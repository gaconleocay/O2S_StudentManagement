namespace O2S_StudentManagement.GUI.MenuBaoCao
{
    partial class ucBCTaiChinhGiaoDich_TongHop
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.tbnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.dateDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControlDataBaoCao = new DevExpress.XtraGrid.GridControl();
            this.gridViewDataBaoCao = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButton_ChiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDataBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDataBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButton_ChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.dateDenNgay);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.dateTuNgay);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 86);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.tbnExport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(1075, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(125, 86);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.Image = global::O2S_StudentManagement.Properties.Resources.printer_16;
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(12, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "In...";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tbnExport
            // 
            this.tbnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnExport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tbnExport.Appearance.Options.UseFont = true;
            this.tbnExport.Appearance.Options.UseForeColor = true;
            this.tbnExport.Image = global::O2S_StudentManagement.Properties.Resources.excel_3_16;
            this.tbnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.tbnExport.Location = new System.Drawing.Point(12, 50);
            this.tbnExport.Name = "tbnExport";
            this.tbnExport.Size = new System.Drawing.Size(100, 30);
            this.tbnExport.TabIndex = 10;
            this.tbnExport.Text = "Xuất file";
            this.tbnExport.Click += new System.EventHandler(this.tbnExport_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Appearance.Options.UseForeColor = true;
            this.btnTimKiem.Image = global::O2S_StudentManagement.Properties.Resources.search_3_16;
            this.btnTimKiem.Location = new System.Drawing.Point(238, 25);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.TabIndex = 54;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.EditValue = null;
            this.dateDenNgay.Location = new System.Drawing.Point(38, 46);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay.Properties.Appearance.Options.UseFont = true;
            this.dateDenNgay.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dateDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateDenNgay.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateDenNgay.Properties.CalendarTimeProperties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateDenNgay.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateDenNgay.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateDenNgay.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateDenNgay.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.dateDenNgay.Size = new System.Drawing.Size(150, 22);
            this.dateDenNgay.TabIndex = 53;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl2.Location = new System.Drawing.Point(8, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 16);
            this.labelControl2.TabIndex = 52;
            this.labelControl2.Text = "Đến";
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.EditValue = null;
            this.dateTuNgay.Location = new System.Drawing.Point(38, 14);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay.Properties.Appearance.Options.UseFont = true;
            this.dateTuNgay.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dateTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateTuNgay.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateTuNgay.Properties.CalendarTimeProperties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateTuNgay.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateTuNgay.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateTuNgay.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateTuNgay.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.dateTuNgay.Size = new System.Drawing.Size(150, 22);
            this.dateTuNgay.TabIndex = 51;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Location = new System.Drawing.Point(15, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 16);
            this.labelControl1.TabIndex = 50;
            this.labelControl1.Text = "Từ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControlDataBaoCao);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 614);
            this.panel2.TabIndex = 1;
            // 
            // gridControlDataBaoCao
            // 
            this.gridControlDataBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDataBaoCao.Location = new System.Drawing.Point(0, 0);
            this.gridControlDataBaoCao.MainView = this.gridViewDataBaoCao;
            this.gridControlDataBaoCao.Name = "gridControlDataBaoCao";
            this.gridControlDataBaoCao.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButton_ChiTiet});
            this.gridControlDataBaoCao.Size = new System.Drawing.Size(1200, 614);
            this.gridControlDataBaoCao.TabIndex = 3;
            this.gridControlDataBaoCao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDataBaoCao});
            // 
            // gridViewDataBaoCao
            // 
            this.gridViewDataBaoCao.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridViewDataBaoCao.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridViewDataBaoCao.Appearance.FooterPanel.Options.UseFont = true;
            this.gridViewDataBaoCao.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridViewDataBaoCao.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewDataBaoCao.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewDataBaoCao.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridViewDataBaoCao.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridViewDataBaoCao.Appearance.GroupFooter.Options.UseFont = true;
            this.gridViewDataBaoCao.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewDataBaoCao.Appearance.GroupFooter.Options.UseTextOptions = true;
            this.gridViewDataBaoCao.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewDataBaoCao.ColumnPanelRowHeight = 25;
            this.gridViewDataBaoCao.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn20});
            this.gridViewDataBaoCao.GridControl = this.gridControlDataBaoCao;
            this.gridViewDataBaoCao.Name = "gridViewDataBaoCao";
            this.gridViewDataBaoCao.OptionsFind.AlwaysVisible = true;
            this.gridViewDataBaoCao.OptionsFind.FindNullPrompt = "Từ khóa tìm kiếm...";
            this.gridViewDataBaoCao.OptionsFind.ShowClearButton = false;
            this.gridViewDataBaoCao.OptionsView.ColumnAutoWidth = false;
            this.gridViewDataBaoCao.OptionsView.RowAutoHeight = true;
            this.gridViewDataBaoCao.OptionsView.ShowGroupPanel = false;
            this.gridViewDataBaoCao.OptionsView.ShowIndicator = false;
            this.gridViewDataBaoCao.RowHeight = 25;
            this.gridViewDataBaoCao.ViewCaptionHeight = 25;
            this.gridViewDataBaoCao.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewDataBaoCao_RowCellStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "stt";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 45;
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
            this.gridColumn2.Caption = "Loại giao dịch";
            this.gridColumn2.FieldName = "loaigiaodich";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 247;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn20.AppearanceCell.Options.UseFont = true;
            this.gridColumn20.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridColumn20.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gridColumn20.AppearanceHeader.Options.UseFont = true;
            this.gridColumn20.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.Caption = "Số tiền";
            this.gridColumn20.DisplayFormat.FormatString = "#,##0";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn20.FieldName = "sotien";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 2;
            this.gridColumn20.Width = 237;
            // 
            // repositoryItemButton_ChiTiet
            // 
            this.repositoryItemButton_ChiTiet.AutoHeight = false;
            this.repositoryItemButton_ChiTiet.Name = "repositoryItemButton_ChiTiet";
            // 
            // ucBCTaiChinhGiaoDich_TongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucBCTaiChinhGiaoDich_TongHop";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.ucBCTaiChinhGiaoDich_TongHopcs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDataBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDataBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButton_ChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.DateEdit dateDenNgay;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateTuNgay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControlDataBaoCao;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDataBaoCao;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButton_ChiTiet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton tbnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
    }
}
