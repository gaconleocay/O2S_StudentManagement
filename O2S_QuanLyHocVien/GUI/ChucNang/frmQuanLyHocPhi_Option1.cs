// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyHocPhi_Option1.cs"
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
using O2S_QuanLyHocVien.Popups;
using System.Linq;
using O2S_Common.DataObjects;
using System.IO;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyHocPhi_Option1 : Form
    {
        #region Khai bao
        private int HocVienId_Select { get; set; }
        private int PhieuGhiDanhId_Select { get; set; }
        private int PhieuThu_Insert = 0;
        #endregion
        public frmQuanLyHocPhi_Option1()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyHocPhi_Option1_Load(object sender, EventArgs e)
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachHocVien()
        {
            SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));
            try
            {
                PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.NgayGhiDanh_Tu = date_TuNgay.DateTime;
                _filter.NgayGhiDanh_Den = date_DenNgay.DateTime;
                List<QLHocPhi_PlusDTO> _lstQLHocPhi = PhieuGhiDanhLogic.SelectQLHocPhiOption1(_filter);
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
                lblMienGiam_Tien.Text = string.Empty;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }
        #endregion

        #region Events
        private void gridViewDSHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                this.HocVienId_Select = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());
                this.PhieuGhiDanhId_Select = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "PhieuGhiDanhId").ToString());

                PHIEUGHIDANH _phieugd = PhieuGhiDanhLogic.SelectSingle(this.PhieuGhiDanhId_Select);

                lblMaHocVien.Text = _phieugd.HOCVIEN.MaHocVien;
                lblTenHocVien.Text = _phieugd.HOCVIEN.TenHocVien;
                lblHocPhi.Text = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(_phieugd.TongTien.ToString()), 0);
                lblDaDong.Text = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(_phieugd.DaDong.ToString()), 0);
                lblConNo.Text = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(_phieugd.ConNo.ToString()), 0);
                lblMienGiam_Tien.Text = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(_phieugd.MienGiam_Tien.ToString()), 0);
                numDaDong.Text = _phieugd.ConNo.ToString();
                //Load danh sach phieu thu
                PhieuThuFilter _filter = new PhieuThuFilter();
                _filter.HocVienId = this.HocVienId_Select;
                _filter.PhieuGhiDanhId = this.PhieuGhiDanhId_Select;
                LoadDanhSachPhieuThu(_filter);
                //Load dot hoc theo lop hoc
                if (_phieugd.LopHocId != null && _phieugd.LopHocId != 0)
                {
                    cboDotHoc.DataSource = DotHocLogic.SelectDotHocChucDongTien(_phieugd.LopHocId ?? 0, this.PhieuGhiDanhId_Select);
                    cboDotHoc.DisplayMember = "TenDotHoc";
                    cboDotHoc.ValueMember = "DotHocId";
                }
                else
                {
                    cboDotHoc.DataSource = null;
                    cboDotHoc.DisplayMember = "TenDotHoc";
                    cboDotHoc.ValueMember = "DotHocId";
                }
                btnInBienLai.Enabled = false;
                //if (_phieugd.ConNo == 0)
                //{
                //    btnLuuLai.Enabled = false;
                //    numDaDong.ReadOnly = true;
                //}
                //else
                //{
                //    btnLuuLai.Enabled = true;
                //    numDaDong.ReadOnly = false;
                //}
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
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
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                this.HocVienId_Select = 0;
                this.PhieuGhiDanhId_Select = 0;
                this.PhieuThu_Insert = 0;
                LoadDanhSachHocVien();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();
                //Update PHIEUGHIDANH: dadong
                PHIEUGHIDANH _phieughidanh = PhieuGhiDanhLogic.SelectSingle(this.PhieuGhiDanhId_Select);
                _phieughidanh.DaDong = _phieughidanh.DaDong + O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text);
                //
                _phieughidanh.SoTietKH = _phieughidanh.SoTietKH + O2S_Common.TypeConvert.Parse.ToDecimal(numSoTietHoc.Text);//so tiet tren dot hoc da chon
                _phieughidanh.HocPhiKH = _phieughidanh.HocPhiKH + O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text);
                _phieughidanh.HocPhiHocVienKH = _phieughidanh.HocPhiHocVienKH + O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text);
                _phieughidanh.SoTietHocVienKH = _phieughidanh.SoTietHocVienKH + O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHVDangKy.Text);

                decimal _mienggiam = _phieughidanh.MienGiam_Tien ?? 0;
                _phieughidanh.ConNo = _phieughidanh.TongTien - _phieughidanh.DaDong - _mienggiam;


                //Insert Phieu Thu
                var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                PHIEUTHU _phieuthu = new PHIEUTHU();
                _phieuthu.CoSoId = GlobalSettings.CoSoId;
                _phieuthu.PhieuGhiDanhId = this.PhieuGhiDanhId_Select;
                _phieuthu.HocVienId = this.HocVienId_Select;
                _phieuthu.ThoiGianThu = DateTime.Now;
                _phieuthu.SoTien = O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text);
                _phieuthu.NoiDung = cboDotHoc.Text;
                _phieuthu.GhiChu = "Thu tiền đợt học: " + cboDotHoc.Text;
                //Hoc phi hoc vien
                DOTHOC _dothoc = DotHocLogic.SelectSingle(O2S_Common.TypeConvert.Parse.ToInt32(cboDotHoc.SelectedValue.ToString()));

                decimal _donGia = _dothoc.HocPhi ?? 0;
                if (_dothoc.SoBuoiHoc != null && _dothoc.SoBuoiHoc != 0)
                {
                    _donGia = _dothoc.HocPhi / _dothoc.SoBuoiHoc ?? 1;
                }

                HOCPHIHOCVIEN _hocphiHV = new HOCPHIHOCVIEN()
                {
                    PhieuGhiDanhId = this.PhieuGhiDanhId_Select,
                    HocVienId = this.HocVienId_Select,
                    Stt = 1,
                    DmDichVuId = _dothoc.DotHocId,
                    TenDichVu = cboDotHoc.Text,
                    SoTien = O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text),
                    SoLuong = O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHVDangKy.Text),
                    DonGia = _donGia,
                    PhieuThuId = 0,
                    GhiChu = "",
                };
                if (PhieuGhiDanhLogic.InsertQLHocPhi_Option1(_phieughidanh, _phieuthu, _hocphiHV, ref this.PhieuThu_Insert))
                {
                    O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.LUU_THANH_CONG);
                    frmthongbao.Show();
                    //
                    LoadDanhSachHocVien();
                    gridViewDSHocVien_Click(null, null);

                    PhieuThuFilter _filter = new PhieuThuFilter();
                    _filter.HocVienId = this.HocVienId_Select;
                    _filter.PhieuGhiDanhId = this.PhieuGhiDanhId_Select;
                    LoadDanhSachPhieuThu(_filter);

                    btnInBienLai.Enabled = true;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
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
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void repositoryItemButton_In_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewPhieuThu.FocusedRowHandle;
                int _PhieuThuId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewPhieuThu.GetRowCellValue(rowHandle, "PhieuThuId").ToString());

                PHIEUTHU _phieuthu = PhieuThuLogic.SelectSingle(_PhieuThuId);
                InBienLaiThuTien(_phieuthu);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void repositoryItemButton_Huy_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewPhieuThu.FocusedRowHandle;
                if (gridViewPhieuThu.GetRowCellValue(rowHandle, "IsRemove").ToString() != "1")
                {
                    int _PhieuThuId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewPhieuThu.GetRowCellValue(rowHandle, "PhieuThuId").ToString());
                    frmPopUpHuyPhieuThuTien _frm = new frmPopUpHuyPhieuThuTien(_PhieuThuId);
                    _frm.ShowDialog();
                    //
                    LoadDanhSachHocVien();
                    gridViewDSHocVien_Click(null, null);

                    PhieuThuFilter _filter = new PhieuThuFilter();
                    _filter.HocVienId = this.HocVienId_Select;
                    _filter.PhieuGhiDanhId = this.PhieuGhiDanhId_Select;
                    LoadDanhSachPhieuThu(_filter);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void numNopThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void numDaDong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                numDaDong.Text = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text), 0);

                numConNo.Text = O2S_Common.Number.Convert.NumberToString((O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text) - O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text.Replace(",", ""))), 0);

            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewPhieuThu_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                // hien thi mau do khi benh an co loi
                if (gridViewPhieuThu.GetRowCellValue(e.RowHandle, "IsRemove").ToString() == "1")
                {
                    e.Appearance.ForeColor = Color.Gray;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void cboDotHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var _dothocselect = (DOTHOC)cboDotHoc.SelectedItem;
                DOTHOC _dothoc = DotHocLogic.SelectSingle(_dothocselect.DotHocId);
                if (_dothoc != null)
                {
                    numHocPhi.Text = O2S_Common.Number.Convert.NumberToString((_dothoc.HocPhi ?? 0), 0);
                    numSoTietHoc.Text = O2S_Common.Number.Convert.NumberToString((_dothoc.SoBuoiHoc ?? 0), 0);

                    numSoBuoiHVDangKy.Text = O2S_Common.Number.Convert.NumberToString((_dothoc.SoBuoiHoc ?? 0), 0);
                    //
                    //decimal _sotiethoc = O2S_Common.TypeConvert.Parse.ToDecimal(numSoTietHoc.Text);
                    if (_dothoc.SoBuoiHoc != 0)
                    {
                        decimal _thanhtien = _dothoc.HocPhi ?? 0 * (O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHVDangKy.Text) / _dothoc.SoBuoiHoc ?? 1);
                        numTongTien.Text = O2S_Common.Number.Convert.NumberToString(_thanhtien, 0);
                        numDaDong.Text = numTongTien.Text;
                        numConNo.Text = "0";
                    }
                    else
                    {
                        numTongTien.Text = "0";
                        numDaDong.Text = "0";
                        numConNo.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void numSoBuoiHVDangKy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //max value
                int _numSoTietHoc = O2S_Common.TypeConvert.Parse.ToInt32(numSoTietHoc.Text);
                int _numSoBuoiHVDangKy = O2S_Common.TypeConvert.Parse.ToInt32(numSoBuoiHVDangKy.Text);
                if (_numSoBuoiHVDangKy > _numSoTietHoc)
                {
                    numSoBuoiHVDangKy.Text = numSoTietHoc.Text;
                }

                decimal _thanhtien = 0;
                if (O2S_Common.TypeConvert.Parse.ToDecimal(numSoTietHoc.Text) != 0)
                {
                    _thanhtien = O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text) * (O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHVDangKy.Text) / O2S_Common.TypeConvert.Parse.ToDecimal(numSoTietHoc.Text));
                }
                numTongTien.Text = O2S_Common.Number.Convert.NumberToString(_thanhtien, 0);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void numTongTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numDaDong.Text = numTongTien.Text;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Process
        public void ValidateLuu()
        {
            if (O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text) == 0)
                throw new ArgumentException("Số tiền nộp phải lớn hơn 0");
        }
        private void InBienLaiThuTien(PHIEUTHU _phieuthu)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));

                PHIEUGHIDANH _phieughidanh = PhieuGhiDanhLogic.SelectSingle(_phieuthu.PhieuGhiDanhId ?? 0);


                var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();

                reportExcelDTO item_MAPHIEUTHU = new reportExcelDTO();
                item_MAPHIEUTHU.name = "MAPHIEUTHU";
                item_MAPHIEUTHU.value = _phieuthu.MaPhieuThu;
                thongTinThem.Add(item_MAPHIEUTHU);

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

                DateTime _namsinh = O2S_Common.TypeConvert.Parse.ToDateTime(gridViewDSHocVien.GetRowCellValue(rowHandle, "NgaySinh").ToString());
                reportExcelDTO item_NAMSINH = new reportExcelDTO();
                item_NAMSINH.name = "NAMSINH";
                item_NAMSINH.value = _namsinh.ToString("dd/MM/yyyy");
                thongTinThem.Add(item_NAMSINH);

                reportExcelDTO item_LOPHOC = new reportExcelDTO();
                item_LOPHOC.name = "LOPHOC";
                item_LOPHOC.value = gridViewDSHocVien.GetRowCellValue(rowHandle, "TenLopHoc").ToString();
                thongTinThem.Add(item_LOPHOC);
                //
                reportExcelDTO item_TONGTIEN = new reportExcelDTO()
                {
                    name = "TONGTIEN",
                    value = O2S_Common.Number.Convert.NumberToString(_phieughidanh.TongTien ?? 0, 0) + " đ",
                };
                thongTinThem.Add(item_TONGTIEN);

                reportExcelDTO item_MIENGIAM_TIEN = new reportExcelDTO()
                {
                    name = "MIENGIAM_TIEN",
                    value = O2S_Common.Number.Convert.NumberToString(_phieughidanh.MienGiam_Tien ?? 0, 0) + " đ",
                };
                thongTinThem.Add(item_MIENGIAM_TIEN);

                reportExcelDTO item_CONNO = new reportExcelDTO()
                {
                    name = "CONNO",
                    value = O2S_Common.Number.Convert.NumberToString(_phieughidanh.ConNo ?? 0, 0) + " đ",
                };
                thongTinThem.Add(item_CONNO);

                reportExcelDTO item_SOTIEN = new reportExcelDTO()
                {
                    name = "SOTIEN",
                    value = O2S_Common.Number.Convert.NumberToString(_phieuthu.SoTien ?? 0, 0) + " đ",
                };
                thongTinThem.Add(item_SOTIEN);

                reportExcelDTO item_sotienchu = new reportExcelDTO();
                item_sotienchu.name = "SOTIENBANGCHU";
                item_sotienchu.value = O2S_Common.Strings.Convert.CurrencyToVneseString(O2S_Common.Number.Convert.NumberToNumberRoundAuto(_phieuthu.SoTien ?? 0, 0).ToString());
                thongTinThem.Add(item_sotienchu);

                //
                DataTable dataExport = new DataTable();
                dataExport.Columns.Add("STT", typeof(string));
                dataExport.Columns.Add("KHOANTHU", typeof(string));
                dataExport.Columns.Add("SOTIEN", typeof(string));
                dataExport.Columns.Add("GHICHU", typeof(string));
                HocPhiHocVienFilter _filter = new HocPhiHocVienFilter()
                {
                    PhieuThuId = _phieuthu.PhieuThuId,
                    HocVienId = this.HocVienId_Select,
                };
                List<HocPhiHocVien_PlusDTO> _lsthocPhiHV = HocPhiHocVienLogic.Select(_filter);
                if (_lsthocPhiHV != null && _lsthocPhiHV.Count > 0)
                {
                    _lsthocPhiHV.OrderBy(o => o.Stt).ToList();
                    for (int i = 0; i < _lsthocPhiHV.Count; i++)
                    {
                        DataRow newRow_khac = dataExport.NewRow();
                        newRow_khac["STT"] = _lsthocPhiHV[i].Stt;
                        newRow_khac["KHOANTHU"] = _lsthocPhiHV[i].TenDichVu == null ? "" : _lsthocPhiHV[i].TenDichVu;
                        newRow_khac["SOTIEN"] = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(_lsthocPhiHV[i].SoTien.ToString()), 0);
                        newRow_khac["GHICHU"] = _lsthocPhiHV[i].GhiChu == null ? "" : _lsthocPhiHV[i].GhiChu;
                        dataExport.Rows.Add(newRow_khac);
                    }
                }

                string fileTemplatePath = LuaChonTemplateInBienLai(_lsthocPhiHV);

                Utilities.Prints.PrintPreview.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, dataExport);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        private string LuaChonTemplateInBienLai(List<HocPhiHocVien_PlusDTO> _lsthocPhiHV)
        {
            string result = "BienLaiThuTien_NopTien_ThuThem.xlsx";
            try
            {
                if (_lsthocPhiHV != null && _lsthocPhiHV.Count == 1)
                {
                    result = "BienLaiThuTien_NopTien.xlsx";
                }
                else if (_lsthocPhiHV != null && _lsthocPhiHV.Count > 1)
                {
                    result = "BienLaiThuTien_NopTien_" + _lsthocPhiHV.Count + ".xlsx";
                }
                //kiem tra ton tai template
                string fileTemplatePath = Environment.CurrentDirectory + "\\Templates\\" + result;
                if (!File.Exists(fileTemplatePath))//khong ton tai
                {
                    result = "BienLaiThuTien_NopTien_ThuThem.xlsx";
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }





        #endregion


    }
}
