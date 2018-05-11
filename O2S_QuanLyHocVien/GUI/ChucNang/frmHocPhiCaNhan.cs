// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmHocPhiHocVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmHocPhiCaNhan : Form
    {
        public frmHocPhiCaNhan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.HocPhiHocVien = null;
        }

        private void frmHocPhiHocVien_Load(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.MaxDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            btnDatLai_Click(sender, e);

            gridLop.AutoGenerateColumns = false;
            KhoaHocFilter _filter = new KhoaHocFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            cboKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
            cboKhoaHoc.DisplayMember = "TenKhoaHoc";
            cboKhoaHoc.ValueMember = "MaKhoaHoc";

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

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            rdKhoangThoiGian.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = BangDiemLogic.SelectDSLop(GlobalSettings.UserID, rdKhoangThoiGian.Checked ? (DateTime?)DateTime.ParseExact(dateTuNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                rdKhoangThoiGian.Checked ? (DateTime?)DateTime.ParseExact(dateDenNgay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                rdKhoaHoc.Checked ? O2S_Common.TypeConvert.Parse.ToInt32(cboKhoaHoc.SelectedValue.ToString()) : 0);

            gridLop_Click(sender, e);
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = BangDiemLogic.SelectDSLop(GlobalSettings.UserID);

            gridLop_Click(sender, e);
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                var f = BangDiemLogic.Select(GlobalSettings.UserID, O2S_Common.TypeConvert.Parse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()));
                lblTenLop.Text = f.LOPHOC.TenLopHoc;
                lblMaLop.Text = f.LopHocId.ToString();
                lblTenKhoaHoc.Text = f.LOPHOC.KHOAHOC.TenKhoaHoc;
                lblNgayBD.Text = f.LOPHOC.NgayBatDau.Value.ToShortDateString();
                lblNgayKT.Text = f.LOPHOC.NgayKetThuc.Value.ToShortDateString();
                lblSiSo.Text = f.LOPHOC.SiSo.ToString();
                lblDaDong.Text = ((decimal)f.PHIEUGHIDANH.DaDong).ToString("C0");
                lblConNo.Text = ((decimal)f.PHIEUGHIDANH.ConNo).ToString("C0");
                lblTongNoTatCa.Text = BangDiemLogic.TongNoCacLop(GlobalSettings.UserID).ToString("C0");
            }
            catch
            {
                lblTenLop.Text = string.Empty;
                lblMaLop.Text = string.Empty;
                lblTenKhoaHoc.Text = string.Empty;
                lblNgayBD.Text = string.Empty;
                lblNgayKT.Text = string.Empty;
                lblSiSo.Text = string.Empty;
                lblDaDong.Text = string.Empty;
                lblConNo.Text = string.Empty;
                lblTongNoTatCa.Text = string.Empty;
            }
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.Value;
        }
    }
}
