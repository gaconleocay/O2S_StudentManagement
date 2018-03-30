// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmChonCoSo.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmChonCoSo : Form
    {
        public frmChonCoSo()
        {
            InitializeComponent();
        }

        #region Load

        private void frmChonCoSo_Load(object sender, EventArgs e)
        {
            InitializeLoaiCoSo();
        }
        public void InitializeLoaiCoSo()
        {
            cboCoSo.DataSource = CoSoTrungTam.SelectAll();
            cboCoSo.DisplayMember = "TenCoSo";
            cboCoSo.ValueMember = "MaCoSo";

            cboCoSo.SelectedIndex = 0;
        }
        #endregion

        #region Events
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cboCoSo.Text))
                    throw new ArgumentException("Cơ sở không được trống");

                GlobalSettings.MaCoSo = (string)cboCoSo.SelectedValue;
                GlobalSettings.TenCoSo = cboCoSo.Text;
                this.Hide();
                this.Visible = false;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
