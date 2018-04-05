namespace O2S_QuanLyHocVien.Pages
{
    partial class frmQuanLyCoSo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnLuuThongTin = new System.Windows.Forms.Button();
            this.txtTenCoSo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaCoSo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridKH = new System.Windows.Forms.DataGridView();
            this.clmCoSoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenCoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKH)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 24);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ CƠ SỞ";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::O2S_QuanLyHocVien.Properties.Resources.icon_Close_9dp;
            this.btnClose.Location = new System.Drawing.Point(1046, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 19);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.txtDiaChi);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btnHuyBo);
            this.splitContainer1.Panel1.Controls.Add(this.btnLuuThongTin);
            this.splitContainer1.Panel1.Controls.Add(this.txtTenCoSo);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtMaCoSo);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.gridKH);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1086, 516);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 6;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(92, 92);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(248, 25);
            this.txtDiaChi.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Địa chỉ:";
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyBo.BackColor = System.Drawing.Color.Silver;
            this.btnHuyBo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyBo.FlatAppearance.BorderSize = 0;
            this.btnHuyBo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnHuyBo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyBo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuyBo.Image = global::O2S_QuanLyHocVien.Properties.Resources.cancel_16x16;
            this.btnHuyBo.Location = new System.Drawing.Point(233, 147);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(107, 34);
            this.btnHuyBo.TabIndex = 18;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuyBo.UseVisualStyleBackColor = false;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnLuuThongTin
            // 
            this.btnLuuThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuThongTin.BackColor = System.Drawing.Color.Silver;
            this.btnLuuThongTin.FlatAppearance.BorderSize = 0;
            this.btnLuuThongTin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnLuuThongTin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLuuThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuThongTin.Image = global::O2S_QuanLyHocVien.Properties.Resources.save_16x16;
            this.btnLuuThongTin.Location = new System.Drawing.Point(106, 147);
            this.btnLuuThongTin.Name = "btnLuuThongTin";
            this.btnLuuThongTin.Size = new System.Drawing.Size(121, 34);
            this.btnLuuThongTin.TabIndex = 17;
            this.btnLuuThongTin.Text = "Lưu thông tin";
            this.btnLuuThongTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuThongTin.UseVisualStyleBackColor = false;
            this.btnLuuThongTin.Click += new System.EventHandler(this.btnLuuThongTin_Click);
            // 
            // txtTenCoSo
            // 
            this.txtTenCoSo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenCoSo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenCoSo.Location = new System.Drawing.Point(92, 52);
            this.txtTenCoSo.Name = "txtTenCoSo";
            this.txtTenCoSo.Size = new System.Drawing.Size(248, 25);
            this.txtTenCoSo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên cơ sở:";
            // 
            // txtMaCoSo
            // 
            this.txtMaCoSo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaCoSo.Enabled = false;
            this.txtMaCoSo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaCoSo.Location = new System.Drawing.Point(92, 12);
            this.txtMaCoSo.Name = "txtMaCoSo";
            this.txtMaCoSo.ReadOnly = true;
            this.txtMaCoSo.Size = new System.Drawing.Size(248, 25);
            this.txtMaCoSo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã cơ sở";
            // 
            // gridKH
            // 
            this.gridKH.AllowUserToAddRows = false;
            this.gridKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKH.BackgroundColor = System.Drawing.Color.White;
            this.gridKH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCoSoId,
            this.clmTenCoSo,
            this.clmDiaChi});
            this.gridKH.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridKH.Location = new System.Drawing.Point(12, 39);
            this.gridKH.MultiSelect = false;
            this.gridKH.Name = "gridKH";
            this.gridKH.RowHeadersVisible = false;
            this.gridKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridKH.Size = new System.Drawing.Size(704, 441);
            this.gridKH.TabIndex = 1;
            this.gridKH.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridKH_RowsAdded);
            this.gridKH.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridKH_RowsRemoved);
            this.gridKH.Click += new System.EventHandler(this.gridKH_Click);
            this.gridKH.DoubleClick += new System.EventHandler(this.gridKH_DoubleClick);
            // 
            // clmCoSoId
            // 
            this.clmCoSoId.DataPropertyName = "CoSoId";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.clmCoSoId.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmCoSoId.FillWeight = 7.383478F;
            this.clmCoSoId.HeaderText = "Mã cơ sở";
            this.clmCoSoId.Name = "clmCoSoId";
            this.clmCoSoId.Width = 80;
            // 
            // clmTenCoSo
            // 
            this.clmTenCoSo.DataPropertyName = "TenCoSo";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Green;
            this.clmTenCoSo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmTenCoSo.FillWeight = 8.860174F;
            this.clmTenCoSo.HeaderText = "Tên cơ sở";
            this.clmTenCoSo.Name = "clmTenCoSo";
            this.clmTenCoSo.Width = 250;
            // 
            // clmDiaChi
            // 
            this.clmDiaChi.DataPropertyName = "DiaChi";
            this.clmDiaChi.FillWeight = 303.7563F;
            this.clmDiaChi.HeaderText = "Địa chỉ";
            this.clmDiaChi.Name = "clmDiaChi";
            this.clmDiaChi.Width = 665;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTongCong);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 486);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(728, 30);
            this.panel3.TabIndex = 2;
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Location = new System.Drawing.Point(9, 7);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(143, 15);
            this.lblTongCong.TabIndex = 11;
            this.lblTongCong.Text = "Tổng cộng: <num> cơ sở";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 37);
            this.panel2.TabIndex = 0;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Silver;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.Image = global::O2S_QuanLyHocVien.Properties.Resources.deletelist_16x16;
            this.btnXoa.Location = new System.Drawing.Point(210, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(71, 25);
            this.btnXoa.TabIndex = 20;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Silver;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.Image = global::O2S_QuanLyHocVien.Properties.Resources.edit_16x16;
            this.btnSua.Location = new System.Drawing.Point(133, 6);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(71, 25);
            this.btnSua.TabIndex = 19;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Silver;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.Image = global::O2S_QuanLyHocVien.Properties.Resources.additem_16x16;
            this.btnThem.Location = new System.Drawing.Point(12, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(115, 25);
            this.btnThem.TabIndex = 18;
            this.btnThem.Text = "Thêm cơ sở";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmQuanLyCoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1086, 540);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuanLyCoSo";
            this.Text = "Quản lý cơ sở";
            this.Load += new System.EventHandler(this.frmQuanLyCoSo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKH)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnLuuThongTin;
        private System.Windows.Forms.TextBox txtTenCoSo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCoSo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridKH;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCoSoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenCoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiaChi;
    }
}