﻿namespace O2S_QuanLyHocVien.Pages
{
    partial class frmBCThongKeNoHocPhi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTaoBaoCao = new System.Windows.Forms.Button();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gridBaoCao = new System.Windows.Forms.DataGridView();
            this.clmHocVienId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmConNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 24);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ NỢ HỌC VIÊN";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTaoBaoCao);
            this.panel2.Controls.Add(this.lblTongCong);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 466);
            this.panel2.TabIndex = 7;
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
            this.btnTaoBaoCao.Location = new System.Drawing.Point(786, 16);
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.Size = new System.Drawing.Size(109, 30);
            this.btnTaoBaoCao.TabIndex = 64;
            this.btnTaoBaoCao.Text = "Tạo báo cáo";
            this.btnTaoBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaoBaoCao.UseVisualStyleBackColor = false;
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);
            // 
            // lblTongCong
            // 
            this.lblTongCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Location = new System.Drawing.Point(48, 441);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(255, 15);
            this.lblTongCong.TabIndex = 49;
            this.lblTongCong.Text = "Tổng cộng: 0 học viên còn nợ. Tổng nợ: 0 VNĐ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 850F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(19, 52);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(909, 377);
            this.tableLayoutPanel2.TabIndex = 48;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.gridBaoCao);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(1);
            this.panel4.Size = new System.Drawing.Size(903, 371);
            this.panel4.TabIndex = 0;
            // 
            // gridBaoCao
            // 
            this.gridBaoCao.AllowUserToAddRows = false;
            this.gridBaoCao.AllowUserToResizeRows = false;
            this.gridBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBaoCao.BackgroundColor = System.Drawing.Color.White;
            this.gridBaoCao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBaoCao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmHocVienId,
            this.clmTenHocVien,
            this.clmGioiTinh,
            this.clmTenKhoaHoc,
            this.clmConNo});
            this.gridBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBaoCao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridBaoCao.Location = new System.Drawing.Point(1, 1);
            this.gridBaoCao.MultiSelect = false;
            this.gridBaoCao.Name = "gridBaoCao";
            this.gridBaoCao.ReadOnly = true;
            this.gridBaoCao.RowHeadersVisible = false;
            this.gridBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBaoCao.Size = new System.Drawing.Size(901, 369);
            this.gridBaoCao.TabIndex = 44;
            this.gridBaoCao.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridBaoCao_RowsAdded);
            this.gridBaoCao.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridBaoCao_RowsRemoved);
            // 
            // clmHocVienId
            // 
            this.clmHocVienId.DataPropertyName = "HocVienId";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.clmHocVienId.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmHocVienId.FillWeight = 70F;
            this.clmHocVienId.HeaderText = "Mã học viên";
            this.clmHocVienId.Name = "clmHocVienId";
            this.clmHocVienId.ReadOnly = true;
            // 
            // clmTenHocVien
            // 
            this.clmTenHocVien.DataPropertyName = "TenHocVien";
            this.clmTenHocVien.FillWeight = 150F;
            this.clmTenHocVien.HeaderText = "Họ và tên";
            this.clmTenHocVien.Name = "clmTenHocVien";
            this.clmTenHocVien.ReadOnly = true;
            // 
            // clmGioiTinh
            // 
            this.clmGioiTinh.DataPropertyName = "GioiTinh";
            this.clmGioiTinh.FillWeight = 50F;
            this.clmGioiTinh.HeaderText = "Giới tính";
            this.clmGioiTinh.Name = "clmGioiTinh";
            this.clmGioiTinh.ReadOnly = true;
            // 
            // clmTenKhoaHoc
            // 
            this.clmTenKhoaHoc.DataPropertyName = "TenKhoaHoc";
            this.clmTenKhoaHoc.HeaderText = "Khóa học";
            this.clmTenKhoaHoc.Name = "clmTenKhoaHoc";
            this.clmTenKhoaHoc.ReadOnly = true;
            // 
            // clmConNo
            // 
            this.clmConNo.DataPropertyName = "ConNo";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Format = "C0";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.clmConNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmConNo.HeaderText = "Còn nợ";
            this.clmConNo.Name = "clmConNo";
            this.clmConNo.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 21);
            this.label2.TabIndex = 46;
            this.label2.Text = "Danh sách các học viên đang nợ học phí";
            // 
            // frmThongKeNoHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(946, 490);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKeNoHocVien";
            this.Text = "frmThongKeNoHocVien";
            this.Load += new System.EventHandler(this.frmThongKeNoHocVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Button btnTaoBaoCao;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView gridBaoCao;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHocVienId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenHocVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmConNo;
    }
}