// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "LichHoc.cs"
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
using System.Transactions;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class XepLichHocLogic
    {
        public static XEPLICHHOC SelectSingle(int _xeplichhocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.XEPLICHHOCs
                        where p.XepLichHocId == _xeplichhocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<XEPLICHHOC> SelectTheoLopHoc(int _lophocid)
        {
            try
            {
                return (from p in GlobalSettings.Database.XEPLICHHOCs
                        where p.LopHocId == _lophocid
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<XepLichHoc_PlusDTO> Select(XepLichHocFilter _filter)
        {
            try
            {
                //List<LichHoc_PlusDTO> _result = null;
                var query = (from p in GlobalSettings.Database.XEPLICHHOCs
                             select new XepLichHoc_PlusDTO
                             {
                                 XepLichHocId = p.XepLichHocId,
                                 CoSoId = p.CoSoId,
                                 KhoaHocId = p.KhoaHocId,
                                 LopHocId = p.LopHocId,
                                 TenLopHoc = p.TenLopHoc,
                                 ThoiGianHoc = p.ThoiGianHoc,
                                 CaHocId = p.CaHocId,
                                 TenCaHocFull = p.TenCaHocFull,
                                 GiaoVien_ChinhId = p.GiaoVien_ChinhId,
                                 TenGiaoVien_Chinh = p.TenGiaoVien_Chinh,
                                 TienGiaoVien_Chinh = p.TienGiaoVien_Chinh,
                                 GiaoVien_TroGiangId = p.GiaoVien_TroGiangId,
                                 TenGiaoVien_TroGiang = p.TenGiaoVien_TroGiang,
                                 TienGiaoVien_TroGiang = p.TienGiaoVien_TroGiang,
                                 GhiChu = p.GhiChu,
                                 IsLock = p.IsLock,
                                 IsRemove = p.IsRemove,
                                 CreatedDate = p.CreatedDate,
                                 CreatedBy = p.CreatedBy,
                                 CreatedLog = p.CreatedLog,
                                 ModifiedDate = p.ModifiedDate,
                                 ModifiedBy = p.ModifiedBy,
                                 ModifiedLog = p.ModifiedLog,

                             }).ToList();
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.LopHocId != null && _filter.LopHocId != 0)
                {
                    query = query.Where(o => o.LopHocId == _filter.LopHocId).ToList();
                }
                if (_filter.IsRemove != null && _filter.IsRemove != 0)
                {
                    query = query.Where(o => o.IsRemove == _filter.IsRemove).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<XEPLICHHOC> SelectTheoGiangVien(XepLichHocFilter _filter)
        {
            try
            {
                return (from p in GlobalSettings.Database.XEPLICHHOCs
                        where p.GiaoVien_ChinhId == _filter.GiaoVien_ChinhId || p.GiaoVien_TroGiangId == _filter.GiaoVien_TroGiangId
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<XepLichHoc_PlusDTO> SelectGroupTheoNgayHoc(XepLichHocFilter _filter)
        {
            try
            {
                var query = (from obj in GlobalSettings.Database.XEPLICHHOCs
                             where (obj.LopHocId == _filter.LopHocId && obj.IsLock == true)
                             select new XepLichHoc_PlusDTO
                             {
                                 ThoiGianHoc = obj.ThoiGianHoc,
                                 ThoiGianHoc_Full = obj.ThoiGianHoc_Full,
                                 //ThoiGianHoc_Long = obj.ThoiGianHoc.ToString("yyyy-MM-dd"),
                             }).ToList().GroupBy(o => o.ThoiGianHoc).Select(n => n.First()).ToList();
                return query;
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(XEPLICHHOC _xeplichhoc, ref int _xeplichhocId)
        {
            try
            {
                _xeplichhoc.CreatedDate = DateTime.Now;
                _xeplichhoc.CreatedBy = GlobalSettings.UserCode;
                _xeplichhoc.CreatedLog = GlobalSettings.SessionMyIP;
                _xeplichhoc.IsRemove = 0;
                Database.XEPLICHHOCs.InsertOnSubmit(_xeplichhoc);
                Database.SubmitChanges();
                _xeplichhocId = _xeplichhoc.XepLichHocId;
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static bool InsertMultiRow(List<XEPLICHHOC> _lstxeplichhoc)
        {
            try
            {
                foreach (var item in _lstxeplichhoc)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = GlobalSettings.UserCode;
                    item.CreatedLog = GlobalSettings.SessionMyIP;
                    item.IsRemove = 0;
                    Database.XEPLICHHOCs.InsertOnSubmit(item);
                }
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(XEPLICHHOC _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var hocVienCu = SelectSingle(_hocVien.XepLichHocId);

                hocVienCu.ThoiGianHoc = _hocVien.ThoiGianHoc;
                hocVienCu.CaHocId = _hocVien.CaHocId;
                hocVienCu.TenCaHocFull = _hocVien.TenCaHocFull;
                hocVienCu.GiaoVien_ChinhId = _hocVien.GiaoVien_ChinhId;
                hocVienCu.TenGiaoVien_Chinh = _hocVien.TenGiaoVien_Chinh;
                hocVienCu.TienGiaoVien_Chinh = _hocVien.TienGiaoVien_Chinh;
                hocVienCu.GiaoVien_TroGiangId = _hocVien.GiaoVien_TroGiangId;
                hocVienCu.TenGiaoVien_TroGiang = _hocVien.TenGiaoVien_TroGiang;
                hocVienCu.TienGiaoVien_TroGiang = _hocVien.TienGiaoVien_TroGiang;
                hocVienCu.GhiChu = _hocVien.GhiChu;
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
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool UpdateKhoaLichHoc(List<XEPLICHHOC> _lstLichHoc)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in _lstLichHoc)
                    {
                        item.IsLock = true;
                        item.ModifiedDate = DateTime.Now;
                        item.ModifiedBy = GlobalSettings.UserCode;
                        item.ModifiedLog = GlobalSettings.SessionMyIP;
                        Database.SubmitChanges();
                    }
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static bool Delete(int _xeplichhocId)
        {
            try
            {
                var temp = SelectSingle(_xeplichhocId);
                Database.XEPLICHHOCs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static bool DeleteTheoLopHoc(int _lophocId)
        {
            try
            {
                var temp = SelectTheoLopHoc(_lophocId);
                Database.XEPLICHHOCs.DeleteAllOnSubmit(temp);
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
