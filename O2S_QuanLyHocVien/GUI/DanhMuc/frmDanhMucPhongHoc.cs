// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyPhongHoc.cs"
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
    public partial class frmDanhMucPhongHoc : Form
    {
        #region Khai bao
        private bool isInsert = false;
        private PHONGHOC PhongHocSelect { get; set; }

        #endregion
        public frmDanhMucPhongHoc()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyPhongHoc_Load(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(false);
            LoadGridPhongHoc();
        }
        private void LoadGridPhongHoc()
        {
            try
            {
                PhongHocFilter _filter = new PhongHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                List<PHONGHOC> _lstPhongHoc = PhongHocLogic.Select(_filter);
                if (_lstPhongHoc != null && _lstPhongHoc.Count > 0)
                {
                    gridControlPhongHoc.DataSource = _lstPhongHoc;
                }
                else
                {
                    gridControlPhongHoc.DataSource = null;
                }
                lblTongCong.Text = string.Format("Tổng cộng: {0} ca/tiết học", gridViewPhongHoc.RowCount);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Processs
        private void LockAndUnLookPanelControl(bool _result)
        {
            //txtMaPhongHoc.Enabled = _result;
            txtTenPhongHoc.ReadOnly = !_result;
            txtGhiChu.ReadOnly = !_result;
            chkIsLock.Enabled = _result;
            btnLuuThongTin.Enabled = _result;
            btnHuyBo.Enabled = _result;
        }

        private void ResetPanelControl()
        {
            txtMaPhongHoc.Text = string.Empty;
            txtTenPhongHoc.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }
        private void PhongHoc_ClickData(PHONGHOC _phonghoc)
        {
            txtMaPhongHoc.Text = _phonghoc.MaPhongHoc;
            txtTenPhongHoc.Text = _phonghoc.TenPhongHoc;
            txtGhiChu.Text = _phonghoc.GhiChu;
            chkIsLock.Checked = _phonghoc.IsLock ?? false;
        }

        private PHONGHOC LoadPhongHoc()
        {
            return new PHONGHOC()
            {
                PhongHocId = this.PhongHocSelect != null ? this.PhongHocSelect.PhongHocId : 0,
                CoSoId = GlobalSettings.CoSoId,
                MaPhongHoc = txtMaPhongHoc.Text,
                TenPhongHoc = txtTenPhongHoc.Text,
                GhiChu = txtGhiChu.Text,
                IsLock = chkIsLock.Checked,
            };
        }

        #endregion

        #region Events
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridViewPhongHoc_Click(sender, e);
        }

        private void gridViewPhongHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewPhongHoc.RowCount > 0)
                {
                    var rowHandle = gridViewPhongHoc.FocusedRowHandle;
                    int _PhongHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewPhongHoc.GetRowCellValue(rowHandle, "PhongHocId").ToString());

                    this.PhongHocSelect = PhongHocLogic.SelectSingle(_PhongHocId);
                    if (this.PhongHocSelect != null)
                    {
                        PhongHoc_ClickData(this.PhongHocSelect);
                        LockAndUnLookPanelControl(false);
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(true);
            ResetPanelControl();
            isInsert = true;
            txtTenPhongHoc.Focus();
        }
        private void gridViewPhongHoc_DoubleClick(object sender, EventArgs e)
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
                    var rowHandle = gridViewPhongHoc.FocusedRowHandle;
                    int _caHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewPhongHoc.GetRowCellValue(rowHandle, "PhongHocId").ToString());
                    if (PhongHocLogic.Delete(_caHocId))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadGridPhongHoc();
                    }
                }
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
                    if (PhongHocLogic.Insert(LoadPhongHoc(), ref _khoaHocId))
                    {
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
                    if (PhongHocLogic.Update(LoadPhongHoc()))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                        frmthongbao.Show();
                    }
                    else
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
                LoadGridPhongHoc();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Custom

        private void gridViewDSPhongHoc_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }



        #endregion


    }
}
