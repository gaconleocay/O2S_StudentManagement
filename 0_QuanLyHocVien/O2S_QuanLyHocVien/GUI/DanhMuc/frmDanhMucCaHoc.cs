// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyMonHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmDanhMucCaHoc : Form
    {
        #region Khai bao
        private bool isInsert = false;
        private CAHOC CaHocSelect { get; set; }

        #endregion
        public frmDanhMucCaHoc()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(false);
            LoadGridCaHoc();
        }
        private void LoadGridCaHoc()
        {
            try
            {
                CaHocFilter _filter = new CaHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                List<CAHOC> _lstCaHoc = CaHocLogic.Select(_filter);
                if (_lstCaHoc != null && _lstCaHoc.Count > 0)
                {
                    gridControlCaHoc.DataSource = _lstCaHoc;
                }
                else
                {
                    gridControlCaHoc.DataSource = null;
                }
                lblTongCong.Text = string.Format("Tổng cộng: {0} ca/tiết học", gridViewCaHoc.RowCount);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Processs
        private void LockAndUnLookPanelControl(bool _result)
        {
            //txtMaCaHoc.Enabled = _result;
            txtTenCaHoc.Enabled = _result;
            timeThoiGianTu.Enabled = _result;
            timeThoiGianDen.Enabled = _result;
            btnLuuThongTin.Enabled = _result;
            btnHuyBo.Enabled = _result;
        }

        private void ResetPanelControl()
        {
            txtMaCaHoc.Text = string.Empty;
            txtTenCaHoc.Text = string.Empty;
            timeThoiGianTu.Text = "00:00";
            timeThoiGianDen.Text = "00:00";
        }
        private void CaHoc_ClickData(CAHOC _cahoc)
        {
            txtMaCaHoc.Text = _cahoc.CaHocId.ToString();
            txtTenCaHoc.Text = _cahoc.TenCaHoc;
            timeThoiGianTu.Time = DateTime.Parse(_cahoc.ThoiGianTu.ToString());
                //DateTime.Now.Add(_cahoc.ThoiGianTu??DateTime.Now.TimeOfDay).TimeOfDay;
            timeThoiGianDen.Time = DateTime.Parse(_cahoc.ThoiGianDen.ToString());
            chkDangSuDung.Checked = _cahoc.DangSuDung ?? false;
        }

        private CAHOC LoadCaHoc()
        {
            return new CAHOC()
            {
                CaHocId = this.CaHocSelect.CaHocId,
                CoSoId = GlobalSettings.CoSoId,
                MaCaHoc = txtMaCaHoc.Text,
                TenCaHoc = txtTenCaHoc.Text,
                TenCaHocFull = txtTenCaHoc.Text + " (" + timeThoiGianTu.Time.ToString("HH:mm") + " - " + timeThoiGianDen.Time.ToString("HH:mm") + ")",
                ThoiGianTu = timeThoiGianTu.Time.TimeOfDay,
                ThoiGianDen = timeThoiGianDen.Time.TimeOfDay,
                //GhiChu=txtGhiChu.Text,
                DangSuDung = chkDangSuDung.Checked,
            };
        }

        #endregion

        #region Events
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridViewCaHoc_Click(sender, e);
        }

        private void gridViewCaHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewCaHoc.RowCount > 0)
                {
                    var rowHandle = gridViewCaHoc.FocusedRowHandle;
                    int _caHocId = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewCaHoc.GetRowCellValue(rowHandle, "CaHocId").ToString());

                    this.CaHocSelect = CaHocLogic.SelectSingle(_caHocId);
                    if (this.CaHocSelect != null)
                    {
                        CaHoc_ClickData(this.CaHocSelect);
                        LockAndUnLookPanelControl(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(true);
            ResetPanelControl();
            isInsert = true;
        }
        private void gridViewCaHoc_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(true);
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var rowHandle = gridViewCaHoc.FocusedRowHandle;
                    int _caHocId = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewCaHoc.GetRowCellValue(rowHandle, "KhoaHocId").ToString());
                    if (CaHocLogic.Delete(_caHocId))
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadGridCaHoc();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    int _khoaHocId = 0;
                    if (CaHocLogic.Insert(LoadCaHoc(), ref _khoaHocId))
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                        frmthongbao.Show();
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
                else
                {
                    if (CaHocLogic.Update(LoadCaHoc()))
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                        frmthongbao.Show();
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
                LoadGridCaHoc();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
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
                Common.Logging.LogSystem.Warn(ex);
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
                Common.Logging.LogSystem.Warn(ex);
            }
        }



        #endregion


    }
}
