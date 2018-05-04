// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "KhoaHocMonHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class KhoaHocMonHocLogic
    {
        public static List<KHOAHOC_MONHOC> SelectTheoKhoaHoc(int _KhoaHocId)
        {
            try
            {
                return (from p in Database.KHOAHOC_MONHOCs
                        where p.KhoaHocId == _KhoaHocId
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static KHOAHOC_MONHOC SelectTheoKhoaHocMonHoc(int _khoahocId, int _monhocId)
        {
            try
            {
                return (from p in Database.KHOAHOC_MONHOCs
                        where p.KhoaHocId == _khoahocId && p.MonHocId == _monhocId
                        select p).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static void Insert(KHOAHOC_MONHOC _khoahoc)
        {
            try
            {
                //_khoahoc.CreatedDate = DateTime.Now;
                //_khoahoc.CreatedBy = GlobalSettings.UserCode;
                //_khoahoc.CreatedLog = GlobalSettings.SessionMyIP;
                Database.KHOAHOC_MONHOCs.InsertOnSubmit(_khoahoc);
                Database.SubmitChanges();
            }
            catch (System.Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void Update(KHOAHOC_MONHOC kh)
        {
            var khoaHocCu = SelectTheoKhoaHocMonHoc(kh.KhoaHocId ?? 0, kh.MonHocId ?? 0);

            khoaHocCu.MonHocId = kh.MonHocId;
            khoaHocCu.TenMonHoc = kh.TenMonHoc;
            khoaHocCu.KhoaHocId = kh.KhoaHocId;
            khoaHocCu.TenKhoaHoc = kh.TenKhoaHoc;
            khoaHocCu.DiemDat = kh.DiemDat;

            Database.SubmitChanges();
        }

        public static void DeleteTheoKhoaHoc(int _khoahocId)
        {
            try
            {
                List<KHOAHOC_MONHOC> khmh = (from p in Database.KHOAHOC_MONHOCs
                                             where p.KhoaHocId == _khoahocId
                                             select p).ToList();
                //xóa khóa học môn học
                Database.KHOAHOC_MONHOCs.DeleteAllOnSubmit(khmh);
                Database.SubmitChanges();
            }
            catch (System.Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

    }
}
