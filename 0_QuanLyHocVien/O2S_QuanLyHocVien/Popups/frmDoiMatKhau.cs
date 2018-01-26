﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmDoiMatKhau.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmDoiMatKhau : Form
    {
        private TAIKHOAN currentUser;

        public frmDoiMatKhau(string userName)
        {
            InitializeComponent();
            currentUser = TaiKhoan.Select(userName);
        }

        #region Events

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

            lblUserName.Text = TaiKhoan.FullUserName(currentUser);

            txtTenDangNhap.Text = GlobalSettings.UserName;
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhauCu.Text == currentUser.MatKhau)
                {
                    if (!string.IsNullOrEmpty(txtMatKhauMoi.Text) && txtMatKhauMoi.Text == txtMatKhauMoiAgain.Text)
                    {
                        currentUser.MatKhau = txtMatKhauMoi.Text;
                        TaiKhoan.Update(currentUser);

                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Mật khẩu mới trống hoặc không khớp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Mật khẩu cũ không chính xác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
