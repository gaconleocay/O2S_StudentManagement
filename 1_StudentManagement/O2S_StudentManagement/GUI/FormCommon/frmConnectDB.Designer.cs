namespace O2S_StudentManagement.GUI.FormCommon
{
    partial class frmConnectDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnectDB));
            this.btnDBLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDBKiemTra = new DevExpress.XtraEditors.SimpleButton();
            this.btnDBUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDBName = new DevExpress.XtraEditors.TextEdit();
            this.txtDBPass = new DevExpress.XtraEditors.TextEdit();
            this.txtDBUser = new DevExpress.XtraEditors.TextEdit();
            this.txtDBHost = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBHost.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDBLuu
            // 
            this.btnDBLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBLuu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDBLuu.Appearance.Options.UseFont = true;
            this.btnDBLuu.Appearance.Options.UseForeColor = true;
            this.btnDBLuu.Image = global::O2S_StudentManagement.Properties.Resources.save_16;
            this.btnDBLuu.Location = new System.Drawing.Point(227, 215);
            this.btnDBLuu.Name = "btnDBLuu";
            this.btnDBLuu.Size = new System.Drawing.Size(100, 30);
            this.btnDBLuu.TabIndex = 10;
            this.btnDBLuu.Text = "Lưu";
            this.btnDBLuu.Click += new System.EventHandler(this.tbnDBLuu_Click);
            // 
            // btnDBKiemTra
            // 
            this.btnDBKiemTra.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBKiemTra.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDBKiemTra.Appearance.Options.UseFont = true;
            this.btnDBKiemTra.Appearance.Options.UseForeColor = true;
            this.btnDBKiemTra.Image = global::O2S_StudentManagement.Properties.Resources.question_mark_16;
            this.btnDBKiemTra.Location = new System.Drawing.Point(102, 215);
            this.btnDBKiemTra.Name = "btnDBKiemTra";
            this.btnDBKiemTra.Size = new System.Drawing.Size(100, 30);
            this.btnDBKiemTra.TabIndex = 11;
            this.btnDBKiemTra.Text = "Kiểm Tra";
            this.btnDBKiemTra.Click += new System.EventHandler(this.btnDBKiemTra_Click);
            // 
            // btnDBUpdate
            // 
            this.btnDBUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBUpdate.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDBUpdate.Appearance.Options.UseFont = true;
            this.btnDBUpdate.Appearance.Options.UseForeColor = true;
            this.btnDBUpdate.Image = global::O2S_StudentManagement.Properties.Resources.sinchronize_16;
            this.btnDBUpdate.Location = new System.Drawing.Point(351, 215);
            this.btnDBUpdate.Name = "btnDBUpdate";
            this.btnDBUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnDBUpdate.TabIndex = 13;
            this.btnDBUpdate.Text = "Update DB";
            this.btnDBUpdate.Click += new System.EventHandler(this.btnDBUpdate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDBName);
            this.groupBox2.Controls.Add(this.txtDBPass);
            this.groupBox2.Controls.Add(this.txtDBUser);
            this.groupBox2.Controls.Add(this.txtDBHost);
            this.groupBox2.Controls.Add(this.labelControl5);
            this.groupBox2.Controls.Add(this.labelControl4);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(7, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 178);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database";
            // 
            // txtDBName
            // 
            this.txtDBName.EditValue = "";
            this.txtDBName.Location = new System.Drawing.Point(108, 126);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBName.Properties.Appearance.Options.UseFont = true;
            this.txtDBName.Size = new System.Drawing.Size(212, 22);
            this.txtDBName.TabIndex = 21;
            // 
            // txtDBPass
            // 
            this.txtDBPass.EditValue = "";
            this.txtDBPass.Location = new System.Drawing.Point(108, 94);
            this.txtDBPass.Name = "txtDBPass";
            this.txtDBPass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBPass.Properties.Appearance.Options.UseFont = true;
            this.txtDBPass.Properties.PasswordChar = '*';
            this.txtDBPass.Size = new System.Drawing.Size(212, 22);
            this.txtDBPass.TabIndex = 20;
            // 
            // txtDBUser
            // 
            this.txtDBUser.EditValue = "";
            this.txtDBUser.Location = new System.Drawing.Point(108, 62);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBUser.Properties.Appearance.Options.UseFont = true;
            this.txtDBUser.Size = new System.Drawing.Size(212, 22);
            this.txtDBUser.TabIndex = 19;
            // 
            // txtDBHost
            // 
            this.txtDBHost.EditValue = "";
            this.txtDBHost.Location = new System.Drawing.Point(108, 31);
            this.txtDBHost.Name = "txtDBHost";
            this.txtDBHost.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBHost.Properties.Appearance.Options.UseFont = true;
            this.txtDBHost.Size = new System.Drawing.Size(436, 22);
            this.txtDBHost.TabIndex = 18;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl5.Location = new System.Drawing.Point(7, 129);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(89, 16);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Database name";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.Location = new System.Drawing.Point(41, 97);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 16);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Password";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Location = new System.Drawing.Point(70, 66);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(26, 16);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "User";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(70, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 16);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Host";
            // 
            // frmConnectDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDBUpdate);
            this.Controls.Add(this.btnDBKiemTra);
            this.Controls.Add(this.btnDBLuu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "frmConnectDB";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu Hình Cơ Sở Dữ Liệu";
            this.Load += new System.EventHandler(this.frmConnectDB_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBHost.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDBLuu;
        private DevExpress.XtraEditors.SimpleButton btnDBKiemTra;
        private DevExpress.XtraEditors.SimpleButton btnDBUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtDBName;
        private DevExpress.XtraEditors.TextEdit txtDBPass;
        private DevExpress.XtraEditors.TextEdit txtDBUser;
        private DevExpress.XtraEditors.TextEdit txtDBHost;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}