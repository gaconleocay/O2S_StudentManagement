namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    partial class ucQLHV_NghiepVu
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
            this.xtraTabControlQLHV_NghiepVu = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabQLHV_TTHV = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabQLHV_KTDV = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabQLHV_BaoCao = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlQLHV_NghiepVu)).BeginInit();
            this.xtraTabControlQLHV_NghiepVu.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControlQLHV_NghiepVu
            // 
            this.xtraTabControlQLHV_NghiepVu.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControlQLHV_NghiepVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlQLHV_NghiepVu.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlQLHV_NghiepVu.Name = "xtraTabControlQLHV_NghiepVu";
            this.xtraTabControlQLHV_NghiepVu.SelectedTabPage = this.xtraTabQLHV_TTHV;
            this.xtraTabControlQLHV_NghiepVu.Size = new System.Drawing.Size(1200, 700);
            this.xtraTabControlQLHV_NghiepVu.TabIndex = 0;
            this.xtraTabControlQLHV_NghiepVu.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabQLHV_TTHV,
            this.xtraTabQLHV_KTDV,
            this.xtraTabQLHV_BaoCao});
            this.xtraTabControlQLHV_NghiepVu.TabPageWidth = 160;
            this.xtraTabControlQLHV_NghiepVu.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlCongCuKhac_SelectedPageChanged);
            this.xtraTabControlQLHV_NghiepVu.CloseButtonClick += new System.EventHandler(this.xtraTabControlCongCuKhac_CloseButtonClick);
            // 
            // xtraTabQLHV_TTHV
            // 
            this.xtraTabQLHV_TTHV.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabQLHV_TTHV.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTabQLHV_TTHV.Appearance.Header.Options.UseFont = true;
            this.xtraTabQLHV_TTHV.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabQLHV_TTHV.Image = global::O2S_StudentManagement.Properties.Resources.group_16;
            this.xtraTabQLHV_TTHV.Name = "xtraTabQLHV_TTHV";
            this.xtraTabQLHV_TTHV.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTabQLHV_TTHV.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabQLHV_TTHV.Size = new System.Drawing.Size(1194, 669);
            this.xtraTabQLHV_TTHV.Text = "Thông tin học viên";
            this.xtraTabQLHV_TTHV.Tooltip = "Thông tin học viên";
            // 
            // xtraTabQLHV_KTDV
            // 
            this.xtraTabQLHV_KTDV.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabQLHV_KTDV.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTabQLHV_KTDV.Appearance.Header.Options.UseFont = true;
            this.xtraTabQLHV_KTDV.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabQLHV_KTDV.Image = global::O2S_StudentManagement.Properties.Resources.text_file_4_16;
            this.xtraTabQLHV_KTDV.Name = "xtraTabQLHV_KTDV";
            this.xtraTabQLHV_KTDV.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTabQLHV_KTDV.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabQLHV_KTDV.Size = new System.Drawing.Size(1194, 669);
            this.xtraTabQLHV_KTDV.Text = "Kiểm tra đầu vào";
            this.xtraTabQLHV_KTDV.Tooltip = "Kiểm tra đầu vào";
            // 
            // xtraTabQLHV_BaoCao
            // 
            this.xtraTabQLHV_BaoCao.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabQLHV_BaoCao.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTabQLHV_BaoCao.Appearance.Header.Options.UseFont = true;
            this.xtraTabQLHV_BaoCao.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabQLHV_BaoCao.Image = global::O2S_StudentManagement.Properties.Resources.excel_3_16;
            this.xtraTabQLHV_BaoCao.Name = "xtraTabQLHV_BaoCao";
            this.xtraTabQLHV_BaoCao.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTabQLHV_BaoCao.PageEnabled = false;
            this.xtraTabQLHV_BaoCao.PageVisible = false;
            this.xtraTabQLHV_BaoCao.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabQLHV_BaoCao.Size = new System.Drawing.Size(1194, 669);
            this.xtraTabQLHV_BaoCao.Text = "Báo cáo";
            this.xtraTabQLHV_BaoCao.Tooltip = "Báo cáo";
            // 
            // ucQLHV_NghiepVu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.xtraTabControlQLHV_NghiepVu);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucQLHV_NghiepVu";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.ucMenuGiamDinhXML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlQLHV_NghiepVu)).EndInit();
            this.xtraTabControlQLHV_NghiepVu.ResumeLayout(false);
            this.ResumeLayout(false);

        }




        #endregion
        private DevExpress.XtraTab.XtraTabPage xtraTabQLHV_TTHV;
        internal DevExpress.XtraTab.XtraTabControl xtraTabControlQLHV_NghiepVu;
        private DevExpress.XtraTab.XtraTabPage xtraTabQLHV_BaoCao;
        private DevExpress.XtraTab.XtraTabPage xtraTabQLHV_KTDV;
    }
}
