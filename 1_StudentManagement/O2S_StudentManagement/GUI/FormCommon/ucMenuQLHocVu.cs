using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;

namespace O2S_StudentManagement.GUI.FormCommon
{
    public partial class ucMenuQLHocVu : UserControl
    {
        #region Declaration
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        public string CurrentTabPage { get; set; }
        public int SelectedTabPageIndex { get; set; }

        // khai báo 1 hàm delegate
        public delegate void GetString(string thoigian);
        public GetString MyGetData;

        #endregion
        public ucMenuQLHocVu()
        {
            InitializeComponent();
        }
        public ucMenuQLHocVu(bool _hienthi_btnTroVe)
        {
            InitializeComponent();
        }

        #region Load
        private void ucMenuThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                KiemTraEnable_ChucNang();
                //MyGetData("Thống kê - Lịch sử kiểm tra xe ra");
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
                //xtraTab_TKLSKiemTra.PageVisible = O2S_StudentManagement.Base.CheckPermission.ChkPerModule("TOOL_05");
                //xtraTab_TKLSVaoRa.PageVisible = O2S_StudentManagement.Base.CheckPermission.ChkPerModule("TOOL_06");
                //xtraTab_TKLSCapNhatNoiTru.PageVisible = O2S_StudentManagement.Base.CheckPermission.ChkPerModule("TOOL_07");
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
                if (xtraTab_TKLSKiemTra.PageVisible)
                {
                    //xtraTab_TKLSKiemTra.Controls.Clear();
                    //ucLichSuKiemTraXeRa uchienthi = new ucLichSuKiemTraXeRa();
                    //uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                    //xtraTab_TKLSKiemTra.Controls.Add(uchienthi);
                }
                if (xtraTab_TKLSVaoRa.PageVisible)
                {
                    //xtraTab_TKLSVaoRa.Controls.Clear();
                    //ucLichSuXeVaoRa uchienthi = new ucLichSuXeVaoRa();
                    //uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                    //xtraTab_TKLSVaoRa.Controls.Add(uchienthi);
                }
                if (xtraTab_TKLSCapNhatNoiTru.PageVisible)
                {
                    //xtraTab_TKLSCapNhatNoiTru.Controls.Clear();
                    //ucLichSuCapNhatNoiTru uchienthi = new ucLichSuCapNhatNoiTru();
                    //uchienthi.Dock = System.Windows.Forms.DockStyle.Fill;
                    //xtraTab_TKLSCapNhatNoiTru.Controls.Add(uchienthi);
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
