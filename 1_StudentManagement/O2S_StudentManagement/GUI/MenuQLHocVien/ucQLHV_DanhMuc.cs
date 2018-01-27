using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    public partial class ucQLHV_DanhMuc : UserControl
    {
        public ucQLHV_DanhMuc()
        {
            InitializeComponent();
        }

        #region Events
        private void navBarItemDM_Tinh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelControlDLHV_DM.Controls.Clear();
                ucQLHVDM_Tinh ucchon = new ucQLHVDM_Tinh();
                ucchon.Dock = System.Windows.Forms.DockStyle.Fill;
                panelControlDLHV_DM.Controls.Add(ucchon);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDM_Huyen_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelControlDLHV_DM.Controls.Clear();
                ucQLHVDM_Huyen ucchon = new ucQLHVDM_Huyen();
                ucchon.Dock = System.Windows.Forms.DockStyle.Fill;
                panelControlDLHV_DM.Controls.Add(ucchon);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDM_Xa_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelControlDLHV_DM.Controls.Clear();
                ucQLHVDM_Xa ucchon = new ucQLHVDM_Xa();
                ucchon.Dock = System.Windows.Forms.DockStyle.Fill;
                panelControlDLHV_DM.Controls.Add(ucchon);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDM_DanToc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelControlDLHV_DM.Controls.Clear();
                ucQLHVDM_DanToc ucchon = new ucQLHVDM_DanToc();
                ucchon.Dock = System.Windows.Forms.DockStyle.Fill;
                panelControlDLHV_DM.Controls.Add(ucchon);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void navBarItemDM_NgheNghiep_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                panelControlDLHV_DM.Controls.Clear();
                ucQLHVDM_NgheNghiep ucchon = new ucQLHVDM_NgheNghiep();
                ucchon.Dock = System.Windows.Forms.DockStyle.Fill;
                panelControlDLHV_DM.Controls.Add(ucchon);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion
    }
}
