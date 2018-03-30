// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "MonHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class MonHoc
    {
        /// <summary>
        /// Chọn tất cả môn học
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from p in Database.MONHOCs
                    select p).ToList();
        }

        /// <summary>
        /// Chọn một môn học
        /// </summary>
        /// <param name="maMonHoc">Mã môn học</param>
        /// <returns></returns>
        public static MONHOC Select(string maMonHoc)
        {
            return (from p in Database.MONHOCs
                    where p.MaMonHoc == maMonHoc
                    select p).FirstOrDefault();
        }

        /// <summary>
        /// Thêm một môn học
        /// </summary>
        /// <param name="kh">Khóa học cần thêm</param>
        public static void Insert(MONHOC kh)
        {
            Database.MONHOCs.InsertOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin môn học
        /// </summary>
        /// <param name="kh">Khóa học cần sửa</param>
        public static void Update(MONHOC kh)
        {
            var khoaHocCu = Select(kh.MaMonHoc);

            khoaHocCu.TenMonHoc = kh.TenMonHoc;
            khoaHocCu.DiemToiDa = kh.DiemToiDa;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xóa một môn học
        /// </summary>
        /// <param name="maMonHoc">Mã môn học</param>
        public static void Delete(string maMonHoc)
        {
            var kh = (from p in Database.MONHOCs
                      where p.MaMonHoc == maMonHoc
                      select p).Single();
            //xóa môn học
            Database.MONHOCs.DeleteOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Tự động sinh mã môn học
        /// </summary>
        /// <returns></returns>
        public static string AutoGenerateId()
        {
            string result = "MH";
            var temp = from p in GlobalSettings.Database.MONHOCs
                       select p.MaMonHoc;
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
