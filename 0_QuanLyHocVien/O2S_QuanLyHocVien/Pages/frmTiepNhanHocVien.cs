// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmTiepNhanHocVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Threading;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Collections.Generic;
using System.Linq;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmTiepNhanHocVien : Form
    {
        #region Khai bao
        private bool isInsert = false;
        //private HOCVIEN hocVien;
        private int hocvienId_Select { get; set; }
        private List<HocVien_PlusDTO> _lstHocVien { get; set; }
        #endregion
        public frmTiepNhanHocVien()
        {
            InitializeComponent();
        }

        #region Load
        private void frmTiepNhanHocVien_Load(object sender, EventArgs e)
        {
            dateNgaySinh.MaxDate = DateTime.Now;

            LockAndUnlockPanelControl(false);
            InitializeLoaiHV();
            InitializeHocVien();
        }
        public void InitializeLoaiHV()
        {
            cboLoaiHV.DataSource = LoaiHocVienLogic.SelectAll();
            cboLoaiHV.DisplayMember = "TenLoaiHocVien";
            cboLoaiHV.ValueMember = "LoaiHocVienId";
        }

        public void InitializeHocVien()
        {
            gridDSHV.AutoGenerateColumns = false;

            Thread th = new Thread(() =>
            {
                HocVienFilter _filter = new HocVienFilter();
                _filter.CoSoId = GlobalSettings.CoSoId;

                this._lstHocVien = HocVienLogic.Select(_filter);

                gridDSHV.Invoke((MethodInvoker)delegate
                {
                    gridDSHV.DataSource = this._lstHocVien;
                });
            });

            th.Start();
        }
        public void LoadPanelControl(HOCVIEN hv = null)
        {
            try
            {
                if (hv == null)
                {
                    ResetPanelControl();
                    cboLoaiHV_SelectedValueChanged(null, null);
                }
                else
                {
                    txtMaHV.Text = hv.MaHocVien;
                    txtHoTen.Text = hv.TenHocVien;
                    dateNgaySinh.Value = (DateTime)hv.NgaySinh;
                    cboGioiTinh.Text = hv.GioiTinh;
                    txtDiaChi.Text = hv.DiaChi;
                    txtSDT.Text = hv.Sdt;
                    txtEmail.Text = hv.Email;
                    txtSDTBo.Text = hv.SdtBo;
                    txtEmailBo.Text = hv.EmailBo;
                    txtSDTMe.Text = hv.SdtMe;
                    txtEmailMe.Text = hv.EmailMe;
                    cboLoaiHV.SelectedValue = hv.LoaiHocVienId;
                    txtTenDangNhap.Text = hv.TAIKHOAN.IsRemove != 1 ? hv.TAIKHOAN.TenDangNhap : string.Empty;
                    txtMatKhau.Text = hv.TAIKHOAN.IsRemove != 1 ? hv.TAIKHOAN.MatKhau : string.Empty;
                }
            }
            catch (Exception ex)
            {
                ResetPanelControl();
                LockAndUnlockPanelControl(false);
                Common.Logging.LogSystem.Error(ex);
            }
        }
        #endregion

        #region Process

        public void LockAndUnlockPanelControl(bool _result)
        {
            txtHoTen.ReadOnly = !_result;
            dateNgaySinh.Enabled = _result;
            cboGioiTinh.Enabled = _result;
            txtDiaChi.ReadOnly = !_result;
            txtSDT.ReadOnly = !_result;
            txtEmail.ReadOnly = !_result;
            txtSDTBo.ReadOnly = !_result;
            txtEmailBo.ReadOnly = !_result;
            txtSDTMe.ReadOnly = !_result;
            txtEmailMe.ReadOnly = !_result;
            cboLoaiHV.Enabled = _result;
            btnLuuThongTin.Enabled = _result;
            btnHuyBo.Enabled = _result;
        }
        public void ResetPanelControl()
        {
            txtMaHV.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            dateNgaySinh.Value = dateNgaySinh.MaxDate;
            cboGioiTinh.SelectedIndex = 0;
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDTBo.Text = string.Empty;
            txtEmailBo.Text = string.Empty;
            txtSDTMe.Text = string.Empty;
            txtEmailMe.Text = string.Empty;
            cboLoaiHV.SelectedIndex = 0;
            txtTenDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }
        private HOCVIEN LoadHocVien()
        {
            HOCVIEN _hocVien = new HOCVIEN()
            {
                HocVienId = this.hocvienId_Select,
                TenHocVien = txtHoTen.Text,
                NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                GioiTinh = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                Sdt = txtSDT.Text,
                Email = txtEmail.Text,
                SdtBo = txtSDTBo.Text,
                EmailBo = txtEmailBo.Text,
                SdtMe = txtSDTMe.Text,
                EmailMe = txtEmailMe.Text,
                LoaiHocVienId = (int)cboLoaiHV.SelectedValue,
                NgayTiepNhan = DateTime.Now,
                CoSoId = GlobalSettings.CoSoId
            };
            return _hocVien;
        }
        public void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                throw new ArgumentException("Họ và tên không được trống");
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                throw new ArgumentException("Địa chỉ không được trống");
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại không được trống");
        }
        #endregion

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GlobalPages.TiepNhanHocVien = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(true);
            isInsert = true;
            LoadPanelControl();
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();

                if (isInsert)
                {
                    int _hocvienId = 0;
                    if (HocVienLogic.Insert(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    }, ref _hocvienId))
                    {
                        InitializeHocVien();
                        MessageBox.Show("Thêm học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LockAndUnlockPanelControl(false);
                    }
                }
                else
                {
                    if (HocVienLogic.Update(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    }))
                    {
                        InitializeHocVien();
                        MessageBox.Show("Sửa học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LockAndUnlockPanelControl(false);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridDSHV_Click(object sender, EventArgs e)
        {
            try
            {
                HOCVIEN hocVien = HocVienLogic.SelectSingle(Common.TypeConvert.TypeConvertParse.ToInt32(gridDSHV.SelectedRows[0].Cells["clmHocVienId"].Value.ToString()));
                this.hocvienId_Select = hocVien.HocVienId;
                LoadPanelControl(hocVien);
                LockAndUnlockPanelControl(false);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(false);
            gridDSHV_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockAndUnlockPanelControl(true);
            isInsert = false;
            cboLoaiHV_SelectedValueChanged(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (HocVienLogic.Delete(this.hocvienId_Select))
                    {
                        MessageBox.Show("Xóa học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitializeHocVien();
                        ResetPanelControl();
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.CO_LOI_XAY_RA);
                frmthongbao.Show();
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gridDSHV_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        #endregion

        #region Custom
        private void cboLoaiHV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLoaiHV.SelectedValue.ToString() == KeySetting.LOAIHOCVIEN_TIEMNANG.ToString())//tiem nang
            {
                txtTenDangNhap.Text = string.Empty;
                txtMatKhau.Text = string.Empty;
            }
        }

        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this._lstHocVien != null && this._lstHocVien.Count > 0)
            {
                lblTongCong.Text = string.Format("Tổng cộng: {0} học viên ({1} học viên chính thức và {2} học viên tiềm năng)",
                    this._lstHocVien.Count, this._lstHocVien.Where(o => o.LoaiHocVienId == 1).ToList().Count, this._lstHocVien.Where(o => o.LoaiHocVienId == 2).ToList().Count);
            }
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (this._lstHocVien != null && this._lstHocVien.Count > 0)
            {
                lblTongCong.Text = string.Format("Tổng cộng: {0} học viên ({1} học viên chính thức và {2} học viên tiềm năng)",
                    this._lstHocVien.Count, this._lstHocVien.Where(o => o.LoaiHocVienId == 1).ToList().Count, this._lstHocVien.Where(o => o.LoaiHocVienId == 2).ToList().Count);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
