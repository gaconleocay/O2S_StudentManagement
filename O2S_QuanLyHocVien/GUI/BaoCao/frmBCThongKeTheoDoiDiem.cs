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
using O2S_Common.DataObjects;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmBCThongKeTheoDoiDiem : Form
    {
        private List<BangDiemFullDTO> lstBangDiem { get; set; }
        public frmBCThongKeTheoDoiDiem()
        {
            InitializeComponent();
        }

        #region Load
        private void frmBaoCaoHocVienTheoThang_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
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
        private void LoadLopCuaKhoaHoc()
        {
            try
            {
                LopHocFilter _filter = new LopHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                cboLopHoc.DataSource = LopHocLogic.Select(_filter);
                cboLopHoc.DisplayMember = "TenLopHoc";
                cboLopHoc.ValueMember = "LopHocId";
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
                if (cboLopHoc.SelectedValue != null)
                {
                    int _lophocid = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());
                    this.lstBangDiem = BangDiemLogic.SelectTheoDoiBangDiemLop(_lophocid);

                    if (this.lstBangDiem != null && this.lstBangDiem.Count > 0)
                    {
                        for (int i = 0; i < this.lstBangDiem.Count; i++)
                        {
                            this.lstBangDiem[i].Stt = i + 1;
                        }
                        gridControlDSPhieuGhiDanh.DataSource = this.lstBangDiem;
                    }
                    else
                    {
                        gridControlDSPhieuGhiDanh.DataSource = null;
                    }
                }
                else
                {
                    O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
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

                string tungay = DateTime.ParseExact(date_TuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                string denngay = DateTime.ParseExact(date_DenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                reportExcelDTO reportitem = new reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = tungaydenngay;
                thongTinThem.Add(reportitem);

                //khoa hoc, lop hoc
               int _KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                KHOAHOC _khoahoc = KhoaHocLogic.SelectSingle(_KhoaHocId);
                int _lophocId = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());
                LOPHOC _lophoc = LopHocLogic.SelectSingle(_lophocId);

                reportExcelDTO _item_makhoahoc = new reportExcelDTO()
                {
                    name = Base.bienTrongBaoCao.MAKHOAHOC,
                    value= _khoahoc.MaKhoaHoc,
                };
                thongTinThem.Add(_item_makhoahoc);
                reportExcelDTO _item_tenkhoahoc = new reportExcelDTO()
                {
                    name = Base.bienTrongBaoCao.TENKHOAHOC,
                    value = _khoahoc.TenKhoaHoc,
                };
                thongTinThem.Add(_item_tenkhoahoc);
                //
                reportExcelDTO _item_malophoc = new reportExcelDTO()
                {
                    name = Base.bienTrongBaoCao.MALOPHOC,
                    value = _lophoc.MaLopHoc,
                };
                thongTinThem.Add(_item_malophoc);
                reportExcelDTO _item_tenlophoc = new reportExcelDTO()
                {
                    name = Base.bienTrongBaoCao.TENLOPHOC,
                    value = _lophoc.TenLopHoc,
                };
                thongTinThem.Add(_item_tenlophoc);

                string fileTemplatePath = "BC03_ThongKeTheoDoiDiem.xlsx";
                DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(this.lstBangDiem);
                Utilities.Prints.PrintPreview.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _databaocao);
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
                string tungay = DateTime.ParseExact(date_TuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");
                string denngay = DateTime.ParseExact(date_DenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("HH:mm dd/MM/yyyy");

                string tungaydenngay = "( Từ " + tungay + " - " + denngay + " )";

                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                reportExcelDTO reportitem = new reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = tungaydenngay;
                thongTinThem.Add(reportitem);
                //khoa hoc, lop hoc
                int _KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                KHOAHOC _khoahoc = KhoaHocLogic.SelectSingle(_KhoaHocId);
                int _lophocId = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());
                LOPHOC _lophoc = LopHocLogic.SelectSingle(_lophocId);

                reportExcelDTO _item_makhoahoc = new reportExcelDTO()
                {
                    name = Base.bienTrongBaoCao.MAKHOAHOC,
                    value = _khoahoc.MaKhoaHoc,
                };
                thongTinThem.Add(_item_makhoahoc);
                reportExcelDTO _item_tenkhoahoc = new reportExcelDTO()
                {
                    name = Base.bienTrongBaoCao.TENKHOAHOC,
                    value = _khoahoc.TenKhoaHoc,
                };
                thongTinThem.Add(_item_tenkhoahoc);
                //
                reportExcelDTO _item_malophoc = new reportExcelDTO()
                {
                    name = Base.bienTrongBaoCao.MALOPHOC,
                    value = _lophoc.MaLopHoc,
                };
                thongTinThem.Add(_item_malophoc);
                reportExcelDTO _item_tenlophoc = new reportExcelDTO()
                {
                    name = Base.bienTrongBaoCao.TENLOPHOC,
                    value = _lophoc.TenLopHoc,
                };
                thongTinThem.Add(_item_tenlophoc);

                string fileTemplatePath = "BC03_ThongKeTheoDoiDiem.xlsx";
                DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(this.lstBangDiem);
                Utilities.Excel.ExcelExport.ExportExcelTemplate("", fileTemplatePath, thongTinThem, _databaocao);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
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

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLopCuaKhoaHoc();
        }

        #endregion

        private void gridControlDSPhieuGhiDanh_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            try
            {
                (e.View as GridView).ColumnPanelRowHeight = 25;
                (e.View as GridView).RowHeight = 25;
                (e.View as GridView).OptionsView.ShowIndicator = false;

                (e.View as GridView).Columns["BangDiemChiTietId"].Visible = false;
                (e.View as GridView).Columns["BangDiemId"].Visible = false;
                (e.View as GridView).Columns["MonHocId"].Visible = false;
                //        
                (e.View as GridView).Columns["MaMonHoc"].Width = 80;
                (e.View as GridView).Columns["TenMonHoc"].Width = 150;
                (e.View as GridView).Columns["Diem"].Width = 80;
                //                 
                (e.View as GridView).Columns["MaMonHoc"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["TenMonHoc"].OptionsColumn.AllowEdit = false;
                (e.View as GridView).Columns["Diem"].OptionsColumn.AllowEdit = false;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
