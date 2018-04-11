namespace O2S_QuanLyHocVien.Pages
{
    partial class frmQuanLyDiem
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
            this.label4 = new System.Windows.Forms.Label();
            this.gridLop = new System.Windows.Forms.DataGridView();
            this.clmLopHocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenLopHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.gridControlDSDiem = new DevExpress.XtraGrid.GridControl();
            this.gridViewDSDiem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemText_diem = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTenHocVien = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMaHV = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnLuuThongTin = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.gridDSHV = new System.Windows.Forms.DataGridView();
            this.clmHocVienId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLop)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemText_diem)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSHV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 24);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ ĐIỂM";
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
            this.panel2.Size = new System.Drawing.Size(296, 526);
            this.panel2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 143);
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
            this.gridLop.Location = new System.Drawing.Point(6, 161);
            this.gridLop.MultiSelect = false;
            this.gridLop.Name = "gridLop";
            this.gridLop.ReadOnly = true;
            this.gridLop.RowHeadersVisible = false;
            this.gridLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLop.Size = new System.Drawing.Size(284, 357);
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
            this.btnTimKiem.Location = new System.Drawing.Point(76, 89);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(97, 29);
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
            this.txtMaLop.Location = new System.Drawing.Point(83, 45);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(178, 25);
            this.txtMaLop.TabIndex = 51;
            this.txtMaLop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaLop_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 50);
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
            this.label2.Location = new System.Drawing.Point(2, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 49;
            this.label2.Text = "Tìm kiếm lớp học";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(296, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 526);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(690, 24);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.panel4.Size = new System.Drawing.Size(422, 526);
            this.panel4.TabIndex = 10;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.gridControlDSDiem);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 200);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(402, 278);
            this.panel9.TabIndex = 82;
            // 
            // gridControlDSDiem
            // 
            this.gridControlDSDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDSDiem.Location = new System.Drawing.Point(0, 0);
            this.gridControlDSDiem.MainView = this.gridViewDSDiem;
            this.gridControlDSDiem.Name = "gridControlDSDiem";
            this.gridControlDSDiem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemText_diem});
            this.gridControlDSDiem.Size = new System.Drawing.Size(402, 278);
            this.gridControlDSDiem.TabIndex = 93;
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
            this.gridColumn5.ColumnEdit = this.repositoryItemText_diem;
            this.gridColumn5.FieldName = "Diem";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 100;
            // 
            // repositoryItemText_diem
            // 
            this.repositoryItemText_diem.AutoHeight = false;
            this.repositoryItemText_diem.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemText_diem.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemText_diem.Name = "repositoryItemText_diem";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.lblTenHocVien);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Controls.Add(this.lblMaHV);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.lblKhoa);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.lblTenLop);
            this.panel8.Controls.Add(this.lblMaLop);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label19);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(402, 200);
            this.panel8.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 91;
            this.label6.Text = "Điểm cho môn học:";
            // 
            // lblTenHocVien
            // 
            this.lblTenHocVien.AutoSize = true;
            this.lblTenHocVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenHocVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblTenHocVien.Location = new System.Drawing.Point(102, 152);
            this.lblTenHocVien.Name = "lblTenHocVien";
            this.lblTenHocVien.Size = new System.Drawing.Size(66, 19);
            this.lblTenHocVien.TabIndex = 90;
            this.lblTenHocVien.Text = "<name>";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label13.Location = new System.Drawing.Point(7, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 19);
            this.label13.TabIndex = 89;
            this.label13.Text = "Tên học viên:";
            // 
            // lblMaHV
            // 
            this.lblMaHV.AutoSize = true;
            this.lblMaHV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaHV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblMaHV.Location = new System.Drawing.Point(102, 122);
            this.lblMaHV.Name = "lblMaHV";
            this.lblMaHV.Size = new System.Drawing.Size(42, 19);
            this.lblMaHV.TabIndex = 88;
            this.lblMaHV.Text = "<id>";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label11.Location = new System.Drawing.Point(7, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 19);
            this.label11.TabIndex = 87;
            this.label11.Text = "Mã học viên:";
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhoa.ForeColor = System.Drawing.Color.Blue;
            this.lblKhoa.Location = new System.Drawing.Point(102, 92);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(114, 19);
            this.lblKhoa.TabIndex = 86;
            this.lblKhoa.Text = "<course name>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label8.Location = new System.Drawing.Point(7, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 19);
            this.label8.TabIndex = 85;
            this.label8.Text = "Khóa:";
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenLop.ForeColor = System.Drawing.Color.Green;
            this.lblTenLop.Location = new System.Drawing.Point(102, 62);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(101, 19);
            this.lblTenLop.TabIndex = 84;
            this.lblTenLop.Text = "<class name>";
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblMaLop.Location = new System.Drawing.Point(102, 32);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(77, 19);
            this.lblMaLop.TabIndex = 83;
            this.lblMaLop.Text = "<class id>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label10.Location = new System.Drawing.Point(7, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 19);
            this.label10.TabIndex = 82;
            this.label10.Text = "Tên lớp:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label19.Location = new System.Drawing.Point(7, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 19);
            this.label19.TabIndex = 81;
            this.label19.Text = "Mã lớp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(7, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 21);
            this.label5.TabIndex = 80;
            this.label5.Text = "Điểm của học viên";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnLuuThongTin);
            this.panel7.Controls.Add(this.btnHuyBo);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 478);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(402, 48);
            this.panel7.TabIndex = 80;
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
            this.btnLuuThongTin.Location = new System.Drawing.Point(72, 6);
            this.btnLuuThongTin.Name = "btnLuuThongTin";
            this.btnLuuThongTin.Size = new System.Drawing.Size(125, 34);
            this.btnLuuThongTin.TabIndex = 76;
            this.btnLuuThongTin.Text = "Lưu thông tin";
            this.btnLuuThongTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuThongTin.UseVisualStyleBackColor = false;
            this.btnLuuThongTin.Click += new System.EventHandler(this.btnLuuThongTin_Click);
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
            this.btnHuyBo.Location = new System.Drawing.Point(203, 6);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(93, 34);
            this.btnHuyBo.TabIndex = 77;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuyBo.UseVisualStyleBackColor = false;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(685, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 526);
            this.panel5.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblTongCong);
            this.panel6.Controls.Add(this.label24);
            this.panel6.Controls.Add(this.gridDSHV);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(301, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(384, 526);
            this.panel6.TabIndex = 12;
            // 
            // lblTongCong
            // 
            this.lblTongCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Location = new System.Drawing.Point(16, 501);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(160, 15);
            this.lblTongCong.TabIndex = 68;
            this.lblTongCong.Text = "Tổng cộng: <num> học viên";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(16, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(152, 15);
            this.label24.TabIndex = 67;
            this.label24.Text = "Danh sách học viên của lớp";
            // 
            // gridDSHV
            // 
            this.gridDSHV.AllowUserToAddRows = false;
            this.gridDSHV.AllowUserToResizeRows = false;
            this.gridDSHV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDSHV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDSHV.BackgroundColor = System.Drawing.Color.White;
            this.gridDSHV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDSHV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDSHV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmHocVienId,
            this.clmTenHocVien,
            this.clmGioiTinh});
            this.gridDSHV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDSHV.Location = new System.Drawing.Point(6, 36);
            this.gridDSHV.MultiSelect = false;
            this.gridDSHV.Name = "gridDSHV";
            this.gridDSHV.ReadOnly = true;
            this.gridDSHV.RowHeadersVisible = false;
            this.gridDSHV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDSHV.Size = new System.Drawing.Size(372, 462);
            this.gridDSHV.TabIndex = 66;
            this.gridDSHV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridDSHV_RowsAdded);
            this.gridDSHV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridDSHV_RowsRemoved);
            this.gridDSHV.Click += new System.EventHandler(this.gridDSHV_Click);
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
            this.clmTenHocVien.FillWeight = 93.27411F;
            this.clmTenHocVien.HeaderText = "Tên học viên";
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
            // frmQuanLyDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 550);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuanLyDiem";
            this.Text = "Quản lý điểm";
            this.Load += new System.EventHandler(this.frmQuanLyDiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLop)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemText_diem)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSHV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gridLop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnLuuThongTin;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView gridDSHV;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTenHocVien;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMaHV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;
        private DevExpress.XtraGrid.GridControl gridControlDSDiem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDSDiem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemText_diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLopHocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHocVienId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenHocVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGioiTinh;
    }
}