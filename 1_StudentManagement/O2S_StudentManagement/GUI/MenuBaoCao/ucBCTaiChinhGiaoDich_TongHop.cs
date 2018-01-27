using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using DevExpress.XtraSplashScreen;
using O2S_StudentManagement.Model.Models;

namespace O2S_StudentManagement.GUI.MenuBaoCao
{
    public partial class ucBCTaiChinhGiaoDich_TongHop : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion

        public ucBCTaiChinhGiaoDich_TongHop()
        {
            InitializeComponent();
        }


        #region Load
        private void ucBCTaiChinhGiaoDich_TongHopcs_Load(object sender, EventArgs e)
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion

        #region Events
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                List<BCTaiChinhGiaoDich_TongHopDTO> lstGiaoDichTongHop = new List<BCTaiChinhGiaoDich_TongHopDTO>();


                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string _tieuchi = " and billdate between '" + tungay + "' and '" + denngay + "' ";
                string _tieuchi_guixe = " and DateTimeOut between '" + tungay + "' and '" + denngay + "' ";

                string _sqlTimKiem_TUHU = "SELECT 1 as stt, 'Tạm ứng' as loaigiaodich, sum(sotien) as sotien FROM cp_bill WHERE loaiphieuthuid=0 and COALESCE(dahuyphieu,0)=0 " + _tieuchi + " UNION ALL SELECT 2 as stt, 'Hoàn ứng' as loaigiaodich, sum(sotien) as sotien FROM cp_bill WHERE loaiphieuthuid=1 and COALESCE(dahuyphieu,0)=0 " + _tieuchi + "; ";
                string _sqlTimKiem_ThuTien = "SELECT 3 as stt, 'Thu ti' + N'ề' + 'n' as loaigiaodich, sum(Moneys) as sotien FROM [MPARKINGEVENT].[dbo].[tblCardEvent] WHERE IsFree=0 " + _tieuchi_guixe + ";";
                DataTable _dataTimKiem_TUHU = condb.GetDataTable(_sqlTimKiem_TUHU);
                if (_dataTimKiem_TUHU != null && _dataTimKiem_TUHU.Rows.Count > 0)
                {
                    lstGiaoDichTongHop = Common.DataTables.ConvertDataTable.DataTableToList<BCTaiChinhGiaoDich_TongHopDTO>(_dataTimKiem_TUHU);
                }
                DataTable _dataTimKiem_ThuTien = condb.GetDataTable_BGX(_sqlTimKiem_ThuTien,1);
                if (_dataTimKiem_ThuTien != null && _dataTimKiem_ThuTien.Rows.Count > 0)
                {
                    List<BCTaiChinhGiaoDich_TongHopDTO> lstGiaoDich_ThuTien = Common.DataTables.ConvertDataTable.DataTableToList<BCTaiChinhGiaoDich_TongHopDTO>(_dataTimKiem_ThuTien);
                    lstGiaoDichTongHop.AddRange(lstGiaoDich_ThuTien);
                }
                BCTaiChinhGiaoDich_TongHopDTO _tongHop = new BCTaiChinhGiaoDich_TongHopDTO();
                _tongHop.stt = 4;
                _tongHop.loaigiaodich = "Tổng tiền quỹ";
                _tongHop.sotien = (lstGiaoDichTongHop[0].sotien + lstGiaoDichTongHop[2].sotien) - lstGiaoDichTongHop[1].sotien;
                lstGiaoDichTongHop.Add(_tongHop);

                if (lstGiaoDichTongHop != null && lstGiaoDichTongHop.Count > 0)
                {
                    gridControlDataBaoCao.DataSource = lstGiaoDichTongHop;
                }
                else
                {
                    gridControlDataBaoCao.DataSource = null;
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Custom
        private void gridViewDataBaoCao_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Xuat bao cao
        private void tbnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDataBaoCao.RowCount > 0)
                {
                    string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                    string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                    string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                    List<O2S_StudentManagement.Model.Models.reportExcelDTO> thongTinThem = new List<O2S_StudentManagement.Model.Models.reportExcelDTO>();
                    O2S_StudentManagement.Model.Models.reportExcelDTO reportitem = new O2S_StudentManagement.Model.Models.reportExcelDTO();
                    reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                    reportitem.value = tungaydenngay;

                    thongTinThem.Add(reportitem);

                    string fileTemplatePath = "REPORT_02_BCTaiChinhGiaoDich_TongHop.xlsx";

                    DataTable dataExportFilter = Common.GridControl.GridControlConvert.ConvertGridControlToDataTable(gridViewDataBaoCao);
                    Utilities.Common.Excel.ExcelExport export = new Utilities.Common.Excel.ExcelExport();
                    export.ExportExcelTemplate("", fileTemplatePath, thongTinThem, dataExportFilter);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                List<O2S_StudentManagement.Model.Models.reportExcelDTO> thongTinThem = new List<O2S_StudentManagement.Model.Models.reportExcelDTO>();
                O2S_StudentManagement.Model.Models.reportExcelDTO reportitem = new O2S_StudentManagement.Model.Models.reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = tungaydenngay;

                thongTinThem.Add(reportitem);

                string fileTemplatePath = "REPORT_02_BCTaiChinhGiaoDich_TongHop.xlsx";
                DataTable dataExportFilter = Common.GridControl.GridControlConvert.ConvertGridControlToDataTable(gridViewDataBaoCao);
                Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, dataExportFilter);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();

        }





        #endregion

    }
}
