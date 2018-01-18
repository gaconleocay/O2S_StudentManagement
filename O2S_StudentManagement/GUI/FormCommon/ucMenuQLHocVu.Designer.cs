namespace O2S_StudentManagement.GUI.FormCommon
{
    partial class ucMenuQLHocVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMenuQLHocVu));
            this.xtraTabControlGiamDinhXML = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTab_TKLSKiemTra = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTab_TKLSVaoRa = new DevExpress.XtraTab.XtraTabPage();
            this.openFileDialogSelect = new System.Windows.Forms.OpenFileDialog();
            this.imageCollectionDSBN = new DevExpress.Utils.ImageCollection(this.components);
            this.xtraTab_TKLSCapNhatNoiTru = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlGiamDinhXML)).BeginInit();
            this.xtraTabControlGiamDinhXML.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionDSBN)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControlGiamDinhXML
            // 
            this.xtraTabControlGiamDinhXML.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControlGiamDinhXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlGiamDinhXML.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlGiamDinhXML.Name = "xtraTabControlGiamDinhXML";
            this.xtraTabControlGiamDinhXML.SelectedTabPage = this.xtraTab_TKLSKiemTra;
            this.xtraTabControlGiamDinhXML.Size = new System.Drawing.Size(1200, 700);
            this.xtraTabControlGiamDinhXML.TabIndex = 0;
            this.xtraTabControlGiamDinhXML.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTab_TKLSKiemTra,
            this.xtraTab_TKLSVaoRa,
            this.xtraTab_TKLSCapNhatNoiTru});
            this.xtraTabControlGiamDinhXML.TabPageWidth = 160;
            this.xtraTabControlGiamDinhXML.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlCongCuKhac_SelectedPageChanged);
            this.xtraTabControlGiamDinhXML.CloseButtonClick += new System.EventHandler(this.xtraTabControlCongCuKhac_CloseButtonClick);
            // 
            // xtraTab_TKLSKiemTra
            // 
            this.xtraTab_TKLSKiemTra.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTab_TKLSKiemTra.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_TKLSKiemTra.Appearance.Header.Options.UseFont = true;
            this.xtraTab_TKLSKiemTra.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_TKLSKiemTra.Image = global::O2S_StudentManagement.Properties.Resources.list_rich_16;
            this.xtraTab_TKLSKiemTra.Name = "xtraTab_TKLSKiemTra";
            this.xtraTab_TKLSKiemTra.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTab_TKLSKiemTra.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_TKLSKiemTra.Size = new System.Drawing.Size(1194, 669);
            this.xtraTab_TKLSKiemTra.Text = "Lịch sử kiểm tra xe ra";
            this.xtraTab_TKLSKiemTra.Tooltip = "Thống kê - Lịch sử kiểm tra xe vào ra";
            // 
            // xtraTab_TKLSVaoRa
            // 
            this.xtraTab_TKLSVaoRa.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTab_TKLSVaoRa.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_TKLSVaoRa.Appearance.Header.Options.UseFont = true;
            this.xtraTab_TKLSVaoRa.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_TKLSVaoRa.Image = global::O2S_StudentManagement.Properties.Resources.timeline_16;
            this.xtraTab_TKLSVaoRa.Name = "xtraTab_TKLSVaoRa";
            this.xtraTab_TKLSVaoRa.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTab_TKLSVaoRa.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_TKLSVaoRa.Size = new System.Drawing.Size(1194, 669);
            this.xtraTab_TKLSVaoRa.Text = "Lịch sử xe vào/ra";
            this.xtraTab_TKLSVaoRa.Tooltip = "Thống kê - Lịch sử xe vào ra";
            // 
            // openFileDialogSelect
            // 
            this.openFileDialogSelect.Filter = "XML file|*.xml";
            this.openFileDialogSelect.Multiselect = true;
            this.openFileDialogSelect.Title = "Chọn file XML";
            // 
            // imageCollectionDSBN
            // 
            this.imageCollectionDSBN.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionDSBN.ImageStream")));
            this.imageCollectionDSBN.Images.SetKeyName(0, "check-mark-16.png");
            this.imageCollectionDSBN.Images.SetKeyName(1, "arrow-48-16.png");
            this.imageCollectionDSBN.Images.SetKeyName(2, "checked-checkbox-16.png");
            this.imageCollectionDSBN.Images.SetKeyName(3, "info-2-16.png");
            this.imageCollectionDSBN.Images.SetKeyName(4, "delete-16.png");
            // 
            // xtraTab_TKLSCapNhatNoiTru
            // 
            this.xtraTab_TKLSCapNhatNoiTru.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTab_TKLSCapNhatNoiTru.Appearance.Header.ForeColor = System.Drawing.Color.Navy;
            this.xtraTab_TKLSCapNhatNoiTru.Appearance.Header.Options.UseFont = true;
            this.xtraTab_TKLSCapNhatNoiTru.Appearance.Header.Options.UseForeColor = true;
            this.xtraTab_TKLSCapNhatNoiTru.Image = global::O2S_StudentManagement.Properties.Resources.inbox_5_16;
            this.xtraTab_TKLSCapNhatNoiTru.Name = "xtraTab_TKLSCapNhatNoiTru";
            this.xtraTab_TKLSCapNhatNoiTru.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.xtraTab_TKLSCapNhatNoiTru.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTab_TKLSCapNhatNoiTru.Size = new System.Drawing.Size(1194, 669);
            this.xtraTab_TKLSCapNhatNoiTru.Text = "Lịch sử cập nhật nội trú";
            this.xtraTab_TKLSCapNhatNoiTru.Tooltip = "Thống kê - Lịch sử cập nhật nội trú";
            // 
            // ucMenuThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.xtraTabControlGiamDinhXML);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMenuThongKe";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.ucMenuThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlGiamDinhXML)).EndInit();
            this.xtraTabControlGiamDinhXML.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionDSBN)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion
        private DevExpress.XtraTab.XtraTabPage xtraTab_TKLSKiemTra;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelect;
        private DevExpress.Utils.ImageCollection imageCollectionDSBN;
        internal DevExpress.XtraTab.XtraTabControl xtraTabControlGiamDinhXML;
        private DevExpress.XtraTab.XtraTabPage xtraTab_TKLSVaoRa;
        private DevExpress.XtraTab.XtraTabPage xtraTab_TKLSCapNhatNoiTru;
    }
}
