using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Aspose.Cells;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    public partial class ucQLHVDM_QuocGia : UserControl
    {
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();
        private List<DAL.DM_QUOCGIA> lstDM_QuocGia { get; set; }
        public ucQLHVDM_QuocGia()
        {
            InitializeComponent();
        }

        #region Load
        private void ucQLHVDM_QuocGia_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhMucQuocGia();
                EnableAndDisableControl();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhMucQuocGia()
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                gridControlDichVu.DataSource = null;
                using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                {
                    this.lstDM_QuocGia = db.DM_QUOCGIA.ToList();
                    if (this.lstDM_QuocGia == null || this.lstDM_QuocGia.Count > 0)
                    {
                        gridControlDichVu.DataSource = this.lstDM_QuocGia;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
            SplashScreenManager.CloseForm();
        }
        private void EnableAndDisableControl()
        {
            try
            {
                btnLuuLai.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        private void btnNhapTuExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
                {
                    this.lstDM_QuocGia = new List<DAL.DM_QUOCGIA>();
                    gridControlDichVu.DataSource = null;
                    Workbook workbook = new Workbook(openFileDialogSelect.FileName);
                    Worksheet worksheet = workbook.Worksheets[0];
                    DataTable data_Excel = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxDataRow + 1, worksheet.Cells.MaxDataColumn + 1, true);
                    data_Excel.TableName = "DATA";
                    if (data_Excel != null)
                    {
                        foreach (DataRow row in data_Excel.Rows)
                        {
                            DAL.DM_QUOCGIA _dmquocgia = new DAL.DM_QUOCGIA();
                            _dmquocgia.id = Common.TypeConvert.TypeConvertParse.ToInt32(row["STT"].ToString());
                            _dmquocgia.name_en = row["NAME_EN"].ToString();
                            _dmquocgia.name_vn = row["NAME_VN"].ToString();
                            _dmquocgia.code = row["CODE"].ToString();
                            _dmquocgia.isremove = Common.TypeConvert.TypeConvertParse.ToInt32(row["ISREMOVE"].ToString());
                            this.lstDM_QuocGia.Add(_dmquocgia);
                        }
                        gridControlDichVu.DataSource = this.lstDM_QuocGia;
                        btnLuuLai.Enabled = true;
                    }
                    else
                    {
                        Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("File excel sai định dạng cấu trúc!");
                        frmthongbao.Show();
                        btnLuuLai.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
                Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao("File excel sai định dạng cấu trúc!");
                frmthongbao.Show();
                btnLuuLai.Enabled = false;
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Utilities.ThongBao.WaitForm1));
            try
            {
                int insert_count = 0;
                int _update_count = 0;
                foreach (var item_dv in this.lstDM_QuocGia)
                {
                    try
                    {
                        using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                        {
                            //xoa
                            db.DM_QUOCGIA.Remove(item_dv);
                            if (db.SaveChanges()==1)
                            {
                                _update_count += 1;
                            }
                            //them
                            db.DM_QUOCGIA.Add(item_dv);
                            if (db.SaveChanges()==1)
                            {
                                insert_count += 1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Logging.LogSystem.Error("Loi insert ie_danhmuc_dvkt " + ex.ToString());
                        continue;
                    }
                }
                MessageBox.Show("Thêm mới [" + (insert_count - _update_count) + "/" + this.lstDM_QuocGia.Count + "]; cập nhật [" + _update_count + "] danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            SplashScreenManager.CloseForm();
            ucQLHVDM_QuocGia_Load(null, null);
        }

        #region Custom
        private void gridViewDichVu_RowCellStyle(object sender, RowCellStyleEventArgs e)
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

        #region Delete Row
        private void gridViewDichVu_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (!btnLuuLai.Enabled)
                {
                    if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                    {
                        //GridView view = sender as GridView;
                        e.Menu.Items.Clear();
                        DXMenuItem itemKiemTraDaChon = new DXMenuItem("Xóa danh mục đã chọn");
                        itemKiemTraDaChon.Image = imageCollectionDSBN.Images[0];
                        itemKiemTraDaChon.Click += new EventHandler(XoaDichVuDaChon_Click);
                        e.Menu.Items.Add(itemKiemTraDaChon);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void XoaDichVuDaChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDichVu.RowCount > 0)
                {
                    string sql_deleteDV = "";
                    foreach (var item_index in gridViewDichVu.GetSelectedRows())
                    {
                        string _id = gridViewDichVu.GetRowCellValue(item_index, "id").ToString();
                        sql_deleteDV += "DELETE FROM DM_QUOCGIA where id='" + _id + "'; ";
                    }
                    condb.ExecuteNonQuery(sql_deleteDV);
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.XOA_THANH_CONG);
                    frmthongbao.Show();
                    ucQLHVDM_QuocGia_Load(null, null);
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
