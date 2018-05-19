namespace O2S_QuanLyHocVien.CauHinh
{
    partial class frmUpdateSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateSQL));
            this.btnHocVien7So = new System.Windows.Forms.LinkLabel();
            this.btnPhieuGhiDanh7So = new System.Windows.Forms.LinkLabel();
            this.btnPhieuThu7So = new System.Windows.Forms.LinkLabel();
            this.btnTaiKhoan7So = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnHocVien7So
            // 
            this.btnHocVien7So.AutoSize = true;
            this.btnHocVien7So.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocVien7So.Location = new System.Drawing.Point(32, 26);
            this.btnHocVien7So.Name = "btnHocVien7So";
            this.btnHocVien7So.Size = new System.Drawing.Size(236, 23);
            this.btnHocVien7So.TabIndex = 0;
            this.btnHocVien7So.TabStop = true;
            this.btnHocVien7So.Text = "Cập nhật mã Học viên 7 số";
            this.btnHocVien7So.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnHocVien7So_LinkClicked);
            // 
            // btnPhieuGhiDanh7So
            // 
            this.btnPhieuGhiDanh7So.AutoSize = true;
            this.btnPhieuGhiDanh7So.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuGhiDanh7So.Location = new System.Drawing.Point(32, 65);
            this.btnPhieuGhiDanh7So.Name = "btnPhieuGhiDanh7So";
            this.btnPhieuGhiDanh7So.Size = new System.Drawing.Size(291, 23);
            this.btnPhieuGhiDanh7So.TabIndex = 1;
            this.btnPhieuGhiDanh7So.TabStop = true;
            this.btnPhieuGhiDanh7So.Text = "Cập nhật mã Phiếu ghi danh 7 số";
            this.btnPhieuGhiDanh7So.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPhieuGhiDanh7So_LinkClicked);
            // 
            // btnPhieuThu7So
            // 
            this.btnPhieuThu7So.AutoSize = true;
            this.btnPhieuThu7So.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuThu7So.Location = new System.Drawing.Point(32, 104);
            this.btnPhieuThu7So.Name = "btnPhieuThu7So";
            this.btnPhieuThu7So.Size = new System.Drawing.Size(244, 23);
            this.btnPhieuThu7So.TabIndex = 2;
            this.btnPhieuThu7So.TabStop = true;
            this.btnPhieuThu7So.Text = "Cập nhật mã Phiếu thu 7 số";
            this.btnPhieuThu7So.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPhieuThu7So_LinkClicked);
            // 
            // btnTaiKhoan7So
            // 
            this.btnTaiKhoan7So.AutoSize = true;
            this.btnTaiKhoan7So.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan7So.Location = new System.Drawing.Point(32, 148);
            this.btnTaiKhoan7So.Name = "btnTaiKhoan7So";
            this.btnTaiKhoan7So.Size = new System.Drawing.Size(256, 23);
            this.btnTaiKhoan7So.TabIndex = 3;
            this.btnTaiKhoan7So.TabStop = true;
            this.btnTaiKhoan7So.Text = "Cập nhật mã đăng nhập 7 số";
            this.btnTaiKhoan7So.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnTaiKhoan7So_LinkClicked);
            // 
            // frmUpdateSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 462);
            this.Controls.Add(this.btnTaiKhoan7So);
            this.Controls.Add(this.btnPhieuThu7So);
            this.Controls.Add(this.btnPhieuGhiDanh7So);
            this.Controls.Add(this.btnHocVien7So);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateSQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update SQL";
            this.Load += new System.EventHandler(this.frmUpdateSQL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnHocVien7So;
        private System.Windows.Forms.LinkLabel btnPhieuGhiDanh7So;
        private System.Windows.Forms.LinkLabel btnPhieuThu7So;
        private System.Windows.Forms.LinkLabel btnTaiKhoan7So;
    }
}