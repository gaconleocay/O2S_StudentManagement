// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "KhoaHocMonHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class KhoaHocMonHoc
    {
        //public static List<KhoaHocMonHocDTO> SelectKhoaHocMonHoc(string MaKhoaHoc)
        //{
        //    return (from p in Database.MONHOCs
        //            join khmh in Database.KHOAHOC_MONHOCs on p.MaMonHoc equals khmh.MaMonHoc
        //            select new KhoaHocMonHocDTO
        //            {
        //                IsCheck = khmh.MaMonHoc != null ? true : false,
        //                MaMonHoc = p.MaMonHoc,
        //                TenMonHoc = p.TenMonHoc,
        //                DiemDat = khmh.DiemDat ?? 0,
        //            }).ToList();
        //}

        /// <summary>
        /// Chọn một khóa học môn học
        /// </summary>
        /// <param name="MaKhoaHoc">Mã khóa học môn học</param>
        /// <returns></returns>
        public static List<KHOAHOC_MONHOC> SelectTheoKhoaHoc(string MaKhoaHoc)
        {
            return (from p in Database.KHOAHOC_MONHOCs
                    where p.MaKhoaHoc == MaKhoaHoc
                    select p).ToList();
        }
        public static KHOAHOC_MONHOC SelectTheoKhoaHocMonHoc(string MaKhoaHoc, string maMonHoc)
        {
            return (from p in Database.KHOAHOC_MONHOCs
                    where p.MaKhoaHoc == MaKhoaHoc && p.MaMonHoc == maMonHoc
                    select p).FirstOrDefault();
        }
        /// <summary>
        /// Thêm một khóa học môn học
        /// </summary>
        /// <param name="kh">Khóa học cần thêm</param>
        public static void Insert(KHOAHOC_MONHOC kh)
        {
            Database.KHOAHOC_MONHOCs.InsertOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin khóa học môn học
        /// </summary>
        /// <param name="kh">Khóa học cần sửa</param>
        public static void Update(KHOAHOC_MONHOC kh)
        {
            var khoaHocCu = SelectTheoKhoaHocMonHoc(kh.MaKhoaHoc, kh.MaMonHoc);

            khoaHocCu.MaMonHoc = kh.MaMonHoc;
            khoaHocCu.TenMonHoc = kh.TenMonHoc;
            khoaHocCu.MaKhoaHoc = kh.MaKhoaHoc;
            khoaHocCu.TenKhoaHoc = kh.TenKhoaHoc;
            khoaHocCu.DiemDat = kh.DiemDat;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xóa một khóa học môn học
        /// </summary>
        /// <param name="MaKhoaHoc">Mã khóa học môn học</param>
        public static void DeleteTheoKhoaHoc(string MaKhoaHoc)
        {
            List<KHOAHOC_MONHOC> khmh = (from p in Database.KHOAHOC_MONHOCs
                                         where p.MaKhoaHoc == MaKhoaHoc
                                         select p).ToList();
            //xóa khóa học môn học
            Database.KHOAHOC_MONHOCs.DeleteAllOnSubmit(khmh);
            Database.SubmitChanges();
        }

    }
}
