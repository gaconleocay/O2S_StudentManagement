// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "PhieuThu.cs"
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
    public static class PhieuThuLogic
    {
        public static PHIEUTHU SelectSingle(int _phieuthuId)
        {
            try
            {
                return (from p in GlobalSettings.Database.PHIEUTHUs
                        where p.PhieuThuId == _phieuthuId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<PhieuThu_PlusDTO> Select(PhieuThuFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.PHIEUTHUs
                                 //where p.HocVienId==_filter.HocVienId
                             select p).AsEnumerable().Select((obj, index) => new PhieuThu_PlusDTO
                             {
                                 Stt = index + 1,
                                 PhieuThuId = obj.PhieuThuId,
                                 MaPhieuThu = obj.MaPhieuThu,
                                 SoThuId = obj.SoThuId,
                                 PhieuGhiDanhId = obj.PhieuGhiDanhId,
                                 HocVienId = obj.HocVienId,
                                 TenHocVien = obj.HOCVIEN.TenHocVien,
                                 LoaiPhieuThuId = obj.LoaiPhieuThuId,
                                 SoTien = obj.SoTien,
                                 ThoiGianThu = obj.ThoiGianThu,
                                 GhiChu = obj.GhiChu,
                                 IsRemove = obj.IsRemove ?? 0,
                                 LyDoHuy = obj.LyDoHuy,
                                 NguoiHuy = obj.NguoiHuy,
                                 ThoiGianHuy = obj.ThoiGianHuy,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,

                             });
                if (_filter.PhieuThuId != null && _filter.PhieuThuId != 0)
                {
                    query = query.Where(o => o.PhieuThuId == _filter.PhieuThuId).ToList();
                }
                if (_filter.HocVienId != null && _filter.HocVienId != 0)
                {
                    query = query.Where(o => o.HocVienId == _filter.HocVienId).ToList();
                }
                if (_filter.PhieuGhiDanhId != null && _filter.PhieuGhiDanhId != 0)
                {
                    query = query.Where(o => o.PhieuGhiDanhId == _filter.PhieuGhiDanhId).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<PHIEUTHU> SelectTheoPhieuGhiDanh(int _PhieuGhiDanhId)
        {
            return (from p in Database.PHIEUTHUs
                    where p.PhieuGhiDanhId == _PhieuGhiDanhId
                    select p).ToList();
        }
        public static bool Insert(PHIEUTHU _phieuthu, ref int _phieuthuId)
        {
            try
            {
                _phieuthu.CreatedDate = DateTime.Now;
                _phieuthu.CreatedBy = GlobalSettings.UserCode;
                _phieuthu.CreatedLog = GlobalSettings.SessionMyIP;
                _phieuthu.IsRemove = 0;
                Database.PHIEUTHUs.InsertOnSubmit(_phieuthu);
                Database.SubmitChanges();
                _phieuthuId = _phieuthu.PhieuThuId;
                _phieuthu.MaPhieuThu = string.Format("{0}{1:D5}", "PT", _phieuthuId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(PHIEUTHU _phieuthu)
        {
            try
            {
                var phieuthuCu = SelectSingle(_phieuthu.PhieuThuId);

                phieuthuCu.IsRemove = _phieuthu.IsRemove;
                phieuthuCu.LyDoHuy = _phieuthu.LyDoHuy;
                phieuthuCu.NguoiHuy = _phieuthu.NguoiHuy;
                phieuthuCu.ThoiGianHuy = _phieuthu.ThoiGianHuy;
                phieuthuCu.ModifiedDate = DateTime.Now;
                phieuthuCu.ModifiedBy = GlobalSettings.UserCode;
                phieuthuCu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _phieuthuId)
        {
            try
            {
                var temp = SelectSingle(_phieuthuId);
                Database.PHIEUTHUs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static bool DeleteTheoPhieuGhiDanh(int _PhieuGhiDanhId)
        {
            try
            {
                List<PHIEUTHU> _lstPhieuThu = SelectTheoPhieuGhiDanh(_PhieuGhiDanhId);
                Database.PHIEUTHUs.DeleteAllOnSubmit(_lstPhieuThu);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool HuyPhieuThuTien(PHIEUTHU _phieuthu)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var phieuthuCu = SelectSingle(_phieuthu.PhieuThuId);
                    phieuthuCu.IsRemove = _phieuthu.IsRemove;
                    phieuthuCu.LyDoHuy = _phieuthu.LyDoHuy;
                    phieuthuCu.NguoiHuy = _phieuthu.NguoiHuy;
                    phieuthuCu.ThoiGianHuy = _phieuthu.ThoiGianHuy;
                    phieuthuCu.ModifiedDate = DateTime.Now;
                    phieuthuCu.ModifiedBy = GlobalSettings.UserCode;
                    phieuthuCu.ModifiedLog = GlobalSettings.SessionMyIP;
                    Database.SubmitChanges();
                    //update PHIEUGHIDANH
                    PHIEUGHIDANH _pgdanh = PhieuGhiDanhLogic.SelectSingle(_phieuthu.PhieuGhiDanhId ?? 0);
                    _pgdanh.DaDong = _pgdanh.DaDong - _phieuthu.SoTien;
                    _pgdanh.ConNo = _pgdanh.ConNo + _phieuthu.SoTien;
                    _pgdanh.ModifiedDate = DateTime.Now;
                    _pgdanh.ModifiedBy = GlobalSettings.UserCode;
                    _pgdanh.ModifiedLog = GlobalSettings.SessionMyIP;
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static List<BaoCaoThuTien_ChiTietDTO> SelectBaoCaoThuTienChiTiet(PhieuThuFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.PHIEUTHUs
                             where (p.ThoiGianThu >= _filter.ThoiGianThu_Tu && p.ThoiGianThu <= _filter.ThoiGianThu_Den) && p.HOCVIEN.CoSoId == _filter.CoSoId
                             select p).AsEnumerable().Select((obj, index) => new BaoCaoThuTien_ChiTietDTO
                             {
                                 Stt = index + 1,
                                 MaPhieuThu = obj.MaPhieuThu,
                                 ThoiGianThu = obj.ThoiGianThu,
                                 SoTien = obj.SoTien,
                                 TenNguoiThu = obj.CreatedBy,
                                 MaPhieuGhiDanh = obj.PHIEUGHIDANH.MaPhieuGhiDanh,
                                 MaHocVien = obj.HOCVIEN.MaHocVien,
                                 TenHocVien = obj.HOCVIEN.TenHocVien,
                                 GioiTinh = obj.HOCVIEN.GioiTinh,
                                 NgaySinh = obj.HOCVIEN.NgaySinh,
                                 GhiChu = obj.GhiChu
                             });
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<BaoCaoThuTien_TongHopDTO> SelectBaoCaoThuTienTongHop(PhieuThuFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.PHIEUTHUs
                             where (p.ThoiGianThu >= _filter.ThoiGianThu_Tu && p.ThoiGianThu <= _filter.ThoiGianThu_Den) && p.HOCVIEN.CoSoId == _filter.CoSoId
                             group p by new
                             {
                                 p.ThoiGianThu,
                                 p.CreatedBy,
                             } into phieuthu
                             select new BaoCaoThuTien_TongHopDTO
                             {
                                 ThoiGianThu = phieuthu.Key.ThoiGianThu,
                                 TenNguoiThu = phieuthu.Key.CreatedBy,
                                 SoTien = phieuthu.Sum(o => o.SoTien),
                             });
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }



    }
}
