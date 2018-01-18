using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;

namespace O2S_StudentManagement.GUI.MenuBaoCao
{
    public partial class ucBCXeNamLauTrongBai : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion

        public ucBCXeNamLauTrongBai()
        {
            InitializeComponent();
        }

        #region Load
        private void ucBCXeNamLauTrongBai_Load(object sender, EventArgs e)
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


        #region Tim kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string _createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                string _sqlTimKiem_Tmp = "SELECT row_number () over (order by A.thoigianxevao) as stt, A.* FROM( SELECT even.Id as cardeventid, DATEDIFF(day, even.DatetimeIn, GETDATE()) as TGTrongBai, even.CardNo as sothexe, even.CardNumber as mathexe, even.PlateIn as biensoxevao, even.DatetimeIn as thoigianxevao, CONVERT(VARCHAR(26), even.DatetimeIn, 25) as thoigianvao_date, uvao.FullName as nguoithuchienvao, ura.FullName as nguoithuchienra, lan_in.LaneName as lanvao_name, even.PicDirIn, cgrp.CardGroupName as loaixe FROM [MPARKINGEVENT].[dbo].[tblCardEvent] even left join [MPARKING].[dbo].[tblUser] uvao on uvao.UserID=even.UserIDIn left join [MPARKING].[dbo].[tblUser] ura on convert(nvarchar(50),ura.UserID)=convert(nvarchar(50),even.UserIDOut) left join [MPARKING].[dbo].[tblLane] lan_in on convert(nvarchar(50),lan_in.LaneID)=convert(nvarchar(50),even.LaneIDIn) left join [MPARKING].[dbo].[tblLane] lan_out on convert(nvarchar(50),lan_out.LaneID)=convert(nvarchar(50),even.LaneIDOut) left join [MPARKING].[dbo].[tblCardGroup] cgrp on cgrp.CardGroupID=even.CardGroupID WHERE DateTimeOut IS NULL and even.DatetimeIn between '" + tungay + "' and '" + denngay + "' ) A WHERE A.TGTrongBai>='" + txtSoNgayTu.Text.Trim() + "' ;";
                DataTable dataTimKiem_Tmp = condb.GetDataTable_BGX(_sqlTimKiem_Tmp, 1);
                if (dataTimKiem_Tmp != null && dataTimKiem_Tmp.Rows.Count > 0)
                {
                    string _insertBCTmp = "";
                    for (int i = 0; i < dataTimKiem_Tmp.Rows.Count; i++)
                    {
                        _insertBCTmp += "INSERT INTO cp_bcxenamlau_tmp(stt, cardeventid, tgtrongbai, sothexe, mathexe, biensoxevao, thoigianxevao, nguoithuchienvao, lanvao_name, picdirin, loaixe, createdate, createusercode) VALUES ('" + dataTimKiem_Tmp.Rows[i]["stt"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["cardeventid"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["tgtrongbai"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["sothexe"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["mathexe"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["biensoxevao"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["thoigianvao_date"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["nguoithuchienvao"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["lanvao_name"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["picdirin"].ToString() + "', '" + dataTimKiem_Tmp.Rows[i]["loaixe"].ToString() + "', '" + _createdate + "', '" + Base.SessionLogin.SessionUsercode + "'); ";
                    }
                    if (condb.ExecuteNonQuery_HSBA(_insertBCTmp))
                    {
                        string _sqlTimKiem_BC = "select * from cp_bcxenamlau_tmp where createdate='" + _createdate + "' and createusercode='" + Base.SessionLogin.SessionUsercode + "'; ";
                        DataTable dataTimKiem_BC = condb.GetDataTable(_sqlTimKiem_BC);
                        if (dataTimKiem_BC != null && dataTimKiem_BC.Rows.Count > 0)
                        {
                            gridControlDataBaoCao.DataSource = dataTimKiem_BC;
                            string _sqlDeleteTmp = "DELETE FROM cp_bcxenamlau_tmp WHERE createdate='" + _createdate + "' and createusercode='" + Base.SessionLogin.SessionUsercode + "'; ";
                            condb.ExecuteNonQuery_HSBA(_sqlDeleteTmp);
                        }
                        else
                        {
                            gridControlDataBaoCao.DataSource = null;
                            Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                            frmthongbao.Show();
                        }
                    }
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
        private void gridViewDataBaoCao_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    int tongsongay = Common.TypeConvert.TypeConvertParse.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["tgtrongbai"]));
                    if (tongsongay >= 5 && tongsongay <= 7)
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        //e.Appearance.BackColor2 = Color.LightCyan;
                        e.HighPriority = true;
                    }
                    else if (tongsongay >= 8 && tongsongay <= 10)
                    {
                        e.Appearance.BackColor = Color.LightSalmon;
                        //e.Appearance.BackColor2 = Color.LightCyan;
                        e.HighPriority = true;
                    }
                    else if (tongsongay > 10)
                    {
                        e.Appearance.BackColor = Color.Red;
                        //e.Appearance.BackColor2 = Color.LightCyan;
                        e.HighPriority = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Xuat bao cao va in
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

                    string fileTemplatePath = "REPORT_06_BCXeNamQuaLauTrongBai.xlsx";

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

                string fileTemplatePath = "REPORT_06_BCXeNamQuaLauTrongBai.xlsx";
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
