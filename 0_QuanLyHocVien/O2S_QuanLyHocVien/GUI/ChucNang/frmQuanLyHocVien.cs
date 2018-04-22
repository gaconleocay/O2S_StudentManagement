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

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyHocVien : Form
    {
        private List<QuanLyHocVienDTO> lstHocVien { get; set; }
        public frmQuanLyHocVien()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyHocVien_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                LayDanhSachHocVien();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
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
                _filter.LoaiHocVienId = KeySetting.LOAIHOCVIEN_CHINHTHUC;
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
                lblTongCong.Text = string.Format("Tổng cộng: {0} học viên", gridViewDSHocVien.RowCount);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LayDanhSachHocVien();
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
                Common.Logging.LogSystem.Warn(ex);
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
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region In va xuat excel
        private void btnInAn_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));

                string tungay = DateTime.ParseExact(date_TuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                string denngay = DateTime.ParseExact(date_DenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                reportExcelDTO reportitem = new reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = tungaydenngay;
                thongTinThem.Add(reportitem);

                string fileTemplatePath = "FUN_QuanLyHocVien_ChinhThuc.xlsx";
                DataTable _databaocao = Common.DataTables.ConvertDataTable.ListToDataTable(this.lstHocVien);
                Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _databaocao);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
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

                string fileTemplatePath = "FUN_QuanLyHocVien_ChinhThuc.xlsx";
                DataTable _databaocao = Common.DataTables.ConvertDataTable.ListToDataTable(this.lstHocVien);
                Utilities.Common.Excel.ExcelExport export = new Utilities.Common.Excel.ExcelExport();
                export.ExportExcelTemplate("", fileTemplatePath, thongTinThem, _databaocao);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion




    }
}
