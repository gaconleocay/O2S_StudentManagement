using System;
using System.Drawing;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.Pages;
using O2S_QuanLyHocVien.Popups;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Configuration;
using O2S_License.PasswordKey;
using O2S_QuanLyHocVien.Base;
using System.Net;
using System.Linq;
using DevExpress.XtraBars;
using O2S_QuanLyHocVien.BUS;
using DevExpress.XtraTab;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;

namespace O2S_QuanLyHocVien
{
    public partial class frmMainHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Khai bao
        private DialogResult hoiThoatChuongTrinh;
        private bool exit_frmmain = true;
        #endregion
        public frmMainHome()
        {
            InitializeComponent();
        }

        #region Load
        private void frmMainHome_Load(object sender, EventArgs e)
        {
            try
            {
                timerClock.Start();
                timerKiemTraLicense.Interval = KeyTrongPhanMem.ThoiGianKiemTraLicense;
                timerKiemTraLicense.Start();

                KiemTraLicensevaEnableChucNang(); //kiem tra license truoc khi kiem tra phan quyen
                HienThiThongTinVePhanMem_Version();
                LoadGiaoDien();

                btnTrangChu_ItemClick(null, null);
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
                if (GlobalSettings.UserCode != KeyTrongPhanMem.AdminUser_key)
                {
                    EnableAndDisableTabChucNang(false);
                    if (!GlobalSettings.KiemTraLicenseSuDung)
                    {
                        //neu la nguoi quan tri thi hien thi nut License
                        EnableNhapLicense();
                        DialogResult dialogResult = MessageBox.Show("Phần mềm hết bản quyền! \nVui lòng liên hệ với tác giả để được trợ giúp.\nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        KiemTraPhanQuyen_TabMenu();
                    }
                }
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
                this.Text = "Quản lý Học viên Trung tâm Anh ngữ (v" + Application.ProductVersion + ")";

                lblCenterName.Caption = GlobalSettings.TrungTam_Name + " - [" + GlobalSettings.CoSo_Ten + "]";
                lblServerName.Caption = GlobalSettings.ServerName;
                StatusUsername.Caption = GlobalSettings.UserName;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Tabcontrol function
        private void xtraTabControl_Home_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                XtraTabControl xtab = (XtraTabControl)sender;
                int i = xtab.SelectedTabPageIndex;
                DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
                xtab.TabPages.Remove((arg.Page as XtraTabPage));
                xtab.SelectedTabPageIndex = i - 1;
                System.GC.Collect();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
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

        #endregion

        #region Delegate
        //internal void HienThiTenChucNang(string _message)
        //{
        //    try
        //    {
        //        lblStatusTenBC.Caption = _message;
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Warn(ex);
        //    }
        //}
        #endregion

        #region Timer
        //private void timerQLMayTram_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string _sqlgetstatus = "SELECT reportstatus,softstatus,thongbao FROM ie_clientmachine WHERE clientmachinecode='" + Base.HardwareInfo.ProcessorId_MainBoardProductId() + "';";
        //        DataTable _dataStatus = condb.GetDataTable_HSBA(_sqlgetstatus);
        //        if (_dataStatus != null && _dataStatus.Rows.Count > 0)
        //        {
        //            //todo
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Logging.LogSystem.Warn(ex);
        //    }
        //}
        // Hiển thị thời gian ngày tháng
        private void timerClock_Tick(object sender, EventArgs e)
        {
            StatusClock.Caption = DateTime.Now.ToString("dddd, HH:mm:ss dd/MM/yyyy");
        }

        private void timerKiemTraLicense_Tick(object sender, EventArgs e)
        {
            try
            {
                if (GlobalSettings.UserCode != KeyTrongPhanMem.AdminUser_key)
                {
                    KiemTraLicense.KiemTraLicenseHopLe();
                    if (!GlobalSettings.KiemTraLicenseSuDung)
                    {
                        timerKiemTraLicense.Stop();
                        DialogResult dialogResult = MessageBox.Show("Phần mềm hết bản quyền! \nVui lòng liên hệ với tác giả để được trợ giúp.\nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Visible = false;
                            this.Dispose();
                            frmDangNhap frm = new frmDangNhap();
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

        #region Process


        #endregion


    }
}