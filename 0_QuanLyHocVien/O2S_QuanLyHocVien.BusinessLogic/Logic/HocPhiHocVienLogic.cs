// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "HocPhiHocVien.cs"
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


namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class HocPhiHocVienLogic
    {
        public static HOCPHIHOCVIEN SelectSingle(int _hocphihocvienId)
        {
            try
            {
                return (from p in GlobalSettings.Database.HOCPHIHOCVIENs
                        where p.HocPhiHocVienId == _hocphihocvienId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<HocPhiHocVien_PlusDTO> Select(HocPhiHocVienFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.HOCPHIHOCVIENs
                             select p).AsEnumerable().Select((obj, index) => new HocPhiHocVien_PlusDTO
                             {
                                 Stt = index + 1,
                                 HocPhiHocVienId = obj.HocPhiHocVienId,
                                 HocVienId = obj.HocVienId,
                                 TenHocVien=obj.HOCVIEN.TenHocVien,
                                 DmDichVuId = obj.DmDichVuId,
                                 TenDichVu = obj.TenDichVu,
                                 SoTien = obj.SoTien,
                                 SoLuong = obj.SoLuong,
                                 PhieuThuId = obj.PhieuThuId,
                                 GhiChu = obj.GhiChu,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,
                             });
                if (_filter.HocPhiHocVienId != null && _filter.HocPhiHocVienId != 0)
                {
                   query = query.Where(o => o.HocPhiHocVienId == _filter.HocPhiHocVienId).ToList();
                }
                if (_filter.HocVienId != null && _filter.HocVienId != 0)
                {
                   query = query.Where(o => o.HocVienId == _filter.HocVienId).ToList();
                }
                if (_filter.PhieuThuId != null && _filter.PhieuThuId != 0)
                {
                   query = query.Where(o => o.PhieuThuId == _filter.PhieuThuId).ToList();
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
        //public static HOCPHIHOCVIEN Select(int _HocVienId, int _PhieuGhiDanhId)
        //{
        //    return (from p in Database.HOCPHIHOCVIENs
        //            where p.HocVienId == _HocVienId && p.PhieuGhiDanhId == _PhieuGhiDanhId
        //            select p).Single();
        //}
        public static bool Insert(HOCPHIHOCVIEN _hocphihocvien)
        {
            try
            {
                _hocphihocvien.CreatedDate = DateTime.Now;
                _hocphihocvien.CreatedBy = GlobalSettings.UserCode;
                _hocphihocvien.CreatedLog = GlobalSettings.SessionMyIP;
                Database.HOCPHIHOCVIENs.InsertOnSubmit(_hocphihocvien);
                Database.SubmitChanges();
               // _hocphihocvienId = _hocphihocvien.HocPhiHocVienId;
                //_hocphihocvien.MaHocPhiHocVien = string.Format("{0}{1:D5}", "PT", _hocphihocvienId);
                //Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(HOCPHIHOCVIEN _hocphihocvien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var hocphihocvienCu = SelectSingle(_hocphihocvien.HocPhiHocVienId);

                hocphihocvienCu.HocVienId = _hocphihocvien.HocVienId;
                hocphihocvienCu.SoTien = _hocphihocvien.SoTien;
                hocphihocvienCu.SoLuong = _hocphihocvien.SoLuong;
                hocphihocvienCu.GhiChu = _hocphihocvien.GhiChu;
                hocphihocvienCu.ModifiedDate = DateTime.Now;
                hocphihocvienCu.ModifiedBy = GlobalSettings.UserCode;
                hocphihocvienCu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _hocphihocvienId)
        {
            try
            {
                var temp = SelectSingle(_hocphihocvienId);
                Database.HOCPHIHOCVIENs.DeleteOnSubmit(temp);
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
