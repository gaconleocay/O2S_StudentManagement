using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Npgsql;
using DevExpress.XtraSplashScreen;
using System.Net.Http;
using System.Net.Http.Headers;
using O2S_StudentManagement.Model.Models;
using System.Data.SqlClient;
using O2S_StudentManagement.DAL;

namespace O2S_StudentManagement.GUI.MenuTrangChu
{
    public partial class ucSettingDatabase : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion
        public ucSettingDatabase()
        {
            InitializeComponent();
        }

        #region Load
        private void ucSettingDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                LoadKetNoiDatabase();
                KiemTraTonTaiVaInsertLinkVersion();
                LoadCauHinhUpdateVersion();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadKetNoiDatabase()
        {
            try
            {
                this.txtDBHost.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim(), true);
                this.txtDBUser.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
                this.txtDBPass.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
                this.txtDBName.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void KiemTraTonTaiVaInsertLinkVersion()
        {
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    List<SM_VERSION> lstVersion = db.SM_VERSION.Where(o => o.app_type == 0).ToList();
                    if (lstVersion == null || lstVersion.Count != 1)
                    {
                        SM_VERSION _verAdd = new SM_VERSION();
                        _verAdd.appversion = "?.?.?.?";
                        _verAdd.app_type = 0;

                        db.SM_VERSION.Add(_verAdd);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadCauHinhUpdateVersion()
        {
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    List<SM_VERSION> lstVersion = db.SM_VERSION.Where(o => o.app_type == 0).ToList();
                    if (lstVersion == null || lstVersion.Count > 0)
                    {
                        txtUpdateVersionLink.Text = lstVersion[0].app_link;
                        txtUrlFullServer.Text = lstVersion[0].urlfullserver;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Events
        private void btnDBKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring_BGX = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};", txtDBHost.Text, txtDBName.Text, txtDBUser.Text, txtDBPass.Text);
                SqlConnection conn_BGX = new SqlConnection(connstring_BGX);
                try
                {
                    conn_BGX.Open();
                    MessageBox.Show("Kết nối đến cơ sở dữ liệu thành công!", "Thông báo");
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi kết nối đến CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void btnDBLuu_Click(object sender, EventArgs e)
        {
            try
            {
                LuuLaiCauHinhFileConfig();
                LuuLaiDuongDanUpdateVersion();
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LuuLaiCauHinhFileConfig()
        {
            try
            {
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _config.AppSettings.Settings["ServerHost"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBHost.Text.Trim(), true);
                _config.AppSettings.Settings["Username"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBUser.Text.Trim(), true);
                _config.AppSettings.Settings["Password"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBPass.Text.Trim(), true);
                _config.AppSettings.Settings["Database"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtDBName.Text.Trim(), true);

                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LuuLaiDuongDanUpdateVersion()
        {
            try
            {
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    SM_VERSION _Version = db.SM_VERSION.Where(o => o.app_type == 0).FirstOrDefault();
                    if (_Version == null)
                    {
                        _Version.app_link = txtUpdateVersionLink.Text.Trim();
                        _Version.urlfullserver = txtUrlFullServer.Text;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void btnDBUpdate_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(O2S_StudentManagement.Utilities.ThongBao.WaitForm1));
            try
            {
                //if (O2S_StudentManagement.DAL.KetNoiSCDLProcess.CapNhatCoSoDuLieu())
                //{
                //    MessageBox.Show("Cập nhật cơ sở dữ liệu thành công", "Thông báo");
                //}
                //else
                //{
                //    MessageBox.Show("Cập nhật cơ sở dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        #endregion
    }
}
