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
using O2S_StudentManagement.Base;

namespace O2S_StudentManagement.GUI.MenuTrangChu
{
    public partial class ucCauHinhHeThong : UserControl
    {
        O2S_StudentManagement.DAL.ConnectDatabase condb = new O2S_StudentManagement.DAL.ConnectDatabase();
        string curentId = "";
        #region Load
        public ucCauHinhHeThong()
        {
            InitializeComponent();
        }

        private void ucCauHinhHeThong_Load(object sender, EventArgs e)
        {
            try
            {
                EnableAndDisableControl(false);
                LoadDanhSachOption();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void EnableAndDisableControl(bool result)
        {
            try
            {
                btnOptionOK.Enabled = result;

                txtOptionCode.ReadOnly = true;
                txtOptionName.Enabled = result;
                txtOptionValue.Enabled = result;
                txtOptionNote.Enabled = result;
                chkLook.Enabled = result;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void LoadDanhSachOption()
        {
            try
            {
                string sqldsnv = "SELECT id, optioncode, optionname, optionvalue, optionnote, optionlook FROM SM_OPTION ORDER BY id;";
                DataView dataOption = new DataView(condb.GetDataTable(sqldsnv));
                if (dataOption != null && dataOption.Count > 0)
                {
                    gridControlDSOption.DataSource = dataOption;
                }
                else
                {
                    gridControlDSOption.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        private void gridViewDSOption_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightGreen;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void gridViewDSOption_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == stt)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void HienThiThongBao(string tenThongBao)
        {
            try
            {
                O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(tenThongBao);
                frmthongbao.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewDSOption_Click(object sender, EventArgs e)
        {
            try
            {
                EnableAndDisableControl(true);
                var rowHandle = gridViewDSOption.FocusedRowHandle;
                curentId = gridViewDSOption.GetRowCellValue(rowHandle, "id").ToString();
                txtOptionCode.Text = gridViewDSOption.GetRowCellValue(rowHandle, "optioncode").ToString();
                txtOptionName.Text = gridViewDSOption.GetRowCellValue(rowHandle, "optionname").ToString();
                txtOptionValue.Text = gridViewDSOption.GetRowCellValue(rowHandle, "optionvalue").ToString();
                txtOptionNote.Text = gridViewDSOption.GetRowCellValue(rowHandle, "optionnote").ToString();

                if (gridViewDSOption.GetRowCellValue(rowHandle, "optionlook").ToString() == "1")
                {
                    chkLook.Checked = true;
                }
                else
                {
                    chkLook.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnOptionOK_Click(object sender, EventArgs e)
        {
            try
            {
                string optionlook = "0";
                if (chkLook.Checked)
                {
                    optionlook = "1";
                }
                if (curentId != "")
                {
                    string sqlupdate = "UPDATE SM_OPTION SET optionname='" + txtOptionName.Text.Trim() + "', optionvalue='" + txtOptionValue.Text.Trim() + "', optionnote='" + txtOptionNote.Text.Trim() + "', optionlook='" + optionlook + "', optiondate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', optioncreateuser='" + SessionLogin.SessionUsername + "' WHERE id='" + curentId + "'; ";
                    if (condb.ExecuteNonQuery(sqlupdate))
                    {
                        HienThiThongBao(O2S_StudentManagement.Base.ThongBaoLable.SUA_THANH_CONG);
                    }
                }
                else
                {
                    string sqlupdate = "INSERT INTO SM_OPTION(optioncode, optionname, optionvalue, optionnote, optionlook, optiondate, optioncreateuser) VALUES ('" + txtOptionCode.Text.Trim() + "', '" + txtOptionName.Text.Trim() + "', '" + txtOptionValue.Text.Trim() + "', '" + txtOptionNote.Text.Trim() + "', '" + optionlook + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + SessionLogin.SessionUsername + "');";
                    if (condb.ExecuteNonQuery(sqlupdate))
                    {
                        HienThiThongBao(O2S_StudentManagement.Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                    }
                }

                gridControlDSOption.DataSource = null;
                ucCauHinhHeThong_Load(null, null);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnOptionAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EnableAndDisableControl(true);
                txtOptionCode.ReadOnly = false;

                curentId = "";
                txtOptionCode.Text = "";
                txtOptionName.Text = "";
                txtOptionValue.Text = "";
                txtOptionNote.Text = "";
                txtOptionCode.Focus();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnOptionDefault_Click(object sender, EventArgs e)
        {
            try
            {
                //DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả option hiện tại và trở về mặc định?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                //if (hoi == DialogResult.Yes)
                //{
                //    string sql_delete_option = "delete from SM_OPTION;";
                //    string sql_default_option = "INSERT INTO SM_OPTION(optioncode, optionname, optionvalue, optionnote, optionlook, optiondate, optioncreateuser) VALUES ('ThoiGianCapNhatTbl__bndangdt_tmp', 'Thời gian tự động cập nhật dữ liệu bảng _bndangdt_tmp', '0', 'Bảng _bndangdt_tmp phục vụ báo cáo Dashboard: BC QL tổng thể khoa; BC BN nội trú. Thời gian tính bằng phút - số', '0', now(), 'Administrator'); INSERT INTO SM_OPTION(optioncode, optionname, optionvalue, optionnote, optionlook, optiondate, optioncreateuser) VALUES ('KhoangThoiGianLayDuLieu', 'Khoảng thời gian lấy dữ liệu báo cáo Dashboard', '2016-01-01 00:00:00', 'Khoảng thời gian lấy dữ liệu báo cáo Dashboard từ -> hiện tại. Định dạng: yyyy-MM-dd HH:mm:ss. VD:  2016-01-01 00:00:00. Phục vụ cho báo cáo: REPORT_08; REPORT_09', '0', now(), 'Administrator');";
                //    if (condb.ExecuteNonQuery(sql_delete_option) && condb.ExecuteNonQuery(sql_default_option))
                //    {
                //        HienThiThongBao(O2S_StudentManagement.Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                //        ucCauHinhHeThong_Load(null,null);
                //    }
                //    else
                //    {
                //        HienThiThongBao(O2S_StudentManagement.Base.ThongBaoLable.CO_LOI_XAY_RA);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


    }
}
