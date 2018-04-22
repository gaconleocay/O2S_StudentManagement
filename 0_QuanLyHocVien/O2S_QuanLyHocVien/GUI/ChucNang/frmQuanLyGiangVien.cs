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
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyGiangVien : Form
    {
        public frmQuanLyGiangVien()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyGiangVien_Load(object sender, EventArgs e)
        {
            btnDatLai_Click(sender, e);
            btnHienTatCa_Click(sender, e);
            gridGV_Click(sender, e);
        }


        #endregion

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

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkMaGV.Checked = true;
            txtMaGV.Text = string.Empty;
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            GiangVienFilter _filter = new GiangVienFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            gridGV.AutoGenerateColumns = false;
            gridGV.DataSource = GiangVienLogic.Select(_filter);
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
                    int _GiangVienId = Common.TypeConvert.TypeConvertParse.ToInt32(gridGV.SelectedRows[0].Cells["clmGiangVienId"].Value.ToString());

                    ValidateXoa(_GiangVienId);

                    if (GiangVienLogic.Delete(_GiangVienId))
                    {
                        MessageBox.Show("Xóa giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    btnHienTatCa_Click(sender, e);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridGV_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
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
        #endregion

        #region Process
        private void ValidateXoa(int _GiangVienId)
        {
            //kiem tra neu giang vien: co GIANGDAY + XEPLICHHOC thi khong cho xoa
            GiangDayFilter _filter = new GiangDayFilter();
            _filter.GiangVienId = Common.TypeConvert.TypeConvertParse.ToInt32(gridGV.SelectedRows[0].Cells["clmGiangVienId"].Value.ToString());
            List<GiangDay_PlusDTO> _lstGiangDay = GiangDayLogic.Select(_filter);
            if (_lstGiangDay != null && _lstGiangDay.Count > 0)
            {
                throw new ArgumentException("Giảng viên đã được xếp lịch giảng dạy");
            }
            XepLichHocFilter _filter_xlh = new XepLichHocFilter();
            _filter_xlh.GiaoVien_ChinhId = _GiangVienId;
            _filter_xlh.GiaoVien_TroGiangId = _GiangVienId;
            List<XEPLICHHOC> _lstXepLichHoc = XepLichHocLogic.SelectTheoGiangVien(_filter_xlh);
            if (_lstXepLichHoc != null && _lstXepLichHoc.Count > 0)
            {
                throw new ArgumentException("Giảng viên đã được xếp lịch giảng dạy");
            }
        }
        #endregion
        #region Custom
        private void chkMaGV_CheckedChanged(object sender, EventArgs e)
        {
            txtMaGV.Enabled = chkMaGV.Checked;
        }

        private void txtMaGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void gridLop_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongLop.Text = string.Format("Tổng cộng: {0} lớp", gridLop.Rows.Count);
        }

        private void gridLop_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongLop.Text = string.Format("Tổng cộng: {0} lớp", gridLop.Rows.Count);
        }
        private void gridGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongGV.Text = string.Format("Tổng cộng: {0} giảng viên", gridGV.Rows.Count);
        }

        private void gridGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongGV.Text = string.Format("Tổng cộng: {0} giảng viên", gridGV.Rows.Count);

        }

        #endregion
    }
}
