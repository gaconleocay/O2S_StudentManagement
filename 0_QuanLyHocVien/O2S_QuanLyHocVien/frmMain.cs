// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmMain.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Drawing;
using System.Windows.Forms;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.Pages;
using O2S_QuanLyHocVien.Popups;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Configuration;
using O2S_License.PasswordKey;
using O2S_QuanLyHocVien.Base;
using System.Net;
using System.Linq;

namespace O2S_QuanLyHocVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
        }

        #region Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                DangNhap();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Đăng nhập và khởi động

        /// <summary>
        /// Đăng nhập vào phần mềm
        /// </summary>
        private void DangNhap()
        {
            this.Hide();
            try
            {
                GlobalSettings.ConnectToDatabase();

                frmDangNhap frm = new frmDangNhap();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadGiaoDien();
                    LoadDuLieuChuongTrinh();
                    HienThiThongTinVePhanMem_Version();
                    this.Show();

                    timerClock.Start();
                    timerKiemTraLicense.Interval = KeyTrongPhanMem.ThoiGianKiemTraLicense;
                    timerKiemTraLicense.Start();
                    KiemTraLicensevaEnableChucNang(); //kiem tra license truoc khi kiem tra phan quyen
                }
            }
            catch (Exception ex)
            {
                Reconnect();
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void Reconnect()
        {
            frmKetNoiCSDL frm = new frmKetNoiCSDL();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn cần khởi động lại chương trình để thay đổi có hiệu lực." + Environment.NewLine + "Khởi động ngay?", "Khởi động lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    Application.Restart();
                else
                    Application.Exit();
            }
            else
            {
                MessageBox.Show("Bạn không thể sử dụng chương trình nếu kết nối cơ sở dữ liệu chưa được thiết lập" + Environment.NewLine + "Hãy chạy lại chương trình vào lần tới để thiết lập lại kết nối cơ sở dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }
        public void PhanQuyen(UserType userType, string userName)
        {
            switch (userType)
            {
                case UserType.NhanVien:
                    string nvType = NhanVienLogic.SelectSingle(GlobalSettings.UserID) != null ? NhanVienLogic.SelectSingle(GlobalSettings.UserID).LOAINHANVIEN.TenLoaiNhanVien : "";
                    switch (nvType)
                    {
                        //Quan tri vien
                        case "LNV00":
                            {
                                btnBanQuyen.Visible = true;
                                break;
                            }
                        //nhân viên ghi danh
                        case "LNV01":
                            btnGiangVienTitle.Visible = false;
                            btnHocVienTitle.Visible = false;
                            btnQuanTriTitle.Visible = false;
                            btnThongKeNoHocVien.Enabled = false;
                            btnThongKeDiemTheoLop.Enabled = false;
                            btnQuanLyDiem.Enabled = false;
                            btnXepLop.Enabled = false;
                            btnNhanVienTitle_Click(btnNhanVienTitle, null);
                            btnBanQuyen.Visible = false;
                            break;
                        //nhân viên học vụ
                        case "LNV02":
                            btnGiangVienTitle.Visible = false;
                            btnHocVienTitle.Visible = false;
                            btnTiepNhanHocVien.Enabled = false;
                            btnLapPhieuGhiDanh.Enabled = false;
                            btnBaoCaoHocVienTheoThang.Enabled = false;
                            btnThongKeNoHocVien.Enabled = false;
                            btnQuanLyNhanVien.Enabled = false;
                            btnQuanLyHocPhi.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThayDoiQuyDinh.Enabled = false;
                            btnKetNoiCSDL.Enabled = false;
                            btnBanQuyen.Visible = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThongTinTrungTam.Enabled = false;
                            btnNhanVienTitle_Click(btnNhanVienTitle, null);
                            btnQuanLyCoSo.Enabled = false;
                            btnQuanLyMonHoc.Enabled = false;
                            break;
                        //nhân viên kế toán
                        case "LNV03":
                            btnGiangVienTitle.Visible = false;
                            btnHocVienTitle.Visible = false;
                            btnTiepNhanHocVien.Enabled = false;
                            btnLapPhieuGhiDanh.Enabled = false;
                            btnBaoCaoHocVienTheoThang.Enabled = false;
                            btnThongKeDiemTheoLop.Enabled = false;
                            btnQuanLyDiem.Enabled = false;
                            btnXepLop.Enabled = false;
                            btnQuanLyHocVien.Enabled = false;
                            btnQuanLyNhanVien.Enabled = false;
                            btnQuanLyGiangVien.Enabled = false;
                            btnQuanLyLopHoc.Enabled = false;
                            btnQuanLyKhoaHoc.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThayDoiQuyDinh.Enabled = false;
                            btnKetNoiCSDL.Enabled = false;
                            btnBanQuyen.Visible = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThongTinTrungTam.Enabled = false;
                            btnQuanLyCoSo.Enabled = false;
                            btnQuanLyMonHoc.Enabled = false;
                            btnNhanVienTitle_Click(btnNhanVienTitle, null);
                            break;
                        default:
                            btnHocVienTitle.Visible = false;
                            btnGiangVienTitle.Visible = false;
                            btnBanQuyen.Visible = false;
                            btnQuanTriTitle_Click(btnQuanTriTitle, null);
                            break;
                    }
                    break;
                case UserType.HocVien:
                    btnNhanVienTitle.Visible = false;
                    btnQuanTriTitle.Visible = false;
                    btnGiangVienTitle.Visible = false;
                    btnBanQuyen.Visible = false;
                    btnHocVienTitle_Click(this.btnHocVienTitle, null);
                    break;
                case UserType.GiangVien:
                    btnNhanVienTitle.Visible = false;
                    btnQuanTriTitle.Visible = false;
                    btnHocVienTitle.Visible = false;
                    btnBanQuyen.Visible = false;
                    btnGiangVienTitle_Click(this.btnGiangVienTitle, null);
                    break;
                default:
                    btnBanQuyen.Visible = false;
                    break;
            }
        }

        public void LoadGiaoDien()
        {
            try
            {
                ResetRibbonControlStatus();
                lblUserName.Text = GlobalSettings.UserCode;

                //PhanQuyen(GlobalSettings.UserType, GlobalSettings.UserName);
                pnlWorkspace.Controls.Clear();
                btnTrangMoDau_Click(null, null);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void LoadDuLieuChuongTrinh()
        {
            try
            {
                GlobalSettings.LoadCenterInformation();
                GlobalSettings.LoadQuyDinh();

                // Địa chỉ Ip
                String strHostName = Dns.GetHostName();
                IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
                //int nIP = 0;
                string listIP = "";
                for (int i = 0; i < iphostentry.AddressList.Count(); i++)
                {
                    listIP += iphostentry.AddressList[i] + ";";
                }
                GlobalSettings.SessionMyIP = listIP;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void HienThiThongTinVePhanMem_Version()
        {
            try
            {
                //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                //FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                //string version = fvi.FileVersion;
                this.Text = "Quản lý Học viên Trung tâm Anh ngữ (v" + Application.ProductVersion + ")";

                lblCenterName.Text = GlobalSettings.CenterName + " - [" + GlobalSettings.TenCoSo + "]";
                lblServerName.Text = GlobalSettings.ServerName;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void KiemTraLicensevaEnableChucNang()
        {
            try
            {
                //Kiểm tra phân quyền
                if (GlobalSettings.UserCode != KeyTrongPhanMem.AdminUser_key)
                {
                    if (!GlobalSettings.KiemTraLicenseSuDung)
                    {
                        EnableAndDisableTabChucNang(false);
                        DialogResult dialogResult = MessageBox.Show("Phần mềm hết bản quyền! \nVui lòng liên hệ với tác giả để được trợ giúp.\nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnTroGiupTitle_Click(null, null);
                    }
                    else
                    {
                        //KiemTraPhanQuyenNguoiDung();
                        PhanQuyen(GlobalSettings.UserType, GlobalSettings.UserCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion


        #region Ribbon bar

        #region Ribbon Tab

        /// <summary>
        /// Phục hồi màu sắc tiêu đề tab
        /// </summary>
        private void ResetColorTabTitle()
        {
            btnNhanVienTitle.BackColor = Color.White;
            btnGiangVienTitle.BackColor = Color.White;
            btnHocVienTitle.BackColor = Color.White;
            btnQuanTriTitle.BackColor = Color.White;
            btnTroGiupTitle.BackColor = Color.White;
        }

        private void btnNhanVienTitle_Click(object sender, EventArgs e)
        {
            try
            {
                tabRibbon.SelectedTab = tabRibbon.TabPages["tabNhanVien"];

                ResetColorTabTitle();
                ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnGiangVienTitle_Click(object sender, EventArgs e)
        {
            try
            {
                tabRibbon.SelectedTab = tabRibbon.TabPages["tabGiangVien"];

                ResetColorTabTitle();
                ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnHocVienTitle_Click(object sender, EventArgs e)
        {
            try
            {
                tabRibbon.SelectedTab = tabRibbon.TabPages["tabHocVien"];

                ResetColorTabTitle();
                ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnQuanTriTitle_Click(object sender, EventArgs e)
        {
            try
            {
                tabRibbon.SelectedTab = tabRibbon.TabPages["tabQuanTri"];

                ResetColorTabTitle();
                ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnTroGiupTitle_Click(object sender, EventArgs e)
        {
            try
            {
                tabRibbon.SelectedTab = tabRibbon.TabPages["tabTroGiup"];

                ResetColorTabTitle();
                ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion

        #region Ribbon Button
        private void btnThongTinTrungTam_Click(object sender, EventArgs e)
        {
            frmThongTinTrungTam frm = new frmThongTinTrungTam();
            frm.ShowDialog();
        }

        private void btnThongTinPhanMem_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem frm = new frmThongTinPhanMem();
            frm.Show();
        }

        private void btnTiepNhanHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                pnlWorkspace.Controls.Clear();
                frmTiepNhanHocVien _frm = new frmTiepNhanHocVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

                pnlWorkspace.Controls.Add(_frm);
                _frm.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnLapPhieuGhiDanh_Click(object sender, EventArgs e)
        {
            try
            {
                pnlWorkspace.Controls.Clear();

                //if (GlobalPages.LapPhieuGhiDanh == null)
                //    GlobalPages.LapPhieuGhiDanh = new frmLapPhieuGhiDanh()
                //    {
                //        Dock = DockStyle.Fill,
                //        TopLevel = false
                //    };

                //pnlWorkspace.Controls.Add(GlobalPages.LapPhieuGhiDanh);
                //GlobalPages.LapPhieuGhiDanh.Show();
                frmLapPhieuGhiDanh _frm = new frmLapPhieuGhiDanh()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

                pnlWorkspace.Controls.Add(_frm);
                _frm.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnGVDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(GlobalSettings.UserCode);
            frm.ShowDialog();
        }

        private void btnHVDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(GlobalSettings.UserCode);
            frm.ShowDialog();
        }

        private void btnGVThayDoiThongTin_Click(object sender, EventArgs e)
        {
            frmThayDoiThongTinGV frm = new frmThayDoiThongTinGV();
            frm.ShowDialog();
        }

        private void btnHVThayDoiThongTin_Click(object sender, EventArgs e)
        {
            frmThayDoiThongTinHV frm = new frmThayDoiThongTinHV();
            frm.ShowDialog();
        }

        private void btnBangDiem_Click(object sender, EventArgs e)
        {
            try
            {
                pnlWorkspace.Controls.Clear();

                //if (GlobalPages.BangDiem == null)
                //    GlobalPages.BangDiem = new frmBangDiem()
                //    {
                //        Dock = DockStyle.Fill,
                //        TopLevel = false
                //    };

                //pnlWorkspace.Controls.Add(GlobalPages.BangDiem);
                //GlobalPages.BangDiem.Show();
                frmBangDiem _frm = new frmBangDiem()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

                pnlWorkspace.Controls.Add(_frm);
                _frm.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnXemCacLopDay_Click(object sender, EventArgs e)
        {
            try
            {
                pnlWorkspace.Controls.Clear();
                frmXemCacLopDay _frm = new frmXemCacLopDay()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

                pnlWorkspace.Controls.Add(_frm);
                _frm.Show();
                //if (GlobalPages.XemCacLopDay == null)
                //    GlobalPages.XemCacLopDay = new frmXemCacLopDay()
                //    {
                //        Dock = DockStyle.Fill,
                //        TopLevel = false
                //    };

                //pnlWorkspace.Controls.Add(GlobalPages.XemCacLopDay);
                //GlobalPages.XemCacLopDay.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            try
            {
                pnlWorkspace.Controls.Clear();
                frmHocPhiHocVien _frm = new frmHocPhiHocVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

                pnlWorkspace.Controls.Add(_frm);
                _frm.Show();
                //if (GlobalPages.HocPhiHocVien == null)
                //    GlobalPages.HocPhiHocVien = new frmHocPhiHocVien()
                //    {
                //        Dock = DockStyle.Fill,
                //        TopLevel = false
                //    };

                //pnlWorkspace.Controls.Add(GlobalPages.HocPhiHocVien);
                //GlobalPages.HocPhiHocVien.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnCacLopDaHoc_Click(object sender, EventArgs e)
        {
            try
            {
                pnlWorkspace.Controls.Clear();
                frmCacLopDaHoc _frm = new frmCacLopDaHoc()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

                pnlWorkspace.Controls.Add(_frm);
                _frm.Show();
                //if (GlobalPages.CacLopDaHoc == null)
                //    GlobalPages.CacLopDaHoc = new frmCacLopDaHoc()
                //    {
                //        Dock = DockStyle.Fill,
                //        TopLevel = false
                //    };

                //pnlWorkspace.Controls.Add(GlobalPages.CacLopDaHoc);
                //GlobalPages.CacLopDaHoc.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnQuanLyHocVien_Click(object sender, EventArgs e)
        {
            try
            {
                pnlWorkspace.Controls.Clear();
                frmQuanLyHocVien _frm = new frmQuanLyHocVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

                pnlWorkspace.Controls.Add(_frm);
                _frm.Show();
                //if (GlobalPages.QuanLyHocVien == null)
                //    GlobalPages.QuanLyHocVien = new frmQuanLyHocVien()
                //    {
                //        Dock = DockStyle.Fill,
                //        TopLevel = false
                //    };

                //pnlWorkspace.Controls.Add(GlobalPages.QuanLyHocVien);
                //GlobalPages.QuanLyHocVien.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyNhanVien _frm = new frmQuanLyNhanVien()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.QuanLyNhanVien == null)
            //    GlobalPages.QuanLyNhanVien = new frmQuanLyNhanVien()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.QuanLyNhanVien);
            //GlobalPages.QuanLyNhanVien.Show();
        }

        private void btnQuanLyGiangVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyGiangVien _frm = new frmQuanLyGiangVien()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.QuanLyGiangVien == null)
            //    GlobalPages.QuanLyGiangVien = new frmQuanLyGiangVien()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.QuanLyGiangVien);
            //GlobalPages.QuanLyGiangVien.Show();
        }

        private void btnQuanLyLopHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyLopHoc _frm = new frmQuanLyLopHoc()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.QuanLyLopHoc == null)
            //    GlobalPages.QuanLyLopHoc = new frmQuanLyLopHoc()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.QuanLyLopHoc);
            //GlobalPages.QuanLyLopHoc.Show();
        }

        private void btnQuanLyKhoaHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyKhoaHoc _frm = new frmQuanLyKhoaHoc()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.QuanLyKhoaHoc == null)
            //    GlobalPages.QuanLyKhoaHoc = new frmQuanLyKhoaHoc()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.QuanLyKhoaHoc);
            //GlobalPages.QuanLyKhoaHoc.Show();
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyTaiKhoan _frm = new frmQuanLyTaiKhoan()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.QuanLyTaiKhoan == null)
            //    GlobalPages.QuanLyTaiKhoan = new frmQuanLyTaiKhoan()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.QuanLyTaiKhoan);
            //GlobalPages.QuanLyTaiKhoan.Show();
        }

        private void btnQuanLyDiem_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyDiem _frm = new frmQuanLyDiem()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.QuanLyDiem == null)
            //    GlobalPages.QuanLyDiem = new frmQuanLyDiem()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.QuanLyDiem);
            //GlobalPages.QuanLyDiem.Show();
        }

        private void btnThongKeDiemTheoLop_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmThongKeDiemTheoLop _frm = new frmThongKeDiemTheoLop()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.ThongKeDiemTheoLop == null)
            //    GlobalPages.ThongKeDiemTheoLop = new frmThongKeDiemTheoLop()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.ThongKeDiemTheoLop);
            //GlobalPages.ThongKeDiemTheoLop.Show();
        }

        private void btnThongKeNoHocVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmThongKeNoHocVien _frm = new frmThongKeNoHocVien()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.ThongKeNoHocVien == null)
            //    GlobalPages.ThongKeNoHocVien = new frmThongKeNoHocVien()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.ThongKeNoHocVien);
            //GlobalPages.ThongKeNoHocVien.Show();
        }

        private void btnBaoCaoHocVienTheoThang_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmBaoCaoHocVienTheoThang _frm = new frmBaoCaoHocVienTheoThang()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.BaoCaoHocVienTheoThang == null)
            //    GlobalPages.BaoCaoHocVienTheoThang = new frmBaoCaoHocVienTheoThang()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.BaoCaoHocVienTheoThang);
            //GlobalPages.BaoCaoHocVienTheoThang.Show();
        }

        private void btnTrangMoDau_Click(object sender, EventArgs e)
        {
            try
            {
                pnlWorkspace.Controls.Clear();

                frmTrangMoDau frm = new frmTrangMoDau() { Dock = DockStyle.Fill, TopLevel = false };
                pnlWorkspace.Controls.Add(frm);
                frm.Show();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnXepLop_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmXepLop _frm = new frmXepLop()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.XepLop == null)
            //    GlobalPages.XepLop = new frmXepLop()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.XepLop);
            //GlobalPages.XepLop.Show();
        }

        private void btnNVDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(GlobalSettings.UserCode);
            frm.ShowDialog();
        }

        private void btnThayDoiThongTinNV_Click(object sender, EventArgs e)
        {
            frmThayDoiThongTinNV frm = new frmThayDoiThongTinNV();
            frm.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();

            DangNhap();
        }

        private void btnThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            frmQuyDinh frm = new frmQuyDinh();
            frm.ShowDialog();
        }

        private void btnKetNoiCSDL_Click(object sender, EventArgs e)
        {
            frmKetNoiCSDL frm = new frmKetNoiCSDL();
            frm.ShowDialog();
        }
        private void btnBanQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                frmDangKyBanQuyen frm = new frmDangKyBanQuyen();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }
        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            //Process.Start("https://");
        }

        private void btnQuanLyHocPhi_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyHocPhi _frm = new frmQuanLyHocPhi()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.QuanLyHocPhi == null)
            //    GlobalPages.QuanLyHocPhi = new frmQuanLyHocPhi()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.QuanLyHocPhi);
            //GlobalPages.QuanLyHocPhi.Show();
        }
        private void btnQuanLyCoSo_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyCoSo _frm = new frmQuanLyCoSo()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //frmLapPhieuGhiDanh1 _frm = new frmLapPhieuGhiDanh1()
            //{
            //    Dock = DockStyle.Fill,
            //    TopLevel = false
            //};

            //pnlWorkspace.Controls.Add(_frm);
            //_frm.Show();
        }
        private void btnQuanLyMonHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();
            frmQuanLyMonHoc _frm = new frmQuanLyMonHoc()
            {
                Dock = DockStyle.Fill,
                TopLevel = false
            };

            pnlWorkspace.Controls.Add(_frm);
            _frm.Show();
            //if (GlobalPages.QuanLyMonHoc == null)
            //    GlobalPages.QuanLyMonHoc = new frmQuanLyMonHoc()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false
            //    };

            //pnlWorkspace.Controls.Add(GlobalPages.QuanLyMonHoc);
            //GlobalPages.QuanLyMonHoc.Show();
        }

        #endregion

        /// <summary>
        /// Phục hồi trạng thái enable của Ribbon control
        /// </summary>
        public void ResetRibbonControlStatus()
        {
            btnQuanTriTitle.Visible = true;
            btnNhanVienTitle.Visible = true;
            btnHocVienTitle.Visible = true;
            btnGiangVienTitle.Visible = true;
            btnTroGiup.Visible = true;

            btnTiepNhanHocVien.Enabled = true;
            btnLapPhieuGhiDanh.Enabled = true;
            btnBaoCaoHocVienTheoThang.Enabled = true;
            btnThongKeNoHocVien.Enabled = true;
            btnThongKeDiemTheoLop.Enabled = true;
            btnQuanLyDiem.Enabled = true;
            btnXepLop.Enabled = true;
            btnQuanLyHocVien.Enabled = true;
            btnQuanLyNhanVien.Enabled = true;
            btnQuanLyGiangVien.Enabled = true;
            btnQuanLyLopHoc.Enabled = true;
            btnQuanLyKhoaHoc.Enabled = true;
            btnQuanLyHocPhi.Enabled = true;
            btnQuanLyTaiKhoan.Enabled = true;
            btnThayDoiQuyDinh.Enabled = true;
            btnKetNoiCSDL.Enabled = true;
            btnBanQuyen.Enabled = true;
            btnQuanLyTaiKhoan.Enabled = true;
            btnThongTinTrungTam.Enabled = true;
            btnQuanLyCoSo.Enabled = true;
            btnQuanLyMonHoc.Enabled = true;
        }



        #endregion

        #region Timer
        private void timerKiemTraLicense_Tick(object sender, EventArgs e)
        {
            try
            {
                if (GlobalSettings.UserCode != KeyTrongPhanMem.AdminUser_key)
                {
                    Base.KiemTraLicense.KiemTraLicenseHopLe();
                    if (GlobalSettings.KiemTraLicenseSuDung == false)
                    {
                        timerKiemTraLicense.Stop();
                        btnTroGiup.PerformClick();
                        DialogResult dialogResult = MessageBox.Show("Phần mềm hết bản quyền! \nVui lòng liên hệ với tác giả để được trợ giúp.\nAuthor: Hồng Minh Nhất \nE-mail: hongminhnhat15@gmail.com \nPhone: 0868-915-456", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //if (dialogResult == DialogResult.OK)
                        //{
                        //    this.Visible = false;
                        //    this.Dispose();
                        //    frmDangNhap frm = new frmDangNhap();
                        //    frm.Show();
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
        }



        #endregion

        #region Process
        private void EnableAndDisableTabChucNang(bool enabledisable)
        {
            try
            {
                btnNhanVienTitle.Visible = enabledisable;
                btnGiangVienTitle.Visible = enabledisable;
                btnHocVienTitle.Visible = enabledisable;
                btnQuanTriTitle.Visible = enabledisable;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
                throw;
            }
        }
        #endregion


    }
}
