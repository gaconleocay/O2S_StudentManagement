namespace O2S_QuanLyHocVien.ChucNang
{
    partial class frmLichHocTheoLopHoc
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gridControlDataBC = new DevExpress.XtraGrid.GridControl();
            this.bandedGridViewDataBC = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnInAn = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDataBC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewDataBC)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 676);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gridControlDataBC);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1100, 616);
            this.panel4.TabIndex = 1;
            // 
            // gridControlDataBC
            // 
            this.gridControlDataBC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDataBC.Location = new System.Drawing.Point(0, 0);
            this.gridControlDataBC.MainView = this.bandedGridViewDataBC;
            this.gridControlDataBC.Name = "gridControlDataBC";
            this.gridControlDataBC.Size = new System.Drawing.Size(1100, 616);
            this.gridControlDataBC.TabIndex = 46;
            this.gridControlDataBC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridViewDataBC});
            // 
            // bandedGridViewDataBC
            // 
            this.bandedGridViewDataBC.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.bandedGridViewDataBC.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bandedGridViewDataBC.Appearance.FooterPanel.Options.UseFont = true;
            this.bandedGridViewDataBC.Appearance.FooterPanel.Options.UseForeColor = true;
            this.bandedGridViewDataBC.BandPanelRowHeight = 25;
            this.bandedGridViewDataBC.ColumnPanelRowHeight = 25;
            this.bandedGridViewDataBC.FooterPanelHeight = 25;
            this.bandedGridViewDataBC.GridControl = this.gridControlDataBC;
            this.bandedGridViewDataBC.GroupRowHeight = 25;
            this.bandedGridViewDataBC.Name = "bandedGridViewDataBC";
            this.bandedGridViewDataBC.OptionsFind.AlwaysVisible = true;
            this.bandedGridViewDataBC.OptionsFind.FindNullPrompt = "Từ khóa tìm kiếm...";
            this.bandedGridViewDataBC.OptionsView.ColumnAutoWidth = false;
            this.bandedGridViewDataBC.OptionsView.EnableAppearanceEvenRow = true;
            this.bandedGridViewDataBC.OptionsView.ShowGroupPanel = false;
            this.bandedGridViewDataBC.OptionsView.ShowIndicator = false;
            this.bandedGridViewDataBC.RowHeight = 25;
            this.bandedGridViewDataBC.ViewCaptionHeight = 25;
            this.bandedGridViewDataBC.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewDSHocVien_RowCellStyle);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboKhoaHoc);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1100, 60);
            this.panel3.TabIndex = 0;
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(80, 17);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(210, 25);
            this.cboKhoaHoc.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 69;
            this.label3.Text = "Khóa học:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnXuatExcel);
            this.panel5.Controls.Add(this.btnInAn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(837, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(263, 60);
            this.panel5.TabIndex = 68;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatExcel.BackColor = System.Drawing.Color.Silver;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnXuatExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.Image = global::O2S_QuanLyHocVien.Properties.Resources.excel_3_16;
            this.btnXuatExcel.Location = new System.Drawing.Point(143, 15);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(108, 29);
            this.btnXuatExcel.TabIndex = 67;
            this.btnXuatExcel.Text = "Xuất excel";
            this.btnXuatExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnInAn
            // 
            this.btnInAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInAn.BackColor = System.Drawing.Color.Silver;
            this.btnInAn.FlatAppearance.BorderSize = 0;
            this.btnInAn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnInAn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInAn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInAn.Image = global::O2S_QuanLyHocVien.Properties.Resources.printer_16;
            this.btnInAn.Location = new System.Drawing.Point(15, 15);
            this.btnInAn.Name = "btnInAn";
            this.btnInAn.Size = new System.Drawing.Size(108, 29);
            this.btnInAn.TabIndex = 66;
            this.btnInAn.Text = "In...";
            this.btnInAn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInAn.UseVisualStyleBackColor = false;
            this.btnInAn.Visible = false;
            this.btnInAn.Click += new System.EventHandler(this.btnInAn_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Silver;
            this.btnTimKiem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Image = global::O2S_QuanLyHocVien.Properties.Resources.zoom_16x16;
            this.btnTimKiem.Location = new System.Drawing.Point(404, 15);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 29);
            this.btnTimKiem.TabIndex = 65;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 24);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "LỊCH HỌC THEO LỚP HỌC";
            // 
            // frmLichHocTheoLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLichHocTheoLopHoc";
            this.Text = "Báo cáo học viên ghi danh theo tháng";
            this.Load += new System.EventHandler(this.frmBaoCaoHocVienTheoThang_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDataBC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewDataBC)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnInAn;
        private DevExpress.XtraGrid.GridControl gridControlDataBC;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridViewDataBC;
    }
}