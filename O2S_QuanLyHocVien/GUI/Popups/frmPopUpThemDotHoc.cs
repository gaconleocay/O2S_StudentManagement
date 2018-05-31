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
    public partial class frmPopUpThemDotHoc : Form
    {
        private int LopHocId { get; set; }

        public frmPopUpThemDotHoc()
        {
            InitializeComponent();
        }
        public frmPopUpThemDotHoc(int _LopHocId)
        {
            try
            {
                InitializeComponent();
                this.LopHocId = _LopHocId;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        #region Load

        private void frmXoaPhieuGhiDanh_Load(object sender, EventArgs e)
        {
            //btnLuuThongTin.Enabled = false;
        }
        #endregion

        #region Events
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                DOTHOC _dotHoc = new DOTHOC()
                {
                    CoSoId = GlobalSettings.CoSoId,
                    LopHocId = this.LopHocId,
                    TenDotHoc = txtTenLopHoc.Text,
                    HocPhi = O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text),
                    SoBuoiHoc = O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHoc.Text),
                };

                if (DotHocLogic.Insert(_dotHoc))
                {
                    O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                    frmthongbao.Show();
                    this.Close();
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

        #endregion

        private void numHocPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numHocPhi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal _hocphi = O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text);
                decimal _buoihoc = O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHoc.Text);
                numHocPhi.Text = O2S_Common.Number.Convert.NumberToString(_hocphi, 0);
                //
                numHocPhi1Buoi.Text = O2S_Common.Number.Convert.NumberToString(_hocphi / _buoihoc, 0);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void numSoBuoiHoc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal _hocphi = O2S_Common.TypeConvert.Parse.ToDecimal(numHocPhi.Text);
                decimal _buoihoc = O2S_Common.TypeConvert.Parse.ToDecimal(numSoBuoiHoc.Text);
                numSoBuoiHoc.Text = O2S_Common.Number.Convert.NumberToString(_buoihoc, 0);
                //
                numHocPhi1Buoi.Text = O2S_Common.Number.Convert.NumberToString(_hocphi / _buoihoc, 0);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
