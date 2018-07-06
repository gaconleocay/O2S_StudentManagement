// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "DotHoc.cs"
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
    public static class DotHocLogic
    {
        public static DOTHOC SelectSingle(int _DotHocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.DOTHOCs
                        where p.DotHocId == _DotHocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<DOTHOC> SelectTheoLopHoc(int _lophocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.DOTHOCs
                        where p.LopHocId == _lophocId
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<DotHoc_PlusDTO> Select(DotHocFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.DOTHOCs
                             select p).AsEnumerable().Select((obj, index) => new DotHoc_PlusDTO
                             {
                                 Stt = index + 1,
                                 DotHocId = obj.DotHocId,
                                 MaDotHoc = obj.MaDotHoc,
                                 CoSoId = obj.CoSoId,
                                 TenCoSoTrungTam = obj.COSOTRUNGTAM.TenCoSo,
                                 LopHocId = obj.LopHocId,
                                 TenLopHoc = obj.LOPHOC.TenLopHoc,
                                 TenDotHoc = obj.TenDotHoc,
                                 HocPhi = obj.HocPhi,
                                 SoBuoiHoc = obj.SoBuoiHoc,
                                 IsLock = obj.IsLock,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,
                             });
                if (_filter.DotHocId != null && _filter.DotHocId != 0)
                {
                    query = query.Where(o => o.DotHocId == _filter.DotHocId).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.LopHocId != null && _filter.LopHocId != 0)
                {
                    query = query.Where(o => o.LopHocId == _filter.LopHocId).ToList();
                }
                if (_filter.IsLock != null)
                {
                    query = query.Where(o => o.IsLock == _filter.IsLock).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        //public static List<DotHoc_PlusDTO> SelectGroupTheoDotHoc(DotHocFilter _filter)
        //{
        //    try
        //    {
        //        var query = (from obj in GlobalSettings.Database.XEPLICHHOCs
        //                     where (obj.KhoaHocId == _filter.KhoaHocId && (obj.GiaoVien_ChinhId == _filter.GiangVienId || obj.GiaoVien_TroGiangId == _filter.GiangVienId) && obj.IsLock == true)
        //                     select new DotHoc_PlusDTO
        //                     {
        //                         DotHocId = obj.DotHocId ?? 0,
        //                         MaDotHoc = obj.DOTHOC.MaDotHoc,
        //                         TenDotHoc = obj.TenDotHoc,
        //                     }).ToList().GroupBy(o => o.DotHocId).Select(n => n.First()).ToList();
        //        return query;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return null;
        //        O2S_Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        public static List<DOTHOC> SelectDotHocChucDongTien(int _lophocId, int _phieuGDId)
        {
            try
            {
                var querry = (from p in Database.DOTHOCs
                              where p.LopHocId == _lophocId && !(from od in Database.HOCPHIHOCVIENs
                                                                 select od.DmDichVuId).Contains(p.DotHocId)
                              select p);

                return querry.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(DOTHOC _dothoc)
        {
            try
            {
                _dothoc.CreatedDate = DateTime.Now;
                _dothoc.CreatedBy = GlobalSettings.UserCode;
                _dothoc.CreatedLog = GlobalSettings.SessionMyIP;
                _dothoc.IsRemove = 0;
                Database.DOTHOCs.InsertOnSubmit(_dothoc);
                Database.SubmitChanges();
                //_dotHocId = _dothoc.DotHocId;
                _dothoc.MaDotHoc = string.Format("{0}{1:D5}", "DH", _dothoc.DotHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(DOTHOC _dotHoc)
        {
            try
            {
                var hocVienCu = SelectSingle(_dotHoc.DotHocId);

                hocVienCu.TenDotHoc = _dotHoc.TenDotHoc;
                hocVienCu.HocPhi = _dotHoc.HocPhi;
                hocVienCu.SoBuoiHoc = _dotHoc.SoBuoiHoc;
                hocVienCu.IsRemove = _dotHoc.IsRemove;
                hocVienCu.IsLock = _dotHoc.IsLock;
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

        public static bool Delete(int _dotHoc)
        {
            try
            {
                var temp = SelectSingle(_dotHoc);
                Database.DOTHOCs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        //public static object DanhSachLopTrong(int _khoahocId)
        //{
        //    try
        //    {
        //        return (from p in Database.DOTHOCs
        //                where p.KhoaHocId == _khoahocId &&
        //                        p.SiSo < p.SiSoToiDa
        //                select new
        //                {
        //                    DotHocId = p.DotHocId,
        //                    MaDotHoc = p.MaDotHoc,
        //                    TenDotHoc = p.TenDotHoc
        //                }).ToList();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return null;
        //        O2S_Common.Logging.LogSystem.Error(ex);
        //    }
        //}

        //public static List<DOTHOC> SelectTheoKhoaHoc(int _khoahocId)
        //{
        //    try
        //    {
        //        return (from p in GlobalSettings.Database.DOTHOCs
        //                where p.KhoaHocId == _khoahocId
        //                select p).ToList();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return null;
        //        O2S_Common.Logging.LogSystem.Error(ex);
        //    }
        //}

    }
}
