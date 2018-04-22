// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmDangNhap.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.Properties;
using System.Data;
using System.IO;
using O2S_License.PasswordKey;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Configuration;
using System.Drawing;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        #region Load
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            try
            {
                if (!GlobalSettings.ConnectToDatabase())
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ReconnectDB();
                }
                else
                {
                    LoadDuLieuChuongTrinh();
                    KiemTraInsertMayTram();
                    LoadDefaultValue();
                    KiemTraVaCopyFileLaucherNew();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadDuLieuChuongTrinh()
        {
            try
            {
                GlobalSettings.LoadCenterInformation();
                GlobalSettings.LoadQuyDinh();
                //ten may
                GlobalSettings.SessionMachineName = Environment.MachineName;
                // Địa chỉ Ip
                String strHostName = Dns.GetHostName();
                IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
                //int nIP = 0;
                string listIP = "";
                for (int i = 0; i < iphostentry.AddressList.Count(); i++)
                {
                    listIP += iphostentry.AddressList[i] + ";";
                }
                GlobalSettings.SessionMyIP = listIP;
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
                GlobalSettings.MaDatabase = Base.KiemTraLicense.LayThongTinMaDatabase();
                LICENSE _license = LicenseLogic.Select(GlobalSettings.MaDatabase);
                if (_license == null) //Insert
                {
                    LICENSE _insert = new LICENSE();
                    _insert.DataKey = GlobalSettings.MaDatabase;
                    _insert.LicenseKey = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt("", true);
                    LicenseLogic.Insert(_insert);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadDefaultValue()
        {
            try
            {
                chkSave.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["checkEditNhoPass"]); ;

                if (chkSave.Checked)
                {
                    txtTenDangNhap.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["LoginUser"].ToString(), true);
                    txtMatKhau.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["LoginPassword"].ToString(), true);
                }
                else
                { txtTenDangNhap.Text = string.Empty;
                    txtMatKhau.Text = string.Empty;
                }

                lblNotification.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #region Kiem tra va copy Lanucher
        private void KiemTraVaCopyFileLaucherNew()
        {
            try
            {
                VERSION dataversion = BusinessLogic.VersionLogic.Select();
                if (dataversion != null)
                {
                    CopyFolder_CheckSum(dataversion.AppLink, Environment.CurrentDirectory);
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
                    if (name.Contains("O2S_QuanLyHocVienLauncher"))
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

        private void ReconnectDB()
        {
            frmKetNoiCSDL frm = new frmKetNoiCSDL();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn cần khởi động lại chương trình để thay đổi có hiệu lực." + Environment.NewLine + "Khởi động ngay?", "Khởi động lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    Application.Restart();
                else
                    Application.Exit();
            }
            else
            {
                MessageBox.Show("Bạn không thể sử dụng chương trình nếu kết nối cơ sở dữ liệu chưa được thiết lập" + Environment.NewLine + "Hãy chạy lại chương trình vào lần tới để thiết lập lại kết nối cơ sở dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        #endregion

        #region Events

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenDangNhap.Text.ToLower() == KeyTrongPhanMem.AdminUser_key && txtMatKhau.Text == KeyTrongPhanMem.AdminPass_key)
                {
                    //TAIKHOAN tk = TaiKhoan.Select(txtTenDangNhap.Text);
                    GlobalSettings.UserID = -1;
                    GlobalSettings.UserCode = txtTenDangNhap.Text.Trim().ToLower();
                    GlobalSettings.UserName = "Administrator";
                    GlobalSettings.UserType = UserType.QuanTri;

                    //Settings.Default.Login_UserName = txtTenDangNhap.Text;
                    //Settings.Default.Login_Password = txtMatKhau.Text;
                    //Settings.Default.Save();
                    LoadDuLieuSauKhiDangNhap();
                }
                else
                {
                    if (TaiKhoanLogic.IsValid(txtTenDangNhap.Text, txtMatKhau.Text))
                    {
                        TAIKHOAN _taikhoan = TaiKhoanLogic.Select(txtTenDangNhap.Text);
                        GlobalSettings.UserID = _taikhoan.TaiKhoanId;//TaiKhoanLogic.FullUserID(_taikhoan);
                        GlobalSettings.UserCode = txtTenDangNhap.Text.Trim().ToLower();
                        GlobalSettings.UserName = TaiKhoanLogic.FullUserName(_taikhoan);
                        GlobalSettings.UserType = (UserType)TaiKhoanLogic.FullUserType(_taikhoan);

                        //Settings.Default.Login_UserName = txtTenDangNhap.Text;
                        //Settings.Default.Login_Password = txtMatKhau.Text;
                        //Settings.Default.Save();
                        Base.KiemTraLicense.KiemTraLicenseHopLe();
                        LoadDuLieuSauKhiDangNhap();
                    }
                    else
                    {
                        lblNotification.Text = "Tên đăng nhập hoặc mật khẩu không chính xác";
                        System.Media.SystemSounds.Exclamation.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Load Du Lieu sau khi Dang nhap
        private void LoadDuLieuSauKhiDangNhap()
        {
            try
            {
                //GlobalSettings.SessionLstPhanQuyenNguoiDung = Base.CheckPermission.GetListPhanQuyenNguoiDung();
                LayCoSoTrungTam();
                LuuLaiThongTinDangNhap();
                frmMainHome frmChon = new frmMainHome();
                frmChon.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LayCoSoTrungTam()
        {
            try
            {
                if (GlobalSettings.UserType != UserType.HocVien) //khong phai Hoc vien
                {
                    List<COSOTRUNGTAM> ObjectList = CoSoTrungTamLogic.SelectAll() as List<COSOTRUNGTAM>;
                    if (ObjectList.Count == 1)
                    {
                        GlobalSettings.CoSoId = ObjectList[0].CoSoId;
                        GlobalSettings.CoSo_Ten = ObjectList[0].TenCoSo;
                        if (ObjectList[0].LogoCoSo != null && ObjectList[0].LogoCoSo.Length > 0)
                        {
                            byte[] Empimage = (byte[])(ObjectList[0].LogoCoSo).ToArray();
                            GlobalSettings.CoSo_LogoCoSo = Image.FromStream(new MemoryStream(Empimage));
                        }
                        else
                        { GlobalSettings.CoSo_LogoCoSo = null; }
                    }
                    else
                    {
                        frmChonCoSo _frm = new frmChonCoSo();
                        _frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LuuLaiThongTinDangNhap()
        {
            try
            {
                // Khi được check vào nút ghi nhớ thì sẽ lưu tên đăng nhập và mật khẩu vào file config
                if (chkSave.Checked)
                {
                    Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["checkEditNhoPass"].Value = Convert.ToString(chkSave.Checked);
                    _config.AppSettings.Settings["LoginUser"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtTenDangNhap.Text.Trim(), true);
                    _config.AppSettings.Settings["LoginPassword"].Value = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(txtMatKhau.Text.Trim(), true);
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
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTenDangNhap.Text.ToLower() == "config")
                {
                    frmKetNoiCSDL _frm = new frmKetNoiCSDL();
                    _frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
