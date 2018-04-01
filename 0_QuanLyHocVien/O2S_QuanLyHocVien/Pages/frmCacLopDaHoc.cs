// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmCacLopDaHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using System.Globalization;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmCacLopDaHoc : Form
    {
        public frmCacLopDaHoc()
        {
            InitializeComponent();
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.CacLopDaHoc = null;
        }

        private void frmCacLopDaHoc_Load(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.MaxDate = DateTime.Now;

            cboKhoaHoc.DataSource = KhoaHoc.SelectTheoCoCo();
            cboKhoaHoc.DisplayMember = "TenKhoaHoc";
            cboKhoaHoc.ValueMember = "MaKhoaHoc";

            gridLop.AutoGenerateColumns = false;

            btnDatLai_Click(sender, e);
            btnXemTatCa_Click(sender, e);
        }

        private void rdKhoangThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            dateTuNgay.Enabled = dateDenNgay.Enabled = rdKhoangThoiGian.Checked;
        }

        private void rdKhoaHoc_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoaHoc.Enabled = rdKhoaHoc.Checked;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = BangDiem.SelectDSLop(GlobalSettings.UserID, rdKhoangThoiGian.Checked ? (DateTime?)DateTime.ParseExact(dateTuNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                rdKhoangThoiGian.Checked ? (DateTime?)DateTime.ParseExact(dateDenNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null, rdKhoaHoc.Checked ? cboKhoaHoc.SelectedValue.ToString() : null);

            gridLop_Click(sender, e);
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            rdKhoangThoiGian.Checked = true;
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = BangDiem.SelectDSLop(GlobalSettings.UserID, null, null, null);

            gridLop_Click(sender, e);
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = BangDiem.SelectDetail(GlobalSettings.UserID, gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());
                lblTenLop.Text = temp.TenLop;
                lblMaLop.Text = temp.MaLop;
                lblTenKhoaHoc.Text = temp.TenKhoaHoc;
                lblNgayBD.Text = temp.NgayBD.Value.ToShortDateString();
                lblNgayKT.Text = temp.NgayKT.Value.ToShortDateString();
                lblSiSo.Text = temp.SiSo.ToString();
                lblTinhTrang.Text = (bool)temp.DangMo ? "Đang mở" : "Đã đóng";
                lblDiemTB.Text = temp.DiemTrungBinh.ToString();
            }
            catch
            {
                lblTenLop.Text = string.Empty;
                lblMaLop.Text = string.Empty;
                lblTenKhoaHoc.Text = string.Empty;
                lblNgayBD.Text = string.Empty;
                lblNgayKT.Text = string.Empty;
                lblSiSo.Text = string.Empty;
                lblTinhTrang.Text = string.Empty;
                lblDiemTB.Text = string.Empty;
            }
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.Value;
        }
        #endregion
    }
}
