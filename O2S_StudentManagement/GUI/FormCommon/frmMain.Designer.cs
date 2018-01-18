namespace O2S_StudentManagement.GUI.FormCommon
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblStatusTenBC = new DevExpress.XtraBars.BarStaticItem();
            this.StatusDBName = new DevExpress.XtraBars.BarStaticItem();
            this.StatusUsername = new DevExpress.XtraBars.BarStaticItem();
            this.StatusClock = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tabPaneMenu = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabMenuTrangChu = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabMenuQLHocVu = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabMenuRestart = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabMenuQLHocVien = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabMenuQLGiaoVien = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabMenuTaiChinh = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabMenuDanhMucTraCuu = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerKiemTraLicense = new System.Windows.Forms.Timer(this.components);
            this.timerQLMayTram = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneMenu)).BeginInit();
            this.tabPaneMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.lblStatusTenBC,
            this.StatusClock,
            this.StatusUsername,
            this.StatusDBName});
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatusTenBC),
            new DevExpress.XtraBars.LinkPersistInfo(this.StatusDBName),
            new DevExpress.XtraBars.LinkPersistInfo(this.StatusUsername),
            new DevExpress.XtraBars.LinkPersistInfo(this.StatusClock)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Chức năng:";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Disabled.Options.UseFont = true;
            this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblStatusTenBC
            // 
            this.lblStatusTenBC.Caption = "Home";
            this.lblStatusTenBC.Id = 1;
            this.lblStatusTenBC.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusTenBC.ItemAppearance.Disabled.Options.UseFont = true;
            this.lblStatusTenBC.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusTenBC.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
            this.lblStatusTenBC.ItemAppearance.Normal.Options.UseFont = true;
            this.lblStatusTenBC.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblStatusTenBC.Name = "lblStatusTenBC";
            this.lblStatusTenBC.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // StatusDBName
            // 
            this.StatusDBName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.StatusDBName.Caption = "StatusDBName";
            this.StatusDBName.Id = 4;
            this.StatusDBName.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusDBName.ItemAppearance.Normal.Options.UseFont = true;
            this.StatusDBName.Name = "StatusDBName";
            this.StatusDBName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // StatusUsername
            // 
            this.StatusUsername.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.StatusUsername.Caption = "StatusUsername";
            this.StatusUsername.Id = 3;
            this.StatusUsername.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusUsername.ItemAppearance.Normal.Options.UseFont = true;
            this.StatusUsername.Name = "StatusUsername";
            this.StatusUsername.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // StatusClock
            // 
            this.StatusClock.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.StatusClock.Caption = "StatusClock";
            this.StatusClock.Id = 2;
            this.StatusClock.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusClock.ItemAppearance.Normal.Options.UseFont = true;
            this.StatusClock.Name = "StatusClock";
            this.StatusClock.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1234, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 716);
            this.barDockControlBottom.Size = new System.Drawing.Size(1234, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 716);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1234, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 716);
            // 
            // tabPaneMenu
            // 
            this.tabPaneMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPaneMenu.Appearance.Options.UseFont = true;
            this.tabPaneMenu.Controls.Add(this.tabMenuTrangChu);
            this.tabPaneMenu.Controls.Add(this.tabMenuQLHocVu);
            this.tabPaneMenu.Controls.Add(this.tabMenuRestart);
            this.tabPaneMenu.Controls.Add(this.tabMenuQLHocVien);
            this.tabPaneMenu.Controls.Add(this.tabMenuQLGiaoVien);
            this.tabPaneMenu.Controls.Add(this.tabMenuTaiChinh);
            this.tabPaneMenu.Controls.Add(this.tabMenuDanhMucTraCuu);
            this.tabPaneMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPaneMenu.Location = new System.Drawing.Point(0, 0);
            this.tabPaneMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tabPaneMenu.Name = "tabPaneMenu";
            this.tabPaneMenu.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabMenuRestart,
            this.tabMenuDanhMucTraCuu,
            this.tabMenuQLGiaoVien,
            this.tabMenuTaiChinh,
            this.tabMenuQLHocVu,
            this.tabMenuQLHocVien,
            this.tabMenuTrangChu});
            this.tabPaneMenu.RegularSize = new System.Drawing.Size(1234, 716);
            this.tabPaneMenu.SelectedPage = this.tabMenuTrangChu;
            this.tabPaneMenu.Size = new System.Drawing.Size(1234, 716);
            this.tabPaneMenu.TabIndex = 5;
            this.tabPaneMenu.Text = "MENU";
            this.tabPaneMenu.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.tabPaneMenu_SelectedPageChanged);
            // 
            // tabMenuTrangChu
            // 
            this.tabMenuTrangChu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMenuTrangChu.Appearance.Options.UseFont = true;
            this.tabMenuTrangChu.Caption = "TRANG CHỦ";
            this.tabMenuTrangChu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMenuTrangChu.Image = global::O2S_StudentManagement.Properties.Resources.house_16;
            this.tabMenuTrangChu.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuTrangChu.Name = "tabMenuTrangChu";
            this.tabMenuTrangChu.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuTrangChu.Size = new System.Drawing.Size(1216, 668);
            // 
            // tabMenuQLHocVu
            // 
            this.tabMenuQLHocVu.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.tabMenuQLHocVu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuQLHocVu.Appearance.Options.UseBackColor = true;
            this.tabMenuQLHocVu.Appearance.Options.UseFont = true;
            this.tabMenuQLHocVu.Caption = "QUẢN LÝ HỌC VỤ";
            this.tabMenuQLHocVu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuQLHocVu.Image = global::O2S_StudentManagement.Properties.Resources.book_stack_16;
            this.tabMenuQLHocVu.ImageUri.Uri = "AlignJustify";
            this.tabMenuQLHocVu.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuQLHocVu.Margin = new System.Windows.Forms.Padding(0);
            this.tabMenuQLHocVu.Name = "tabMenuQLHocVu";
            this.tabMenuQLHocVu.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuQLHocVu.Size = new System.Drawing.Size(1216, 668);
            // 
            // tabMenuRestart
            // 
            this.tabMenuRestart.Caption = "tabMenuRestart";
            this.tabMenuRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuRestart.Image = global::O2S_StudentManagement.Properties.Resources.refresh_2_16;
            this.tabMenuRestart.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Image;
            this.tabMenuRestart.Name = "tabMenuRestart";
            this.tabMenuRestart.PageText = "Khởi động lại";
            this.tabMenuRestart.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Image;
            this.tabMenuRestart.Size = new System.Drawing.Size(1216, 668);
            this.tabMenuRestart.Tag = "Khởi động lại";
            // 
            // tabMenuQLHocVien
            // 
            this.tabMenuQLHocVien.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuQLHocVien.Appearance.Options.UseFont = true;
            this.tabMenuQLHocVien.Caption = "QUẢN LÝ HỌC VIÊN";
            this.tabMenuQLHocVien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuQLHocVien.Image = ((System.Drawing.Image)(resources.GetObject("tabMenuQLHocVien.Image")));
            this.tabMenuQLHocVien.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuQLHocVien.Margin = new System.Windows.Forms.Padding(0);
            this.tabMenuQLHocVien.Name = "tabMenuQLHocVien";
            this.tabMenuQLHocVien.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuQLHocVien.Size = new System.Drawing.Size(1216, 668);
            // 
            // tabMenuQLGiaoVien
            // 
            this.tabMenuQLGiaoVien.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuQLGiaoVien.Appearance.Options.UseFont = true;
            this.tabMenuQLGiaoVien.Caption = "QUẢN LÝ GIÁO VIÊN";
            this.tabMenuQLGiaoVien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuQLGiaoVien.Image = ((System.Drawing.Image)(resources.GetObject("tabMenuQLGiaoVien.Image")));
            this.tabMenuQLGiaoVien.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuQLGiaoVien.Margin = new System.Windows.Forms.Padding(0);
            this.tabMenuQLGiaoVien.Name = "tabMenuQLGiaoVien";
            this.tabMenuQLGiaoVien.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuQLGiaoVien.Size = new System.Drawing.Size(1216, 668);
            // 
            // tabMenuTaiChinh
            // 
            this.tabMenuTaiChinh.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuTaiChinh.Appearance.Options.UseFont = true;
            this.tabMenuTaiChinh.Caption = "TÀI CHÍNH";
            this.tabMenuTaiChinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuTaiChinh.Image = ((System.Drawing.Image)(resources.GetObject("tabMenuTaiChinh.Image")));
            this.tabMenuTaiChinh.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuTaiChinh.Margin = new System.Windows.Forms.Padding(0);
            this.tabMenuTaiChinh.Name = "tabMenuTaiChinh";
            this.tabMenuTaiChinh.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuTaiChinh.Size = new System.Drawing.Size(1216, 668);
            // 
            // tabMenuDanhMucTraCuu
            // 
            this.tabMenuDanhMucTraCuu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuDanhMucTraCuu.Appearance.Options.UseFont = true;
            this.tabMenuDanhMucTraCuu.Caption = "DANH MỤC TRA CỨU";
            this.tabMenuDanhMucTraCuu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabMenuDanhMucTraCuu.Image = global::O2S_StudentManagement.Properties.Resources.book_stack_16;
            this.tabMenuDanhMucTraCuu.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuDanhMucTraCuu.Margin = new System.Windows.Forms.Padding(0);
            this.tabMenuDanhMucTraCuu.Name = "tabMenuDanhMucTraCuu";
            this.tabMenuDanhMucTraCuu.PageVisible = false;
            this.tabMenuDanhMucTraCuu.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabMenuDanhMucTraCuu.Size = new System.Drawing.Size(1216, 668);
            // 
            // timerClock
            // 
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timerKiemTraLicense
            // 
            this.timerKiemTraLicense.Interval = 360000;
            this.timerKiemTraLicense.Tick += new System.EventHandler(this.timerKiemTraLicense_Tick);
            // 
            // timerQLMayTram
            // 
            this.timerQLMayTram.Interval = 30000;
            this.timerQLMayTram.Tick += new System.EventHandler(this.timerQLMayTram_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 742);
            this.Controls.Add(this.tabPaneMenu);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý học viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneMenu)).EndInit();
            this.tabPaneMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem StatusDBName;
        private DevExpress.XtraBars.BarStaticItem StatusUsername;
        private DevExpress.XtraBars.BarStaticItem StatusClock;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Navigation.TabPane tabPaneMenu;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabMenuQLHocVien;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabMenuQLHocVu;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timerKiemTraLicense;
        internal DevExpress.XtraBars.BarStaticItem lblStatusTenBC;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabMenuRestart;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabMenuTaiChinh;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabMenuQLGiaoVien;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabMenuTrangChu;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabMenuDanhMucTraCuu;
        private System.Windows.Forms.Timer timerQLMayTram;
    }
}