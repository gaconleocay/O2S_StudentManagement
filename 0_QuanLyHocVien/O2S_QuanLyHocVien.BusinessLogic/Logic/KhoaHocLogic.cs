﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "KhoaHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using O2S_QuanLyHocVien.BusinessLogic;

namespace O2S_QuanLyKhoaHoc.BusinessLogic
{
    public static class KhoaHocLogic
    {
        public static KHOAHOC SelectSingle(int _khoahocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.KHOAHOCs
                        where p.KhoaHocId == _khoahocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<KhoaHoc_PlusDTO> Select(KhoaHocFilter _filter)
        {
            try
            {
                //List<KhoaHoc_PlusDTO> _result = null;
                var query = (from p in GlobalSettings.Database.KHOAHOCs
                             select p).AsEnumerable().Select((obj, index) => new KhoaHoc_PlusDTO
                             {
                                 Stt = index + 1,
                                 KhoaHocId = obj.KhoaHocId,
                                 CoSoId = obj.CoSoId,
                                 TenCoSoTrungTam = obj.COSOTRUNGTAM.TenCoSo,
                                 MaKhoaHoc = obj.MaKhoaHoc,
                                 TenKhoaHoc = obj.TenKhoaHoc,
                                 HocPhi = obj.HocPhi,
                                 IsRemove = obj.IsRemove,
                                 TrangThai_Ten = obj.IsRemove == 1 ? "Đã khóa" : "",
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,
                             });
                if (_filter.KhoaHocId != null && _filter.KhoaHocId != 0)
                {
                    query = query.Where(o => o.KhoaHocId == _filter.KhoaHocId).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.IsRemove != null && _filter.IsRemove != 0)
                {
                    query = query.Where(o => o.IsRemove == _filter.IsRemove).ToList();
                }
                if (_filter.CreatedDate_Tu != null && _filter.CreatedDate_Den != null)
                {
                    query = query.Where(o => o.CreatedDate >= _filter.CreatedDate_Tu && o.CreatedDate <= _filter.CreatedDate_Den).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(KHOAHOC _khoahoc, ref int _khoaHocId)
        {
            try
            {
                _khoahoc.CreatedDate = DateTime.Now;
                _khoahoc.CreatedBy = GlobalSettings.UserCode;
                _khoahoc.CreatedLog = GlobalSettings.SessionMyIP;
                Database.KHOAHOCs.InsertOnSubmit(_khoahoc);
                Database.SubmitChanges();
                _khoaHocId = _khoahoc.KhoaHocId;
                _khoahoc.MaKhoaHoc = string.Format("{0}{1:D5}", "KH", _khoaHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(KHOAHOC _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var hocVienCu = SelectSingle(_hocVien.KhoaHocId);

                hocVienCu.TenKhoaHoc = _hocVien.TenKhoaHoc;
                hocVienCu.HocPhi = _hocVien.HocPhi;
                hocVienCu.IsRemove = _hocVien.IsRemove;
                hocVienCu.ModifiedDate = DateTime.Now;
                hocVienCu.ModifiedBy = GlobalSettings.UserCode;
                hocVienCu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _khoahocId)
        {
            try
            {
                var temp = SelectSingle(_khoahocId);
                Database.KHOAHOCs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

    }
}
