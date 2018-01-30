// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "ChiTietTrungTam.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class ChiTietTrungTam
    {
        /// <summary>
        /// Lấy chi tiết trung tâm
        /// </summary>
        /// <returns></returns>
        public static CHITIETTRUNGTAM Select()
        {
            return (from p in Database.CHITIETTRUNGTAMs
                    select p).Single();
        }

        /// <summary>
        /// Cập nhật chi tiết trung tâm
        /// </summary>
        /// <param name="ct"></param>
        public static void Update(CHITIETTRUNGTAM ct)
        {
            Database.CHITIETTRUNGTAMs.DeleteOnSubmit(Select());
            Database.SubmitChanges();
            Database.CHITIETTRUNGTAMs.InsertOnSubmit(ct);
            Database.SubmitChanges();
        }
    }
}
