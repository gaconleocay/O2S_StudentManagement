// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyCoSo.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmDanhMucCoSoTrungTam : Form
    {
        private bool isInsert = false;

        public frmDanhMucCoSoTrungTam()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khóa điều khiển các control
        /// </summary>
        public void LockPanelControl()
        {
            txtMaCoSo.Enabled = false;
            txtTenCoSo.Enabled = false;
            txtDiaChi.Enabled = false;
            btnLuuThongTin.Enabled = false;
            btnHuyBo.Enabled = false;
        }

        /// <summary>
        /// Mở khóa điều khiển các control
        /// </summary>
        public void UnlockPanelControl()
        {
            txtTenCoSo.Enabled = true;
            txtDiaChi.Enabled = true;
            btnLuuThongTin.Enabled = true;
            btnHuyBo.Enabled = true;
        }

        /// <summary>
        /// Đặt lại giá trị của các control trong panel
        /// </summary>
        public void ResetPanelControl()
        {
            txtMaCoSo.Text = string.Empty;
            txtTenCoSo.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
        }

        /// <summary>
        /// Nạp cơ sở lên giao diện
        /// </summary>
        /// <param name="kh">cơ sở</param>
        public void LoadUI(COSOTRUNGTAM kh)
        {
            txtMaCoSo.Text = kh.CoSoId.ToString();
            txtTenCoSo.Text = kh.TenCoSo;
            txtDiaChi.Text = kh.DiaChi;

        }

        /// <summary>
        /// Nạp giao diện xuống cơ sở
        /// </summary>
        /// <returns></returns>
        public COSOTRUNGTAM LoadCoSoTrungTam()
        {
            return new COSOTRUNGTAM()
            {
               CoSoId =Common.TypeConvert.TypeConvertParse.ToInt32( txtMaCoSo.Text),
                TenCoSo = txtTenCoSo.Text,
                DiaChi = txtDiaChi.Text,
            };
        }
        public void LoadGridKhoaHoc()
        {
            gridKH.DataSource = CoSoTrungTamLogic.SelectAll();
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.QuanLyCoSo = null;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridKH_Click(sender, e);
        }

        private void frmQuanLyCoSo_Load(object sender, EventArgs e)
        {
            gridKH.AutoGenerateColumns = false;

            LockPanelControl();
            LoadGridKhoaHoc();
            gridKH_Click(sender, e);
        }

        private void gridKH_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} cơ sở", gridKH.Rows.Count);
        }

        private void gridKH_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} cơ sở", gridKH.Rows.Count);
        }

        private void gridKH_Click(object sender, EventArgs e)
        {
            LockPanelControl();

            try
            {
                LoadUI(CoSoTrungTamLogic.Select(Common.TypeConvert.TypeConvertParse.ToInt32(gridKH.SelectedRows[0].Cells["clmCoSoId"].Value.ToString())));
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
            //txtMaCoSo.Text = CoSoTrungTamLogic.AutoGenerateId();
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
                    CoSoTrungTamLogic.Delete(Common.TypeConvert.TypeConvertParse.ToInt32(gridKH.SelectedRows[0].Cells["clmCoSoId"].Value.ToString()));

                    MessageBox.Show("Xóa cơ sở thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridKhoaHoc();
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
                    CoSoTrungTamLogic.Insert(LoadCoSoTrungTam());

                    MessageBox.Show("Thêm cơ sở thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CoSoTrungTamLogic.Update(LoadCoSoTrungTam());

                    MessageBox.Show("Sửa cơ sở thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadGridKhoaHoc();
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
    }
}
