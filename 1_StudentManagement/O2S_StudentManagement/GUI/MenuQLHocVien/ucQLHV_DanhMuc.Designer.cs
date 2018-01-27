namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    partial class ucQLHV_DanhMuc
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
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl3 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemDM_Tinh = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDM_Huyen = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDM_Xa = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemDM_NgheNghiep = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDM_DanToc = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControlDLHV_DM = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDLHV_DM)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.navBarControl3);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.panelControlDLHV_DM);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1200, 700);
            this.splitContainerControl2.SplitterPosition = 220;
            this.splitContainerControl2.TabIndex = 4;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // navBarControl3
            // 
            this.navBarControl3.ActiveGroup = this.navBarGroup4;
            this.navBarControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl3.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup4,
            this.navBarGroup1});
            this.navBarControl3.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItemDM_Tinh,
            this.navBarItemDM_Huyen,
            this.navBarItemDM_Xa,
            this.navBarItemDM_NgheNghiep,
            this.navBarItemDM_DanToc});
            this.navBarControl3.Location = new System.Drawing.Point(0, 0);
            this.navBarControl3.Name = "navBarControl3";
            this.navBarControl3.OptionsNavPane.ExpandedWidth = 220;
            this.navBarControl3.Size = new System.Drawing.Size(220, 700);
            this.navBarControl3.TabIndex = 0;
            this.navBarControl3.Text = "navBarControl3";
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarGroup4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarGroup4.Appearance.Options.UseFont = true;
            this.navBarGroup4.Appearance.Options.UseForeColor = true;
            this.navBarGroup4.Caption = "Đơn vị hành chính";
            this.navBarGroup4.Expanded = true;
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_Tinh),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_Huyen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_Xa)});
            this.navBarGroup4.Name = "navBarGroup4";
            // 
            // navBarItemDM_Tinh
            // 
            this.navBarItemDM_Tinh.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Tinh.Appearance.Options.UseFont = true;
            this.navBarItemDM_Tinh.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Tinh.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_Tinh.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Tinh.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_Tinh.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_Tinh.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_Tinh.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Tinh.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_Tinh.Caption = "Tỉnh";
            this.navBarItemDM_Tinh.Name = "navBarItemDM_Tinh";
            this.navBarItemDM_Tinh.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_Tinh_LinkClicked);
            // 
            // navBarItemDM_Huyen
            // 
            this.navBarItemDM_Huyen.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Huyen.Appearance.Options.UseFont = true;
            this.navBarItemDM_Huyen.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Huyen.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_Huyen.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Huyen.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_Huyen.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_Huyen.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_Huyen.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBarItemDM_Huyen.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_Huyen.Caption = "Huyện";
            this.navBarItemDM_Huyen.Name = "navBarItemDM_Huyen";
            this.navBarItemDM_Huyen.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_Huyen_LinkClicked);
            // 
            // navBarItemDM_Xa
            // 
            this.navBarItemDM_Xa.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.navBarItemDM_Xa.Appearance.Options.UseFont = true;
            this.navBarItemDM_Xa.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_Xa.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_Xa.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.navBarItemDM_Xa.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_Xa.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_Xa.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_Xa.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_Xa.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_Xa.Caption = "Xã";
            this.navBarItemDM_Xa.Name = "navBarItemDM_Xa";
            this.navBarItemDM_Xa.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_Xa_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.navBarGroup1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarGroup1.Appearance.Options.UseFont = true;
            this.navBarGroup1.Appearance.Options.UseForeColor = true;
            this.navBarGroup1.Caption = "Khác";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_NgheNghiep),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDM_DanToc)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarItemDM_NgheNghiep
            // 
            this.navBarItemDM_NgheNghiep.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.navBarItemDM_NgheNghiep.Appearance.Options.UseFont = true;
            this.navBarItemDM_NgheNghiep.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_NgheNghiep.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_NgheNghiep.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.navBarItemDM_NgheNghiep.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_NgheNghiep.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_NgheNghiep.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_NgheNghiep.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_NgheNghiep.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_NgheNghiep.Caption = "Nghề nghiệp";
            this.navBarItemDM_NgheNghiep.Name = "navBarItemDM_NgheNghiep";
            this.navBarItemDM_NgheNghiep.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_NgheNghiep_LinkClicked);
            // 
            // navBarItemDM_DanToc
            // 
            this.navBarItemDM_DanToc.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.navBarItemDM_DanToc.Appearance.Options.UseFont = true;
            this.navBarItemDM_DanToc.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_DanToc.AppearanceDisabled.Options.UseFont = true;
            this.navBarItemDM_DanToc.AppearanceHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.navBarItemDM_DanToc.AppearanceHotTracked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.navBarItemDM_DanToc.AppearanceHotTracked.Options.UseFont = true;
            this.navBarItemDM_DanToc.AppearanceHotTracked.Options.UseForeColor = true;
            this.navBarItemDM_DanToc.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.navBarItemDM_DanToc.AppearancePressed.Options.UseFont = true;
            this.navBarItemDM_DanToc.Caption = "Dân tộc";
            this.navBarItemDM_DanToc.Name = "navBarItemDM_DanToc";
            this.navBarItemDM_DanToc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDM_DanToc_LinkClicked);
            // 
            // panelControlDLHV_DM
            // 
            this.panelControlDLHV_DM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlDLHV_DM.Location = new System.Drawing.Point(0, 0);
            this.panelControlDLHV_DM.Name = "panelControlDLHV_DM";
            this.panelControlDLHV_DM.Size = new System.Drawing.Size(975, 700);
            this.panelControlDLHV_DM.TabIndex = 0;
            // 
            // ucQLHV_DanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl2);
            this.Name = "ucQLHV_DanhMuc";
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDLHV_DM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup4;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_Tinh;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_Huyen;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_Xa;
        private DevExpress.XtraEditors.PanelControl panelControlDLHV_DM;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_NgheNghiep;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDM_DanToc;
    }
}
