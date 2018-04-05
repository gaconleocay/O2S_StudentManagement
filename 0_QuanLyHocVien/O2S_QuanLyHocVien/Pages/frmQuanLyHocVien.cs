// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmO2S_QuanLyHocVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.Popups;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Collections.Generic;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyHocVien : Form
    {
        public frmQuanLyHocVien()
        {
            InitializeComponent();
        }

        private void frmQuanLyHocVien_Load(object sender, EventArgs e)
        {
            try
            {
                cboLoaiHV.DataSource = LoaiHocVienLogic.SelectAll();
                cboLoaiHV.DisplayMember = "TenLoaiHocVien";
                cboLoaiHV.ValueMember = "LoaiHocVienId";

                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                LayDanhSachHocVien();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.QuanLyHocVien = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmHocVienEdit frm = new frmHocVienEdit(null);
            frm.Text = "Thêm học viên mới";
            frm.ShowDialog();
            LayDanhSachHocVien();
        }



        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên", gridDSHV.Rows.Count);
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên", gridDSHV.Rows.Count);
        }

        private void LayDanhSachHocVien()
        {
            try
            {
                gridDSHV.AutoGenerateColumns = false;

                HocVienFilter _filter = new HocVienFilter();
                _filter.LoaiHocVienId = Common.TypeConvert.TypeConvertParse.ToInt32(cboLoaiHV.SelectedValue.ToString());
                _filter.NgayTiepNhan_Tu = date_TuNgay.DateTime;
                _filter.NgayTiepNhan_Den = date_DenNgay.DateTime;

                List<HocVien_PlusDTO> _lsthocvien = HocVienLogic.Select(_filter);
                if (_lsthocvien != null && _lsthocvien.Count > 0)
                {
                    gridDSHV.DataSource = _lsthocvien;
                }

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LayDanhSachHocVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int _hocvienId = Common.TypeConvert.TypeConvertParse.ToInt32(gridDSHV.SelectedRows[0].Cells["clmHocVienId"].Value.ToString());
            frmHocVienEdit frm = new frmHocVienEdit(HocVienLogic.SelectSingle(_hocvienId));
            frm.Text = "Cập nhật thông tin học viên";
            frm.ShowDialog();
            LayDanhSachHocVien();
        }

        private void gridDSHV_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int _hocvienId = Common.TypeConvert.TypeConvertParse.ToInt32(gridDSHV.SelectedRows[0].Cells["clmHocVienId"].Value.ToString());
                    HocVienLogic.Delete(_hocvienId);

                    MessageBox.Show("Xóa học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayDanhSachHocVien();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
