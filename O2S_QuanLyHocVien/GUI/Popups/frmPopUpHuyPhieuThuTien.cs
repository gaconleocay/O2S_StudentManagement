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

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmPopUpHuyPhieuThuTien : Form
    {
        private int PhieuThuId { get; set; }

        public frmPopUpHuyPhieuThuTien()
        {
            InitializeComponent();
        }
        public frmPopUpHuyPhieuThuTien(int _PhieuThuId)
        {
            try
            {
                InitializeComponent();
                this.PhieuThuId = _PhieuThuId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Load

        #endregion

        #region Events
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                PHIEUTHU _phieuGD = PhieuThuLogic.SelectSingle(this.PhieuThuId);
                _phieuGD.IsRemove = 1;
                _phieuGD.LyDoHuy = txtLyDoHuy.Text;
                _phieuGD.NguoiHuy = GlobalSettings.UserCode + " - " + GlobalSettings.UserName;
                _phieuGD.ThoiGianHuy = DateTime.Now;
                if (PhieuThuLogic.HuyPhieuThuTien(_phieuGD))
                {
                    MessageBox.Show("Hủy phiếu thu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
