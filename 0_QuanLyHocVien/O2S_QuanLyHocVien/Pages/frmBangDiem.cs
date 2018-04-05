// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmBangDiem.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using O2S_QuanLyHocVien.Reports;
using System.Data;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmBangDiem : Form
    {
        private bool isLoaded = false;

        public frmBangDiem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nạp bảng điểm lên giao diện
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="maLop">Mã lớp</param>
        public void LoadBangDiem(int maHV, int maLop)
        {
            try
            {
                var bangDiem = BangDiemLogic.SelectDetail(maHV, maLop);
                lblTenLop.Text = bangDiem.TenLop;
                lblTenKhoaHocoa.Text = bangDiem.TenKhoaHoc;
                lblDiemTrungBinh.Text = bangDiem.DiemTrungBinh.ToString("N2");
                gridControlDSDiem.DataSource = bangDiem.BangDiemChiTiets;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.BangDiem = null;
        }

        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            lblTitle.Text = string.Format("Bảng điểm của {0}", TaiKhoanLogic.FullUserName(new TAIKHOAN() { TenDangNhap = GlobalSettings.UserCode }));
            cboLop.DataSource = BangDiemLogic.SelectDSLop(GlobalSettings.UserID);
            cboLop.DisplayMember = "TenLopHoc";
            cboLop.ValueMember = "LopHocId";

            lblTenLop.Text = lblTenKhoaHocoa.Text = string.Empty;

            lblDiemTrungBinh.Text = 0.ToString();

            isLoaded = true;
            cboLop_SelectedValueChanged(sender, e);
        }

        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();

            List<ReportParameter> _params = new List<ReportParameter>()
            {
                new ReportParameter("CenterName", GlobalSettings.CenterName),
                new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                new ReportParameter("MaHocVien", GlobalSettings.UserID.ToString()),
                new ReportParameter("TenHocVien", TaiKhoanLogic.FullUserName(new TAIKHOAN() {TenDangNhap = GlobalSettings.UserCode })),
                new ReportParameter("MaLop", cboLop.SelectedValue.ToString()),
                new ReportParameter("TenLop",lblTenLop.Text),
                new ReportParameter("TenKhoaHoc", lblTenKhoaHocoa.Text),
                new ReportParameter("DiemTB",lblDiemTrungBinh.Text)
            };
            frm.ReportViewer.LocalReport.ReportPath = @"Reports\rptInBangDiem.rdlc";

            dsSource.dtBangDiemHocVienDataTable dt = new dsSource.dtBangDiemHocVienDataTable();
            for (int i = 0; i < gridViewDSDiem.RowCount; i++)
            {
                dt.Rows.Add(gridViewDSDiem.GetRowCellValue(i, "MaMonHoc").ToString(), gridViewDSDiem.GetRowCellValue(i, "TenMonHoc").ToString(), gridViewDSDiem.GetRowCellValue(i, "Diem").ToString());
            }

            //var query = BangDiem.SelectBangDiemLop(gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());
            //var bangDiem = BangDiem.SelectDetail(maHV, maLop);
            //gridControlDSDiem.DataSource = bangDiem.BangDiemChiTiets;

            //foreach (var i in query)
            //{
            //    dt.Rows.Add(i.MaHocVien, i.TenHocVien, i.DiemTrungBinh);
            //}

            frm.ReportViewer.LocalReport.DataSources.Clear();
            frm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", (DataTable)dt));

            frm.ReportViewer.LocalReport.SetParameters(_params);
            frm.ReportViewer.LocalReport.DisplayName = "Bảng điểm học viên";
            frm.Text = "Bảng điểm học viên";

            frm.ShowDialog();
        }

        private void cboLop_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLoaded)
                    LoadBangDiem(GlobalSettings.UserID,Common.TypeConvert.TypeConvertParse.ToInt32( cboLop.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion
    }
}
