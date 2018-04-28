using DevExpress.XtraBars;
using O2S_License.PasswordKey;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.BusinessLogic.Logic;
using O2S_QuanLyHocVien.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static O2S_QuanLyHocVien.BusinessLogic.KeySetting;

namespace O2S_QuanLyHocVien.BUS
{
    public static class KiemTraPhanQuyen
    {
        public static BarItemVisibility KiemTraChucNang_Form(string _machucnang)
        {
            BarItemVisibility result = BarItemVisibility.Never;
            try
            {
                if (GlobalSettings.UserCode == KeyTrongPhanMem.AdminUser_key)
                {
                    result = BarItemVisibility.Always;
                }
                else
                {
                    PHANQUYENTAIKHOAN _phanquyen = PhanQuyenTaiKhoanLogic.SelectTheoMaChucNang(_machucnang);
                    if (_phanquyen != null)
                    {
                        result = BarItemVisibility.Always;
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        public static bool KiemTraChucNang_Nut(string _machucnang, ButtonEnum _button)
        {
            bool result = false;
            try
            {
                if (GlobalSettings.UserCode == KeyTrongPhanMem.AdminUser_key)
                {
                    result = true;
                }
                else
                {
                    PHANQUYENTAIKHOAN _phanquyen = PhanQuyenTaiKhoanLogic.SelectTheoMaChucNang(_machucnang);
                    if (_phanquyen != null)
                    {
                        switch (_button)
                        {
                            case ButtonEnum.Them:
                                {
                                    result = _phanquyen.Them == 1 ? true : false;
                                    break;
                                }
                            case ButtonEnum.Sua:
                                {
                                    result = _phanquyen.Sua == 1 ? true : false;
                                    break;
                                }
                            case ButtonEnum.Xoa:
                                {
                                    result = _phanquyen.Xoa == 1 ? true : false;
                                    break;
                                }
                            case ButtonEnum.In:
                                {
                                    result = _phanquyen.InAn == 1 ? true : false;
                                    break;
                                }
                            case ButtonEnum.XuatFile:
                                {
                                    result = _phanquyen.XuatFile == 1 ? true : false;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }



    }
}
