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
                GlobalSettings.MaDatabase = Base.KiemTraLicense.LayThongTinMaDatabase();
                LICENSE _license = License.Select(GlobalSettings.MaDatabase);
                if (_license == null) //Insert
                {
                    LICENSE _insert = new LICENSE();
                    _insert.DataKey = GlobalSettings.MaDatabase;
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
                    //TAIKHOAN tk = TaiKhoan.Select(txtTenDangNhap.Text);
                    GlobalSettings.UserID = "-1";
                    GlobalSettings.UserCode = txtTenDangNhap.Text.Trim().ToLower();
                    GlobalSettings.UserName = "Administrator";
                    GlobalSettings.UserType = UserType.QuanTri;

                    Settings.Default.Login_UserName = txtTenDangNhap.Text;
                    Settings.Default.Login_Password = txtMatKhau.Text;
                    Settings.Default.Save();
                    LoadDuLieuSauKhiDangNhap();
                    LayCoSoTrungTam();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (TaiKhoan.IsValid(txtTenDangNhap.Text, txtMatKhau.Text))
                    {
                        TAIKHOAN tk = TaiKhoan.Select(txtTenDangNhap.Text);
                        GlobalSettings.UserID = TaiKhoan.FullUserID(tk);
                        GlobalSettings.UserCode = txtTenDangNhap.Text.Trim().ToLower();
                        GlobalSettings.UserName = TaiKhoan.FullUserName(tk);
                        GlobalSettings.UserType = (UserType)TaiKhoan.FullUserType(tk);

                        Settings.Default.Login_UserName = txtTenDangNhap.Text;
                        Settings.Default.Login_Password = txtMatKhau.Text;
                        Settings.Default.Save();
                        Base.KiemTraLicense.KiemTraLicenseHopLe();
                        LoadDuLieuSauKhiDangNhap();
                        LayCoSoTrungTam();
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

        private void LayCoSoTrungTam()
        {
            try
            {
                if (GlobalSettings.UserType != UserType.HocVien) //khong phai Hoc vien
                {
                    List<COSOTRUNGTAM> ObjectList = CoSoTrungTam.SelectAll() as List<COSOTRUNGTAM>;
                    if (ObjectList.Count == 1)
                    {
                        GlobalSettings.MaCoSo = ObjectList[0].MaCoSo;
                        GlobalSettings.TenCoSo = ObjectList[0].TenCoSo;
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
                GlobalSettings.SessionLstPhanQuyenNguoiDung = Base.CheckPermission.GetListPhanQuyenNguoiDung();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

    }
}
