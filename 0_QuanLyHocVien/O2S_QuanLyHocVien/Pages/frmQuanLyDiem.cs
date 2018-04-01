// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyDiem.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Threading;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyDiem : Form
    {
        #region Khai bao
        private Thread thLop;
        private Thread thHocVien;
        private Thread thPanelDiem;
        private BangDiemFullDTO bangDiemFull_Click { get; set; }
        #endregion
        public frmQuanLyDiem()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyDiem_Load(object sender, EventArgs e)
        {
            lblMaLop.Text = string.Empty;
            lblTenLop.Text = string.Empty;
            lblKhoa.Text = string.Empty;
            lblMaHV.Text = string.Empty;
            lblTenHocVien.Text = string.Empty;

            gridDSHV.AutoGenerateColumns = false;
            gridLop.AutoGenerateColumns = false;

            btnHienTatCa_Click(sender, e);
            gridLop_Click(sender, e);
            gridDSHV_Click(sender, e);
        }

        #endregion
        public void LoadPanelDiem(string maHV, string maLop)
        {
            List<BangDiemChiTietDTO> _lstBangDiem = new List<BangDiemChiTietDTO>();

            this.bangDiemFull_Click = BangDiem.SelectDetail(maHV, maLop);
            lblMaLop.Text = this.bangDiemFull_Click.MaLop;
            lblTenLop.Text = this.bangDiemFull_Click.TenLop;
            lblKhoa.Text = this.bangDiemFull_Click.TenKhoaHoc;
            lblMaHV.Text = this.bangDiemFull_Click.MaHocVien;
            lblTenHocVien.Text = this.bangDiemFull_Click.TenHocVien;
            ////load Danh sach diem
            //foreach (var item in this.bangDiemFull_Click.BangDiemChiTiets)
            //{
            //    BangDiemChiTietDTO _bangdiem = new BangDiemChiTietDTO();
            //    _bangdiem.BangDiemChiTietId = item.BangDiemChiTietId; ;
            //    _bangdiem.BangDiemId = this.bangDiemFull_Click.BangDiemId;
            //    _bangdiem.MaMonHoc = item.MaMonHoc;
            //    _bangdiem.TenMonHoc = item.TenMonHoc;
            //    _bangdiem.Diem = item.Diem ?? 0;
            //    _lstBangDiem.Add(_bangdiem);
            //}
            gridControlDSDiem.DataSource = this.bangDiemFull_Click.BangDiemChiTiets;
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (txtMaLop.Text == string.Empty)
                throw new ArgumentException("Mã lớp không được trống");
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.QuanLyDiem = null;
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            thLop = new Thread(() =>
            {
                object source = LopHoc.SelectTheoCoCo();

                gridLop.Invoke((MethodInvoker)delegate
                {
                    gridLop.DataSource = source;
                });
            });

            thLop.Start();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                thLop = new Thread(() =>
                {
                    object source = LopHoc.SelectAll(txtMaLop.Text);

                    gridLop.Invoke((MethodInvoker)delegate
                    {
                        gridLop.DataSource = source;
                    });
                });

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

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = string.Empty;
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                thHocVien = new Thread(() =>
                {
                    thLop.Join();
                    object source = BangDiem.SelectDSHV(gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());

                    gridDSHV.Invoke((MethodInvoker)delegate
                    {
                        gridDSHV.DataSource = source;
                    });
                });

                thHocVien.Start();
            }
            catch { }
        }

        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên", gridDSHV.Rows.Count);
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên", gridDSHV.Rows.Count);
        }

        private void gridDSHV_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDSHV.RowCount > 0)
                {
                    thPanelDiem = new Thread(() =>
                    {
                        thHocVien.Join();

                        gridLop.Invoke((MethodInvoker)delegate
                        {
                            LoadPanelDiem(gridDSHV.SelectedRows[0].Cells["clmMaHocVien"].Value.ToString(),
                                        gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());
                        });
                    });

                    thPanelDiem.Start();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridDSHV_Click(sender, e);
        }



        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                BangDiem.UpdateFull(this.bangDiemFull_Click);

                MessageBox.Show("Cập nhật bảng điểm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
