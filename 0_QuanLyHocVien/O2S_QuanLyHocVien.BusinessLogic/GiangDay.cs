﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmGiangDay.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class GiangDay
    {
        /// <summary>
        /// Chọn danh sách lớp của giảng viên
        /// </summary>
        /// <param name="maGV"></param>
        /// <returns></returns>
        public static object Select(string maGV)
        {
            return (from p in Database.GIANGDAYs
                    where p.MaGiangVien == maGV
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.LOPHOC.TenLop,
                        NgayBD = p.LOPHOC.NgayBD,
                        NgayKT = p.LOPHOC.NgayKT,
                        DangMo = p.LOPHOC.DangMo,
                        SiSo = p.LOPHOC.SiSo
                    }).ToList();
        }


        /// <summary>
        /// Xóa một quá trình giảng dạy của giảng viên
        /// </summary>
        /// <param name="maGV"></param>
        public static void Delete(string maGV)
        {
            var temp = (from p in Database.GIANGDAYs
                        where p.MaGiangVien == maGV
                        select p);

            Database.GIANGDAYs.DeleteAllOnSubmit(temp);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Tìm các lớp thỏa điều kiện
        /// </summary>
        /// <param name="maGV">Mã giảng viên</param>
        /// <param name="tuNgay">Từ ngày</param>
        /// <param name="denNgay">Đến ngày</param>
        /// <param name="MaKhoaHoc">Mã khóa học</param>
        /// <returns></returns>
        public static object SelectAll(string maGV, DateTime? tuNgay, DateTime? denNgay, string MaKhoaHoc)
        {
            return (from p in Database.GIANGDAYs
                    where p.MaGiangVien == maGV &&
                          (tuNgay == null ? true : p.LOPHOC.NgayBD >= tuNgay) &&
                          (denNgay == null ? true : p.LOPHOC.NgayKT <= denNgay) &&
                          (MaKhoaHoc == null ? true : p.LOPHOC.MaKhoaHoc == MaKhoaHoc)
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.LOPHOC.TenLop
                    }).ToList();

        }
    }
}
