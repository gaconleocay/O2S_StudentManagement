// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "LopHoc.cs"
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
    public static class LopHocLogic
    {
        public static LOPHOC SelectSingle(int _LopHocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.LOPHOCs
                        where p.LopHocId == _LopHocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<LopHoc_PlusDTO> Select(LopHocFilter _filter)
        {
            try
            {
                //List<LopHoc_PlusDTO> _result = null;
                var query = (from p in GlobalSettings.Database.LOPHOCs
                             select p).AsEnumerable().Select((obj, index) => new LopHoc_PlusDTO
                             {
                                 Stt = index + 1,
                                 LopHocId = obj.LopHocId,
                                 MaLopHoc = obj.MaLopHoc,
                                 TenLopHoc = obj.TenLopHoc,
                                 NgayBatDau = obj.NgayBatDau,
                                 NgayKetThuc = obj.NgayKetThuc,
                                 SiSoToiDa = obj.SiSoToiDa,
                                 SiSo = obj.SiSo,
                                 KhoaHocId = obj.KhoaHocId,
                                 TenKhoaHoc = obj.KHOAHOC.TenKhoaHoc,
                                 CoSoId = obj.CoSoId,
                                 TenCoSoTrungTam = obj.COSOTRUNGTAM.TenCoSo,
                                 IsLock = obj.IsLock,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,

                             });
                if (_filter.LopHocId != null && _filter.LopHocId != 0)
                {
                    query = query.Where(o => o.LopHocId == _filter.LopHocId).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.KhoaHocId != null && _filter.KhoaHocId != 0)
                {
                    query = query.Where(o => o.KhoaHocId == _filter.KhoaHocId).ToList();
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
        public static List<LopHoc_PlusDTO> SelectOption1(LopHocFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.LOPHOCs
                             select p).AsEnumerable().Select((obj, index) => new LopHoc_PlusDTO
                             {
                                 Stt = index + 1,
                                 LopHocId = obj.LopHocId,
                                 MaLopHoc = obj.MaLopHoc,
                                 TenLopHoc = obj.TenLopHoc,
                                 NgayBatDau = obj.NgayBatDau,
                                 NgayKetThuc = obj.NgayKetThuc,
                                 SiSoToiDa = obj.SiSoToiDa,
                                 SiSo = obj.SiSo,
                                 KhoaHocId = obj.KhoaHocId,
                                 TenKhoaHoc = obj.KHOAHOC.TenKhoaHoc,
                                 CoSoId = obj.CoSoId,
                                 TenCoSoTrungTam = obj.COSOTRUNGTAM.TenCoSo,
                                 TongHocPhi = (from dt in Database.DOTHOCs
                                               where dt.LopHocId == obj.LopHocId
                                               select dt).Sum(o => o.HocPhi),
                                 TongSoBuoiHoc = (from dt in Database.DOTHOCs
                                                  where dt.LopHocId == obj.LopHocId
                                                  select dt).Sum(o => o.SoBuoiHoc),
                                 SoDotHoc = (from dt in Database.DOTHOCs
                                             where dt.LopHocId == obj.LopHocId
                                             select dt).Count(),
                                 IsLock = obj.IsLock,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,

                             });
                if (_filter.LopHocId != null && _filter.LopHocId != 0)
                {
                    query = query.Where(o => o.LopHocId == _filter.LopHocId).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.KhoaHocId != null && _filter.KhoaHocId != 0)
                {
                    query = query.Where(o => o.KhoaHocId == _filter.KhoaHocId).ToList();
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

        public static List<LopHoc_PlusDTO> SelectGroupTheoLopHoc(LopHocFilter _filter)
        {
            try
            {
                var query = (from obj in GlobalSettings.Database.XEPLICHHOCs
                             where (obj.KhoaHocId == _filter.KhoaHocId && (obj.GiaoVien_ChinhId == _filter.GiangVienId || obj.GiaoVien_TroGiangId == _filter.GiangVienId) && obj.IsLock == true)
                             select new LopHoc_PlusDTO
                             {
                                 LopHocId = obj.LopHocId ?? 0,
                                 MaLopHoc = obj.LOPHOC.MaLopHoc,
                                 TenLopHoc = obj.TenLopHoc,
                             }).ToList().GroupBy(o => o.LopHocId).Select(n => n.First()).ToList();
                return query;
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(LOPHOC _khoahoc, ref int _khoaHocId)
        {
            try
            {
                _khoahoc.CreatedDate = DateTime.Now;
                _khoahoc.CreatedBy = GlobalSettings.UserCode;
                _khoahoc.CreatedLog = GlobalSettings.SessionMyIP;
                _khoahoc.IsRemove = 0;
                Database.LOPHOCs.InsertOnSubmit(_khoahoc);
                Database.SubmitChanges();
                _khoaHocId = _khoahoc.LopHocId;
                _khoahoc.MaLopHoc = string.Format("{0}{1:D5}", "LH", _khoaHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(LOPHOC _lopHoc)
        {
            try
            {
                var hocVienCu = SelectSingle(_lopHoc.LopHocId);

                hocVienCu.TenLopHoc = _lopHoc.TenLopHoc;
                hocVienCu.NgayBatDau = _lopHoc.NgayBatDau;
                hocVienCu.NgayKetThuc = _lopHoc.NgayKetThuc;
                hocVienCu.SiSoToiDa = _lopHoc.SiSoToiDa;
                hocVienCu.SiSo = _lopHoc.SiSo;
                hocVienCu.KhoaHocId = _lopHoc.KhoaHocId;
                hocVienCu.IsLock = _lopHoc.IsLock;
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

        public static bool Delete(int _lopHoc)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Xoa dot hoc
                    List<DOTHOC> _lstdothoc = DotHocLogic.SelectTheoLopHoc(_lopHoc);
                    if (_lstdothoc != null && _lstdothoc.Count > 0)
                    {
                        Database.DOTHOCs.DeleteAllOnSubmit(_lstdothoc);
                        Database.SubmitChanges();
                    }
                    var temp = SelectSingle(_lopHoc);
                    Database.LOPHOCs.DeleteOnSubmit(temp);
                    Database.SubmitChanges();
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

        public static object DanhSachLopTrong(int _khoahocId)
        {
            try
            {
                return (from p in Database.LOPHOCs
                        where p.KhoaHocId == _khoahocId &&
                                p.SiSo < p.SiSoToiDa
                        select new
                        {
                            LopHocId = p.LopHocId,
                            MaLopHoc = p.MaLopHoc,
                            TenLopHoc = p.TenLopHoc
                        }).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<LOPHOC> SelectTheoKhoaHoc(int _khoahocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.LOPHOCs
                        where p.KhoaHocId == _khoahocId
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

    }
}
