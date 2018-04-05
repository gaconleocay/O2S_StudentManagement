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
using O2S_QuanLyHocVien.BusinessLogic.Filter;

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

            btnTimKiem_Click(sender, e);
            gridLop_Click(sender, e);
            gridDSHV_Click(sender, e);
        }
        public void LoadPanelDiem(int maHV, int maLop)
        {
            List<BangDiemChiTietDTO> _lstBangDiem = new List<BangDiemChiTietDTO>();

            this.bangDiemFull_Click = BangDiemLogic.SelectDetail(maHV, maLop);
            lblMaLop.Text = this.bangDiemFull_Click.LopHocId.ToString();
            lblTenLop.Text = this.bangDiemFull_Click.TenLop;
            lblKhoa.Text = this.bangDiemFull_Click.TenKhoaHoc;
            lblMaHV.Text = this.bangDiemFull_Click.HocVienId.ToString();
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

        #endregion

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.QuanLyDiem = null;
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
                thHocVien = new Thread(() =>
                {
                    thLop.Join();
                    object source = BangDiemLogic.SelectDSHV(Common.TypeConvert.TypeConvertParse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()));

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
                            LoadPanelDiem(Common.TypeConvert.TypeConvertParse.ToInt32(gridDSHV.SelectedRows[0].Cells["clmHocVienId"].Value.ToString()),
                                        Common.TypeConvert.TypeConvertParse.ToInt32(gridLop.SelectedRows[0].Cells["clmLopHocId"].Value.ToString()));
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
                BangDiemLogic.UpdateFull(this.bangDiemFull_Click);

                MessageBox.Show("Cập nhật bảng điểm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
