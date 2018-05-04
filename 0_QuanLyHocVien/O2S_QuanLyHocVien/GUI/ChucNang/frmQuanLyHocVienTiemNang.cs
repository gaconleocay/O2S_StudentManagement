// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmO2S_QuanLyHocVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.Popups;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using O2S_QuanLyHocVien.BusinessLogic.Models;
using System.Data;
using O2S_Common.DataObjects;

namespace O2S_QuanLyHocVien.ChucNang
{
    public partial class frmQuanLyHocVienTiemNang : Form
    {
        private List<QuanLyHocVienDTO> lstHocVien { get; set; }
        public frmQuanLyHocVienTiemNang()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyHocVienTiemNang_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                LayDanhSachHocVien();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Events
        private void LayDanhSachHocVien()
        {
            try
            {
                HocVienFilter _filter = new HocVienFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.LoaiHocVienId = KeySetting.LOAIHOCVIEN_TIEMNANG;
                _filter.NgayTiepNhan_Tu = date_TuNgay.DateTime;
                _filter.NgayTiepNhan_Den = date_DenNgay.DateTime;

                this.lstHocVien = HocVienLogic.SelectQuanLyHocVien(_filter);

                if (this.lstHocVien != null && this.lstHocVien.Count > 0)
                {
                    for (int i = 0; i < this.lstHocVien.Count; i++)
                    {
                        this.lstHocVien[i].Stt = i + 1;
                    }
                    gridControlDSHocVien.DataSource = this.lstHocVien;
                }
                else
                {
                    gridControlDSHocVien.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LayDanhSachHocVien();
        }
        private void gridViewDSHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDSHocVien.RowCount > 0)
                {
                    var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                    int _HocVienId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());
                    LoadLichSuTuVanTheoHocVien(_HocVienId);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadLichSuTuVanTheoHocVien(int _HocVienId)
        {
            try
            {
                List<LichSuTuVan_PlusDTO> _lstLSTuVan = LichSuTuVanLogic.Select(_HocVienId);
                if (_lstLSTuVan != null && lstHocVien.Count > 0)
                {
                    for (int i = 0; i < _lstLSTuVan.Count; i++)
                    {
                        _lstLSTuVan[i].Stt = i + 1;
                    }
                    gridControlLSTuVan.DataSource = _lstLSTuVan;
                }
                else
                {
                    gridControlLSTuVan.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void repositoryItemButton_TuVan_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDSHocVien.RowCount > 0)
                {
                    var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                    int _HocVienId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());
                    frmThemTuVanHocVien _frm = new frmThemTuVanHocVien(_HocVienId);
                    _frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Custom
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


        #endregion

        #region In va xuat excel
        private void btnInAn_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));

                string tungay = DateTime.ParseExact(date_TuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                string denngay = DateTime.ParseExact(date_DenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                reportExcelDTO reportitem = new reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = tungaydenngay;
                thongTinThem.Add(reportitem);

                string fileTemplatePath = "FUN_QuanLyHocVien_TiemNang.xlsx";
                DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(this.lstHocVien);
                O2S_Common.Utilities.PrintPreview.ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _databaocao);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string tungay = DateTime.ParseExact(date_TuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                string denngay = DateTime.ParseExact(date_DenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                reportExcelDTO reportitem = new reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = tungaydenngay;
                thongTinThem.Add(reportitem);

                string fileTemplatePath = "FUN_QuanLyHocVien_TiemNang.xlsx";
                DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(this.lstHocVien);
                O2S_Common.Excel.ExcelExport.ExportExcelTemplate("", fileTemplatePath, thongTinThem, _databaocao);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }






        #endregion


    }
}
