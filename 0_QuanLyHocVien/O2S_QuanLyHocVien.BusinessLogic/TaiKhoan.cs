﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "TaiKhoan.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using System.Collections.Generic;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class TaiKhoan
    {
        /// <summary>
        /// Chọn một tài khoản
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập</param>
        /// <returns></returns>
        public static TAIKHOAN Select(string tenDangNhap)
        {
            return (from p in Database.TAIKHOANs
                    where p.TenDangNhap == tenDangNhap
                    select p).FirstOrDefault();
        }

        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <param name="tenDangNhap">Theo tên đăng nhập</param>
        /// <param name="loaiTK">Theo loại tài khoản (0: Nhân viên, 1: Học viên, 2: Giảng viên)</param>
        /// <returns></returns>
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
                            where (tenDangNhap == null ? true : p.TenDangNhap.Contains(tenDangNhap))
                            select p.TAIKHOAN).ToList();
                case UserType.HocVien:
                    return (from p in Database.HOCVIENs
                            where p.TenDangNhap != null &&
                                  (tenDangNhap == null ? true : p.TenDangNhap.Contains(tenDangNhap))
                            select p.TAIKHOAN).ToList();
                case UserType.GiangVien:
                    return (from p in Database.GIANGVIENs
                            where (tenDangNhap == null ? true : p.TenDangNhap.Contains(tenDangNhap))
                            select p.TAIKHOAN).ToList();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="tenDangNhap"></param>
        public static void Delete(string tenDangNhap)
        {
            var temp = (from p in Database.TAIKHOANs
                        where p.TenDangNhap == tenDangNhap
                        select p).Single();

            Database.TAIKHOANs.DeleteOnSubmit(temp);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="tk"></param>
        public static void Update(TAIKHOAN tk)
        {
            var temp = (from p in Database.TAIKHOANs
                        where p.TenDangNhap == tk.TenDangNhap
                        select p).Single();

            temp.MatKhau = tk.MatKhau;
            Database.SubmitChanges();
        }

        /// <summary>
        /// Trả về mã của tên đăng nhập
        /// </summary>
        /// <param name="tk"></param>
        public static string FullUserID(TAIKHOAN tk)
        {
            var a = (from p in Database.NHANVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (a != null)
                return a.MaNhanVien;

            var b = (from p in Database.HOCVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (b != null)
                return b.MaHocVien;

            var c = (from p in Database.GIANGVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (c != null)
                return c.MaGiangVien;

            return null;
        }

        /// <summary>
        /// Trả về kiểu người dùng của tên đăng nhập
        /// </summary>
        /// <param name="tk"></param>
        public static UserType? FullUserType(TAIKHOAN tk)
        {
            var a = (from p in Database.NHANVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (a != null)
                return UserType.NhanVien;

            var b = (from p in Database.HOCVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (b != null)
                return UserType.HocVien;

            var c = (from p in Database.GIANGVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (c != null)
                return UserType.GiangVien;
            return null;
        }

        /// <summary>
        /// Trả về tên người dùng của tên đăng nhập
        /// </summary>
        /// <param name="tk"></param>
        public static string FullUserName(TAIKHOAN tk)
        {
            var a = (from p in Database.NHANVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (a != null)
                return a.TenNhanVien;

            var b = (from p in Database.HOCVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (b != null)
                return b.TenHocVien;

            var c = (from p in Database.GIANGVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (c != null)
                return c.TenGiangVien;
            return null;
        }

        /// <summary>
        /// Xác định tên đăng nhập và mật khẩu có hợp lệ
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns></returns>
        public static bool IsValid(string userName, string password)
        {
            try
            {
                return Select(userName).MatKhau == password;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
