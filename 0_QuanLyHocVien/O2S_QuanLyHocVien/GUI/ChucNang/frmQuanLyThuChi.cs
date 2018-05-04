// Quản lý giảng viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyThuChi.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using DevExpress.Utils.Menu;
using O2S_QuanLyHocVien.BusinessLogic.Models;
using System.Data;
using DevExpress.XtraSplashScreen;
using O2S_Common.DataObjects;

namespace O2S_QuanLyHocVien.ChucNang
{
    public partial class frmQuanLyThuChi : Form
    {
        #region Khai bao
        private int HoaDonThuChiId_Select { get; set; }
        private List<HoaDonThuChi_PlusDTO> lstHoaDonThuChi { get; set; }
        #endregion
        public frmQuanLyThuChi()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyThuChi_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddYears(-10).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");

                LockAndUnlockPanelControl(false);
                LoadLoaiChungTu();
                LoadDanhSachHoaDon();
                LoadDanhSachInAn();
                LoadDanhSachExport();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadLoaiChungTu()
        {
            try
            {
                //loaithuchi_timkiem
                List<LOAICHUNGTU> _lstloaichungtu = LoaiChungTuLogic.SelectAll();
                List<LOAICHUNGTU> _lstloaichungtu_TK = new List<LOAICHUNGTU>();
                LOAICHUNGTU _add_all = new LOAICHUNGTU()
                {
                    LoaiChungTuId = 0,
                    TenLoaiChungTu = "Tất cả",
                };
                _lstloaichungtu_TK.Add(_add_all);
                _lstloaichungtu_TK.AddRange(_lstloaichungtu);

                cboLoaiChungTu_TK.DataSource = _lstloaichungtu_TK;
                cboLoaiChungTu_TK.DisplayMember = "TenLoaiChungTu";
                cboLoaiChungTu_TK.ValueMember = "LoaiChungTuId";

                //
                cboLoaiChungTu.DataSource = _lstloaichungtu;
                cboLoaiChungTu.DisplayMember = "TenLoaiChungTu";
                cboLoaiChungTu.ValueMember = "LoaiChungTuId";
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachHoaDon()
        {
            try
            {
                HoaDonThuChiFilter _filter = new HoaDonThuChiFilter();
                _filter.LoaiChungTuId = O2S_Common.TypeConvert.Parse.ToInt32(cboLoaiChungTu_TK.SelectedValue.ToString());
                _filter.ThoiGianLap_Tu = date_TuNgay.DateTime;
                _filter.ThoiGianLap_Den = date_DenNgay.DateTime;
                this.lstHoaDonThuChi = HoaDonThuChiLogic.Select(_filter);
                if (this.lstHoaDonThuChi != null && this.lstHoaDonThuChi.Count > 0)
                {
                    decimal _tongthu = 0;
                    decimal _tongchi = 0;

                    for (int i = 0; i < this.lstHoaDonThuChi.Count; i++)
                    {
                        this.lstHoaDonThuChi[i].Stt = i + 1;
                        if (this.lstHoaDonThuChi[i].LoaiChungTuId == KeySetting.LOAICHUNGTU_PhieuThu)
                        {
                            _tongthu += this.lstHoaDonThuChi[i].SoTien ?? 0;
                        }
                        else
                        {
                            _tongchi += this.lstHoaDonThuChi[i].SoTien ?? 0;
                            this.lstHoaDonThuChi[i].SoTien = 0 - this.lstHoaDonThuChi[i].SoTien;
                        }
                    }

                    gridControlDSHoaDonThuChi.DataSource = this.lstHoaDonThuChi;

                    lblTongThu.Text = O2S_Common.Number.Convert.NumberToString(_tongthu, 0) + " đ";
                    lblTongChi.Text = O2S_Common.Number.Convert.NumberToString(_tongchi, 0) + " đ";
                    lblTonQuy.Text = O2S_Common.Number.Convert.NumberToString(_tongthu - _tongchi, 0) + " đ";
                }
                else
                {
                    gridControlDSHoaDonThuChi.DataSource = null;
                    lblTongThu.Text = "0 đ";
                    lblTongChi.Text = "0 đ";
                    lblTonQuy.Text = "0 đ";
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void LoadDanhSachInAn()
        {
            try
            {
                DXPopupMenu menu = new DXPopupMenu();
                menu.Items.Add(new DXMenuItem("Báo cáo thu chi chi tiết"));
                // menu.Items.Add(new DXMenuItem("Báo cáo thu chi tổng hợp theo ngày"));
                // ... add more items
                dropDownPrint.DropDownControl = menu;
                // subscribe item.Click event
                foreach (DXMenuItem item in menu.Items)
                    item.Click += Item_Print_Click;
                // setup initial selection
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachExport()
        {
            try
            {
                DXPopupMenu menu = new DXPopupMenu();
                menu.Items.Add(new DXMenuItem("Báo cáo thu chi chi tiết"));
                // menu.Items.Add(new DXMenuItem("Báo cáo thu chi tổng hợp theo ngày"));
                // ... add more items
                dropDownExport.DropDownControl = menu;
                // subscribe item.Click event
                foreach (DXMenuItem item in menu.Items)
                    item.Click += Item_Export_Click;
                // setup initial selection
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void LoadPanelControl(HOADONTHUCHI _hdthuchi = null)
        {
            try
            {
                if (_hdthuchi == null)
                {
                    ResetPanelControl();
                }
                else
                {
                    dateThoiGianLapPhieu.Value = _hdthuchi.ThoiGianLap != null ? (DateTime)_hdthuchi.ThoiGianLap : dateThoiGianLapPhieu.MaxDate;
                    cboLoaiChungTu.SelectedValue = _hdthuchi.LoaiChungTuId;
                    txtSoHoaDon.Text = _hdthuchi.SoHoaDon;
                    txtNguoiLap.Text = _hdthuchi.TenNguoiLap;
                    numSoTien.Text = O2S_Common.Number.Convert.NumberToString(_hdthuchi.SoTien ?? 0, 0);
                    txtNoiDung.Text = _hdthuchi.NoiDung;
                    txtGhiChu.Text = _hdthuchi.GhiChu;
                }
            }
            catch (Exception ex)
            {
                ResetPanelControl();
                LockAndUnlockPanelControl(false);
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }



        #endregion

        #region Process
        private void LockAndUnlockPanelControl(bool _result)
        {
            dateThoiGianLapPhieu.Enabled = _result;
            cboLoaiChungTu.Enabled = _result;
            txtSoHoaDon.ReadOnly = !_result;
            txtNguoiLap.ReadOnly = !_result;
            numSoTien.ReadOnly = !_result;
            txtNoiDung.ReadOnly = !_result;
            txtGhiChu.ReadOnly = !_result;

            btnLuuThongTin.Enabled = _result;
            btnHuyBo.Enabled = _result;
        }
        private void ResetPanelControl()
        {
            dateThoiGianLapPhieu.Value = DateTime.Now;
            cboLoaiChungTu.SelectedIndex = 0;
            txtSoHoaDon.Text = string.Empty;
            txtNguoiLap.Text = GlobalSettings.UserCode + " - " + GlobalSettings.UserName;
            numSoTien.Text = string.Empty;
            txtNoiDung.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }
        private HOADONTHUCHI LoadHoaDonThuChi()
        {
            HOADONTHUCHI _giangvien = new HOADONTHUCHI()
            {
                HoaDonThuChiId = this.HoaDonThuChiId_Select,
                SoHoaDon = txtSoHoaDon.Text,
                LoaiChungTuId = (int)cboLoaiChungTu.SelectedValue,
                ThoiGianLap = DateTime.ParseExact(dateThoiGianLapPhieu.Text, "HH:mm dd/MM/yyyy", CultureInfo.InvariantCulture),
                TenNguoiLap = txtNguoiLap.Text,
                SoTien = O2S_Common.TypeConvert.Parse.ToDecimal(numSoTien.Text),
                NoiDung = txtNoiDung.Text,
                GhiChu = txtGhiChu.Text,
            };
            return _giangvien;
        }
        private void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(cboLoaiChungTu.Text))
                throw new ArgumentException("Loại chứng từ không được trống");
            if (string.IsNullOrWhiteSpace(numSoTien.Text))
                throw new ArgumentException("Số tiền không được trống");
        }
        #endregion

        #region Events
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachHoaDon();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(true);
            //isInsert = true;
            LoadPanelControl();
            dateThoiGianLapPhieu.Focus();
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();

                if (HoaDonThuChiLogic.Insert(LoadHoaDonThuChi()))
                {
                    O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                    frmthongbao.Show();
                    LoadDanhSachHoaDon();
                    LockAndUnlockPanelControl(false);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridViewDSHoaDonThuChi_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDSHoaDonThuChi.FocusedRowHandle;
                this.HoaDonThuChiId_Select = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHoaDonThuChi.GetRowCellValue(rowHandle, "HoaDonThuChiId").ToString());
                HOADONTHUCHI _hdThuChi = HoaDonThuChiLogic.SelectSingle(this.HoaDonThuChiId_Select);
                LoadPanelControl(_hdThuChi);
                LockAndUnlockPanelControl(false);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(false);
            gridViewDSHoaDonThuChi_Click(sender, e);
        }

        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    LockAndUnlockPanelControl(true);
        //    //isInsert = false;
        //}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (HoaDonThuChiLogic.Delete(this.HoaDonThuChiId_Select))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadDanhSachHoaDon();
                        ResetPanelControl();
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridViewDSHoaDonThuChi_DoubleClick(object sender, EventArgs e)
        {
            //btnSua_Click(sender, e);
        }

        #endregion

        #region Custom
        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void gridViewDSHoaDonThuChi_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
        private void gridViewDSHoaDonThuChi_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                // hien thi mau do khi la Phieu Chi
                int _LoaiChungTuId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHoaDonThuChi.GetRowCellValue(e.RowHandle, "LoaiChungTuId").ToString());
                if (_LoaiChungTuId == KeySetting.LOAICHUNGTU_PhieuChi)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                //else
                //{
                //    e.Appearance.ForeColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }






        #endregion

        #region In An va Xuat Excel
        private void Item_Export_Click(object sender, EventArgs e)
        {
            try
            {
                string tenbaocao = ((DXMenuItem)sender).Caption;
                if (tenbaocao == "Báo cáo thu chi chi tiết")
                {
                    tbnExportBCThuChi_ChiTiet_Click();
                }
                else if (tenbaocao == "Báo cáo thu chi tổng hợp theo ngày")
                {
                    tbnExportBCThuChi_TongHopTheoNgay_Click();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void tbnExportBCThuChi_ChiTiet_Click()
        {
            try
            {
                string tungay = date_TuNgay.Text;
                string denngay = date_DenNgay.Text;

                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                reportExcelDTO reportitem = new reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = "( Từ " + tungay + " - " + denngay + " )";
                thongTinThem.Add(reportitem);

                reportExcelDTO item_loai = new reportExcelDTO()
                {
                    name = "LOAICHUNGTU",
                    value = cboLoaiChungTu_TK.Text,
                };
                thongTinThem.Add(item_loai);

                string fileTemplatePath = "BC_QuanLyThuChi_ChiTiet.xlsx";
                DataTable _dataBC = O2S_Common.DataTables.Convert.ListToDataTable(this.lstHoaDonThuChi);
                O2S_Common.Excel.ExcelExport.ExportExcelTemplate("", fileTemplatePath, thongTinThem, _dataBC);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void tbnExportBCThuChi_TongHopTheoNgay_Click()
        {
            try
            {
                string tungay = date_TuNgay.Text;
                string denngay = date_DenNgay.Text;

                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                reportExcelDTO reportitem = new reportExcelDTO();
                reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                reportitem.value = "( Từ " + tungay + " - " + denngay + " )";
                thongTinThem.Add(reportitem);

                reportExcelDTO item_loai = new reportExcelDTO()
                {
                    name = "LOAICHUNGTU",
                    value = cboLoaiChungTu_TK.Text,
                };
                thongTinThem.Add(item_loai);

                string fileTemplatePath = "BC_QuanLyThuChi_TongHop.xlsx";
                DataTable _dataBC = O2S_Common.DataTables.Convert.ListToDataTable(this.lstHoaDonThuChi);
                O2S_Common.Excel.ExcelExport.ExportExcelTemplate("", fileTemplatePath, thongTinThem, _dataBC);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }


        private void Item_Print_Click(object sender, EventArgs e)
        {
            try
            {
                string tenbaocao = ((DXMenuItem)sender).Caption;
                if (tenbaocao == "Báo cáo thu chi chi tiết")
                {
                    tbnPrintBCThuChi_ChiTiet_Click();
                }
                else if (tenbaocao == "Báo cáo thu chi tổng hợp theo ngày")
                {
                    tbnPrintBCThuChi_TongHopTheoNgay_Click();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void tbnPrintBCThuChi_ChiTiet_Click()
        {
            SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));
            try
            {
                try
                {
                    string tungay = date_TuNgay.Text;
                    string denngay = date_DenNgay.Text;

                    List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                    reportExcelDTO reportitem = new reportExcelDTO();
                    reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                    reportitem.value = "( Từ " + tungay + " - " + denngay + " )";
                    thongTinThem.Add(reportitem);

                    reportExcelDTO item_loai = new reportExcelDTO()
                    {
                        name = "LOAICHUNGTU",
                        value = cboLoaiChungTu_TK.Text,
                    };
                    thongTinThem.Add(item_loai);

                    string fileTemplatePath = "BC_QuanLyThuChi_ChiTiet.xlsx";
                    DataTable _dataBC = O2S_Common.DataTables.Convert.ListToDataTable(this.lstHoaDonThuChi);
                    O2S_Common.Utilities.PrintPreview.ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _dataBC);

                }
                catch (Exception ex)
                {
                    O2S_Common.Logging.LogSystem.Warn(ex);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void tbnPrintBCThuChi_TongHopTheoNgay_Click()
        {
            SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));
            try
            {
                try
                {
                    string tungay = date_TuNgay.Text;
                    string denngay = date_DenNgay.Text;

                    List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                    reportExcelDTO reportitem = new reportExcelDTO();
                    reportitem.name = Base.bienTrongBaoCao.THOIGIANBAOCAO;
                    reportitem.value = "( Từ " + tungay + " - " + denngay + " )";
                    thongTinThem.Add(reportitem);

                    reportExcelDTO item_loai = new reportExcelDTO()
                    {
                        name = "LOAICHUNGTU",
                        value = cboLoaiChungTu_TK.Text,
                    };
                    thongTinThem.Add(item_loai);

                    string fileTemplatePath = "BC_QuanLyThuChi_TongHop.xlsx";
                    DataTable _dataBC = O2S_Common.DataTables.Convert.ListToDataTable(this.lstHoaDonThuChi);
                    O2S_Common.Utilities.PrintPreview.ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _dataBC);

                }
                catch (Exception ex)
                {
                    O2S_Common.Logging.LogSystem.Warn(ex);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }


        #endregion



    }
}
