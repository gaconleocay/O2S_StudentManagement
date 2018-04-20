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

        private void frmTrangMoDau_Load(object sender, EventArgs e)
        {
            try
            {
                lblCenter.Text = string.Format("{0}", GlobalSettings.TrungTam_Name).ToUpper();
                lblAddress.Text = string.Format("Địa chỉ: {0}", GlobalSettings.TrungTam_DiaChi);
                lblSoDienThoai.Text = string.Format("Số điện thoại: {0}", GlobalSettings.TrungTam_Phone);
                lblLienHe.Text = string.Format("Liên hệ: {0} - {1}", GlobalSettings.TrungTam_Website, GlobalSettings.TrungTam_Email);

                piclogotrungtam.Image = Image.FromFile(@"Picture\logo.jpg");

                //Co so trung tam
                lblCoSo_Ten.Text = string.Format("{0}", GlobalSettings.CoSo_Ten).ToUpper();
                lblCoSo_DiaChi.Text = string.Format("Địa chỉ: {0}", GlobalSettings.CoSo_DiaChi);
                lblCoSo_SDT.Text = string.Format("Số điện thoại: {0}", GlobalSettings.CoSo_Sdt);
                lblCoSo_Email.Text = string.Format("Liên hệ: {0} - {1}", GlobalSettings.CoSo_Email, GlobalSettings.TrungTam_Email);
                picCoSo_image.Image = GlobalSettings.CoSo_LogoCoSo;



                lblWelcome.Text = string.Format("Xin chào, {0}", TaiKhoanLogic.FullUserName(new DataAccess.TAIKHOAN() { TenDangNhap = GlobalSettings.UserCode }));
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }





    }
}
