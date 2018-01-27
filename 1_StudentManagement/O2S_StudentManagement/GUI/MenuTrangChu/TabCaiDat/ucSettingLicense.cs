using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using O2S_StudentManagement.Base;
using O2S_License.PasswordKey;

namespace O2S_StudentManagement.GUI.MenuTrangChu
{
    public partial class ucSettingLicense : UserControl
    {
        private string MaDatabase = String.Empty;
        private O2S_StudentManagement.DAL.ConnectDatabase condb = new O2S_StudentManagement.DAL.ConnectDatabase();

        public ucSettingLicense()
        {
            InitializeComponent();
        }

        private void ucSettingLicense_Load(object sender, EventArgs e)
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
                //Load License tu DB ra
                string kiemtra_licensetag = "SELECT top 1 datakey, licensekey FROM SM_LICENSE WHERE datakey='" + MaDatabase + "' ;";
                DataView dv = new DataView(condb.GetDataTable(kiemtra_licensetag));
                if (dv != null && dv.Count > 0)
                {
                    txtKeyKichHoat.Text = dv[0]["licensekey"].ToString();
                }
                txtKeyKichHoat.Focus();
                btnLicenseKiemTra_Click(null, null);
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
                if (SessionLogin.SessionUsercode == KeyTrongPhanMem.AdminUser_key)
                {
                    groupBoxTaoLicense.Visible = true;
                    txtTaoLicensePassword.Focus();
                    btnTaoLicenseTao.Enabled = false;
                    DateTime tuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    DateTime denNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    dtTaoLicenseKeyTuNgay.Value = tuNgay;
                    dtTaoLicenseKeyDenNgay.Value = denNgay;
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
                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao("Chưa nhập mã kích hoạt!");
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
                //Luu key kich hoat vao DB
                string update_license = "UPDATE SM_LICENSE SET licensekey='" + txtKeyKichHoat.Text.Trim() + "' WHERE datakey='" + MaDatabase + "' ;";
                if (condb.ExecuteNonQuery(update_license))
                {
                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao("Lưu mã kích hoạt thành công!");
                    frmthongbao.Show();
                }
                else
                {
                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.CO_LOI_XAY_RA);
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
                        MaDatabaseVaThoiGianSuDung = KeyTrongPhanMem.SaltEncrypt + "$" + txtTaoLicenseMaMay.Text + "$" + KeyTrongPhanMem.BanQuyenKhongThoiHan;
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
                    if (txtTaoLicensePassword.Text.Trim() == KeyTrongPhanMem.LayLicense_key && SessionLogin.SessionUsercode == KeyTrongPhanMem.AdminUser_key)
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







    }
}
