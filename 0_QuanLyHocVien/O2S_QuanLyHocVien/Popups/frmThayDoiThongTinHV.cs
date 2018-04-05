// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmThayDoiThongTinHV.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Globalization;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmThayDoiThongTinHV : Form
    {
        private HOCVIEN hv;

        public frmThayDoiThongTinHV()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểm tra hợp lệ
        /// </summary>
        public void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                throw new ArgumentException("Địa chỉ không được trống");
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại không được trống");
        }


        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThayDoiThongTinHV_Load(object sender, EventArgs e)
        {
            hv = HocVienLogic.SelectSingle(GlobalSettings.UserID);

            txtMaHV.Text = hv.MaHocVien;
            txtTenHocVien.Text = hv.TenHocVien;
            dateNgaySinh.Value = (DateTime)hv.NgaySinh;
            cboGioiTinh.Text = hv.GioiTinh;
            txtDiaChi.Text = hv.DiaChi;
            txtSDT.Text = hv.Sdt;
            txtEmail.Text = hv.Email;
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

                HocVienLogic.Update(new HOCVIEN()
                {
                    MaHocVien = txtMaHV.Text,
                    TenHocVien = txtTenHocVien.Text,
                    GioiTinh = cboGioiTinh.Text,
                    NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DiaChi = txtDiaChi.Text,
                    Sdt = txtSDT.Text,
                    Email = txtEmail.Text,
                    HocVienId = hv.HocVienId
                });

                MessageBox.Show("Cập nhật thông tin học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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

