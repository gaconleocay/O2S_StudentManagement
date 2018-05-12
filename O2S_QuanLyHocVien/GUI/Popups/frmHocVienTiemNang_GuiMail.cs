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
using System.Net.Mail;
using System.Net;
using System.Drawing;

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
            try
            {
                //Load ds nguoi gui.
                CauHinhEmailFilter _filter = new CauHinhEmailFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                cboEmailGui.DataSource = CauHinhEmailLogic.Select(_filter);
                cboEmailGui.DisplayMember = "TaiKhoan";
                cboEmailGui.ValueMember = "CauHinhEmailId";

                HOCVIEN _hocvien = HocVienLogic.SelectSingle(this.HocVienId_Select);
                lblMaHocVien.Text = _hocvien.MaHocVien;
                lblTenHocVien.Text = _hocvien.TenHocVien;
                txtEmailNhan.Text = _hocvien.Email;

                txtTieuDeMail.Focus();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        #region Events


        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateEmailKhiGui();
                int _CauHinhId = O2S_Common.TypeConvert.Parse.ToInt32(cboEmailGui.SelectedValue.ToString());
                CAUHINHEMAIL _cauhinh = CauHinhEmailLogic.SelectSingle(_CauHinhId);
                if (_cauhinh == null)
                {
                    O2S_Common.Utilities.ThongBao.frmThongBao _frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
                    _frmthongbao.Show();
                    return;
                }

                SmtpClient mailclient = new SmtpClient(_cauhinh.SMTPServer, _cauhinh.Port ?? 0);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential(_cauhinh.TaiKhoan, O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(_cauhinh.MatKhau, true));

                MailMessage message = new MailMessage(_cauhinh.TaiKhoan, txtEmailNhan.Text);
                message.Subject = txtTieuDeMail.Text;
                message.Body = txtNoiDungMail.HtmlText;
                message.IsBodyHtml = true;

                mailclient.Send(message);
                MessageBox.Show(Base.ThongBaoLable.GUI_MAIL_THANH_CONG, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.GUI_MAIL_THANH_CONG);
                //frmthongbao.Show();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                O2S_Common.Logging.LogSystem.Error(ex);
                //O2S_Common.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_Common.Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.GUI_MAIL_THAT_BAI);
                //frmthongbao.Show();
            }
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Process
        private void ValidateEmailKhiGui()
        {
            if (!string.IsNullOrWhiteSpace(txtEmailNhan.Text))
            {
                if (!txtEmailNhan.Text.Contains("@") || !txtEmailNhan.Text.Contains("."))
                {
                    throw new ArgumentException("Email không đúng");
                }
            }
            else
            {
                throw new ArgumentException("Địa chỉ email không được trống");
            }
        }

        #endregion
    }
}
