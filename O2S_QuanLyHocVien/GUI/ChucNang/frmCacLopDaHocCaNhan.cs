// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmCacLopDaHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmCacLopDaHocCaNhan : Form
    {
        public frmCacLopDaHocCaNhan()
        {
            InitializeComponent();
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.CacLopDaHoc = null;
        }

        private void frmCacLopDaHoc_Load(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.MaxDate = DateTime.Now;
            KhoaHocFilter _filter = new KhoaHocFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            cboKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
            cboKhoaHoc.DisplayMember = "TenKhoaHoc";
            cboKhoaHoc.ValueMember = "KhoaHocId";

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
            gridLop.DataSource = BangDiemLogic.SelectDSLop(GlobalSettings.UserID, rdKhoangThoiGian.Checked ? (DateTime?)DateTime.ParseExact(dateTuNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                rdKhoangThoiGian.Checked ? (DateTime?)DateTime.ParseExact(dateDenNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null, rdKhoaHoc.Checked ? O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString()) : 0);

            gridLop_Click(sender, e);
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            rdKhoangThoiGian.Checked = true;
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = BangDiemLogic.SelectDSLop(GlobalSettings.UserID, null, null, 0);

            gridLop_Click(sender, e);
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = BangDiemLogic.SelectDetail(GlobalSettings.UserID, O2S_Common.TypeConvert.Parse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()));
                lblTenLop.Text = temp.TenLopHoc;
                lblMaLop.Text = temp.LopHocId.ToString();
                lblTenKhoaHoc.Text = temp.TenKhoaHoc;
                lblNgayBD.Text = temp.NgayBatDau.Value.ToShortDateString();
                lblNgayKT.Text = temp.NgayKetThuc.Value.ToShortDateString();
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
