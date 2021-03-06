﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmTiepNhanHocVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Threading;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmTiepNhanHocVien : Form
    {
        #region Khai bao
        private bool isInsert = false;
        private int hocvienId_Select { get; set; }
        // private List<HocVien_PlusDTO> lstHocVien { get; set; }
        #endregion
        public frmTiepNhanHocVien()
        {
            InitializeComponent();
        }

        #region Load
        private void frmTiepNhanHocVien_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                dateNgaySinh.MaxDate = DateTime.Now;

                LockAndUnlockPanelControl(false);
                LoadDuLieuLoaiHV();
                LoadDanhSachHocVien();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDuLieuLoaiHV()
        {
            cboLoaiHV.DataSource = LoaiHocVienLogic.SelectAll();
            cboLoaiHV.DisplayMember = "TenLoaiHocVien";
            cboLoaiHV.ValueMember = "LoaiHocVienId";
        }

        private void LoadDanhSachHocVien()
        {
            try
            {
                gridControlDSHocVien.DataSource = null;
                //Thread th = new Thread(() =>
                //{
                HocVienFilter _filter = new HocVienFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.NgayTiepNhan_Tu = date_TuNgay.DateTime;
                _filter.NgayTiepNhan_Den = date_DenNgay.DateTime;
                List<HocVien_PlusDTO> _lstHocVien = HocVienLogic.Select(_filter);
                if (_lstHocVien != null && _lstHocVien.Count > 0)
                {
                    //gridControlDSHocVien.Invoke((MethodInvoker)delegate
                    //{
                    gridControlDSHocVien.DataSource = _lstHocVien;
                    lblTongCong.Text = string.Format("Tổng cộng: {0} học viên ({1} học viên chính thức; {2} học viên tiềm năng; {3} học viên chờ lớp)", _lstHocVien.Count, _lstHocVien.Where(o => o.LoaiHocVienId == KeySetting.LOAIHOCVIEN_CHINHTHUC).ToList().Count, _lstHocVien.Where(o => o.LoaiHocVienId == KeySetting.LOAIHOCVIEN_TIEMNANG).ToList().Count, _lstHocVien.Where(o => o.LoaiHocVienId == KeySetting.LOAIHOCVIEN_CHOLOP).ToList().Count);
                    //});
                }
                else
                {
                    gridControlDSHocVien.DataSource = null;
                    lblTongCong.Text = string.Format("Tổng cộng: {0} học viên ({1} học viên chính thức; {2} học viên tiềm năng; {3} học viên chờ lớp)", 0, 0, 0);
                }
                //});

                //th.Start();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadPanelControl(HOCVIEN _hocvien = null)
        {
            try
            {
                if (_hocvien == null)
                {
                    ResetPanelControl();
                    cboLoaiHV_SelectedValueChanged(null, null);
                }
                else
                {
                    txtMaHV.Text = _hocvien.MaHocVien;
                    txtHoTen.Text = _hocvien.TenHocVien;
                    dateNgaySinh.Value = (DateTime)_hocvien.NgaySinh;
                    cboGioiTinh.Text = _hocvien.GioiTinh;
                    txtDiaChi.Text = _hocvien.DiaChi;
                    txtSDT.Text = _hocvien.Sdt;
                    txtEmail.Text = _hocvien.Email;
                    txtSDTBo.Text = _hocvien.SdtBo;
                    txtEmailBo.Text = _hocvien.EmailBo;
                    txtSDTMe.Text = _hocvien.SdtMe;
                    txtEmailMe.Text = _hocvien.EmailMe;
                    txtNguoiTuVan.Text = _hocvien.TenNguoiTuVan;
                    txtGhiChu.Text = _hocvien.GhiChu;
                    cboLoaiHV.SelectedValue = _hocvien.LoaiHocVienId;
                    txtTenDangNhap.Text = _hocvien.TAIKHOAN.IsRemove != 1 ? _hocvien.TAIKHOAN.TenDangNhap : string.Empty;
                    txtMatKhau.Text = _hocvien.TAIKHOAN.IsRemove != 1 ? O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(_hocvien.TAIKHOAN.MatKhau, true) : string.Empty;
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

        #region Events
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachHocVien();
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
                    int _hocvienId = 0;
                    if (HocVienLogic.Insert(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                        LoaiTaiKhoanId = KeySetting.LOAITAIKHOAN_HocVien,
                    }, ref _hocvienId))
                    {
                        LoadDanhSachHocVien();
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                        frmthongbao.Show();
                        LockAndUnlockPanelControl(false);
                    }
                }
                else
                {
                    if (HocVienLogic.Update(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    }))
                    {
                        LoadDanhSachHocVien();
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
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
                O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridViewDSHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                this.hocvienId_Select = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());
                HOCVIEN hocVien = HocVienLogic.SelectSingle(this.hocvienId_Select);
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
            gridViewDSHocVien_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(true);
            isInsert = false;
            cboLoaiHV_SelectedValueChanged(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate xoa du lieu
                ValidateXoaHocVien(this.hocvienId_Select);
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (HocVienLogic.Delete(this.hocvienId_Select))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadDanhSachHocVien();
                        ResetPanelControl();
                    }
                    else
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridViewDSHocVien_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
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
            txtSDTBo.ReadOnly = !_result;
            txtEmailBo.ReadOnly = !_result;
            txtSDTMe.ReadOnly = !_result;
            txtNguoiTuVan.ReadOnly = !_result;
            txtGhiChu.ReadOnly = !_result;
            txtEmailMe.ReadOnly = !_result;
            cboLoaiHV.Enabled = _result;
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
            txtSDTBo.Text = string.Empty;
            txtEmailBo.Text = string.Empty;
            txtSDTMe.Text = string.Empty;
            txtNguoiTuVan.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtEmailMe.Text = string.Empty;
            cboLoaiHV.SelectedIndex = 0;
            txtTenDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }
        private HOCVIEN LoadHocVien()
        {
            HOCVIEN _hocVien = new HOCVIEN()
            {
                HocVienId = this.hocvienId_Select,
                TenHocVien = txtHoTen.Text,
                NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                GioiTinh = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                Sdt = txtSDT.Text,
                Email = txtEmail.Text,
                SdtBo = txtSDTBo.Text,
                EmailBo = txtEmailBo.Text,
                SdtMe = txtSDTMe.Text,
                EmailMe = txtEmailMe.Text,
                TenNguoiTuVan = txtNguoiTuVan.Text,
                GhiChu = txtGhiChu.Text,
                LoaiHocVienId = (int)cboLoaiHV.SelectedValue,
                NgayTiepNhan = DateTime.Now,
                CoSoId = GlobalSettings.CoSoId
            };
            return _hocVien;
        }
        private void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                throw new ArgumentException("Họ và tên không được trống");
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                throw new ArgumentException("Địa chỉ không được trống");
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại không được trống");
            //if (string.IsNullOrWhiteSpace(txtEmail.Text))
            //throw new ArgumentException("Email không được trống");
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains(".")))
                throw new ArgumentException("Email không đúng");
            if (txtEmailBo.ForeColor == Color.Red || txtEmailMe.ForeColor == Color.Red)
                throw new ArgumentException("Email của bố hoặc của mẹ không đúng");
            //ngay sinh
            DateTime _ngaysinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int _tuoi = DateTime.Now.Year - _ngaysinh.Year;
            if (_tuoi < 3)
            {
                throw new ArgumentException("Ngày sinh không đúng");
            }
        }
        private void ValidateXoaHocVien(int _hocvienId)
        {
            //hv khong cho xoa: da lap phieu ghi danh
            PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter()
            {
                HocVienId = _hocvienId,
            };
            List<PhieuGhiDanh_PlusDTO> _lstphieugd = PhieuGhiDanhLogic.Select(_filter);
            if (_lstphieugd != null && _lstphieugd.Count > 0)
            {
                throw new ArgumentException("Học viên đã lập phiếu ghi danh nên không thể xóa được.");
            }
        }
        #endregion

        #region Custom
        private void cboLoaiHV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLoaiHV.SelectedValue.ToString() == KeySetting.LOAIHOCVIEN_TIEMNANG.ToString() || cboLoaiHV.SelectedValue.ToString() == KeySetting.LOAIHOCVIEN_CHOLOP.ToString())//tiem nang
            {
                txtTenDangNhap.Text = string.Empty;
                txtMatKhau.Text = string.Empty;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void gridViewDSHocVien_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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

        private void gridViewDSHocVien_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clm_HocVien_Stt)
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
        private void txtEmailBo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmailBo.Text))
                {
                    if (!txtEmailBo.Text.Contains("@") || !txtEmailBo.Text.Contains("."))
                    {
                        txtEmailBo.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtEmailBo.ForeColor = Color.Black;
                    }
                }
                else
                {
                    txtEmailBo.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtEmailMe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmailMe.Text))
                {
                    if (!txtEmailMe.Text.Contains("@") || !txtEmailMe.Text.Contains("."))
                    {
                        txtEmailMe.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtEmailMe.ForeColor = Color.Black;
                    }
                }
                else
                {
                    txtEmailMe.ForeColor = Color.Black;
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
