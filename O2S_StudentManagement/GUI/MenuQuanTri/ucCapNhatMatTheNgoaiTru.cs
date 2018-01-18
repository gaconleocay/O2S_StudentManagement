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
using DevExpress.Utils.Menu;
using System.Globalization;
using DevExpress.XtraSplashScreen;
using O2S_StudentManagement.Model.Models;

namespace O2S_StudentManagement.GUI.MenuQuanTri
{
    public partial class ucCapNhatMatTheNgoaiTru : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion


        public ucCapNhatMatTheNgoaiTru()
        {
            InitializeComponent();
        }

        #region Load 
        private void ucCapNhatMatTheNgoaiTru_Load(object sender, EventArgs e)
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                EnabledAndDisableControl(false);
                btnTimKiem.PerformClick();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region Tim kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");

                string _sqlTimKiem = "select row_number () over (order by createdate) as stt, *, (createusercode || ' - ' || createusername) as nguoitao from CP_matthexe where isremove=0 and createdate between '" + tungay + "' and '" + denngay + "';";
                DataTable _dataMatTheXe = condb.GetDataTable(_sqlTimKiem);
                if (_dataMatTheXe != null && _dataMatTheXe.Rows.Count > 0)
                {
                    gridControlDataBaoCao.DataSource = _dataMatTheXe;
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

        #region Events
        private void btnTimTTXe_Click(object sender, EventArgs e)
        {
            try
            {
                EnabledAndDisableControl(true);
                Model.Models.ThongTinVeXeDTO _thongtinxe = new Model.Models.ThongTinVeXeDTO();
                frmThongTinXeVaoRa _frmTTXe = new frmThongTinXeVaoRa();
                _frmTTXe.MyGetData = new frmThongTinXeVaoRa.GetString(TranPatiDataThongTinXe);
                _frmTTXe.ShowDialog();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void TranPatiDataThongTinXe(Model.Models.ThongTinVeXeDTO _thongtinxe)
        {
            try
            {
                txtXe_Cardeventid.Text = _thongtinxe.cardeventid;
                txtXe_MaTheXe.Text = _thongtinxe.mathexe;
                txtXe_SoTheXe.Text = _thongtinxe.sothexe;
                cboXe_LoaiXe.Text = _thongtinxe.nhomthexe;
                txtXe_BienSoXe.Text = _thongtinxe.biensoxevao;
                txtXe_TenChuXe.Text = "";
                txtXe_DiaChi.Text = "";
                txtGhiChu.Text = "";
                txtXe_ThoiGianVao.Text = DateTime.ParseExact(_thongtinxe.thoigianvao_long, "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                pictureAnhXeVao_PLATEIN.Image = Image.FromFile(_thongtinxe.PicDirIn);
                pictureAnhXeVao_OVERVIEWIN.Image = Image.FromFile(_thongtinxe.PicDirIn.Replace("PLATEIN", "OVERVIEWIN"));
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ResetDataVeXe();
                EnabledAndDisableControl(true);
                TaoSoVaSoPhieuThu();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string _sotien = "0";
                string _billremark = "Thu tiền cho thẻ gửi xe mã: " + txtXe_MaTheXe.Text;
                string _thoigianxevao = "0001-01-01 00:00:00";
                if (txtXe_ThoiGianVao.Text != "")
                {
                    _thoigianxevao = txtXe_ThoiGianVao.Text;
                }
                if (txtSoTien.Text != "")
                {
                    _sotien = txtSoTien.Text.Replace(".", "");
                }
                string _sqlInsert = "INSERT INTO CP_matthexe(cardeventid, sothexe, mathexe, biensoxe, loaixe, tenchuxe, diachi, thoigianxevao, billgroupcode, billstt, sotien, billremark, createdate, createusercode, createusername, ghichu) VALUES ('" + txtXe_Cardeventid.Text + "', '" + txtXe_SoTheXe.Text + "', '" + txtXe_MaTheXe.Text + "', '" + txtXe_BienSoXe.Text + "', '" + cboXe_LoaiXe.Text + "', '" + txtXe_TenChuXe.Text + "', '" + txtXe_DiaChi.Text + "', '" + _thoigianxevao + "', '" + txtMaSo.Text + "', '" + txtSoPhieu.Text + "', '" + _sotien + "', '" + _billremark + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + Base.SessionLogin.SessionUsercode + "', '" + Base.SessionLogin.SessionUsername + "', '" + txtGhiChu.Text + "'); ";
                if (condb.ExecuteNonQuery(_sqlInsert))
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                    frmthongbao.Show();
                    EnabledAndDisableControl(false);
                    //ResetDataVeXe();
                    btnTimKiem.PerformClick();
                    btnIn.Enabled = true;
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THAT_BAI);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                EnabledAndDisableControl(false);
                ResetDataVeXe();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();

                reportExcelDTO item_billgroup = new reportExcelDTO();
                item_billgroup.name = "BILL_GROUP";
                item_billgroup.value = txtMaSo.Text;
                thongTinThem.Add(item_billgroup);

                reportExcelDTO item_billcode = new reportExcelDTO();
                item_billcode.name = "BILL_CODE";
                item_billcode.value = txtSoPhieu.Text;
                thongTinThem.Add(item_billcode);

                reportExcelDTO item_patientname = new reportExcelDTO();
                item_patientname.name = "PATIENTNAME";
                item_patientname.value = txtXe_TenChuXe.Text;
                thongTinThem.Add(item_patientname);

                reportExcelDTO item_patientcode = new reportExcelDTO();
                item_patientcode.name = "BIENSOXE";
                item_patientcode.value = txtXe_BienSoXe.Text;
                thongTinThem.Add(item_patientcode);

                reportExcelDTO item_diachi = new reportExcelDTO();
                item_diachi.name = "DIACHI";
                item_diachi.value = txtXe_DiaChi.Text;
                thongTinThem.Add(item_diachi);

                reportExcelDTO item_lydo = new reportExcelDTO();
                item_lydo.name = "BILL_REMARK";
                item_lydo.value = "Thu tiền cho thẻ gửi xe mã: " + txtXe_MaTheXe.Text;
                thongTinThem.Add(item_lydo);

                reportExcelDTO item_sotien = new reportExcelDTO();
                item_sotien.name = "SOTIEN";
                item_sotien.value = txtSoTien.Text;
                thongTinThem.Add(item_sotien);

                reportExcelDTO item_sotienchu = new reportExcelDTO();
                item_sotienchu.name = "SOTIENBANGCHU";
                item_sotienchu.value = Common.String.StringConvert.CurrencyToVneseString(txtSoTien.Text.Replace(".", ""));
                thongTinThem.Add(item_sotienchu);

                string fileTemplatePath = "BienLaiThuTien_NopTien_MatTheXe.xlsx";

                Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void repositoryItemButton_InPhieuThu_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();

                reportExcelDTO item_billgroup = new reportExcelDTO();
                item_billgroup.name = "BILL_GROUP";
                item_billgroup.value = gridViewDataBaoCao.GetRowCellValue(rowHandle, "billgroupcode").ToString();
                thongTinThem.Add(item_billgroup);

                reportExcelDTO item_billcode = new reportExcelDTO();
                item_billcode.name = "BILL_CODE";
                item_billcode.value = gridViewDataBaoCao.GetRowCellValue(rowHandle, "billstt").ToString();
                thongTinThem.Add(item_billcode);

                reportExcelDTO item_patientname = new reportExcelDTO();
                item_patientname.name = "PATIENTNAME";
                item_patientname.value = gridViewDataBaoCao.GetRowCellValue(rowHandle, "tenchuxe").ToString();
                thongTinThem.Add(item_patientname);

                reportExcelDTO item_patientcode = new reportExcelDTO();
                item_patientcode.name = "BIENSOXE";
                item_patientcode.value = gridViewDataBaoCao.GetRowCellValue(rowHandle, "biensoxe").ToString();
                thongTinThem.Add(item_patientcode);

                reportExcelDTO item_diachi = new reportExcelDTO();
                item_diachi.name = "DIACHI";
                item_diachi.value = gridViewDataBaoCao.GetRowCellValue(rowHandle, "diachi").ToString();
                thongTinThem.Add(item_diachi);

                reportExcelDTO item_lydo = new reportExcelDTO();
                item_lydo.name = "BILL_REMARK";
                item_lydo.value = gridViewDataBaoCao.GetRowCellValue(rowHandle, "billremark").ToString();
                thongTinThem.Add(item_lydo);

                reportExcelDTO item_sotien = new reportExcelDTO();
                item_sotien.name = "SOTIEN";
                item_sotien.value = gridViewDataBaoCao.GetRowCellValue(rowHandle, "sotien").ToString();
                thongTinThem.Add(item_sotien);

                reportExcelDTO item_sotienchu = new reportExcelDTO();
                item_sotienchu.name = "SOTIENBANGCHU";
                item_sotienchu.value = Common.String.StringConvert.CurrencyToVneseString(gridViewDataBaoCao.GetRowCellValue(rowHandle, "sotien").ToString().Replace(".", ""));
                thongTinThem.Add(item_sotienchu);

                string fileTemplatePath = "BienLaiThuTien_NopTien_MatTheXe.xlsx";
                Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem);
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
                MenuThongKe.frmXemAnhXeVaoRa frmAnh = new MenuThongKe.frmXemAnhXeVaoRa(_cardeventid);
                frmAnh.ShowDialog();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Custom
        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtSoTien_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal _sotien = Common.TypeConvert.TypeConvertParse.ToDecimal(txtSoTien.Text.Replace(".", ""));
                txtSoTien.Text = Common.Number.NumberConvert.NumberToString(_sotien, 0);
            }
            catch (Exception)
            {

                throw;
            }
        }






        #endregion

        #region Process
        private void EnabledAndDisableControl(bool _enable)
        {
            try
            {
                btnThem.Enabled = !_enable;
                btnLuu.Enabled = _enable;
                btnHuy.Enabled = _enable;
                btnIn.Enabled = false;
                btnTimTTXe.Enabled = _enable;
                txtXe_MaTheXe.ReadOnly = !_enable;
                txtXe_SoTheXe.ReadOnly = !_enable;
                cboXe_LoaiXe.Enabled = _enable;
                txtXe_BienSoXe.ReadOnly = !_enable;
                txtXe_TenChuXe.ReadOnly = !_enable;
                txtXe_DiaChi.ReadOnly = !_enable;
                txtSoTien.ReadOnly = !_enable;
                txtGhiChu.ReadOnly = !_enable;
                txtXe_ThoiGianVao.ReadOnly = !_enable;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void ResetDataVeXe()
        {
            try
            {
                txtXe_Cardeventid.Text = "";
                txtXe_MaTheXe.Text = "";
                txtXe_SoTheXe.Text = "";
                cboXe_LoaiXe.Text = "";
                txtXe_BienSoXe.Text = "";
                txtXe_TenChuXe.Text = "";
                txtXe_DiaChi.Text = "";
                txtSoTien.Text = "50000";
                txtGhiChu.Text = "";
                txtXe_ThoiGianVao.Text = "";
                pictureAnhXeVao_PLATEIN.Image = null;
                pictureAnhXeVao_OVERVIEWIN.Image = null;
                txtMaSo.Text = "";
                txtSoPhieu.Text = "";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void TaoSoVaSoPhieuThu()
        {
            try
            {
                //Tao ma so
                if (GlobalStore.lstOption != null && GlobalStore.lstOption.Count > 0)
                {
                    txtMaSo.Text = DateTime.Now.ToString("\\" + GlobalStore.lstOption.Where(o => o.optioncode == "sothutienmatthexe").FirstOrDefault().optionvalue);
                }
                else
                {
                    txtMaSo.Text = DateTime.Now.ToString("\\TTMTX.yyyy.MM.dd");
                }

                string _sqlSoThu = "SELECT COALESCE((max(billstt) + 1),1) as sophieuthu FROM CP_matthexe WHERE to_char(createdate,'yyyyMMdd')='" + DateTime.Now.ToString("yyyyMMdd") + "';";
                DataTable _dataSoThu = condb.GetDataTable(_sqlSoThu);
                if (_dataSoThu != null && _dataSoThu.Rows.Count > 0)
                {
                    txtSoPhieu.Text = _dataSoThu.Rows[0]["sophieuthu"].ToString();
                }
                else
                {
                    txtSoPhieu.Text = "1";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion

        #region In va xuat file
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

                string fileTemplatePath = "TOOL_09_CapNhatMatTheNgoaiTru.xlsx";
                DataTable dataExportFilter = Common.GridControl.GridControlConvert.ConvertGridControlToDataTable(gridViewDataBaoCao);
                Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, dataExportFilter);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
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

                    string fileTemplatePath = "TOOL_09_CapNhatMatTheNgoaiTru.xlsx";

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


        #endregion


    }
}
