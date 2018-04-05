// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmXepLop.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;
using System.Threading;
using O2S_QuanLyKhoaHoc.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmXepLop : Form
    {
        private List<PHIEUGHIDANH> dsChuaCoLop;
        private List<HOCVIEN> dsLopChuaDu;

        public frmXepLop()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nạp danh sách chưa có lớp lên giao diện
        /// </summary>
        public void LoadDSHVChuaCoLop()
        {
            gridDSHV.Rows.Clear();

            dsChuaCoLop = HocVienLogic.DanhSachChuaCoLop();

            foreach (var i in dsChuaCoLop)
            {
                string[] s = { i.HocVienId.ToString(), i.HOCVIEN.TenHocVien, i.PhieuGhiDanhId.ToString(), i.KHOAHOC.TenKhoaHoc };
                gridDSHV.Rows.Add(s);
            }
        }

        /// <summary>
        /// Nạp danh sách học viên của lớp lên giao diện
        /// </summary>
        public void LoadDSHVLopChuaDu()
        {
            try
            {
                if (cboLop.SelectedValue != null)
                {
                    int _lophocId = Common.TypeConvert.TypeConvertParse.ToInt32(cboLop.SelectedValue.ToString());
                    dsLopChuaDu = BangDiemLogic.SelectDSHV(_lophocId);

                    gridDSHVLop.Rows.Clear();
                    foreach (var i in dsLopChuaDu)
                    {
                        string[] s = { i.HocVienId.ToString(), i.TenHocVien, i.NgaySinh.ToString(), i.GioiTinh, i.Sdt, i.DiaChi, BangDiemLogic.Select(i.HocVienId, _lophocId).PhieuGhiDanhId.ToString() };
                        gridDSHVLop.Rows.Add(s);
                    }
                }
                else
                {
                    gridDSHVLop.Rows.Clear();
                }
            }
            catch(Exception ex)
            {
                gridDSHVLop.Rows.Clear();
            }
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.XepLop = null;
        }

        private void frmXepLop_Load(object sender, EventArgs e)
        {
            //load danh sách học viên chưa có lớp
            gridDSHV.AutoGenerateColumns = false;

            LoadDSHVChuaCoLop();

            //load khóa học
            KhoaHocFilter _filter = new KhoaHocFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            cboKhoa.DataSource = KhoaHocLogic.Select(_filter);
            cboKhoa.DisplayMember = "TenKhoaHoc";
            cboKhoa.ValueMember = "KhoaHocId";

            //load lớp trống của khóa
            cboLop.DataSource = LopHocLogic.DanhSachLopTrong(Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoa.SelectedValue.ToString()));
            cboLop.DisplayMember = "TenLopHoc";
            cboLop.ValueMember = "LopHocId";

            LoadDSHVLopChuaDu();

        }

        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} học viên", gridDSHV.Rows.Count);
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} học viên", gridDSHV.Rows.Count);
        }

        private void gridDSHVLop_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongHVLop.Text = string.Format("Tổng cộng: {0} học viên", gridDSHVLop.Rows.Count);
        }

        private void gridDSHVLop_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongHVLop.Text = string.Format("Tổng cộng: {0} học viên", gridDSHVLop.Rows.Count);
        }

        private void btnThemVaoLop_Click(object sender, EventArgs e)
        {
            try
            {
                HOCVIEN hv = HocVienLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(gridDSHV.SelectedRows[0].Cells["clmHocVienId"].Value.ToString()));

                if (gridDSHVLop.Rows.Count < GlobalSettings.QuyDinh["QD0000"] ||
                MessageBox.Show("Số học viên tối đa của lớp là " + GlobalSettings.QuyDinh["QD0000"] + Environment.NewLine + "Bạn có chắc sẽ thêm?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string[] s = new string[]
                    {
                        hv.HocVienId.ToString(),
                        hv.TenHocVien,
                        ((DateTime)hv.NgaySinh).ToString("dd/MM/yyyy"),
                        hv.GioiTinh,
                        hv.Sdt,
                        hv.DiaChi,
                        gridDSHV.SelectedRows[0].Cells["clmPhieuGhiDanhId"].Value.ToString()
                    };

                    gridDSHV.Rows.RemoveAt(gridDSHV.SelectedRows[0].Index);

                    gridDSHVLop.Rows.Add(s);
                }
            }
            catch { }
        }

        private void btnBoKhoiLop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var i in dsChuaCoLop)
                {
                    if (gridDSHVLop.SelectedRows[0].Cells["clmMaHVLop"].Value.ToString() == i.HocVienId.ToString())
                    {
                        string[] s = { i.HocVienId.ToString(), i.HOCVIEN.TenHocVien, i.PhieuGhiDanhId.ToString(), i.KHOAHOC.TenKhoaHoc };
                        gridDSHV.Rows.Add(s);
                        break;
                    }
                }

                gridDSHVLop.Rows.RemoveAt(gridDSHVLop.SelectedRows[0].Index);
            }
            catch { }
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            gridDSHVLop.Rows.Clear();

            LoadDSHVChuaCoLop();
        }

        private void cboKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            //load lớp trống của khóa
            cboLop.DataSource = LopHocLogic.DanhSachLopTrong(Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoa.SelectedValue.ToString()));
            cboLop.DisplayMember = "TenLopHoc";
            cboLop.ValueMember = "LopHocId";
        }

        private void btnLuuLop_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = gridDSHVLop.Rows;

                foreach (DataGridViewRow i in rows)
                {
                    bool isAdded = false;
                    foreach (var j in dsLopChuaDu)
                    {
                        if (i.Cells["clmMaHVLop"].Value.ToString() == j.MaHocVien)
                        {
                            isAdded = true;
                            break;
                        }
                    }

                    if (!isAdded)
                    {
                        BangDiemLogic.Insert(new BANGDIEM()
                        {
                            HocVienId = Common.TypeConvert.TypeConvertParse.ToInt32(i.Cells["clmMaHVLop"].Value.ToString()),
                            LopHocId = Common.TypeConvert.TypeConvertParse.ToInt32(cboLop.SelectedValue.ToString()),
                            PhieuGhiDanhId = Common.TypeConvert.TypeConvertParse.ToInt32(i.Cells["clmMaPhieuLop"].Value.ToString()),
                            CreatedDate = DateTime.Now,
                            CreatedBy = GlobalSettings.UserCode,
                            KhoaHocId = Common.TypeConvert.TypeConvertParse.ToInt32(cboKhoa.SelectedValue.ToString()),
                            TrangThai = 0,//=0: xep lop; =1: dang hoc; =99:ket thuc
                        });
                    }

                }

                LOPHOC lh = LopHocLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(cboLop.SelectedValue.ToString()));
                LopHocLogic.Update(new LOPHOC()
                {
                    LopHocId = lh.LopHocId,
                    TenLopHoc = lh.TenLopHoc,
                    NgayBatDau = lh.NgayBatDau,
                    NgayKetThuc = lh.NgayKetThuc,
                    SiSo = gridDSHVLop.Rows.Count,
                    KhoaHocId = lh.KhoaHocId,
                    DangMo = lh.DangMo
                });

                MessageBox.Show("Đã xếp lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDatLai_Click(sender, e);
                cboKhoa_SelectedValueChanged(sender, e);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboLop_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDSHVLopChuaDu();
        }

        #endregion


    }
}
