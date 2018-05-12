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
using DevExpress.XtraBars;
using O2S_QuanLyHocVien.BUS;
using DevExpress.XtraTab;
using O2S_QuanLyHocVien.CauHinh;
using O2S_QuanLyHocVien.ChucNang;
using O2S_QuanLyHocVien.BaoCao;
using O2S_QuanLyHocVien.DanhMuc;

namespace O2S_QuanLyHocVien
{
    public partial class frmMainHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        #region Trang chu
        private void btnTrangChu_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                xtraTabControl_Home.SelectedTabPageIndex = 0;
                xtraTabPage_TrangChu.Controls.Clear();
                frmTrangMoDau _frm = new frmTrangMoDau()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };
                xtraTabPage_TrangChu.Controls.Add(_frm);
                _frm.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnBangDiemCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBangDiemCaNhan frmControlActive = new frmBangDiemCaNhan() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmBangDiemCaNhan", "Bảng điểm cá nhân", "Bảng điểm cá nhân", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnHocPhiCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmHocPhiCaNhan frmControlActive = new frmHocPhiCaNhan() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmHocPhiCaNhan", "Học phí cá nhân", "Học phí cá nhân", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnCacLopDaHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmCacLopDaHocCaNhan frmControlActive = new frmCacLopDaHocCaNhan() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmCacLopDaHocCaNhan", "Các lớp đã học cá nhân", "Các lớp đã học cá nhân", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDoiMatKhau frmControlActive = new frmDoiMatKhau(GlobalSettings.UserCode);
                frmControlActive.ShowDialog();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnThayDoiThongTinCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //todo
                frmThayDoiThongTinHocVien frm = new frmThayDoiThongTinHocVien();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Tiep nhan
        private void btnTiepNhanHocVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTiepNhanHocVien frmControlActive = new frmTiepNhanHocVien() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmTiepNhanHocVien", "Tiếp nhận học viên", "Tiếp nhận học viên", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnLapPhieuGhiDanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLapPhieuGhiDanh frmControlActive = new frmLapPhieuGhiDanh() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmLapPhieuGhiDanh", "Lập phiếu ghi danh", "Lập phiếu ghi danh", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region QL lop hoc
        private void btnXepLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmXepLop frmControlActive = new frmXepLop() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmXepLop", "Xếp lớp học", "Xếp lớp học", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnQuanLyDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyDiem frmControlActive = new frmQuanLyDiem() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyDiem", "Quản lý điểm học viên", "Quản lý điểm học viên", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnXepLichHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmXepLichHoc frmControlActive = new frmXepLichHoc() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmXepLichHoc", "Xếp lịch học", "Xếp lịch học", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnLichHocTheoLopHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLichHocTheoLopHoc frmControlActive = new frmLichHocTheoLopHoc() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmLichHocTheoLopHoc", "Lịch học theo lớp học", "Lịch học theo lớp học", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnLichDayGiangVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLichDayCuaGiangVien frmControlActive = new frmLichDayCuaGiangVien() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmLichDayCuaGiangVien", "Lịch dạy của giảng viên", "Lịch dạy của giảng viên", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnBangDiemDanhHocVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBangDiemDanhHocVien frmControlActive = new frmBangDiemDanhHocVien() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmBangDiemDanhHocVien", "Bảng điểm danh học viên", "Bảng điểm danh học viên", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region QL trung tam
        private void btnQuanLyHocVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyHocVien frmControlActive = new frmQuanLyHocVien() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyHocVien", "Quản lý học viên", "Quản lý học viên", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnQuanLyHocVien_TiemNang_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyHocVienTiemNang frmControlActive = new frmQuanLyHocVienTiemNang() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyHocVienTiemNang", "Quản lý học viên tiềm năng", "Quản lý học viên tiềm năng", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnQuanLyHocVien_ChoLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyHocVienChoLop frmControlActive = new frmQuanLyHocVienChoLop() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyHocVienChoLop", "Quản lý học viên chờ lớp", "Quản lý học viên chờ lớp", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnQuanLyNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyNhanVien frmControlActive = new frmQuanLyNhanVien() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyNhanVien", "Quản lý nhân viên", "Quản lý nhân viên", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnQuanLyGiangVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyGiangVien frmControlActive = new frmQuanLyGiangVien() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyGiangVien", "Quản lý giảng viên", "Quản lý giảng viên", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnQuanLyHocPhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyHocPhi frmControlActive = new frmQuanLyHocPhi() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyHocPhi", "Quản lý học phí", "Quản lý học phí", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnQuanLyThuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyThuChi frmControlActive = new frmQuanLyThuChi() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyThuChi", "Quản lý thu chi", "Quản lý thu chi", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Danh muc
        private void btnDmKhoaHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDanhMucKhoaHoc frmControlActive = new frmDanhMucKhoaHoc() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmDanhMucKhoaHoc", "Danh mục khóa học", "Danh mục khóa học", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnDmLopHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDanhMucLopHoc frmControlActive = new frmDanhMucLopHoc() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmDanhMucLopHoc", "Danh mục lớp học", "Danh mục lớp học", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnDmMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDanhMucMonHoc frmControlActive = new frmDanhMucMonHoc() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmDanhMucMonHoc", "Danh mục môn học", "Danh mục môn học", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnDMCaHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDanhMucCaHoc frmControlActive = new frmDanhMucCaHoc() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmDanhMucCaHoc", "Danh mục ca/tiết học", "Danh mục ca/tiết học", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnDMPhongHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDanhMucPhongHoc frmControlActive = new frmDanhMucPhongHoc() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmDanhMucPhongHoc", "Danh mục phòng học", "Danh mục phòng học", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }



        #endregion

        #region He thong
        private void btnQuanLyTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuanLyTaiKhoan frmControlActive = new frmQuanLyTaiKhoan() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyTaiKhoan", "Quản lý tài khoản", "Quản lý tài khoản", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThayDoiQuyDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmQuyDinh _frm = new frmQuyDinh();
                _frm.ShowDialog();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnKetNoiCoSoDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmCauHinhPhanMem_CSDL _frm = new frmCauHinhPhanMem_CSDL();
                _frm.ShowDialog();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnThongTinTrungTam_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmThongTinTrungTam _frm = new frmThongTinTrungTam();
                _frm.ShowDialog();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnQuanLyCoSoTrungTam_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDanhMucCoSoTrungTam frmControlActive = new frmDanhMucCoSoTrungTam() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmQuanLyCoSo", "Cơ sở trung tâm", "Cơ sở trung tâm", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnDangKyBanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDangKyBanQuyen _frm = new frmDangKyBanQuyen();
                _frm.ShowDialog();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnQLCauHinhEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmCauHinhEmail frmControlActive = new frmCauHinhEmail() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmCauHinhEmail", "Cấu hình email", "Cấu hình email", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Tro giup
        private void btnTroGiup_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnThongTinPhanMem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmThongTinPhanMem _frm = new frmThongTinPhanMem();
                _frm.ShowDialog();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Khac
        private void btnKhoiDongLai_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.hoiThoatChuongTrinh = DialogResult.Retry;
                // Application.Restart();
                Application.ExitThread();
                System.Diagnostics.Process.Start(@"O2S_QuanLyHocVienLauncher.exe");
                Application.Exit();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }


        #endregion

        #region Bao cao
        private void btnBC_HocVienGhiDanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBaoCaoHocVienGhiDanh frmControlActive = new frmBaoCaoHocVienGhiDanh() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmBaoCaoHocVienGhiDanh", "Báo cáo học viên ghi danh", "Báo cáo học viên ghi danh", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnBC_TiepNhanHocVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBaoCaoTiepNhanHocVien frmControlActive = new frmBaoCaoTiepNhanHocVien() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmBaoCaoTiepNhanHocVien", "Báo cáo tiếp nhận học viên", "Báo cáo tiếp nhận học viên", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnBC_ThongKeTheoDoiDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBCThongKeTheoDoiDiem frmControlActive = new frmBCThongKeTheoDoiDiem() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmThongKeDiemTheoLop", "Thống kê theo dõi điểm", "Thống kê theo dõi điểm", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnBC_ThongKeNoHocPhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBCHocVienNoHocPhi frmControlActive = new frmBCHocVienNoHocPhi() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmBCHocVienNoHocPhi", "Thống kê học viên nợ học phí", "Thống kê học viên nợ học phí", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnBC_ThuTienChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBaoCaoThuTien_ChiTiet frmControlActive = new frmBaoCaoThuTien_ChiTiet() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmBaoCaoThuTien_ChiTiet", "Báo cáo thu tiền chi tiết", "Báo cáo thu tiền chi tiết", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void btnBC_ThuTienTongHop_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBaoCaoThuTien_TongHop frmControlActive = new frmBaoCaoThuTien_TongHop() { Dock = DockStyle.Fill, TopLevel = false };
                TabControlProcess.TabCreating(xtraTabControl_Home, "frmBaoCaoThuTien_TongHop", "Báo cáo thu tiền tổng hợp", "Báo cáo thu tiền tổng hợp", frmControlActive);
                frmControlActive.Show();
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn(ex);
            }
        }



        #endregion

    }
}
