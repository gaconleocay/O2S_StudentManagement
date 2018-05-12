// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyKhoaHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Collections.Generic;
using System.Linq;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmDanhMucKhoaHoc : Form
    {
        private bool isInsert = false;
        private List<KhoaHocMonHocDTO> lstKHMH { get; set; }
        private KHOAHOC khoaHocSelect { get; set; }
        public frmDanhMucKhoaHoc()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyKhoaHoc_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");

                LockPanelControl(false);
                LoadGridKhoaHocMonHoc();
                LoadGridKhoaHoc();
                gridViewKhoaHoc_Click(sender, e);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadGridKhoaHocMonHoc()
        {
            try
            {
                this.lstKHMH = new List<KhoaHocMonHocDTO>();
                List<MonHoc_PlusDTO> _lstMonHoc = MonHocLogic.Select(new MonHocFilter());
                foreach (var item in _lstMonHoc)
                {
                    KhoaHocMonHocDTO _khmh = new KhoaHocMonHocDTO();
                    _khmh.IsCheck = false;
                    _khmh.MonHocId = item.MonHocId;
                    _khmh.MaMonHoc = item.MaMonHoc;
                    _khmh.TenMonHoc = item.TenMonHoc;
                    _khmh.DiemDat = 0;
                    this.lstKHMH.Add(_khmh);
                }
                gridControlDSMonHoc.DataSource = this.lstKHMH;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        public void LockPanelControl(bool result)
        {
            //txtMaKhoaHoc.ReadOnly = !result;
            txtTenKhoaHoc.ReadOnly = !result;
            numHocPhi.ReadOnly = !result;
            numSoTietHoc.ReadOnly = !result;
            chkDaKhoa.Enabled = result;
            btnLuuThongTin.Enabled = result;
            btnHuyBo.Enabled = result;
        }
        public void LoadGridKhoaHoc()
        {
            try
            {
                KhoaHocFilter _filter = new KhoaHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.CreatedDate_Tu = date_TuNgay.DateTime;
                _filter.CreatedDate_Den = date_DenNgay.DateTime;
                gridControlKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
                lblTongCong.Text = string.Format("Tổng cộng: {0} khóa học", gridViewKhoaHoc.RowCount);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Process
        private void KhoaHoc_ClickData(KHOAHOC kh)
        {
            try
            {
                txtMaKhoaHoc.Text = kh.MaKhoaHoc;
                txtTenKhoaHoc.Text = kh.TenKhoaHoc;
                numHocPhi.Value = (decimal)kh.HocPhi;
                numSoTietHoc.Value = kh.SoTietHoc != null ? (decimal)kh.SoTietHoc : 0;
                chkDaKhoa.Checked = kh.IsLock ?? false;
                //Load mon hoc cua Khoa hoc
                List<KhoaHocMonHocDTO> _lstKHMH = this.lstKHMH;
                List<KHOAHOC_MONHOC> _khmh = KhoaHocMonHocLogic.SelectTheoKhoaHoc(kh.KhoaHocId);
                if (_khmh != null && _khmh.Count > 0)
                {
                    foreach (var item in _lstKHMH)
                    {
                        List<KHOAHOC_MONHOC> _kiemtra = _khmh.Where(o => o.MonHocId == item.MonHocId).ToList();
                        if (_kiemtra != null && _kiemtra.Count > 0)
                        {
                            item.IsCheck = true;
                            item.DiemDat = _kiemtra[0].DiemDat ?? 0;
                        }
                        else
                        {
                            item.IsCheck = false;
                            item.DiemDat = 0;
                        }
                    }
                }
                else
                {
                    foreach (var item in _lstKHMH)
                    {
                        item.IsCheck = false;
                        item.DiemDat = 0;
                    }
                }
                gridControlDSMonHoc.DataSource = null;
                gridControlDSMonHoc.DataSource = _lstKHMH;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private KHOAHOC LoadKhoaHoc()
        {
            return new KHOAHOC()
            {
                KhoaHocId = this.khoaHocSelect != null ? this.khoaHocSelect.KhoaHocId : 0,
                TenKhoaHoc = txtTenKhoaHoc.Text,
                HocPhi = numHocPhi.Value,
                CoSoId = GlobalSettings.CoSoId,
                SoTietHoc = numSoTietHoc.Value,
                IsLock = chkDaKhoa.Checked ? true : false,
            };
        }
        private void ResetPanelControl()
        {
            txtMaKhoaHoc.Text = string.Empty;
            txtTenKhoaHoc.Text = string.Empty;
            numHocPhi.Value = 0;
            numSoTietHoc.Value = 0;
            chkDaKhoa.Checked = false;
        }
        private void ValidateXoaKhoaHoc(int _KhoaHocId)
        {
            //kiem tra neu khóa học đã có trong PHIEUGHIDANH thì không cho xóa
            PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter();
            _filter.KhoaHocId = _KhoaHocId;
            _filter.CoSoId = GlobalSettings.CoSoId;

            List<PhieuGhiDanh_PlusDTO> _lstPhieuGD = PhieuGhiDanhLogic.Select(_filter);
            if (_lstPhieuGD != null && _lstPhieuGD.Count > 0)
            {
                throw new ArgumentException("Khóa học đã được sử dụng nên không thể xóa");
            }
        }
        private void ValidateSuaKhoaHoc(int _KhoaHocId)
        {
            //kiem tra neu khóa học đã có trong BANGDIEM thì không cho sửa
            BangDiemFilter _filter = new BangDiemFilter();
            _filter.KhoaHocId = _KhoaHocId;

            List<BANGDIEM> _lstBangDiem = BangDiemLogic.SelectFilter(_filter);
            if (_lstBangDiem != null && _lstBangDiem.Count > 0)
            {
                throw new ArgumentException("Khóa học đã được sử dụng nên không thể sửa");
            }
        }

        #endregion

        #region Events
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadGridKhoaHoc();
        }
        private void gridViewKhoaHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewKhoaHoc.RowCount > 0)
                {
                    var rowHandle = gridViewKhoaHoc.FocusedRowHandle;
                    int _KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewKhoaHoc.GetRowCellValue(rowHandle, "KhoaHocId").ToString());

                    this.khoaHocSelect = KhoaHocLogic.SelectSingle(_KhoaHocId);
                    if (this.khoaHocSelect != null)
                    {
                        KhoaHoc_ClickData(this.khoaHocSelect);
                        LockPanelControl(false);
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridViewKhoaHoc_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockPanelControl(true);
            ResetPanelControl();
            isInsert = true;
            txtTenKhoaHoc.Focus();
        }

        private void gridViewKhoaHoc_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.khoaHocSelect != null)
                {
                    ValidateSuaKhoaHoc(this.khoaHocSelect.KhoaHocId);
                }
                LockPanelControl(true);
                isInsert = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewKhoaHoc.FocusedRowHandle;
                int _KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewKhoaHoc.GetRowCellValue(rowHandle, "KhoaHocId").ToString());

                ValidateXoaKhoaHoc(_KhoaHocId);
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (KhoaHocLogic.Delete(_KhoaHocId))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadGridKhoaHoc();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    int _khoaHocId = 0;
                    if (KhoaHocLogic.Insert(LoadKhoaHoc(), ref _khoaHocId))
                    {//Insert Khoa hoc-mon hoc
                        for (int i = 0; i < gridViewDSMonHoc.RowCount; i++)
                        {
                            bool _IsCheck = O2S_Common.TypeConvert.Parse.ToBoolean(gridViewDSMonHoc.GetRowCellValue(i, "IsCheck").ToString());
                            if (_IsCheck)
                            {
                                KHOAHOC_MONHOC _khmh = new KHOAHOC_MONHOC();
                                _khmh.KhoaHocId = _khoaHocId;
                                _khmh.TenKhoaHoc = txtTenKhoaHoc.Text;
                                _khmh.MonHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSMonHoc.GetRowCellValue(i, "MonHocId").ToString());
                                _khmh.TenMonHoc = gridViewDSMonHoc.GetRowCellValue(i, "TenMonHoc").ToString();
                                _khmh.DiemDat = O2S_Common.TypeConvert.Parse.ToDecimal(gridViewDSMonHoc.GetRowCellValue(i, "DiemDat").ToString());
                                KhoaHocMonHocLogic.Insert(_khmh);
                            }
                        }
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                        frmthongbao.Show();
                    }
                    else
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
                else
                {
                    if (KhoaHocLogic.Update(LoadKhoaHoc()))
                    {
                        //INsert Khoa hoc-mon hoc
                        KhoaHocMonHocLogic.DeleteTheoKhoaHoc(this.khoaHocSelect.KhoaHocId);
                        for (int i = 0; i < gridViewDSMonHoc.RowCount; i++)
                        {
                            bool _IsCheck = O2S_Common.TypeConvert.Parse.ToBoolean(gridViewDSMonHoc.GetRowCellValue(i, "IsCheck").ToString());
                            if (_IsCheck)
                            {
                                KHOAHOC_MONHOC _khmh = new KHOAHOC_MONHOC();
                                _khmh.KhoaHocId = this.khoaHocSelect.KhoaHocId;
                                _khmh.TenKhoaHoc = txtTenKhoaHoc.Text;
                                _khmh.MonHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSMonHoc.GetRowCellValue(i, "MonHocId").ToString());
                                _khmh.TenMonHoc = gridViewDSMonHoc.GetRowCellValue(i, "TenMonHoc").ToString();
                                _khmh.DiemDat = O2S_Common.TypeConvert.Parse.ToDecimal(gridViewDSMonHoc.GetRowCellValue(i, "DiemDat").ToString());
                                KhoaHocMonHocLogic.Insert(_khmh);
                            }
                        }

                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                        frmthongbao.Show();
                    }
                }
                LoadGridKhoaHoc();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Custom
        private void gridViewDSMonHoc_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
        private void gridViewKhoaHoc_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clmKH_stt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
            }
        }


        #endregion


    }
}
