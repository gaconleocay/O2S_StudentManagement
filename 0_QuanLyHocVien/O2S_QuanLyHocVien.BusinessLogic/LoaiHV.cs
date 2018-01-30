// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "LoaiHV.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class LoaiHV
    {
        /// <summary>
        /// Chọn tất cả
        /// </summary>
        /// <returns></returns>
        public static List<LOAIHV> SelectAll()
        {
            var result = from p in GlobalSettings.Database.LOAIHVs
                         select p;

            return result.ToList();
        }
    }
}
