// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmLapPhieuGhiDanh.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Threading;
using O2S_QuanLyHocVien.Reports;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using DevExpress.XtraSplashScreen;
using O2S_QuanLyHocVien.BusinessLogic.Models;
using System.Data;
using O2S_QuanLyHocVien.PhieuGhiDanh;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmLapPhieuGhiDanh : Form
    {
        #region Khai bao
        private Thread thHocVien;
        private int HocVienId_Select;
        private bool isSave = false;
        private int PhieuGhiDanhId = 0;

        List<PhieuThu_KhoanKhacDTO> lstKhoanKhac { get; set; }

        #endregion

        public frmLapPhieuGhiDanh()
        {
            InitializeComponent();
        }

        #region Load
        private void frmLapPhieuGhiDanh_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                KhoaHocFilter _filter = new KhoaHocFilter();
                cboKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
                cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                cboKhoaHoc.ValueMember = "KhoaHocId";
                LoadPhieuGhiDanh();
                LoadKhoanKhacMacDinh();
                LoadDanhSachHocVien();
                btnInBienLai.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        public void LoadPhieuGhiDanh()
        {
            //thPhieuGhiDanh = new Thread(() =>
            //{
            object source = PhieuGhiDanhLogic.SelectTheoCoSo();

            //gridPhieuGhiDanh.Invoke((MethodInvoker)delegate
            // {
            gridControlDSPhieuGhiDanh.DataSource = source;
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridViewDSPhieuGhiDanh.RowCount);
            //});
            //});
            //thPhieuGhiDanh.Start();
        }
        private void LoadKhoanKhacMacDinh()
        {
            try
            {
                this.lstKhoanKhac = new List<PhieuThu_KhoanKhacDTO>();
                PhieuThu_KhoanKhacDTO _new = new PhieuThu_KhoanKhacDTO();
                _new.stt = 1;
                this.lstKhoanKhac.Add(_new);

                gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachHocVien()
        {
            thHocVien = new Thread(() =>
            {
                //thPhieuGhiDanh.Join();
                HocVienFilter _filter = new HocVienFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.NgayTiepNhan_Tu = date_TuNgay.DateTime;
                _filter.NgayTiepNhan_Den = date_DenNgay.DateTime;
                object source = HocVienLogic.Select(_filter);

                gridControlDSHocVien.Invoke((MethodInvoker)delegate
                {
                    gridControlDSHocVien.DataSource = source;
                });
            });
            thHocVien.Start();
        }
        #endregion

        #region Process
        public void ValidatePhieu()
        {
            var rowHandle = gridViewDSHocVien.FocusedRowHandle;

            PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter();
            _filter.HocVienId = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());

            var f = PhieuGhiDanhLogic.Select(_filter);

            foreach (var i in f)
            {
                if (i.ConNo > 0)
                    throw new Exception("Học viên đang nợ không được phép ghi danh mới");
            }
            if (Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text) < GlobalSettings.QuyDinh["QD0001"])
                throw new Exception(string.Format("Số tiền đóng khi ghi danh phải ít nhất bằng {0:C0}", GlobalSettings.QuyDinh["QD0001"]));
        }

        #endregion

        #region Events
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachHocVien();
                LoadPhieuGhiDanh();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatePhieu();
                //var rowHandle = gridViewKhoanKhac.FocusedRowHandle;
                //Insert bang PHIEUGHIDANH
                //insert bang PHIEUTHU; HOCPHIHOCVIEN
                //cap nhat bang HOCVIEN trang thai hoc vien = hoc vien chinh thuc + TAIKHOAN=chinh thuc
                PHIEUGHIDANH _phieughidanh = new PHIEUGHIDANH();
                _phieughidanh.HocVienId = this.HocVienId_Select;
                _phieughidanh.KhoaHocId = Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                _phieughidanh.NgayGhiDanh = DateTime.ParseExact(dateNgayGhiDanh.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                _phieughidanh.TongTien = Common.TypeConvert.TypeConvertParse.ToDecimal(numTongTien.Text);
                _phieughidanh.DaDong = Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text.Replace(",", ""));
                _phieughidanh.ConNo = Common.TypeConvert.TypeConvertParse.ToDecimal(numConNo.Text);
                _phieughidanh.MienGiam_PhanTram = Common.TypeConvert.TypeConvertParse.ToInt16(numMienGiam_PTram.Value.ToString());
                _phieughidanh.MienGiam_Tien = Common.TypeConvert.TypeConvertParse.ToDecimal(numMienGiam_Tien.Text.Replace(",", ""));
                if (GlobalSettings.UserID != -1)
                {
                    _phieughidanh.NhanVienId = GlobalSettings.UserID;
                }

                //insert bang PHIEUTHU
                PHIEUTHU _phieuthu = new PHIEUTHU();
                List<HOCPHIHOCVIEN> _lsthphv = new List<HOCPHIHOCVIEN>();
                if (Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text.Replace(",", "")) > 0)
                {
                    //_phieuthuInsert.PhieuGhiDanhId = this.PhieuGhiDanhId;
                    _phieuthu.HocVienId = this.HocVienId_Select;
                    _phieuthu.ThoiGianThu = DateTime.Now;
                    _phieuthu.SoTien = Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text.Replace(",", ""));
                    _phieuthu.GhiChu = "";
                    //Tien Khoa Hoc
                    HOCPHIHOCVIEN _hphv_kh = new HOCPHIHOCVIEN()
                    {
                        HocVienId = this.HocVienId_Select,
                        DmDichVuId = Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoaHoc.SelectedValue.ToString()),
                        TenDichVu = cboKhoaHoc.Text,
                        SoTien = Common.TypeConvert.TypeConvertParse.ToDecimal(numHocPhi.Text),
                        SoLuong = 1,
                        //PhieuThuId = _phieuthuId,
                        GhiChu = "",
                    };
                    _lsthphv.Add(_hphv_kh);

                    //tien khoan Khac
                    if (gridViewKhoanKhac.RowCount > 0)
                    {
                        for (int i = 0; i < gridViewKhoanKhac.RowCount; i++)
                        {
                            HOCPHIHOCVIEN _hphv_khac = new HOCPHIHOCVIEN()
                            {
                                HocVienId = this.HocVienId_Select,
                                DmDichVuId = 0,
                                TenDichVu = gridViewKhoanKhac.GetRowCellValue(i, "noidung") == null ? "" : gridViewKhoanKhac.GetRowCellValue(i, "noidung").ToString(),
                                SoTien = Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewKhoanKhac.GetRowCellValue(i, "sotien").ToString()),
                                SoLuong = 1,
                                //PhieuThuId = _phieuthuId,
                                GhiChu = gridViewKhoanKhac.GetRowCellValue(i, "ghichu") == null ? "" : gridViewKhoanKhac.GetRowCellValue(i, "ghichu").ToString(),
                            };
                            _lsthphv.Add(_hphv_khac);
                        }
                    }
                }

                if (PhieuGhiDanhLogic.InsertPGDFull(_phieughidanh, _phieuthu, _lsthphv, ref this.PhieuGhiDanhId))
                {
                    HOCVIEN _hv = HocVienLogic.SelectSingle(this.HocVienId_Select);
                    MessageBox.Show(string.Format("Học viên {0} đã được chuyển thành học viên chính thức với tài khoản:{1}Tên đăng nhập: {2}{3}Mật khẩu: {4}",
                 _hv.TenHocVien, Environment.NewLine, _hv.MaHocVien, Environment.NewLine, _hv.MaHocVien),
                 "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isSave = true;
                    btnInBienLai.Enabled = true;
                    LoadPhieuGhiDanh();
                    if (MessageBox.Show("Bạn có muốn in phiếu ghi danh vừa lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnInBienLai_Click(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));

                HOCVIEN _hocvien = HocVienLogic.SelectSingle(this.HocVienId_Select);

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
                item_DIACHI.value = _hocvien.DiaChi;
                thongTinThem.Add(item_DIACHI);

                reportExcelDTO item_KHOAHOC = new reportExcelDTO();
                item_KHOAHOC.name = "KHOAHOC";
                item_KHOAHOC.value = cboKhoaHoc.Text;
                thongTinThem.Add(item_KHOAHOC);

                reportExcelDTO item_NAMSINH = new reportExcelDTO();
                item_NAMSINH.name = "NAMSINH";
                item_NAMSINH.value = _hocvien.NgaySinh != null ? _hocvien.NgaySinh.ToString() : "";
                thongTinThem.Add(item_NAMSINH);

                reportExcelDTO item_LOPHOC = new reportExcelDTO();
                item_LOPHOC.name = "LOPHOC";
                item_LOPHOC.value = "";
                thongTinThem.Add(item_LOPHOC);

                reportExcelDTO item_sotienchu = new reportExcelDTO();
                item_sotienchu.name = "SOTIENBANGCHU";
                item_sotienchu.value = Common.String.StringConvert.CurrencyToVneseString(numDaDong.Text.Replace(".", ""));
                thongTinThem.Add(item_sotienchu);

                DataTable dataExport = new DataTable();
                dataExport.Columns.Add("STT", typeof(string));
                dataExport.Columns.Add("KHOANTHU", typeof(string));
                dataExport.Columns.Add("SOTIEN", typeof(string));
                dataExport.Columns.Add("GHICHU", typeof(string));
                DataRow newRow = dataExport.NewRow();
                newRow["STT"] = "1";
                newRow["KHOANTHU"] = cboKhoaHoc.Text;
                newRow["SOTIEN"] = Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(numHocPhi.Text), 0);
                newRow["GHICHU"] = "";
                dataExport.Rows.Add(newRow);

                if (gridViewKhoanKhac.RowCount > 0)
                {
                    for (int i = 0; i < gridViewKhoanKhac.RowCount; i++)
                    {
                        DataRow newRow_khac = dataExport.NewRow();
                        newRow_khac["STT"] = (i + 2).ToString();
                        newRow_khac["KHOANTHU"] = gridViewKhoanKhac.GetRowCellValue(i, "noidung") == null ? "" : gridViewKhoanKhac.GetRowCellValue(i, "noidung").ToString();
                        newRow_khac["SOTIEN"] = Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewKhoanKhac.GetRowCellValue(i, "sotien").ToString()), 0);
                        newRow_khac["GHICHU"] = gridViewKhoanKhac.GetRowCellValue(i, "ghichu") == null ? "" : gridViewKhoanKhac.GetRowCellValue(i, "ghichu").ToString();
                        dataExport.Rows.Add(newRow_khac);
                    }
                }

                string fileTemplatePath = "BienLaiThuTien_NopTien.xlsx"; Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, dataExport);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void gridControlDSHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDSHocVien.RowCount > 0)
                {
                    isSave = false;
                    numDaDong.Text = "0";
                    var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                    this.HocVienId_Select = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());
                    lblMaHocVien.Text = gridViewDSHocVien.GetRowCellValue(rowHandle, "MaHocVien").ToString();

                    lblTenHocVien.Text = gridViewDSHocVien.GetRowCellValue(rowHandle, "TenHocVien").ToString();
                    dateNgayGhiDanh.DateTime = DateTime.Now;
                    numDaDong.Text = "0";
                    numMienGiam_PTram.Value = 0;
                    numMienGiam_Tien.Text = "0";
                    btnInBienLai.Enabled = false;
                }
                else
                {
                    lblMaHocVien.Text = string.Empty;
                    lblTenHocVien.Text = string.Empty;
                    numDaDong.Text = "0";
                    numMienGiam_PTram.Value = 0;
                    numMienGiam_Tien.Text = "0";
                    btnInBienLai.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void repositoryItemButton_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewKhoanKhac.RowCount > 1)
                {
                    var rowHandle = gridViewKhoanKhac.FocusedRowHandle;
                    int _stt = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewKhoanKhac.GetRowCellValue(rowHandle, "stt").ToString());
                    PhieuThu_KhoanKhacDTO _delete = this.lstKhoanKhac.Where(o => o.stt == _stt).FirstOrDefault();
                    this.lstKhoanKhac.Remove(_delete);
                    gridControlKhoanKhac.DataSource = null;
                    gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
                    //if (this.lstKhoanKhac == null || this.lstKhoanKhac.Count == 0)
                    //{
                    //    PhieuThu_KhoanKhacDTO _new = new PhieuThu_KhoanKhacDTO();
                    //    _new.stt = 1;
                    //    gridControlKhoanKhac.DataSource = null;
                    //    gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
                    //}
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void repositoryItemButton_them_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                PhieuThu_KhoanKhacDTO _new = new PhieuThu_KhoanKhacDTO();
                _new.stt = this.lstKhoanKhac.Count + 1;
                this.lstKhoanKhac.Add(_new);
                gridControlKhoanKhac.DataSource = null;
                gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void repositoryItemButton_XoaPGD_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewDSPhieuGhiDanh.RowCount > 1)
                {
                    var rowHandle = gridViewDSPhieuGhiDanh.FocusedRowHandle;
                    int _PhieuGhiDanhId = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewDSPhieuGhiDanh.GetRowCellValue(rowHandle, "PhieuGhiDanhId").ToString());
                    frmPopUpXoaPhieuGhiDanh _frmXoa = new frmPopUpXoaPhieuGhiDanh(_PhieuGhiDanhId);
                    _frmXoa.ShowDialog();
                    LoadPhieuGhiDanh();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Custom
        private void cboKhoaHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                KHOAHOC _khoahoc = KhoaHocLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoaHoc.SelectedValue.ToString()));
                if (_khoahoc != null)
                {
                    numHocPhi.Text = Common.Number.NumberConvert.NumberToString((_khoahoc.HocPhi ?? 0), 0);
                }
                //numDaDong.Maximum = Common.TypeConvert.TypeConvertParse.ToDecimal(numHocPhi.Text);

                decimal _tongtien = 0;
                _tongtien += Common.TypeConvert.TypeConvertParse.ToDecimal(numHocPhi.Text);
                if (gridViewKhoanKhac.RowCount > 0)
                {
                    for (int i = 0; i < gridViewKhoanKhac.RowCount; i++)
                    {
                        _tongtien += Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewKhoanKhac.GetRowCellValue(i, "sotien").ToString());
                    }
                }
                numTongTien.Text = Common.Number.NumberConvert.NumberToString(_tongtien, 0);

                numConNo.Text = Common.Number.NumberConvert.NumberToString((Common.TypeConvert.TypeConvertParse.ToDecimal(numTongTien.Text) - Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text.Replace(",", ""))), 0);

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewDSHocVien_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                lblTongCongHV.Text = string.Format("Tổng cộng: {0} kết quả", gridViewDSHocVien.RowCount);

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewKhoanKhac_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                decimal _tongtien = 0;
                _tongtien += Common.TypeConvert.TypeConvertParse.ToDecimal(numHocPhi.Text);
                if (gridViewKhoanKhac.RowCount > 0)
                {
                    for (int i = 0; i < gridViewKhoanKhac.RowCount; i++)
                    {
                        _tongtien += Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewKhoanKhac.GetRowCellValue(i, "sotien").ToString());
                    }
                }
                numTongTien.Text = Common.Number.NumberConvert.NumberToString(_tongtien, 0);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

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
        private void numTongTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numConNo.Text = Common.Number.NumberConvert.NumberToString((Common.TypeConvert.TypeConvertParse.ToDecimal(numTongTien.Text) - Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text.Replace(",", ""))), 0);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void numDaDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numDaDong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numConNo.Text = Common.Number.NumberConvert.NumberToString((Common.TypeConvert.TypeConvertParse.ToDecimal(numTongTien.Text) - Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text.Replace(",", "")) - Common.TypeConvert.TypeConvertParse.ToDecimal(numMienGiam_Tien.Text.Replace(",", ""))), 0);
                numDaDong.Text = Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text), 0);
                //numDaDong.Text = String.Format("{0:#,##0}", Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text));
                //Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text), 0);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewDSHocVien_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clm_HocVien_Stt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void numMienGiam_Tien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numConNo.Text = Common.Number.NumberConvert.NumberToString((Common.TypeConvert.TypeConvertParse.ToDecimal(numTongTien.Text) - Common.TypeConvert.TypeConvertParse.ToDecimal(numDaDong.Text.Replace(",", "")) - Common.TypeConvert.TypeConvertParse.ToDecimal(numMienGiam_Tien.Text.Replace(",", ""))), 0);
                numMienGiam_Tien.Text = Common.Number.NumberConvert.NumberToString(Common.TypeConvert.TypeConvertParse.ToDecimal(numMienGiam_Tien.Text), 0);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void numMienGiam_PTram_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal _miengiam = Common.TypeConvert.TypeConvertParse.ToDecimal(numTongTien.Text) * (numMienGiam_PTram.Value / 100);
                numMienGiam_Tien.Text = Common.Number.NumberConvert.NumberToString(_miengiam, 0);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewDSPhieuGhiDanh_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clm_PhieuGhiDanh_Stt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion


    }
}
