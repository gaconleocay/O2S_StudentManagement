// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "BangDiem.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using System;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using System.Transactions;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class BangDiemLogic
    {
        public static BangDiemFullDTO SelectDetail(int _hocvienId, int _lophocId)
        {
            try
            {
                return (from p in Database.BANGDIEMs
                        where p.LopHocId == _lophocId && p.HocVienId == _hocvienId
                        select new BangDiemFullDTO()
                        {
                            BangDiemId = p.BangDiemId,
                            HocVienId = p.HocVienId,
                            MaHocVien = p.HOCVIEN.MaHocVien,
                            TenHocVien = p.HOCVIEN.TenHocVien,
                            NgaySinh = p.HOCVIEN.NgaySinh,
                            GioiTinh = p.HOCVIEN.GioiTinh,
                            PhieuGhiDanhId = p.PhieuGhiDanhId,
                            MaPhieuGhiDanh = p.PHIEUGHIDANH.MaPhieuGhiDanh,
                            NgayGhiDanh = p.PHIEUGHIDANH.NgayGhiDanh,
                            LopHocId = p.LopHocId,
                            TenLopHoc = p.LOPHOC.TenLopHoc,
                            KhoaHocId = p.KhoaHocId,
                            TenKhoaHoc = p.KHOAHOC.TenKhoaHoc,
                            NgayBatDau = p.LOPHOC.NgayBatDau,
                            NgayKetThuc = p.LOPHOC.NgayKetThuc,
                            SiSo = p.LOPHOC.SiSo,
                            DangMo = p.LOPHOC.IsLock,
                            DiemTrungBinh = p.DiemTrungBinh,
                            TrangThai = p.TrangThai,
                            TrangThai_Ten = p.TrangThai == 0 ? "xếp lớp" : p.TrangThai == 1 ? "đang học" : p.TrangThai == 3 ? "có điểm" : p.TrangThai == 99 ? "kết thúc" : "",
                            BangDiemChiTiets =
                                (from ct in Database.BANGDIEMCHITIETs
                                 where ct.BangDiemId == p.BangDiemId
                                 select new BangDiemChiTietDTO()
                                 {
                                     BangDiemChiTietId = ct.BangDiemChiTietId,
                                     BangDiemId = ct.BangDiemId,
                                     MonHocId = ct.MonHocId,
                                     MaMonHoc = ct.MONHOC.MaMonHoc,
                                     TenMonHoc = ct.TenMonHoc,
                                     Diem = ct.Diem
                                 }).ToList()
                        }).Single();
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static BANGDIEM Select(int _hocvienId, int _lophocId)
        {
            try
            {
                return (from p in Database.BANGDIEMs
                        where p.LopHocId == _lophocId && p.HocVienId == _hocvienId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<BANGDIEM> SelectTheoPhieuGhiDanh(int _phieughidanhId)
        {
            try
            {
                return (from p in Database.BANGDIEMs
                        where p.PhieuGhiDanhId == _phieughidanhId
                        select p).ToList();
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<BANGDIEM> SelectTheoLopHoc(int _lophocId)
        {
            try
            {
                return (from p in Database.BANGDIEMs
                        where p.LopHocId == _lophocId
                        select p).ToList();
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<XepLopDTO> SelectDSHV_Lop(int _lophocId)
        {
            try
            {
                var querry = (from p in Database.BANGDIEMs
                              where (p.LopHocId == _lophocId)
                              select p).AsEnumerable().Select((obj, index) => new XepLopDTO
                              {
                                  Stt = index + 1,
                                  HocVienId = obj.HocVienId,
                                  MaHocVien = obj.HOCVIEN.MaHocVien,
                                  TenHocVien = obj.HOCVIEN.TenHocVien,
                                  PhieuGhiDanhId = obj.PhieuGhiDanhId,
                                  MaPhieuGhiDanh = obj.PHIEUGHIDANH.MaPhieuGhiDanh,
                                  NgayGhiDanh = obj.PHIEUGHIDANH.NgayGhiDanh,
                                  NgaySinh = obj.HOCVIEN.NgaySinh,
                                  GioiTinh = obj.HOCVIEN.GioiTinh,
                                  DiaChi = obj.HOCVIEN.DiaChi,
                                  Sdt = obj.HOCVIEN.Sdt,
                                  Email = obj.HOCVIEN.Email,
                                  KhoaHocId = obj.KhoaHocId,
                                  MaKhoaHoc = obj.KHOAHOC.MaKhoaHoc,
                                  TenKhoaHoc = obj.KHOAHOC.TenKhoaHoc,
                                  LopHocId = obj.LopHocId,
                                  MaLopHoc = obj.LOPHOC.MaLopHoc,
                                  TenLopHoc = obj.LOPHOC.TenLopHoc,
                              });
                return querry.ToList();
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static object SelectDSLop(int _hocvienId, DateTime? tuNgay = null, DateTime? denNgay = null, int _khoahocId = 0)
        {
            try
            {
                return (from p in Database.BANGDIEMs
                        where p.HocVienId == _hocvienId &&
                            (tuNgay == null ? true : p.LOPHOC.NgayBatDau >= tuNgay) &&
                            (denNgay == null ? true : p.LOPHOC.NgayKetThuc <= denNgay) &&
                            (_khoahocId == 0 ? true : p.LOPHOC.KhoaHocId == _khoahocId)
                        select new
                        {
                            LopHocId = p.LopHocId,
                            TenLopHoc = p.LOPHOC.TenLopHoc,
                        }).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static decimal TongNoCacLop(int _hocvienId)
        {
            try
            {
                var f = from p in Database.BANGDIEMs
                        where p.HocVienId == _hocvienId
                        select p;

                decimal result = 0;
                foreach (var i in f)
                    result += (decimal)i.PHIEUGHIDANH.ConNo;

                return result;
            }
            catch (System.Exception ex)
            {
                return 0;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<BangDiemFullDTO> SelectTheoDoiBangDiemLop(int _lophocId)
        {
            try
            {
                return (from p in Database.BANGDIEMs
                        where p.LopHocId == _lophocId
                        select new BangDiemFullDTO()
                        {
                            BangDiemId = p.BangDiemId,
                            HocVienId = p.HocVienId,
                            MaHocVien = p.HOCVIEN.MaHocVien,
                            TenHocVien = p.HOCVIEN.TenHocVien,
                            NgaySinh = p.HOCVIEN.NgaySinh,
                            GioiTinh = p.HOCVIEN.GioiTinh,
                            PhieuGhiDanhId = p.PhieuGhiDanhId,
                            MaPhieuGhiDanh = p.PHIEUGHIDANH.MaPhieuGhiDanh,
                            NgayGhiDanh = p.PHIEUGHIDANH.NgayGhiDanh,
                            LopHocId = p.LopHocId,
                            TenLopHoc = p.LOPHOC.TenLopHoc,
                            KhoaHocId = p.KhoaHocId,
                            TenKhoaHoc = p.KHOAHOC.TenKhoaHoc,
                            NgayBatDau = p.LOPHOC.NgayBatDau,
                            NgayKetThuc = p.LOPHOC.NgayKetThuc,
                            SiSo = p.LOPHOC.SiSo,
                            DangMo = p.LOPHOC.IsLock,
                            DiemTrungBinh = p.DiemTrungBinh,
                            TrangThai = p.TrangThai,
                            TrangThai_Ten = p.TrangThai == 0 ? "xếp lớp" : p.TrangThai == 1 ? "đang học" : p.TrangThai == 3 ? "có điểm" : p.TrangThai == 99 ? "kết thúc" : "",
                            BangDiemChiTiets =
                                (from ct in Database.BANGDIEMCHITIETs
                                 where ct.BangDiemId == p.BangDiemId
                                 select new BangDiemChiTietDTO()
                                 {
                                     BangDiemChiTietId = ct.BangDiemChiTietId,
                                     BangDiemId = ct.BangDiemId,
                                     MonHocId = ct.MonHocId,
                                     MaMonHoc = ct.MONHOC.MaMonHoc,
                                     TenMonHoc = ct.TenMonHoc,
                                     Diem = ct.Diem
                                 }).ToList()
                        }).ToList();
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void Insert(BANGDIEM _bangdiem)
        {
            try
            {
                _bangdiem.CreatedDate = DateTime.Now;
                _bangdiem.CreatedBy = GlobalSettings.UserCode;
                _bangdiem.CreatedLog = GlobalSettings.SessionMyIP;
                _bangdiem.IsRemove = 0;
                Database.BANGDIEMs.InsertOnSubmit(_bangdiem);
                Database.SubmitChanges();
                int _id = _bangdiem.BangDiemId;

                //Insert Bang diem chi tiet
                List<KHOAHOC_MONHOC> _khmh = KhoaHocMonHocLogic.SelectTheoKhoaHoc(_bangdiem.KhoaHocId);
                foreach (var item in _khmh)
                {
                    BANGDIEMCHITIET _chitiet = new BANGDIEMCHITIET();
                    _chitiet.BangDiemId = _id;
                    _chitiet.MonHocId = item.MonHocId ?? 0;
                    _chitiet.TenMonHoc = item.TenMonHoc;
                    _chitiet.IsRemove = 0;
                    //_chitiet.CreatedDate = DateTime.Now;
                    //_chitiet.CreatedBy = GlobalSettings.UserCode;
                    //_chitiet.CreatedLog = GlobalSettings.SessionMyIP;
                    Database.BANGDIEMCHITIETs.InsertOnSubmit(_chitiet);
                    Database.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void Update(BANGDIEM b)
        {
            var temp = Select(b.HocVienId, b.LopHocId);

            temp.DiemTrungBinh = b.DiemTrungBinh;

            Database.SubmitChanges();
        }
        public static bool UpdateFull(BangDiemFullDTO _bdct)
        {
            bool result = false;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    decimal _tongdiem = 0;
                    foreach (var item in _bdct.BangDiemChiTiets)
                    {
                        BANGDIEMCHITIET _chitiet = new BANGDIEMCHITIET();
                        _chitiet.BangDiemChiTietId = (int)item.BangDiemChiTietId;
                        _chitiet.BangDiemId = (int)item.BangDiemId;
                        _chitiet.MonHocId = item.MonHocId;
                        _chitiet.TenMonHoc = item.TenMonHoc;
                        _chitiet.Diem = item.Diem;
                        BangDiemChiTietLogic.Update(_chitiet);

                        _tongdiem += item.Diem ?? 0;
                    }
                    //Cap nhat BANGDIEM + diem trung binh
                    var _bangdiemtmp = Select(_bdct.HocVienId ?? 0, _bdct.LopHocId ?? 0);
                    _bangdiemtmp.DiemTrungBinh = Math.Round(_tongdiem / _bdct.BangDiemChiTiets.Count, 2);
                    _bangdiemtmp.TrangThai = 3;
                    Database.SubmitChanges();
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return result;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        public static bool DeleteList(List<BANGDIEM> _lstbangdiem)
        {
            try
            {
                foreach (var item in _lstbangdiem)
                {
                    List<BANGDIEMCHITIET> _lstBDChiTiet = (from p in Database.BANGDIEMCHITIETs
                                                           where p.BangDiemId == item.BangDiemId
                                                           select p).ToList();
                    Database.BANGDIEMCHITIETs.DeleteAllOnSubmit(_lstBDChiTiet);
                }
                Database.BANGDIEMs.DeleteAllOnSubmit(_lstbangdiem);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<BANGDIEM> SelectFilter(BangDiemFilter _filter)
        {
            try
            {
                var query = (from p in Database.BANGDIEMs
                             where p.IsRemove != 1
                             select p).ToList();
                if (_filter.HocVienId != null && _filter.HocVienId != 0)
                {
                    query = query.Where(o => o.HocVienId == _filter.HocVienId).ToList();
                }
                if (_filter.KhoaHocId != null && _filter.KhoaHocId != 0)
                {
                    query = query.Where(o => o.KhoaHocId == _filter.KhoaHocId).ToList();
                }
                if (_filter.LopHocId != null && _filter.LopHocId != 0)
                {
                    query = query.Where(o => o.LopHocId == _filter.LopHocId).ToList();
                }
                if (_filter.PhieuGhiDanhId != null && _filter.PhieuGhiDanhId != 0)
                {
                    query = query.Where(o => o.PhieuGhiDanhId == _filter.PhieuGhiDanhId).ToList();
                }
                return query;
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

    }
}
