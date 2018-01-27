using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using O2S_StudentManagement.Model.Models;
using DevExpress.XtraSplashScreen;

namespace O2S_StudentManagement.GUI.FormCommon
{
    public partial class ucMenuQLGiaoVien : UserControl
    {
        #region Declaration
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        public string CurrentTabPage { get; set; }
        public int SelectedTabPageIndex { get; set; }
        // khai báo 1 hàm delegate
        public delegate void GetString(string thoigian);
        public GetString MyGetData;
        #endregion

        #region Contrustor
        public ucMenuQLGiaoVien()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void ucMenuGiamDinhXML_Load(object sender, EventArgs e)
        {
            try
            {
                KiemTraEnable_ChucNang();
                //MyGetData("Quản lý xe ra - Kiểm tra xe miễn phí");
                LoadTabChucNang();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void KiemTraEnable_ChucNang()
        {
            try
            {
                //xtraTabQLHV_DanhMuc.PageVisible = O2S_StudentManagement.Base.CheckPermission.ChkPerModule("TOOL_01");
                //xtraTabQLHV_KTDauVao.PageVisible = O2S_StudentManagement.Base.CheckPermission.ChkPerModule("TOOL_02");
                //xtraTabQLHV_TTHocVien.PageVisible = O2S_StudentManagement.Base.CheckPermission.ChkPerModule("TOOL_03");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadTabChucNang()
        {
            try
            {
                if (xtraTabQLHV_DanhMuc.PageVisible)
                {
                    //xtraTabQLHV_DanhMuc.Controls.Clear();
                    //MenuQLHocVien.ucQLHV_DanhMuc uchienthi = new MenuQLHocVien.ucQLHV_DanhMuc();
                    //uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                    //xtraTabQLHV_DanhMuc.Controls.Add(uchienthi);
                }
                if (xtraTabQLHV_TTHocVien.PageVisible)
                {
                    //xtraTabQLHV_TTHocVien.Controls.Clear();
                    //MenuQLHocVien.ucQLHV_TTHocVien uchienthi = new MenuQLHocVien.ucQLHV_TTHocVien();
                    //uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                    //xtraTabQLHV_TTHocVien.Controls.Add(uchienthi);
                }
                if (xtraTabQLHV_KTDauVao.PageVisible)
                {
                    //xtraTabQLHV_KTDauVao.Controls.Clear();
                    //MenuQLHocVien.ucQLHV_KTDauVao uchienthi = new MenuQLHocVien.ucQLHV_KTDauVao();
                    //uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                    //xtraTabQLHV_KTDauVao.Controls.Add(uchienthi);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Tabcontrol function
        //Dong tab
        private void xtraTabControlCongCuKhac_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                XtraTabControl xtab = (XtraTabControl)sender;
                int i = xtab.SelectedTabPageIndex;
                DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
                xtab.TabPages.Remove((arg.Page as XtraTabPage));
                xtab.SelectedTabPageIndex = i - 1;
                //(arg.Page as XtraTabPage).PageVisible = false;
                System.GC.Collect();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void xtraTabControlCongCuKhac_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                //frmMain = new frmMain();
                this.CurrentTabPage = e.Page.Name;
                XtraTabControl xtab = new XtraTabControl();
                xtab = (XtraTabControl)sender;
                if (xtab != null)
                {
                    this.SelectedTabPageIndex = xtab.SelectedTabPageIndex;
                    //delegate - thong tin chuc nang
                    if (MyGetData != null)
                    {// tại đây gọi nó
                        MyGetData(xtab.TabPages[xtab.SelectedTabPageIndex].Tooltip);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion


    }
}
