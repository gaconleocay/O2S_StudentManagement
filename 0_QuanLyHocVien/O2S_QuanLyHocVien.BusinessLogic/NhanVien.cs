// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "NhanVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class NhanVien
    {
        /// <summary>
        /// Chọn một nhân viên
        /// </summary>
        /// <param name="maNV"></param>
        /// <returns></returns>
        public static NHANVIEN Select(string maNV)
        {
            return (from p in Database.NHANVIENs
                    where p.MaNhanVien == maNV
                    select p).FirstOrDefault();
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from p in Database.NHANVIENs
                    select new
                    {
                        MaNhanVien = p.MaNhanVien,
                        TenNhanVien = p.TenNhanVien,
                        SdtNhanVien = p.SdtNhanVien,
                        EmailNhanVien = p.EmailNhanVien,
                        TenLoaiNhanVien = p.LOAINV.TenLoaiNhanVien
                    }).ToList();
        }

        /// <summary>
        /// Lấy danh sách nhân viên thỏa điều kiện
        /// </summary>
        /// <param name="maNV">Mã nhân viên</param>
        /// <param name="tenNV">Tên nhân viên</param>
        /// <param name="maLoaiHV">Mã loại nhân viên</param>
        /// <returns></returns>
        public static object SelectAll(string maNV, string tenNV, string maLoaiHV)
        {
            return (from p in GlobalSettings.Database.NHANVIENs
                    where (maNV == null ? true : p.MaNhanVien.Contains(maNV)) &&
                          (tenNV == null ? true : p.TenNhanVien.Contains(tenNV)) &&
                          (maLoaiHV == null ? true : p.MaLoaiNhanVien == maLoaiHV)
                    select new
                    {
                        MaNhanVien = p.MaNhanVien,
                        TenNhanVien = p.TenNhanVien,
                        SdtNhanVien = p.SdtNhanVien,
                        EmailNhanVien = p.EmailNhanVien,
                        TenLoaiNhanVien = p.LOAINV.TenLoaiNhanVien
                    }).ToList();
        }

        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="nhanVien">Nhân viên</param>
        /// <param name="taiKhoan">Tài khoản</param>
        public static void Insert(NHANVIEN nhanVien, TAIKHOAN taiKhoan)
        {
            var f = TaiKhoan.SelectAll(taiKhoan.TenDangNhap, UserType.NhanVien);

            if (f.Count > 0)
                throw new Exception("Tên tài khoản đã tồn tại");
            else
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
            Database.NHANVIENs.InsertOnSubmit(nhanVien);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="nhanVien"></param>
        /// <param name="taiKhoan"></param>
        public static void Update(NHANVIEN nhanVien, TAIKHOAN taiKhoan = null)
        {
            var nhanVienCu = Select(nhanVien.MaNhanVien);

            nhanVienCu.TenNhanVien = nhanVien.TenNhanVien;
            nhanVienCu.SdtNhanVien = nhanVien.SdtNhanVien;
            nhanVienCu.EmailNhanVien = nhanVien.EmailNhanVien;
            nhanVienCu.MaLoaiNhanVien = nhanVien.MaLoaiNhanVien;

            Database.SubmitChanges();
            if(taiKhoan!=null)
                TaiKhoan.Update(taiKhoan);         
        }

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// <param name="maNV">Mã nhân viên cần xóa</param>
        public static void Delete(string maNV)
        {
            var temp = Select(maNV);
            string tenDangNhap = temp.TenDangNhap;

            Database.NHANVIENs.DeleteOnSubmit(temp);
            Database.SubmitChanges();

            TaiKhoan.Delete(tenDangNhap);
        }

        /// <summary>
        /// Tự động sinh mã nhân viên
        /// </summary>
        /// <returns></returns>
        public static string AutoGenerateId()
        {
            string result = "NV";
            var temp = from p in GlobalSettings.Database.NHANVIENs
                       where p.MaNhanVien.StartsWith(result)
                       select p.MaNhanVien;
            int max = -1;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(2, 4));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D4}", result, max + 1);
        }
    }
}
