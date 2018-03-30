﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyGiangVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.Popups;

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
            if (chkTenGV.Checked && txtTenGV.Text == string.Empty)
                throw new ArgumentException("Họ và tên giảng viên không được trống");
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

        private void chkTenGV_CheckedChanged(object sender, EventArgs e)
        {
            txtTenGV.Enabled = chkTenGV.Checked;
        }

        private void chkGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            cboGioiTinh.Enabled = chkGioiTinh.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkMaGV.Checked = true;
            chkTenGV.Checked = chkGioiTinh.Checked = false;
            txtMaGV.Text = txtTenGV.Text = string.Empty;
            cboGioiTinh.SelectedIndex = 0;
        }

        private void frmQuanLyGiangVien_Load(object sender, EventArgs e)
        {
            btnDatLai_Click(sender, e);
            btnHienTatCa_Click(sender, e);
            gridGV_Click(sender, e);
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridGV.AutoGenerateColumns = false;
            gridGV.DataSource = GiangVien.SelectTheoCoSo();
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
            frmGiangVienEdit frm = new frmGiangVienEdit(GiangVien.Select(gridGV.SelectedRows[0].Cells["clmMaGiangVien"].Value.ToString()));
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
                    GiangVien.Delete(gridGV.SelectedRows[0].Cells["clmMaGiangVien"].Value.ToString());

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
                gridLop.AutoGenerateColumns = false;
                gridLop.DataSource = GiangDay.Select(gridGV.SelectedRows[0].Cells["clmMaGiangVien"].Value.ToString());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                gridGV.DataSource = GiangVien.SelectAll(chkMaGV.Checked ? txtMaGV.Text : null,
                    chkTenGV.Checked ? txtTenGV.Text : null, chkGioiTinh.Checked ? cboGioiTinh.Text : null);
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
            GlobalPages.QuanLyGiangVien = null;
        }
        #endregion
    }
}
