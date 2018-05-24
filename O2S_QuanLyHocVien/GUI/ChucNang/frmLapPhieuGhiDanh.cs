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
using O2S_Common.DataObjects;
using System.IO;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmLapPhieuGhiDanh : Form
    {
        #region Khai bao
        private Thread thHocVien;
        private int HocVienId_Select;
        private bool isSave = false;
        private int PhieuGhiDanhId = 0;
        private int PhieuThuId = 0;
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
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                KhoaHocFilter _filter = new KhoaHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                cboKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
                cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                cboKhoaHoc.ValueMember = "KhoaHocId";
                LoadPhieuGhiDanh();
                LoadKhoanKhacMacDinh();
                LoadDanhSachHocVien();
                LoadQuyDinh_LapPhieuGD();

                btnLuuPhieu.Enabled = false;
                btnInBienLai.Enabled = false;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        public void LoadPhieuGhiDanh()
        {
            PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            _filter.NgayGhiDanh_Tu = date_TuNgay.DateTime;
            _filter.NgayGhiDanh_Den = date_DenNgay.DateTime;
            List<PhieuGhiDanh_PlusDTO> _lstPhieuGhiDanh = PhieuGhiDanhLogic.Select(_filter);

            gridControlDSPhieuGhiDanh.DataSource = _lstPhieuGhiDanh;
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridViewDSPhieuGhiDanh.RowCount);
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
                O2S_Common.Logging.LogSystem.Warn(ex);
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
        private void LoadQuyDinh_LapPhieuGD()
        {
            try
            {
                if (GlobalSettings.lstQuyDinh["QD0002"] == "1")
                {
                    numSoBuoiHVDangKy.ReadOnly = false;
                }
                else
                {
                    numSoBuoiHVDangKy.ReadOnly = true;
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
            try
            {
                LoadDanhSachHocVien();
                LoadPhieuGhiDanh();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuuPhieu();
                KHOAHOC _khoahoc = KhoaHocLogic.SelectSingle(O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString()));
                //var rowHandle = gridViewKhoanKhac.FocusedRowHandle;
                //Insert bang PHIEUGHIDANH
                //insert bang PHIEUTHU; HOCPHIHOCVIEN
                //cap nhat bang HOCVIEN trang thai hoc vien = hoc vien chinh thuc + TAIKHOAN=chinh thuc
                PHIEUGHIDANH _phieughidanh = new PHIEUGHIDANH();
                _phieughidanh.HocVienId = this.HocVienId_Select;
                _phieughidanh.KhoaHocId = _khoahoc.KhoaHocId;
                _phieughidanh.NgayGhiDanh = DateTime.ParseExact(dateNgayGhiDanh.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                //
                _phieughidanh.HocPhiKH = _khoahoc.HocPhi;
                _phieughidanh.SoTietKH = _khoahoc.SoTietHoc;
                _phieughidanh.HocPhiHocVienKH = O2S_Common.TypeConvert.Parse.ToDecimal(lblThanhTienKhoaHoc.Text.Replace(",", ""));
                _phieughidanh.SoTietHocVienKH = O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHVDangKy.Text);
                _phieughidanh.ThuKhoanKhac = TinhTongTien_ThuThem();
                _phieughidanh.TongTien = O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text);
                _phieughidanh.DaDong = O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text.Replace(",", ""));
                _phieughidanh.ConNo = O2S_Common.TypeConvert.Parse.ToDecimal(numConNo.Text);
                _phieughidanh.MienGiam_PhanTram = O2S_Common.TypeConvert.Parse.ToInt16(numMienGiam_PTram.Value.ToString());
                _phieughidanh.MienGiam_Tien = O2S_Common.TypeConvert.Parse.ToDecimal(numMienGiam_Tien.Text.Replace(",", ""));
                _phieughidanh.LyDoMienGiam = txtLyDoMienGiam.Text;
                if (GlobalSettings.UserID != -1)
                {
                    _phieughidanh.NhanVienId = GlobalSettings.UserID;
                }

                //insert bang PHIEUTHU
                PHIEUTHU _phieuthu = new PHIEUTHU();
                List<HOCPHIHOCVIEN> _lsthphv = new List<HOCPHIHOCVIEN>();
                if (O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text.Replace(",", "")) > 0)
                {
                    //_phieuthuInsert.PhieuGhiDanhId = this.PhieuGhiDanhId;
                    _phieuthu.CoSoId = GlobalSettings.CoSoId;
                    _phieuthu.HocVienId = this.HocVienId_Select;
                    _phieuthu.ThoiGianThu = DateTime.Now;
                    _phieuthu.SoTien = O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text.Replace(",", ""));
                    _phieuthu.GhiChu = "";
                    //Tien Khoa Hoc
                    HOCPHIHOCVIEN _hphv_kh = new HOCPHIHOCVIEN()
                    {
                        Stt = 1,
                        HocVienId = this.HocVienId_Select,
                        DmDichVuId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString()),
                        TenDichVu = cboKhoaHoc.Text,
                        SoTien = O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text),
                        SoLuong = 1,
                        //PhieuThuId = _phieuthuId,
                        GhiChu = "",
                    };
                    _lsthphv.Add(_hphv_kh);

                    //tien khoan Khac
                    if (gridViewKhoanKhac.RowCount > 0)
                    {
                        int _stt_thuthem = 2;
                        for (int i = 0; i < gridViewKhoanKhac.RowCount; i++)
                        {
                            object _noidungkt = gridViewKhoanKhac.GetRowCellValue(i, "noidung");
                            if (_noidungkt != null)
                            {
                                HOCPHIHOCVIEN _hphv_khac = new HOCPHIHOCVIEN()
                                {
                                    Stt = _stt_thuthem,
                                    HocVienId = this.HocVienId_Select,
                                    DmDichVuId = 0,
                                    TenDichVu = gridViewKhoanKhac.GetRowCellValue(i, "noidung") == null ? "" : gridViewKhoanKhac.GetRowCellValue(i, "noidung").ToString(),
                                    SoTien = O2S_Common.TypeConvert.Parse.ToDecimal(gridViewKhoanKhac.GetRowCellValue(i, "sotien").ToString()),
                                    SoLuong = 1,
                                    //PhieuThuId = _phieuthuId,
                                    GhiChu = gridViewKhoanKhac.GetRowCellValue(i, "ghichu") == null ? "" : gridViewKhoanKhac.GetRowCellValue(i, "ghichu").ToString(),
                                };
                                _lsthphv.Add(_hphv_khac);
                                _stt_thuthem += 1;
                            }
                        }
                    }
                }

                if (PhieuGhiDanhLogic.InsertPGDFull(_phieughidanh, _phieuthu, _lsthphv, ref this.PhieuGhiDanhId, ref this.PhieuThuId))
                {
                    HOCVIEN _hv = HocVienLogic.SelectSingle(this.HocVienId_Select);
                    MessageBox.Show(string.Format("Học viên {0} đã được chuyển thành học viên chính thức với tài khoản:{1}Tên đăng nhập: {2}{3}Mật khẩu: {4}",
                 _hv.TenHocVien, Environment.NewLine, _hv.MaHocVien, Environment.NewLine, _hv.MaHocVien),
                 "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isSave = true;

                    btnLuuPhieu.Enabled = false;
                    LoadPhieuGhiDanh();

                    if (this.PhieuThuId != 0)
                    {
                        btnInBienLai.Enabled = true;
                        if (MessageBox.Show("Bạn có muốn in phiếu ghi danh vừa lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            InBienLaiThuTien_Process(this.PhieuThuId);
                        }
                    }
                }
                else
                {
                    O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THAT_BAI);
                    frmthongbao.Show();
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            InBienLaiThuTien_Process(this.PhieuThuId);
        }
        private void InBienLaiThuTien_Process(int _phieuthuId)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));

                HOCVIEN _hocvien = HocVienLogic.SelectSingle(this.HocVienId_Select);
                PHIEUTHU _phieuthu = PhieuThuLogic.SelectSingle(_phieuthuId);
                PHIEUGHIDANH _phieughidanh = PhieuGhiDanhLogic.SelectSingle(this.PhieuGhiDanhId);


                List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();

                reportExcelDTO item_MAPHIEUTHU = new reportExcelDTO();
                item_MAPHIEUTHU.name = "MAPHIEUTHU";
                item_MAPHIEUTHU.value = _phieuthu.MaPhieuThu;
                thongTinThem.Add(item_MAPHIEUTHU);

                reportExcelDTO item_MAHOCVIEN = new reportExcelDTO();
                item_MAHOCVIEN.name = "MAHOCVIEN";
                item_MAHOCVIEN.value = _hocvien.MaHocVien;
                thongTinThem.Add(item_MAHOCVIEN);

                reportExcelDTO item_TENHOCVIEN = new reportExcelDTO();
                item_TENHOCVIEN.name = "TENHOCVIEN";
                item_TENHOCVIEN.value = _hocvien.TenHocVien;
                thongTinThem.Add(item_TENHOCVIEN);

                reportExcelDTO item_DIACHI = new reportExcelDTO();
                item_DIACHI.name = "DIACHI";
                item_DIACHI.value = _hocvien.DiaChi;
                thongTinThem.Add(item_DIACHI);

                reportExcelDTO item_KHOAHOC = new reportExcelDTO();
                item_KHOAHOC.name = "KHOAHOC";
                item_KHOAHOC.value = _phieuthu.PHIEUGHIDANH.KHOAHOC.TenKhoaHoc;
                thongTinThem.Add(item_KHOAHOC);

                reportExcelDTO item_NAMSINH = new reportExcelDTO();
                item_NAMSINH.name = "NAMSINH";
                item_NAMSINH.value = _hocvien.NgaySinh != null ? (_hocvien.NgaySinh.Value.ToString("dd/MM/yyyy")) : "";
                thongTinThem.Add(item_NAMSINH);

                reportExcelDTO item_LOPHOC = new reportExcelDTO();
                item_LOPHOC.name = "LOPHOC";
                item_LOPHOC.value = "";
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
                item_sotienchu.value = O2S_Common.Strings.Convert.CurrencyToVneseString(_phieuthu.SoTien.ToString().Replace(".", ""));
                thongTinThem.Add(item_sotienchu);

                DataTable dataExport = new DataTable();
                dataExport.Columns.Add("STT", typeof(string));
                dataExport.Columns.Add("KHOANTHU", typeof(string));
                dataExport.Columns.Add("SOTIEN", typeof(string));
                dataExport.Columns.Add("GHICHU", typeof(string));
                //DataRow newRow = dataExport.NewRow();
                //newRow["STT"] = "1";
                //newRow["KHOANTHU"] = _phieuthu.PHIEUGHIDANH.KHOAHOC.TenKhoaHoc;
                //newRow["SOTIEN"] = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(_phieuthu.PHIEUGHIDANH.KHOAHOC.HocPhi.ToString()), 0);
                //newRow["GHICHU"] = "";
                //dataExport.Rows.Add(newRow);

                HocPhiHocVienFilter _filter = new HocPhiHocVienFilter()
                {
                    PhieuThuId = _phieuthuId,
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
        private void gridControlDSHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                ResetDefaultHocPhiHocVien();
                if (gridViewDSHocVien.RowCount > 0)
                {
                    isSave = false;
                    numDaDong.Text = "0";
                    var rowHandle = gridViewDSHocVien.FocusedRowHandle;
                    this.HocVienId_Select = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());
                    lblMaHocVien.Text = gridViewDSHocVien.GetRowCellValue(rowHandle, "MaHocVien").ToString();

                    lblTenHocVien.Text = gridViewDSHocVien.GetRowCellValue(rowHandle, "TenHocVien").ToString();
                    dateNgayGhiDanh.DateTime = DateTime.Now;

                    numTongTien.Text = numHocPhi.Text;
                    numDaDong.Text = "0";
                    numMienGiam_PTram.Value = 0;
                    numMienGiam_Tien.Text = "0";
                    btnLuuPhieu.Enabled = true;
                    btnInBienLai.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void repositoryItemButton_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewKhoanKhac.RowCount > 1)
                {
                    var rowHandle = gridViewKhoanKhac.FocusedRowHandle;
                    int _stt = O2S_Common.TypeConvert.Parse.ToInt32(gridViewKhoanKhac.GetRowCellValue(rowHandle, "stt").ToString());
                    PhieuThu_KhoanKhacDTO _delete = this.lstKhoanKhac.Where(o => o.stt == _stt).FirstOrDefault();
                    this.lstKhoanKhac.Remove(_delete);
                    gridControlKhoanKhac.DataSource = null;
                    gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void repositoryItemButton_XoaPGD_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewDSPhieuGhiDanh.RowCount > 0)
                {
                    var rowHandle = gridViewDSPhieuGhiDanh.FocusedRowHandle;
                    int _PhieuGhiDanhId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSPhieuGhiDanh.GetRowCellValue(rowHandle, "PhieuGhiDanhId").ToString());
                    //validate xoa:da xep lop thi khong the xoa duoc
                    ValidateXoaPhieuGhiDanh(_PhieuGhiDanhId);
                    frmPopUpXoaPhieuGhiDanh _frmXoa = new frmPopUpXoaPhieuGhiDanh(_PhieuGhiDanhId);
                    _frmXoa.ShowDialog();
                    LoadPhieuGhiDanh();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Process
        private void ValidateLuuPhieu()
        {
            var rowHandle = gridViewDSHocVien.FocusedRowHandle;

            PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter();
            _filter.HocVienId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewDSHocVien.GetRowCellValue(rowHandle, "HocVienId").ToString());

            var f = PhieuGhiDanhLogic.Select(_filter);

            foreach (var i in f)
            {
                if (i.ConNo > 0)
                    throw new Exception("Học viên đang nợ không được phép ghi danh mới");
            }
            if (O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text) < O2S_Common.TypeConvert.Parse.ToDecimal(GlobalSettings.lstQuyDinh["QD0001"]))
                throw new Exception(string.Format("Số tiền đóng khi ghi danh phải ít nhất bằng {0:C0}", GlobalSettings.lstQuyDinh["QD0001"]));
        }

        private void ValidateXoaPhieuGhiDanh(int _PhieuGhiDanhId)
        {
            List<BANGDIEM> _bangdiem = BangDiemLogic.SelectTheoPhieuGhiDanh(_PhieuGhiDanhId);
            if (_bangdiem != null && _bangdiem.Count > 0)
            {
                throw new ArgumentException("Học viên đã được xếp lớp nên không thể xóa được.");
            }
        }
        private void ResetDefaultHocPhiHocVien()
        {
            try
            {
                lblMaHocVien.Text = string.Empty;
                lblTenHocVien.Text = string.Empty;
                dateNgayGhiDanh.DateTime = DateTime.Now;
                numDaDong.Text = "0";
                numMienGiam_PTram.Value = 0;
                numMienGiam_Tien.Text = "0";
                txtLyDoMienGiam.Text = string.Empty;
                //
                numSoBuoiHVDangKy.Text = numSoTietHoc.Text;
                lblThanhTienKhoaHoc.Text = numHocPhi.Text;
                LoadKhoanKhacMacDinh();
                btnLuuPhieu.Enabled = false;
                btnInBienLai.Enabled = false;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private decimal TinhTongTien()
        {
            decimal _tongtien = 0;
            try
            {
                decimal _thanhtien = 0;
                if (O2S_Common.TypeConvert.Parse.ToDecimal(numSoTietHoc.Text) != 0)
                {
                    _thanhtien = O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text) * (O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHVDangKy.Text) / O2S_Common.TypeConvert.Parse.ToDecimal(numSoTietHoc.Text));
                }

                _tongtien += _thanhtien; //O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text);
                if (gridViewKhoanKhac.RowCount > 0)
                {
                    for (int i = 0; i < gridViewKhoanKhac.RowCount; i++)
                    {
                        _tongtien += O2S_Common.TypeConvert.Parse.ToDecimal(gridViewKhoanKhac.GetRowCellValue(i, "sotien").ToString());
                    }
                }
                numTongTien.Text = O2S_Common.Number.Convert.NumberToString(_tongtien, 0);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            return _tongtien;
        }
        private decimal TinhTongTien_ThuThem()
        {
            decimal _tongtien = 0;
            try
            {
                if (gridViewKhoanKhac.RowCount > 0)
                {
                    for (int i = 0; i < gridViewKhoanKhac.RowCount; i++)
                    {
                        object _noidungkt = gridViewKhoanKhac.GetRowCellValue(i, "noidung");
                        if (_noidungkt != null)
                        {
                            _tongtien += O2S_Common.TypeConvert.Parse.ToDecimal(gridViewKhoanKhac.GetRowCellValue(i, "sotien").ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            return _tongtien;
        }

        private string LuaChonTemplateInBienLai(List<HocPhiHocVien_PlusDTO> _lsthocPhiHV)
        {
            string result = "BienLaiThuTien_NopTien.xlsx";
            try
            {
                if (_lsthocPhiHV.Count > 1)
                {
                    result = "BienLaiThuTien_NopTien_" + _lsthocPhiHV.Count + ".xlsx";
                }
                //kiem tra ton tai template
                string fileTemplatePath = Environment.CurrentDirectory + "\\Templates\\" + result;
                if (!File.Exists(fileTemplatePath))//khong ton tai
                {
                    result = "BienLaiThuTien_NopTien.xlsx";
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }
        #endregion


        #region Custom
        private void cboKhoaHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                KHOAHOC _khoahoc = KhoaHocLogic.SelectSingle(O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString()));
                if (_khoahoc != null)
                {
                    numHocPhi.Text = O2S_Common.Number.Convert.NumberToString((_khoahoc.HocPhi ?? 0), 0);
                    numSoTietHoc.Text = O2S_Common.Number.Convert.NumberToString((_khoahoc.SoTietHoc ?? 0), 0);

                    numSoBuoiHVDangKy.Text = O2S_Common.Number.Convert.NumberToString((_khoahoc.SoTietHoc ?? 0), 0);
                    //
                    decimal _sotiethoc = O2S_Common.TypeConvert.Parse.ToDecimal(numSoTietHoc.Text);
                    if (_sotiethoc != 0)
                    {
                        decimal _thanhtien = O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text) * (O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHVDangKy.Text) / _sotiethoc);
                        lblThanhTienKhoaHoc.Text = O2S_Common.Number.Convert.NumberToString(_thanhtien, 0);
                    }
                    else
                    {
                        lblThanhTienKhoaHoc.Text = "0";
                    }
                }
                //numDaDong.Maximum = O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text);

                numTongTien.Text = O2S_Common.Number.Convert.NumberToString(TinhTongTien(), 0);

                numConNo.Text = O2S_Common.Number.Convert.NumberToString((O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text) - O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text.Replace(",", ""))), 0);

            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewKhoanKhac_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                numTongTien.Text = O2S_Common.Number.Convert.NumberToString(TinhTongTien(), 0);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void numTongTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numConNo.Text = O2S_Common.Number.Convert.NumberToString((O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text) - O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text.Replace(",", ""))), 0);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
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
                numConNo.Text = O2S_Common.Number.Convert.NumberToString((O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text) - O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text.Replace(",", "")) - O2S_Common.TypeConvert.Parse.ToDecimal(numMienGiam_Tien.Text.Replace(",", ""))), 0);
                numDaDong.Text = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text), 0);
                //numDaDong.Text = String.Format("{0:#,##0}", O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text));
                //O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text), 0);
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
                if (e.Column == clm_HocVien_Stt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void numMienGiam_Tien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numConNo.Text = O2S_Common.Number.Convert.NumberToString((O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text) - O2S_Common.TypeConvert.Parse.ToDecimal(numDaDong.Text.Replace(",", "")) - O2S_Common.TypeConvert.Parse.ToDecimal(numMienGiam_Tien.Text.Replace(",", ""))), 0);
                numMienGiam_Tien.Text = O2S_Common.Number.Convert.NumberToString(O2S_Common.TypeConvert.Parse.ToDecimal(numMienGiam_Tien.Text), 0);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void numMienGiam_PTram_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal _miengiam = O2S_Common.TypeConvert.Parse.ToDecimal(numTongTien.Text) * (numMienGiam_PTram.Value / 100);
                numMienGiam_Tien.Text = O2S_Common.Number.Convert.NumberToString(_miengiam, 0);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
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
                lblThanhTienKhoaHoc.Text = O2S_Common.Number.Convert.NumberToString(_thanhtien, 0);
                //tong tien
                numTongTien.Text = O2S_Common.Number.Convert.NumberToString(TinhTongTien(), 0);

            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

    }
}
