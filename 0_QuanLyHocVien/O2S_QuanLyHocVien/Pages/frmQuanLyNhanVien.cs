// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyNhanVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.Popups;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }


        private void chkLoaiNV_CheckedChanged(object sender, EventArgs e)
        {
            cboLoaiNV.Enabled = chkLoaiNV.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkMaNV.Checked = true;
            txtMaNV.Text = string.Empty;
            chkLoaiNV.Checked = false;
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            //load loại nhân viên          
            cboLoaiNV.DataSource = LoaiNhanVienLogic.SelectAll();
            cboLoaiNV.DisplayMember = "TenLoaiNhanVien";
            cboLoaiNV.ValueMember = "LoaiNhanVienId";

            btnDatLai_Click(sender, e);
            btnHienTatCa_Click(sender, e);
        }

        public void ValidateSearch()
        {
            if (chkMaNV.Checked && txtMaNV.Text == string.Empty)
                throw new ArgumentException("Mã nhân viên không được trống");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.QuanLyNhanVien = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNhanVienEdit frm = new frmNhanVienEdit(null);
            frm.Text = "Thêm nhân viên mới";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void chkMaNV_CheckedChanged(object sender, EventArgs e)
        {
            txtMaNV.Enabled = chkMaNV.Checked;
        }

        private void gridNV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} nhân viên", gridNV.Rows.Count);
        }

        private void gridNV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} nhân viên", gridNV.Rows.Count);
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridNV.AutoGenerateColumns = false;
            NhanVienFilter _filter = new NhanVienFilter();
            gridNV.DataSource = NhanVienLogic.Select(_filter);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                gridNV.AutoGenerateColumns = false;
                ValidateSearch();
                NhanVienFilter _filter = new NhanVienFilter();
                _filter.NhanVienId = chkMaNV.Checked ? Common.TypeConvert.TypeConvertParse.ToInt32(txtMaNV.Text) : 0;
                _filter.LoaiNhanVienId = chkLoaiNV.Checked ? Common.TypeConvert.TypeConvertParse.ToInt32(cboLoaiNV.SelectedValue.ToString()) : 0;

                gridNV.DataSource = NhanVienLogic.Select(_filter);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmNhanVienEdit frm = new frmNhanVienEdit(NhanVienLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(gridNV.SelectedRows[0].Cells["clmNhanVienId"].Value.ToString())));
            frm.Text = "Cập nhật thông tin nhân viên";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NhanVienLogic.Delete(Common.TypeConvert.TypeConvertParse.ToInt32(gridNV.SelectedRows[0].Cells["clmNhanVienId"].Value.ToString())))
                    {
                        MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnHienTatCa_Click(sender, e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridNV_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
