// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyMonHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyMonHoc : Form
    {
        private bool isInsert = false;

        public frmQuanLyMonHoc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khóa điều khiển các control
        /// </summary>
        public void LockPanelControl()
        {
            //txtMaMonHoc.Enabled = false;
            txtTenMonHoc.Enabled = false;
            numDiemToiDa.Enabled = false;
            btnLuuThongTin.Enabled = false;
            btnHuyBo.Enabled = false;
        }

        /// <summary>
        /// Mở khóa điều khiển các control
        /// </summary>
        public void UnlockPanelControl()
        {
            txtTenMonHoc.Enabled = true;
            numDiemToiDa.Enabled = true;
            btnLuuThongTin.Enabled = true;
            btnHuyBo.Enabled = true;
        }

        /// <summary>
        /// Đặt lại giá trị của các control trong panel
        /// </summary>
        public void ResetPanelControl()
        {
            txtMaMonHoc.Text = string.Empty;
            txtTenMonHoc.Text = string.Empty;
            numDiemToiDa.Text = "0";
        }

        /// <summary>
        /// Nạp môn học lên giao diện
        /// </summary>
        /// <param name="kh">môn học</param>
        public void LoadUI(MONHOC kh)
        {
            txtMaMonHoc.Text = kh.MonHocId.ToString();
            txtTenMonHoc.Text = kh.TenMonHoc;
            numDiemToiDa.Text = kh.DiemToiDa.ToString();

        }

        /// <summary>
        /// Nạp giao diện xuống môn học
        /// </summary>
        /// <returns></returns>
        public MONHOC LoadMonHoc()
        {
            return new MONHOC()
            {
                MonHocId = Common.TypeConvert.TypeConvertParse.ToInt32(txtMaMonHoc.Text),
                TenMonHoc = txtTenMonHoc.Text,
                DiemToiDa = Common.TypeConvert.TypeConvertParse.ToDecimal(numDiemToiDa.Text),
            };
        }
        public void LoadGridMonHoc()
        {
            gridKH.DataSource = MonHocLogic.Select(new MonHocFilter());
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.QuanLyMonHoc = null;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridKH_Click(sender, e);
        }

        private void frmQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            gridKH.AutoGenerateColumns = false;

            LockPanelControl();
            LoadGridMonHoc();
            gridKH_Click(sender, e);
        }

        private void gridKH_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} môn học", gridKH.Rows.Count);
        }

        private void gridKH_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} môn học", gridKH.Rows.Count);
        }

        private void gridKH_Click(object sender, EventArgs e)
        {
            LockPanelControl();

            try
            {
                LoadUI(MonHocLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(gridKH.SelectedRows[0].Cells["clmMonHocId"].Value.ToString())));
            }
            catch
            {
                ResetPanelControl();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnlockPanelControl();
            ResetPanelControl();
            //txtMaMonHoc.Text = MonHocLogic.AutoGenerateId();
            isInsert = true;
        }

        private void gridKH_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnlockPanelControl();
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MonHocLogic.Delete(Common.TypeConvert.TypeConvertParse.ToInt32(gridKH.SelectedRows[0].Cells["clmMonHocId"].Value.ToString()));

                    MessageBox.Show("Xóa môn học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridMonHoc();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    int _monHocId = 0;
                    if (MonHocLogic.Insert(LoadMonHoc(), ref _monHocId))
                    {
                        MessageBox.Show("Thêm môn học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MonHocLogic.Update(LoadMonHoc());

                    MessageBox.Show("Sửa môn học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadGridMonHoc();
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

        #region Custom
        private void txtDiemToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion


    }
}
