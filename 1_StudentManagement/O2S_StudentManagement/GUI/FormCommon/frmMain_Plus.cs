using O2S_StudentManagement.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using O2S_StudentManagement.Model.Models;

namespace O2S_StudentManagement.GUI.FormCommon
{
    public partial class frmMain : Form
    {
        private void KiemTraPhanQuyenNguoiDung()
        {
            try
            {
                List<classPermission> SessionLstPhanQuyen_TabMenuQLHocVien = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.tabMenuId == 2).OrderBy(o => o.permissioncode).ToList();
                List<classPermission> SessionLstPhanQuyen_TabMenuQLHocVu = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.tabMenuId == 3).OrderBy(o => o.permissioncode).ToList();
                List<classPermission> SessionLstPhanQuyen_TabMenuQLGiaoVien = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.tabMenuId == 5).OrderBy(o => o.permissioncode).ToList();
                List<classPermission> SessionLstPhanQuyen_TabMenuTaiChinh = Base.SessionLogin.SessionLstPhanQuyenNguoiDung.Where(o => o.tabMenuId == 4).OrderBy(o => o.permissioncode).ToList();

                if (SessionLstPhanQuyen_TabMenuQLHocVien != null && SessionLstPhanQuyen_TabMenuQLHocVien.Count > 0)
                {
                    tabMenuQLHocVien.PageVisible = true;
                }
                else
                {
                    tabMenuQLHocVien.PageVisible = false;
                }
                if (SessionLstPhanQuyen_TabMenuQLHocVu != null && SessionLstPhanQuyen_TabMenuQLHocVu.Count > 0)
                {
                    tabMenuQLHocVu.PageVisible = true;
                }
                else
                {
                    tabMenuQLHocVu.PageVisible = false;
                }

                if (SessionLstPhanQuyen_TabMenuQLGiaoVien != null && SessionLstPhanQuyen_TabMenuQLGiaoVien.Count > 0)
                {
                    tabMenuQLGiaoVien.PageVisible = true;
                }
                else
                {
                    tabMenuQLGiaoVien.PageVisible = false;
                }

                if (SessionLstPhanQuyen_TabMenuTaiChinh != null && SessionLstPhanQuyen_TabMenuTaiChinh.Count > 0)
                {
                    tabMenuTaiChinh.PageVisible = true;
                }
                else
                {
                    tabMenuTaiChinh.PageVisible = false;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void EnableAndDisableTabChucNang(bool enabledisable)
        {
            try
            {
                tabMenuQLHocVien.PageVisible = enabledisable;
                tabMenuQLHocVu.PageVisible = enabledisable;
                tabMenuQLGiaoVien.PageVisible = enabledisable;
                tabMenuTaiChinh.PageVisible = enabledisable;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
                throw;
            }
        }

    }
}
