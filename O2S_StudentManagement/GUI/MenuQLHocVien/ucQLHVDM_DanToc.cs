﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Aspose.Cells;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    public partial class ucQLHVDM_DanToc : UserControl
    {
        private O2S_StudentManagement.DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        //private string worksheetName = "Sheet";
       // private List<Model.Models.DanhMucDichVu_DVKTDTO> lstDichVuImport { get; set; }
        public ucQLHVDM_DanToc()
        {
            InitializeComponent();
        }

        #region Load
        private void ucQLHVDM_DanToc_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhMucDichVu();
                EnableAndDisableControl();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhMucDichVu()
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                //gridControlDichVu.DataSource = null;
                //string sql_getdmdv = "SELECT danhmucdvktid, row_number () over (order by stt) as stt, ma_dvkt, ma_ax, ten_dvkt, ten_ax, ma_gia, don_gia, gia_ax, quyet_dinh, cong_bo, ma_cosokcb, manhom_9324, hieuluc, ketqua, lydotuchoi, is_look, lastuserupdated, lasttimeupdated, '0' as HIEULUC_ID, '0' as KETQUA_ID, '' as IS_LOOK_NAME FROM ie_danhmuc_dvkt;";
                //DataTable dataDMDV = condb.GetDataTable_HSBA(sql_getdmdv);
                //this.lstDichVuImport = new List<Model.Models.DanhMucDichVu_DVKTDTO>();
                //if (dataDMDV != null && dataDMDV.Rows.Count > 0)
                //{
                //    //this.lstDichVuImport = Common.DataTables.ConvertDataTable.DataTableToList<Model.Models.DanhMucDichVu_DVKTDTO>(dataDMDV);
                //    foreach (DataRow row in dataDMDV.Rows)
                //    {
                //        Model.Models.DanhMucDichVu_DVKTDTO dichVu = new Model.Models.DanhMucDichVu_DVKTDTO();
                //        dichVu.danhmucdvktid = Common.TypeConvert.TypeConvertParse.ToInt64(row["danhmucdvktid"].ToString());
                //        dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
                //        dichVu.MA_DVKT = row["MA_DVKT"].ToString();
                //        dichVu.MA_AX = row["MA_AX"].ToString();
                //        dichVu.TEN_DVKT = row["TEN_DVKT"].ToString();
                //        dichVu.TEN_AX = row["TEN_AX"].ToString();
                //        dichVu.MA_GIA = row["MA_GIA"].ToString();
                //        dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
                //        dichVu.GIA_AX = Common.TypeConvert.TypeConvertParse.ToDecimal(row["GIA_AX"].ToString());
                //        dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
                //        dichVu.CONG_BO = Common.TypeConvert.TypeConvertParse.ToInt64(row["CONG_BO"].ToString());
                //        dichVu.MA_COSOKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_COSOKCB"].ToString());
                //        dichVu.MANHOM_9324 = Common.TypeConvert.TypeConvertParse.ToInt64(row["MANHOM_9324"].ToString());
                //        dichVu.HIEULUC = row["HIEULUC"].ToString();
                //        dichVu.KETQUA = row["KETQUA"].ToString();
                //        dichVu.LYDOTUCHOI = row["LYDOTUCHOI"].ToString();

                //        if (dichVu.HIEULUC.ToLower() == "có")
                //        {
                //            dichVu.HIEULUC_ID = 1;
                //        }
                //        if (dichVu.KETQUA.ToLower() == "đã phê duyệt")
                //        {
                //            dichVu.KETQUA_ID = 1;
                //        }
                //        dichVu.LASTUSERUPDATED = row["LASTUSERUPDATED"].ToString();
                //        dichVu.LASTTIMEUPDATED = row["LASTTIMEUPDATED"];

                //        this.lstDichVuImport.Add(dichVu);
                //    }
                //}
                //gridControlDichVu.DataSource = this.lstDichVuImport;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void EnableAndDisableControl()
        {
            try
            {
                btnLuuLai.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        private void btnNhapTuExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                //{
                //    this.lstDichVuImport = new List<Model.Models.DanhMucDichVu_DVKTDTO>();
                //    gridControlDichVu.DataSource = null;
                //    //SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                //    Workbook workbook = new Workbook(openFileDialogSelect.FileName);
                //    Worksheet worksheet = workbook.Worksheets[0];
                //    DataTable data_Excel = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxDataRow + 1, worksheet.Cells.MaxDataColumn + 1, true);
                //    data_Excel.TableName = "DATA";
                //    if (data_Excel != null)
                //    {
                //        foreach (DataRow row in data_Excel.Rows)
                //        {
                //            Model.Models.DanhMucDichVu_DVKTDTO dichVu = new Model.Models.DanhMucDichVu_DVKTDTO();
                //            dichVu.STT = Common.TypeConvert.TypeConvertParse.ToInt64(row["STT"].ToString());
                //            dichVu.MA_DVKT = row["MA_DVKT"].ToString();
                //            dichVu.MA_AX = row["MA_AX"].ToString();
                //            dichVu.TEN_DVKT = row["TEN_DVKT"].ToString();
                //            dichVu.TEN_AX = row["TEN_AX"].ToString();
                //            dichVu.MA_GIA = row["MA_GIA"].ToString();
                //            dichVu.DON_GIA = Common.TypeConvert.TypeConvertParse.ToDecimal(row["DON_GIA"].ToString());
                //            dichVu.GIA_AX = Common.TypeConvert.TypeConvertParse.ToDecimal(row["GIA_AX"].ToString());
                //            dichVu.QUYET_DINH = row["QUYET_DINH"].ToString();
                //            dichVu.CONG_BO = Common.TypeConvert.TypeConvertParse.ToInt64(row["CONG_BO"].ToString());
                //            dichVu.MA_COSOKCB = Common.TypeConvert.TypeConvertParse.ToInt64(row["MA_COSOKCB"].ToString());
                //            dichVu.MANHOM_9324 = Common.TypeConvert.TypeConvertParse.ToInt64(row["MANHOM_9324"].ToString());
                //            dichVu.HIEULUC = row["HIEULUC"].ToString();
                //            dichVu.KETQUA = row["KETQUA"].ToString();
                //            dichVu.LYDOTUCHOI = row["LYDOTUCHOI"].ToString();

                //            if (dichVu.HIEULUC.ToLower() == "có")
                //            {
                //                dichVu.HIEULUC_ID = 1;
                //            }
                //            if (dichVu.KETQUA.ToLower() == "đã phê duyệt")
                //            {
                //                dichVu.KETQUA_ID = 1;
                //            }

                //            this.lstDichVuImport.Add(dichVu);
                //        }
                //        gridControlDichVu.DataSource = this.lstDichVuImport;
                //        btnLuuLai.Enabled = true;
                //    }
                //    else
                //    {
                //        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("File excel sai định dạng cấu trúc!");
                //        frmthongbao.Show();
                //        btnLuuLai.Enabled = false;
                //    }
                //}
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
                //SplashScreenManager.CloseForm();
            }
            //SplashScreenManager.CloseForm();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                //int insert_count = 0;
                //int _update_count = 0;
                //foreach (var item_dv in this.lstDichVuImport)
                //{
                //    try
                //    {
                //        string _sqlkiemtratrung = "SELECT MA_DVKT FROM ie_danhmuc_dvkt WHERE MA_DVKT='" + item_dv.MA_DVKT + "' and MA_AX='" + item_dv.MA_AX + "' and TEN_DVKT='" + item_dv.TEN_DVKT.Replace("'", "''") + "' and TEN_AX='" + item_dv.TEN_AX.Replace("'", "''") + "' and MA_GIA='" + item_dv.MA_GIA.ToString().Replace(",", ".") + "' and DON_GIA='" + item_dv.DON_GIA + "' and GIA_AX='" + item_dv.GIA_AX.ToString().Replace(",", ".") + "' and QUYET_DINH='" + item_dv.QUYET_DINH + "' and CONG_BO='" + item_dv.CONG_BO + "' and MA_COSOKCB='" + item_dv.MA_COSOKCB + "' and MANHOM_9324='" + item_dv.MANHOM_9324 + "'; ";
                //        DataTable _dataKiemTra = condb.GetDataTable_HSBA(_sqlkiemtratrung);
                //        if (_dataKiemTra != null && _dataKiemTra.Rows.Count > 0)
                //        {
                //            _update_count += _dataKiemTra.Rows.Count;
                //            //Xoa
                //            string _sql_delete = "DELETE FROM ie_danhmuc_dvkt WHERE MA_DVKT='" + item_dv.MA_DVKT + "' and MA_AX='" + item_dv.MA_AX + "' and TEN_DVKT='" + item_dv.TEN_DVKT.Replace("'", "''") + "' and TEN_AX='" + item_dv.TEN_AX.Replace("'", "''") + "' and MA_GIA='" + item_dv.MA_GIA.ToString().Replace(",", ".") + "' and DON_GIA='" + item_dv.DON_GIA + "' and GIA_AX='" + item_dv.GIA_AX.ToString().Replace(",", ".") + "' and QUYET_DINH='" + item_dv.QUYET_DINH + "' and CONG_BO='" + item_dv.CONG_BO + "' and MA_COSOKCB='" + item_dv.MA_COSOKCB + "' and MANHOM_9324='" + item_dv.MANHOM_9324 + "'; ";
                //            condb.ExecuteNonQuery_HSBA(_sql_delete);
                //        }

                //        string sql_insert = "INSERT INTO ie_danhmuc_dvkt(stt, ma_dvkt, ma_ax, ten_dvkt, ten_ax, ma_gia, don_gia, gia_ax, quyet_dinh, cong_bo, ma_cosokcb, manhom_9324, hieuluc_id, hieuluc, ketqua_id, ketqua, lydotuchoi, is_look, lastuserupdated, lasttimeupdated) VALUES ('" + item_dv.STT + "', '" + item_dv.MA_DVKT + "', '" + item_dv.MA_AX + "', '" + item_dv.TEN_DVKT.Replace("'", "''") + "', '" + item_dv.TEN_AX.Replace("'", "''") + "', '" + item_dv.MA_GIA + "', '" + item_dv.DON_GIA.ToString().Replace(",", ".") + "', '" + item_dv.GIA_AX.ToString().Replace(",", ".") + "', '" + item_dv.QUYET_DINH + "', '" + item_dv.CONG_BO + "', '" + item_dv.MA_COSOKCB + "', '" + item_dv.MANHOM_9324 + "', '" + item_dv.HIEULUC_ID + "', '" + item_dv.HIEULUC + "', '" + item_dv.KETQUA_ID + "', '" + item_dv.KETQUA + "', '" + item_dv.LYDOTUCHOI + "', '0', '" + Base.SessionLogin.SessionUsercode + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'); ";
                //        if (condb.ExecuteNonQuery_HSBA(sql_insert))
                //        {
                //            insert_count += 1;
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        Common.Logging.LogSystem.Error("Loi insert ie_danhmuc_dvkt " + ex.ToString());
                //        continue;
                //    }
                //}
                //MessageBox.Show("Thêm mới [" + (insert_count - _update_count) + "/" + this.lstDichVuImport.Count + "]; cập nhật [" + _update_count + "] dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //BUS.CallAPIServerYeuCauCapNhat.LayDuLieuTuCSDL("ie_danhmuc_dvkt");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
            ucQLHVDM_DanToc_Load(null, null);
        }

        #region Custom
        private void gridViewDichVu_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Delete Row
        private void gridViewDichVu_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (!btnLuuLai.Enabled)
                {
                    if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                    {
                        //GridView view = sender as GridView;
                        e.Menu.Items.Clear();
                        DXMenuItem itemKiemTraDaChon = new DXMenuItem("Xóa dịch vụ đã chọn"); // caption menu
                        itemKiemTraDaChon.Image = imageCollectionDSBN.Images[0]; // icon cho menu
                        itemKiemTraDaChon.Click += new EventHandler(XoaDichVuDaChon_Click);// thêm sự kiện click
                        e.Menu.Items.Add(itemKiemTraDaChon);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void XoaDichVuDaChon_Click(object sender, EventArgs e)
        {
            try
            {
                //if (gridViewDichVu.RowCount > 0)
                //{
                //    string sql_deleteDV = "";
                //    foreach (var item_index in gridViewDichVu.GetSelectedRows())
                //    {
                //        string danhmucdvktid = gridViewDichVu.GetRowCellValue(item_index, "danhmucdvktid").ToString();
                //        sql_deleteDV += "DELETE FROM ie_danhmuc_dvkt where danhmucdvktid='" + danhmucdvktid + "'; ";
                //    }
                //    condb.ExecuteNonQuery_HSBA(sql_deleteDV);
                //    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                //    frmthongbao.Show();
                //    ucQLHVDM_DanToc_Load(null, null);
                //}
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion



    }
}
