// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "PhongHoc.cs"
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
    public static class PhongHocLogic
    {
        public static PHONGHOC SelectSingle(int _phonghocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.PHONGHOCs
                        where p.PhongHocId == _phonghocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<PHONGHOC> Select(PhongHocFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.PHONGHOCs
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

        public static bool Insert(PHONGHOC _monhoc, ref int _monHocId)
        {
            try
            {
                _monhoc.CreatedDate = DateTime.Now;
                _monhoc.CreatedBy = GlobalSettings.UserCode;
                _monhoc.CreatedLog = GlobalSettings.SessionMyIP;
                _monhoc.IsRemove = 0;
                Database.PHONGHOCs.InsertOnSubmit(_monhoc);
                Database.SubmitChanges();
                _monHocId = _monhoc.PhongHocId;
                _monhoc.MaPhongHoc = string.Format("{0}{1:D5}", "PH", _monHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(PHONGHOC _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var monhoccu = SelectSingle(_hocVien.PhongHocId);

                monhoccu.TenPhongHoc = _hocVien.TenPhongHoc;
                monhoccu.GhiChu = _hocVien.GhiChu;
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

        public static bool Delete(int _phonghocId)
        {
            try
            {
                var temp = SelectSingle(_phonghocId);
                Database.PHONGHOCs.DeleteOnSubmit(temp);
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
