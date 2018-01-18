namespace O2S_StudentManagement.GUI.FormCommon
{
    partial class ucMenuQLGiaoVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMenuQLGiaoVien));
            this.xtraTabControlQLHocVien = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabQLHV_DanhMuc = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabQLHV_TTHocVien = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabQLHV_KTDauVao = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlQLHocVien)).BeginInit();
            this.xtraTabControlQLHocVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControlQLHocVien
            // 
            this.xtraTabControlQLHocVien.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControlQLHocVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlQLHocVien.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlQLHocVien.Name = "xtraTabControlQLHocVien";
            this.xtraTabControlQLHocVien.SelectedTabPage = this.xtraTabQLHV_DanhMuc;
            this.xtraTabControlQLHocVien.Size = new System.Drawing.Size(1200, 700);
            this.xtraTabControlQLHocVien.TabIndex = 0;
            this.xtraTabControlQLHocVien.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabQLHV_DanhMuc,
            this.xtraTabQLHV_TTHocVien,
            this.xtraTabQLHV_KTDauVao});
            this.xtraTabControlQLHocVien.TabPageWidth = 160;
            this.xtraTabControlQLHocVien.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlCongCuKhac_SelectedPageChanged);
            this.xtraTabControlQLHocVien.CloseButtonClick += new System.EventHandler(this.xtraTabControlCongCuKhac_CloseButtonClick);
            // 
            // xtraTabQLHV_DanhMuc
            // 
            this.xtraTabQLHV_DanhMuc.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabQLHV_DanhMuc.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTabQLHV_DanhMuc.Appearance.Header.Options.UseFont = true;
            this.xtraTabQLHV_DanhMuc.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabQLHV_DanhMuc.Image = global::O2S_StudentManagement.Properties.Resources.list_rich_16;
            this.xtraTabQLHV_DanhMuc.Name = "xtraTabQLHV_DanhMuc";
            this.xtraTabQLHV_DanhMuc.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTabQLHV_DanhMuc.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabQLHV_DanhMuc.Size = new System.Drawing.Size(1194, 669);
            this.xtraTabQLHV_DanhMuc.Text = "Danh mục";
            this.xtraTabQLHV_DanhMuc.Tooltip = "Danh mục";
            // 
            // xtraTabQLHV_TTHocVien
            // 
            this.xtraTabQLHV_TTHocVien.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabQLHV_TTHocVien.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTabQLHV_TTHocVien.Appearance.Header.Options.UseFont = true;
            this.xtraTabQLHV_TTHocVien.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabQLHV_TTHocVien.Image = global::O2S_StudentManagement.Properties.Resources.group_16;
            this.xtraTabQLHV_TTHocVien.Name = "xtraTabQLHV_TTHocVien";
            this.xtraTabQLHV_TTHocVien.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTabQLHV_TTHocVien.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabQLHV_TTHocVien.Size = new System.Drawing.Size(1194, 669);
            this.xtraTabQLHV_TTHocVien.Text = "Thông tin học viên";
            this.xtraTabQLHV_TTHocVien.Tooltip = "Thông tin học viên";
            // 
            // xtraTabQLHV_KTDauVao
            // 
            this.xtraTabQLHV_KTDauVao.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabQLHV_KTDauVao.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTabQLHV_KTDauVao.Appearance.Header.Options.UseFont = true;
            this.xtraTabQLHV_KTDauVao.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabQLHV_KTDauVao.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabQLHV_KTDauVao.Image")));
            this.xtraTabQLHV_KTDauVao.Name = "xtraTabQLHV_KTDauVao";
            this.xtraTabQLHV_KTDauVao.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTabQLHV_KTDauVao.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabQLHV_KTDauVao.Size = new System.Drawing.Size(1194, 669);
            this.xtraTabQLHV_KTDauVao.Text = "Kiểm tra đầu vào";
            this.xtraTabQLHV_KTDauVao.Tooltip = "Kiểm tra đầu vào";
            // 
            // ucMenuQLGiaoVien
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.xtraTabControlQLHocVien);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMenuQLGiaoVien";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.ucMenuGiamDinhXML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlQLHocVien)).EndInit();
            this.xtraTabControlQLHocVien.ResumeLayout(false);
            this.ResumeLayout(false);

        }




        #endregion
        private DevExpress.XtraTab.XtraTabPage xtraTabQLHV_DanhMuc;
        internal DevExpress.XtraTab.XtraTabControl xtraTabControlQLHocVien;
        private DevExpress.XtraTab.XtraTabPage xtraTabQLHV_KTDauVao;
        private DevExpress.XtraTab.XtraTabPage xtraTabQLHV_TTHocVien;
    }
}
