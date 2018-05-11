// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "ChiTietTrungTam.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class ChiTietTrungTamLogic
    {
        /// <summary>
        /// Lấy chi tiết trung tâm
        /// </summary>
        /// <returns></returns>
        public static THONGTINTRUNGTAM Select()
        {
            return (from p in Database.THONGTINTRUNGTAMs
                    select p).FirstOrDefault();
        }

        /// <summary>
        /// Cập nhật chi tiết trung tâm
        /// </summary>
        /// <param name="ct"></param>
        public static void Update(THONGTINTRUNGTAM ct)
        {
            Database.THONGTINTRUNGTAMs.DeleteOnSubmit(Select());
            Database.SubmitChanges();
            Database.THONGTINTRUNGTAMs.InsertOnSubmit(ct);
            Database.SubmitChanges();
        }
    }
}
