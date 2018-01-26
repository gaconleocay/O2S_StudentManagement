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

namespace O2S_StudentManagement.GUI.MenuTrangChu
{
    public partial class ucDanhMucDungChung : UserControl
    {
        #region Khai bao
        O2S_StudentManagement.DAL.ConnectDatabase condb = new O2S_StudentManagement.DAL.ConnectDatabase();
        private DataView loaiDanhMuc { get; set; } 
        private long select_othertypelistid { get; set; }
        private long select_otherlistid { get; set; }

        #endregion
        public ucDanhMucDungChung()
        {
            InitializeComponent();
        }

        #region Load
        private void ucDanhMucDungChung_Load(object sender, EventArgs e)
        {
            try
            {
                Load_ControlDefault();
                LoadDS_LoaiDanhMuc();
                LoadDS_DanhMuc(0);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void Load_ControlDefault()
        {
            try
            {
                btnLoaiDM_Them.Enabled = true;
                btnLoaiDM_Luu.Enabled = false;
                txtLoaiDM_Ma.ReadOnly = true;
                txtLoaiDM_Ten.ReadOnly = true;

                btnDM_Them.Enabled = false;
                btnDM_Luu.Enabled = false;
                txtDM_Ma.ReadOnly = true;
                txtDM_Ten.ReadOnly = true;
                txtDM_GiaTri.ReadOnly = true;
                cboDM_LoaiDMTen.ReadOnly = true;
                cboDM_LoaiDMTen.EditValue = null;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDS_LoaiDanhMuc()
        {
            try
            {
                loaiDanhMuc = new DataView();
                string sqlgetdanhsach = "select ROW_NUMBER() OVER (ORDER BY id) as stt, id, othertypelistcode, othertypelistname, othertypeliststatus from DM_OTHERTYPELIST; ";
                DataView dataDanhSach = new DataView(condb.GetDataTable(sqlgetdanhsach));
                gridControlLoaiDM.DataSource = dataDanhSach;
                cboDM_LoaiDMTen.Properties.DataSource = dataDanhSach;
                cboDM_LoaiDMTen.Properties.DisplayMember = "othertypelistname";
                cboDM_LoaiDMTen.Properties.ValueMember = "id";
                loaiDanhMuc = dataDanhSach;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDS_DanhMuc(long othertypelist_id)
        {
            try
            {
                string SM_OTHERTYPELISTid = "";
                if (othertypelist_id != 0)
                {
                    SM_OTHERTYPELISTid = " where oty.id=" + othertypelist_id;
                }
                string sqlgetdanhsach = "select ROW_NUMBER() OVER (ORDER BY oty.othertypelistname, o.otherlistname) as stt, oty.id as othertypelist_id, oty.othertypelistcode, oty.othertypelistname, o.id, o.otherlistcode, o.otherlistname, o.otherliststatus, o.otherlistvalue from DM_OTHERTYPELIST oty inner join DM_OTHERLIST o on o.othertypelist_id=oty.id " + SM_OTHERTYPELISTid + "; ";
                DataView dataDanhSach = new DataView(condb.GetDataTable(sqlgetdanhsach));
                gridControlDM.DataSource = dataDanhSach;
                cboDM_LoaiDMTen.Properties.DataSource = this.loaiDanhMuc;
                cboDM_LoaiDMTen.Properties.DisplayMember = "othertypelistname";
                cboDM_LoaiDMTen.Properties.ValueMember = "id";
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Loai danh muc
        private void btnLoaiDM_Them_Click(object sender, EventArgs e)
        {
            try
            {
                this.select_othertypelistid = 0;
                btnLoaiDM_Them.Enabled = true;
                btnLoaiDM_Luu.Enabled = true;
                txtLoaiDM_Ma.ReadOnly = false;
                txtLoaiDM_Ten.ReadOnly = false;
                txtLoaiDM_Ma.Text = "";
                txtLoaiDM_Ten.Text = "";

                btnDM_Them.Enabled = false;
                btnDM_Luu.Enabled = false;
                txtDM_Ma.ReadOnly = true;
                txtDM_Ten.ReadOnly = true;
                txtDM_GiaTri.ReadOnly = true;
                txtDM_Ma.Text = "";
                txtDM_Ten.Text = "";
                txtDM_GiaTri.Text = "";
                cboDM_LoaiDMTen.ReadOnly = true;
                cboDM_LoaiDMTen.EditValue = null;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnLoaiDM_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLoaiDM_Ma.Text.Trim() != "" && txtLoaiDM_Ten.Text.Trim() != "")
                {
                    if (this.select_othertypelistid == 0)
                    {
                        string kiemtratontai = "select id from DM_OTHERTYPELIST where othertypelistcode='" + txtLoaiDM_Ma.Text.Trim().ToUpper() + "';";
                        DataView dataDanhSach = new DataView(condb.GetDataTable(kiemtratontai));
                        if (dataDanhSach != null && dataDanhSach.Count > 0)
                        {
                            O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.KHONG_THE_SU_DUNG_MA_NAY);
                            frmthongbao.Show();
                        }
                        else //them moi
                        {
                            string insert = "INSERT INTO DM_OTHERTYPELIST(othertypelistcode, othertypelistname) VALUES (N'" + txtLoaiDM_Ma.Text.Trim().ToUpper() + "', N'" + txtLoaiDM_Ten.Text.Trim() + "'); ";
                            if (condb.ExecuteNonQuery(insert))
                            {
                                O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                                frmthongbao.Show();
                            }
                        }
                    }
                    else//cap nhat
                    {
                        string insert = "UPDATE DM_OTHERTYPELIST SET othertypelistname=N'" + txtLoaiDM_Ten.Text.Trim() + "' WHERE id=" + this.select_othertypelistid + "; ";
                        if (condb.ExecuteNonQuery(insert))
                        {
                            O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                            frmthongbao.Show();
                        }
                    }
                    LoadDS_LoaiDanhMuc();
                }
                else
                {
                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridControlLoaiDM_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewLoaiDM.RowCount > 0)
                {
                    var rowHandle = gridViewLoaiDM.FocusedRowHandle;

                    this.select_othertypelistid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewLoaiDM.GetRowCellValue(rowHandle, "id").ToString());
                    txtLoaiDM_Ma.Text = gridViewLoaiDM.GetRowCellValue(rowHandle, "othertypelistcode").ToString();
                    txtLoaiDM_Ten.Text = gridViewLoaiDM.GetRowCellValue(rowHandle, "othertypelistname").ToString();
                    btnLoaiDM_Them.Enabled = true;
                    btnLoaiDM_Luu.Enabled = true;
                    txtLoaiDM_Ma.ReadOnly = true;
                    txtLoaiDM_Ten.ReadOnly = false;
                    LoadDS_DanhMuc(this.select_othertypelistid);

                    btnDM_Them.Enabled = true;
                    btnDM_Luu.Enabled = true;
                    txtDM_Ma.ReadOnly = true;
                    txtDM_Ten.ReadOnly = true;
                    txtDM_GiaTri.ReadOnly = true;
                    txtDM_Ma.Text = "";
                    txtDM_Ten.Text = "";
                    txtDM_GiaTri.Text = "";
                    cboDM_LoaiDMTen.ReadOnly = true;
                    cboDM_LoaiDMTen.EditValue = null;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Danh muc
        private void btnDM_Them_Click(object sender, EventArgs e)
        {
            try
            {
                this.select_otherlistid = 0;
                btnLoaiDM_Them.Enabled = false;
                btnLoaiDM_Luu.Enabled = false;
                txtLoaiDM_Ma.ReadOnly = true;
                txtLoaiDM_Ten.ReadOnly = true;
                txtLoaiDM_Ma.Text = "";
                txtLoaiDM_Ten.Text = "";

                btnDM_Them.Enabled = true;
                btnDM_Luu.Enabled = true;
                txtDM_Ma.ReadOnly = false;
                txtDM_Ten.ReadOnly = false;
                txtDM_GiaTri.ReadOnly = false;
                txtDM_Ma.Text = "";
                txtDM_Ten.Text = "";
                txtDM_GiaTri.Text = "";
                cboDM_LoaiDMTen.ReadOnly = false;
                cboDM_LoaiDMTen.EditValue = null;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnDM_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDM_Ma.Text.Trim() != "" && txtDM_Ten.Text.Trim() != "" && cboDM_LoaiDMTen.EditValue != null)
                {
                    if (this.select_otherlistid == 0)
                    {
                        string kiemtratontai = "select id from DM_OTHERLIST where otherlistcode='" + txtDM_Ma.Text.Trim().ToUpper() + "';";
                        DataView dataDanhSach = new DataView(condb.GetDataTable(kiemtratontai));
                        if (dataDanhSach != null && dataDanhSach.Count > 0)
                        {
                            O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.KHONG_THE_SU_DUNG_MA_NAY);
                            frmthongbao.Show();
                        }
                        else //them moi
                        {
                            string insert = "INSERT INTO DM_OTHERLIST(otherlistcode, otherlistname, othertypelist_id, otherlistvalue) VALUES (N'" + txtDM_Ma.Text.Trim().ToUpper() + "', N'" + txtDM_Ten.Text.Trim() + "', N'" + cboDM_LoaiDMTen.EditValue.ToString() + "', '" + txtDM_GiaTri.Text.Trim().ToUpper() + "'); ";
                            if (condb.ExecuteNonQuery(insert))
                            {
                                O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.THEM_MOI_THANH_CONG);
                                frmthongbao.Show();
                            }
                        }
                    }
                    else//cap nhat
                    {
                        string insert = "UPDATE DM_OTHERLIST SET otherlistname=N'" + txtDM_Ten.Text.Trim() + "', otherlistvalue=N'" + txtDM_GiaTri.Text.Trim() + "' WHERE id=" + this.select_otherlistid + "; ";
                        if (condb.ExecuteNonQuery(insert))
                        {
                            O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.CAP_NHAT_THANH_CONG);
                            frmthongbao.Show();
                        }
                    }
                    LoadDS_DanhMuc(Common.TypeConvert.TypeConvertParse.ToInt64(cboDM_LoaiDMTen.EditValue.ToString()));
                }
                else
                {
                    O2S_StudentManagement.Utilities.ThongBao.frmThongBao frmthongbao = new O2S_StudentManagement.Utilities.ThongBao.frmThongBao(O2S_StudentManagement.Base.ThongBaoLable.VUI_LONG_NHAP_DAY_DU_THONG_TIN);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void gridControlDM_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDM.RowCount > 0)
                {
                    var rowHandle = gridViewDM.FocusedRowHandle;

                    this.select_otherlistid = Common.TypeConvert.TypeConvertParse.ToInt64(gridViewDM.GetRowCellValue(rowHandle, "id").ToString());
                    txtDM_Ma.Text = gridViewDM.GetRowCellValue(rowHandle, "otherlistcode").ToString();
                    txtDM_Ten.Text = gridViewDM.GetRowCellValue(rowHandle, "otherlistname").ToString();
                    cboDM_LoaiDMTen.EditValue = gridViewDM.GetRowCellValue(rowHandle, "othertypelist_id");
                    txtDM_GiaTri.Text = gridViewDM.GetRowCellValue(rowHandle, "otherlistvalue").ToString();
                    btnDM_Them.Enabled = true;
                    btnDM_Luu.Enabled = true;
                    txtDM_Ma.ReadOnly = true;
                    txtDM_Ten.ReadOnly = false;
                    txtDM_GiaTri.ReadOnly = false;
                    cboDM_LoaiDMTen.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Custom
        private void gridViewLoaiDM_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
