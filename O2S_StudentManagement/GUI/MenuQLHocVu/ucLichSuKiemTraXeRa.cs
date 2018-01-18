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

namespace O2S_StudentManagement.GUI.MenuThongKe
{
    public partial class ucLichSuKiemTraXeRa : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion
        public ucLichSuKiemTraXeRa()
        {
            InitializeComponent();
        }


        #region Load
        private void ucLichSuKiemTraXeRacs_Load(object sender, EventArgs e)
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
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                string _tieuchi = "";
                string _trangthai = "";
                string _loaibenhan = "";
                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                _tieuchi = " checkdate between '" + tungay + "' and '" + denngay + "' ";

                if (txtTK_MaBenhNhan.Text.Trim() != "" && txtTK_SoTheXe.Text.Trim() == "")
                {
                    _tieuchi += " and patientid='" + Common.TypeConvert.TypeConvertParse.ToInt64(txtTK_MaBenhNhan.Text.Trim().ToUpper().Replace("BN", "")).ToString() + "' ";
                }
                else if (txtTK_MaBenhNhan.Text.Trim() == "" && txtTK_SoTheXe.Text.Trim() != "")
                {
                    if (txtTK_SoTheXe.Text.Trim().Length == 8)
                    {
                        _tieuchi += " and mathexe='" + txtTK_SoTheXe.Text.Trim() + "' ";
                    }
                    else
                    {
                        _tieuchi += " and sothexe='" + txtTK_SoTheXe.Text.PadLeft(6, '0') + "' ";
                    }
                }
                if (cboTrangThai.Text == "Miễn phí")
                {
                    _trangthai = " and checkstatus=1 ";
                }
                else if (cboTrangThai.Text == "Trả phí")
                {
                    _trangthai = " and checkstatus=0 ";
                }
                if (cboLoaiBenhAn.Text == "Ngoại trú")
                {
                    _loaibenhan = " and loaivienphiid in (1,2) ";
                }
                else if (cboLoaiBenhAn.Text == "Nội trú")
                {
                    _loaibenhan = " and loaivienphiid=0 ";
                }

                string _sqlTimKiem = "SELECT row_number () over (order by chk.checkdate) as stt, chk.patientid, chk.patientcode, chk.vienphiid, chk.hosobenhanid, chk.patientname, (case when chk.checkstatus=1 then 'Miễn phí' else 'Trả phí' end) as checkstatus_name, chk.checkdate, chk.checknote, (chk.checkusercode || ' - ' || chk.checkusername) as checkuser, chk.vienphidate, (case when chk.vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(chk.vienphidate_ravien,'HH24:MI dd/MM/yyyy') end) as vienphidate_ravien, chk.bhytcode, chk.gioitinhname, to_char(chk.namsinh,'dd/MM/yyyy') as namsinh, chk.diachi, chk.vienphistatus, (case when chk.vienphistatus=0 then 'Đang điều trị' else 'Đã ra viện' end) as vienphistatus_name, chk.loaivienphiid, (case chk.loaivienphiid when 0 then 'Nội trú' when 1 then 'Ngoại trú' when 2 then 'Điều trị ngoại trú' end) as loaivienphi_name, (chk.departmentgroupname || ' - ' || chk.departmentname) as khoaphong, (case when chk.thuhoithe=1 then 'Thu lại thẻ gửi xe' end) as thuhoithe, chk.mathexe as mathexe, chk.sothexe as sothexe, chk.biensoxe as biensoxe, chk.loaixe as loaixe, to_char(chk.thoigianvao,'HH24:MI dd/MM/yyyy') as thoigianvao, chk.cardeventid as cardeventid FROM (select * from cp_checkxera where " + _tieuchi + _trangthai + _loaibenhan + ") chk; ";
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
        private void txtMaBenhNhan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimKiem.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtTK_SoTheXe_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimKiem.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtMaBenhNhan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTK_MaBenhNhan.Text != "")
                {
                    txtTK_MaBenhNhan.Text = txtTK_MaBenhNhan.Text.ToUpper();
                    txtTK_SoTheXe.Text = "";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtTK_SoTheXe_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTK_SoTheXe.Text.Trim() != "")
                {
                    txtTK_MaBenhNhan.Text = "";
                    if (txtTK_SoTheXe.Text.Length == 10)
                    {
                        txtTK_SoTheXe.Text = Common.TypeConvert.TypeConvertParse.ToUInt64(txtTK_SoTheXe.Text).ToString("X");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtTK_SoTheXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
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

                    string fileTemplatePath = "TOOL_05_LichSuKiemTraXeRa.xlsx";

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

                string fileTemplatePath = "TOOL_05_LichSuKiemTraXeRa.xlsx";
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
