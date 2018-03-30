// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "HocVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class HocVien
    {
        public static object SelectAll()
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    select p).ToList();
        }

        /// <summary>
        /// Chọn tất cả theo cơ sở
        /// </summary>
        /// <returns></returns>
        public static object SelectTheoCoSo()
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where (p.MaCoSo == GlobalSettings.MaCoSo)
                    select p).ToList();
        }

        /// <summary>
        /// Chọn tất cả học viên theo loại
        /// </summary>
        /// <param name="loai">Loại học viên</param>
        /// <returns></returns>
        public static object SelectAll(string maloai)
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where p.MaLoaiHocVien == maloai
                    select p).ToList();
        }

        /// <summary>
        /// Chọn các học viên thỏa điều kiện
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="TenHocVien">Tên học viên</param>
        /// <param name="gioiTinh">Giới tính</param>
        /// <param name="tuNgay">Tiếp nhận từ ngày</param>
        /// <param name="denNgay">Tiếp nhận đến ngày</param>
        /// <param name="loai">Loại học viên</param>
        /// <returns></returns>
        public static object SelectAll(string maHV, string TenHocVien, string gioiTinh, DateTime? tuNgay, DateTime? denNgay, string maLoai)
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where (maLoai == null ? true : p.MaLoaiHocVien == maLoai) &&
                           (maHV == null ? true : p.MaHocVien.Contains(maHV)) &&
                           (TenHocVien == null ? true : p.TenHocVien.Contains(TenHocVien)) &&
                           (gioiTinh == null ? true : p.GioiTinhHocVien.Contains(gioiTinh)) &&
                           (tuNgay == null ? true : p.NgayTiepNhan >= tuNgay) &&
                           (denNgay == null ? true : p.NgayTiepNhan <= denNgay)
                    select p).ToList();
        }

        /// <summary>
        /// Chọn danh sách học viên chưa có lớp
        /// </summary>
        /// <returns></returns>
        public static List<DANGKY> DanhSachChuaCoLop()
        {
            return (from p in Database.DANGKies
                    where !(from q in Database.BANGDIEMs
                            select q.MaPhieu).Contains(p.MaPhieu)
                    select p).ToList();
        }

        /// <summary>
        /// Chọn một học viên
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <returns></returns>
        public static HOCVIEN Select(string maHV)
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where p.MaHocVien == maHV
                    select p).FirstOrDefault();
        }

        /// <summary>
        /// Thêm một học viên
        /// </summary>
        /// <param name="hocVien">Học viên cần thêm</param>
        public static void Insert(HOCVIEN hocVien, TAIKHOAN taiKhoan)
        {
            if (hocVien.MaLoaiHocVien == "LHV01")
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
            Database.HOCVIENs.InsertOnSubmit(hocVien);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật một học viên
        /// </summary>
        /// <param name="hocVien">Học viên cần cập nhật</param>
        /// <param name="taiKhoan">Tài khoản cần thêm mới</param>
        public static void Update(HOCVIEN hocVien, TAIKHOAN taiKhoan = null)
        {
            var hocVienCu = Select(hocVien.MaHocVien);

            //không thay đổi loại
            hocVienCu.TenHocVien = hocVien.TenHocVien;
            hocVienCu.NgaySinh = hocVien.NgaySinh;
            hocVienCu.GioiTinhHocVien = hocVien.GioiTinhHocVien;
            hocVienCu.DiaChi = hocVien.DiaChi;
            hocVienCu.SdtHocVien = hocVien.SdtHocVien;
            hocVienCu.EmailHocVien = hocVien.EmailHocVien;
            hocVienCu.NgayTiepNhan = hocVien.NgayTiepNhan;
            hocVienCu.SdtBo = hocVien.SdtBo;
            hocVienCu.EmailBo = hocVien.EmailBo;
            hocVienCu.SdtMe = hocVien.SdtMe;
            hocVienCu.EmailMe = hocVien.EmailMe;

            if (hocVienCu.MaLoaiHocVien != hocVien.MaLoaiHocVien)
            {
                //đổi từ tiềm năng sang chính thức
                if (hocVien.MaLoaiHocVien == "LHV01")
                {
                    Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
                    hocVienCu.MaLoaiHocVien = hocVien.MaLoaiHocVien;
                    hocVienCu.TenDangNhap = hocVien.TenDangNhap;
                }
                else
                {
                    hocVienCu.MaLoaiHocVien = hocVien.MaLoaiHocVien;
                    Database.TAIKHOANs.DeleteOnSubmit((from p in Database.TAIKHOANs where p.TenDangNhap == hocVienCu.TenDangNhap select p).Single());
                    hocVienCu.TenDangNhap = null;
                }
            }
            Database.SubmitChanges();
        }

        /// <summary>
        /// Xóa một học viên
        /// </summary>
        /// <param name="maHV">Mã học viên cần xóa</param>
        public static void Delete(string maHV)
        {
            var temp = Select(maHV);
            string maLoai = temp.MaLoaiHocVien;
            string tenDangNhap = temp.TenDangNhap;

            Database.HOCVIENs.DeleteOnSubmit(temp);
            Database.SubmitChanges();

            if (maLoai == "LHV01")
                TaiKhoan.Delete(tenDangNhap);
        }

        /// <summary>
        /// Tự động sinh mã học viên
        /// </summary>
        /// <returns></returns>
        public static string AutoGenerateId()
        {
            string result = "HV" + DateTime.Now.ToString("yyMMdd");
            var temp = from p in GlobalSettings.Database.HOCVIENs
                       where p.MaHocVien.StartsWith(result)
                       select p.MaHocVien;
            int max = -1;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(8, 2));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D2}", result, max + 1);
        }

        /// <summary>
        /// Đếm tổng học viên
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where (p.MaCoSo == GlobalSettings.MaCoSo)
                    select p).Count();
        }

        /// <summary>
        /// Đếm học viên tiềm năng
        /// </summary>
        /// <returns></returns>
        public static int CountTiemNang()
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where p.MaLoaiHocVien == "LHV00" && p.MaCoSo == GlobalSettings.MaCoSo
                    select p).Count();
        }

        /// <summary>
        /// Đếm học viên chính thức
        /// </summary>
        /// <returns></returns>
        public static int CountChinhThuc()
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where p.MaLoaiHocVien == "LHV01" && p.MaCoSo == GlobalSettings.MaCoSo
                    select p).Count();
        }
    }
}
