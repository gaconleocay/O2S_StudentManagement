﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmGiangDay.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using static BusinessLogic.GlobalSettings;

namespace BusinessLogic
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
                    where p.MaGV == maGV
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
                        where p.MaGV == maGV
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
        /// <param name="maKH">Mã khóa học</param>
        /// <returns></returns>
        public static object SelectAll(string maGV, DateTime? tuNgay, DateTime? denNgay, string maKH)
        {
            return (from p in Database.GIANGDAYs
                    where p.MaGV == maGV &&
                          (tuNgay == null ? true : p.LOPHOC.NgayBD >= tuNgay) &&
                          (denNgay == null ? true : p.LOPHOC.NgayKT <= denNgay) &&
                          (maKH == null ? true : p.LOPHOC.MaKH == maKH)
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.LOPHOC.TenLop
                    }).ToList();

        }
    }
}
