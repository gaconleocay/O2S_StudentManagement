// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "BangDiemChiTiet.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class BangDiemChiTietLogic
    {
        public static BANGDIEMCHITIET Select(int _bangDiemChiTietId)
        {
            try
            {
                return (from p in Database.BANGDIEMCHITIETs
                        where p.BangDiemChiTietId == _bangDiemChiTietId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void Insert(BANGDIEMCHITIET bd)
        {
            bd.IsRemove = 0;
            Database.BANGDIEMCHITIETs.InsertOnSubmit(bd);
            Database.SubmitChanges();
        }

        public static void Update(BANGDIEMCHITIET kh)
        {
            try
            {
                var khoaHocCu = Select(kh.BangDiemChiTietId);

                khoaHocCu.Diem = kh.Diem;
                Database.SubmitChanges();
            }
            catch (System.Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void Delete(int bangDiemId)
        {
            var kh = (from p in Database.BANGDIEMCHITIETs
                      where p.BangDiemId == bangDiemId
                      select p).Single();
            //xóa bảng điểm
            Database.BANGDIEMCHITIETs.DeleteOnSubmit(kh);
            Database.SubmitChanges();
        }
    }
}
