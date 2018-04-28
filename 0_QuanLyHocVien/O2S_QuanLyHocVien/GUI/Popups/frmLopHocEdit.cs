// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmLopHocEdit.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.Globalization;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmLopHocEdit : Form
    {
        private LOPHOC lh;
        private bool isInsert = false;

        public frmLopHocEdit(LOPHOC lh = null)
        {
            InitializeComponent();
            this.lh = lh;
            isInsert = lh == null;
        }

        /// <summary>
        /// Nạp lớp lên giao diện
        /// </summary>
        /// <param name="lh"></param>
        public void LoadUI(LOPHOC lh)
        {
            if (lh == null)
            {
                // txtMaLop.Text = LopHocLogic.AutoGenerateId(dateNgayBD.Value);
            }
            else
            {
                txtMaLop.Text = lh.LopHocId.ToString();
                txtTenLop.Text = lh.TenLopHoc;
                dateNgayBD.Value = (DateTime)lh.NgayBatDau;
                dateNgayBD.Enabled = cboKhoa.Enabled = isInsert;
                dateNgayKT.Value = (DateTime)lh.NgayKetThuc;
                cboKhoa.SelectedValue = lh.KhoaHocId;
                rdMo.Checked = (bool)lh.DangMo;
                rdDong.Checked = !(bool)lh.DangMo;
            }
        }

        /// <summary>
        /// Nạp giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        private LOPHOC LoadLopHoc()
        {
            return new LOPHOC()
            {
                LopHocId = O2S_Common.TypeConvert.Parse.ToInt32(txtMaLop.Text),
                TenLopHoc = txtTenLop.Text,
                NgayBatDau = DateTime.ParseExact(dateNgayBD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                NgayKetThuc = DateTime.ParseExact(dateNgayKT.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                SiSo = lh == null ? 0 : lh.SiSo,
                KhoaHocId = O2S_Common.TypeConvert.Parse.ToInt32(cboKhoa.SelectedValue.ToString()),
                DangMo = rdMo.Checked,
                CoSoId = GlobalSettings.CoSoId
            };
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
                throw new ArgumentException("Tên lớp không được trống");
        }

        #region Events

        private void dateNgayBD_ValueChanged(object sender, EventArgs e)
        {
            //if (isInsert)
            //    txtMaLop.Text = LopHocLogic.AutoGenerateId(dateNgayBD.Value);

            dateNgayKT.MinDate = dateNgayBD.Value;
            dateNgayKT.Value = dateNgayBD.Value + TimeSpan.FromDays(180);
        }

        private void frmLopHocEdit_Load(object sender, EventArgs e)
        {
            dateNgayBD.Value = DateTime.Now;

            KhoaHocFilter _filter = new KhoaHocFilter();
            _filter.CoSoId = GlobalSettings.CoSoId;
            cboKhoa.DataSource = KhoaHocLogic.Select(_filter);
            cboKhoa.DisplayMember = "TenKhoaHoc";
            cboKhoa.ValueMember = "KhoaHocId";

            LoadUI(lh);
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();
                int _khoaHocId = 0;
                if (isInsert)
                {
                    if (LopHocLogic.Insert(LoadLopHoc(), ref _khoaHocId))
                    {
                        MessageBox.Show("Thêm lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    LopHocLogic.Update(LoadLopHoc());

                    MessageBox.Show("Sửa lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
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
