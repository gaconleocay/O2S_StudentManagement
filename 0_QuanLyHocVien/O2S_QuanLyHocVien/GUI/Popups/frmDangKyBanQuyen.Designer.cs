namespace O2S_QuanLyHocVien.Popups
{
    partial class frmDangKyBanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangKyBanQuyen));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxTaoLicense = new System.Windows.Forms.GroupBox();
            this.chkKhongThoiHan = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtTaoLicenseKeyDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtTaoLicenseKeyTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTaoLicenseTao = new System.Windows.Forms.Button();
            this.txtTaoLicenseMaKichHoat = new System.Windows.Forms.TextBox();
            this.txtTaoLicensePassword = new System.Windows.Forms.TextBox();
            this.btnTaoLicenseCopy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaoLicenseMaMay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupLicense = new System.Windows.Forms.GroupBox();
            this.btnLicenseLuu = new System.Windows.Forms.Button();
            this.btnLicenseKiemTra = new System.Windows.Forms.Button();
            this.lblThoiGianSuDung = new System.Windows.Forms.Label();
            this.txtMaMay = new System.Windows.Forms.TextBox();
            this.btnLicenseCopy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeyKichHoat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBoxTaoLicense.SuspendLayout();
            this.groupLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBoxTaoLicense);
            this.panel2.Controls.Add(this.groupLicense);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 562);
            this.panel2.TabIndex = 3;
            // 
            // groupBoxTaoLicense
            // 
            this.groupBoxTaoLicense.Controls.Add(this.chkKhongThoiHan);
            this.groupBoxTaoLicense.Controls.Add(this.label7);
            this.groupBoxTaoLicense.Controls.Add(this.dtTaoLicenseKeyDenNgay);
            this.groupBoxTaoLicense.Controls.Add(this.dtTaoLicenseKeyTuNgay);
            this.groupBoxTaoLicense.Controls.Add(this.label6);
            this.groupBoxTaoLicense.Controls.Add(this.label5);
            this.groupBoxTaoLicense.Controls.Add(this.btnTaoLicenseTao);
            this.groupBoxTaoLicense.Controls.Add(this.txtTaoLicenseMaKichHoat);
            this.groupBoxTaoLicense.Controls.Add(this.txtTaoLicensePassword);
            this.groupBoxTaoLicense.Controls.Add(this.btnTaoLicenseCopy);
            this.groupBoxTaoLicense.Controls.Add(this.label2);
            this.groupBoxTaoLicense.Controls.Add(this.txtTaoLicenseMaMay);
            this.groupBoxTaoLicense.Controls.Add(this.label3);
            this.groupBoxTaoLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTaoLicense.Location = new System.Drawing.Point(0, 195);
            this.groupBoxTaoLicense.Name = "groupBoxTaoLicense";
            this.groupBoxTaoLicense.Size = new System.Drawing.Size(884, 367);
            this.groupBoxTaoLicense.TabIndex = 47;
            this.groupBoxTaoLicense.TabStop = false;
            this.groupBoxTaoLicense.Text = "Tạo license";
            // 
            // chkKhongThoiHan
            // 
            this.chkKhongThoiHan.AutoSize = true;
            this.chkKhongThoiHan.Location = new System.Drawing.Point(119, 145);
            this.chkKhongThoiHan.Name = "chkKhongThoiHan";
            this.chkKhongThoiHan.Size = new System.Drawing.Size(166, 19);
            this.chkKhongThoiHan.TabIndex = 63;
            this.chkKhongThoiHan.Text = "Bản quyền không thời hạn";
            this.chkKhongThoiHan.UseVisualStyleBackColor = true;
            this.chkKhongThoiHan.CheckedChanged += new System.EventHandler(this.chkKhongThoiHan_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(341, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 15);
            this.label7.TabIndex = 62;
            this.label7.Text = "đến";
            // 
            // dtTaoLicenseKeyDenNgay
            // 
            this.dtTaoLicenseKeyDenNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTaoLicenseKeyDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTaoLicenseKeyDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtTaoLicenseKeyDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTaoLicenseKeyDenNgay.Location = new System.Drawing.Point(388, 110);
            this.dtTaoLicenseKeyDenNgay.Name = "dtTaoLicenseKeyDenNgay";
            this.dtTaoLicenseKeyDenNgay.Size = new System.Drawing.Size(196, 25);
            this.dtTaoLicenseKeyDenNgay.TabIndex = 61;
            // 
            // dtTaoLicenseKeyTuNgay
            // 
            this.dtTaoLicenseKeyTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTaoLicenseKeyTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTaoLicenseKeyTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtTaoLicenseKeyTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTaoLicenseKeyTuNgay.Location = new System.Drawing.Point(119, 110);
            this.dtTaoLicenseKeyTuNgay.Name = "dtTaoLicenseKeyTuNgay";
            this.dtTaoLicenseKeyTuNgay.Size = new System.Drawing.Size(196, 25);
            this.dtTaoLicenseKeyTuNgay.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 54;
            this.label6.Text = "Thời hạn từ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 53;
            this.label5.Text = "Key kích hoạt:";
            // 
            // btnTaoLicenseTao
            // 
            this.btnTaoLicenseTao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoLicenseTao.BackColor = System.Drawing.Color.Silver;
            this.btnTaoLicenseTao.FlatAppearance.BorderSize = 0;
            this.btnTaoLicenseTao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTaoLicenseTao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTaoLicenseTao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoLicenseTao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTaoLicenseTao.Location = new System.Drawing.Point(366, 170);
            this.btnTaoLicenseTao.Name = "btnTaoLicenseTao";
            this.btnTaoLicenseTao.Size = new System.Drawing.Size(100, 30);
            this.btnTaoLicenseTao.TabIndex = 52;
            this.btnTaoLicenseTao.Text = "Tạo license";
            this.btnTaoLicenseTao.UseVisualStyleBackColor = false;
            this.btnTaoLicenseTao.Click += new System.EventHandler(this.btnTaoLicenseTao_Click);
            // 
            // txtTaoLicenseMaKichHoat
            // 
            this.txtTaoLicenseMaKichHoat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaoLicenseMaKichHoat.Location = new System.Drawing.Point(119, 241);
            this.txtTaoLicenseMaKichHoat.Multiline = true;
            this.txtTaoLicenseMaKichHoat.Name = "txtTaoLicenseMaKichHoat";
            this.txtTaoLicenseMaKichHoat.Size = new System.Drawing.Size(614, 50);
            this.txtTaoLicenseMaKichHoat.TabIndex = 51;
            // 
            // txtTaoLicensePassword
            // 
            this.txtTaoLicensePassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaoLicensePassword.Location = new System.Drawing.Point(119, 22);
            this.txtTaoLicensePassword.Name = "txtTaoLicensePassword";
            this.txtTaoLicensePassword.PasswordChar = '*';
            this.txtTaoLicensePassword.Size = new System.Drawing.Size(614, 25);
            this.txtTaoLicensePassword.TabIndex = 47;
            this.txtTaoLicensePassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaoLicensePassword_KeyDown);
            // 
            // btnTaoLicenseCopy
            // 
            this.btnTaoLicenseCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoLicenseCopy.BackColor = System.Drawing.Color.Silver;
            this.btnTaoLicenseCopy.FlatAppearance.BorderSize = 0;
            this.btnTaoLicenseCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTaoLicenseCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTaoLicenseCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoLicenseCopy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTaoLicenseCopy.Location = new System.Drawing.Point(739, 241);
            this.btnTaoLicenseCopy.Name = "btnTaoLicenseCopy";
            this.btnTaoLicenseCopy.Size = new System.Drawing.Size(90, 50);
            this.btnTaoLicenseCopy.TabIndex = 50;
            this.btnTaoLicenseCopy.Text = "Copy";
            this.btnTaoLicenseCopy.UseVisualStyleBackColor = false;
            this.btnTaoLicenseCopy.Click += new System.EventHandler(this.btnTaoLicenseCopy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 46;
            this.label2.Text = "Password:";
            // 
            // txtTaoLicenseMaMay
            // 
            this.txtTaoLicenseMaMay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTaoLicenseMaMay.Location = new System.Drawing.Point(119, 53);
            this.txtTaoLicenseMaMay.Multiline = true;
            this.txtTaoLicenseMaMay.Name = "txtTaoLicenseMaMay";
            this.txtTaoLicenseMaMay.Size = new System.Drawing.Size(614, 49);
            this.txtTaoLicenseMaMay.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 48;
            this.label3.Text = "Mã máy:";
            // 
            // groupLicense
            // 
            this.groupLicense.Controls.Add(this.btnLicenseLuu);
            this.groupLicense.Controls.Add(this.btnLicenseKiemTra);
            this.groupLicense.Controls.Add(this.lblThoiGianSuDung);
            this.groupLicense.Controls.Add(this.txtMaMay);
            this.groupLicense.Controls.Add(this.btnLicenseCopy);
            this.groupLicense.Controls.Add(this.label4);
            this.groupLicense.Controls.Add(this.txtKeyKichHoat);
            this.groupLicense.Controls.Add(this.label1);
            this.groupLicense.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupLicense.Location = new System.Drawing.Point(0, 0);
            this.groupLicense.Name = "groupLicense";
            this.groupLicense.Size = new System.Drawing.Size(884, 195);
            this.groupLicense.TabIndex = 46;
            this.groupLicense.TabStop = false;
            this.groupLicense.Text = "License";
            // 
            // btnLicenseLuu
            // 
            this.btnLicenseLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLicenseLuu.BackColor = System.Drawing.Color.Silver;
            this.btnLicenseLuu.FlatAppearance.BorderSize = 0;
            this.btnLicenseLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnLicenseLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLicenseLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLicenseLuu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLicenseLuu.Location = new System.Drawing.Point(441, 113);
            this.btnLicenseLuu.Name = "btnLicenseLuu";
            this.btnLicenseLuu.Size = new System.Drawing.Size(100, 30);
            this.btnLicenseLuu.TabIndex = 47;
            this.btnLicenseLuu.Text = "Lưu";
            this.btnLicenseLuu.UseVisualStyleBackColor = false;
            this.btnLicenseLuu.Click += new System.EventHandler(this.btnLicenseLuu_Click);
            // 
            // btnLicenseKiemTra
            // 
            this.btnLicenseKiemTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLicenseKiemTra.BackColor = System.Drawing.Color.Silver;
            this.btnLicenseKiemTra.FlatAppearance.BorderSize = 0;
            this.btnLicenseKiemTra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnLicenseKiemTra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLicenseKiemTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLicenseKiemTra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLicenseKiemTra.Location = new System.Drawing.Point(302, 113);
            this.btnLicenseKiemTra.Name = "btnLicenseKiemTra";
            this.btnLicenseKiemTra.Size = new System.Drawing.Size(100, 30);
            this.btnLicenseKiemTra.TabIndex = 46;
            this.btnLicenseKiemTra.Text = "Kiểm tra";
            this.btnLicenseKiemTra.UseVisualStyleBackColor = false;
            this.btnLicenseKiemTra.Click += new System.EventHandler(this.btnLicenseKiemTra_Click);
            // 
            // lblThoiGianSuDung
            // 
            this.lblThoiGianSuDung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianSuDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblThoiGianSuDung.Location = new System.Drawing.Point(115, 152);
            this.lblThoiGianSuDung.Name = "lblThoiGianSuDung";
            this.lblThoiGianSuDung.Size = new System.Drawing.Size(618, 30);
            this.lblThoiGianSuDung.TabIndex = 42;
            this.lblThoiGianSuDung.Text = "Thời hạn";
            this.lblThoiGianSuDung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaMay
            // 
            this.txtMaMay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaMay.Location = new System.Drawing.Point(119, 22);
            this.txtMaMay.Name = "txtMaMay";
            this.txtMaMay.Size = new System.Drawing.Size(614, 25);
            this.txtMaMay.TabIndex = 20;
            // 
            // btnLicenseCopy
            // 
            this.btnLicenseCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLicenseCopy.BackColor = System.Drawing.Color.Silver;
            this.btnLicenseCopy.FlatAppearance.BorderSize = 0;
            this.btnLicenseCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnLicenseCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLicenseCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLicenseCopy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLicenseCopy.Location = new System.Drawing.Point(739, 22);
            this.btnLicenseCopy.Name = "btnLicenseCopy";
            this.btnLicenseCopy.Size = new System.Drawing.Size(90, 25);
            this.btnLicenseCopy.TabIndex = 45;
            this.btnLicenseCopy.Text = "Copy";
            this.btnLicenseCopy.UseVisualStyleBackColor = false;
            this.btnLicenseCopy.Click += new System.EventHandler(this.btnLicenseCopy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Mã máy:";
            // 
            // txtKeyKichHoat
            // 
            this.txtKeyKichHoat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKeyKichHoat.Location = new System.Drawing.Point(119, 53);
            this.txtKeyKichHoat.Multiline = true;
            this.txtKeyKichHoat.Name = "txtKeyKichHoat";
            this.txtKeyKichHoat.Size = new System.Drawing.Size(614, 49);
            this.txtKeyKichHoat.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 43;
            this.label1.Text = "Mã kích hoạt";
            // 
            // frmDangKyBanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangKyBanQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký bản quyền";
            this.Load += new System.EventHandler(this.frmDangKyBanQuyen_Load);
            this.panel2.ResumeLayout(false);
            this.groupBoxTaoLicense.ResumeLayout(false);
            this.groupBoxTaoLicense.PerformLayout();
            this.groupLicense.ResumeLayout(false);
            this.groupLicense.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaMay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThoiGianSuDung;
        private System.Windows.Forms.GroupBox groupBoxTaoLicense;
        private System.Windows.Forms.GroupBox groupLicense;
        private System.Windows.Forms.Button btnLicenseCopy;
        private System.Windows.Forms.TextBox txtKeyKichHoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTaoLicenseTao;
        private System.Windows.Forms.TextBox txtTaoLicenseMaKichHoat;
        private System.Windows.Forms.TextBox txtTaoLicensePassword;
        private System.Windows.Forms.Button btnTaoLicenseCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaoLicenseMaMay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLicenseLuu;
        private System.Windows.Forms.Button btnLicenseKiemTra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkKhongThoiHan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtTaoLicenseKeyDenNgay;
        private System.Windows.Forms.DateTimePicker dtTaoLicenseKeyTuNgay;
    }
}