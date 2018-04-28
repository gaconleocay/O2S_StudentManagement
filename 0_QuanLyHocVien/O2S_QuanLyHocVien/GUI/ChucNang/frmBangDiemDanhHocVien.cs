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
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.ChucNang
{
    public partial class frmBangDiemDanhHocVien : Form
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        #endregion

        public frmBangDiemDanhHocVien()
        {
            InitializeComponent();
        }

        #region Load
        private void frmBaoCaoHocVienTheoThang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadKhoaHoc();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadKhoaHoc()
        {
            try
            {
                KhoaHocFilter _filter = new KhoaHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.IsRemove = 0;
                List<KhoaHoc_PlusDTO> _lstKhoaHoc = KhoaHocLogic.Select(_filter);
                cboKhoaHoc.DataSource = _lstKhoaHoc;
                cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                cboKhoaHoc.ValueMember = "KhoaHocId";
                if (_lstKhoaHoc != null && _lstKhoaHoc.Count > 0)
                {
                    cboKhoaHoc.SelectedIndex = 0;
                    LoadLopCuaKhoaHoc();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadLopCuaKhoaHoc()
        {
            try
            {
                int _khoahocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                if (_khoahocId != 0)
                {
                    LopHocFilter _filter = new LopHocFilter();
                    _filter.CoSoId = GlobalSettings.CoSoId;
                    _filter.KhoaHocId = _khoahocId;
                    List<LopHoc_PlusDTO> _lstLopHoc = LopHocLogic.Select(_filter);
                    cboLopHoc.DataSource = _lstLopHoc;
                    cboLopHoc.DisplayMember = "TenLopHoc";
                    cboLopHoc.ValueMember = "LopHocId";
                    cboLopHoc.SelectedIndex = 0;
                }
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
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                DataGridView_ResetLaiCot();

                int _KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                int _LopHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());

                if (_KhoaHocId != 0 && _LopHocId != 0)
                {
                    XepLichHocFilter _filter = new XepLichHocFilter();
                    _filter.LopHocId = _LopHocId;
                    List<XepLichHoc_PlusDTO> _lstNgayHoc = XepLichHocLogic.SelectGroupTheoNgayHoc(_filter);
                    if (_lstNgayHoc != null && _lstNgayHoc.Count > 0)
                    {
                        foreach (var item in _lstNgayHoc)
                        {
                            item.ThoiGianHoc_Long = item.ThoiGianHoc.ToString("yyyyMMdd");
                        }
                        TaoCot_DataGridView(_lstNgayHoc);
                        LayDuLieuLenGridView(_lstNgayHoc, _LopHocId, _KhoaHocId);
                    }
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
                    frmthongbao.Show();
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
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));

                //string tungay = DateTime.ParseExact(date_TuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                //string denngay = DateTime.ParseExact(date_DenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                //string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                //List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                //reportExcelDTO reportitem = new reportExcelDTO();
                //reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                //reportitem.value = tungaydenngay;
                //thongTinThem.Add(reportitem);

                //string fileTemplatePath = "BC03_ThongKeTheoDoiDiem.xlsx";
                //DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(this.lstBangDiem);
                //Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _databaocao);
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
                Utilities.Common.Excel.ExcelExport export = new Utilities.Common.Excel.ExcelExport();
                export.ExportDataGridViewToFile(gridControlDataBC, bandedGridViewDataBC);

                //List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                //reportExcelDTO reportitem = new reportExcelDTO();
                //reportitem.name = Base.bienTrongBaoCao.TENKHOAHOC;
                //reportitem.value = cboKhoaHoc.Text;
                //thongTinThem.Add(reportitem);

                //string fileTemplatePath = "BC03_ThongKeTheoDoiDiem.xlsx";
                //DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(this.lstBangDiem);
                //Utilities.Common.Excel.ExcelExport export = new Utilities.Common.Excel.ExcelExport();
                //export.ExportExcelTemplate("", fileTemplatePath, thongTinThem, _databaocao);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLopCuaKhoaHoc();
        }
        #endregion

        #region Process
        private void DataGridView_ResetLaiCot()
        {
            try
            {
                //xoa tat ca cac cot
                this.bandedGridViewDataBC.Bands.Clear();
                this.bandedGridViewDataBC.Columns.Clear();

                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand_tgian = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn_XepLichHocId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn clm_PhieuGhiDanh_Stt = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn_MaHocVien = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn_TenHocVien = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                //================
                this.bandedGridViewDataBC.Bands.Add(gridBand_tgian);

                this.bandedGridViewDataBC.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridColumn_XepLichHocId, clm_PhieuGhiDanh_Stt, gridColumn_MaHocVien, gridColumn_TenHocVien });
                //=================
                // gridBand_tgian
                gridBand_tgian.Caption = "gridBand_STT";
                gridBand_tgian.Columns.Add(gridColumn_XepLichHocId);
                gridBand_tgian.Columns.Add(clm_PhieuGhiDanh_Stt);
                gridBand_tgian.Columns.Add(gridColumn_MaHocVien);
                gridBand_tgian.Columns.Add(gridColumn_TenHocVien);
                gridBand_tgian.Name = "gridBand_STT";
                gridBand_tgian.OptionsBand.ShowCaption = false;
                gridBand_tgian.VisibleIndex = 0;
                gridBand_tgian.Width = 215;

                // gridColumn_XepLichHocId
                gridColumn_XepLichHocId.Caption = "XepLichHocId";
                gridColumn_XepLichHocId.FieldName = "XepLichHocId";
                gridColumn_XepLichHocId.Name = "gridColumn_XepLichHocId";
                // clm_PhieuGhiDanh_Stt
                clm_PhieuGhiDanh_Stt.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                clm_PhieuGhiDanh_Stt.AppearanceCell.Options.UseFont = true;
                clm_PhieuGhiDanh_Stt.AppearanceCell.Options.UseTextOptions = true;
                clm_PhieuGhiDanh_Stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                clm_PhieuGhiDanh_Stt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                clm_PhieuGhiDanh_Stt.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                clm_PhieuGhiDanh_Stt.AppearanceHeader.Options.UseFont = true;
                clm_PhieuGhiDanh_Stt.AppearanceHeader.Options.UseForeColor = true;
                clm_PhieuGhiDanh_Stt.AppearanceHeader.Options.UseTextOptions = true;
                clm_PhieuGhiDanh_Stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                clm_PhieuGhiDanh_Stt.Caption = "STT";
                clm_PhieuGhiDanh_Stt.FieldName = "stt";
                clm_PhieuGhiDanh_Stt.Name = "clm_PhieuGhiDanh_Stt";
                clm_PhieuGhiDanh_Stt.OptionsColumn.AllowEdit = false;
                clm_PhieuGhiDanh_Stt.OptionsColumn.ReadOnly = true;
                clm_PhieuGhiDanh_Stt.Visible = true;
                clm_PhieuGhiDanh_Stt.Width = 45;
                // gridColumn_MaHocVien
                gridColumn_MaHocVien.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                gridColumn_MaHocVien.AppearanceCell.Options.UseFont = true;
                gridColumn_MaHocVien.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                gridColumn_MaHocVien.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                gridColumn_MaHocVien.AppearanceHeader.Options.UseFont = true;
                gridColumn_MaHocVien.AppearanceHeader.Options.UseForeColor = true;
                gridColumn_MaHocVien.AppearanceHeader.Options.UseTextOptions = true;
                gridColumn_MaHocVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridColumn_MaHocVien.Caption = "Mã học viên";
                gridColumn_MaHocVien.FieldName = "MaHocVien";
                gridColumn_MaHocVien.Name = "gridColumn_MaHocVien";
                gridColumn_MaHocVien.OptionsColumn.AllowEdit = false;
                gridColumn_MaHocVien.OptionsColumn.ReadOnly = true;
                gridColumn_MaHocVien.Visible = true;
                gridColumn_MaHocVien.Width = 100;
                // gridColumn_TenHocVien
                gridColumn_TenHocVien.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                gridColumn_TenHocVien.AppearanceCell.Options.UseFont = true;
                gridColumn_TenHocVien.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                gridColumn_TenHocVien.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                gridColumn_TenHocVien.AppearanceHeader.Options.UseFont = true;
                gridColumn_TenHocVien.AppearanceHeader.Options.UseForeColor = true;
                gridColumn_TenHocVien.AppearanceHeader.Options.UseTextOptions = true;
                gridColumn_TenHocVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridColumn_TenHocVien.Caption = "Tên học viên";
                gridColumn_TenHocVien.FieldName = "TenHocVien";
                gridColumn_TenHocVien.Name = "gridColumn_TenHocVien";
                gridColumn_TenHocVien.OptionsColumn.AllowEdit = false;
                gridColumn_TenHocVien.OptionsColumn.ReadOnly = true;
                gridColumn_TenHocVien.Visible = true;
                gridColumn_TenHocVien.Width = 220;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void TaoCot_DataGridView(List<XepLichHoc_PlusDTO> _lstLichHoc)
        {
            try
            {
                foreach (var item_lh in _lstLichHoc)
                {
                    DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandThoiGian = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn_Ca = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn_GhiChu = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    //================
                    this.bandedGridViewDataBC.Bands.Add(gridBandThoiGian);
                    this.bandedGridViewDataBC.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridColumn_Ca, gridColumn_GhiChu });
                    //=================
                    gridBandThoiGian.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    gridBandThoiGian.AppearanceHeader.Options.UseFont = true;
                    gridBandThoiGian.AppearanceHeader.Options.UseTextOptions = true;
                    gridBandThoiGian.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridBandThoiGian.Caption = item_lh.ThoiGianHoc_Full;
                    gridBandThoiGian.Columns.Add(gridColumn_Ca);
                    gridBandThoiGian.Columns.Add(gridColumn_GhiChu);
                    gridBandThoiGian.Name = item_lh.ThoiGianHoc_Long;
                    gridBandThoiGian.VisibleIndex = 1;
                    gridBandThoiGian.Width = 510;
                    // gridColumnLop_0_ca
                    gridColumn_Ca.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumn_Ca.AppearanceCell.Options.UseFont = true;
                    gridColumn_Ca.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumn_Ca.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                    gridColumn_Ca.AppearanceHeader.Options.UseFont = true;
                    gridColumn_Ca.AppearanceHeader.Options.UseForeColor = true;
                    gridColumn_Ca.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumn_Ca.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn_Ca.Caption = "Ca/tiết học";
                    gridColumn_Ca.FieldName = "TenCaHocFull_" + item_lh.ThoiGianHoc_Long;
                    gridColumn_Ca.Name = "gridColumnCaNgay_" + item_lh.ThoiGianHoc_Long;
                    gridColumn_Ca.OptionsColumn.AllowEdit = false;
                    gridColumn_Ca.OptionsColumn.ReadOnly = true;
                    gridColumn_Ca.Visible = true;
                    gridColumn_Ca.Width = 180;
                    // 
                    // gridColumnLop_0_gvchinh
                    // 
                    gridColumn_GhiChu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumn_GhiChu.AppearanceCell.Options.UseFont = true;
                    gridColumn_GhiChu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumn_GhiChu.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                    gridColumn_GhiChu.AppearanceHeader.Options.UseFont = true;
                    gridColumn_GhiChu.AppearanceHeader.Options.UseForeColor = true;
                    gridColumn_GhiChu.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumn_GhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn_GhiChu.Caption = "Ghi chú";
                    gridColumn_GhiChu.FieldName = "GhiChu_" + item_lh.ThoiGianHoc_Long;
                    gridColumn_GhiChu.Name = "gridColumnGhiChuNgay_" + item_lh.ThoiGianHoc_Long;
                    gridColumn_GhiChu.OptionsColumn.AllowEdit = false;
                    gridColumn_GhiChu.OptionsColumn.ReadOnly = true;
                    gridColumn_GhiChu.Visible = true;
                    gridColumn_GhiChu.Width = 180;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LayDuLieuLenGridView(List<XepLichHoc_PlusDTO> _lstNgayHoc, int _LopHocId, int _KhoaHocId)
        {
            try
            {
                string _sqlDSNgayHoc = "";
                foreach (var item_lh in _lstNgayHoc)
                {
                    _sqlDSNgayHoc += @", STUFF((SELECT '; ' + (case when FORMAT(t2.ThoiGianHoc,'yyyyMMdd')='"+item_lh.ThoiGianHoc_Long+ "' then t2.TenCaHocFull end) from XEPLICHHOC t2 inner join (select * from BANGDIEM where LopHocId=" + _LopHocId + ") bd1 on bd1.LopHocId=t2.LopHocId inner join HOCVIEN hv1 on hv1.HocVienId=bd1.HocVienId where hv1.MaHocVien = hv.MaHocVien and t2.LopHocId=" + _LopHocId + " and t2.IsLock='True' order by t2.TenCaHocFull FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,LEN('; '),'') as TenCaHocFull_" + item_lh.ThoiGianHoc_Long + ", '' as GhiChu_" + item_lh.ThoiGianHoc_Long + "";
                }

                string _sqlSelect = @"SELECT row_number () over (order by hv.TenHocVien) as stt, hv.MaHocVien, hv.TenHocVien "+ _sqlDSNgayHoc + " FROM (select * from XEPLICHHOC where LopHocId=" + _LopHocId + " and IsLock='True') xlh inner join (select * from BANGDIEM where LopHocId=" + _LopHocId + ") bd on bd.LopHocId=xlh.LopHocId  inner join HOCVIEN hv on hv.HocVienId=bd.HocVienId GROUP BY hv.MaHocVien, hv.TenHocVien; ";
                DataTable _dataBaoCao = condb.GetDataTable(_sqlSelect);
                gridControlDataBC.DataSource = _dataBaoCao;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
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
        #endregion


    }
}
