namespace O2S_QuanLyHocVien.Pages
{
    partial class frmBangDiemCaNhan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControlDSDiem = new DevExpress.XtraGrid.GridControl();
            this.gridViewDSDiem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblDiemTrungBinh = new System.Windows.Forms.Label();
            this.btnInBangDiem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTenKhoaHocoa = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSDiem)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 24);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "BẢNG ĐIỂM HỌC VIÊN";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 526);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControlDSDiem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 103);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.panel3.Size = new System.Drawing.Size(1100, 371);
            this.panel3.TabIndex = 38;
            // 
            // gridControlDSDiem
            // 
            this.gridControlDSDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDSDiem.Location = new System.Drawing.Point(30, 0);
            this.gridControlDSDiem.MainView = this.gridViewDSDiem;
            this.gridControlDSDiem.Name = "gridControlDSDiem";
            this.gridControlDSDiem.Size = new System.Drawing.Size(1040, 371);
            this.gridControlDSDiem.TabIndex = 94;
            this.gridControlDSDiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDSDiem});
            // 
            // gridViewDSDiem
            // 
            this.gridViewDSDiem.ColumnPanelRowHeight = 25;
            this.gridViewDSDiem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridViewDSDiem.GridControl = this.gridControlDSDiem;
            this.gridViewDSDiem.Name = "gridViewDSDiem";
            this.gridViewDSDiem.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDSDiem.OptionsView.ShowGroupPanel = false;
            this.gridViewDSDiem.OptionsView.ShowIndicator = false;
            this.gridViewDSDiem.RowHeight = 25;
            this.gridViewDSDiem.ViewCaptionHeight = 25;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Mã môn học";
            this.gridColumn3.FieldName = "MonHocId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 85;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Tên môn học";
            this.gridColumn4.FieldName = "TenMonHoc";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 210;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Điểm";
            this.gridColumn5.FieldName = "Diem";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 100;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblDiemTrungBinh);
            this.panel8.Controls.Add(this.btnInBangDiem);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 474);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1100, 52);
            this.panel8.TabIndex = 37;
            // 
            // lblDiemTrungBinh
            // 
            this.lblDiemTrungBinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiemTrungBinh.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDiemTrungBinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDiemTrungBinh.Location = new System.Drawing.Point(179, 12);
            this.lblDiemTrungBinh.Name = "lblDiemTrungBinh";
            this.lblDiemTrungBinh.Size = new System.Drawing.Size(116, 30);
            this.lblDiemTrungBinh.TabIndex = 37;
            this.lblDiemTrungBinh.Text = "0";
            this.lblDiemTrungBinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInBangDiem
            // 
            this.btnInBangDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInBangDiem.BackColor = System.Drawing.Color.Silver;
            this.btnInBangDiem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnInBangDiem.FlatAppearance.BorderSize = 0;
            this.btnInBangDiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnInBangDiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInBangDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBangDiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnInBangDiem.Image = global::O2S_QuanLyHocVien.Properties.Resources.print_16x16;
            this.btnInBangDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInBangDiem.Location = new System.Drawing.Point(480, 12);
            this.btnInBangDiem.Name = "btnInBangDiem";
            this.btnInBangDiem.Size = new System.Drawing.Size(121, 28);
            this.btnInBangDiem.TabIndex = 39;
            this.btnInBangDiem.Text = "In bảng điểm";
            this.btnInBangDiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInBangDiem.UseVisualStyleBackColor = false;
            this.btnInBangDiem.Click += new System.EventHandler(this.btnInBangDiem_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label7.Location = new System.Drawing.Point(53, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Điểm trung bình:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblTenKhoaHocoa);
            this.panel7.Controls.Add(this.lblTenLop);
            this.panel7.Controls.Add(this.cboLop);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.lblTitle);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1100, 103);
            this.panel7.TabIndex = 36;
            // 
            // lblTenKhoaHocoa
            // 
            this.lblTenKhoaHocoa.AutoSize = true;
            this.lblTenKhoaHocoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenKhoaHocoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTenKhoaHocoa.Location = new System.Drawing.Point(630, 61);
            this.lblTenKhoaHocoa.Name = "lblTenKhoaHocoa";
            this.lblTenKhoaHocoa.Size = new System.Drawing.Size(129, 21);
            this.lblTenKhoaHocoa.TabIndex = 40;
            this.lblTenKhoaHocoa.Text = "<course name>";
            this.lblTenKhoaHocoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenLop.ForeColor = System.Drawing.Color.Green;
            this.lblTenLop.Location = new System.Drawing.Point(630, 16);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(115, 21);
            this.lblTenLop.TabIndex = 39;
            this.lblTenLop.Text = "<class name>";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(378, 60);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(197, 25);
            this.cboLop.TabIndex = 36;
            this.cboLop.SelectedValueChanged += new System.EventHandler(this.cboLop_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label4.Location = new System.Drawing.Point(310, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "Chọn Lớp:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::O2S_QuanLyHocVien.Properties.Resources.icon_BangDiem_64dp;
            this.pictureBox1.Location = new System.Drawing.Point(15, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTitle.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Location = new System.Drawing.Point(85, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 25);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "Bảng điểm của <user name>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label2.Location = new System.Drawing.Point(87, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Chọn Lớp để xem bảng điểm học viên";
            // 
            // frmBangDiemCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBangDiemCaNhan";
            this.Text = "Bảng điểm";
            this.Load += new System.EventHandler(this.frmBangDiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSDiem)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTenKhoaHocoa;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.Label lblDiemTrungBinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnInBangDiem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private DevExpress.XtraGrid.GridControl gridControlDSDiem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDSDiem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}