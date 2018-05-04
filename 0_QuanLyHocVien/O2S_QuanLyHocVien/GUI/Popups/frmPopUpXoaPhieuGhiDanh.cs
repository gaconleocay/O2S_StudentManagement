// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmXoaPhieuGhiDanh.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Drawing;
using System.IO;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Collections.Generic;

namespace O2S_QuanLyHocVien.PhieuGhiDanh
{
    public partial class frmPopUpXoaPhieuGhiDanh : Form
    {
        private int PhieuGhiDanhId { get; set; }

        public frmPopUpXoaPhieuGhiDanh()
        {
            InitializeComponent();
        }
        public frmPopUpXoaPhieuGhiDanh(int _PhieuGhiDanhId)
        {
            try
            {
                InitializeComponent();
                this.PhieuGhiDanhId = _PhieuGhiDanhId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Load

        private void frmXoaPhieuGhiDanh_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region Events
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                PHIEUGHIDANH _phieuGD = PhieuGhiDanhLogic.SelectSingle(this.PhieuGhiDanhId);
                _phieuGD.IsRemove = 1;
                _phieuGD.LyDoXoa = txtLyDoXoa.Text;
                _phieuGD.NguoiXoa = GlobalSettings.UserCode;
                if (PhieuGhiDanhLogic.XoaPhieuGhiDanh(_phieuGD))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    O2S_Common. Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common. Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion
    }
}
