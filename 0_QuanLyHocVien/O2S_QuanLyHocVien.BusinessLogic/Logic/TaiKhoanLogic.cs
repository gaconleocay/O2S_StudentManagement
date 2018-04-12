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

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class TaiKhoanLogic
    {
        public static TAIKHOAN SelectSingle(int _taikhoanId)
        {
            return (from p in Database.TAIKHOANs
                    where p.TaiKhoanId == _taikhoanId
                    select p).FirstOrDefault();
        }
        public static TAIKHOAN Select(string tenDangNhap)
        {
            return (from p in Database.TAIKHOANs
                    where p.TenDangNhap == tenDangNhap
                    select p).FirstOrDefault();
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
                                where (_filter.TenDangNhap == null ? true : p.TAIKHOAN.TenDangNhap.Contains(_filter.TenDangNhap)) && p.LoaiNhanVienId != KeySetting.LOAINHANVIEN_QuanTri && p.TAIKHOAN.IsRemove ==0
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
                Common.Logging.LogSystem.Error(ex);
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
                Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(TAIKHOAN tk)
        {
            try
            {
                var temp = (from p in Database.TAIKHOANs
                            where p.TenDangNhap == tk.TenDangNhap
                            select p).Single();

                temp.MatKhau = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(tk.MatKhau, true);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                Common.Logging.LogSystem.Error(ex);
            }

        }

        /// <summary>
        /// Trả về mã của tên đăng nhập
        /// </summary>
        /// <param name="tk"></param>
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

        /// <summary>
        /// Trả về kiểu người dùng của tên đăng nhập
        /// </summary>
        /// <param name="tk"></param>
        public static UserType? FullUserType(TAIKHOAN tk)
        {
            var a = (from p in Database.NHANVIENs
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (a != null)
                return UserType.NhanVien;

            var b = (from p in Database.HOCVIENs
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (b != null)
                return UserType.HocVien;

            var c = (from p in Database.GIANGVIENs
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
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
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (a != null)
                return a.TenNhanVien;

            var b = (from p in Database.HOCVIENs
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (b != null)
                return b.TenHocVien;

            var c = (from p in Database.GIANGVIENs
                     where p.TAIKHOAN.TenDangNhap == tk.TenDangNhap
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
                return Select(userName).MatKhau == Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(password, true);
            }
            catch
            {
                return false;
            }

        }
    }
}
