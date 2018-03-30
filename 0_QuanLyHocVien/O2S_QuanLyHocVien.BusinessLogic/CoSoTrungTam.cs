// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "CoSoTrungTam.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class CoSoTrungTam
    {
        /// <summary>
        /// Chọn tất cả cơ sở
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from p in Database.COSOTRUNGTAMs
                    select p).ToList();
        }

        /// <summary>
        /// Chọn một cơ sở
        /// </summary>
        /// <param name="maCoSo">Mã cơ sở</param>
        /// <returns></returns>
        public static COSOTRUNGTAM Select(string maCoSo)
        {
            return (from p in Database.COSOTRUNGTAMs
                    where p.MaCoSo == maCoSo
                    select p).FirstOrDefault();
        }

        /// <summary>
        /// Thêm một cơ sở
        /// </summary>
        /// <param name="kh">Khóa học cần thêm</param>
        public static void Insert(COSOTRUNGTAM kh)
        {
            Database.COSOTRUNGTAMs.InsertOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin cơ sở
        /// </summary>
        /// <param name="kh">Khóa học cần sửa</param>
        public static void Update(COSOTRUNGTAM kh)
        {
            var khoaHocCu = Select(kh.MaCoSo);

            khoaHocCu.TenCoSo = kh.TenCoSo;
            khoaHocCu.DiaChi = kh.DiaChi;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xóa một cơ sở
        /// </summary>
        /// <param name="maCoSo">Mã cơ sở</param>
        public static void Delete(string maCoSo)
        {
            var kh = (from p in Database.COSOTRUNGTAMs
                      where p.MaCoSo == maCoSo
                      select p).Single();
            //xóa cơ sở
            Database.COSOTRUNGTAMs.DeleteOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Tự động sinh mã cơ sở
        /// </summary>
        /// <returns></returns>
        public static string AutoGenerateId()
        {
            string result = "CS";
            var temp = from p in GlobalSettings.Database.COSOTRUNGTAMs
                       select p.MaCoSo;
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
