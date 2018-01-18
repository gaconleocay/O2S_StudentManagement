using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    public partial class ucQLHVNV_TTHocVien : UserControl
    {
        public ucQLHVNV_TTHocVien()
        {
            InitializeComponent();
        }

        #region Custom
        private void gridViewDataBaoCao_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Load
        private void ucQLHVNV_TTHocVien_Load(object sender, EventArgs e)
        {
            try
            {
                dateTuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddMonths(-5).ToString("yyyy-MM-dd") + " 00:00:00");
                dateDenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Tim kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Events
        private void gridViewDataBaoCao_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDataBaoCao.RowCount > 0)
                {
                    var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                    string _hocvienId = gridViewDataBaoCao.GetRowCellValue(rowHandle, "id").ToString();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void repositoryItemButton_ChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                btnSua.PerformClick();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                frmThongTinHocVien_ChiTiet frm_them = new frmThongTinHocVien_ChiTiet();
                frm_them.ShowDialog();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDataBaoCao.RowCount > 0)
                {
                    var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                    long _hocvienId = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDataBaoCao.GetRowCellValue(rowHandle, "id").ToString());
                    frmThongTinHocVien_ChiTiet frm_them = new frmThongTinHocVien_ChiTiet(_hocvienId);
                    frm_them.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDataBaoCao.RowCount > 0)
                {
                    var rowHandle = gridViewDataBaoCao.FocusedRowHandle;
                    string _hocvienId = gridViewDataBaoCao.GetRowCellValue(rowHandle, "id").ToString();
                    //todo
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
