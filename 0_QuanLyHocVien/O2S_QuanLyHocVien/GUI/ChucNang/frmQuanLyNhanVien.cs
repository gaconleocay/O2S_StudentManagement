// Quản lý nhân viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyNhanVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;

namespace O2S_QuanLyHocVien.ChucNang
{
    public partial class frmQuanLyNhanVien : Form
    {
        #region Khai bao
        private bool isInsert = false;
        private int nhanvienId_Select { get; set; }
        #endregion
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddYears(-10).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                dateNgaySinh.MaxDate = DateTime.Now.AddYears(-10);

                LockAndUnlockPanelControl(false);
                LoadDuLieuLoaiHV();
                LoadDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDuLieuLoaiHV()
        {
            cboLoaiNhanVien.DataSource = LoaiNhanVienLogic.SelectAll();
            cboLoaiNhanVien.DisplayMember = "TenLoaiNhanVien";
            cboLoaiNhanVien.ValueMember = "LoaiNhanVienId";
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                NhanVienFilter _filter = new NhanVienFilter();
                _filter.NgayBatDauLamViec_Tu = date_TuNgay.DateTime;
                _filter.NgayBatDauLamViec_Den = date_DenNgay.DateTime;
                List<NhanVien_PlusDTO> _lstNhanVien = NhanVienLogic.Select(_filter);
                if (_lstNhanVien != null && _lstNhanVien.Count > 0)
                {
                    gridControlDSNhanVien.DataSource = _lstNhanVien;
                    lblTongCong.Text = string.Format("Tổng cộng: {0} nhân viên)", _lstNhanVien.Count);
                }
                else
                {
                    gridControlDSNhanVien.DataSource = null;
                    lblTongCong.Text = string.Format("Tổng cộng: {0} nhân viên)", 0);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadPanelControl(NHANVIEN _nhanvien = null)
        {
            try
            {
                if (_nhanvien == null)
                {
                    ResetPanelControl();
                }
                else
                {
                    txtMaHV.Text = _nhanvien.MaNhanVien;
                    txtHoTen.Text = _nhanvien.TenNhanVien;
                    dateNgaySinh.Value = _nhanvien.NgaySinh != null ? (DateTime)_nhanvien.NgaySinh : dateNgaySinh.MaxDate;
                    cboGioiTinh.Text = _nhanvien.GioiTinh;
                    txtDiaChi.Text = _nhanvien.DiaChi;
                    txtSDT.Text = _nhanvien.Sdt;
                    txtEmail.Text = _nhanvien.Email;
                    dateNgayBatDauLamViec.Value = _nhanvien.NgayBatDauLamViec != null ? (DateTime)_nhanvien.NgayBatDauLamViec : DateTime.Now;
                    txtGhiChu.Text = _nhanvien.GhiChu;
                    cboLoaiNhanVien.SelectedValue = _nhanvien.LoaiNhanVienId;
                    txtTenDangNhap.Text = _nhanvien.TAIKHOAN.IsRemove != 1 ? _nhanvien.TAIKHOAN.TenDangNhap : string.Empty;
                    txtMatKhau.Text = _nhanvien.TAIKHOAN.IsRemove != 1 ? O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(_nhanvien.TAIKHOAN.MatKhau, true) : string.Empty;
                }
            }
            catch (Exception ex)
            {
                ResetPanelControl();
                LockAndUnlockPanelControl(false);
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Process
        private void LockAndUnlockPanelControl(bool _result)
        {
            txtHoTen.ReadOnly = !_result;
            dateNgaySinh.Enabled = _result;
            cboGioiTinh.Enabled = _result;
            txtDiaChi.ReadOnly = !_result;
            txtSDT.ReadOnly = !_result;
            txtEmail.ReadOnly = !_result;
            dateNgayBatDauLamViec.Enabled = _result;
            txtTenDangNhap.ReadOnly = !_result;
            txtMatKhau.ReadOnly = !_result;
            txtGhiChu.ReadOnly = !_result;
            cboLoaiNhanVien.Enabled = _result;
            btnLuuThongTin.Enabled = _result;
            btnHuyBo.Enabled = _result;
        }
        private void ResetPanelControl()
        {
            txtMaHV.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            dateNgaySinh.Value = dateNgaySinh.MaxDate;
            cboGioiTinh.SelectedIndex = 0;
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dateNgayBatDauLamViec.Value = DateTime.Now;
            txtGhiChu.Text = string.Empty;
            cboLoaiNhanVien.SelectedIndex = 0;
            txtTenDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }
        private NHANVIEN LoadNhanVien()
        {
            NHANVIEN _hocVien = new NHANVIEN()
            {
                NhanVienId = this.nhanvienId_Select,
                TenNhanVien = txtHoTen.Text,
                NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                GioiTinh = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                Sdt = txtSDT.Text,
                Email = txtEmail.Text,
                NgayBatDauLamViec = DateTime.ParseExact(dateNgayBatDauLamViec.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                GhiChu = txtGhiChu.Text,
                LoaiNhanVienId = (int)cboLoaiNhanVien.SelectedValue,
            };
            return _hocVien;
        }
        private TAIKHOAN LoadTaiKhoan()
        {
            int _loaitaikhoan = KeySetting.LOAITAIKHOAN_NhanVien;
            if ((int)cboLoaiNhanVien.SelectedValue == KeySetting.LOAINHANVIEN_QuanTri)
            { _loaitaikhoan = KeySetting.LOAITAIKHOAN_QuanTri; }

            TAIKHOAN _taikhoan = new TAIKHOAN()
            {
                TenDangNhap = txtTenDangNhap.Text,
                MatKhau = txtMatKhau.Text,
                LoaiTaiKhoanId =_loaitaikhoan,
            };
            return _taikhoan;
        }
        private void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                throw new ArgumentException("Họ và tên không được trống");
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại không được trống");
        }
        private void ValidateTrungTaiKhoan(string _tendangnhap)
        {
            TAIKHOAN _taikhoan = TaiKhoanLogic.Select(_tendangnhap);
            if (_taikhoan != null)
            {
                throw new ArgumentException("Tên đăng nhập đã có người sử dụng\nVui lòng lấy tên đăng nhập khác");
            }
        }
        #endregion

        #region Events
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(true);
            isInsert = true;
            LoadPanelControl();
            txtHoTen.Focus();
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();

                if (isInsert)
                {
                    ValidateTrungTaiKhoan(txtTenDangNhap.Text);
                    if (NhanVienLogic.InsertAndTaiKhoan(LoadNhanVien(), LoadTaiKhoan()))
                    {
                        LoadDanhSachNhanVien();
                        O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                        frmthongbao.Show();
                        LockAndUnlockPanelControl(false);
                    }
                }
                else
                {
                    if (NhanVienLogic.Update(LoadNhanVien(), LoadTaiKhoan()))
                    {
                        LoadDanhSachNhanVien();
                        O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                        frmthongbao.Show();
                        LockAndUnlockPanelControl(false);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridViewDSNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDSNhanVien.FocusedRowHandle;
                this.nhanvienId_Select = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSNhanVien.GetRowCellValue(rowHandle, "NhanVienId").ToString());
                NHANVIEN hocVien = NhanVienLogic.SelectSingle(this.nhanvienId_Select);
                LoadPanelControl(hocVien);
                LockAndUnlockPanelControl(false);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(false);
            gridViewDSNhanVien_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(true);
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NhanVienLogic.Delete(this.nhanvienId_Select))
                    {
                        O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadDanhSachNhanVien();
                        ResetPanelControl();
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridViewDSNhanVien_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        #endregion

        #region Custom

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void gridViewDSNhanVien_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.DodgerBlue;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewDSNhanVien_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clm_NhanVien_Stt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                    {
                        txtEmail.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtEmail.ForeColor = Color.Black;
                    }
                }
                else
                {
                    txtEmail.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion


    }
}
