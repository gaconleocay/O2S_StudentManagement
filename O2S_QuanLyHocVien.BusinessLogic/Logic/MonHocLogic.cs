// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "MonHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class MonHocLogic
    {
        public static MONHOC SelectSingle(int _khoahocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.MONHOCs
                        where p.MonHocId == _khoahocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<MonHoc_PlusDTO> Select(MonHocFilter _filter)
        {
            try
            {
                //List<MonHoc_PlusDTO> _result = null;
                var query = (from p in GlobalSettings.Database.MONHOCs
                             select p).AsEnumerable().Select((obj, index) => new MonHoc_PlusDTO
                             {
                                 Stt = index + 1,
                                 MonHocId = obj.MonHocId,
                                 MaMonHoc = obj.MaMonHoc,
                                 TenMonHoc = obj.TenMonHoc,
                                 DiemToiDa = obj.DiemToiDa,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,
                             });
                if (_filter.MonHocId != null && _filter.MonHocId != 0)
                {
                    query = query.Where(o => o.MonHocId == _filter.MonHocId).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(MONHOC _monhoc, ref int _monHocId)
        {
            try
            {
                _monhoc.CreatedDate = DateTime.Now;
                _monhoc.CreatedBy = GlobalSettings.UserCode;
                _monhoc.CreatedLog = GlobalSettings.SessionMyIP;
                _monhoc.IsRemove = 0;
                Database.MONHOCs.InsertOnSubmit(_monhoc);
                Database.SubmitChanges();
                _monHocId = _monhoc.MonHocId;
                _monhoc.MaMonHoc = string.Format("{0}{1:D5}", "MH", _monHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(MONHOC _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var monhoccu = SelectSingle(_hocVien.MonHocId);

                monhoccu.TenMonHoc = _hocVien.TenMonHoc;
                monhoccu.DiemToiDa = _hocVien.DiemToiDa;
                monhoccu.ModifiedDate = DateTime.Now;
                monhoccu.ModifiedBy = GlobalSettings.UserCode;
                monhoccu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _khoahocId)
        {
            try
            {
                var temp = SelectSingle(_khoahocId);
                Database.MONHOCs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
