using O2S_License.PasswordKey;
using O2S_StudentManagement.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace O2S_StudentManagement.GUI.FormCommon
{
    public partial class frmMain : Form
    {
        #region Khai bao
        private  DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        private DialogResult hoiThoatChuongTrinh;
        private bool exit_frmmain = true;
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        #region Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                timerClock.Start();
                timerKiemTraLicense.Interval = KeyTrongPhanMem.ThoiGianKiemTraLicense;
                timerKiemTraLicense.Start();

                KhoiTaoPageMenu();
                KiemTraLicensevaEnableChucNang(); //kiem tra license truoc khi kiem tra phan quyen
                HienThiThongTinVePhanMem_Version();
                LoadGiaoDien();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void KhoiTaoPageMenu()
        {
            try
            {
                tabMenuTrangChu.Controls.Clear();
                O2S_StudentManagement.GUI.FormCommon.ucMenuTrangChu ucTrangChu = new FormCommon.ucMenuTrangChu();
                ucTrangChu.MyGetData = new FormCommon.ucMenuTrangChu.GetString(HienThiTenChucNang);
                ucTrangChu.Dock = System.Windows.Forms.DockStyle.Fill;
                tabMenuTrangChu.Controls.Add(ucTrangChu);

                tabMenuQLHocVien.Controls.Clear();
                GUI.FormCommon.ucMenuQLHocVien ucCauHinh = new GUI.FormCommon.ucMenuQLHocVien();
                ucCauHinh.MyGetData = new GUI.FormCommon.ucMenuQLHocVien.GetString(HienThiTenChucNang);
                ucCauHinh.Dock = System.Windows.Forms.DockStyle.Fill;
                tabMenuQLHocVien.Controls.Add(ucCauHinh);

                tabMenuQLHocVu.Controls.Clear();
                GUI.FormCommon.ucMenuQLHocVu ucGiamDinhXML = new GUI.FormCommon.ucMenuQLHocVu();
                ucGiamDinhXML.MyGetData = new GUI.FormCommon.ucMenuQLHocVu.GetString(HienThiTenChucNang);
                ucGiamDinhXML.Dock = System.Windows.Forms.DockStyle.Fill;
                tabMenuQLHocVu.Controls.Add(ucGiamDinhXML);

                tabMenuTaiChinh.Controls.Clear();
                FormCommon.ucMenuTaiChinh ucTabMenuQuanTri = new ucMenuTaiChinh();
                ucTabMenuQuanTri.MyGetData = new ucMenuTaiChinh.GetString(HienThiTenChucNang);
                ucTabMenuQuanTri.Dock = System.Windows.Forms.DockStyle.Fill;
                tabMenuTaiChinh.Controls.Add(ucTabMenuQuanTri);

                tabMenuQLGiaoVien.Controls.Clear();
                FormCommon.ucMenuQLGiaoVien ucTabMenu = new ucMenuQLGiaoVien();
                ucTabMenu.MyGetData = new ucMenuQLGiaoVien.GetString(HienThiTenChucNang);
                ucTabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
                tabMenuQLGiaoVien.Controls.Add(ucTabMenu);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void HienThiThongTinVePhanMem_Version()
        {
            try
            {
                string serverhost = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString(), true);
                string serverdb = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString(), true);
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                this.Text = "Phần mềm Quản lý học viên (v" + version + ")";
                StatusUsername.Caption = SessionLogin.SessionUsername;
                StatusDBName.Caption = serverhost + " [ " + serverdb + " ]";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void KiemTraLicensevaEnableChucNang()
        {
            try
            {
                //Kiểm tra phân quyền
                if (SessionLogin.SessionUsercode != KeyTrongPhanMem.AdminUser_key)
                {
                    if (!SessionLogin.KiemTraLicenseSuDung)
                    {
                        EnableAndDisableTabChucNang(false);
                        DialogResult dialogResult = MessageBox.Show("Phần mềm hết bản quyền! \nVui lòng liên hệ với tác giả để được trợ giúp.\nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        KiemTraPhanQuyenNguoiDung();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Giao dien
        private void LoadGiaoDien()
        {
            try
            {
                foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
                {
                    DevExpress.XtraBars.BarButtonItem item = new DevExpress.XtraBars.BarButtonItem();
                    item.Caption = skin.SkinName;
                    item.Name = "button" + skin.SkinName;
                    item.ItemClick += item_ItemClick;
                    // barSubItemSkin.AddItem(item);
                }
                if (ConfigurationManager.AppSettings["skin"].ToString() != "")
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(ConfigurationManager.AppSettings["skin"].ToString());
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void item_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DevExpress.XtraBars.BarItem item = e.Item;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(item.Caption);
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _config.AppSettings.Settings["skin"].Value = item.Caption;
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Custom
        // sự kiện hỏi khi ấn nút X để đóng chương trình
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.exit_frmmain == false)
                {
                    return;
                }
                if (hoiThoatChuongTrinh != DialogResult.Retry)
                {
                    hoiThoatChuongTrinh = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (hoiThoatChuongTrinh == DialogResult.No)
                        e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        // Thoát chương trình 
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void tabPaneMenu_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            try
            {
                if (tabPaneMenu.SelectedPage == tabMenuRestart)
                {
                    hoiThoatChuongTrinh = DialogResult.Retry;
                    // Application.Restart();
                    Application.ExitThread();
                    System.Diagnostics.Process.Start(@"O2S StudentManagementLauncher.exe");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
                throw;
            }
        }

        #endregion

        #region Delegate
        internal void HienThiTenChucNang(string _message)
        {
            try
            {
                lblStatusTenBC.Caption = _message;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        internal void ExitFormMain_Function(bool _exit_frmmain)
        {
            try
            {
                this.exit_frmmain = _exit_frmmain;
                this.Visible = _exit_frmmain;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }



        #endregion

        #region Timer
        private void timerQLMayTram_Tick(object sender, EventArgs e)
        {
            try
            {
                //string _sqlgetstatus = "SELECT reportstatus,softstatus,thongbao FROM ie_clientmachine WHERE clientmachinecode='" + Base.HardwareInfo.ProcessorId_MainBoardProductId() + "';";
                //DataTable _dataStatus = condb.GetDataTable(_sqlgetstatus);
                //if (_dataStatus != null && _dataStatus.Rows.Count > 0)
                //{
                //    //todo
                //}
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        // Hiển thị thời gian ngày tháng
        private void timerClock_Tick(object sender, EventArgs e)
        {
            StatusClock.Caption = DateTime.Now.ToString("dddd, HH:mm:ss dd/MM/yyyy");
        }

        private void timerKiemTraLicense_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SessionLogin.SessionUsercode != KeyTrongPhanMem.AdminUser_key)
                {
                    KiemTraLicense.KiemTraLicenseHopLe();
                    if (SessionLogin.KiemTraLicenseSuDung == false)
                    {
                        timerKiemTraLicense.Stop();
                        DialogResult dialogResult = MessageBox.Show("Phần mềm hết bản quyền! \nVui lòng liên hệ với tác giả để được trợ giúp.\nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Visible = false;
                            this.Dispose();
                            frmLogin frm = new frmLogin();
                            frm.Show();
                        }
                    }
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
