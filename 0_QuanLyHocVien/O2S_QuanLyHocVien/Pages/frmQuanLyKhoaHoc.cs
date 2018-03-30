// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyKhoaHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Collections.Generic;
using System.Linq;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmQuanLyKhoaHoc : Form
    {
        private bool isInsert = false;
        private List<KhoaHocMonHocDTO> lstKHMH { get; set; }
        public frmQuanLyKhoaHoc()
        {
            InitializeComponent();
        }

        #region Load
        private void frmQuanLyKhoaHoc_Load(object sender, EventArgs e)
        {
            gridKH.AutoGenerateColumns = false;

            LockPanelControl(false);
            LoadGridKhoaHocMonHoc();
            LoadGridKhoaHoc();
            gridKH_Click(sender, e);
        }
        private void LoadGridKhoaHocMonHoc()
        {
            try
            {
                this.lstKHMH = new List<KhoaHocMonHocDTO>();
                List<MONHOC> _lstMonHoc = MonHoc.SelectAll() as List<MONHOC>;
                foreach (var item in _lstMonHoc)
                {
                    KhoaHocMonHocDTO _khmh = new KhoaHocMonHocDTO();
                    _khmh.IsCheck = false;
                    _khmh.MaMonHoc = item.MaMonHoc;
                    _khmh.TenMonHoc = item.TenMonHoc;
                    _khmh.DiemDat = 0;
                    this.lstKHMH.Add(_khmh);
                }
                gridControlDSMonHoc.DataSource = this.lstKHMH;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        public void LockPanelControl(bool result)
        {
            txtMaKhoaHoc.Enabled = result;
            txtTenKhoaHoc.Enabled = result;
            numHocPhi.Enabled = result;
            btnLuuThongTin.Enabled = result;
            btnHuyBo.Enabled = result;
        }

        public void ResetPanelControl()
        {
            txtMaKhoaHoc.Text = string.Empty;
            txtTenKhoaHoc.Text = string.Empty;
            numHocPhi.Value = 0;
            LoadGridKhoaHocMonHoc();
        }

        /// <summary>
        /// Nạp khóa học lên giao diện
        /// </summary>
        /// <param name="kh">Khóa học</param>
        public void LoadUI(KHOAHOC kh)
        {
            try
            {
                txtMaKhoaHoc.Text = kh.MaKhoaHoc;
                txtTenKhoaHoc.Text = kh.TenKhoaHoc;
                numHocPhi.Value = (decimal)kh.HocPhi;
                //Load mon hoc cua Khoa hoc
                List<KhoaHocMonHocDTO> _lstKHMH = this.lstKHMH;
                List<KHOAHOC_MONHOC> _khmh = KhoaHocMonHoc.SelectTheoKhoaHoc(kh.MaKhoaHoc);
                if (_khmh != null && _khmh.Count > 0)
                {
                    foreach (var item in _lstKHMH)
                    {
                        List<KHOAHOC_MONHOC> _kiemtra = _khmh.Where(o => o.MaMonHoc == item.MaMonHoc).ToList();
                        if (_kiemtra != null && _kiemtra.Count > 0)
                        {
                            item.IsCheck = true;
                            item.DiemDat = _kiemtra[0].DiemDat ?? 0;
                        }
                        else
                        {
                            item.IsCheck = false;
                            item.DiemDat = 0;
                        }
                    }
                }
                else
                {
                    foreach (var item in _lstKHMH)
                    {
                        item.IsCheck = false;
                        item.DiemDat = 0;
                    }
                }
                gridControlDSMonHoc.DataSource = null;
                gridControlDSMonHoc.DataSource = _lstKHMH;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        /// <summary>
        /// Nạp giao diện xuống khóa học
        /// </summary>
        /// <returns></returns>
        public KHOAHOC LoadKhoaHoc()
        {
            return new KHOAHOC()
            {
                MaKhoaHoc = txtMaKhoaHoc.Text,
                TenKhoaHoc = txtTenKhoaHoc.Text,
                HocPhi = numHocPhi.Value,
                MaCoSo = GlobalSettings.MaCoSo
            };
        }

        public void LoadGridKhoaHoc()
        {
            try
            {
                gridKH.DataSource = KhoaHoc.SelectAll();
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
            GlobalPages.QuanLyKhoaHoc = null;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridKH_Click(sender, e);
        }


        private void gridKH_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} khóa học", gridKH.Rows.Count);
        }

        private void gridKH_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} khóa học", gridKH.Rows.Count);
        }

        private void gridKH_Click(object sender, EventArgs e)
        {
            LockPanelControl(false);

            try
            {
                LoadUI(KhoaHoc.Select(gridKH.SelectedRows[0].Cells["clmMaKhoaHoc"].Value.ToString()));
            }
            catch
            {
                ResetPanelControl();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockPanelControl(true);
            ResetPanelControl();
            txtMaKhoaHoc.Text = KhoaHoc.AutoGenerateId();
            isInsert = true;
        }

        private void gridKH_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockPanelControl(true);
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KhoaHoc.Delete(gridKH.SelectedRows[0].Cells["clmMaKhoaHoc"].Value.ToString());

                    MessageBox.Show("Xóa khóa học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridKhoaHoc();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                //  ValidateHeSo();

                if (isInsert)
                {
                    KhoaHoc.Insert(LoadKhoaHoc());
                    //Insert Khoa hoc-mon hoc
                    for (int i = 0; i < gridViewDSMonHoc.RowCount; i++)
                    {
                        bool _IsCheck = Common.TypeConvert.TypeConvertParse.ToBoolean(gridViewDSMonHoc.GetRowCellValue(i, "IsCheck").ToString());
                        if (_IsCheck)
                        {
                            KHOAHOC_MONHOC _khmh = new KHOAHOC_MONHOC();
                            _khmh.MaKhoaHoc = txtMaKhoaHoc.Text;
                            _khmh.TenKhoaHoc = txtTenKhoaHoc.Text;
                            _khmh.MaMonHoc = gridViewDSMonHoc.GetRowCellValue(i, "MaMonHoc").ToString();
                            _khmh.TenMonHoc = gridViewDSMonHoc.GetRowCellValue(i, "TenMonHoc").ToString();
                            _khmh.DiemDat = Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewDSMonHoc.GetRowCellValue(i, "DiemDat").ToString());
                            KhoaHocMonHoc.Insert(_khmh);
                        }
                    }

                    MessageBox.Show("Thêm khóa học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KhoaHoc.Update(LoadKhoaHoc());
                    //INsert Khoa hoc-mon hoc
                    KhoaHocMonHoc.DeleteTheoKhoaHoc(txtMaKhoaHoc.Text);
                    for (int i = 0; i < gridViewDSMonHoc.RowCount; i++)
                    {
                        bool _IsCheck = Common.TypeConvert.TypeConvertParse.ToBoolean(gridViewDSMonHoc.GetRowCellValue(i, "IsCheck").ToString());
                        if (_IsCheck)
                        {
                            KHOAHOC_MONHOC _khmh = new KHOAHOC_MONHOC();
                            _khmh.MaKhoaHoc = txtMaKhoaHoc.Text;
                            _khmh.TenKhoaHoc = txtTenKhoaHoc.Text;
                            _khmh.MaMonHoc = gridViewDSMonHoc.GetRowCellValue(i, "MaMonHoc").ToString();
                            _khmh.TenMonHoc = gridViewDSMonHoc.GetRowCellValue(i, "TenMonHoc").ToString();
                            _khmh.DiemDat = Common.TypeConvert.TypeConvertParse.ToDecimal(gridViewDSMonHoc.GetRowCellValue(i, "DiemDat").ToString());
                            KhoaHocMonHoc.Insert(_khmh);
                        }
                    }

                    MessageBox.Show("Sửa khóa học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadGridKhoaHoc();
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
        #endregion
    }
}
