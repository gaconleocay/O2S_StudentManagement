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
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmLapPhieuGhiDanh : Form
    {
        #region Khai bao
        private Thread thHocVien;
        private string maPhieu;
        private string MaHocVienSelect;
        private string MaKhoaHoc;
        private bool isSave = false;
        List<PhieThu_KhoanKhacDTO> lstKhoanKhac { get; set; }

        #endregion

        public frmLapPhieuGhiDanh()
        {
            InitializeComponent();
        }

        #region Load
        private void frmLapPhieuGhiDanh_Load(object sender, EventArgs e)
        {
            try
            {
                date_TuNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                date_DenNgay.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                cboKhoaHoc.DataSource = KhoaHoc.SelectTheoCoCo();
                cboKhoaHoc.DisplayMember = "TenKhoaHoc";
                LoadPhieuGhiDanh();
                LoadKhoanKhacMacDinh();
                LoadDanhSachHocVien();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
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
        private void LoadKhoanKhacMacDinh()
        {
            try
            {
                this.lstKhoanKhac = new List<PhieThu_KhoanKhacDTO>();
                PhieThu_KhoanKhacDTO _new = new PhieThu_KhoanKhacDTO();
                _new.stt = 1;
                this.lstKhoanKhac.Add(_new);

                gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadDanhSachHocVien()
        {
            thHocVien = new Thread(() =>
            {
                //thPhieuGhiDanh.Join();
                object source = HocVien.SelectTheoCoSo(date_TuNgay.DateTime, date_DenNgay.DateTime);

                gridControlDSHocVien.Invoke((MethodInvoker)delegate
                {
                    gridControlDSHocVien.DataSource = source;
                });
            });
            thHocVien.Start();
        }
        #endregion

        public void ValidateSearch()
        {
            //if (rdMaHV.Checked && txtMaHV.Text == string.Empty)
            //    throw new ArgumentException("Mã học viên không được trống");
            //if (rdTenHocVien.Checked && txtTenHocVien.Text == string.Empty)
            //    throw new ArgumentException("Họ và tên học viên không được trống");
        }

        public void ValidatePhieu()
        {
            var rowHandle = gridViewKhoanKhac.FocusedRowHandle;
            var f = DangKy.SelectAll(gridViewKhoanKhac.GetRowCellValue(rowHandle, "MaHocVien").ToString());

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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachHocVien();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridPhieuGhiDanh_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridPhieuGhiDanh.Rows.Count);
        }

        private void gridPhieuGhiDanh_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridPhieuGhiDanh.Rows.Count);
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatePhieu();
                var rowHandle = gridViewKhoanKhac.FocusedRowHandle;
                MaKhoaHoc = ((KHOAHOC)cboKhoaHoc.SelectedValue).MaKhoaHoc;
                PhieuGhiDanh.Insert(new PHIEUGHIDANH()
                {
                    MaPhieu = maPhieu,
                    NgayGhiDanh = DateTime.ParseExact(dateNgayGhiDanh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DaDong = numDaDong.Value,
                    ConNo = Common.TypeConvert.TypeConvertParse.ToDecimal(numConNo.Text),
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
                    MaHocVien = MaHocVienSelect,
                    MaKhoaHoc = MaKhoaHoc,
                    MaPhieu = maPhieu
                });

                MessageBox.Show(string.Format("Phiếu ghi danh {0} đã được thêm thành công", maPhieu), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var h = HocVien.Select(MaHocVienSelect);
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

                DANGKY d = DangKy.Select(MaHocVienSelect, MaKhoaHoc, maPhieu);

                List<ReportParameter> _params = new List<ReportParameter>()
                {
                    new ReportParameter("CenterName", GlobalSettings.CenterName),
                    new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                    new ReportParameter("MaHocVien", MaHocVienSelect),
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
        private void gridControlDSHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                isSave = false;
                numDaDong.Value = 0;
                var rowHandle = gridViewKhoanKhac.FocusedRowHandle;
                this.MaHocVienSelect = gridViewKhoanKhac.GetRowCellValue(rowHandle, "MaHocVien").ToString();
                lblMaHocVien.Text = this.MaHocVienSelect;

                lblTenHocVien.Text = gridViewKhoanKhac.GetRowCellValue(rowHandle, "TenHocVien").ToString();




            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void repositoryItemButton_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var rowHandle = gridViewKhoanKhac.FocusedRowHandle;
                int _stt = Common.TypeConvert.TypeConvertParse.ToInt32(gridViewKhoanKhac.GetRowCellValue(rowHandle, "stt").ToString());
                PhieThu_KhoanKhacDTO _delete = this.lstKhoanKhac.Where(o => o.stt == _stt).FirstOrDefault();
                this.lstKhoanKhac.Remove(_delete);
                gridControlKhoanKhac.DataSource = null;
                gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
                if (this.lstKhoanKhac == null || this.lstKhoanKhac.Count > 0)
                {
                    PhieThu_KhoanKhacDTO _new = new PhieThu_KhoanKhacDTO();
                    _new.stt = 1;
                    gridControlKhoanKhac.DataSource = null;
                    gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void repositoryItemButton_them_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                PhieThu_KhoanKhacDTO _new = new PhieThu_KhoanKhacDTO();
                _new.stt = this.lstKhoanKhac.Count + 1;
                this.lstKhoanKhac.Add(_new);
                gridControlKhoanKhac.DataSource = null;
                gridControlKhoanKhac.DataSource = this.lstKhoanKhac;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Custom
        private void cboKhoaHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            numHocPhi.Text = Common.Number.NumberConvert.NumberToString(((KHOAHOC)cboKhoaHoc.SelectedValue).HocPhi ?? 0, 0);

            numDaDong.Maximum = Common.TypeConvert.TypeConvertParse.ToDecimal(numHocPhi.Text);
            numConNo.Text = Common.Number.NumberConvert.NumberToString((Common.TypeConvert.TypeConvertParse.ToDecimal(numHocPhi.Text) - numDaDong.Value), 0);
        }
        private void numDaDong_ValueChanged(object sender, EventArgs e)
        {
            numConNo.Text = Common.Number.NumberConvert.NumberToString((Common.TypeConvert.TypeConvertParse.ToDecimal(numHocPhi.Text) - numDaDong.Value), 0);
        }
        private void gridViewDSHocVien_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                lblTongCongHV.Text = string.Format("Tổng cộng: {0} kết quả", gridViewDSHocVien.RowCount);

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        private void gridViewKhoanKhac_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void gridViewDSHocVien_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    e.Appearance.BackColor = Color.DodgerBlue;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
