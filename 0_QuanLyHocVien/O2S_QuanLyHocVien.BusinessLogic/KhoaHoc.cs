// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "KhoaHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class KhoaHoc
    {
        public static object Select()
        {
            return (from p in Database.KHOAHOCs
                    select p).ToList();
        }

        /// <summary>
        /// Chọn tất cả khóa học theo cơ sở
        /// </summary>
        /// <returns></returns>
        public static object SelectTheoCoCo()
        {
            return (from p in Database.KHOAHOCs
                    where (p.MaCoSo == GlobalSettings.MaCoSo)
                    select p).ToList();
        }

        /// <summary>
        /// Chọn một khóa học
        /// </summary>
        /// <param name="MaKhoaHoc">Mã khóa học</param>
        /// <returns></returns>
        public static KHOAHOC Select(string MaKhoaHoc)
        {
            return (from p in Database.KHOAHOCs
                    where p.MaKhoaHoc == MaKhoaHoc
                    select p).FirstOrDefault();
        }

        /// <summary>
        /// Thêm một khóa học
        /// </summary>
        /// <param name="kh">Khóa học cần thêm</param>
        public static void Insert(KHOAHOC kh)
        {
            Database.KHOAHOCs.InsertOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin khóa học
        /// </summary>
        /// <param name="kh">Khóa học cần sửa</param>
        public static void Update(KHOAHOC kh)
        {
            var khoaHocCu = Select(kh.MaKhoaHoc);

            khoaHocCu.TenKhoaHoc = kh.TenKhoaHoc;
            khoaHocCu.HocPhi = kh.HocPhi;
            //khoaHocCu.HeSoNghe = kh.HeSoNghe;
            //khoaHocCu.HeSoNoi = kh.HeSoNoi;
            //khoaHocCu.HeSoDoc = kh.HeSoDoc;
            //khoaHocCu.HeSoViet = kh.HeSoViet;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xóa một khóa học
        /// </summary>
        /// <param name="MaKhoaHoc">Mã khóa học</param>
        public static void Delete(string MaKhoaHoc)
        {
            var kh = (from p in Database.KHOAHOCs
                      where p.MaKhoaHoc == MaKhoaHoc
                      select p).Single();

            //xóa bảng đăng ký
            var dk = from p in Database.DANGKies
                     where p.MaKhoaHoc == MaKhoaHoc
                     select p;
            Database.DANGKies.DeleteAllOnSubmit(dk);

            //xóa bảng lớp học
            var l = from p in Database.LOPHOCs
                    where p.MaKhoaHoc == MaKhoaHoc
                    select p;
            foreach (var i in l)
            {
                LopHoc.Delete(i.MaLop);
            }

            //Xóa bảng [KHOAHOC_MONHOC]
            var khmh = from p in Database.KHOAHOC_MONHOCs
                     where p.MaKhoaHoc == MaKhoaHoc
                     select p;
            Database.KHOAHOC_MONHOCs.DeleteAllOnSubmit(khmh);

            //xóa khóa học
            Database.KHOAHOCs.DeleteOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Tự động sinh mã khóa học
        /// </summary>
        /// <returns></returns>
        public static string AutoGenerateId()
        {
            string result = "KH";
            var temp = from p in GlobalSettings.Database.KHOAHOCs
                       select p.MaKhoaHoc;
            int max = -1;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(2, 2));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D2}", result, max + 1);
        }

    }
}
