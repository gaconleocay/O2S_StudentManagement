namespace O2S_QuanLyHocVien.Pages
{
    partial class frmQuanLyKhoaHoc
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
            this.gridControlDSMonHoc = new DevExpress.XtraGrid.GridControl();
            this.gridViewDSMonHoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numHocPhi = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnLuuThongTin = new System.Windows.Forms.Button();
            this.txtTenKhoaHoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaKhoaHoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridKH = new System.Windows.Forms.DataGridView();
            this.clmKhoaHocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHocPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHocPhi)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ KHÓA HỌC";
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
            this.splitContainer1.Panel1.Controls.Add(this.gridControlDSMonHoc);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.numHocPhi);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btnHuyBo);
            this.splitContainer1.Panel1.Controls.Add(this.btnLuuThongTin);
            this.splitContainer1.Panel1.Controls.Add(this.txtTenKhoaHoc);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtMaKhoaHoc);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.gridKH);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1086, 516);
            this.splitContainer1.SplitterDistance = 501;
            this.splitContainer1.TabIndex = 6;
            // 
            // gridControlDSMonHoc
            // 
            this.gridControlDSMonHoc.Location = new System.Drawing.Point(21, 162);
            this.gridControlDSMonHoc.MainView = this.gridViewDSMonHoc;
            this.gridControlDSMonHoc.Name = "gridControlDSMonHoc";
            this.gridControlDSMonHoc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlDSMonHoc.Size = new System.Drawing.Size(462, 289);
            this.gridControlDSMonHoc.TabIndex = 23;
            this.gridControlDSMonHoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDSMonHoc});
            // 
            // gridViewDSMonHoc
            // 
            this.gridViewDSMonHoc.ColumnPanelRowHeight = 25;
            this.gridViewDSMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridViewDSMonHoc.GridControl = this.gridControlDSMonHoc;
            this.gridViewDSMonHoc.Name = "gridViewDSMonHoc";
            this.gridViewDSMonHoc.OptionsView.ShowGroupPanel = false;
            this.gridViewDSMonHoc.OptionsView.ShowIndicator = false;
            this.gridViewDSMonHoc.RowHeight = 25;
            this.gridViewDSMonHoc.ViewCaptionHeight = 25;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Check";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "IsCheck";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ShowCaption = false;
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 35;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
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
            this.gridColumn3.VisibleIndex = 1;
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
            this.gridColumn4.VisibleIndex = 2;
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
            this.gridColumn5.Caption = "Điểm đạt";
            this.gridColumn5.FieldName = "DiemDat";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Danh sách môn học:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(296, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "đ";
            // 
            // numHocPhi
            // 
            this.numHocPhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numHocPhi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.numHocPhi.ForeColor = System.Drawing.Color.Blue;
            this.numHocPhi.Location = new System.Drawing.Point(103, 94);
            this.numHocPhi.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numHocPhi.Name = "numHocPhi";
            this.numHocPhi.Size = new System.Drawing.Size(187, 25);
            this.numHocPhi.TabIndex = 20;
            this.numHocPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Học phí:";
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
            this.btnHuyBo.Location = new System.Drawing.Point(375, 457);
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
            this.btnLuuThongTin.Location = new System.Drawing.Point(248, 457);
            this.btnLuuThongTin.Name = "btnLuuThongTin";
            this.btnLuuThongTin.Size = new System.Drawing.Size(121, 34);
            this.btnLuuThongTin.TabIndex = 17;
            this.btnLuuThongTin.Text = "Lưu thông tin";
            this.btnLuuThongTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuThongTin.UseVisualStyleBackColor = false;
            this.btnLuuThongTin.Click += new System.EventHandler(this.btnLuuThongTin_Click);
            // 
            // txtTenKhoaHoc
            // 
            this.txtTenKhoaHoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenKhoaHoc.Location = new System.Drawing.Point(103, 52);
            this.txtTenKhoaHoc.Name = "txtTenKhoaHoc";
            this.txtTenKhoaHoc.Size = new System.Drawing.Size(380, 25);
            this.txtTenKhoaHoc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên khóa học:";
            // 
            // txtMaKhoaHoc
            // 
            this.txtMaKhoaHoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaKhoaHoc.Enabled = false;
            this.txtMaKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaKhoaHoc.Location = new System.Drawing.Point(103, 12);
            this.txtMaKhoaHoc.Name = "txtMaKhoaHoc";
            this.txtMaKhoaHoc.ReadOnly = true;
            this.txtMaKhoaHoc.Size = new System.Drawing.Size(187, 25);
            this.txtMaKhoaHoc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã khóa học:";
            // 
            // gridKH
            // 
            this.gridKH.AllowUserToAddRows = false;
            this.gridKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridKH.BackgroundColor = System.Drawing.Color.White;
            this.gridKH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmKhoaHocId,
            this.clmTenKhoaHoc,
            this.clmHocPhi});
            this.gridKH.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridKH.Location = new System.Drawing.Point(12, 39);
            this.gridKH.MultiSelect = false;
            this.gridKH.Name = "gridKH";
            this.gridKH.RowHeadersVisible = false;
            this.gridKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridKH.Size = new System.Drawing.Size(557, 441);
            this.gridKH.TabIndex = 1;
            this.gridKH.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridKH_RowsAdded);
            this.gridKH.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridKH_RowsRemoved);
            this.gridKH.Click += new System.EventHandler(this.gridKH_Click);
            this.gridKH.DoubleClick += new System.EventHandler(this.gridKH_DoubleClick);
            // 
            // clmKhoaHocId
            // 
            this.clmKhoaHocId.DataPropertyName = "KhoaHocId";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.clmKhoaHocId.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmKhoaHocId.HeaderText = "Mã khóa học";
            this.clmKhoaHocId.Name = "clmKhoaHocId";
            // 
            // clmTenKhoaHoc
            // 
            this.clmTenKhoaHoc.DataPropertyName = "TenKhoaHoc";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Green;
            this.clmTenKhoaHoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmTenKhoaHoc.FillWeight = 120F;
            this.clmTenKhoaHoc.HeaderText = "Tên khóa học";
            this.clmTenKhoaHoc.Name = "clmTenKhoaHoc";
            // 
            // clmHocPhi
            // 
            this.clmHocPhi.DataPropertyName = "HocPhi";
            this.clmHocPhi.HeaderText = "Học phí";
            this.clmHocPhi.Name = "clmHocPhi";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTongCong);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 486);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(581, 30);
            this.panel3.TabIndex = 2;
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Location = new System.Drawing.Point(9, 7);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(164, 15);
            this.lblTongCong.TabIndex = 11;
            this.lblTongCong.Text = "Tổng cộng: <num> khóa học";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(581, 37);
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
            this.btnThem.Text = "Thêm khóa học";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmQuanLyKhoaHoc
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
            this.Name = "frmQuanLyKhoaHoc";
            this.Text = "Quản lý khóa học";
            this.Load += new System.EventHandler(this.frmQuanLyKhoaHoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDSMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHocPhi)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numHocPhi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnLuuThongTin;
        private System.Windows.Forms.TextBox txtTenKhoaHoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaKhoaHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridKH;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.GridControl gridControlDSMonHoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDSMonHoc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKhoaHocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHocPhi;
    }
}