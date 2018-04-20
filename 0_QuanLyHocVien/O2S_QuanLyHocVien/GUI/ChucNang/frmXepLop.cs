// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmXepLop.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;
using System.Threading;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Linq;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using O2S_QuanLyHocVien.BusinessLogic.Models;
using System.Data;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmXepLop : Form
    {
        #region Khai bao
        private List<XepLopDTO> dsChuaCoLop;
        private List<XepLopDTO> dsXepLopHocVien;

        #endregion
        public frmXepLop()
        {
            InitializeComponent();
        }

        #region Load
        private void frmXepLop_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDSHVChuaCoLop();
                LoadKhoaHoc();
                LoadLopTrongCuaKhoaHoc();
                LoadDSHVLopChuaDu();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        public void LoadDSHVChuaCoLop()
        {
            try
            {
                this.dsChuaCoLop = HocVienLogic.DanhSachHocVienChuaXepLop(GlobalSettings.CoSoId);
                gridControlHV_ChuaXepLop.DataSource = this.dsChuaCoLop;
                lblTongCongHV.Text = string.Format("Tổng cộng: {0} học viên", this.dsChuaCoLop.Count);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
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
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadLopTrongCuaKhoaHoc()
        {
            try
            {
                cboLopHoc.DataSource = LopHocLogic.DanhSachLopTrong(Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoaHoc.SelectedValue.ToString()));
                cboLopHoc.DisplayMember = "TenLopHoc";
                cboLopHoc.ValueMember = "LopHocId";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        public void LoadDSHVLopChuaDu()
        {
            try
            {
                if (cboLopHoc.SelectedValue != null)
                {
                    int _lophocId = Common.TypeConvert.TypeConvertParse.ToInt32(cboLopHoc.SelectedValue.ToString());
                    this.dsXepLopHocVien = BangDiemLogic.SelectDSHV_Lop(_lophocId);
                    gridControlHV_XepLop.DataSource = this.dsXepLopHocVien;
                }
                else
                {
                    gridControlHV_XepLop.DataSource = null;
                }
                lblTongCongHVLop.Text = string.Format("Tổng cộng: {0} học viên", gridViewHV_XepLop.RowCount);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Events
        private void btnLamMoiDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                frmXepLop_Load(null, null);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnThemVaoLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewHV_ChuaXepLop.RowCount > 0)
                {
                    if (gridViewHV_XepLop.RowCount < GlobalSettings.QuyDinh["QD0000"] ||
                    MessageBox.Show("Số học viên tối đa của lớp là " + GlobalSettings.QuyDinh["QD0000"] + Environment.NewLine + "Bạn có chắc sẽ thêm?",
                        "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var rowHandle = gridViewHV_ChuaXepLop.FocusedRowHandle;
                        int _phieughidanhId = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewHV_ChuaXepLop.GetRowCellValue(rowHandle, "PhieuGhiDanhId").ToString());
                        PHIEUGHIDANH _phieuGD = PhieuGhiDanhLogic.SelectSingle(_phieughidanhId);

                        XepLopDTO _hocvienLop = new XepLopDTO();
                        _hocvienLop.HocVienId = _phieuGD.HocVienId;
                        _hocvienLop.MaHocVien = _phieuGD.HOCVIEN.MaHocVien;
                        _hocvienLop.TenHocVien = _phieuGD.HOCVIEN.TenHocVien;
                        _hocvienLop.PhieuGhiDanhId = _phieuGD.PhieuGhiDanhId;
                        _hocvienLop.MaPhieuGhiDanh = _phieuGD.MaPhieuGhiDanh;
                        _hocvienLop.NgayGhiDanh = _phieuGD.NgayGhiDanh;
                        _hocvienLop.NgaySinh = _phieuGD.HOCVIEN.NgaySinh;
                        _hocvienLop.GioiTinh = _phieuGD.HOCVIEN.GioiTinh;
                        _hocvienLop.DiaChi = _phieuGD.HOCVIEN.DiaChi;
                        _hocvienLop.Sdt = _phieuGD.HOCVIEN.Sdt;
                        _hocvienLop.Email = _phieuGD.HOCVIEN.Email;
                        _hocvienLop.KhoaHocId = _phieuGD.KhoaHocId;
                        _hocvienLop.MaKhoaHoc = _phieuGD.KHOAHOC.MaKhoaHoc;
                        _hocvienLop.TenKhoaHoc = _phieuGD.KHOAHOC.TenKhoaHoc;

                        this.dsXepLopHocVien.Add(_hocvienLop);

                        XepLopDTO _xoa = this.dsChuaCoLop.Where(o => o.PhieuGhiDanhId == _hocvienLop.PhieuGhiDanhId && o.KhoaHocId == _hocvienLop.KhoaHocId).FirstOrDefault();
                        this.dsChuaCoLop.Remove(_xoa);

                        gridControlHV_ChuaXepLop.DataSource = null;
                        gridControlHV_ChuaXepLop.DataSource = this.dsChuaCoLop;
                        gridControlHV_XepLop.DataSource = null;
                        gridControlHV_XepLop.DataSource = this.dsXepLopHocVien;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnBoKhoiLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewHV_XepLop.RowCount > 0)
                {
                    var rowHandle = gridViewHV_XepLop.FocusedRowHandle;
                    int _phieughidanhId = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewHV_XepLop.GetRowCellValue(rowHandle, "PhieuGhiDanhId").ToString());

                    XepLopDTO _xeplopXoa = this.dsXepLopHocVien.Where(o => o.PhieuGhiDanhId == _phieughidanhId).FirstOrDefault();

                    this.dsXepLopHocVien.Remove(_xeplopXoa);
                    this.dsChuaCoLop.Add(_xeplopXoa);

                    gridControlHV_ChuaXepLop.DataSource = null;
                    gridControlHV_ChuaXepLop.DataSource = this.dsChuaCoLop;
                    gridControlHV_XepLop.DataSource = null;
                    gridControlHV_XepLop.DataSource = this.dsXepLopHocVien;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnLuuLop_Click(object sender, EventArgs e)
        {
            try
            {
                //insert + Xoa tai BANGDIEM 
                int _LopHocId = Common.TypeConvert.TypeConvertParse.ToInt32(cboLopHoc.SelectedValue.ToString());
                foreach (var item in this.dsXepLopHocVien)
                {
                    //kiem tra ton tai hay khong
                    List<BANGDIEM> _kiemtratontai = BangDiemLogic.SelectTheoPhieuGhiDanh(item.PhieuGhiDanhId ?? 0);
                    if (_kiemtratontai == null || _kiemtratontai.Count == 0)
                    {
                        BANGDIEM _bangdiem = new BANGDIEM();
                        _bangdiem.HocVienId = item.HocVienId ?? 0;
                        _bangdiem.LopHocId = _LopHocId;
                        _bangdiem.PhieuGhiDanhId = item.PhieuGhiDanhId ?? 0;
                        _bangdiem.KhoaHocId = item.KhoaHocId ?? 0;
                        _bangdiem.TrangThai = 0;//=0: xep lop; =1: dang hoc; =3: co diem; =99:ket thuc
                        BangDiemLogic.Insert(_bangdiem);
                    }
                }

                List<BANGDIEM> _lstBangDiem_LopHoc = BangDiemLogic.SelectTheoLopHoc(_LopHocId);
                if (_lstBangDiem_LopHoc != null && _lstBangDiem_LopHoc.Count > 0)
                {
                    List<BANGDIEM> _bangdiem_Xoa = (from p in _lstBangDiem_LopHoc
                                                    where !(from q in this.dsXepLopHocVien select q.PhieuGhiDanhId).Contains(p.PhieuGhiDanhId)
                                                    select p).ToList();
                    if (_bangdiem_Xoa != null && _bangdiem_Xoa.Count > 0)
                    {
                        BangDiemLogic.DeleteList(_bangdiem_Xoa);
                    }
                }

                //Update  SiSo cua LOPHOC
                LOPHOC _lophoc = LopHocLogic.SelectSingle(_LopHocId);
                LopHocLogic.Update(new LOPHOC()
                {
                    LopHocId = _lophoc.LopHocId,
                    TenLopHoc = _lophoc.TenLopHoc,
                    NgayBatDau = _lophoc.NgayBatDau,
                    NgayKetThuc = _lophoc.NgayKetThuc,
                    SiSo = this.dsXepLopHocVien.Count,
                    KhoaHocId = _lophoc.KhoaHocId,
                    DangMo = _lophoc.DangMo
                });

                Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                frmthongbao.Show();
            }
            catch (Exception ex)
            {
                Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                frmthongbao.Show();
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion

        #region Custom
        private void cboLop_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDSHVLopChuaDu();
        }
        private void cboKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadLopTrongCuaKhoaHoc();
        }
        private void gridViewHV_ChuaXepLop_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
        private void gridViewHV_ChuaXepLop_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clm_chuaxep_stt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewHV_XepLop_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //try
            //{
            //    if (e.Column == clm_xeplopstt)
            //    {
            //        e.DisplayText = Convert.ToString(e.RowHandle + 1);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Common.Logging.LogSystem.Warn(ex);
            //}
        }


        #endregion

        #region In An
        private void btnInAn_DSLop_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
                if (cboLopHoc.SelectedValue != null)
                {
                    List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();
                    reportExcelDTO _item_tenkhoahoc = new reportExcelDTO()
                    {
                        name = Base.bienTrongBaoCao.TENKHOAHOC,
                        value = cboKhoaHoc.Text,
                    };
                    thongTinThem.Add(_item_tenkhoahoc);
                    reportExcelDTO _item_tenlophoc = new reportExcelDTO()
                    {
                        name = Base.bienTrongBaoCao.TENLOPHOC,
                        value = cboLopHoc.Text,
                    };
                    thongTinThem.Add(_item_tenlophoc);

                    int _lophocId = Common.TypeConvert.TypeConvertParse.ToInt32(cboLopHoc.SelectedValue.ToString());
                    List<XepLopDTO> _lstXepLop = BangDiemLogic.SelectDSHV_Lop(_lophocId);

                    string fileTemplatePath = "FUN_XepLop_DanhSachLopHoc.xlsx";
                    DataTable _databaocao = Common.DataTables.ConvertDataTable.ListToDataTable(_lstXepLop);
                    Utilities.PrintPreview.PrintPreview_ExcelFileTemplate.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _databaocao);
                }
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
