// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyTaiKhoan.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Logic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        #region Khai bao
        private TAIKHOAN TaiKhoan_Select { get; set; }
        private List<PhanQuyenTaiKhoan_PlusDTO> lstPQ_TK_ChucNang { get; set; }
        private List<PhanQuyenTaiKhoan_PlusDTO> lstPQ_TK_BaoCao { get; set; }
        #endregion
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLoaiTaiKhoan();
                LoadDanhSachTaiKhoan();
                LoadChucNangVaBaoCao();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadLoaiTaiKhoan()
        {
            try
            {
                cboLoaiTaiKhoan.DataSource = LoaiTaiKhoanLogic.SelectAll();
                cboLoaiTaiKhoan.DisplayMember = "TenLoaiTaiKhoan";
                cboLoaiTaiKhoan.ValueMember = "LoaiTaiKhoanId";
                cboLoaiTaiKhoan.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachTaiKhoan()
        {
            try
            {
                TaiKhoanFilter _filter = new TaiKhoanFilter();
                _filter.LoaiTaiKhoanId = O2S_Common.TypeConvert.Parse.ToInt32(cboLoaiTaiKhoan.SelectedValue.ToString());
                List<TaiKhoan_PlusDTO> _lstTaiKhoan = TaiKhoanLogic.SelectFilter(_filter);
                gridControlTaiKhoan.DataSource = _lstTaiKhoan;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadChucNangVaBaoCao()
        {
            try
            {
                List<PhanQuyenTaiKhoan_PlusDTO> lstChucNangAll = ChucNangLogic.SelectKieuPhanQuyen();
                List<PhanQuyenTaiKhoan_PlusDTO> _lstChucNang_ChucNang = lstChucNangAll.Where(o => o.LoaiChucNangId != 3).ToList();
                gridControlChucNang.DataSource = _lstChucNang_ChucNang;
                //
                List<PhanQuyenTaiKhoan_PlusDTO> _lstChucNang_BaoCao = lstChucNangAll.Where(o => o.LoaiChucNangId == 3).ToList();
                gridControlBaoCao.DataSource = _lstChucNang_BaoCao;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Events
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachTaiKhoan();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridViewTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewTaiKhoan.RowCount > 0)
                {
                    var rowHandle = gridViewTaiKhoan.FocusedRowHandle;
                    int _taikhoanId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewTaiKhoan.GetRowCellValue(rowHandle, "TaiKhoanId").ToString());

                    //hien thi tai khoan hien tai len form
                    this.TaiKhoan_Select = TaiKhoanLogic.SelectSingle(_taikhoanId);
                    txtTenDangNhap.Text = this.TaiKhoan_Select.TenDangNhap;
                    txtMatKhau.Text = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(this.TaiKhoan_Select.MatKhau, true);

                    LoadPhanQuyenTheoTaiKhoan(_taikhoanId);
                }
                else
                {
                    this.TaiKhoan_Select = new TAIKHOAN();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadPhanQuyenTheoTaiKhoan(int _taikhoanId)
        {
            try
            {
                gridControlChucNang.DataSource = null;
                gridControlBaoCao.DataSource = null;
                this.lstPQ_TK_ChucNang = new List<PhanQuyenTaiKhoan_PlusDTO>();
                this.lstPQ_TK_BaoCao = new List<PhanQuyenTaiKhoan_PlusDTO>();

                List<PhanQuyenTaiKhoan_PlusDTO> _lstPQ_TK_All = PhanQuyenTaiKhoanLogic.SelectKieuPhanQuyen(_taikhoanId);
                this.lstPQ_TK_ChucNang = _lstPQ_TK_All.Where(o => o.LoaiChucNangId != 3).ToList();
                gridControlChucNang.DataSource = this.lstPQ_TK_ChucNang;

                this.lstPQ_TK_BaoCao = _lstPQ_TK_All.Where(o => o.LoaiChucNangId == 3).ToList();
                gridControlBaoCao.DataSource = this.lstPQ_TK_BaoCao;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TaiKhoan_Select != null)
                {
                    //Update TAIKHOAN: passs
                    this.TaiKhoan_Select.MatKhau = txtMatKhau.Text;

                    //Update PHANQUYENTAIKHOAN
                    List<PHANQUYENTAIKHOAN> _lstPQ_TK_All = new List<PHANQUYENTAIKHOAN>();
                    foreach (var _item in this.lstPQ_TK_ChucNang)
                    {
                        if (_item.IsCheck)
                        {
                            PHANQUYENTAIKHOAN _phanquyen = new PHANQUYENTAIKHOAN
                            {
                                TaiKhoanId = this.TaiKhoan_Select.TaiKhoanId,
                                ChucNangId = _item.ChucNangId,
                                Them = _item.Them == true ? 1 : 0,
                                Sua = _item.Sua == true ? 1 : 0,
                                Xoa = _item.Xoa == true ? 1 : 0,
                                InAn = _item.InAn == true ? 1 : 0,
                                XuatFile = _item.XuatFile == true ? 1 : 0,
                            };
                            _lstPQ_TK_All.Add(_phanquyen);
                        }
                    }
                    foreach (var _item in this.lstPQ_TK_BaoCao)
                    {
                        if (_item.IsCheck)
                        {
                            PHANQUYENTAIKHOAN _phanquyen = new PHANQUYENTAIKHOAN
                            {
                                TaiKhoanId = this.TaiKhoan_Select.TaiKhoanId,
                                ChucNangId = _item.ChucNangId,
                                Them = _item.Them == true ? 1 : 0,
                                Sua = _item.Sua == true ? 1 : 0,
                                Xoa = _item.Xoa == true ? 1 : 0,
                                InAn = _item.InAn == true ? 1 : 0,
                                XuatFile = _item.XuatFile == true ? 1 : 0,
                            };
                            _lstPQ_TK_All.Add(_phanquyen);
                        }
                    }

                    if (TaiKhoanLogic.Update(this.TaiKhoan_Select) && PhanQuyenTaiKhoanLogic.DeleteAndInsert(_lstPQ_TK_All, this.TaiKhoan_Select.TaiKhoanId))
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                        frmthongbao.Show();
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Custom
        private void cboLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachTaiKhoan();
        }
        private void gridViewChucNang_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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

        private void gridViewBaoCao_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }






        #endregion





    }
}
