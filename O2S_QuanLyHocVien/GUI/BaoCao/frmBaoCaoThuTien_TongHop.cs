// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmBaoCaoHocVienTheoThang.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using System.Threading;
using O2S_QuanLyHocVien.Reports;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Data;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic.Models;
using O2S_Common.DataObjects;

namespace O2S_QuanLyHocVien.BaoCao
{
    public partial class frmBaoCaoThuTien_TongHop : Form
    {
        private DataTable dataPhieuThuTH { get; set; }
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        public frmBaoCaoThuTien_TongHop()
        {
            InitializeComponent();
        }

        #region Load
        private void frmBaoCaoHocVienTheoThang_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Events
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));
            try
            {
                string datetungay = DateTime.ParseExact(date_TuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string datedenngay = DateTime.ParseExact(date_DenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                string _SQLselect = @"SELECT 
	 row_number () over (order by FORMAT(pt.ThoiGianThu,'dd/MM/yyyy')) as stt,
	 FORMAT(pt.ThoiGianThu,'dd/MM/yyyy') as ThoiGianThu,
	 nv.TenNhanVien as TenNguoiThu,
	 sum(pt.SoTien) as SoTien
FROM 
	(select * from PHIEUTHU where CoSoId='" + GlobalSettings.CoSoId + "' and ThoiGianThu between '" + datetungay + "' and '" + datedenngay + "' ) pt inner join (select TenDangNhap,TaiKhoanId from TAIKHOAN) tk on tk.TenDangNhap = pt.CreatedBy inner join (select TaiKhoanId, TenNhanVien from NHANVIEN) nv on nv.TaiKhoanId = tk.TaiKhoanId GROUP BY FORMAT(pt.ThoiGianThu, 'dd/MM/yyyy'), nv.TenNhanVien; ";
                this.dataPhieuThuTH = condb.GetDataTable(_SQLselect);
                if (this.dataPhieuThuTH != null && this.dataPhieuThuTH.Rows.Count > 0)
                {
                    gridControlDSPhieuGhiDanh.DataSource = this.dataPhieuThuTH;
                }
                else
                {
                    gridControlDSPhieuGhiDanh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

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

                string fileTemplatePath = "BC06_BaoCaoThuTien_TongHop.xlsx";
                Utilities.Prints.PrintPreview.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, this.dataPhieuThuTH);
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

                string fileTemplatePath = "BC06_BaoCaoThuTien_TongHop.xlsx";
                Utilities.Excel.ExcelExport.ExportExcelTemplate("", fileTemplatePath, thongTinThem, this.dataPhieuThuTH);
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

        private void gridViewDSHocVien_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == gridColumn_stt)
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
