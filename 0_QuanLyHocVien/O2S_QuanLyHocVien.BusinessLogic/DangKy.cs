// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "DangKy.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class DangKy
    {
        /// <summary>
        /// Thêm một đăng ký
        /// </summary>
        /// <param name="dk"></param>
        public static void Insert(DANGKY dk)
        {
            Database.DANGKies.InsertOnSubmit(dk);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Chọn một đăng ký
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="MaKhoaHoc">Mã khóa học</param>
        /// <param name="maPhieu">Mã phiếu</param>
        /// <returns></returns>
        public static DANGKY Select(string maHV, string MaKhoaHoc, string maPhieu)
        {
            return (from p in Database.DANGKies
                    where p.MaHocVien == maHV && p.MaKhoaHoc == MaKhoaHoc && p.MaPhieu == maPhieu
                    select p).Single();
        }

        /// <summary>
        /// Tìm một đăng ký
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <returns></returns>
        public static IQueryable<DANGKY> SelectAll(string maHV)
        {
            return (from p in Database.DANGKies
                    where p.MaHocVien == maHV
                    select p);
        }
    }
}
