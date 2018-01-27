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
using O2S_StudentManagement.DAL;
using System.Globalization;

namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    public partial class ucQLHVNV_TTHocVien : UserControl
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion

        public ucQLHVNV_TTHocVien()
        {
            InitializeComponent();
        }

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
                string _trangthai = "";
                if (cboTrangThai.Text == "Đang học")
                {
                    _trangthai = " and trangthai_id=" + Base.TT_SM_STUDENT.trangthai_danghoc.ToString();
                }
                else if (cboTrangThai.Text == "Tiếp nhận hồ sơ")
                {
                    _trangthai = " and trangthai_id=" + Base.TT_SM_STUDENT.trangthai_tiepnhan.ToString();
                }
                else if (cboTrangThai.Text == "Kết thúc")
                {
                    _trangthai = " and trangthai_id=" + Base.TT_SM_STUDENT.trangthai_ketthuc.ToString();
                }

                string _tungay = DateTime.ParseExact(dateTuNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string _denngay = DateTime.ParseExact(dateDenNgay.Text, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                string _sqlTKHV = "SELECT row_number () over (order by stu.last_name) as stt, stu.id, stu.studentcode, stu.full_name, (case stu.gioitinh_id when 1 then 'Nam' when 2 then 'Nữ' end) as gioitinh_name, stu.ngaysinh, dto.name_vn as dantoc_name, nng.name_vn as nghenghiep_name, (stu.thonxom + ', ' + xa.name_vn + ', ' + huy.name_vn + ', ' + tin.name_vn) as diachi, stu.cmtnd, stu.sodienthoai, stu.email, stu.ngayvao, (case stu.trangthai_id when 0 then 'Tiếp nhận hồ sơ' when 1 then 'Đang học' end) as trangthai_name, chn.name_vn as chuyennganh_name, ban.name_vn as bangcap_name FROM SM_STUDENT stu LEFT JOIN DM_TINH tin on tin.id=stu.tinh_id LEFT JOIN DM_HUYEN huy on huy.id=stu.huyen_id LEFT JOIN DM_XA xa on xa.id=stu.xa_id LEFT JOIN DM_DANTOC dto on dto.id=stu.dantoc_id LEFT JOIN DM_NGHENGHIEP nng on nng.id=stu.nghenghiep_id LEFT JOIN DM_CHUYENNGANH chn on chn.id=stu.chuyennganh_id LEFT JOIN DM_BANGCAP ban on ban.id=stu.bangcap_id WHERE stu.created_date between '" + _tungay + "' and '" + _denngay + "' "+ _trangthai + " and isremoveid=0; ";
                DataTable _dataHocVien = condb.GetDataTable(_sqlTKHV);
                if (_dataHocVien != null && _dataHocVien.Rows.Count > 0)
                {
                    gridControlDataBaoCao.DataSource = _dataHocVien;
                }
                else
                {
                    gridControlDataBaoCao.DataSource = null;
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.KHONG_CO_DU_LIEU);
                    frmthongbao.Show();
                }
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
                btnSua.PerformClick();
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
                    long _hocvienId = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDataBaoCao.GetRowCellValue(rowHandle, "id").ToString());
                    using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                    {
                        SM_STUDENT _student = db.SM_STUDENT.Where(o => o.id == _hocvienId).SingleOrDefault();
                        if (_student == null)
                        {
                            _student.isremoveid = 1;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion


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




    }
}
