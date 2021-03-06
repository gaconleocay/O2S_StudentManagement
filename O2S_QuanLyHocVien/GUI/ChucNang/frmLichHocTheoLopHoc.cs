﻿// Quản lý Học viên Trung tâm Anh ngữ
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
    public partial class frmLichHocTheoLopHoc : Form
    {
        #region Khai bao
        //private List<BangDiemFullDTO> lstBangDiem { get; set; }
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        #endregion

        public frmLichHocTheoLopHoc()
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
                cboKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
                cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                cboKhoaHoc.ValueMember = "KhoaHocId";
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
            SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));
            try
            {
                DataGridView_ResetLaiCot();
                if (cboKhoaHoc.SelectedValue != null)
                {
                    LopHocFilter _filter = new LopHocFilter();
                    _filter.KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                    List<LopHoc_PlusDTO> _lstLopHoc = LopHocLogic.Select(_filter);
                    if (_lstLopHoc != null && _lstLopHoc.Count > 0)
                    {
                        TaoCot_DataGridView(_lstLopHoc);
                        LayDuLieuLenGridView(_lstLopHoc);
                    }
                }
                else
                {
                    O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
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
                SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));

                //string tungay = DateTime.ParseExact(date_TuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                //string denngay = DateTime.ParseExact(date_DenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                //string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                //List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                //reportExcelDTO reportitem = new reportExcelDTO();
                //reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                //reportitem.value = tungaydenngay;
                //thongTinThem.Add(reportitem);

                //string fileTemplatePath = "hfghfghf.xlsx";
                //DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(this.lstBangDiem);
                //O2S_Common.Utilities.PrintPreview.ExcelFileTemplateShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _databaocao);
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
                Utilities.Excel.ExcelExport.ExportDataGridViewToFile(gridControlDataBC, bandedGridViewDataBC);
                
                //List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                //reportExcelDTO reportitem = new reportExcelDTO();
                //reportitem.name = Base.bienTrongBaoCao.TENKHOAHOC;
                //reportitem.value = cboKhoaHoc.Text;
                //thongTinThem.Add(reportitem);

                //string fileTemplatePath = "hghghg.xlsx";
                //DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(this.lstBangDiem);
                //Utilities.Common.Excel.ExcelExport export = new Utilities.Common.Excel.ExcelExport();
                //export.ExportExcelTemplate("", fileTemplatePath, thongTinThem, _databaocao);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
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
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn_ThoiGianHoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn clm_PhieuGhiDanh_Stt = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn_ThoiGianHoc_Full = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                //================
                this.bandedGridViewDataBC.Bands.Add(gridBand_tgian);

                this.bandedGridViewDataBC.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridColumn_XepLichHocId, gridColumn_ThoiGianHoc, clm_PhieuGhiDanh_Stt, gridColumn_ThoiGianHoc_Full });
                //=================
                // gridBand_tgian
                gridBand_tgian.Caption = "gridBand_tgian";
                gridBand_tgian.Columns.Add(gridColumn_XepLichHocId);
                gridBand_tgian.Columns.Add(clm_PhieuGhiDanh_Stt);
                gridBand_tgian.Columns.Add(gridColumn_ThoiGianHoc);
                gridBand_tgian.Columns.Add(gridColumn_ThoiGianHoc_Full);
                gridBand_tgian.Name = "gridBand_tgian";
                gridBand_tgian.OptionsBand.ShowCaption = false;
                gridBand_tgian.VisibleIndex = 0;
                gridBand_tgian.Width = 205;
                // gridColumn_XepLichHocId
                gridColumn_XepLichHocId.Caption = "XepLichHocId";
                gridColumn_XepLichHocId.FieldName = "XepLichHocId";
                gridColumn_XepLichHocId.Name = "gridColumn_XepLichHocId";
                // gridColumn_ThoiGianHoc
                gridColumn_ThoiGianHoc.Caption = "ThoiGianHoc";
                gridColumn_ThoiGianHoc.FieldName = "ThoiGianHoc";
                gridColumn_ThoiGianHoc.Name = "gridColumn_ThoiGianHoc";
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
                // gridColumn_tgian
                // 
                gridColumn_ThoiGianHoc_Full.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                gridColumn_ThoiGianHoc_Full.AppearanceCell.Options.UseFont = true;
                gridColumn_ThoiGianHoc_Full.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                gridColumn_ThoiGianHoc_Full.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                gridColumn_ThoiGianHoc_Full.AppearanceHeader.Options.UseFont = true;
                gridColumn_ThoiGianHoc_Full.AppearanceHeader.Options.UseForeColor = true;
                gridColumn_ThoiGianHoc_Full.AppearanceHeader.Options.UseTextOptions = true;
                gridColumn_ThoiGianHoc_Full.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridColumn_ThoiGianHoc_Full.Caption = "Thời gian";
                gridColumn_ThoiGianHoc_Full.FieldName = "ThoiGianHoc_Full";
                gridColumn_ThoiGianHoc_Full.Name = "gridColumn_tgian";
                gridColumn_ThoiGianHoc_Full.OptionsColumn.AllowEdit = false;
                gridColumn_ThoiGianHoc_Full.OptionsColumn.ReadOnly = true;
                gridColumn_ThoiGianHoc_Full.Visible = true;
                gridColumn_ThoiGianHoc_Full.Width = 160;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void TaoCot_DataGridView(List<LopHoc_PlusDTO> _lstLopHoc)
        {
            try
            {
                foreach (var item_lh in _lstLopHoc)
                {
                    DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandLop_0 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnLop_0_ca = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnLop_0_phong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnLop_0_gvchinh = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnLop_0_gvtrogiang = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                    //================
                    this.bandedGridViewDataBC.Bands.Add(gridBandLop_0);

                    this.bandedGridViewDataBC.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridColumnLop_0_ca, gridColumnLop_0_phong, gridColumnLop_0_gvchinh, gridColumnLop_0_gvtrogiang });
                    //=================
                    gridBandLop_0.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    gridBandLop_0.AppearanceHeader.Options.UseFont = true;
                    gridBandLop_0.AppearanceHeader.Options.UseTextOptions = true;
                    gridBandLop_0.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridBandLop_0.Caption = item_lh.TenLopHoc;
                    gridBandLop_0.Columns.Add(gridColumnLop_0_ca);
                    gridBandLop_0.Columns.Add(gridColumnLop_0_phong);
                    gridBandLop_0.Columns.Add(gridColumnLop_0_gvchinh);
                    gridBandLop_0.Columns.Add(gridColumnLop_0_gvtrogiang);
                    gridBandLop_0.Name = item_lh.LopHocId.ToString();
                    gridBandLop_0.VisibleIndex = 1;
                    gridBandLop_0.Width = 500;
                    // gridColumnLop_0_ca
                    gridColumnLop_0_ca.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumnLop_0_ca.AppearanceCell.Options.UseFont = true;
                    gridColumnLop_0_ca.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumnLop_0_ca.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                    gridColumnLop_0_ca.AppearanceHeader.Options.UseFont = true;
                    gridColumnLop_0_ca.AppearanceHeader.Options.UseForeColor = true;
                    gridColumnLop_0_ca.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumnLop_0_ca.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumnLop_0_ca.Caption = "Ca/tiết học";
                    gridColumnLop_0_ca.FieldName = "TenCaHocFull_" + item_lh.LopHocId.ToString();
                    gridColumnLop_0_ca.Name = "gridColumnLop_" + item_lh.LopHocId.ToString() + "_ca";
                    gridColumnLop_0_ca.OptionsColumn.AllowEdit = false;
                    gridColumnLop_0_ca.OptionsColumn.ReadOnly = true;
                    gridColumnLop_0_ca.Visible = true;
                    gridColumnLop_0_ca.Width = 150;
                    // gridColumnLop_0_phong
                    gridColumnLop_0_phong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumnLop_0_phong.AppearanceCell.Options.UseFont = true;
                    gridColumnLop_0_phong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumnLop_0_phong.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                    gridColumnLop_0_phong.AppearanceHeader.Options.UseFont = true;
                    gridColumnLop_0_phong.AppearanceHeader.Options.UseForeColor = true;
                    gridColumnLop_0_phong.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumnLop_0_phong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumnLop_0_phong.Caption = "Ca/tiết học";
                    gridColumnLop_0_phong.FieldName = "TenPhongHoc_" + item_lh.LopHocId.ToString();
                    gridColumnLop_0_phong.Name = "gridColumnPhong_" + item_lh.LopHocId.ToString() + "_ca";
                    gridColumnLop_0_phong.OptionsColumn.AllowEdit = false;
                    gridColumnLop_0_phong.OptionsColumn.ReadOnly = true;
                    gridColumnLop_0_phong.Visible = true;
                    gridColumnLop_0_phong.Width = 150;
                    // 
                    // gridColumnLop_0_gvchinh
                    // 
                    gridColumnLop_0_gvchinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumnLop_0_gvchinh.AppearanceCell.Options.UseFont = true;
                    gridColumnLop_0_gvchinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumnLop_0_gvchinh.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                    gridColumnLop_0_gvchinh.AppearanceHeader.Options.UseFont = true;
                    gridColumnLop_0_gvchinh.AppearanceHeader.Options.UseForeColor = true;
                    gridColumnLop_0_gvchinh.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumnLop_0_gvchinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumnLop_0_gvchinh.Caption = "Giáo viên dạy chính";
                    gridColumnLop_0_gvchinh.FieldName = "TenGiaoVien_Chinh_" + item_lh.LopHocId.ToString();
                    gridColumnLop_0_gvchinh.Name = "gridColumnLop_" + item_lh.LopHocId.ToString() + "_gvchinh";
                    gridColumnLop_0_gvchinh.OptionsColumn.AllowEdit = false;
                    gridColumnLop_0_gvchinh.OptionsColumn.ReadOnly = true;
                    gridColumnLop_0_gvchinh.Visible = true;
                    gridColumnLop_0_gvchinh.Width = 180;
                    // 
                    // gridColumnLop_0_gvtrogiang
                    // 
                    gridColumnLop_0_gvtrogiang.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumnLop_0_gvtrogiang.AppearanceCell.Options.UseFont = true;
                    gridColumnLop_0_gvtrogiang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
                    gridColumnLop_0_gvtrogiang.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                    gridColumnLop_0_gvtrogiang.AppearanceHeader.Options.UseFont = true;
                    gridColumnLop_0_gvtrogiang.AppearanceHeader.Options.UseForeColor = true;
                    gridColumnLop_0_gvtrogiang.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumnLop_0_gvtrogiang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumnLop_0_gvtrogiang.Caption = "Giáo viên trợ giảng";
                    gridColumnLop_0_gvtrogiang.FieldName = "TenGiaoVien_TroGiang_" + item_lh.LopHocId.ToString();
                    gridColumnLop_0_gvtrogiang.Name = "gridColumnLop_" + item_lh.LopHocId.ToString() + "_gvtrogiang";
                    gridColumnLop_0_gvtrogiang.OptionsColumn.AllowEdit = false;
                    gridColumnLop_0_gvtrogiang.OptionsColumn.ReadOnly = true;
                    gridColumnLop_0_gvtrogiang.Visible = true;
                    gridColumnLop_0_gvtrogiang.Width = 180;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LayDuLieuLenGridView(List<LopHoc_PlusDTO> _lstLopHoc)
        {
            try
            {
                string _sqlDSLopHoc = "";
                foreach (var item_lh in _lstLopHoc)
                {
                    _sqlDSLopHoc += @", STUFF((SELECT '; ' + (case when t2.LopHocId=" + item_lh.LopHocId + " then t2.TenCaHocFull end) from XEPLICHHOC t2 where t1.ThoiGianHoc = t2.ThoiGianHoc and t2.IsLock='True' order by t2.TenCaHocFull FOR XML PATH(''),TYPE).value('.','NVARCHAR(MAX)'),1,LEN('; '),'') as TenCaHocFull_" + item_lh.LopHocId + ", STUFF((SELECT '; ' + (case when t2.LopHocId=" + item_lh.LopHocId + " then t2.TenPhongHoc end) from XEPLICHHOC t2 where t1.ThoiGianHoc = t2.ThoiGianHoc and t2.IsLock='True' order by t2.TenCaHocFull FOR XML PATH(''),TYPE).value('.','NVARCHAR(MAX)'),1,LEN('; '),'') as TenPhongHoc_" + item_lh.LopHocId + ", STUFF((SELECT '; ' + (case when t2.LopHocId=" + item_lh.LopHocId + " then t2.TenGiaoVien_Chinh end) from XEPLICHHOC t2 where t1.ThoiGianHoc = t2.ThoiGianHoc and t2.IsLock='True' order by t2.TenCaHocFull FOR XML PATH(''),TYPE).value('.','NVARCHAR(MAX)'),1,LEN('; '),'') as TenGiaoVien_Chinh_" + item_lh.LopHocId + ", STUFF((SELECT '; ' + (case when t2.LopHocId=" + item_lh.LopHocId + " then t2.TenGiaoVien_TroGiang end) from XEPLICHHOC t2 where t1.ThoiGianHoc = t2.ThoiGianHoc and t2.IsLock='True' order by t2.TenCaHocFull FOR XML PATH(''),TYPE).value('.','NVARCHAR(MAX)'),1,LEN('; '),'') as TenGiaoVien_TroGiang_" + item_lh.LopHocId + "";
                }

                string _sqlSelect = @"SELECT row_number () over (order by t1.ThoiGianHoc) as stt, t1.ThoiGianHoc, t1.ThoiGianHoc_Full" + _sqlDSLopHoc + " FROM XEPLICHHOC t1 WHERE KhoaHocId='" + _lstLopHoc[0].KhoaHocId + "' and IsLock='True' GROUP BY ThoiGianHoc,ThoiGianHoc_Full;";
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

        private void gridViewDSHocVien_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                //if (e.Column == clm_PhieuGhiDanh_Stt)
                //{
                //    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                //}
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

    }
}
