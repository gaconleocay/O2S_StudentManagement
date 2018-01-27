// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmDangNhap.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.Properties;

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
            chkSave.Checked = Settings.Default.Login_IsSaved;

            if (chkSave.Checked)
            {
                txtTenDangNhap.Text = Settings.Default.Login_UserName;
                txtMatKhau.Text = Settings.Default.Login_Password;
            }

            lblNotification.Text = string.Empty;
        }

        #endregion

        #region Events

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.IsValid(txtTenDangNhap.Text, txtMatKhau.Text))
            {
                TAIKHOAN tk = TaiKhoan.Select(txtTenDangNhap.Text);
                GlobalSettings.UserID = TaiKhoan.FullUserID(tk);
                GlobalSettings.UserName = txtTenDangNhap.Text;
                GlobalSettings.UserType = (UserType)TaiKhoan.FullUserType(tk);

                Settings.Default.Login_UserName = txtTenDangNhap.Text;
                Settings.Default.Login_Password = txtMatKhau.Text;
                Settings.Default.Save();

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblNotification.Text = "Tên đăng nhập hoặc mật khẩu không chính xác";
                System.Media.SystemSounds.Exclamation.Play();
            }
        }
        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Login_IsSaved = chkSave.Checked;
            Settings.Default.Save();
        }
        #endregion

    }
}
