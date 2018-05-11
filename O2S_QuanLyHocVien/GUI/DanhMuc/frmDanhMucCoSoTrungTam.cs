// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmQuanLyCoSo.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;
using System.IO;
using System.Drawing;

namespace O2S_QuanLyHocVien.Pages
{
    public partial class frmDanhMucCoSoTrungTam : Form
    {
        private bool isInsert = false;

        public frmDanhMucCoSoTrungTam()
        {
            InitializeComponent();
        }

        public void LockPanelControl()
        {
            txtMaCoSo.Enabled = false;
            txtTenCoSo.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            txtEmail.Enabled = false;
            btnLuuThongTin.Enabled = false;
            btnHuyBo.Enabled = false;
        }

        public void UnlockPanelControl()
        {
            txtTenCoSo.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtEmail.Enabled = true;
            btnLuuThongTin.Enabled = true;
            btnHuyBo.Enabled = true;
        }

        public void ResetPanelControl()
        {
            txtMaCoSo.Text = string.Empty;
            txtTenCoSo.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtEmail.Text = string.Empty;
            picLogoCoSo.Image = null;
        }

        public void LoadUI(COSOTRUNGTAM kh)
        {
            txtMaCoSo.Text = kh.CoSoId.ToString();
            txtTenCoSo.Text = kh.TenCoSo;
            txtDiaChi.Text = kh.DiaChi;
            txtDienThoai.Text = kh.Sdt;
            txtEmail.Text = kh.Email;
            if (kh.LogoCoSo != null && kh.LogoCoSo.Length > 0)//image type sql server - hien thi
            {
                byte[] Empimage = (byte[])(kh.LogoCoSo).ToArray();
                picLogoCoSo.Image = Image.FromStream(new MemoryStream(Empimage));
            }
            else
            { picLogoCoSo.Image = null; }
        }

        public COSOTRUNGTAM LoadCoSoTrungTam()
        {
            //luu image vao CSQL SQL server
            Image _image = picLogoCoSo.Image;
            MemoryStream memstrem = new System.IO.MemoryStream();
            _image.Save(memstrem, System.Drawing.Imaging.ImageFormat.Bmp);

            return new COSOTRUNGTAM()
            {
                CoSoId = O2S_Common.TypeConvert.Parse.ToInt32(txtMaCoSo.Text),
                TenCoSo = txtTenCoSo.Text,
                DiaChi = txtDiaChi.Text,
                Sdt=txtDienThoai.Text,
                Email=txtEmail.Text,
                LogoCoSo = memstrem.GetBuffer(),
            //
        };
        }
        public void LoadGridKhoaHoc()
        {
            gridKH.DataSource = CoSoTrungTamLogic.SelectAll();
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridKH_Click(sender, e);
        }

        private void frmQuanLyCoSo_Load(object sender, EventArgs e)
        {
            gridKH.AutoGenerateColumns = false;

            LockPanelControl();
            LoadGridKhoaHoc();
            gridKH_Click(sender, e);
        }

        private void gridKH_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} cơ sở", gridKH.Rows.Count);
        }

        private void gridKH_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} cơ sở", gridKH.Rows.Count);
        }

        private void gridKH_Click(object sender, EventArgs e)
        {
            LockPanelControl();

            try
            {
                LoadUI(CoSoTrungTamLogic.Select(O2S_Common.TypeConvert.Parse.ToInt32(gridKH.SelectedRows[0].Cells["clmCoSoId"].Value.ToString())));
            }
            catch
            {
                ResetPanelControl();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnlockPanelControl();
            ResetPanelControl();
            //txtMaCoSo.Text = CoSoTrungTamLogic.AutoGenerateId();
            isInsert = true;
        }

        private void gridKH_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnlockPanelControl();
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CoSoTrungTamLogic.Delete(O2S_Common.TypeConvert.Parse.ToInt32(gridKH.SelectedRows[0].Cells["clmCoSoId"].Value.ToString()));

                    MessageBox.Show("Xóa cơ sở thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridKhoaHoc();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    CoSoTrungTamLogic.Insert(LoadCoSoTrungTam());

                    MessageBox.Show("Thêm cơ sở thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CoSoTrungTamLogic.Update(LoadCoSoTrungTam());

                    MessageBox.Show("Sửa cơ sở thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Chọn file logo";
                openFileDialog1.Filter = "(*.BMP;*.JPG;*.GIF;*.ICO)|*.BMP;*.JPG;*.GIF;*.ICO|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    picLogoCoSo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                    picLogoCoSo.Image = Image.FromFile(openFileDialog1.FileName);
                    //strLogoFileName = openFileDialog1.SafeFileName;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion


    }
}
