﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmThongKeNoHocVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Threading;
using O2S_QuanLyHocVien.Reports;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmThongKeNoHocVien : Form
    { 
        public frmThongKeNoHocVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tính tổng nợ
        /// </summary>
        /// <returns></returns>
        public double TongNo()
        {
            double sum = 0;
            for (int i = 0; i < gridBaoCao.Rows.Count; i++)
                sum += Convert.ToDouble(gridBaoCao.Rows[i].Cells["clmConNo"].Value);
            return sum;
        }

        private void frmThongKeNoHocVien_Load(object sender, EventArgs e)
        {
            gridBaoCao.AutoGenerateColumns = false;

            Thread th = new Thread(() =>
            {
                object source = PhieuGhiDanh.ThongKeDanhSachNoHocPhi();

                gridBaoCao.Invoke((MethodInvoker)delegate
                {
                    gridBaoCao.DataSource = source;
                });
            });

            th.Start();           
        }

        private void gridBaoCao_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên còn nợ. Tổng nợ: {1:C0}",gridBaoCao.Rows.Count,TongNo());
        }

        private void gridBaoCao_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên còn nợ. Tổng nợ: {1:C0}", gridBaoCao.Rows.Count, TongNo());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.ThongKeNoHocVien = null;
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();

            List<ReportParameter> _params = new List<ReportParameter>()
            {
                new ReportParameter("CenterName", GlobalSettings.CenterName),
                new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                new ReportParameter("TongCong", gridBaoCao.Rows.Count.ToString()),
                new ReportParameter("TongNo", TongNo().ToString())
            };

            //frm.ReportViewer.LocalReport.ReportEmbeddedResource = "O2S_QuanLyHocVien.Reports.rptBaoCaoHocVienNo.rdlc";
            frm.ReportViewer.LocalReport.ReportPath = @"Reports\rptBaoCaoHocVienNo.rdlc";

            dsSource.dtBaoCaoNoHocVienDataTable dt = new dsSource.dtBaoCaoNoHocVienDataTable();
            var query = PhieuGhiDanh.ThongKeDanhSachNoHocPhi();
            foreach (var i in query)
            {
                dt.Rows.Add(i.MaHocVien, i.TenHocVien, i.GioiTinhHocVien, i.TenKhoaHoc,i.ConNo);
            }

            frm.ReportViewer.LocalReport.DataSources.Clear();
            frm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ds", (DataTable)dt));

            frm.ReportViewer.LocalReport.SetParameters(_params);
            frm.ReportViewer.LocalReport.DisplayName = "Thống kê học viên nợ học phí";
            frm.Text = "Thống kê học viên nợ học phí";

            frm.ShowDialog();
        }
    }
}
