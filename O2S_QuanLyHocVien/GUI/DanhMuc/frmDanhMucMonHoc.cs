// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyMonHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using DevExpress.XtraGrid.Views.Grid;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Collections.Generic;
using System.Drawing;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmDanhMucMonHoc : Form
    {
        #region Khai bao
        private bool isInsert = false;
        private MONHOC MonHocSelect { get; set; }

        #endregion

        public frmDanhMucMonHoc()
        {
            InitializeComponent();
        }
        #region Load
        private void frmQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(false);
            LoadGridMonHoc();
        }
        private void LoadGridMonHoc()
        {
            try
            {
                MonHocFilter _filter = new MonHocFilter();
                // _filter.CoSoId = GlobalSettings.CoSoId;
                List<MonHoc_PlusDTO> _lstMonHoc = MonHocLogic.Select(_filter);
                if (_lstMonHoc != null && _lstMonHoc.Count > 0)
                {
                    gridControlMonHoc.DataSource = _lstMonHoc;
                }
                else
                {
                    gridControlMonHoc.DataSource = null;
                }
                lblTongCong.Text = string.Format("Tổng cộng: {0} môn học", gridViewMonHoc.RowCount);
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
            //txtMaMonHoc.Enabled = _result;
            txtTenMonHoc.ReadOnly = !_result;
            numDiemToiDa.ReadOnly = !_result;
            btnLuuThongTin.Enabled = _result;
            btnHuyBo.Enabled = _result;
        }

        private void ResetPanelControl()
        {
            txtMaMonHoc.Text = string.Empty;
            txtTenMonHoc.Text = string.Empty;
            numDiemToiDa.Text = "0";
        }
        private void MonHoc_ClickData(MONHOC _phonghoc)
        {
            txtMaMonHoc.Text = _phonghoc.MaMonHoc;
            txtTenMonHoc.Text = _phonghoc.TenMonHoc;
            numDiemToiDa.Text = _phonghoc.DiemToiDa.ToString();
            // chkIsLock.Checked = _phonghoc.IsLock ?? false;
        }

        private MONHOC LoadMonHoc()
        {
            return new MONHOC()
            {
                MonHocId = this.MonHocSelect != null ? this.MonHocSelect.MonHocId : 0,
                //CoSoId = GlobalSettings.CoSoId,
                MaMonHoc = txtMaMonHoc.Text,
                TenMonHoc = txtTenMonHoc.Text,
                DiemToiDa = O2S_Common.TypeConvert.Parse.ToDecimal(numDiemToiDa.Text),
                // IsLock = chkIsLock.Checked,
            };
        }

        #endregion

        #region Events
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridViewMonHoc_Click(sender, e);
        }

        private void gridViewMonHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewMonHoc.RowCount > 0)
                {
                    var rowHandle = gridViewMonHoc.FocusedRowHandle;
                    int _MonHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewMonHoc.GetRowCellValue(rowHandle, "MonHocId").ToString());

                    this.MonHocSelect = MonHocLogic.SelectSingle(_MonHocId);
                    if (this.MonHocSelect != null)
                    {
                        MonHoc_ClickData(this.MonHocSelect);
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
        }
        private void gridViewMonHoc_DoubleClick(object sender, EventArgs e)
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
                    var rowHandle = gridViewMonHoc.FocusedRowHandle;
                    int _monHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewMonHoc.GetRowCellValue(rowHandle, "MonHocId").ToString());
                    if (MonHocLogic.Delete(_monHocId))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadGridMonHoc();
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
                    if (MonHocLogic.Insert(LoadMonHoc(), ref _khoaHocId))
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
                    if (MonHocLogic.Update(LoadMonHoc()))
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
                LoadGridMonHoc();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Custom
        private void txtDiemToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }



        #endregion

    }
}
