// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyCauHinhEmail.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace O2S_QuanLyHocVien.CauHinh
{
    public partial class frmCauHinhEmail : Form
    {
        #region Khai bao
        private bool isInsert = false;
        private CAUHINHEMAIL CauHinhEmailSelect { get; set; }

        #endregion
        public frmCauHinhEmail()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyCauHinhEmail_Load(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(false);
            LoadGridCauHinhEmail();
        }
        private void LoadGridCauHinhEmail()
        {
            try
            {
                CauHinhEmailFilter _filter = new CauHinhEmailFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                List<CAUHINHEMAIL> _lstCauHinhEmail = CauHinhEmailLogic.Select(_filter);
                if (_lstCauHinhEmail != null && _lstCauHinhEmail.Count > 0)
                {
                    gridControlEmail.DataSource = _lstCauHinhEmail;
                }
                else
                {
                    gridControlEmail.DataSource = null;
                }
                lblTongCong.Text = string.Format("Tổng cộng: {0}", gridViewEmail.RowCount);
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Processs
        private void LockAndUnLookPanelControl(bool _result)
        {
            //txtMaEmail.Enabled = _result;
            txtSMTPServer.ReadOnly = !_result;
            txtPort.ReadOnly = !_result;
            txtDiaChiEmail.ReadOnly = !_result;
            txtTaiKhoan.ReadOnly = !_result;
            txtMatKhau.ReadOnly = !_result;
            chkXacThucSSL.Enabled = _result;
            chkXacThucTKKhiGui.Enabled = _result;
            chkIsLock.Enabled = _result;

            btnLuuThongTin.Enabled = _result;
            btnHuyBo.Enabled = _result;
        }

        private void ResetPanelControl()
        {
            txtMaEmail.Text = string.Empty;
            txtSMTPServer.Text = string.Empty;
            txtPort.Text = string.Empty;
            txtDiaChiEmail.Text = string.Empty;
            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            chkXacThucSSL.Checked = false;
            chkXacThucTKKhiGui.Checked = false;
            chkIsLock.Checked = false;
        }
        private void CauHinhEmail_ClickData(CAUHINHEMAIL _cauhinh)
        {
            txtMaEmail.Text = _cauhinh.MaEmail;
            txtSMTPServer.Text = _cauhinh.SMTPServer;
            txtPort.Text = _cauhinh.Port.ToString();
            txtDiaChiEmail.Text = _cauhinh.DiaChiEmail;
            txtTaiKhoan.Text = _cauhinh.TaiKhoan;
            txtMatKhau.Text = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(_cauhinh.MatKhau, true);
            chkXacThucSSL.Checked = _cauhinh.XacThucSSL ?? false;
            chkXacThucTKKhiGui.Checked = _cauhinh.XacThucTKKhiGui ?? false;

            chkIsLock.Checked = _cauhinh.IsLock ?? false;
        }

        private CAUHINHEMAIL LoadCauHinhEmail()
        {
            return new CAUHINHEMAIL()
            {
                CauHinhEmailId = this.CauHinhEmailSelect != null ? this.CauHinhEmailSelect.CauHinhEmailId : 0,
                CoSoId = GlobalSettings.CoSoId,
                SMTPServer = txtSMTPServer.Text,
                Port = O2S_Common.TypeConvert.Parse.ToInt32(txtPort.Text),
                DiaChiEmail = txtDiaChiEmail.Text,
                TaiKhoan = txtTaiKhoan.Text,
                MatKhau = txtMatKhau.Text,
                XacThucSSL = chkXacThucSSL.Checked,
                XacThucTKKhiGui = chkXacThucTKKhiGui.Checked,
                IsLock = chkIsLock.Checked,
            };
        }

        #endregion

        #region Events
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridViewCauHinhEmail_Click(sender, e);
        }

        private void gridViewCauHinhEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewEmail.RowCount > 0)
                {
                    var rowHandle = gridViewEmail.FocusedRowHandle;
                    int _CauHinhEmailId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewEmail.GetRowCellValue(rowHandle, "CauHinhEmailId").ToString());

                    this.CauHinhEmailSelect = CauHinhEmailLogic.SelectSingle(_CauHinhEmailId);
                    if (this.CauHinhEmailSelect != null)
                    {
                        CauHinhEmail_ClickData(this.CauHinhEmailSelect);
                        LockAndUnLookPanelControl(false);
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(true);
            ResetPanelControl();
            isInsert = true;
        }
        private void gridViewCauHinhEmail_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockAndUnLookPanelControl(true);
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var rowHandle = gridViewEmail.FocusedRowHandle;
                    int _caHocId = O2S_Common.TypeConvert.Parse.ToInt32(gridViewEmail.GetRowCellValue(rowHandle, "CauHinhEmailId").ToString());
                    if (CauHinhEmailLogic.Delete(_caHocId))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                        frmthongbao.Show();
                        LoadGridCauHinhEmail();
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    int _khoaHocId = 0;
                    if (CauHinhEmailLogic.Insert(LoadCauHinhEmail(), ref _khoaHocId))
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
                else
                {
                    if (CauHinhEmailLogic.Update(LoadCauHinhEmail()))
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                        frmthongbao.Show();
                    }
                    else
                    {
                        O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CAP_NHAT_THAT_BAI);
                        frmthongbao.Show();
                    }
                }
                LoadGridCauHinhEmail();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Custom

        private void gridViewDSCauHinhEmail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
        private void gridViewKhoaHoc_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clmKH_stt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        #endregion


    }
}
