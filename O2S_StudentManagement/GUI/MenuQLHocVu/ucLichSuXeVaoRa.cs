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

namespace O2S_StudentManagement.GUI.MenuThongKe
{
    public partial class ucLichSuXeVaoRa : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion

        public ucLichSuXeVaoRa()
        {
            InitializeComponent();
        }


        #region Load
        private void ucLichSuXeVaoRacs_Load(object sender, EventArgs e)
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
                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");


                if (cboTieuChi.Text == "Theo thời gian xe vào")
                {
                    _tieuchi = " even.DatetimeIn between '" + tungay + "' and '" + denngay + "' ";
                }
                else if (cboTieuChi.Text == "Theo thời gian xe ra")
                {
                    _tieuchi = " even.DateTimeOut between '" + tungay + "' and '" + denngay + "' ";
                }

                if (txtTK_SoTheXe.Text.Trim() != "" && txtTK_SoTheXe.Text.Trim().Length == 8)
                {
                    _tieuchi += " and even.CardNumber='" + txtTK_SoTheXe.Text.Trim() + "' ";
                }
                else if (txtTK_SoTheXe.Text.Trim() != "" && txtTK_SoTheXe.Text.Trim().Length != 8)
                {
                    _tieuchi += " and even.CardNo='" + txtTK_SoTheXe.Text.PadLeft(6, '0') + "' ";
                }

                if (cboTrangThai.Text == "Chưa lấy xe")
                {
                    _trangthai = " and even.DateTimeOut is NULL ";
                }
                else if (cboTrangThai.Text == "Đã lấy xe")
                {
                    _trangthai = " and even.DateTimeOut is NOT NULL ";
                }
                string _sqlTimKiem = "SELECT row_number () over (order by even.DatetimeIn) as stt, even.Id as cardeventid, even.CardNo as sothexe, even.CardNumber as mathexe, even.PlateIn as biensoxevao, even.PlateOut as biensoxera, even.DatetimeIn as thoigianxevao, REPLACE(REPLACE(REPLACE(CAST(CONVERT(VARCHAR(19),even.DatetimeIn,120) AS VARCHAR(20)),'-',''),':',''),' ','') as thoigianvao_long, even.DateTimeOut as thoigianxera, uvao.FullName as nguoithuchienvao, ura.FullName as nguoithuchienra, lan_in.LaneName as lanvao_name, lan_out.LaneName as lanra_name, even.PicDirIn, even.PicDirOut, cgrp.CardGroupName FROM [MPARKINGEVENT].[dbo].[tblCardEvent] even left join [MPARKING].[dbo].[tblUser] uvao on uvao.UserID=even.UserIDIn left join [MPARKING].[dbo].[tblUser] ura on convert(nvarchar(50),ura.UserID)=convert(nvarchar(50),even.UserIDOut) left join [MPARKING].[dbo].[tblLane] lan_in on convert(nvarchar(50),lan_in.LaneID)=convert(nvarchar(50),even.LaneIDIn) left join [MPARKING].[dbo].[tblLane] lan_out on convert(nvarchar(50),lan_out.LaneID)=convert(nvarchar(50),even.LaneIDOut) left join [MPARKING].[dbo].[tblCardGroup] cgrp on cgrp.CardGroupID=even.CardGroupID WHERE " + _tieuchi + _trangthai + "; ";

                DataTable _dataTimKiem = condb.GetDataTable_BGX(_sqlTimKiem, 1);
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
        private void gridViewDataBaoCao_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.MenuType == GridMenuType.Row)
                {
                    e.Menu.Items.Clear();
                    DXMenuItem itemXoaNguoiDung = new DXMenuItem("Xem ảnh xe vào/ra");
                    itemXoaNguoiDung.Image = imMenu.Images[0];
                    itemXoaNguoiDung.Click += new EventHandler(repositoryItemButton_chitiet_Click);
                    e.Menu.Items.Add(itemXoaNguoiDung);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void repositoryItemButton_chitiet_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                string _cardeventid = gridViewDataBaoCao.GetRowCellValue(rowHandle, "cardeventid").ToString();
                frmXemAnhXeVaoRa frmAnh = new frmXemAnhXeVaoRa(_cardeventid);
                frmAnh.ShowDialog();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
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
        private void txtTK_SoTheXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    {
            //        e.Handled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Common.Logging.LogSystem.Warn(ex);
            //}
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
        private void txtTK_SoTheXe_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTK_SoTheXe.Text.Length == 10)
                {
                    txtTK_SoTheXe.Text = Common.TypeConvert.TypeConvertParse.ToUInt64(txtTK_SoTheXe.Text).ToString("X");
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

                    string fileTemplatePath = "TOOL_06_LichSuXeVaoRa.xlsx";

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

                string fileTemplatePath = "TOOL_06_LichSuXeVaoRa.xlsx";
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
