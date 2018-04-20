// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmChonCoSo.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Drawing;
using System.IO;

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

                COSOTRUNGTAM _coso = CoSoTrungTamLogic.Select(GlobalSettings.CoSoId);
                GlobalSettings.CoSo_Ten = _coso.TenCoSo;
                if (_coso.LogoCoSo != null && _coso.LogoCoSo.Length > 0)
                {
                    byte[] Empimage = (byte[])(_coso.LogoCoSo).ToArray();
                    GlobalSettings.CoSo_LogoCoSo = Image.FromStream(new MemoryStream(Empimage));
                }
                else
                { GlobalSettings.CoSo_LogoCoSo = null; }

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
