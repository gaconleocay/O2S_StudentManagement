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
using System.Net;
using System.Diagnostics;
using O2S_StudentManagement.Base;
using System.IO;
using O2S_StudentManagement.Utilities;
using System.Data.SqlClient;
using O2S_License.PasswordKey;

namespace O2S_StudentManagement.GUI.FormCommon
{
    public partial class frmLogin : Form
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new O2S_StudentManagement.DAL.ConnectDatabase();

        #endregion
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Load
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                KiemTraKetNoiDenCoSoDuLieu();
                KiemTraInsertMayTram();
                LoadDataFromDatabase();
                LoadDefaultValue();
                KiemTraVaCopyFileLaucherNew();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void KiemTraKetNoiDenCoSoDuLieu()
        {
            try
            {
                string _loithongbao = "";

                string serverhost = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
                string serveruser = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
                string serverpass = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
                string serverdb = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);

                //Kiem tra ket noi den CSDL
                string connstring_BGX = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};", serverhost, serverdb, serveruser, serverpass);
                SqlConnection conn_BGX = new SqlConnection(connstring_BGX);
                try
                {
                    conn_BGX.Open();
                }
                catch (Exception)
                {
                    _loithongbao += "Lỗi kết nối đến CSDL!";
                }

                // thong bao
                if (_loithongbao != "")
                {
                    MessageBox.Show(_loithongbao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void KiemTraInsertMayTram()
        {
            try
            {
                SessionLogin.MaDatabase = Base.KiemTraLicense.LayThongTinMaDatabase();
                string license_trang = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt("", true);
                string kiemtra_client = "SELECT * FROM SM_LICENSE WHERE datakey='" + SessionLogin.MaDatabase + "' ;";
                DataView dv = new DataView(condb.GetDataTable(kiemtra_client));
                if (dv != null && dv.Count > 0)
                {
                    //Kiem tra license
                    //O2S_StudentManagement.GUI.FormCommon.DangKyBanQuyen.kiemTraLicenseHopLe.KiemTraLicenseHopLe();
                }
                else
                {
                    string insert_client = "INSERT INTO SM_LICENSE(datakey, licensekey) VALUES ('" + SessionLogin.MaDatabase + "','" + license_trang + "' );";
                    condb.GetDataTable(insert_client);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadDataFromDatabase()
        {
            try
            {
                BUS.LoadDataSystems.LoadDataOption();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDefaultValue()
        {
            try
            {
                if (ConfigurationManager.AppSettings["LoginUser"].ToString() != "" && ConfigurationManager.AppSettings["LoginPassword"].ToString() != "")
                {
                    this.txtUsername.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["LoginUser"].ToString(), true);
                    this.txtPassword.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["LoginPassword"].ToString(), true);
                    this.checkEditNhoPass.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["checkEditNhoPass"]);
                }
                else
                {
                    this.txtUsername.Text = "";
                    this.txtPassword.Text = "";
                }
                txtUsername.Focus();

                SessionLogin.SessionMachineName = Environment.MachineName;
                // Địa chỉ Ip
                String strHostName = Dns.GetHostName();
                IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
                //int nIP = 0;
                string listIP = "";
                for (int i = 0; i < iphostentry.AddressList.Count(); i++)
                {
                    listIP += iphostentry.AddressList[i] + ";";
                }
                SessionLogin.SessionMyIP = listIP;
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                SessionLogin.SessionVersion = fvi.FileVersion;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #region Kiem tra va copy Lanucher
        private void KiemTraVaCopyFileLaucherNew()
        {
            try
            {
                DataView dataurlfile = new DataView(condb.GetDataTable("select top 1 app_link from SM_VERSION where app_type=0;"));
                if (dataurlfile != null && dataurlfile.Count > 0)
                {
                    string tempDirectory = dataurlfile[0]["app_link"].ToString();
                    CopyFolder_CheckSum(tempDirectory, Environment.CurrentDirectory);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private static void CopyFolder_CheckSum(string SourceFolder, string DestFolder)
        {
            Directory.CreateDirectory(DestFolder); //Tao folder moi
            string[] files = Directory.GetFiles(SourceFolder);
            //Neu co file thi phai copy file
            foreach (string file in files)
            {
                try
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(DestFolder, name);
                    if (name.Contains("O2S StudentManagementLauncher"))
                    {
                        //Check file
                        if (Common.Checksum.GetFileCheckSum.GetMD5HashFromFile(file) != Common.Checksum.GetFileCheckSum.GetMD5HashFromFile(dest))
                        {
                            File.Copy(file, dest, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    continue;
                    Common.Logging.LogSystem.Error("Lỗi copy file check_sum" + ex.ToString());
                }
            }

            string[] folders = Directory.GetDirectories(SourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(DestFolder, name);
                CopyFolder_CheckSum(folder, dest);
            }
        }
        #endregion

        #endregion

        #region Click Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();
                    return;
                }
                // tạo 1 tài khoản ở trên PM, không chứa trong DB để làm tài khoản admin
                else if (txtUsername.Text.ToLower() == KeyTrongPhanMem.AdminUser_key && txtPassword.Text == KeyTrongPhanMem.AdminPass_key)
                {
                    SessionLogin.SessionUserID = -1;
                    SessionLogin.SessionUsercode = txtUsername.Text.Trim().ToLower();
                    SessionLogin.SessionUsername = "Administrator";

                    LoadDuLieuSauKhiDangNhap();
                }
                else
                {
                    string en_txtUsername = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtUsername.Text.Trim().ToLower(), true);
                    string en_txtPassword = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtPassword.Text.Trim(), true);
                    try
                    {
                        string command = "SELECT id, usercode, username, userpassword FROM SM_TBLUSER WHERE usercode='" + en_txtUsername + "' and userpassword='" + en_txtPassword + "';";
                        DataView dv = new DataView(condb.GetDataTable(command));
                        if (dv != null && dv.Count > 0)
                        {
                            Base.KiemTraLicense.KiemTraLicenseHopLe();
                            SessionLogin.SessionUserID = Common.TypeConvert.TypeConvertParse.ToInt64(dv[0]["userid"].ToString());
                            SessionLogin.SessionUsercode = txtUsername.Text.Trim().ToLower();
                            SessionLogin.SessionUsername = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(dv[0]["username"].ToString(), true);

                            LoadDuLieuSauKhiDangNhap();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Logging.LogSystem.Error(ex);
                        txtUsername.Focus();
                    }
                }

                // Khi được check vào nút ghi nhớ thì sẽ lưu tên đăng nhập và mật khẩu vào file config
                if (checkEditNhoPass.Checked)
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["checkEditNhoPass"].Value = Convert.ToString(checkEditNhoPass.Checked);
                    _config.AppSettings.Settings["LoginUser"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtUsername.Text.Trim(), true);
                    _config.AppSettings.Settings["LoginPassword"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtPassword.Text.Trim(), true);
                    _config.Save(ConfigurationSaveMode.Modified);

                    ConfigurationManager.RefreshSection("appSettings");
                }
                // không thì sẽ xóa giá trị đã lưu trong file congfig đi
                else
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["checkEditNhoPass"].Value = "false";
                    _config.AppSettings.Settings["LoginUser"].Value = "";
                    _config.AppSettings.Settings["LoginPassword"].Value = "";
                    _config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn("Dang nhap " + ex.ToString());
            }
        }

        private void LoadDuLieuSauKhiDangNhap()
        {
            try
            {
                SessionLogin.SessionLstPhanQuyenNguoiDung = O2S_StudentManagement.Base.CheckPermission.GetListPhanQuyenNguoiDung();
               // SessionLogin.SessionlstPhanQuyen_KhoaPhong = O2S_StudentManagement.Base.CheckPermission.GetPhanQuyen_KhoaPhong();

                frmMain frmChon = new frmMain();
                frmChon.Show();
                this.Visible = false;

                Common.Logging.LogSystem.Info("Application open successfull. Time=" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"));
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Custom
        // Khi nhập username và nhấn enter thì forcus vào ô nhập pass
        private void txtUsername_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPassword.Text != "")
                {
                    btnLogin.PerformClick();
                }
                else
                {
                    txtPassword.Focus();
                }
            }
        }

        // Sau khi nhập password và ấn enter thì đăng nhập luôn
        private void txtPassword_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        // nếu viết vào ô username = "config" thì mở ra bảng để cấu hình DB
        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.ToUpper() == "CONFIG")
            {
                frmConnectDB frmcon = new frmConnectDB();
                frmcon.Dock = System.Windows.Forms.DockStyle.Bottom;
                frmcon.ShowDialog();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
                this.Dispose();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void linkTroGiup_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Liên hệ với tác giả để được trợ giúp! \nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông tin về tác giả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

    }
}
