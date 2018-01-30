// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "LoaiNV.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Collections.Generic;
using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class LoaiNV
    {
        /// <summary>
        /// Chọn tất cả loại nhân viên
        /// </summary>
        /// <returns></returns>
        public static List<LOAINV> SelectAll()
        {
            return (from p in Database.LOAINVs
                    select p).ToList();
        }
    }
}
