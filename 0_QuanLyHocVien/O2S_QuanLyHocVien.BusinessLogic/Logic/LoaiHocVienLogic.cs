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
    public static class LoaiHocVienLogic
    {
        public static LOAIHOCVIEN Select(int _loaihocvienId)
        {
            try
            {
                var result = (from p in GlobalSettings.Database.LOAIHOCVIENs
                              where p.LoaiHocVienId == _loaihocvienId
                              select p);

                return result.FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<LOAIHOCVIEN> SelectAll()
        {
            try
            {
                var result = from p in GlobalSettings.Database.LOAIHOCVIENs
                             select p;

                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
