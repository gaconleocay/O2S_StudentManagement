namespace O2S_StudentManagement.GUI.FormCommon
{
    partial class ucMenuTaiChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMenuTaiChinh));
            this.xtraTabControlQuanTri = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTab_QuanLyTheNoiTru = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTab_CapNhatMatTheNgoaiTru = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTab_TamUngThuTien = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlQuanTri)).BeginInit();
            this.xtraTabControlQuanTri.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControlQuanTri
            // 
            this.xtraTabControlQuanTri.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControlQuanTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlQuanTri.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlQuanTri.Name = "xtraTabControlQuanTri";
            this.xtraTabControlQuanTri.SelectedTabPage = this.xtraTab_QuanLyTheNoiTru;
            this.xtraTabControlQuanTri.Size = new System.Drawing.Size(1200, 700);
            this.xtraTabControlQuanTri.TabIndex = 0;
            this.xtraTabControlQuanTri.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTab_QuanLyTheNoiTru,
            this.xtraTab_CapNhatMatTheNgoaiTru,
            this.xtraTab_TamUngThuTien});
            this.xtraTabControlQuanTri.TabPageWidth = 160;
            this.xtraTabControlQuanTri.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlCongCuKhac_SelectedPageChanged);
            this.xtraTabControlQuanTri.CloseButtonClick += new System.EventHandler(this.xtraTabControlCongCuKhac_CloseButtonClick);
            // 
            // xtraTab_QuanLyTheNoiTru
            // 
            this.xtraTab_QuanLyTheNoiTru.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTab_QuanLyTheNoiTru.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_QuanLyTheNoiTru.Appearance.Header.Options.UseFont = true;
            this.xtraTab_QuanLyTheNoiTru.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_QuanLyTheNoiTru.Image = global::O2S_StudentManagement.Properties.Resources.list_rich_16;
            this.xtraTab_QuanLyTheNoiTru.Name = "xtraTab_QuanLyTheNoiTru";
            this.xtraTab_QuanLyTheNoiTru.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTab_QuanLyTheNoiTru.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_QuanLyTheNoiTru.Size = new System.Drawing.Size(1194, 669);
            this.xtraTab_QuanLyTheNoiTru.Text = "Quản lý thẻ nội trú";
            this.xtraTab_QuanLyTheNoiTru.Tooltip = "Quản trị - Quản lý thẻ nội trú";
            // 
            // xtraTab_CapNhatMatTheNgoaiTru
            // 
            this.xtraTab_CapNhatMatTheNgoaiTru.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTab_CapNhatMatTheNgoaiTru.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_CapNhatMatTheNgoaiTru.Appearance.Header.Options.UseFont = true;
            this.xtraTab_CapNhatMatTheNgoaiTru.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_CapNhatMatTheNgoaiTru.Image = global::O2S_StudentManagement.Properties.Resources.x_mark_16;
            this.xtraTab_CapNhatMatTheNgoaiTru.Name = "xtraTab_CapNhatMatTheNgoaiTru";
            this.xtraTab_CapNhatMatTheNgoaiTru.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTab_CapNhatMatTheNgoaiTru.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_CapNhatMatTheNgoaiTru.Size = new System.Drawing.Size(1194, 669);
            this.xtraTab_CapNhatMatTheNgoaiTru.Text = "Cập nhật mất thẻ ngoại trú";
            this.xtraTab_CapNhatMatTheNgoaiTru.Tooltip = "Cập nhật mất thẻ ngoại trú";
            // 
            // xtraTab_TamUngThuTien
            // 
            this.xtraTab_TamUngThuTien.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTab_TamUngThuTien.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_TamUngThuTien.Appearance.Header.Options.UseFont = true;
            this.xtraTab_TamUngThuTien.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_TamUngThuTien.Image = ((System.Drawing.Image)(resources.GetObject("xtraTab_TamUngThuTien.Image")));
            this.xtraTab_TamUngThuTien.Name = "xtraTab_TamUngThuTien";
            this.xtraTab_TamUngThuTien.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTab_TamUngThuTien.PageEnabled = false;
            this.xtraTab_TamUngThuTien.PageVisible = false;
            this.xtraTab_TamUngThuTien.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_TamUngThuTien.Size = new System.Drawing.Size(1194, 669);
            this.xtraTab_TamUngThuTien.Text = "Tài chính - giao dịch";
            this.xtraTab_TamUngThuTien.Tooltip = "Tài chính - giao dịch";
            // 
            // ucMenuQuanTri
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.xtraTabControlQuanTri);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMenuQuanTri";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.ucMenuGiamDinhXML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlQuanTri)).EndInit();
            this.xtraTabControlQuanTri.ResumeLayout(false);
            this.ResumeLayout(false);

        }




        #endregion
        private DevExpress.XtraTab.XtraTabPage xtraTab_QuanLyTheNoiTru;
        internal DevExpress.XtraTab.XtraTabControl xtraTabControlQuanTri;
        private DevExpress.XtraTab.XtraTabPage xtraTab_TamUngThuTien;
        private DevExpress.XtraTab.XtraTabPage xtraTab_CapNhatMatTheNgoaiTru;
    }
}
