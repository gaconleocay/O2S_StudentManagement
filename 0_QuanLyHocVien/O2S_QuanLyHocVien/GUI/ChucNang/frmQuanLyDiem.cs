// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyDiem.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Threading;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyDiem : Form
    {
        #region Khai bao
        private BangDiemFullDTO bangDiemFull_Click { get; set; }
        #endregion
        public frmQuanLyDiem()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyDiem_Load(object sender, EventArgs e)
        {
            try
            {
                LoadKhoaHoc();
                btnTimKiem_Click(null, null);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadKhoaHoc()
        {
            try
            {
                KhoaHocFilter _filter = new KhoaHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.IsRemove = 0;
                cboKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
                cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                cboKhoaHoc.ValueMember = "KhoaHocId";
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadLopCuaKhoaHoc()
        {
            try
            {
                int _khoahocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                if (_khoahocId != 0)
                {
                    LopHocFilter _filter = new LopHocFilter();
                    _filter.CoSoId = GlobalSettings.CoSoId;
                    _filter.KhoaHocId = _khoahocId;
                    List<LopHoc_PlusDTO> _lstLopHoc = LopHocLogic.Select(_filter);
                    cboLopHoc.DataSource = _lstLopHoc;
                    cboLopHoc.DisplayMember = "TenLopHoc";
                    cboLopHoc.ValueMember = "LopHocId";
                    cboLopHoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        public void LoadDSHVCuaLop()
        {
            try
            {
                if (cboLopHoc.SelectedValue != null)
                {
                    int _lophocId = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());
                    List<XepLopDTO> _dsXepLopHocVien = BangDiemLogic.SelectDSHV_Lop(_lophocId);
                    gridControlDSHV.DataSource = _dsXepLopHocVien;
                }
                else
                {
                    gridControlDSHV.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        public void LoadPanelDiem(int _hocvienId, int _lophocId)
        {
            //List<BangDiemChiTietDTO> _lstBangDiem = new List<BangDiemChiTietDTO>();

            this.bangDiemFull_Click = BangDiemLogic.SelectDetail(_hocvienId, _lophocId);
            lblMaLop.Text = this.bangDiemFull_Click.TenLopHoc;
            lblTenLop.Text = this.bangDiemFull_Click.TenLopHoc;
            lblKhoa.Text = this.bangDiemFull_Click.TenKhoaHoc;
            lblMaHV.Text = this.bangDiemFull_Click.MaHocVien;
            lblTenHocVien.Text = this.bangDiemFull_Click.TenHocVien;
            ////load Danh sach diem
            //foreach (var item in this.bangDiemFull_Click.BangDiemChiTiets)
            //{
            //    BangDiemChiTietDTO _bangdiem = new BangDiemChiTietDTO();
            //    _bangdiem.BangDiemChiTietId = item.BangDiemChiTietId; ;
            //    _bangdiem.BangDiemId = this.bangDiemFull_Click.BangDiemId;
            //    _bangdiem.MaMonHoc = item.MaMonHoc;
            //    _bangdiem.TenMonHoc = item.TenMonHoc;
            //    _bangdiem.Diem = item.Diem ?? 0;
            //    _lstBangDiem.Add(_bangdiem);
            //}
            gridControlDSDiem.DataSource = this.bangDiemFull_Click.BangDiemChiTiets;
        }

        #endregion

        #region Events
        private void gridViewDSHV_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDSHV.RowCount > 0)
                {
                    var rowHandle = gridViewDSHV.FocusedRowHandle;
                    int _HocVienId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHV.GetRowCellValue(rowHandle, "HocVienId").ToString());

                    int _lophocId = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());

                    LoadPanelDiem(_HocVienId, _lophocId);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLopHoc.SelectedValue != null)
                {
                    LoadDSHVCuaLop();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridViewDSHV_Click(sender, e);
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (BangDiemLogic.UpdateFull(this.bangDiemFull_Click))
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
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion

        #region Cusstom
        private void gridViewDSHV_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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

        private void gridViewDSHV_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clm_xeplopstt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void cboKhoaHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadLopCuaKhoaHoc();
        }

        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDSHVCuaLop();
        }


        #endregion


    }
}
