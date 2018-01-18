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

namespace O2S_StudentManagement.GUI.MenuBaoCao
{
    public partial class ucBCTinhHinh_TongHop : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion

        public ucBCTinhHinh_TongHop()
        {
            InitializeComponent();
        }


        #region Load
        private void ucBCTinhHinh_TongHop_Load(object sender, EventArgs e)
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
                string _baocaotheo_vao = " convert(varchar(5),DatetimeIn ,3) ";
                string _baocaotheo_ra = " convert(varchar(5),DateTimeOut ,3) ";
                string _baocaotheo_bill = " TO_CHAR(billdate,'dd/MM') ";

                string _createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                if (cboTieuChi.Text == "Tháng")
                {
                    _baocaotheo_vao = " LEFT(CONVERT(VARCHAR(8), DatetimeIn, 1), 2) ";
                    _baocaotheo_ra = " LEFT(CONVERT(VARCHAR(8), DateTimeOut, 1), 2) ";
                    _baocaotheo_bill = " TO_CHAR(billdate,'MM') ";
                }
                else if (cboTieuChi.Text == "Năm")
                {
                    _baocaotheo_vao = " CAST(YEAR(DatetimeIn) AS VARCHAR(4)) ";
                    _baocaotheo_ra = " CAST(YEAR(DateTimeOut) AS VARCHAR(4)) ";
                    _baocaotheo_bill = " TO_CHAR(billdate,'yyyy') ";
                }

