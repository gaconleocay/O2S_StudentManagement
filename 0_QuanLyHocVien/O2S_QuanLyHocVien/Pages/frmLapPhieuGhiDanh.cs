// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmLapPhieuGhiDanh.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Threading;
using O2S_QuanLyHocVien.Reports;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Globalization;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmLapPhieuGhiDanh : Form
    {
        private Thread thHocVien;
        private string maPhieu;
        private string maHV;
        private string MaKhoaHoc;
        private bool isSave = false;

        public frmLapPhieuGhiDanh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load các phiếu ghi danh
        /// </summary>
        public void LoadPhieuGhiDanh()
        {
            //thPhieuGhiDanh = new Thread(() =>
            //{
            object source = PhieuGhiDanh.SelectTheoCoSo();

            //gridPhieuGhiDanh.Invoke((MethodInvoker)delegate
            // {
            gridPhieuGhiDanh.DataSource = source;
            //});
            //});
            //thPhieuGhiDanh.Start();
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (rdMaHV.Checked && txtMaHV.Text == string.Empty)
                throw new ArgumentException("Mã học viên không được trống");
            if (rdTenHocVien.Checked && txtTenHocVien.Text == string.Empty)
                throw new ArgumentException("Họ và tên học viên không được trống");
        }

        /// <summary>
        /// Kiểm tra phiếu ghi danh có hợp lệ
        /// </summary>
        public void ValidatePhieu()
        {
            var f = DangKy.SelectAll(gridDSHV.SelectedRows[0].Cells["clmMaHocVien"].Value.ToString());

            foreach (var i in f)
                if (i.PHIEUGHIDANH.ConNo > 0)
                    throw new Exception("Học viên đang nợ không được phép ghi danh mới");
            if (numDaDong.Value < GlobalSettings.QuyDinh["QD0001"])
                throw new Exception(string.Format("Số tiền đóng khi ghi danh phải ít nhất bằng {0:C0}", GlobalSettings.QuyDinh["QD0001"]));
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.LapPhieuGhiDanh = null;
        }

        private void rdMaHV_CheckedChanged(object sender, EventArgs e)
        {
            txtMaHV.Enabled = rdMaHV.Checked;
        }

        private void rdTenHocVien_CheckedChanged(object sender, EventArgs e)
        {
            txtTenHocVien.Enabled = rdTenHocVien.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtMaHV.Text = txtTenHocVien.Text = string.Empty;
            rdMaHV.Checked = true;
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridDSHV.AutoGenerateColumns = false;

            thHocVien = new Thread(() =>
            {
                //thPhieuGhiDanh.Join();

                object source = HocVien.SelectTheoCoSo();

                gridDSHV.Invoke((MethodInvoker)delegate
                {
                    gridDSHV.DataSource = source;
                });
            });
            thHocVien.Start();
        }

        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} kết quả", gridDSHV.Rows.Count);
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} kết quả", gridDSHV.Rows.Count);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                if (rdMaHV.Checked)
                    gridDSHV.DataSource = HocVien.SelectAll(txtMaHV.Text, null, null, null, null, null);
                else if (rdTenHocVien.Checked)
                    gridDSHV.DataSource = HocVien.SelectAll(null, txtTenHocVien.Text, null, null, null, null);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmLapPhieuGhiDanh_Load(object sender, EventArgs e)
        {
            //load khóa học
            cboKhoaHoc.DataSource = KhoaHoc.SelectAll();
            cboKhoaHoc.DisplayMember = "TenKhoaHoc";

            //tạo mã phiếu
            txtMaPhieu.Text = PhieuGhiDanh.AutoGenerateId();

            //load danh sách phiếu
            LoadPhieuGhiDanh();

            //load danh sách học viên
            btnHienTatCa_Click(sender, e);
        }


        private void gridPhieuGhiDanh_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridPhieuGhiDanh.Rows.Count);
        }

        private void gridPhieuGhiDanh_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridPhieuGhiDanh.Rows.Count);
        }

        private void cboKhoaHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            numHocPhi.Value = (decimal)((KHOAHOC)cboKhoaHoc.SelectedValue).HocPhi;
            numDaDong.Maximum = numHocPhi.Value;
            numConNo.Value = numHocPhi.Value - numDaDong.Value;
        }

        private void numDaDong_ValueChanged(object sender, EventArgs e)
        {
            numConNo.Value = numHocPhi.Value - numDaDong.Value;
        }

        private void btnDatLaiPhieu_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Text = PhieuGhiDanh.AutoGenerateId();
            numDaDong.Value = 0;
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatePhieu();

                maPhieu = txtMaPhieu.Text;
                maHV = gridDSHV.SelectedRows[0].Cells["clmMaHocVien"].Value.ToString();
                MaKhoaHoc = ((KHOAHOC)cboKhoaHoc.SelectedValue).MaKhoaHoc;
                PhieuGhiDanh.Insert(new PHIEUGHIDANH()
                {
                    MaPhieu = maPhieu,
                    NgayGhiDanh = DateTime.ParseExact(dateNgayGhiDanh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DaDong = numDaDong.Value,
                    ConNo = numConNo.Value,
                    MaNhanVien = GlobalSettings.UserID,

                    //DANGKies = new DANGKY()
                    //{
                    //    MaHocVien = maHV,
                    //    MaKhoaHoc = MaKhoaHoc,
                    //    MaPhieu = maPhieu
                    //}

                    //DANGKies = new System.Data.Linq.EntitySet<DANGKY>()
                    //{
                    //    //MaHocVien = maHV,
                    //    //MaKhoaHoc = MaKhoaHoc,
                    //    //MaPhieu = maPhieu
                    //}

                });
                DangKy.Insert(new DANGKY()
                {
                    MaHocVien = maHV,
                    MaKhoaHoc = MaKhoaHoc,
                    MaPhieu = maPhieu
                });

                MessageBox.Show(string.Format("Phiếu ghi danh {0} đã được thêm thành công", maPhieu), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var h = HocVien.Select(maHV);
                if (h.MaLoaiHocVien == "LHV00")
                {
                    HocVien.Update(new HOCVIEN()
                    {
                        MaHocVien = h.MaHocVien,
                        TenHocVien = h.TenHocVien,
                        GioiTinhHocVien = h.GioiTinhHocVien,
                        NgaySinh = h.NgaySinh,
                        DiaChi = h.DiaChi,
                        SdtHocVien = h.SdtHocVien,
                        EmailHocVien = h.EmailHocVien,
                        NgayTiepNhan = h.NgayTiepNhan,
                        MaLoaiHocVien = "LHV01",
                        TenDangNhap = h.MaHocVien,
                    },
                    new TAIKHOAN()
                    {
                        TenDangNhap = h.MaHocVien,
                        MatKhau = h.MaHocVien
                    });
                    MessageBox.Show(string.Format("Học viên {0} đã được chuyển thành học viên chính thức với tài khoản:{1}Tên đăng nhập: {2}{3}Mật khẩu: {4}",
                        h.TenHocVien, Environment.NewLine, h.MaHocVien, Environment.NewLine, h.MaHocVien),
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                isSave = true;
                LoadPhieuGhiDanh();
                if (MessageBox.Show("Bạn có muốn in phiếu ghi danh vừa lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    btnInBienLai_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            if (isSave)
            {
                frmReport frm = new frmReport();

                DANGKY d = DangKy.Select(maHV, MaKhoaHoc, maPhieu);

                List<ReportParameter> _params = new List<ReportParameter>()
                {
                    new ReportParameter("CenterName", GlobalSettings.CenterName),
                    new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                    new ReportParameter("MaHocVien", maHV),
                    new ReportParameter("TenHocVien", d.HOCVIEN.TenHocVien),
                    new ReportParameter("TenKhoaHoc", d.KHOAHOC.TenKhoaHoc),
                    new ReportParameter("HocPhi",((decimal)d.KHOAHOC.HocPhi).ToString("C0")),
                    new ReportParameter("DaDong", ((decimal)d.PHIEUGHIDANH.DaDong).ToString("C0")),
                    new ReportParameter("ConNo", ((decimal)d.PHIEUGHIDANH.ConNo).ToString("C0")),
                };

               // frm.ReportViewer.LocalReport.ReportEmbeddedResource = "O2S_QuanLyHocVien.Reports.rptBienLaiHocPhi.rdlc";
                frm.ReportViewer.LocalReport.ReportPath = @"Reports\rptBienLaiHocPhi.rdlc";
                frm.ReportViewer.LocalReport.SetParameters(_params);
                frm.ReportViewer.LocalReport.DisplayName = "Biên lai học phí";
                frm.Text = "Biên lai học phí";

                frm.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng lưu phiếu trước khi in", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridDSHV_Click(object sender, EventArgs e)
        {
            isSave = false;
            btnDatLaiPhieu_Click(sender, e);
        }
        #endregion
    }
}
