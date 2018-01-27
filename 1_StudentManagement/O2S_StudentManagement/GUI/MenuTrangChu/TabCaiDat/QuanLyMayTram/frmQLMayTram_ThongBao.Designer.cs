namespace O2S_StudentManagement.GUI.MenuTrangChu.TabCaiDat
{
    partial class frmQLMayTram_ThongBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLMayTram_ThongBao));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLuuLai = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNoiDung = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLuuLai);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuLai.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLuuLai.Appearance.Options.UseFont = true;
            this.btnLuuLai.Appearance.Options.UseForeColor = true;
            this.btnLuuLai.Image = global::O2S_StudentManagement.Properties.Resources.save_16;
            this.btnLuuLai.Location = new System.Drawing.Point(202, 10);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(120, 30);
            this.btnLuuLai.TabIndex = 14;
            this.btnLuuLai.Text = "Lưu";
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtNoiDung);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(608, 235);
            this.panel2.TabIndex = 1;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(84, 10);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(512, 217);
            this.txtNoiDung.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(15, 105);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nội dung:";
            // 
            // frmQLMayTram_ThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 285);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQLMayTram_ThongBao";
            this.Text = "Nội dung thông báo";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnLuuLai;
        private DevExpress.XtraEditors.MemoEdit txtNoiDung;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}