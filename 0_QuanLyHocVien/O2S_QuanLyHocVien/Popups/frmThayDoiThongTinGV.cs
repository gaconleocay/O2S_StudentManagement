// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmThayDoiThongTinGV.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmThayDoiThongTinGV : Form
    {
        public frmThayDoiThongTinGV()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểm tra hợp lệ
        /// </summary>
        public void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại không được trống");
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                throw new ArgumentException("Email không được trống");
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThayDoiThongTinGV_Load(object sender, EventArgs e)
        {
            GIANGVIEN gv = GiangVien.Select(GlobalSettings.UserID);
            txtMaGV.Text = gv.MaGiangVien;
            txtTenGV.Text = gv.TenGiangVien;
            cboGioiTinh.Text = gv.GioiTinhGiangVien;
            txtEmail.Text = gv.EmailGiangVien;
            txtSDT.Text = gv.SdtGiangVien;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();

                GiangVien.Update(new GIANGVIEN()
                {
                    MaGiangVien = txtMaGV.Text,
                    TenGiangVien = txtTenGV.Text,
                    GioiTinhGiangVien = cboGioiTinh.Text,
                    EmailGiangVien = txtEmail.Text,
                    SdtGiangVien = txtSDT.Text
                });

                MessageBox.Show("Cập nhật thông tin giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
