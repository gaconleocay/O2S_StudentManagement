﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmThongTinPhanMem.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace O2S_QuanLyHocVien.Popups
{
    public partial class frmThongTinPhanMem : Form
    {
        public frmThongTinPhanMem()
        {
            InitializeComponent();
        }

        #region Events

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinPhanMem_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Application.ProductVersion;   
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:nguyentuanit96@gmail.com");
        }

        #endregion
    }
}
