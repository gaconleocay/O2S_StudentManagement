// Quản lý giảng viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyGiangVien.cs"
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
    public partial class frmQuanLyGiangVien : Form
    {
        #region Khai bao
        private bool isInsert = false;
        private int giangvienId_Select { get; set; }
        #endregion
        public frmQuanLyGiangVien()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyGiangVien_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddYears(-10).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                dateNgaySinh.MaxDate = DateTime.Now.AddYears(-10);

                LockAndUnlockPanelControl(false);
                LoadDanhSachGiangVien();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void LoadDanhSachGiangVien()
        {
            try
            {
                GiangVienFilter _filter = new GiangVienFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.NgayBatDauLamViec_Tu = date_TuNgay.DateTime;
                _filter.NgayBatDauLamViec_Den = date_DenNgay.DateTime;
                List<GiangVien_PlusDTO> _lstGiangVien = GiangVienLogic.Select(_filter);
                if (_lstGiangVien != null && _lstGiangVien.Count > 0)
                {
                    for (int i = 0; i < _lstGiangVien.Count; i++)
                    {
                        _lstGiangVien[i].Stt = i + 1;
                    }
                    gridControlDSGiangVien.DataSource = _lstGiangVien;
                    lblTongCong.Text = string.Format("Tổng cộng: {0} giảng viên)", _lstGiangVien.Count);
                }
                else
                {
                    gridControlDSGiangVien.DataSource = null;
                    lblTongCong.Text = string.Format("Tổng cộng: {0} giảng viên)", 0);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadPanelControl(GIANGVIEN _giangvien = null)
        {
            try
            {
                if (_giangvien == null)
                {
                    ResetPanelControl();
                }
                else
                {
                    txtMaHV.Text = _giangvien.MaGiangVien;
                    txtHoTen.Text = _giangvien.TenGiangVien;
                    dateNgaySinh.Value = _giangvien.NgaySinh != null ? (DateTime)_giangvien.NgaySinh : dateNgaySinh.MaxDate;
                    cboGioiTinh.Text = _giangvien.GioiTinh;
                    txtDiaChi.Text = _giangvien.DiaChi;
                    txtSDT.Text = _giangvien.Sdt;
                    txtEmail.Text = _giangvien.Email;
                    dateNgayBatDauLamViec.Value = _giangvien.NgayBatDauLamViec != null ? (DateTime)_giangvien.NgayBatDauLamViec : DateTime.Now;
                    txtGhiChu.Text = _giangvien.GhiChu;
                    txtTenDangNhap.Text = _giangvien.TAIKHOAN.IsRemove != 1 ? _giangvien.TAIKHOAN.TenDangNhap : string.Empty;
                    txtMatKhau.Text = _giangvien.TAIKHOAN.IsRemove != 1 ? O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(_giangvien.TAIKHOAN.MatKhau, true) : string.Empty;
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
            txtTenDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }
        private GIANGVIEN LoadGiangVien()
        {
            GIANGVIEN _giangvien = new GIANGVIEN()
            {
                GiangVienId = this.giangvienId_Select,
                TenGiangVien = txtHoTen.Text,
                NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                GioiTinh = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                Sdt = txtSDT.Text,
                Email = txtEmail.Text,
                NgayBatDauLamViec = DateTime.ParseExact(dateNgayBatDauLamViec.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                GhiChu = txtGhiChu.Text,
                CoSoId=GlobalSettings.CoSoId,
            };
            return _giangvien;
        }
        private TAIKHOAN LoadTaiKhoan()
        {
            TAIKHOAN _taikhoan = new TAIKHOAN()
            {
                TenDangNhap = txtTenDangNhap.Text,
                MatKhau = txtMatKhau.Text,
                LoaiTaiKhoanId = KeySetting.LOAITAIKHOAN_GiangVien,
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
            TAIKHOAN _taikhoan = TaiKhoanLogic.SelectTheoTenDangNhap(_tendangnhap);
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
                LoadDanhSachGiangVien();
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
                    if (GiangVienLogic.InsertAndTaiKhoan(LoadGiangVien(), LoadTaiKhoan()))
                    {
                        LoadDanhSachGiangVien();
                        O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                        frmthongbao.Show();
                        LockAndUnlockPanelControl(false);
                    }
                }
                else
                {
                    if (GiangVienLogic.Update(LoadGiangVien(), LoadTaiKhoan()))
                    {
                        LoadDanhSachGiangVien();
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

        private void gridViewDSGiangVien_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDSGiangVien.FocusedRowHandle;
                this.giangvienId_Select = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSGiangVien.GetRowCellValue(rowHandle, "GiangVienId").ToString());
                GIANGVIEN hocVien = GiangVienLogic.SelectSigleTheoKhoaKhoa(this.giangvienId_Select);
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
            gridViewDSGiangVien_Click(sender, e);
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
                    if (GiangVienLogic.Delete(this.giangvienId_Select))
                    {
                        O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadDanhSachGiangVien();
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

        private void gridViewDSGiangVien_DoubleClick(object sender, EventArgs e)
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
        private void gridViewDSGiangVien_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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

        private void gridViewDSGiangVien_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clm_GiangVien_Stt)
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
