namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    partial class ucQLHVDM_QuocGia
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQLHVDM_QuocGia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLuuLai = new DevExpress.XtraEditors.SimpleButton();
            this.btnNhapTuExcel = new DevExpress.XtraEditors.SimpleButton();
            this.panelNoiDung = new System.Windows.Forms.Panel();
            this.gridControlDichVu = new DevExpress.XtraGrid.GridControl();
            this.gridViewDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialogSelect = new System.Windows.Forms.OpenFileDialog();
            this.imageCollectionDSBN = new DevExpress.Utils.ImageCollection(this.components);
            this.panel1.SuspendLayout();
            this.panelNoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionDSBN)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLuuLai);
            this.panel1.Controls.Add(this.btnNhapTuExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 41);
            this.panel1.TabIndex = 0;
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuLai.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLuuLai.Appearance.Options.UseFont = true;
            this.btnLuuLai.Appearance.Options.UseForeColor = true;
            this.btnLuuLai.Image = global::O2S_StudentManagement.Properties.Resources.save_16;
            this.btnLuuLai.Location = new System.Drawing.Point(515, 5);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(120, 30);
            this.btnLuuLai.TabIndex = 34;
            this.btnLuuLai.Text = "Lưu";
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // btnNhapTuExcel
            // 
            this.btnNhapTuExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapTuExcel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNhapTuExcel.Appearance.Options.UseFont = true;
            this.btnNhapTuExcel.Appearance.Options.UseForeColor = true;
            this.btnNhapTuExcel.Image = global::O2S_StudentManagement.Properties.Resources.excel_3_16;
            this.btnNhapTuExcel.Location = new System.Drawing.Point(18, 5);
            this.btnNhapTuExcel.Name = "btnNhapTuExcel";
            this.btnNhapTuExcel.Size = new System.Drawing.Size(120, 30);
            this.btnNhapTuExcel.TabIndex = 33;
            this.btnNhapTuExcel.Text = "Nhập từ excel";
            this.btnNhapTuExcel.Click += new System.EventHandler(this.btnNhapTuExcel_Click);
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.Controls.Add(this.gridControlDichVu);
            this.panelNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoiDung.Location = new System.Drawing.Point(0, 41);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(1000, 572);
            this.panelNoiDung.TabIndex = 1;
            // 
            // gridControlDichVu
            // 
            this.gridControlDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDichVu.Location = new System.Drawing.Point(0, 0);
            this.gridControlDichVu.MainView = this.gridViewDichVu;
            this.gridControlDichVu.Name = "gridControlDichVu";
            this.gridControlDichVu.Size = new System.Drawing.Size(1000, 572);
            this.gridControlDichVu.TabIndex = 0;
            this.gridControlDichVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDichVu});
            // 
            // gridViewDichVu
            // 
            this.gridViewDichVu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridViewDichVu.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridViewDichVu.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewDichVu.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewDichVu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDichVu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDichVu.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridViewDichVu.Appearance.Row.Options.UseFont = true;
            this.gridViewDichVu.ColumnPanelRowHeight = 25;
            this.gridViewDichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.gridViewDichVu.GridControl = this.gridControlDichVu;
            this.gridViewDichVu.Name = "gridViewDichVu";
            this.gridViewDichVu.OptionsFind.AlwaysVisible = true;
            this.gridViewDichVu.OptionsFind.FindNullPrompt = "Từ khóa tìm kiếm";
            this.gridViewDichVu.OptionsFind.ShowClearButton = false;
            this.gridViewDichVu.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridViewDichVu.OptionsSelection.InvertSelection = true;
            this.gridViewDichVu.OptionsSelection.MultiSelect = true;
            this.gridViewDichVu.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewDichVu.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridViewDichVu.OptionsView.ColumnAutoWidth = false;
            this.gridViewDichVu.OptionsView.ShowGroupPanel = false;
            this.gridViewDichVu.OptionsView.ShowIndicator = false;
            this.gridViewDichVu.RowHeight = 25;
            this.gridViewDichVu.ViewCaptionHeight = 25;
            this.gridViewDichVu.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewDichVu_RowCellStyle);
            this.gridViewDichVu.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewDichVu_PopupMenuShowing);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "STT";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã";
            this.gridColumn2.FieldName = "code";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên tiếng Việt";
            this.gridColumn3.FieldName = "name_vn";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 200;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn4.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Tên tiếng Anh";
            this.gridColumn4.FieldName = "name_en";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 200;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn5.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Trạng thái";
            this.gridColumn5.FieldName = "isremove";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 125;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn14.AppearanceCell.Options.UseFont = true;
            this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn14.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn14.AppearanceHeader.Options.UseFont = true;
            this.gridColumn14.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "Người sửa";
            this.gridColumn14.FieldName = "modified_by";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            this.gridColumn14.Width = 160;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn15.AppearanceCell.Options.UseFont = true;
            this.gridColumn15.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn15.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn15.AppearanceHeader.Options.UseFont = true;
            this.gridColumn15.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "Thời gian sửa";
            this.gridColumn15.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn15.FieldName = "modified_date";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 9;
            this.gridColumn15.Width = 125;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "ID";
            this.gridColumn16.FieldName = "id";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn17.AppearanceCell.Options.UseFont = true;
            this.gridColumn17.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn17.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn17.AppearanceHeader.Options.UseFont = true;
            this.gridColumn17.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "Người tạo";
            this.gridColumn17.FieldName = "created_by";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 6;
            this.gridColumn17.Width = 160;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn18.AppearanceCell.Options.UseFont = true;
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn18.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn18.AppearanceHeader.Options.UseFont = true;
            this.gridColumn18.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "Thời gian tạo";
            this.gridColumn18.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn18.FieldName = "created_date";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 7;
            this.gridColumn18.Width = 125;
            // 
            // openFileDialogSelect
            // 
            this.openFileDialogSelect.Filter = "Excel 2007-2013|*.xlsx|Excel 2003|*.xls";
            this.openFileDialogSelect.Title = "Mở file Excel";
            // 
            // imageCollectionDSBN
            // 
            this.imageCollectionDSBN.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionDSBN.ImageStream")));
            this.imageCollectionDSBN.Images.SetKeyName(0, "delete-16.png");
            // 
            // ucQLHVDM_QuocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelNoiDung);
            this.Controls.Add(this.panel1);
            this.Name = "ucQLHVDM_QuocGia";
            this.Size = new System.Drawing.Size(1000, 613);
            this.Load += new System.EventHandler(this.ucQLHVDM_QuocGia_Load);
            this.panel1.ResumeLayout(false);
            this.panelNoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionDSBN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelNoiDung;
        private DevExpress.XtraEditors.SimpleButton btnLuuLai;
        private DevExpress.XtraEditors.SimpleButton btnNhapTuExcel;
        private DevExpress.XtraGrid.GridControl gridControlDichVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDichVu;
        internal System.Windows.Forms.OpenFileDialog openFileDialogSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.Utils.ImageCollection imageCollectionDSBN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
    }
}
