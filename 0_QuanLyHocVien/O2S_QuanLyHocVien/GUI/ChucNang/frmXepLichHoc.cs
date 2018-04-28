// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmXepLichHoc.cs"
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
using System.Linq;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmXepLichHoc : Form
    {
        #region Khai bao
        private List<XepLichHoc_PlusDTO> lstLichHoc { get; set; }
        private int LopHocId_Select { get; set; }
        private int KhoaHocId_Select { get; set; }

        #endregion
        public frmXepLichHoc()
        {
            InitializeComponent();
        }

        #region Load
        private void frmXepLichHoc_Load(object sender, EventArgs e)
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

        //
        private void LoadLichHocCuaLopHoc(int _lophocId)
        {
            try
            {
                //Kiem tra xem co lich hoc chua
                //-Neu co hien thi len
                //--neu chua insert 1 dong new
                XepLichHocFilter _filter = new XepLichHocFilter();
                _filter.LopHocId = _lophocId;
                this.lstLichHoc = XepLichHocLogic.Select(_filter);
                if (this.lstLichHoc != null && this.lstLichHoc.Count > 0)
                {
                    for (int i = 0; i < this.lstLichHoc.Count; i++)
                    {
                        this.lstLichHoc[i].Stt = i + 1;
                    }
                }
                else
                {
                    XepLichHoc_PlusDTO _lichhoc = new XepLichHoc_PlusDTO()
                    {
                        Stt = 1,
                        CoSoId = GlobalSettings.CoSoId,
                        LopHocId = _lophocId,
                        TenLopHoc = cboLopHoc.Text,
                    };
                    this.lstLichHoc = new List<XepLichHoc_PlusDTO>();
                    this.lstLichHoc.Add(_lichhoc);
                }

                gridControlLichHoc.DataSource = this.lstLichHoc;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadCaHoc()
        {
            try
            {
                CaHocFilter _filter = new CaHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.IsRemove = 0;
                List<CAHOC> dataCaHoc = CaHocLogic.Select(_filter);
                repositoryItemGrid_CaHoc.DataSource = dataCaHoc;
                repositoryItemGrid_CaHoc.DisplayMember = "TenCaHocFull";
                repositoryItemGrid_CaHoc.ValueMember = "CaHocId";
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadGiangVien()
        {
            try
            {
                List<XepLich_GiaoVienChinhDTO> _dataGiaoVienChinh = new List<XepLich_GiaoVienChinhDTO>();
                List<XepLich_GiaoVienTroGiangDTO> _dataGiaoVienTroGiang = new List<XepLich_GiaoVienTroGiangDTO>();

                GiangVienFilter _filter = new GiangVienFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                List<GiangVien_PlusDTO> _dataGiangVien = GiangVienLogic.Select(_filter);
                if (_dataGiangVien != null && _dataGiangVien.Count > 0)
                {
                    foreach (var item in _dataGiangVien)
                    {
                        XepLich_GiaoVienChinhDTO _gvChinh = new XepLich_GiaoVienChinhDTO()
                        {
                            GiaoVien_ChinhId = item.GiangVienId,
                            TenGiaoVien_Chinh = item.TenGiangVien,
                        };
                        _dataGiaoVienChinh.Add(_gvChinh);
                        //
                        XepLich_GiaoVienTroGiangDTO _gvTroGiang = new XepLich_GiaoVienTroGiangDTO()
                        {
                            GiaoVien_TroGiangId = item.GiangVienId,
                            TenGiaoVien_TroGiang = item.TenGiangVien,
                        };
                        _dataGiaoVienTroGiang.Add(_gvTroGiang);
                    }
                }

                repositoryItemGrid_GVChinh.DataSource = _dataGiaoVienChinh;
                repositoryItemGrid_GVChinh.DisplayMember = "TenGiaoVien_Chinh";
                repositoryItemGrid_GVChinh.ValueMember = "GiaoVien_ChinhId";

                repositoryItemGrid_TroGiang.DataSource = _dataGiaoVienTroGiang;
                repositoryItemGrid_TroGiang.DisplayMember = "TenGiaoVien_TroGiang";
                repositoryItemGrid_TroGiang.ValueMember = "GiaoVien_TroGiangId";
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
                this.KhoaHocId_Select = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString());
                this.LopHocId_Select = O2S_Common.TypeConvert.Parse.ToInt32(cboLopHoc.SelectedValue.ToString());
                if (this.LopHocId_Select != 0)
                {
                    LoadCaHoc();
                    LoadGiangVien();
                    LoadLichHocCuaLopHoc(this.LopHocId_Select);
                }
                else
                { this.LopHocId_Select = 0; }
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
                if (this.LopHocId_Select != 0)
                {
                    //Xoa di het roi insert lai
                    if (XepLichHocLogic.DeleteTheoLopHoc(this.LopHocId_Select))
                    {
                        List<XEPLICHHOC> _lstInsert = new List<XEPLICHHOC>();
                        foreach (var item in this.lstLichHoc)
                        {
                            var culture = new System.Globalization.CultureInfo("vi-VN");
                            var day_tiengViet = culture.DateTimeFormat.GetDayName(item.ThoiGianHoc.DayOfWeek);

                            ValidateLuu(item);
                            CAHOC _cahoc = CaHocLogic.SelectSingle(item.CaHocId ?? 0);
                            GIANGVIEN _gv_chinh = GiangVienLogic.SelectSigleTheoKhoaKhoa(item.GiaoVien_ChinhId ?? 0);
                            GIANGVIEN _gv_trogiang = GiangVienLogic.SelectSigleTheoKhoaKhoa(item.GiaoVien_TroGiangId ?? 0);
                            XEPLICHHOC _xeplich = new XEPLICHHOC()
                            {
                                CoSoId = GlobalSettings.CoSoId,
                                KhoaHocId = this.KhoaHocId_Select,
                                LopHocId = this.LopHocId_Select,
                                TenLopHoc = cboLopHoc.Text,
                                ThoiGianHoc = item.ThoiGianHoc,
                                ThoiGianHoc_Full = day_tiengViet + " - " + item.ThoiGianHoc.ToString("dd/MM/yyyy"),
                                CaHocId = item.CaHocId,
                                TenCaHocFull = _cahoc != null ? _cahoc.TenCaHocFull : "",
                                GiaoVien_ChinhId = item.GiaoVien_ChinhId,
                                TenGiaoVien_Chinh = _gv_chinh != null ? _gv_chinh.TenGiangVien : "",
                                TienGiaoVien_Chinh = item.TienGiaoVien_Chinh,
                                GiaoVien_TroGiangId = item.GiaoVien_TroGiangId,
                                TenGiaoVien_TroGiang = _gv_trogiang != null ? _gv_trogiang.TenGiangVien : "",
                                TienGiaoVien_TroGiang = item.TienGiaoVien_TroGiang,
                                GhiChu = item.GhiChu,
                                IsLock = item.IsLock,
                            };
                            _lstInsert.Add(_xeplich);
                        }
                        if (XepLichHocLogic.InsertMultiRow(_lstInsert))
                        {
                            //Thread.Sleep(2500);
                            Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                            frmthongbao.Show();
                            LoadLichHocCuaLopHoc(this.LopHocId_Select);
                        }
                        else
                        {
                            Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                            frmthongbao.Show();
                        }
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                        frmthongbao.Show();
                    }
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
        private void repositoryItemButton_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewLichHoc.RowCount > 1)
                {
                    var rowHandle = gridViewLichHoc.FocusedRowHandle;
                    int _stt = O2S_Common.TypeConvert.Parse.ToInt32(gridViewLichHoc.GetRowCellValue(rowHandle, "Stt").ToString());
                    XepLichHoc_PlusDTO _delete = this.lstLichHoc.Where(o => o.Stt == _stt).FirstOrDefault();
                    this.lstLichHoc.Remove(_delete);
                    gridControlLichHoc.DataSource = null;
                    gridControlLichHoc.DataSource = this.lstLichHoc;
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
                XepLichHoc_PlusDTO _lichhoc = new XepLichHoc_PlusDTO()
                {
                    Stt = this.lstLichHoc.Count + 1,
                    CoSoId = GlobalSettings.CoSoId,
                    LopHocId = this.LopHocId_Select,
                    TenLopHoc = cboLopHoc.Text,
                };
                this.lstLichHoc.Add(_lichhoc);
                gridControlLichHoc.DataSource = null;
                gridControlLichHoc.DataSource = this.lstLichHoc;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void ValidateLuu(XepLichHoc_PlusDTO _xeplich)
        {
            if (_xeplich.ThoiGianHoc == null)
                throw new ArgumentException("Thời gian học không được trống");
            if (_xeplich.CaHocId == null || _xeplich.CaHocId == 0)
                throw new ArgumentException("Ca/tiết học không được trống");
            if (_xeplich.GiaoVien_ChinhId == null || _xeplich.GiaoVien_ChinhId == 0)
                throw new ArgumentException("Giảng viên dạy chính không được trống");
        }

        private void btnKhoaLichHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn sẵn sàng lên lịch học?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<XEPLICHHOC> _lstLichHoc = XepLichHocLogic.SelectTheoLopHoc(this.LopHocId_Select);
                    if (XepLichHocLogic.UpdateKhoaLichHoc(_lstLichHoc))
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                        frmthongbao.Show();
                        btnTimKiem_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewLichHoc_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.MenuType == GridMenuType.Row)
                {
                    e.Menu.Items.Clear();
                    var rowHandle = gridViewLichHoc.FocusedRowHandle;
                    int _XepLichHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewLichHoc.GetRowCellValue(rowHandle, "XepLichHocId").ToString());
                    XEPLICHHOC _lichhoc = XepLichHocLogic.SelectSingle(_XepLichHocId);
                    if (_lichhoc != null && _lichhoc.IsLock == true)
                    {
                        DXMenuItem item_sualich = new DXMenuItem("Sửa lịch học");
                        item_sualich.Image = imMenu.Images[0];
                        item_sualich.Click += new EventHandler(repositoryItemButton_SuaLichHoc_Click);
                        e.Menu.Items.Add(item_sualich);
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void repositoryItemButton_SuaLichHoc_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gridViewLichHoc.FocusedRowHandle;
                int _XepLichHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewLichHoc.GetRowCellValue(rowHandle, "XepLichHocId").ToString());
                //
                foreach (var item in this.lstLichHoc)
                {
                    if (item.XepLichHocId == _XepLichHocId)
                    {
                        item.IsEdit = true;
                    }
                }
                //  gridControlLichHoc.DataSource = this.lstLichHoc;
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

        private void gridViewLichHoc_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                if (IsLookLichHoc(view, view.FocusedRowHandle)) //view.FocusedColumn.FieldName == "IsLock" &&
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private bool IsLookLichHoc(GridView view, int row)
        {
            bool result = false;
            try
            {
                GridColumn col = view.Columns["XepLichHocId"];
                int _XepLichHocId = O2S_Common.TypeConvert.Parse.ToInt32(view.GetRowCellValue(row, col).ToString());
                //kiem tra trong DB xem da khoa hay khong
                XEPLICHHOC _lichhoc = XepLichHocLogic.SelectSingle(_XepLichHocId);
                if (_lichhoc != null && _lichhoc.IsLock == true)
                {
                    result = true;
                }
                foreach (var item in this.lstLichHoc)
                {
                    if (item.XepLichHocId == _XepLichHocId && item.IsEdit == true)
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }




    }
}
