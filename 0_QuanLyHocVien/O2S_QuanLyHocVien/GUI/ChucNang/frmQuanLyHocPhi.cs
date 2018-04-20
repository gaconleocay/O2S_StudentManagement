// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyHocPhi.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.Reports;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraSplashScreen;
using O2S_QuanLyHocVien.BusinessLogic.Models;
using System.Data;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyHocPhi : Form
    {
        #region Khai bao
        private int HocVienId_Select { get; set; }
        private int PhieuGhiDanhId_Select { get; set; }
        private int PhieuThu_Insert = 0;
        #endregion
        public frmQuanLyHocPhi()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyHocPhi_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                LoadDanhSachHocVien();
                btnInBienLai.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachHocVien()
        {
            try
            {
                PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter();
                _filter.NgayGhiDanh_Tu = date_TuNgay.DateTime;
                _filter.NgayGhiDanh_Den = date_DenNgay.DateTime;
                List<QLHocPhi_PlusDTO> _lstQLHocPhi = PhieuGhiDanhLogic.SelectQLHocPhi(_filter);
                if (_lstQLHocPhi != null)
                {
                    gridControlDSHocVien.DataSource = _lstQLHocPhi;
                }
                else
                {
                    gridControlDSHocVien.DataSource = null;
                }
                gridControlPhieuThu.DataSource = null;
                lblMaHocVien.Text = String.Empty;
                lblTenHocVien.Text = String.Empty;
                lblHocPhi.Text = String.Empty;
                lblDaDong.Text = String.Empty;
                lblConNo.Text = String.Empty;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Events
        private void gridViewDSHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                this.HocVienId_Select = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());
                this.PhieuGhiDanhId_Select = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "PhieuGhiDanhId").ToString());
                lblMaHocVien.Text = gridViewDSHocVien.GetRowCellValue(rowHandle, "MaHocVien").ToString();
                lblTenHocVien.Text = gridViewDSHocVien.GetRowCellValue(rowHandle, "TenHocVien").ToString();
                lblHocPhi.Text = Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewDSHocVien.GetRowCellValue(rowHandle, "TongTien").ToString()), 0);
                lblDaDong.Text = Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewDSHocVien.GetRowCellValue(rowHandle, "DaDong").ToString()), 0);
                lblConNo.Text = Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewDSHocVien.GetRowCellValue(rowHandle, "ConNo").ToString()), 0);
                numNopThem.Text = "0";
                //Load danh sach phieu thu
                PhieuThuFilter _filter = new PhieuThuFilter();
                _filter.HocVienId = this.HocVienId_Select;
                _filter.PhieuGhiDanhId = this.PhieuGhiDanhId_Select;
                LoadDanhSachPhieuThu(_filter);
                btnInBienLai.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadDanhSachPhieuThu(PhieuThuFilter _filter)
        {
            try
            {
                gridControlPhieuThu.DataSource = PhieuThuLogic.Select(_filter);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachHocVien();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            try
            {
                //Update PHIEUGHIDANH
                PHIEUGHIDANH _phieughidanh = PhieuGhiDanhLogic.SelectSingle(this.PhieuGhiDanhId_Select);
                _phieughidanh.DaDong = _phieughidanh.DaDong + Common.TypeConvert.TypeConvertParse.ToDecimal(numNopThem.Text);
                _phieughidanh.ConNo = _phieughidanh.TongTien - _phieughidanh.DaDong;

                //Insert Phieu Thu
                var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                PHIEUTHU _phieuthu = new PHIEUTHU();
                _phieuthu.PhieuGhiDanhId = this.PhieuGhiDanhId_Select;
                _phieuthu.HocVienId = this.HocVienId_Select;
                _phieuthu.ThoiGianThu = DateTime.Now;
                _phieuthu.SoTien = Common.TypeConvert.TypeConvertParse.ToDecimal(numNopThem.Text);
                _phieuthu.GhiChu = gridViewDSHocVien.GetRowCellValue(rowHandle, "TenKhoaHoc").ToString();
                if (PhieuGhiDanhLogic.InsertQLHocPhi(_phieughidanh, _phieuthu, ref this.PhieuThu_Insert))
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.LUU_THANH_CONG);
                    frmthongbao.Show();
                    //LoadDanhSachHocVien();

                    PhieuThuFilter _filter = new PhieuThuFilter();
                    _filter.HocVienId = this.HocVienId_Select;
                    _filter.PhieuGhiDanhId = this.PhieuGhiDanhId_Select;
                    LoadDanhSachPhieuThu(_filter);

                    btnInBienLai.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PhieuThu_Insert != 0)
                {
                    PHIEUTHU _phieuthu = PhieuThuLogic.SelectSingle(this.PhieuThu_Insert);
                    InBienLaiThuTien(_phieuthu);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void repositoryItemButton_In_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewPhieuThu.FocusedRowHandle;
                int _PhieuThuId = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewPhieuThu.GetRowCellValue(rowHandle, "PhieuThuId").ToString());

                PHIEUTHU _phieuthu = PhieuThuLogic.SelectSingle(_PhieuThuId);
                InBienLaiThuTien(_phieuthu);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Cusstom
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
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void numNop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Process
        public void ValidateLuu()
        {
            if (Common.TypeConvert.TypeConvertParse.ToDecimal(numNopThem.Text) == 0)
                throw new ArgumentException("Số tiền nộp phải lớn hơn 0");
        }
        private void InBienLaiThuTien(PHIEUTHU _phieuthu)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));

                var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();

                reportExcelDTO item_MAHOCVIEN = new reportExcelDTO();
                item_MAHOCVIEN.name = "MAHOCVIEN";
                item_MAHOCVIEN.value = lblMaHocVien.Text;
                thongTinThem.Add(item_MAHOCVIEN);

                reportExcelDTO item_TENHOCVIEN = new reportExcelDTO();
                item_TENHOCVIEN.name = "TENHOCVIEN";
                item_TENHOCVIEN.value = lblTenHocVien.Text;
                thongTinThem.Add(item_TENHOCVIEN);

                reportExcelDTO item_DIACHI = new reportExcelDTO();
                item_DIACHI.name = "DIACHI";
                item_DIACHI.value = gridViewDSHocVien.GetRowCellValue(rowHandle, "DiaChi").ToString();
                thongTinThem.Add(item_DIACHI);

                reportExcelDTO item_KHOAHOC = new reportExcelDTO();
                item_KHOAHOC.name = "KHOAHOC";
                item_KHOAHOC.value = gridViewDSHocVien.GetRowCellValue(rowHandle, "TenKhoaHoc").ToString();
                thongTinThem.Add(item_KHOAHOC);

                reportExcelDTO item_NAMSINH = new reportExcelDTO();
                item_NAMSINH.name = "NAMSINH";
                item_NAMSINH.value = gridViewDSHocVien.GetRowCellValue(rowHandle, "NgaySinh").ToString();
                thongTinThem.Add(item_NAMSINH);

                reportExcelDTO item_LOPHOC = new reportExcelDTO();
                item_LOPHOC.name = "LOPHOC";
                item_LOPHOC.value = gridViewDSHocVien.GetRowCellValue(rowHandle, "TenLopHoc").ToString();
                thongTinThem.Add(item_LOPHOC);

                //reportExcelDTO item_sotienchu = new reportExcelDTO();
                //item_sotienchu.name = "SOTIENBANGCHU";
                //item_sotienchu.value = Common.String.StringConvert.CurrencyToVneseString(numNopThem.Text.Replace(".", ""));
                //thongTinThem.Add(item_sotienchu);

                DataTable dataExport = new DataTable();
                dataExport.Columns.Add("STT", typeof(string));
                dataExport.Columns.Add("KHOANTHU", typeof(string));
                dataExport.Columns.Add("SOTIEN", typeof(string));
                dataExport.Columns.Add("GHICHU", typeof(string));
                DataRow newRow = dataExport.NewRow();
                newRow["STT"] = "1";
                newRow["KHOANTHU"] = _phieuthu.PHIEUGHIDANH.KHOAHOC.TenKhoaHoc;
                //gridViewDSHocVien.GetRowCellValue(rowHandle, "TenKhoaHoc").ToString();
                newRow["SOTIEN"] = Common.Number.NumberConvert.NumberToString(_phieuthu.SoTien ?? 0, 0);
                //Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(numNopThem.Text), 0);
                newRow["GHICHU"] = _phieuthu.GhiChu;
                dataExport.Rows.Add(newRow);

                string fileTemplatePath = "BienLaiThuTien_NopTien.xlsx"; Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, dataExport);
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