                string _sqlLayVaoRa = "SELECT A.ngaythangnam, sum(case when A.noidung='vao' then A.soluong else 0 end) as sl_vao, sum(case when A.noidung='ra' then A.soluong else 0 end) as sl_ra, sum(case when A.noidung='ra' then A.thu3000 else 0 end) as thu3000, sum(case when A.noidung='ra' then A.thu4000 else 0 end) as thu4000, sum(case when A.noidung='ra' then A.thu5000 else 0 end) as thu5000, sum(case when A.noidung='ra' then A.thu6000 else 0 end) as thu6000, sum(case when A.noidung='ra' then A.thu9000 else 0 end) as thu9000, sum(case when A.noidung='ra' then A.thu10000 else 0 end) as thu10000, sum(case when A.noidung='ra' then A.thu14000 else 0 end) as thu14000, sum(case when A.noidung='ra' then A.thu16000 else 0 end) as thu16000, sum(case when A.noidung='ra' then A.thu19000 else 0 end) as thu19000, sum(case when A.noidung='ra' then A.thu24000 else 0 end) as thu24000, sum(case when A.noidung='ra' then A.thu26000 else 0 end) as thu26000, sum(case when A.noidung='ra' then A.thu29000 else 0 end) as thu29000, sum(case when A.noidung='ra' then A.thu34000 else 0 end) as thu34000, sum(case when A.noidung='ra' then A.thu36000 else 0 end) as thu36000, sum(case when A.noidung='ra' then A.thu46000 else 0 end) as thu46000, sum(case when A.noidung='ra' then A.thu56000 else 0 end) as thu56000, sum(case when A.noidung='ra' then A.thu59000 else 0 end) as thu59000, sum(case when A.noidung='ra' then A.thu66000 else 0 end) as thu66000, sum(case when A.noidung='ra' then A.thu76000 else 0 end) as thu76000, sum(case when A.noidung='ra' then A.thu86000 else 0 end) as thu86000, sum(case when A.noidung='ra' then A.thu96000 else 0 end) as thu96000, sum(case when A.noidung='ra' then A.thukhac else 0 end) as thukhac, (sum(case when A.noidung='ra' then A.thu3000 else 0 end)*3000+ sum(case when A.noidung='ra' then A.thu4000 else 0 end)*4000+ sum(case when A.noidung='ra' then A.thu5000 else 0 end)*5000+ sum(case when A.noidung='ra' then A.thu6000 else 0 end)*6000+ sum(case when A.noidung='ra' then A.thu9000 else 0 end)*9000+ sum(case when A.noidung='ra' then A.thu10000 else 0 end)*10000+ sum(case when A.noidung='ra' then A.thu14000 else 0 end)*14000+ sum(case when A.noidung='ra' then A.thu16000 else 0 end)*16000+ sum(case when A.noidung='ra' then A.thu19000 else 0 end)*19000+ sum(case when A.noidung='ra' then A.thu24000 else 0 end)*24000+ sum(case when A.noidung='ra' then A.thu26000 else 0 end)*26000+ sum(case when A.noidung='ra' then A.thu29000 else 0 end)*29000+ sum(case when A.noidung='ra' then A.thu34000 else 0 end)*34000+ sum(case when A.noidung='ra' then A.thu36000 else 0 end)*36000+ sum(case when A.noidung='ra' then A.thu46000 else 0 end)*46000+ sum(case when A.noidung='ra' then A.thu56000 else 0 end)*56000+ sum(case when A.noidung='ra' then A.thu59000 else 0 end)*59000+ sum(case when A.noidung='ra' then A.thu66000 else 0 end)*66000+ sum(case when A.noidung='ra' then A.thu76000 else 0 end)*76000+ sum(case when A.noidung='ra' then A.thu86000 else 0 end)*86000+ sum(case when A.noidung='ra' then A.thu96000 else 0 end)*96000+ sum(case when A.noidung='ra' then A.thukhac_tien else 0 end)) as tongtien FROM ( select 'vao' as noidung, " + _baocaotheo_vao + " as ngaythangnam, count(*) as soluong, 0 as thu3000, 0 as thu4000, 0 as thu5000, 0 as thu6000, 0 as thu9000, 0 as thu10000, 0 as thu14000, 0 as thu16000, 0 as thu19000, 0 as thu24000, 0 as thu26000, 0 as thu29000, 0 as thu34000, 0 as thu36000, 0 as thu46000, 0 as thu56000, 0 as thu59000, 0 as thu66000, 0 as thu76000, 0 as thu86000, 0 as thu96000, 0 as thukhac, 0 as thukhac_tien, 0 as tongtien from [MPARKINGEVENT].[dbo].[tblCardEvent] where IsDelete=0 and DatetimeIn between '" + tungay + "' and '" + denngay + "' group by " + _baocaotheo_vao + " union all select 'ra' as noidung, " + _baocaotheo_ra + " as ngaythangnam, count(*) as soluong, sum(case when IsFree=0 and Moneys=3000 then 1 else 0 end) as thu3000, sum(case when IsFree=0 and Moneys=4000 then 1 else 0 end) as thu4000, sum(case when IsFree=0 and Moneys=5000 then 1 else 0 end) as thu5000, sum(case when IsFree=0 and Moneys=6000 then 1 else 0 end) as thu6000, sum(case when IsFree=0 and Moneys=9000 then 1 else 0 end) as thu9000, sum(case when IsFree=0 and Moneys=10000 then 1 else 0 end) as thu10000, sum(case when IsFree=0 and Moneys=14000 then 1 else 0 end) as thu14000, sum(case when IsFree=0 and Moneys=16000 then 1 else 0 end) as thu16000, sum(case when IsFree=0 and Moneys=19000 then 1 else 0 end) as thu19000, sum(case when IsFree=0 and Moneys=24000 then 1 else 0 end) as thu24000, sum(case when IsFree=0 and Moneys=26000 then 1 else 0 end) as thu26000, sum(case when IsFree=0 and Moneys=29000 then 1 else 0 end) as thu29000, sum(case when IsFree=0 and Moneys=34000 then 1 else 0 end) as thu34000, sum(case when IsFree=0 and Moneys=36000 then 1 else 0 end) as thu36000, sum(case when IsFree=0 and Moneys=46000 then 1 else 0 end) as thu46000, sum(case when IsFree=0 and Moneys=56000 then 1 else 0 end) as thu56000, sum(case when IsFree=0 and Moneys=59000 then 1 else 0 end) as thu59000, sum(case when IsFree=0 and Moneys=66000 then 1 else 0 end) as thu66000, sum(case when IsFree=0 and Moneys=76000 then 1 else 0 end) as thu76000, sum(case when IsFree=0 and Moneys=86000 then 1 else 0 end) as thu86000, sum(case when IsFree=0 and Moneys=96000 then 1 else 0 end) as thu96000, sum(case when IsFree=0 and Moneys>96000 then 1 else 0 end) as thukhac, sum(case when IsFree=0 and Moneys>96000 then Moneys else 0 end) as thukhac_tien, 0 as tongtien from [MPARKINGEVENT].[dbo].[tblCardEvent] where IsDelete=0 and DateTimeOut between '" + tungay + "' and '" + denngay + "' group by " + _baocaotheo_ra + " ) A GROUP BY A.ngaythangnam;";

