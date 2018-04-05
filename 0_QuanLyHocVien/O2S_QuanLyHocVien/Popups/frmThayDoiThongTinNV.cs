// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmThayDoiThongTinNV.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmThayDoiThongTinNV : Form
    {
        public frmThayDoiThongTinNV()
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

        private void frmThayDoiThongTinNV_Load(object sender, EventArgs e)
        {
            cboLoaiNV.DataSource = LoaiNhanVienLogic.SelectAll();
            cboLoaiNV.DisplayMember = "TenLoaiNhanVien";
            cboLoaiNV.ValueMember = "LoaiNhanVienId";

            NHANVIEN nv = NhanVienLogic.SelectSingle(GlobalSettings.UserID);
            txtMaNV.Text = nv.MaNhanVien;
            txtTenNV.Text = nv.TenNhanVien;
            txtEmail.Text = nv.Email;
            txtSDT.Text = nv.Sdt;
            cboLoaiNV.SelectedValue = nv.LoaiNhanVienId;
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();

                NhanVienLogic.Update(new NHANVIEN()
                {
                    MaNhanVien = txtMaNV.Text,
                    TenNhanVien = txtTenNV.Text,
                    Email = txtEmail.Text,
                    Sdt = txtSDT.Text,
                    LoaiNhanVienId =Common.TypeConvert.TypeConvertParse.ToInt32( cboLoaiNV.SelectedValue.ToString())
                });

                MessageBox.Show("Cập nhật thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
