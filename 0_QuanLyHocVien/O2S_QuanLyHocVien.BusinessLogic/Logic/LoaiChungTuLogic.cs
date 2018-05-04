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
    public static class LoaiChungTuLogic
    {
        public static LOAICHUNGTU Select(int _loaichungtuId)
        {
            return (from p in Database.LOAICHUNGTUs
                    where p.LoaiChungTuId == _loaichungtuId
                    select p).FirstOrDefault();
        }
        public static List<LOAICHUNGTU> SelectAll()
        {
            try
            {
                return (from p in Database.LOAICHUNGTUs
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