                DataTable _dataVaoRa = condb.GetDataTable_BGX(_sqlLayVaoRa, 1);
                if (_dataVaoRa != null && _dataVaoRa.Rows.Count > 0)
                {
                    string _insertBCTmp = "";
                    for (int i = 0; i < _dataVaoRa.Rows.Count; i++)
                    {
                        _insertBCTmp += "insert into CP_BCTongHop_Tmp(ngaythangnam, sl_vao, sl_ra, thu3000, thu4000, thu5000, thu6000, thu9000, thu10000, thu14000, thu16000, thu19000, thu24000, thu26000, thu29000, thu34000, thu36000, thu46000, thu56000, thu59000, thu66000, thu76000, thu86000, thu96000, thukhac, tongtien, createdate, createusercode) values ('" + _dataVaoRa.Rows[i]["ngaythangnam"].ToString() + "', '" + _dataVaoRa.Rows[i]["sl_vao"].ToString() + "', '" + _dataVaoRa.Rows[i]["sl_ra"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu3000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu4000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu5000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu6000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu9000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu10000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu14000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu16000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu19000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu24000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu26000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu29000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu34000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu36000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu46000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu56000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu59000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu66000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu76000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu86000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thu96000"].ToString() + "', '" + _dataVaoRa.Rows[i]["thukhac"].ToString() + "', '" + _dataVaoRa.Rows[i]["tongtien"].ToString() + "', '" + _createdate + "', '" + Base.SessionLogin.SessionUsercode + "');  ";
                    }
                    if (condb.ExecuteNonQuery_HSBA(_insertBCTmp))
                    {
                        string _sqlBaoCao = "SELECT row_number () over (order by event.ngaythangnam) as stt, COALESCE(event.ngaythangnam,bill.ngaythangnam) as ngaythangnam, event.sl_vao, event.sl_ra, bill.tamung, bill.hoanung, event.thu3000, event.thu4000, event.thu5000, event.thu6000, event.thu9000, event.thu10000, event.thu14000, event.thu16000, event.thu19000, event.thu24000, event.thu26000, event.thu29000, event.thu34000, event.thu36000, event.thu46000, event.thu56000, event.thu59000, event.thu66000, event.thu76000, event.thu86000, event.thu96000, event.thukhac, event.tongtien FROM (select * from CP_BCTongHop_Tmp where createdate='" + _createdate + "' and createusercode='" + Base.SessionLogin.SessionUsercode + "') event full join (select " + _baocaotheo_bill + " as ngaythangnam, sum(case when loaiphieuthuid=0 then 1 else 0 end) as tamung, sum(case when loaiphieuthuid=1 then 1 else 0 end) as hoanung from cp_bill where billdate between '" + tungay + "' and '" + denngay + "' group by " + _baocaotheo_bill + ") bill on bill.ngaythangnam=event.ngaythangnam; ";
                        DataTable _dataBaoCaoTH = condb.GetDataTable(_sqlBaoCao);
                        if (_dataBaoCaoTH != null && _dataBaoCaoTH.Rows.Count > 0)
                        {
                            gridControlDataBaoCao.DataSource = _dataBaoCaoTH;
                            string _sqlDeleteTmp = "DELETE FROM CP_BCTongHop_Tmp WHERE createdate='" + _createdate + "' and createusercode='" + Base.SessionLogin.SessionUsercode + "'; ";
                            condb.ExecuteNonQuery_HSBA(_sqlDeleteTmp);
                            //Hien thi tong
                            decimal _tongthu = 0;
                            decimal _tonghoan = 0;
                            for (int i = 0; i < _dataBaoCaoTH.Rows.Count; i++)
                            {
                                _tongthu += Common.TypeConvert.TypeConvertParse.ToInt64(_dataBaoCaoTH.Rows[i]["tongtien"].ToString());

                                _tonghoan += (Common.TypeConvert.TypeConvertParse.ToInt64(_dataBaoCaoTH.Rows[i]["hoanung"].ToString()) * 50000);
                            }
                            lblTongThu.Text = Common.Number.NumberConvert.NumberToString(_tongthu,0);
                            lblTongHoan.Text = Common.Number.NumberConvert.NumberToString(_tonghoan, 0);
                            lblCon.Text = Common.Number.NumberConvert.NumberToString((_tongthu - _tonghoan), 0);
                        }
                        else
                        {
                            gridControlDataBaoCao.DataSource = null;
                            Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                            frmthongbao.Show();
                            lblTongThu.Text = "0";
                            lblTongHoan.Text = "0";
                            lblCon.Text = "0";
                        }
                    }
                }
                else
                {
                    gridControlDataBaoCao.DataSource = null;
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                    lblTongThu.Text = "0";
                    lblTongHoan.Text = "0";
                    lblCon.Text = "0";
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

                    string fileTemplatePath = "REPORT_03_BCTinhHinh_TongHop.xlsx";

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

                string fileTemplatePath = "REPORT_03_BCTinhHinh_TongHop.xlsx";
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
