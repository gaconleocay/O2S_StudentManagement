// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "HoaDonThuChi.cs"
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
    public static class HoaDonThuChiLogic
    {
        public static HOADONTHUCHI SelectSingle(int _hoadonthuchiId)
        {
            try
            {
                return (from p in GlobalSettings.Database.HOADONTHUCHIs
                        where p.HoaDonThuChiId == _hoadonthuchiId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<HoaDonThuChi_PlusDTO> Select(HoaDonThuChiFilter _filter)
        {
            try
            {
                var query = (from obj in GlobalSettings.Database.HOADONTHUCHIs
                             select new HoaDonThuChi_PlusDTO
                             {
                                 HoaDonThuChiId = obj.HoaDonThuChiId,
                                 SoHoaDon = obj.SoHoaDon,
                                 LoaiChungTuId = obj.LoaiChungTuId,
                                 TenLoaiChungTu=obj.LOAICHUNGTU.TenLoaiChungTu,
                                 ThoiGianLap = obj.ThoiGianLap,
                                 TenNguoiLap = obj.TenNguoiLap,
                                 SoTien = obj.SoTien,
                                 NoiDung = obj.NoiDung,
                                 GhiChu = obj.GhiChu,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,

                             }).ToList();
                if (_filter.LoaiChungTuId != null && _filter.LoaiChungTuId != 0)
                {
                    query = query.Where(o => o.LoaiChungTuId == _filter.LoaiChungTuId).ToList();
                }
                if (_filter.ThoiGianLap_Tu != null && _filter.ThoiGianLap_Den != null)
                {
                    query = query.Where(o => o.ThoiGianLap >= _filter.ThoiGianLap_Tu && o.ThoiGianLap <= _filter.ThoiGianLap_Den).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(HOADONTHUCHI _hsthuchi)
        {
            try
            {
                _hsthuchi.CreatedDate = DateTime.Now;
                _hsthuchi.CreatedBy = GlobalSettings.UserCode;
                _hsthuchi.CreatedLog = GlobalSettings.SessionMyIP;
                _hsthuchi.IsRemove = 0;
                Database.HOADONTHUCHIs.InsertOnSubmit(_hsthuchi);
                Database.SubmitChanges();
               // _hdthuchiId = _hsthuchi.HoaDonThuChiId;
                //_hsthuchi.MaHoaDonThuChi = string.Format("{0}{1:D5}", "MH", _monHocId);
                //Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        //public static bool Update(HOADONTHUCHI _hocVien, TAIKHOAN taiKhoan = null)
        //{
        //    try
        //    {
        //        var hsthuchicu = SelectSingle(_hocVien.HoaDonThuChiId);

        //        hsthuchicu.TenHoaDonThuChi = _hocVien.TenHoaDonThuChi;
        //        hsthuchicu.DiemToiDa = _hocVien.DiemToiDa;
        //        hsthuchicu.ModifiedDate = DateTime.Now;
        //        hsthuchicu.ModifiedBy = GlobalSettings.UserCode;
        //        hsthuchicu.ModifiedLog = GlobalSettings.SessionMyIP;
        //        Database.SubmitChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        O2S_Common.Logging.LogSystem.Error(ex);
        //    }
        //}

        public static bool Delete(int _hoadonthuchiId)
        {
            try
            {
                var temp = SelectSingle(_hoadonthuchiId);
                Database.HOADONTHUCHIs.DeleteOnSubmit(temp);
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
