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
    public partial class ucLichSuCapNhatNoiTru : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion

        public ucLichSuCapNhatNoiTru()
        {
            InitializeComponent();
        }

        #region Load
        private void ucLichSuCapNhatNoiTrucs_Load(object sender, EventArgs e)
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

        #region Tim Kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                string _tieuchi = "";
                string _loaibenhan = "";

                string tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                _tieuchi = " and createdate between '" + tungay + "' and '" + denngay + "' ";

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

                if (cboLoaiBenhAn.Text == "Nội trú")
                {
                    _loaibenhan = " and loaivienphiid=0 ";
                }

                string _sqlTimKiem = "SELECT row_number () over (order by bntx.createdate) as stt, bntx.benhnhanthexeid, bntx.patientid, bntx.patientcode, bntx.vienphiid, bntx.hosobenhanid, bntx.patientname, to_char(bntx.vienphidate,'HH24:MI dd/MM/yyyy') as vienphidate, (case when vienphi.vienphidate_ravien<>'0001-01-01 00:00:00' then to_char(vienphi.vienphidate_ravien,'HH24:MI dd/MM/yyyy') end) as vienphidate_ravien, bntx.bhytcode, bntx.gioitinhname, to_char(bntx.namsinh,'dd/MM/yyyy') as namsinh, bntx.diachi, (case when vienphi.vienphistatus=0 then 'Đang điều trị' else 'Đã ra viện' end) as vienphistatus_name, (case vienphi.loaivienphiid when 0 then 'Nội trú' when 1 then 'Ngoại trú' when 2 then 'Điều trị ngoại trú' end) as loaivienphi_name, vienphi.khoaphong, bntx.sothexe, bntx.cardeventid, bntx.mathexe, bntx.biensoxe, bntx.loaixe, (case when bntx.thoigianvao<>'0001-01-01 00:00:00' then to_char(bntx.thoigianvao,'HH24:MI dd/MM/yyyy') end) as thoigianvao, to_char(bntx.createdate,'HH24:MI dd/MM/yyyy') as createdate, (bntx.createusercode || ' - ' || bntx.createusername) as nguoicapnhat, bntx.ketthuc_status, (case when bntx.ketthuc_status=1 then 'Đã kết thúc' end) as ketthuc_status_name, (case when bntx.ketthuc_status=1 then to_char(bntx.ketthuc_date,'HH24:MI dd/MM/yyyy') end) as ketthuc_date, (case when bntx.ketthuc_status=1 then (bntx.ketthuc_usercode || ' - ' || bntx.ketthuc_username) end) as nguoiketthuc, (case when bntx.ismatthe=1 then 'Mất thẻ xe' end) as ismatthe FROM (select * from cp_benhnhanthexe where isremove=0 " + _tieuchi + _loaibenhan + " ) bntx left join dblink('myconn','select vp.vienphiid, vp.vienphidate_ravien, vp.vienphistatus, vp.loaivienphiid, (degp.departmentgroupname || '' - '' || de.departmentname) as khoaphong from (select vienphiid,vienphidate_ravien,vienphistatus,loaivienphiid,departmentgroupid,departmentid from vienphi where vienphidate>''2017-11-01 00:00:00'') vp left join (select departmentgroupid,departmentgroupname from departmentgroup) degp on degp.departmentgroupid=vp.departmentgroupid left join (select departmentid,departmentname from department where departmenttype in (2,3,6,7,9)) de on de.departmentid=vp.departmentid') AS vienphi(vienphiid integer,vienphidate_ravien timestamp without time zone,vienphistatus integer,loaivienphiid integer,khoaphong text) on vienphi.vienphiid=bntx.vienphiid;";
                DataTable _dataTimKiem = condb.GetDataTable_Dblink(_sqlTimKiem);
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
        private void gridViewDataBaoCao_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {

                var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                string _ketthuc_status = gridViewDataBaoCao.GetRowCellValue(rowHandle, "ketthuc_status").ToString();
                if (_ketthuc_status == "0")
                {
                    if (e.MenuType == GridMenuType.Row)
                    {
                        e.Menu.Items.Clear();
                        if (O2S_StudentManagement.Base.CheckPermission.ChkPerModule("THAOTAC_01"))
                        {
                            DXMenuItem itemXoaNguoiDung = new DXMenuItem("Sửa cập nhật nội trú");
                            itemXoaNguoiDung.Image = imMenu.Images[0];
                            itemXoaNguoiDung.Click += new EventHandler(SuaCapNhatNoiTru_Click);
                            e.Menu.Items.Add(itemXoaNguoiDung);
                        }
                        if (O2S_StudentManagement.Base.CheckPermission.ChkPerModule("THAOTAC_02"))
                        {
                            DXMenuItem item_matthe = new DXMenuItem("Cập nhật mất thẻ xe");
                            item_matthe.Image = imMenu.Images[2];
                            item_matthe.Click += new EventHandler(CapNhatMatTheXe_Click);
                            e.Menu.Items.Add(item_matthe);
                        }
                        if (O2S_StudentManagement.Base.CheckPermission.ChkPerModule("THAOTAC_03"))
                        {
                            DXMenuItem item_huycapnhat = new DXMenuItem("Hủy cập nhật nội trú");
                            item_huycapnhat.Image = imMenu.Images[1];
                            item_huycapnhat.Click += new EventHandler(HuyCapNhatNoiTru_Click);
                            e.Menu.Items.Add(item_huycapnhat);
                            item_huycapnhat.BeginGroup = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void SuaCapNhatNoiTru_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                string _benhnhanthexeid = gridViewDataBaoCao.GetRowCellValue(rowHandle, "benhnhanthexeid").ToString();
                frmChinhSuaCapNhatNoiTru frmcapnhat = new frmChinhSuaCapNhatNoiTru(_benhnhanthexeid);
                frmcapnhat.ShowDialog();
                btnTimKiem.PerformClick();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void CapNhatMatTheXe_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật mất thẻ xe và giữ lại tiền tạm ứng?", "Thông báo !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {

                    var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                    string _benhnhanthexeid = gridViewDataBaoCao.GetRowCellValue(rowHandle, "benhnhanthexeid").ToString();
                    //todo
                    string _sqlUpdateVaKetThuc = "UPDATE cp_benhnhanthexe SET ismatthe=1, matthedate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', updatedate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', updateusercode='" + Base.SessionLogin.SessionUsercode + "', updateusername='" + Base.SessionLogin.SessionUsername + "', ketthuc_status=1, ketthuc_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ketthuc_usercode='" + Base.SessionLogin.SessionUsercode + "', ketthuc_username='" + Base.SessionLogin.SessionUsername + "' WHERE benhnhanthexeid='" + _benhnhanthexeid + "';";

                    if (condb.ExecuteNonQuery_HSBA(_sqlUpdateVaKetThuc))
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                        frmthongbao.Show();
                        btnTimKiem.PerformClick();
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void HuyCapNhatNoiTru_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn hủy cập nhật nội trú?", "Thông báo !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {

                    var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                    string _benhnhanthexeid = gridViewDataBaoCao.GetRowCellValue(rowHandle, "benhnhanthexeid").ToString();

                    string _sqlUpdate = "UPDATE cp_benhnhanthexe SET isremove=1, updatedate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', updateusercode='" + Base.SessionLogin.SessionUsercode + "', updateusername='" + Base.SessionLogin.SessionUsername + "' WHERE benhnhanthexeid='" + _benhnhanthexeid + "';";
                    if (condb.ExecuteNonQuery_HSBA(_sqlUpdate))
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                        frmthongbao.Show();
                        btnTimKiem.PerformClick();
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void repositoryItemButton_XemAnh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                string _cardeventid = gridViewDataBaoCao.GetRowCellValue(rowHandle, "cardeventid").ToString();
                if (_cardeventid != null && _cardeventid != "")
                {
                    frmXemAnhXeVaoRa frmAnh = new frmXemAnhXeVaoRa(_cardeventid);
                    frmAnh.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewDataBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDataBaoCao.DataRowCount > 0)
                {
                    var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                    string _benhnhanthexeid = gridViewDataBaoCao.GetRowCellValue(rowHandle, "benhnhanthexeid").ToString();
                    string _sqlLayLog = "SELECT row_number () over (order by createdate) as stt, (createusercode || ' - ' || createusername) as nguoicapnhat, * FROM cp_updatenoitrulog WHERE benhnhanthexeid='" + _benhnhanthexeid + "';";
                    DataTable _dataLayLog = condb.GetDataTable(_sqlLayLog);
                    if (_dataLayLog != null && _dataLayLog.Rows.Count > 0)
                    {
                        gridControlLSUpdate.DataSource = _dataLayLog;
                    }
                    else
                    {
                        gridControlLSUpdate.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void repositoryItemButton_LSXemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewLSUpdate.FocusedRowHandle;
                string _cardeventid = gridViewLSUpdate.GetRowCellValue(rowHandle, "cardeventid").ToString();
                if (_cardeventid != null && _cardeventid != "")
                {
                    frmXemAnhXeVaoRa frmAnh = new frmXemAnhXeVaoRa(_cardeventid);
                    frmAnh.ShowDialog();
                }
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
                Common.Logging.LogSystem.Error(ex);
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
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void txtTK_MaBenhNhan_KeyDown(object sender, KeyEventArgs e)
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

                    string fileTemplatePath = "TOOL_07_LichSuCapNhatNoiTru.xlsx";

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

                string fileTemplatePath = "TOOL_07_LichSuCapNhatNoiTru.xlsx";
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
