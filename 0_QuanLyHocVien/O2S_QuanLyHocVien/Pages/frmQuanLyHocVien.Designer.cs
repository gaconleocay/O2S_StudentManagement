namespace O2S_QuanLyHocVien.Pages
{
    partial class frmQuanLyHocVien
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboLoaiHV = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.date_DenNgay = new DevExpress.XtraEditors.DateEdit();
            this.date_TuNgay = new DevExpress.XtraEditors.DateEdit();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.gridDSHV = new System.Windows.Forms.DataGridView();
            this.clmHocVienId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lmDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSdtBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmailBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSdtMe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmailMe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLoaiHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_DenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_TuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_TuNgay.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSHV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTongCong);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 457);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 38);
            this.panel3.TabIndex = 2;
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Location = new System.Drawing.Point(9, 7);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(160, 15);
            this.lblTongCong.TabIndex = 11;
            this.lblTongCong.Text = "Tổng cộng: <num> học viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 37);
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
            this.btnThem.Text = "Thêm học viên";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboLoaiHV
            // 
            this.cboLoaiHV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLoaiHV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiHV.FormattingEnabled = true;
            this.cboLoaiHV.Location = new System.Drawing.Point(97, 46);
            this.cboLoaiHV.Name = "cboLoaiHV";
            this.cboLoaiHV.Size = new System.Drawing.Size(186, 25);
            this.cboLoaiHV.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Loại học viên:";
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
            this.splitContainer1.Panel1.Controls.Add(this.date_DenNgay);
            this.splitContainer1.Panel1.Controls.Add(this.date_TuNgay);
            this.splitContainer1.Panel1.Controls.Add(this.cboLoaiHV);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.btnTimKiem);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.gridDSHV);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 495);
            this.splitContainer1.SplitterDistance = 298;
            this.splitContainer1.TabIndex = 3;
            // 
            // date_DenNgay
            // 
            this.date_DenNgay.EditValue = null;
            this.date_DenNgay.Location = new System.Drawing.Point(97, 124);
            this.date_DenNgay.Name = "date_DenNgay";
            this.date_DenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_DenNgay.Properties.Appearance.Options.UseFont = true;
            this.date_DenNgay.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_DenNgay.Properties.AppearanceDropDown.Options.UseFont = true;
            this.date_DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_DenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_DenNgay.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.date_DenNgay.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_DenNgay.Properties.CalendarTimeProperties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.date_DenNgay.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_DenNgay.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.date_DenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_DenNgay.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.date_DenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_DenNgay.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.date_DenNgay.Size = new System.Drawing.Size(186, 22);
            this.date_DenNgay.TabIndex = 62;
            // 
            // date_TuNgay
            // 
            this.date_TuNgay.EditValue = null;
            this.date_TuNgay.Location = new System.Drawing.Point(97, 89);
            this.date_TuNgay.Name = "date_TuNgay";
            this.date_TuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_TuNgay.Properties.Appearance.Options.UseFont = true;
            this.date_TuNgay.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_TuNgay.Properties.AppearanceDropDown.Options.UseFont = true;
            this.date_TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_TuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_TuNgay.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.date_TuNgay.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_TuNgay.Properties.CalendarTimeProperties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.date_TuNgay.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_TuNgay.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.date_TuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_TuNgay.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.date_TuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_TuNgay.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.date_TuNgay.Size = new System.Drawing.Size(186, 22);
            this.date_TuNgay.TabIndex = 61;
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
            this.btnTimKiem.Location = new System.Drawing.Point(81, 173);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 29);
            this.btnTimKiem.TabIndex = 60;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 58;
            this.label6.Text = "Đến ngày:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 56;
            this.label7.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(17, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tìm kiếm học viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ HỌC VIÊN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 24);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::O2S_QuanLyHocVien.Properties.Resources.icon_Close_9dp;
            this.btnClose.Location = new System.Drawing.Point(1068, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 19);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridDSHV
            // 
            this.gridDSHV.AllowUserToAddRows = false;
            this.gridDSHV.BackgroundColor = System.Drawing.Color.White;
            this.gridDSHV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDSHV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmHocVienId,
            this.clmTenHocVien,
            this.clmNgaySinh,
            this.clmGioiTinh,
            this.lmDiaChi,
            this.clmSdt,
            this.clmEmail,
            this.clmSdtBo,
            this.clmEmailBo,
            this.clmSdtMe,
            this.clmEmailMe,
            this.clmLoaiHocVien});
            this.gridDSHV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDSHV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDSHV.Location = new System.Drawing.Point(0, 37);
            this.gridDSHV.MultiSelect = false;
            this.gridDSHV.Name = "gridDSHV";
            this.gridDSHV.RowHeadersVisible = false;
            this.gridDSHV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDSHV.Size = new System.Drawing.Size(806, 420);
            this.gridDSHV.TabIndex = 3;
            // 
            // clmHocVienId
            // 
            this.clmHocVienId.DataPropertyName = "HocVienId";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.clmHocVienId.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmHocVienId.HeaderText = "Mã học viên";
            this.clmHocVienId.Name = "clmHocVienId";
            this.clmHocVienId.Width = 80;
            // 
            // clmTenHocVien
            // 
            this.clmTenHocVien.DataPropertyName = "TenHocVien";
            this.clmTenHocVien.HeaderText = "Họ và tên";
            this.clmTenHocVien.Name = "clmTenHocVien";
            this.clmTenHocVien.Width = 150;
            // 
            // clmNgaySinh
            // 
            this.clmNgaySinh.DataPropertyName = "NgaySinh";
            this.clmNgaySinh.HeaderText = "Ngày sinh";
            this.clmNgaySinh.Name = "clmNgaySinh";
            this.clmNgaySinh.Width = 85;
            // 
            // clmGioiTinh
            // 
            this.clmGioiTinh.DataPropertyName = "GioiTinh";
            this.clmGioiTinh.HeaderText = "Giới tính";
            this.clmGioiTinh.Name = "clmGioiTinh";
            this.clmGioiTinh.Width = 77;
            // 
            // lmDiaChi
            // 
            this.lmDiaChi.DataPropertyName = "DiaChi";
            this.lmDiaChi.HeaderText = "Địa chỉ";
            this.lmDiaChi.Name = "lmDiaChi";
            this.lmDiaChi.Width = 200;
            // 
            // clmSdt
            // 
            this.clmSdt.DataPropertyName = "Sdt";
            this.clmSdt.HeaderText = "SĐT";
            this.clmSdt.Name = "clmSdt";
            // 
            // clmEmail
            // 
            this.clmEmail.DataPropertyName = "Email";
            this.clmEmail.HeaderText = "Email";
            this.clmEmail.Name = "clmEmail";
            this.clmEmail.Width = 120;
            // 
            // clmSdtBo
            // 
            this.clmSdtBo.DataPropertyName = "SdtBo";
            this.clmSdtBo.HeaderText = "SĐT của bố";
            this.clmSdtBo.Name = "clmSdtBo";
            // 
            // clmEmailBo
            // 
            this.clmEmailBo.DataPropertyName = "EmailBo";
            this.clmEmailBo.HeaderText = "Email của bố";
            this.clmEmailBo.Name = "clmEmailBo";
            this.clmEmailBo.Width = 120;
            // 
            // clmSdtMe
            // 
            this.clmSdtMe.DataPropertyName = "SdtMe";
            this.clmSdtMe.HeaderText = "SĐT của mẹ";
            this.clmSdtMe.Name = "clmSdtMe";
            // 
            // clmEmailMe
            // 
            this.clmEmailMe.DataPropertyName = "EmailMe";
            this.clmEmailMe.HeaderText = "Email của mẹ";
            this.clmEmailMe.Name = "clmEmailMe";
            this.clmEmailMe.Width = 120;
            // 
            // clmLoaiHocVien
            // 
            this.clmLoaiHocVien.DataPropertyName = "TenLoaiHocVien";
            this.clmLoaiHocVien.HeaderText = "Loại học viên";
            this.clmLoaiHocVien.Name = "clmLoaiHocVien";
            // 
            // frmQuanLyHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 519);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuanLyHocVien";
            this.Text = "Quản lý học viên";
            this.Load += new System.EventHandler(this.frmQuanLyHocVien_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_DenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_TuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_TuNgay.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSHV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboLoaiHV;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.DateEdit date_DenNgay;
        private DevExpress.XtraEditors.DateEdit date_TuNgay;
        private System.Windows.Forms.DataGridView gridDSHV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHocVienId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenHocVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn lmDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSdtBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmailBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSdtMe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmailMe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLoaiHocVien;
    }
}