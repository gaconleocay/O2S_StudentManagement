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
            try
            {
                cboCoSo.DataSource = CoSoTrungTamLogic.SelectAll();
                cboCoSo.DisplayMember = "TenCoSo";
                cboCoSo.ValueMember = "CoSoId";

                cboCoSo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Events
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cboCoSo.Text))
                    throw new ArgumentException("Cơ sở không được trống");

                GlobalSettings.CoSoId = Common.TypeConvert.TypeConvertParse.ToInt32(cboCoSo.SelectedValue.ToString());
                GlobalSettings.TenCoSo = cboCoSo.Text;
                //this.Hide();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion
    }
}
