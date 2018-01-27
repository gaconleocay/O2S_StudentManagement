using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Configuration;
using System.Diagnostics;
using O2S_StudentManagement.Base;
using DevExpress.XtraSplashScreen;
using O2S_StudentManagement.Model.Models;
using JWT;
using System.Data.SqlClient;

namespace O2S_StudentManagement.GUI.FormCommon
{
    public partial class frmConnectDB : Form
    {
        O2S_StudentManagement.DAL.ConnectDatabase condb = new O2S_StudentManagement.DAL.ConnectDatabase();
        string en_licensekeynull = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt("", true);
        public frmConnectDB()
        {
            InitializeComponent();
        }

        private void frmConnectDB_Load(object sender, EventArgs e)
        {
            this.txtDBHost.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim(), true);
            this.txtDBUser.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
            this.txtDBPass.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
            this.txtDBName.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);
        }

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

        // Lưu lại giá trị vào file config
        private void tbnDBLuu_Click(object sender, EventArgs e)
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
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
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
                //if (DAL.KetNoiSCDLProcess.CapNhatCoSoDuLieu())
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



    }
}
