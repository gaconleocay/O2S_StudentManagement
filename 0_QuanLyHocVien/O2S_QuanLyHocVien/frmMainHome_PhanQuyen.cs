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
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;

namespace O2S_QuanLyHocVien
{
    public partial class frmMainHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private void KiemTraPhanQuyen_TabMenu()
        {
            try
            {
                List<CHUCNANG> _lstChucNang = ChucNangLogic.SelecTheoTaiKhoan();
                if (_lstChucNang != null && _lstChucNang.Count > 0)
                {
                    List<CHUCNANG> _lstChucNang_TrangChu = _lstChucNang.Where(o => o.TabMenuId == 1).ToList();
                    List<CHUCNANG> _lstChucNang_TiepNhan = _lstChucNang.Where(o => o.TabMenuId == 2).ToList();
                    List<CHUCNANG> _lstChucNang_QLLopHoc = _lstChucNang.Where(o => o.TabMenuId == 3).ToList();
                    List<CHUCNANG> _lstChucNang_QLHocVien = _lstChucNang.Where(o => o.TabMenuId == 4).ToList();
                    List<CHUCNANG> _lstChucNang_DanhMuc = _lstChucNang.Where(o => o.TabMenuId == 5).ToList();
                    List<CHUCNANG> _lstChucNang_HeThong = _lstChucNang.Where(o => o.TabMenuId == 6).ToList();
                    List<CHUCNANG> _lstChucNang_BaoCao = _lstChucNang.Where(o => o.TabMenuId == 7).ToList();
                    //
                    if (_lstChucNang_TrangChu != null && _lstChucNang_TrangChu.Count > 0)
                    {
                        ribbonPage_TrangChu.Visible = true;
                        ribbonPage_TrangChu_CN.Visible = true;
                        ribbonPage_TrangChu_TTCN.Visible = true;
                        //Nut chuc nang
                        btnBangDiemCaNhan.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_09");
                        btnHocPhiCaNhan.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_10");
                        btnCacLopDaHoc.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_11");

                    }
                    if (_lstChucNang_TiepNhan != null && _lstChucNang_TiepNhan.Count > 0)
                    {
                        ribbonPage_TiepNhan.Visible = true;
                        //ribbonPage_TiepNhan_TNHV.Visible = true;
                        //ribbonPage_TiepNhan_BC.Visible = true;
                        //
                        btnTiepNhanHocVien.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_01");
                        btnLapPhieuGhiDanh.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_02");
         

                    }
                    if (_lstChucNang_QLLopHoc != null && _lstChucNang_QLLopHoc.Count > 0)
                    {
                        ribbonPage_QLLopHoc.Visible = true;
                        //ribbonPage_QLLopHoc_LH.Visible = true;
                        //ribbonPage_QLLopHoc_BC.Visible = true;
                        //
                        btnXepLop.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_03");
                        btnQuanLyDiem.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_04");
                        btnXepLichHoc.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_15");
                        btnLichHocTheoLopHoc.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_16");
                        btnLichDayGiangVien.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_17");
                        btnBangDiemDanhHocVien.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_18");

                

                    }
                    if (_lstChucNang_QLHocVien != null && _lstChucNang_QLHocVien.Count > 0)
                    {
                        ribbonPage_QLHocVien.Visible = true;
                        //ribbonPage_QLHocVien_NV.Visible = true;
                        //ribbonPage_QLHocVien_TC.Visible = true;
                        //
                        btnQuanLyHocVien_ChinhThuc.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_05");
                        btnQuanLyHocVien_TiemNang.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_19");
                        btnQuanLyNhanVien.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_06");
                        btnQuanLyGiangVien.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_07");
                        btnQuanLyHocPhi.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_08");

                    }
                    if (_lstChucNang_DanhMuc != null && _lstChucNang_DanhMuc.Count > 0)
                    {
                        ribbonPage_DanhMuc.Visible = true;
                        ribbonPage_DanhMuc_DM.Visible = true;
                        //
                        btnDmKhoaHoc.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_12");
                        btnDmLopHoc.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_13");
                        btnDmMonHoc.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("FUNC_14");
                    }
                    if (_lstChucNang_HeThong != null && _lstChucNang_HeThong.Count > 0)
                    {
                        ribbonPage_HeThong.Visible = true;
                        //ribbonPage_HeThong_QLHT.Visible = true;
                        //ribbonPage_HeThong_DKBQ.Visible = true;
                        //
                        btnQuanLyTaiKhoan.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("SYS_02");
                        btnThayDoiQuyDinh.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("SYS_03");
                        btnKetNoiCoSoDuLieu.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("SYS_01");
                        btnThongTinTrungTam.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("SYS_06");
                        btnQuanLyCoSoTrungTam.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("SYS_04");
                        btnDangKyBanQuyen.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("SYS_05");
                    }
                    if (_lstChucNang_BaoCao != null && _lstChucNang_BaoCao.Count > 0)
                    {
                        ribbonPage_BaoCao.Visible = true;
                        //ribbonPage_BC_TiepNhan.Visible = true;
                        //ribbonPage_BC_QLLH.Visible = true;
                        //
                        btnBC_TiepNhanHocVien.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("REPORT_01");
                        btnBC_HocVienGhiDanh.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("REPORT_02");
                        btnBC_ThongKeTheoDoiDiem.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("REPORT_03");
                        btnBC_ThongKeNoHocPhi.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("REPORT_04");
                        btnBC_ThuTienChiTiet.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("REPORT_05");
                        btnBC_ThuTienTongHop.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("REPORT_06");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void EnableAndDisableTabChucNang(bool enabledisable)
        {
            try
            {
                //ribbonPage_TrangChu.Visible = enabledisable;
                //ribbonPage_TrangChu_CN.Visible = enabledisable;
               // ribbonPage_TrangChu_TTCN.Visible = enabledisable;

                ribbonPage_TiepNhan.Visible = enabledisable;
                // ribbonPage_TiepNhan_TNHV.Visible = enabledisable;
                //ribbonPage_TiepNhan_BC.Visible = enabledisable;

                ribbonPage_QLLopHoc.Visible = enabledisable;
                //ribbonPage_QLLopHoc_LH.Visible = enabledisable;
                //ribbonPage_QLLopHoc_BC.Visible = enabledisable;

                ribbonPage_QLHocVien.Visible = enabledisable;
                // ribbonPage_QLHocVien_NV.Visible = enabledisable;
                //ribbonPage_QLHocVien_TC.Visible = enabledisable;

                ribbonPage_DanhMuc.Visible = enabledisable;
                //ribbonPage_DanhMuc_DM.Visible = enabledisable;

                ribbonPage_HeThong.Visible = enabledisable;
                //ribbonPage_HeThong_QLHT.Visible = enabledisable;
                //ribbonPage_HeThong_DKBQ.Visible = enabledisable;

                ribbonPage_BaoCao.Visible = enabledisable;
                //ribbonPage_BC_TiepNhan.Visible = enabledisable;
                //ribbonPage_BC_QLLH.Visible = enabledisable;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void EnableNhapLicense()
        {
            try
            {
                ribbonPage_TrangChu.Visible = false;
                ribbonPage_TiepNhan.Visible = false;
                ribbonPage_QLLopHoc.Visible = false;
                ribbonPage_QLHocVien.Visible = false;
                ribbonPage_DanhMuc.Visible = false;
                ribbonPage_HeThong.Visible = true;
                ribbonPage_HeThong_QLHT.Visible = false;
                ribbonPage_BaoCao.Visible = false;
                btnDangKyBanQuyen.Visibility = KiemTraPhanQuyen.KiemTraChucNang_Form("SYS_05");
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }



    }
}
