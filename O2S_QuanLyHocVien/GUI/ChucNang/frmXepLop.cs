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
using O2S_Common.DataObjects;

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
                LoadKhoaHoc();
                LoadLopTrongCuaKhoaHoc();
                LoadDSHVChuaCoLop();
                LoadDSHVLopChuaDu();
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
        private void LoadLopTrongCuaKhoaHoc()
        {
            try
            {
                cboLopHoc.DataSource = LopHocLogic.DanhSachLopTrong(O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString()));
                cboLopHoc.DisplayMember = "TenLopHoc";
                cboLopHoc.ValueMember = "LopHocId";
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        public void LoadDSHVChuaCoLop()
        {
            try
            {
                int _lopHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                this.dsChuaCoLop = HocVienLogic.HocVienChuaXepLopTheoKhoaHoc(_lopHocId);
                gridControlHV_ChuaXepLop.DataSource = this.dsChuaCoLop;
                lblTongCongHV.Text = string.Format("Tổng cộng: {0} học viên", this.dsChuaCoLop.Count);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        public void LoadDSHVLopChuaDu()
        {
            try
            {
                if (cboLopHoc.SelectedValue != null)
                {
                    int _lophocId = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Events
        private void btnLamMoiDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                LoadLopTrongCuaKhoaHoc();
                LoadDSHVChuaCoLop();
                LoadDSHVLopChuaDu();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnThemVaoLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewHV_ChuaXepLop.RowCount > 0)
                {
                    int _lophocId = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());
                    LOPHOC _lophoc = LopHocLogic.SelectSingle(_lophocId);

                    if (gridViewHV_XepLop.RowCount < _lophoc.SiSoToiDa ||
                    MessageBox.Show("Số học viên tối đa của lớp là " + _lophoc.SiSoToiDa + Environment.NewLine + "Bạn có chắc sẽ thêm?",
                        "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var rowHandle = gridViewHV_ChuaXepLop.FocusedRowHandle;
                        int _phieughidanhId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewHV_ChuaXepLop.GetRowCellValue(rowHandle, "PhieuGhiDanhId").ToString());
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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnBoKhoiLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewHV_XepLop.RowCount > 0)
                {
                    var rowHandle = gridViewHV_XepLop.FocusedRowHandle;
                    int _phieughidanhId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewHV_XepLop.GetRowCellValue(rowHandle, "PhieuGhiDanhId").ToString());

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
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnLuuLop_Click(object sender, EventArgs e)
        {
            try
            {
                //insert + Xoa tai BANGDIEM 
                int _LopHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());
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
                    SiSoToiDa = _lophoc.SiSoToiDa,
                    SiSo = this.dsXepLopHocVien.Count,
                    KhoaHocId = _lophoc.KhoaHocId,
                    IsLock = _lophoc.IsLock
                });

                O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                frmthongbao.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                frmthongbao.Show();
                O2S_Common.Logging.LogSystem.Error(ex);
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
            LoadDSHVChuaCoLop();
            LoadDSHVLopChuaDu();
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
                O2S_Common.Logging.LogSystem.Warn(ex);
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
                O2S_Common.Logging.LogSystem.Warn(ex);
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
            //    O2S_Common.Logging.LogSystem.Warn(ex);
            //}
        }


        #endregion

        #region In An
        private void btnInAn_DSLop_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(O2S_Common.Utilities.ThongBao.WaitForm_Wait));
                if (cboLopHoc.SelectedValue != null)
                {
                    List<reportExcelDTO> thongTinThem = new List<reportExcelDTO>();

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

                    List<XepLopDTO> _lstXepLop = BangDiemLogic.SelectDSHV_Lop(_lophocId);

                    string fileTemplatePath = "FUN_XepLop_DanhSachLopHoc.xlsx";
                    DataTable _databaocao = O2S_Common.DataTables.Convert.ListToDataTable(_lstXepLop);
                    Utilities.Prints.PrintPreview.ShowPrintPreview_UsingExcelTemplate(fileTemplatePath, thongTinThem, _databaocao);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
        }

        #endregion




    }
}
