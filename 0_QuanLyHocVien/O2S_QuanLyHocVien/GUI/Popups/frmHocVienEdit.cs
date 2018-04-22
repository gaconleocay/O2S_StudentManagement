// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmHocVienEdit.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Globalization;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmHocVienEdit : Form
    {
        private HOCVIEN hocVienCurrent;
        private bool isInsert = true;

        public frmHocVienEdit(HOCVIEN hv)
        {
            InitializeComponent();
            this.hocVienCurrent = hv;
            isInsert = hv == null;
        }

        /// <summary>
        /// Nạp học viên lên giao diện
        /// </summary>
        /// <param name="hv"></param>
        public void LoadUI(HOCVIEN hv)
        {
            if (hv == null)
            {
                cboGioiTinh.SelectedIndex = 0;
            }
            else
            {
                txtMaHV.Text = hv.HocVienId.ToString();
                txtHoTen.Text = hv.TenHocVien;
                dateNgaySinh.Value = (DateTime)hv.NgaySinh;
                cboGioiTinh.Text = hv.GioiTinh;
                txtDiaChi.Text = hv.DiaChi;
                txtSDT.Text = hv.Sdt;
                txtEmail.Text = hv.Email;
                cboLoaiHV.SelectedValue = hv.LoaiHocVienId;

                if (hv.LoaiHocVienId == 2)
                {
                    cboLoaiHV.Enabled = false;
                    txtMatKhau.Enabled = false;
                }

                if (hv.TaiKhoanId != null && hv.TaiKhoanId != 0)
                {
                    txtTenDangNhap.Text = hv.TAIKHOAN.TenDangNhap;
                    txtMatKhau.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(hv.TAIKHOAN.MatKhau, true);
                }
                else
                    txtTenDangNhap.Text = txtMatKhau.Text = string.Empty;
            }
        }

        /// <summary>
        /// Nạp giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        private HOCVIEN LoadHocVien()
        {
            return new HOCVIEN()
            {
                HocVienId = Common.TypeConvert.TypeConvertParse.ToInt32(txtMaHV.Text),
                TenHocVien = txtHoTen.Text,
                NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                GioiTinh = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                Sdt = txtSDT.Text,
                Email = txtEmail.Text,
                LoaiHocVienId = Common.TypeConvert.TypeConvertParse.ToInt32(cboLoaiHV.SelectedValue.ToString()),
                NgayTiepNhan = DateTime.Now,
                //TenDangNhap = (string)cboLoaiHV.SelectedValue == "2" ? null : txtTenDangNhap.Text,
                CoSoId = GlobalSettings.CoSoId
            };
        }

        /// <summary>
        /// Kiểm tra hợp lệ
        /// </summary>
        public void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                throw new ArgumentException("Họ và tên học viên không được trống");
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                throw new ArgumentException("Địa chỉ học viên không được trống");
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại học viên không được trống");
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHocVienEdit_Load(object sender, EventArgs e)
        {
            cboLoaiHV.DataSource = LoaiHocVienLogic.SelectAll();
            cboLoaiHV.DisplayMember = "TenLoaiHocVien";
            cboLoaiHV.ValueMember = "LoaiHocVienId";

            LoadUI(hocVienCurrent);
        }

        private void cboLoaiHV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLoaiHV.SelectedValue.ToString() != "2")
            {
                txtMatKhau.Enabled = true;
                txtTenDangNhap.Text = txtMaHV.Text;
                txtMatKhau.Text = txtMaHV.Text;
            }
            else
            {
                txtMatKhau.Enabled = false;
                txtTenDangNhap.Text = string.Empty;
                txtMatKhau.Text = string.Empty;
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();

                if (isInsert)
                {
                    int _hocVienId = 0;
                    if (HocVienLogic.Insert(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    }, ref _hocVienId))
                    {
                        MessageBox.Show("Thêm học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    HocVienLogic.Update(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Sửa học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
