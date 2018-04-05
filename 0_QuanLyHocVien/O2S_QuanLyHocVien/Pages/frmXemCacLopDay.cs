// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmXemCacLopDay.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Globalization;
using O2S_QuanLyKhoaHoc.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmXemCacLopDay : Form
    {
        public frmXemCacLopDay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nạp lớp lên giao diện
        /// </summary>
        /// <param name="lh"></param>
        public void LoadUI(LOPHOC lh = null)
        {
            if (lh != null)
            {
                lblTenLop.Text = lh.TenLopHoc;
                lblMaLop.Text = lh.MaLopHoc;
                lblKhoa.Text = lh.KHOAHOC.TenKhoaHoc;
                lblNgayBatDau.Text = lh.NgayBatDau.Value.ToShortDateString();
                lblNgayKetThuc.Text = lh.NgayKetThuc.Value.ToShortDateString();
                lblSiSo.Text = lh.SiSo.ToString();
            }
            else
            {
                lblTenLop.Text = string.Empty;
                lblMaLop.Text = string.Empty;
                lblKhoa.Text = string.Empty;
                lblNgayBatDau.Text = string.Empty;
                lblNgayKetThuc.Text = string.Empty;
                lblSiSo.Text = string.Empty;
            }
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdKhoangThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            dateTuNgay.Enabled = dateDenNgay.Enabled = rdKhoangThoiGian.Checked;
        }

        private void rdKhoaHoc_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoaHoc.Enabled = rdKhoaHoc.Checked;
        }

        private void frmXemCacLopDay_Load(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.MaxDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //load khóa học
            KhoaHocFilter _filter = new KhoaHocFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;

            cboKhoaHoc.DataSource = KhoaHocLogic.Select(_filter);
            cboKhoaHoc.DisplayMember = "TenKhoaHoc";
            cboKhoaHoc.ValueMember = "KhoaHocId";

            gridKetQuaTimKiem.AutoGenerateColumns = false;

            btnTimKiem_Click(sender, e);
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            rdKhoangThoiGian.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            GiangDayFilter _filter = new GiangDayFilter();
            _filter.GiangVienId = GlobalSettings.UserID;
            _filter.KhoaHocId = rdKhoaHoc.Checked ? Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoaHoc.SelectedValue.ToString()) : 0;
            _filter.NgayBatDau = rdKhoangThoiGian.Checked ? (DateTime?)dateTuNgay.Value : null;
            _filter.NgayKetThuc = rdKhoangThoiGian.Checked ? (DateTime?)dateDenNgay.Value : null;
            gridKetQuaTimKiem.DataSource = GiangDayLogic.Select(_filter);
            gridKetQuaTimKiem_Click(sender, e);
        }

        private void gridKetQuaTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUI(LopHocLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(gridKetQuaTimKiem.SelectedRows[0].Cells["clmLopHocId"].Value.ToString())));
            }
            catch
            {
                LoadUI();
            }
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.Value;
        }
        #endregion
    }
}
