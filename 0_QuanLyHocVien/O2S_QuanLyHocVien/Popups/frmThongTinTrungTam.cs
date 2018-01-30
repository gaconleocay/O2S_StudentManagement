﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmThongTinTrungTam.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmThongTinTrungTam : Form
    {
        public frmThongTinTrungTam()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chuyển giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        public CHITIETTRUNGTAM LoadChiTiet()
        {
            return new CHITIETTRUNGTAM()
            {
                TenTT = txtTenTrungTam.Text,
                DiaChiTT = txtDiaChi.Text,
                SdtTT = txtSDT.Text,
                EmailTT = txtEmail.Text,
                Website = txtWebsite.Text,
            };
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinTrungTam_Load(object sender, EventArgs e)
        {
            var item = ChiTietTrungTam.Select();
            txtTenTrungTam.Text = item.TenTT;
            txtDiaChi.Text = item.DiaChiTT;
            txtSDT.Text = item.SdtTT;
            txtEmail.Text = item.EmailTT;
            txtWebsite.Text = item.Website;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietTrungTam.Update(LoadChiTiet());

                MessageBox.Show("Thay đổi thông tin trung tâm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalSettings.LoadCenterInformation();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
