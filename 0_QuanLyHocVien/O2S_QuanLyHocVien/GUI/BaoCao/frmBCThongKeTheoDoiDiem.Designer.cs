﻿namespace O2S_QuanLyHocVien.Pages
{
    partial class frmBCThongKeTheoDoiDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.gridLop = new System.Windows.Forms.DataGridView();
            this.clmLopHocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenLopHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnTaoBaoCao = new System.Windows.Forms.Button();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.gridThongKe = new System.Windows.Forms.DataGridView();
            this.clmHocVienId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiemNghe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiemNoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiemDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiemViet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiemTrungBinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLop)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 24);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ ĐIỂM THEO LỚP";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.gridLop);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.txtMaLop);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 481);
            this.panel2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 65;
            this.label4.Text = "Kết quả tìm kiếm";
            // 
            // gridLop
            // 
            this.gridLop.AllowUserToAddRows = false;
            this.gridLop.AllowUserToResizeRows = false;
            this.gridLop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLop.BackgroundColor = System.Drawing.Color.White;
            this.gridLop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLopHocId,
            this.clmTenLopHoc});
            this.gridLop.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridLop.Location = new System.Drawing.Point(21, 161);
            this.gridLop.MultiSelect = false;
            this.gridLop.Name = "gridLop";
            this.gridLop.ReadOnly = true;
            this.gridLop.RowHeadersVisible = false;
            this.gridLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLop.Size = new System.Drawing.Size(279, 308);
            this.gridLop.TabIndex = 64;
            this.gridLop.Click += new System.EventHandler(this.gridLop_Click);
            // 
            // clmLopHocId
            // 
            this.clmLopHocId.DataPropertyName = "LopHocId";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.clmLopHocId.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmLopHocId.FillWeight = 70F;
            this.clmLopHocId.HeaderText = "Mã lớp";
            this.clmLopHocId.Name = "clmLopHocId";
            this.clmLopHocId.ReadOnly = true;
            // 
            // clmTenLopHoc
            // 
            this.clmTenLopHoc.DataPropertyName = "TenLopHoc";
            this.clmTenLopHoc.FillWeight = 93.27411F;
            this.clmTenLopHoc.HeaderText = "Tên lớp";
            this.clmTenLopHoc.Name = "clmTenLopHoc";
            this.clmTenLopHoc.ReadOnly = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.Silver;
            this.btnTimKiem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Image = global::O2S_QuanLyHocVien.Properties.Resources.zoom_16x16;
            this.btnTimKiem.Location = new System.Drawing.Point(116, 89);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(96, 29);
            this.btnTimKiem.TabIndex = 62;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtMaLop
            // 
            this.txtMaLop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaLop.Location = new System.Drawing.Point(98, 45);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(202, 25);
            this.txtMaLop.TabIndex = 51;
            this.txtMaLop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaLop_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 50;
            this.label3.Text = "Mã lớp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(17, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 49;
            this.label2.Text = "Tìm kiếm lớp học";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(320, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 481);
            this.panel3.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnTaoBaoCao);
            this.panel6.Controls.Add(this.lblTongCong);
            this.panel6.Controls.Add(this.label24);
            this.panel6.Controls.Add(this.gridThongKe);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(325, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(762, 481);
            this.panel6.TabIndex = 13;
            // 
            // btnTaoBaoCao
            // 
            this.btnTaoBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoBaoCao.BackColor = System.Drawing.Color.Silver;
            this.btnTaoBaoCao.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTaoBaoCao.FlatAppearance.BorderSize = 0;
            this.btnTaoBaoCao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTaoBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTaoBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaoBaoCao.Image = global::O2S_QuanLyHocVien.Properties.Resources.print_16x16;
            this.btnTaoBaoCao.Location = new System.Drawing.Point(634, 12);
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.Size = new System.Drawing.Size(113, 29);
            this.btnTaoBaoCao.TabIndex = 69;
            this.btnTaoBaoCao.Text = "Tạo báo cáo";
            this.btnTaoBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaoBaoCao.UseVisualStyleBackColor = false;
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);
            // 
            // lblTongCong
            // 
            this.lblTongCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Location = new System.Drawing.Point(16, 456);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(305, 15);
            this.lblTongCong.TabIndex = 68;
            this.lblTongCong.Text = "Tổng cộng: 0 học viên. Điểm trung bình của lớp: 0 điểm.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(16, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(129, 15);
            this.label24.TabIndex = 67;
            this.label24.Text = "Thống kê điểm của lớp";
            // 
            // gridThongKe
            // 
            this.gridThongKe.AllowUserToAddRows = false;
            this.gridThongKe.AllowUserToResizeRows = false;
            this.gridThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridThongKe.BackgroundColor = System.Drawing.Color.White;
            this.gridThongKe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmHocVienId,
            this.clmTenHocVien,
            this.clmDiemNghe,
            this.clmDiemNoi,
            this.clmDiemDoc,
            this.clmDiemViet,
            this.clmDiemTrungBinh});
            this.gridThongKe.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridThongKe.Location = new System.Drawing.Point(19, 45);
            this.gridThongKe.MultiSelect = false;
            this.gridThongKe.Name = "gridThongKe";
            this.gridThongKe.ReadOnly = true;
            this.gridThongKe.RowHeadersVisible = false;
            this.gridThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridThongKe.Size = new System.Drawing.Size(728, 408);
            this.gridThongKe.TabIndex = 66;
            this.gridThongKe.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridThongKe_RowsAdded);
            // 
            // clmHocVienId
            // 
            this.clmHocVienId.DataPropertyName = "HocVienId";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.clmHocVienId.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmHocVienId.FillWeight = 70F;
            this.clmHocVienId.HeaderText = "Mã học viên";
            this.clmHocVienId.Name = "clmHocVienId";
            this.clmHocVienId.ReadOnly = true;
            // 
            // clmTenHocVien
            // 
            this.clmTenHocVien.DataPropertyName = "TenHocVien";
            this.clmTenHocVien.HeaderText = "Tên học viên";
            this.clmTenHocVien.Name = "clmTenHocVien";
            this.clmTenHocVien.ReadOnly = true;
            // 
            // clmDiemNghe
            // 
            this.clmDiemNghe.DataPropertyName = "DiemNghe";
            this.clmDiemNghe.FillWeight = 50F;
            this.clmDiemNghe.HeaderText = "Điểm nghe";
            this.clmDiemNghe.Name = "clmDiemNghe";
            this.clmDiemNghe.ReadOnly = true;
            this.clmDiemNghe.Visible = false;
            // 
            // clmDiemNoi
            // 
            this.clmDiemNoi.DataPropertyName = "DiemNoi";
            this.clmDiemNoi.FillWeight = 50F;
            this.clmDiemNoi.HeaderText = "Điểm nói";
            this.clmDiemNoi.Name = "clmDiemNoi";
            this.clmDiemNoi.ReadOnly = true;
            this.clmDiemNoi.Visible = false;
            // 
            // clmDiemDoc
            // 
            this.clmDiemDoc.DataPropertyName = "DiemDoc";
            this.clmDiemDoc.FillWeight = 50F;
            this.clmDiemDoc.HeaderText = "Điểm đọc";
            this.clmDiemDoc.Name = "clmDiemDoc";
            this.clmDiemDoc.ReadOnly = true;
            this.clmDiemDoc.Visible = false;
            // 
            // clmDiemViet
            // 
            this.clmDiemViet.DataPropertyName = "DiemViet";
            this.clmDiemViet.FillWeight = 50F;
            this.clmDiemViet.HeaderText = "Điểm viết";
            this.clmDiemViet.Name = "clmDiemViet";
            this.clmDiemViet.ReadOnly = true;
            this.clmDiemViet.Visible = false;
            // 
            // clmDiemTrungBinh
            // 
            this.clmDiemTrungBinh.DataPropertyName = "DiemTrungBinh";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.clmDiemTrungBinh.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmDiemTrungBinh.FillWeight = 75F;
            this.clmDiemTrungBinh.HeaderText = "Điểm trung bình";
            this.clmDiemTrungBinh.Name = "clmDiemTrungBinh";
            this.clmDiemTrungBinh.ReadOnly = true;
            // 
            // frmThongKeDiemTheoLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1087, 505);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKeDiemTheoLop";
            this.Text = "Thống kê điểm theo lớp";
            this.Load += new System.EventHandler(this.frmThongKeDiemTheoLop_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLop)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gridLop;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnTaoBaoCao;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView gridThongKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLopHocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHocVienId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenHocVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiemNghe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiemNoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiemDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiemViet;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiemTrungBinh;
    }
}