// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmTrangMoDau.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Diagnostics;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using System.Drawing;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmTrangMoDau : Form
    {
        public frmTrangMoDau()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTroGiup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void frmTrangMoDau_Load(object sender, EventArgs e)
        {
            lblCenter.Text = string.Format("{0}", GlobalSettings.CenterName).ToUpper();
            lblAddress.Text = string.Format("Địa chỉ: {0}", GlobalSettings.CenterAddress);
            lblSoDienThoai.Text = string.Format("Số điện thoại: {0}", GlobalSettings.CenterTelephone);
            lblLienHe.Text = string.Format("Liên hệ: {0} - {1}", GlobalSettings.CenterWebsite, GlobalSettings.CenterEmail);
            lblWelcome.Text = string.Format("Xin chào, {0}", TaiKhoanLogic.FullUserName(new DataAccess.TAIKHOAN() { TenDangNhap = GlobalSettings.UserCode }));

            piclogotrungtam.Image = Image.FromFile(@"Picture\logo.png");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Process.Start("https://github.com/chidokun/QuanLyHocVien/");
        }
    }
}
