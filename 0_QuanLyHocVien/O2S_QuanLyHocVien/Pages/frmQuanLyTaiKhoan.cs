﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyTaiKhoan.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (chkTen.Checked && txtTen.Text == string.Empty)
                throw new ArgumentException("Tên đăng nhập không được trống");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.QuanLyTaiKhoan = null; 
        }

        private void chkTen_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.Enabled = chkTen.Checked;
        }

        private void chkLoaiTK_CheckedChanged(object sender, EventArgs e)
        {
            cboLoaiTK.Enabled = chkLoaiTK.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkTen.Checked = true;
            txtTen.Text = string.Empty;
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            cboLoaiTK.Items.AddRange(new string[]
            {
                "Nhân viên",
                "Học viên",
                "Giảng viên"
            });
            cboLoaiTK.SelectedIndex = 0;

            btnDatLai_Click(sender, e);
            gridKetQua.AutoGenerateColumns = false;
            btnXemTatCa_Click(sender, e);
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            gridKetQua.DataSource = TaiKhoan.SelectAll(null, null);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                gridKetQua.DataSource = TaiKhoan.SelectAll(chkTen.Checked ? txtTen.Text : null, chkLoaiTK.Checked ? (UserType?)cboLoaiTK.SelectedIndex : null);
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

        private void gridKetQua_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenDangNhap.Text = gridKetQua.SelectedRows[0].Cells["clmTenDangNhap"].Value.ToString();
                txtMatKhau.Text = gridKetQua.SelectedRows[0].Cells["clmMatKhau"].Value.ToString();
            }
            catch { }
        }

        private void gridKetQua_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} kết quả", gridKetQua.Rows.Count);
        }

        private void gridKetQua_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} kết quả", gridKetQua.Rows.Count);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = txtMatKhau.Text = string.Empty;
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan.Update(new TAIKHOAN()
                {
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = txtMatKhau.Text,
                });

                MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXemTatCa_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
