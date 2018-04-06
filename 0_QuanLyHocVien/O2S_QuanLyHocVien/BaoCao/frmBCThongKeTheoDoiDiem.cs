// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmThongKeDiemTheoLop.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Threading;
using O2S_QuanLyHocVien.Reports;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmBCThongKeTheoDoiDiem : Form
    {
        private Thread thLop;
        private Thread thBangDiem;

        public frmBCThongKeTheoDoiDiem()
        {
            InitializeComponent();
        }

        #region Load
        private void frmThongKeDiemTheoLop_Load(object sender, EventArgs e)
        {
            gridLop.AutoGenerateColumns = false;
            btnTimKiem_Click(sender, e);
            gridLop_Click(sender, e);
        }


        #endregion

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.ThongKeDiemTheoLop = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLop.Text != "")
                {
                    thLop = new Thread(() =>
                    {
                        object source = LopHocLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(txtMaLop.Text));

                        gridLop.Invoke((MethodInvoker)delegate
                        {
                            gridLop.DataSource = source;
                        });
                    });
                }
                else
                {
                    thLop = new Thread(() =>
                    {
                        LopHocFilter _filter = new LopHocFilter();
                        _filter.CoSoId = GlobalSettings.CoSoId;
                        object source = LopHocLogic.Select(_filter);

                        gridLop.Invoke((MethodInvoker)delegate
                        {
                            gridLop.DataSource = source;
                        });
                    });
                }

                thLop.Start();
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

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                thBangDiem = new Thread(() =>
                {
                    thLop.Join();

                    object source = BangDiemLogic.SelectBangDiemLop(Common.TypeConvert.TypeConvertParse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()));

                    gridThongKe.Invoke((MethodInvoker)delegate
                    {
                        gridThongKe.DataSource = source;
                    });
                });

                thBangDiem.Start();
            }
            catch { }
        }
        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();

            List<ReportParameter> _params = new List<ReportParameter>()
            {
                new ReportParameter("CenterName", GlobalSettings.CenterName),
                new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                new ReportParameter("MaLop", gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()),
                new ReportParameter("TenLop", gridLop.SelectedRows[0].Cells["clmTenLophoc"].Value.ToString()),
                new ReportParameter("DiemTBLop", string.Format("{0:N2}",DiemTrungBinhLop()))
            };

            //frm.ReportViewer.LocalReport.ReportEmbeddedResource = "O2S_QuanLyHocVien.Reports.rptBangDiemLop.rdlc";
            frm.ReportViewer.LocalReport.ReportPath = @"Reports\rptBangDiemLop.rdlc";

            dsSource.dtBangDiemLopDataTable dt = new dsSource.dtBangDiemLopDataTable();
            var query = BangDiemLogic.SelectBangDiemLop(Common.TypeConvert.TypeConvertParse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()));
            foreach (var i in query)
            {
                dt.Rows.Add(i.MaHocVien, i.TenHocVien, i.DiemTrungBinh);
            }

            frm.ReportViewer.LocalReport.DataSources.Clear();
            frm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ds", (DataTable)dt));

            frm.ReportViewer.LocalReport.SetParameters(_params);
            frm.ReportViewer.LocalReport.DisplayName = "Bảng điểm lớp";
            frm.Text = "Thống kê điểm theo lớp";

            frm.ShowDialog();
        }
        public decimal DiemTrungBinhLop()
        {
            decimal diem = 0;
            for (int i = 0; i < gridThongKe.Rows.Count; i++)
                diem += Convert.ToDecimal(gridThongKe.Rows[i].Cells["clmDiemTrungBinh"].Value);

            return Math.Round((diem / gridThongKe.Rows.Count), 2);
        }

        private void gridThongKe_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên. Điểm trung bình của lớp: {1:N2} điểm.", gridThongKe.Rows.Count, DiemTrungBinhLop());
        }

        #endregion

        #region Cusstom
        private void txtMaLop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion






    }
}
