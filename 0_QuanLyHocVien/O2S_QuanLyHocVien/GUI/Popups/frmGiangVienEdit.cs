// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmGiangVienEdit.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmGiangVienEdit : Form
    {
        private GIANGVIEN gv;
        private bool isInsert;

        public frmGiangVienEdit(GIANGVIEN gv)
        {
            InitializeComponent();
            this.gv = gv;
            isInsert = gv == null;
        }

        /// <summary>
        /// Nạp giảng viên lên giao diện
        /// </summary>
        /// <param name="gv"></param>
        public void LoadUI(GIANGVIEN gv)
        {
            if (gv == null)
            {
                //txtMaGV.Text = GiangVienLogic.AutoGenerateId();
                cboGioiTinh.SelectedIndex = 0;
            }
            else
            {
                txtMaGV.Text = gv.MaGiangVien;
                txtTenGV.Text = gv.TenGiangVien;
                cboGioiTinh.Text = gv.GioiTinh;
                txtSDT.Text = gv.Sdt;
                txtEmail.Text = gv.Email;
                txtTenDangNhap.Text = gv.TAIKHOAN.TenDangNhap;
                txtMatKhau.Text = gv.TAIKHOAN.MatKhau;
                txtTenDangNhap.Enabled = false;
            }
        }

        /// <summary>
        /// Nạp giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        private GIANGVIEN LoadGiangVien()
        {
            return new GIANGVIEN()
            {
                GiangVienId = Common.TypeConvert.TypeConvertParse.ToInt32(txtMaGV.Text),
                TenGiangVien = txtTenGV.Text,
                GioiTinh = cboGioiTinh.Text,
                Sdt = txtSDT.Text,
                Email = txtEmail.Text,
                //TenDangNhap = txtTenDangNhap.Text,
                CoSoId=GlobalSettings.CoSoId
            };
        }

        /// <summary>
        /// Kiểm tra hợp lệ
        /// </summary>
        public void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtTenGV.Text))
                throw new ArgumentException("Họ và tên giảng viên không được trống");
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại giảng viên không được trống");
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                throw new ArgumentException("Email giảng viên không được trống");
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                throw new ArgumentException("Tên đăng nhập giảng viên không được trống");
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                throw new ArgumentException("Mật khẩu giảng viên không được trống");
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiangVienEdit_Load(object sender, EventArgs e)
        {
            LoadUI(gv);
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

                if (isInsert)
                {
                    GiangVienLogic.Insert(LoadGiangVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Thêm giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GiangVienLogic.Update(LoadGiangVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Sửa giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
