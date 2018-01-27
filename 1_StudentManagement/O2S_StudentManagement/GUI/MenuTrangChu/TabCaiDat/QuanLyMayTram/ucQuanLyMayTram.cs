using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using O2S_StudentManagement.DAL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using O2S_StudentManagement.GUI.MenuTrangChu.TabCaiDat;

namespace O2S_StudentManagement.GUI.MenuTrangChu
{
    public partial class ucQuanLyMayTram : UserControl
    {
        #region Khai bao
        ConnectDatabase condb = new ConnectDatabase();

        #endregion
        public ucQuanLyMayTram()
        {
            InitializeComponent();
        }

        #region Event
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                string _laythongtin = "SELECT row_number () over (order by lastping) as stt, clientmachineid, clientmachinecode, computername, ipaddress, appversion, (case reportstatus when 0 then 'Đã cập nhật' when 1 then 'Yêu cầu cập nhật báo cáo' end) as reportstatus, (case softstatus when 0 then 'Đã cập nhật' when 1 then 'Yêu cầu khởi động lại PM' when 2 then 'Yêu cầu tắt phần mềm' when 3 then 'Hiển thị thông báo' when 4 then 'Yêu cầu khởi động sau 1 phút' end) as softstatus, thongbao, installedtime, lastping, currentusercode, currentusername, ProcessorId, MainBoardProductId, MACAddress, HDDSerialNo, BIOSserNo, OSInformation, ProcessorInformation FROM ie_clientmachine; ";
                DataTable _dataDS = condb.GetDataTable(_laythongtin);
                gridControlDSMayTram.DataSource = _dataDS;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnTatPM_Click(object sender, EventArgs e)
        {
            try
            {
                string _sqlupdate = "UPDATE ie_clientmachine SET softstatus='2';";
                if (condb.ExecuteNonQuery(_sqlupdate))
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                    frmthongbao.Show();
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnKhoiDongPM_Click(object sender, EventArgs e)
        {
            try
            {
                string _sqlupdate = "UPDATE ie_clientmachine SET softstatus='1';";
                if (condb.ExecuteNonQuery(_sqlupdate))
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                    frmthongbao.Show();
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnKhoiDongPM1Phut_Click(object sender, EventArgs e)
        {
            try
            {
                string _sqlupdate = "UPDATE ie_clientmachine SET softstatus='4';";
                if (condb.ExecuteNonQuery(_sqlupdate))
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                    frmthongbao.Show();
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnHienThiThongBao_Click(object sender, EventArgs e)
        {
            try
            {
                frmQLMayTram_ThongBao _frm = new frmQLMayTram_ThongBao();
                _frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region load
        private void ucQuanLyMayTram_Load(object sender, EventArgs e)
        {
            try
            {
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Custom
        private void gridViewDSMayTram_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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

        private void gridViewDSMayTram_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "status_img")
                {
                    string val = Convert.ToString(gridViewDSMayTram.GetRowCellValue(e.RowHandle, "medicalrecordstatus"));
                    if (val == "2")
                    {
                        e.Handled = true;
                        Point pos = Utilities.GUIGridView.Util_GUIGridView.CalcPosition(e, imageListstatus.Images[0]);
                        e.Graphics.DrawImage(imageListstatus.Images[0], pos);
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
