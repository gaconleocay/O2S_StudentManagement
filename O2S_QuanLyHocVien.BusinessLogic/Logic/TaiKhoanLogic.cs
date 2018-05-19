// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "TaiKhoan.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using O2S_QuanLyHocVien.BusinessLogic.Logic;
using System;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class TaiKhoanLogic
    {
        public static TAIKHOAN SelectSingle(int _taikhoanId)
        {
            try
            {
                return (from p in Database.TAIKHOANs
                        where p.TaiKhoanId == _taikhoanId
                        select p).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static TAIKHOAN SelectTheoTenDangNhap(string tenDangNhap)
        {
            try
            {
                return (from p in Database.TAIKHOANs
                        where p.TenDangNhap.ToLower() == tenDangNhap.ToLower()
                        select p).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<TAIKHOAN> SelectAll(string tenDangNhap, UserType? loaiTK)
        {
            switch (loaiTK)
            {
                case null:
                    return (from p in Database.TAIKHOANs
                            where (tenDangNhap == null ? true : p.TenDangNhap.Contains(tenDangNhap))
                            select p).ToList();
                case UserType.NhanVien:
                    return (from p in Database.NHANVIENs
                            where (tenDangNhap == null ? true : p.TAIKHOAN.TenDangNhap.Contains(tenDangNhap))
                            select p.TAIKHOAN).ToList();
                case UserType.HocVien:
                    return (from p in Database.HOCVIENs
                            where p.TAIKHOAN.TenDangNhap != null &&
                                  (tenDangNhap == null ? true : p.TAIKHOAN.TenDangNhap.Contains(tenDangNhap))
                            select p.TAIKHOAN).ToList();
                case UserType.GiangVien:
                    return (from p in Database.GIANGVIENs
                            where (tenDangNhap == null ? true : p.TAIKHOAN.TenDangNhap.Contains(tenDangNhap))
                            select p.TAIKHOAN).ToList();
                default:
                    return null;
            }
        }

        public static List<TaiKhoan_PlusDTO> SelectFilter(TaiKhoanFilter _filter)
        {
            try
            {
                if (_filter.LoaiTaiKhoanId != null)
                {
                    if (_filter.LoaiTaiKhoanId == KeySetting.LOAITAIKHOAN_NhanVien)
                    {
                        return (from p in Database.NHANVIENs
                                where (_filter.TenDangNhap == null ? true : p.TAIKHOAN.TenDangNhap.Contains(_filter.TenDangNhap)) && p.LoaiNhanVienId != KeySetting.LOAINHANVIEN_QuanTri && p.TAIKHOAN.IsRemove == 0
                                select new TaiKhoan_PlusDTO
                                {
                                    TaiKhoanId = p.TAIKHOAN.TaiKhoanId,
                                    LoaiTaiKhoanId = p.TAIKHOAN.LoaiTaiKhoanId,
                                    TenNguoiDung = p.TenNhanVien,
                                    TenLoaiTaiKhoan = p.TAIKHOAN.LOAITAIKHOAN.TenLoaiTaiKhoan,
                                    TenDangNhap = p.TAIKHOAN.TenDangNhap,
                                    MatKhau = p.TAIKHOAN.MatKhau,
                                    IsRemove = p.TAIKHOAN.IsRemove,
                                    CreatedDate = p.TAIKHOAN.CreatedDate,
                                    CreatedBy = p.TAIKHOAN.CreatedBy,
                                    CreatedLog = p.TAIKHOAN.CreatedLog,
                                    ModifiedDate = p.TAIKHOAN.ModifiedDate,
                                    ModifiedBy = p.TAIKHOAN.ModifiedBy,
                                    ModifiedLog = p.TAIKHOAN.ModifiedLog,
                                }).ToList();
                    }
                    else if (_filter.LoaiTaiKhoanId == KeySetting.LOAITAIKHOAN_HocVien)
                    {
                        return (from p in Database.HOCVIENs
                                where p.TAIKHOAN.TenDangNhap != null &&
                                      (_filter.TenDangNhap == null ? true : p.TAIKHOAN.TenDangNhap.Contains(_filter.TenDangNhap)) && p.TAIKHOAN.IsRemove == 0
                                select new TaiKhoan_PlusDTO
                                {
                                    TaiKhoanId = p.TAIKHOAN.TaiKhoanId,
                                    LoaiTaiKhoanId = p.TAIKHOAN.LoaiTaiKhoanId,
                                    TenNguoiDung = p.TenHocVien,
                                    TenLoaiTaiKhoan = p.TAIKHOAN.LOAITAIKHOAN.TenLoaiTaiKhoan,
                                    TenDangNhap = p.TAIKHOAN.TenDangNhap,
                                    MatKhau = p.TAIKHOAN.MatKhau,
                                    IsRemove = p.TAIKHOAN.IsRemove,
                                    CreatedDate = p.TAIKHOAN.CreatedDate,
                                    CreatedBy = p.TAIKHOAN.CreatedBy,
                                    CreatedLog = p.TAIKHOAN.CreatedLog,
                                    ModifiedDate = p.TAIKHOAN.ModifiedDate,
                                    ModifiedBy = p.TAIKHOAN.ModifiedBy,
                                    ModifiedLog = p.TAIKHOAN.ModifiedLog,
                                }).ToList();
                    }
                    else if (_filter.LoaiTaiKhoanId == KeySetting.LOAITAIKHOAN_GiangVien)
                    {
                        return (from p in Database.GIANGVIENs
                                where (_filter.TenDangNhap == null ? true : p.TAIKHOAN.TenDangNhap.Contains(_filter.TenDangNhap)) && p.TAIKHOAN.IsRemove == 0
                                select new TaiKhoan_PlusDTO
                                {
                                    TaiKhoanId = p.TAIKHOAN.TaiKhoanId,
                                    LoaiTaiKhoanId = p.TAIKHOAN.LoaiTaiKhoanId,
                                    TenNguoiDung = p.TenGiangVien,
                                    TenLoaiTaiKhoan = p.TAIKHOAN.LOAITAIKHOAN.TenLoaiTaiKhoan,
                                    TenDangNhap = p.TAIKHOAN.TenDangNhap,
                                    MatKhau = p.TAIKHOAN.MatKhau,
                                    IsRemove = p.TAIKHOAN.IsRemove,
                                    CreatedDate = p.TAIKHOAN.CreatedDate,
                                    CreatedBy = p.TAIKHOAN.CreatedBy,
                                    CreatedLog = p.TAIKHOAN.CreatedLog,
                                    ModifiedDate = p.TAIKHOAN.ModifiedDate,
                                    ModifiedBy = p.TAIKHOAN.ModifiedBy,
                                    ModifiedLog = p.TAIKHOAN.ModifiedLog,
                                }).ToList();
                    }
                    else if (_filter.LoaiTaiKhoanId == KeySetting.LOAITAIKHOAN_QuanTri)
                    {
                        return (from p in Database.NHANVIENs
                                where (_filter.TenDangNhap == null ? true : p.TAIKHOAN.TenDangNhap.Contains(_filter.TenDangNhap)) && p.LoaiNhanVienId == KeySetting.LOAINHANVIEN_QuanTri && p.TAIKHOAN.IsRemove == 0
                                select new TaiKhoan_PlusDTO
                                {
                                    TaiKhoanId = p.TAIKHOAN.TaiKhoanId,
                                    LoaiTaiKhoanId = p.TAIKHOAN.LoaiTaiKhoanId,
                                    TenNguoiDung = p.TenNhanVien,
                                    TenLoaiTaiKhoan = p.TAIKHOAN.LOAITAIKHOAN.TenLoaiTaiKhoan,
                                    TenDangNhap = p.TAIKHOAN.TenDangNhap,
                                    MatKhau = p.TAIKHOAN.MatKhau,
                                    IsRemove = p.TAIKHOAN.IsRemove,
                                    CreatedDate = p.TAIKHOAN.CreatedDate,
                                    CreatedBy = p.TAIKHOAN.CreatedBy,
                                    CreatedLog = p.TAIKHOAN.CreatedLog,
                                    ModifiedDate = p.TAIKHOAN.ModifiedDate,
                                    ModifiedBy = p.TAIKHOAN.ModifiedBy,
                                    ModifiedLog = p.TAIKHOAN.ModifiedLog,
                                }).ToList();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return (from p in Database.TAIKHOANs
                            where (_filter.TenDangNhap == null ? true : p.TenDangNhap.Contains(_filter.TenDangNhap)) && p.IsRemove == 0
                            select new TaiKhoan_PlusDTO
                            {
                                TaiKhoanId = p.TaiKhoanId,
                                LoaiTaiKhoanId = p.LoaiTaiKhoanId,
                                TenNguoiDung = p.TenDangNhap,
                                TenLoaiTaiKhoan = p.LOAITAIKHOAN.TenLoaiTaiKhoan,
                                TenDangNhap = p.TenDangNhap,
                                MatKhau = p.MatKhau,
                                IsRemove = p.IsRemove,
                                CreatedDate = p.CreatedDate,
                                CreatedBy = p.CreatedBy,
                                CreatedLog = p.CreatedLog,
                                ModifiedDate = p.ModifiedDate,
                                ModifiedBy = p.ModifiedBy,
                                ModifiedLog = p.ModifiedLog,
                            }).ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void Delete(int _TaiKhoanId)
        {
            try
            {
                //Xoa phan quyen tai khoan
                List<PHANQUYENTAIKHOAN> _lstPhanQuyen = PhanQuyenTaiKhoanLogic.SelectTheoTaiKhoan(_TaiKhoanId);
                Database.PHANQUYENTAIKHOANs.DeleteAllOnSubmit(_lstPhanQuyen);
                var temp = (from p in Database.TAIKHOANs
                            where p.TaiKhoanId == _TaiKhoanId
                            select p).Single();

                Database.TAIKHOANs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
            }
            catch (System.Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(TAIKHOAN tk)
        {
            try
            {
                var temp = (from p in Database.TAIKHOANs
                            where p.TenDangNhap.ToLower() == tk.TenDangNhap.ToLower()
                            select p).FirstOrDefault();

                temp.MatKhau = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(tk.MatKhau, true);
                temp.IsRemove = tk.IsRemove;
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }

        }

        public static int FullUserID(TAIKHOAN tk)
        {
            var a = (from p in Database.NHANVIENs
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (a != null)
                return a.NhanVienId;

            var b = (from p in Database.HOCVIENs
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (b != null)
                return b.HocVienId;

            var c = (from p in Database.GIANGVIENs
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (c != null)
                return c.GiangVienId;

            return 0;
        }

        public static UserType? FullUserType(TAIKHOAN tk)
        {
            try
            {
                var a = (from p in Database.NHANVIENs
                         where p.TAIKHOAN.TenDangNhap.ToLower() == tk.TenDangNhap.ToLower()
                         select p).SingleOrDefault();
                if (a != null)
                    return UserType.NhanVien;

                var b = (from p in Database.HOCVIENs
                         where p.TAIKHOAN.TenDangNhap.ToLower() == tk.TenDangNhap.ToLower()
                         select p).SingleOrDefault();
                if (b != null)
                    return UserType.HocVien;

                var c = (from p in Database.GIANGVIENs
                         where p.TAIKHOAN.TenDangNhap.ToLower() == tk.TenDangNhap.ToLower()
                         select p).SingleOrDefault();
                if (c != null)
                    return UserType.GiangVien;
                return null;
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static string FullUserName(TAIKHOAN tk)
        {
            try
            {
                var a = (from p in Database.NHANVIENs
                         where p.TAIKHOAN.TenDangNhap.ToLower() == tk.TenDangNhap.ToLower()
                         select p).SingleOrDefault();
                if (a != null)
                    return a.TenNhanVien;

                var b = (from p in Database.HOCVIENs
                         where p.TAIKHOAN.TenDangNhap.ToLower() == tk.TenDangNhap.ToLower()
                         select p).SingleOrDefault();
                if (b != null)
                    return b.TenHocVien;

                var c = (from p in Database.GIANGVIENs
                         where p.TAIKHOAN.TenDangNhap.ToLower() == tk.TenDangNhap.ToLower()
                         select p).SingleOrDefault();
                if (c != null)
                    return c.TenGiangVien;
                return null;
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool IsValid(string userName, string password)
        {
            try
            {
                return SelectTheoTenDangNhap(userName).MatKhau == O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(password, true);
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool UpdateMaDangNhap7So()
        {
            try
            {
                List<TAIKHOAN> _lstTaiKhoan = (from p in GlobalSettings.Database.TAIKHOANs
                                              where p.LoaiTaiKhoanId==2
                                              select p).ToList();

                foreach (var item in _lstTaiKhoan)
                {
                    HOCVIEN _hocvien = (from p in GlobalSettings.Database.HOCVIENs
                                        where p.TaiKhoanId == item.TaiKhoanId
                                        select p).Single();

                    TAIKHOAN _taikhoan = SelectSingle(item.TaiKhoanId);
                    _taikhoan.TenDangNhap = string.Format("{0}{1:D7}", "HV", _hocvien.HocVienId);
                    Database.SubmitChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
