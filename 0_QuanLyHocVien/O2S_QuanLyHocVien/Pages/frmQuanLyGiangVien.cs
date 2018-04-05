// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyGiangVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.Popups;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyGiangVien : Form
    {
        public frmQuanLyGiangVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (chkMaGV.Checked && txtMaGV.Text == string.Empty)
                throw new ArgumentException("Mã giảng viên không được trống");

        }

        #region Events
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmGiangVienEdit frm = new frmGiangVienEdit(null);
            frm.Text = "Thêm giảng viên mới";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void chkMaGV_CheckedChanged(object sender, EventArgs e)
        {
            txtMaGV.Enabled = chkMaGV.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkMaGV.Checked = true;
            txtMaGV.Text = string.Empty;
        }

        private void frmQuanLyGiangVien_Load(object sender, EventArgs e)
        {
            btnDatLai_Click(sender, e);
            btnHienTatCa_Click(sender, e);
            gridGV_Click(sender, e);
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            GiangVienFilter _filter = new GiangVienFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            gridGV.AutoGenerateColumns = false;
            gridGV.DataSource = GiangVienLogic.Select(_filter);
        }

        private void gridGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongGV.Text = string.Format("Tổng cộng: {0} giảng viên", gridGV.Rows.Count);
        }

        private void gridGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongGV.Text = string.Format("Tổng cộng: {0} giảng viên", gridGV.Rows.Count);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmGiangVienEdit frm = new frmGiangVienEdit(GiangVienLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(gridGV.SelectedRows[0].Cells["clmGiangVienId"].Value.ToString())));
            frm.Text = "Cập nhật thông tin giảng viên";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GiangVienLogic.Delete(Common.TypeConvert.TypeConvertParse.ToInt32(gridGV.SelectedRows[0].Cells["clmGiangVienId"].Value.ToString()));

                    MessageBox.Show("Xóa giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnHienTatCa_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridGV_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void gridLop_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongLop.Text = string.Format("Tổng cộng: {0} lớp", gridLop.Rows.Count);
        }

        private void gridLop_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongLop.Text = string.Format("Tổng cộng: {0} lớp", gridLop.Rows.Count);
        }

        private void gridGV_Click(object sender, EventArgs e)
        {
            if (gridLop != null && gridLop.RowCount > 0)
            {
                GiangDayFilter _filter = new GiangDayFilter();
                _filter.GiangVienId = Common.TypeConvert.TypeConvertParse.ToInt32(gridGV.SelectedRows[0].Cells["clmGiangVienId"].Value.ToString());
                gridLop.AutoGenerateColumns = false;
                gridLop.DataSource = GiangDayLogic.Select(_filter);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();
                GiangVienFilter _filter = new GiangVienFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.GiangVienId = chkMaGV.Checked ? Common.TypeConvert.TypeConvertParse.ToInt32(txtMaGV.Text) : 0;


                gridGV.DataSource = GiangVienLogic.Select(_filter);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.QuanLyGiangVien = null;
        }
        #endregion

        private void txtMaGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
