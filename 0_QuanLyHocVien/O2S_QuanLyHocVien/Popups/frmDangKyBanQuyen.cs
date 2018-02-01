// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmDangKyBanQuyen.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using System.Data;
using O2S_QuanLyHocVien.DataAccess;
using System.Globalization;
using O2S_QuanLyHocVien.Base;
using O2S_License.PasswordKey;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmDangKyBanQuyen : Form
    {
        #region Khai bao
        private string MaDatabase = String.Empty;
        //private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion
        public frmDangKyBanQuyen()
        {
            InitializeComponent();
        }

        #region Load
        private void frmDangKyBanQuyen_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiThongTinVeLicense();
                LoadFormTaoLicense();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void HienThiThongTinVeLicense()
        {
            try
            {
                MaDatabase = Base.KiemTraLicense.LayThongTinMaDatabase();
                txtMaMay.Text = MaDatabase;
                txtMaMay.ReadOnly = true;
                LICENSE license = License.Select(MaDatabase);
                if (license != null)
                {
                    txtKeyKichHoat.Text = license.LicenseKey;
                }
                txtKeyKichHoat.Focus();
                btnLicenseKiemTra.PerformClick();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadFormTaoLicense()
        {
            try
            {
                if (Base.SessionLogin.SessionUsercode == O2S_License.PasswordKey.KeyTrongPhanMem.AdminUser_key)
                {
                    groupBoxTaoLicense.Visible = true;
                    txtTaoLicensePassword.Focus();
                    btnTaoLicenseTao.Enabled = false;
                    dtTaoLicenseKeyTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    dtTaoLicenseKeyDenNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                }
                else
                {
                    groupBoxTaoLicense.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region License
        private void btnLicenseKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtKeyKichHoat.Text.Trim()))
                {
                    lblThoiGianSuDung.Text = Base.KiemTraLicense.KiemTraThoiHanLicense(txtKeyKichHoat.Text.Trim());
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("Chưa nhập mã kích hoạt!");
                    frmthongbao.Show();
                    lblThoiGianSuDung.Text = "none";
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }

        }
        private void btnLicenseLuu_Click(object sender, EventArgs e)
        {
            try
            {
                LICENSE _license = new LICENSE();
                _license.LicenseKey = txtKeyKichHoat.Text.Trim();
                try
                {
                    License.Update(_license);
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("Lưu mã kích hoạt thành công!");
                    frmthongbao.Show();
                }
                catch (Exception)
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnLicenseCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();    //Clear if any old value is there in Clipboard        
                Clipboard.SetText(txtMaMay.Text); //Copy text to Clipboard
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Tao License
        private void btnTaoLicenseTao_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaoLicenseMaMay.Text != "")
                {
                    string MaDatabaseVaThoiGianSuDung = "";
                    if (chkKhongThoiHan.Checked)
                    {
                        MaDatabaseVaThoiGianSuDung = O2S_License.PasswordKey.KeyTrongPhanMem.SaltEncrypt + "$" + txtTaoLicenseMaMay.Text + "$" + O2S_License.PasswordKey.KeyTrongPhanMem.BanQuyenKhongThoiHan;
                    }
                    else
                    {
                        string datetungay = DateTime.ParseExact(dtTaoLicenseKeyTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                        string datedenngay = DateTime.ParseExact(dtTaoLicenseKeyDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                        MaDatabaseVaThoiGianSuDung = KeyTrongPhanMem.SaltEncrypt + "$" + txtTaoLicenseMaMay.Text + "$" + datetungay + "$" + datedenngay;
                    }
                    txtTaoLicenseMaKichHoat.Text = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(MaDatabaseVaThoiGianSuDung, true);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnTaoLicenseCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();    //Clear if any old value is there in Clipboard        
                Clipboard.SetText(txtTaoLicenseMaKichHoat.Text); //Copy text to Clipboard
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void txtTaoLicensePassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Kiem tra pass dung hay sai?
                    if (txtTaoLicensePassword.Text.Trim() == KeyTrongPhanMem.LayLicense_key && SessionLogin.SessionUsercode ==KeyTrongPhanMem.AdminUser_key)
                    {
                        btnTaoLicenseTao.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion



        #region Custom
        private void chkKhongThoiHan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkKhongThoiHan.Checked)
                {
                    dtTaoLicenseKeyTuNgay.Enabled = false;
                    dtTaoLicenseKeyDenNgay.Enabled = false;
                }
                else
                {
                    dtTaoLicenseKeyTuNgay.Enabled = true;
                    dtTaoLicenseKeyDenNgay.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

    }
}
