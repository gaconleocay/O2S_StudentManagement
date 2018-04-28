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
    public static class LoaiNhanVienLogic
    {
        public static LOAINHANVIEN Select(int _loainhanvienId)
        {
            return (from p in Database.LOAINHANVIENs
                    where p.LoaiNhanVienId == _loainhanvienId
                    select p).FirstOrDefault();
        }
        public static List<LOAINHANVIEN> SelectAll()
        {
            return (from p in Database.LOAINHANVIENs
                    select p).ToList();
        }
    }
}
