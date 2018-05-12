// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmHocVienTiemNang_GuiMail.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmHocVienTiemNang_GuiMail : Form
    {
        private int HocVienId_Select { get; set; }

        public frmHocVienTiemNang_GuiMail()
        {
            InitializeComponent();
        }
        public frmHocVienTiemNang_GuiMail(int _hocVienId)
        {
            InitializeComponent();
            this.HocVienId_Select = _hocVienId;
        }

        private void frmHocVienTiemNang_GuiMail_Load(object sender, EventArgs e)
        {
            dateNgayTuVan.DateTime = DateTime.Now;
            HOCVIEN _hocvien = HocVienLogic.SelectSingle(this.HocVienId_Select);
            lblMaHocVien.Text = _hocvien.MaHocVien;
            lblTenHocVien.Text = _hocvien.TenHocVien;

            txtTieuDeMail.Focus();
        }

        #region Events


        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                LICHSUTUVAN _lstuvan = new LICHSUTUVAN()
                {
                    HocVienId = this.HocVienId_Select,
                    NguoiTuVan = txtTieuDeMail.Text,
                    NoiDungTuVan = txtNoiDungMail.Text,
                    KetQuaTuVan = txtKetQuaTuVan.Text,
                    GhiChu = txtGhiChu.Text,
                    NgayTuVan = dateNgayTuVan.DateTime,
                };
                if (LichSuTuVanLogic.Insert(_lstuvan))
                {
                    O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                    frmthongbao.Show();
                }
                else
                {
                    O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THAT_BAI);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
