// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyLopHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.Popups;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyKhoaHoc.BusinessLogic;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyLopHoc : Form
    {
        public frmQuanLyLopHoc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (chkMaLop.Checked && txtMaLop.Text == string.Empty)
                throw new ArgumentException("Mã lớp không được trống");       
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.QuanLyLopHoc = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmLopHocEdit frm = new frmLopHocEdit();
            frm.Text = "Thêm lớp mới";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void chkMaLop_CheckedChanged(object sender, EventArgs e)
        {
            txtMaLop.Enabled = chkMaLop.Checked;
        }

        private void chkKhoa_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoa.Enabled = chkKhoa.Checked;
        }

        private void chkTinhTrang_CheckedChanged(object sender, EventArgs e)
        {
            rdMo.Enabled = rdDong.Enabled = chkTinhTrang.Checked;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();
                LopHocFilter _filter = new LopHocFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;
                _filter.LopHocId = chkMaLop.Checked ? Common.TypeConvert.TypeConvertParse.ToInt32(txtMaLop.Text) : 0;
                _filter.KhoaHocId = chkKhoa.Checked ? Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoa.SelectedValue.ToString()) : 0;
                _filter.DangMo = chkTinhTrang.Checked ? (bool?)rdMo.Checked : null;

                gridLop.DataSource = LopHocLogic.Select(_filter);
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

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkMaLop.Checked = true;
            txtMaLop.Text = string.Empty;
            chkKhoa.Checked = false;
            chkTinhTrang.Checked = false;
        }

        private void frmQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            KhoaHocFilter _filter = new KhoaHocFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            cboKhoa.DataSource = KhoaHocLogic.Select(_filter);
            cboKhoa.DisplayMember = "TenKhoaHoc";
            cboKhoa.ValueMember = "KhoaHocId";

            btnDatLai_Click(sender, e);

            gridLop.AutoGenerateColumns = false;
            btnHienTatCa_Click(sender, e);
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            LopHocFilter _filter = new LopHocFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            gridLop.DataSource = LopHocLogic.Select(_filter);

            gridLop_Click(sender, e);
        }

        private void gridLop_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} lớp", gridLop.Rows.Count);
        }

        private void gridLop_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} lớp", gridLop.Rows.Count);
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                LOPHOC lop = LopHocLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()));

                lblTenLop.Text = lop.TenLopHoc;
                lblMaLop.Text = lop.MaLopHoc;
                lblKhoa.Text = lop.KHOAHOC.TenKhoaHoc;
                lblSiSo.Text = lop.SiSo.ToString();
                lblNgayBatDau.Text = lop.NgayBatDau.ToString();
                lblNgayKetThuc.Text = lop.NgayKetThuc.ToString();
            }
            catch { }
        }

        private void gridLop_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmLopHocEdit frm = new frmLopHocEdit(LopHocLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString())));
            frm.Text = "Cập nhật thông tin lớp";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LopHocLogic.Delete(Common.TypeConvert.TypeConvertParse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()));

                    MessageBox.Show("Xóa lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnHienTatCa_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void txtMaLop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
