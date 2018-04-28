using DevExpress.XtraTab;
using O2S_License.PasswordKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_QuanLyHocVien.BUS
{
    internal static class TabControlProcess
    {
        #region Tabcontrol function
        //Dong tab
        //internal static void CloseAllTabpage(XtraTabControl tabControlName)
        //{
        //    try
        //    {
        //        int tab = 0;
        //        while (tabControlName.TabPages.Count > 0)
        //        {
        //            if (tabControlName.TabPages[tab].Name != "xtraTabDSChucNang")
        //            {
        //                tabControlName.TabPages.Remove(tabControlName.TabPages[tab]);
        //            }
        //        }
        //        System.GC.Collect();
        //    }
        //    catch (Exception ex)
        //    {
        //        O2S_Common.Logging.LogSystem.Warn(ex);
        //    }
        //}

        /// <summary>
        /// Tạo thêm tab mới
        /// </summary>
        /// <param name="tabControl">Tên TabControl để thêm tabpage mới vào</param>
        /// <param name="name">Tên tabpage mới</param>
        internal static void TabCreating(XtraTabControl tabControl, string name)
        {
            try
            {
                int index = KiemTraTabpageTonTai(tabControl, name);
                if (index >= 0)
                {
                    if (tabControl.TabPages[index].PageVisible == false)
                        tabControl.TabPages[index].PageVisible = true;
                }
                else
                {
                    index = 0;
                }
                tabControl.SelectedTabPage = tabControl.TabPages[index];
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        /// <summary>
        /// Tạo thêm tab mới
        /// </summary>
        /// <param name="tabControl">Tên TabControl để thêm tabpage mới vào</param>
        /// <param name="name">Tên tabpage mới</param>
        internal static void TabCreating(XtraTabControl tabControl, string name, string text, string tooltip, Form uc)
        {
            try
            {
                if (tabControl.Visible == false)
                {
                    tabControl.Visible = true;
                }
                int index = KiemTraTabpageTonTai(tabControl, name);
                if (index >= 0)
                {
                    if (tabControl.TabPages[index].PageVisible == false)
                        tabControl.TabPages[index].PageVisible = true;

                    tabControl.SelectedTabPage = tabControl.TabPages[index];
                }
                else
                {
                    KiemTraGioiHanSLTabpage(tabControl);
                    XtraTabPage tabpage = new XtraTabPage { Text = text, Name = name, Tooltip = tooltip };
                    tabControl.TabPages.Add(tabpage);
                    tabControl.SelectedTabPage = tabpage;

                    uc.Parent = tabpage;
                    uc.Show();
                    uc.Dock = DockStyle.Fill;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        /// <summary>
        /// Tạo thêm tab mới từ Tab cũ (Refresh lại tab cũ)
        /// </summary>
        /// <param name="tabControl">Xóa tab hiện tại đi và thêm tab mới</param>
        /// <param name="name">Tên tabpage mới</param>
        internal static void TabCreatingRefresh(XtraTabControl tabControl, string name, string text, string tooltip, UserControl uc)
        {
            try
            {
                if (tabControl.Visible == false)
                {
                    tabControl.Visible = true;
                }
                int index = KiemTraTabpageTonTai(tabControl, name);
                if (index >= 0)
                {
                    tabControl.TabPages.Remove(tabControl.TabPages[index]);
                }
                KiemTraGioiHanSLTabpage(tabControl);
                XtraTabPage tabpage = new XtraTabPage { Text = text, Name = name, Tooltip = tooltip };
                tabControl.TabPages.Add(tabpage);
                tabControl.SelectedTabPage = tabpage;

                uc.Parent = tabpage;
                uc.Show();
                uc.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        /// <summary>
        /// Kiểm tra tabpage có tồn tại hay không
        /// </summary>
        /// <param name="tabControlName">Tên TabControl để kiểm tra</param>
        /// <param name="tabName">Tên tabpage cần kiểm tra</param>
        internal static int KiemTraTabpageTonTai(XtraTabControl tabControlName, string tabName)
        {
            int result = -1;
            try
            {
                for (int i = 0; i < tabControlName.TabPages.Count; i++)
                {
                    if (tabControlName.TabPages[i].Name == tabName)
                    {
                        result = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }

        internal static void KiemTraGioiHanSLTabpage(XtraTabControl tabControlName)
        {
            try
            {
                if (tabControlName.TabPages.Count >= KeyTrongPhanMem.SoLuongTabPageChucNang)
                {
                    for (int i = 1; i < tabControlName.TabPages.Count - (KeyTrongPhanMem.SoLuongTabPageChucNang - 1); i++)
                    {
                        if (tabControlName.TabPages[i].ShowCloseButton != DevExpress.Utils.DefaultBoolean.False)
                        {
                            tabControlName.TabPages.Remove(tabControlName.TabPages[i]);
                            //tabControlName.SelectedTabPageIndex = tabControlName.TabPages.Count - 1;
                            System.GC.Collect();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        internal static UserControl SelectUCControlActive(string ucName)
        {
            UserControl ucResult = new UserControl();
            try
            {
                switch (ucName)
                {
                    //case "REPORT_01":
                    //    ucResult = new GUI.MenuBaoCao.ucBCTaiChinhGiaoDich_TUHU();
                    //    break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            return ucResult;
        }
    }
}
