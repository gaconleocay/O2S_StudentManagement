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
                KiemTraInsertMayTram();
                LoadDefaultValue();
                KiemTraVaCopyFileLaucherNew();
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
                chkSave.Checked = Settings.Default.Login_IsSaved;

                if (chkSave.Checked)
                {
                    txtTenDangNhap.Text = Settings.Default.Login_UserName;
                    txtMatKhau.Text = Settings.Default.Login_Password;
                }

                lblNotification.Text = string.Empty;
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
                Base.SessionLogin.MaDatabase = Base.KiemTraLicense.LayThongTinMaDatabase();
                LICENSE _license = License.Select(Base.SessionLogin.MaDatabase);
                if (_license == null) //Insert
                {
                    LICENSE _insert = new LICENSE();
                    _insert.DataKey = Base.SessionLogin.MaDatabase;
                    _insert.LicenseKey = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt("", true);
                    License.Insert(_insert);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Events

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenDangNhap.Text.ToLower() == KeyTrongPhanMem.AdminUser_key && txtMatKhau.Text == KeyTrongPhanMem.AdminPass_key)
                {
                    Base.SessionLogin.SessionUsercode = txtTenDangNhap.Text.Trim().ToLower();
                    Base.SessionLogin.SessionUsername = "Administrator";

                    //TAIKHOAN tk = TaiKhoan.Select(txtTenDangNhap.Text);
                    GlobalSettings.UserID = "-1";
                    GlobalSettings.UserName = txtTenDangNhap.Text;
                    //GlobalSettings.UserType = (UserType)TaiKhoan.FullUserType(tk);

                    Settings.Default.Login_UserName = txtTenDangNhap.Text;
                    Settings.Default.Login_Password = txtMatKhau.Text;
                    Settings.Default.Save();
                    LoadDuLieuSauKhiDangNhap();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (TaiKhoan.IsValid(txtTenDangNhap.Text, txtMatKhau.Text))
                    {
                        Base.SessionLogin.SessionUsercode = txtTenDangNhap.Text.Trim().ToLower();
                        Base.SessionLogin.SessionUsername = txtTenDangNhap.Text.Trim().ToLower();

                        TAIKHOAN tk = TaiKhoan.Select(txtTenDangNhap.Text);
                        GlobalSettings.UserID = TaiKhoan.FullUserID(tk);
                        GlobalSettings.UserName = txtTenDangNhap.Text;
                        GlobalSettings.UserType = (UserType)TaiKhoan.FullUserType(tk);

                        Settings.Default.Login_UserName = txtTenDangNhap.Text;
                        Settings.Default.Login_Password = txtMatKhau.Text;
                        Settings.Default.Save();
                        Base.KiemTraLicense.KiemTraLicenseHopLe();
                        LoadDuLieuSauKhiDangNhap();
                        this.DialogResult = DialogResult.OK;
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
        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Login_IsSaved = chkSave.Checked;
            Settings.Default.Save();
        }
        #endregion

        #region Kiem tra va copy Lanucher
        private void KiemTraVaCopyFileLaucherNew()
        {
            try
            {
                VERSION dataversion = BusinessLogic.Version.Select(1);
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

        #region Load Du Lieu sau khi Dang nhap
        private void LoadDuLieuSauKhiDangNhap()
        {
            try
            {
                Base.SessionLogin.SessionLstPhanQuyenNguoiDung = Base.CheckPermission.GetListPhanQuyenNguoiDung();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

    }
}
