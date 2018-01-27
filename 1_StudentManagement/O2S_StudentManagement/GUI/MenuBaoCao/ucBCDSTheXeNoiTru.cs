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
using DevExpress.Utils.Menu;

namespace O2S_StudentManagement.GUI.MenuBaoCao
{
    public partial class ucBCDSTheXeNoiTru : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion

        public ucBCDSTheXeNoiTru()
        {
            InitializeComponent();
        }

        #region Load
        private void ucBCDSTheXeNoiTrucs_Load(object sender, EventArgs e)
        {
            try
            {
                btnTimKiem.PerformClick();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion

        #region Tim Kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                string _sqlTimKiem = " SELECT row_number () over (order by createdate,sothexe) as stt, benhnhanthexeid, patientid, patientcode, vienphiid, hosobenhanid, patientname, to_char(vienphidate,'HH24:MI dd/MM/yyyy') as vienphidate, (case when vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vienphidate_ravien,'HH24:MI dd/MM/yyyy') end) as vienphidate_ravien, bhytcode, gioitinhname, to_char(namsinh,'dd/MM/yyyy') as namsinh, diachi, (case when vienphistatus=0 then 'Đang điều trị' else 'Đã ra viện' end) as vienphistatus_name, (case loaivienphiid when 0 then 'Nội trú' when 1 then 'Ngoại trú' when 2 then 'Điều trị ngoại trú' end) as loaivienphi_name, (departmentgroupname || ' - ' || departmentname) as khoaphong, sothexe, cardeventid, mathexe, biensoxe, loaixe, (case when thoigianvao<>'0001-01-01 00:00:00' then to_char(thoigianvao,'HH24:MI dd/MM/yyyy') end) as thoigianvao, to_char(createdate,'HH24:MI dd/MM/yyyy') as createdate, (createusercode || ' - ' || createusername) as nguoicapnhat, ketthuc_status, (case when ketthuc_status=1 then 'Đã kết thúc' end) as ketthuc_status_name, (case when ketthuc_status=1 then to_char(ketthuc_date,'HH24:MI dd/MM/yyyy') end) as ketthuc_date, (case when ketthuc_status=1 then (ketthuc_usercode || ' - ' || ketthuc_username) end) as nguoiketthuc, (case when ismatthe=1 then 'Mất thẻ xe' end) as ismatthe FROM cp_benhnhanthexe WHERE isremove=0 and ketthuc_status=0 and ismatthe=0; ";
                DataTable _dataTimKiem = condb.GetDataTable(_sqlTimKiem);
                if (_dataTimKiem != null && _dataTimKiem.Rows.Count > 0)
                {
                    gridControlDataBaoCao.DataSource = _dataTimKiem;
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
            SplashScreenManager.CloseForm();
        }

        #endregion

        #region Events
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
                    //string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                    //string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                    //string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                    List<O2S_StudentManagement.Model.Models.reportExcelDTO> thongTinThem = new List<O2S_StudentManagement.Model.Models.reportExcelDTO>();
                    O2S_StudentManagement.Model.Models.reportExcelDTO reportitem = new O2S_StudentManagement.Model.Models.reportExcelDTO();
                    reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                    reportitem.value = "";
                    thongTinThem.Add(reportitem);

                    string fileTemplatePath = "REPORT_04_BCDSTheXeNoiTru.xlsx";

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
                //string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                //string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                //string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                List<O2S_StudentManagement.Model.Models.reportExcelDTO> thongTinThem = new List<O2S_StudentManagement.Model.Models.reportExcelDTO>();
                O2S_StudentManagement.Model.Models.reportExcelDTO reportitem = new O2S_StudentManagement.Model.Models.reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = "";
                thongTinThem.Add(reportitem);

                string fileTemplatePath = "REPORT_04_BCDSTheXeNoiTru.xlsx";
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
