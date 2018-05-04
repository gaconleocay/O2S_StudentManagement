// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmCauHinhPhanMem_CSDL.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using System.Configuration;
using System.Data;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.CauHinh
{
    public partial class frmCauHinhPhanMem_CSDL : Form
    {
        private string connectionString;

        public frmCauHinhPhanMem_CSDL()
        {
            InitializeComponent();
        }

        #region Load
        private void frmCauHinhPhanMem_CSDL_Load(object sender, EventArgs e)
        {
            try
            {
                LoadKetNoiDatabase();
                KiemTraTonTaiVaInsertLinkVersion();
                LoadCauHinhUpdateVersion();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadKetNoiDatabase()
        {
            try
            {
                cboKieuXacThuc.Items.AddRange(new string[]
                {
                "Xác thực của SQL Server"
                });
                cboKieuXacThuc.SelectedIndex = 0;
                //load temp
                txtTenDangNhap.Text = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
                txtMatKhau.Text = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
                txtTenServer.Text = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
                cboDatabase.Text = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void KiemTraTonTaiVaInsertLinkVersion()
        {
            try
            {
                VERSION _version = VersionLogic.Select();
                if (_version == null)
                {
                    VERSION _versionInsert = new VERSION()
                    {
                        AppVersion = "1.0.0.0",
                        //AppLink = txtUpdateVersionLink.Text,
                        AppType = 0,
                    };
                    VersionLogic.Insert(_version);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadCauHinhUpdateVersion()
        {
            try
            {
                VERSION _version = VersionLogic.Select();
                if (_version != null)
                {
                    txtUpdateVersionLink.Text = _version.AppLink;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenServer.Text))
                    throw new ArgumentException("Tên đăng nhập không được trống");

                connectionString = string.Format("Data Source={0};Initial Catalog=master;", txtTenServer.Text);

                if (cboKieuXacThuc.SelectedIndex == 0)
                    connectionString += "Integrated Security=True;";
                else
                    connectionString += string.Format("User Id={0};Password={1};", txtTenDangNhap.Text, txtMatKhau.Text);


                cboDatabase.DataSource = GlobalSettings.GetDatabaseList(connectionString);

                MessageBox.Show("Kết nối thành công!" + Environment.NewLine + "Vui lòng chọn cơ sở dữ liệu trong danh sách bên dưới.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDatabase.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại!" + Environment.NewLine + "Vui lòng thử lại một lần nữa.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboKieuXacThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenDangNhap.Enabled = txtMatKhau.Enabled = cboKieuXacThuc.SelectedIndex == 1;
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            //connectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; ", txtTenServer.Text, cboDatabase.Text);

            //if (cboKieuXacThuc.SelectedIndex == 0)
            //    connectionString += "Integrated Security = True; ";
            //else
            //    connectionString += string.Format("User Id = {0}; Password = {1}; ", txtTenDangNhap.Text, txtMatKhau.Text);

            //GlobalSettings.ConnectionString = connectionString;
            //GlobalSettings.ServerName = txtTenServer.Text;
            //GlobalSettings.ServerCatalog = cboDatabase.Text;

            //GlobalSettings.SaveDatabaseConnection();

            LuuLaiCauHinhFileConfig();
            //luu lai duong dan cap nhat CDSL
            VERSION _version = VersionLogic.Select();
            _version.AppLink = txtUpdateVersionLink.Text;
            if (VersionLogic.Update(_version))
            {
                O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
            }
        }
        private void LuuLaiCauHinhFileConfig()
        {
            try
            {
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _config.AppSettings.Settings["ServerHost"].Value = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(txtTenServer.Text.Trim(), true);
                _config.AppSettings.Settings["Username"].Value = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(txtTenDangNhap.Text.Trim(), true);
                _config.AppSettings.Settings["Password"].Value = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(txtMatKhau.Text.Trim(), true);
                _config.AppSettings.Settings["Database"].Value = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(cboDatabase.Text, true);

                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion
    }
}
