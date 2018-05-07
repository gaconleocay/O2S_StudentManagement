// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "CaHoc.cs"
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
    public static class CaHocLogic
    {
        public static CAHOC SelectSingle(int _cahocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.CAHOCs
                        where p.CaHocId == _cahocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<CAHOC> Select(CaHocFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.CAHOCs
                             select p).ToList();
                if (_filter.IsRemove != null && _filter.IsRemove != 0)
                {
                    query = query.Where(o => o.IsRemove == _filter.IsRemove).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                return query;
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(CAHOC _monhoc, ref int _monHocId)
        {
            try
            {
                _monhoc.CreatedDate = DateTime.Now;
                _monhoc.CreatedBy = GlobalSettings.UserCode;
                _monhoc.CreatedLog = GlobalSettings.SessionMyIP;
                _monhoc.IsRemove = 0;
                Database.CAHOCs.InsertOnSubmit(_monhoc);
                Database.SubmitChanges();
                _monHocId = _monhoc.CaHocId;
                _monhoc.MaCaHoc = string.Format("{0}{1:D5}", "CH", _monHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(CAHOC _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var monhoccu = SelectSingle(_hocVien.CaHocId);

                monhoccu.TenCaHoc = _hocVien.TenCaHoc;
                monhoccu.TenCaHocFull = _hocVien.TenCaHocFull;
                monhoccu.ThoiGianTu = _hocVien.ThoiGianTu;
                monhoccu.ThoiGianDen = _hocVien.ThoiGianDen;
                monhoccu.IsLock = _hocVien.IsLock;
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

        public static bool Delete(int _cahocId)
        {
            try
            {
                var temp = SelectSingle(_cahocId);
                Database.CAHOCs.DeleteOnSubmit(temp);
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
