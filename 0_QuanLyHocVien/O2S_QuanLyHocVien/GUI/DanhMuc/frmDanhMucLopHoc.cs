// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyLopHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Globalization;

namespace O2S_QuanLyHocVien.DanhMuc
{
    public partial class frmDanhMucLopHoc : Form
    {
        #region Khai bao
        private bool isInsert = false;
        private LOPHOC LopHocSelect { get; set; }

        #endregion
        public frmDanhMucLopHoc()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            dateNgayBD.Value = DateTime.Now;
            LockAndUnLookPanelControl(false);
            LoadKhoaHoc();
            LoadGridLopHoc();
        }
        private void LoadKhoaHoc()
        {
            try
            {

                KhoaHocFilter _filter = new KhoaHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                cboKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
                cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                cboKhoaHoc.ValueMember = "KhoaHocId";
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadGridLopHoc()
        {
            try
            {
                LopHocFilter _filter = new LopHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                List<LopHoc_PlusDTO> _lstLopHoc = LopHocLogic.Select(_filter);
                if (_lstLopHoc != null && _lstLopHoc.Count > 0)
                {
                    gridControlLopHoc.DataSource = _lstLopHoc;
                }
                else
                {
                    gridControlLopHoc.DataSource = null;
                }
                lblTongCong.Text = string.Format("Tổng cộng: {0} ca/tiết học", gridViewLopHoc.RowCount);
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
            //txtMaLopHoc.Enabled = _result;
            txtTenLopHoc.ReadOnly = !_result;
            dateNgayBD.Enabled = _result;
            dateNgayKT.Enabled = _result;
            cboKhoaHoc.Enabled = _result;
            numSiSoToiDa.ReadOnly = !_result;
            chkDaDong.Enabled = _result;
            btnLuuThongTin.Enabled = _result;
            btnHuyBo.Enabled = _result;
        }

        private void ResetPanelControl()
        {
            txtMaLopHoc.Text = string.Empty;
            txtTenLopHoc.Text = string.Empty;
            dateNgayBD.Value = DateTime.Now;
            dateNgayKT.Value = DateTime.Now;
            cboKhoaHoc.SelectedIndex = 1;
            numSiSoToiDa.Text = "0";
            chkDaDong.Checked = false;
        }
        private void LopHoc_ClickData(LOPHOC _phonghoc)
        {
            txtMaLopHoc.Text = _phonghoc.MaLopHoc;
            txtTenLopHoc.Text = _phonghoc.TenLopHoc;
            dateNgayBD.Value = (DateTime)_phonghoc.NgayBatDau;
            dateNgayKT.Value = (DateTime)_phonghoc.NgayKetThuc;
            cboKhoaHoc.SelectedValue = _phonghoc.KhoaHocId;
            numSiSoToiDa.Text = "0";
            chkDaDong.Checked = _phonghoc.IsLock ?? false;
        }

        private LOPHOC LoadLopHoc()
        {
            return new LOPHOC()
            {
                LopHocId = this.LopHocSelect != null ? this.LopHocSelect.LopHocId : 0,
                CoSoId = GlobalSettings.CoSoId,
                MaLopHoc = txtMaLopHoc.Text,
                TenLopHoc = txtTenLopHoc.Text,
                NgayBatDau = DateTime.ParseExact(dateNgayBD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                NgayKetThuc = DateTime.ParseExact(dateNgayKT.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                SiSoToiDa = O2S_Common.TypeConvert.Parse.ToInt32(numSiSoToiDa.Text),
                SiSo = LopHocSelect == null ? 0 : LopHocSelect.SiSo,
                KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString()),
                IsLock = chkDaDong.Checked,
            };
        }

        #endregion

        #region Events
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridViewLopHoc_Click(sender, e);
        }

        private void gridViewLopHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewLopHoc.RowCount > 0)
                {
                    var rowHandle = gridViewLopHoc.FocusedRowHandle;
                    int _LopHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewLopHoc.GetRowCellValue(rowHandle, "LopHocId").ToString());

                    this.LopHocSelect = LopHocLogic.SelectSingle(_LopHocId);
                    if (this.LopHocSelect != null)
                    {
                        LopHoc_ClickData(this.LopHocSelect);
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
        private void gridViewLopHoc_DoubleClick(object sender, EventArgs e)
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
                    var rowHandle = gridViewLopHoc.FocusedRowHandle;
                    int _caHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewLopHoc.GetRowCellValue(rowHandle, "LopHocId").ToString());
                    if (LopHocLogic.Delete(_caHocId))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadGridLopHoc();
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
                    if (LopHocLogic.Insert(LoadLopHoc(), ref _khoaHocId))
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
                    if (LopHocLogic.Update(LoadLopHoc()))
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
                LoadGridLopHoc();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Custom
        private void numSiSoToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void gridViewDSLopHoc_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
