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

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public struct BangDiemTrungBinh
    {
        public int HocVienId { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public decimal? DiemTrungBinh { get; set; }
    }

    public static class BangDiemLogic
    {
        public static BangDiemFullDTO SelectDetail(int _hocvienId, int _lophocId)
        {
            return (from p in Database.BANGDIEMs
                    where p.LopHocId == _lophocId && p.HocVienId == _hocvienId
                    select new BangDiemFullDTO()
                    {
                        BangDiemId = p.BangDiemId,
                        HocVienId = p.HocVienId,
                        TenHocVien = p.HOCVIEN.TenHocVien,
                        LopHocId = p.LopHocId,
                        TenLop = p.LOPHOC.TenLopHoc,
                        PhieuGhiDanhId = p.PhieuGhiDanhId,
                        TenKhoaHoc = p.LOPHOC.KHOAHOC.TenKhoaHoc,
                        NgayBatDau = p.LOPHOC.NgayBatDau,
                        NgayKetThuc = p.LOPHOC.NgayKetThuc,
                        SiSo = p.LOPHOC.SiSo,
                        DangMo = p.LOPHOC.DangMo,
                        DiemTrungBinh = p.DiemTrungBinh ?? 0,
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

        public static BANGDIEM Select(int _hocvienId, int _lophocId)
        {
            return (from p in Database.BANGDIEMs
                    where p.LopHocId == _lophocId && p.HocVienId == _hocvienId
                    select p).Single();
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
                Common.Logging.LogSystem.Error(ex);
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
                Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<XepLopDTO> SelectDSHV_Lop(int _lophocId)
        {
            try
            {
                var querry = (from p in Database.BANGDIEMs
                              where (p.LopHocId == _lophocId)
                              select new XepLopDTO()
                              {
                                  HocVienId = p.HocVienId,
                                  MaHocVien = p.HOCVIEN.MaHocVien,
                                  TenHocVien = p.HOCVIEN.TenHocVien,
                                  PhieuGhiDanhId = p.PhieuGhiDanhId,
                                  MaPhieuGhiDanh = p.PHIEUGHIDANH.MaPhieuGhiDanh,
                                  NgayGhiDanh = p.PHIEUGHIDANH.NgayGhiDanh,
                                  NgaySinh = p.HOCVIEN.NgaySinh,
                                  GioiTinh = p.HOCVIEN.GioiTinh,
                                  DiaChi = p.HOCVIEN.DiaChi,
                                  KhoaHocId = p.KhoaHocId,
                                  MaKhoaHoc = p.KHOAHOC.MaKhoaHoc,
                                  TenKhoaHoc = p.KHOAHOC.TenKhoaHoc,
                              });
                return querry.ToList();
            }
            catch (Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static object SelectDSLop(int _hocvienId, DateTime? tuNgay = null, DateTime? denNgay = null, int _khoahocId = 0)
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

        public static decimal TongNoCacLop(int _hocvienId)
        {
            var f = from p in Database.BANGDIEMs
                    where p.HocVienId == _hocvienId
                    select p;

            decimal result = 0;
            foreach (var i in f)
                result += (decimal)i.PHIEUGHIDANH.ConNo;

            return result;
        }

        public static IQueryable<BangDiemTrungBinh> SelectBangDiemLop(int _lophocId)
        {
            return (from p in Database.BANGDIEMs
                    where p.LopHocId == _lophocId
                    select new BangDiemTrungBinh()
                    {
                        HocVienId = p.HocVienId,
                        MaHocVien = p.HOCVIEN.MaHocVien,
                        TenHocVien = p.HOCVIEN.TenHocVien,
                        DiemTrungBinh = p.DiemTrungBinh,
                    });
        }

        public static void Insert(BANGDIEM _bangdiem)
        {
            try
            {
                _bangdiem.CreatedDate = DateTime.Now;
                _bangdiem.CreatedBy = GlobalSettings.UserCode;
                _bangdiem.CreatedLog = GlobalSettings.SessionMyIP;
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
                    Database.BANGDIEMCHITIETs.InsertOnSubmit(_chitiet);
                    Database.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
        }

        public static void Update(BANGDIEM b)
        {
            var temp = Select(b.HocVienId, b.LopHocId);

            temp.DiemTrungBinh = b.DiemTrungBinh;

            Database.SubmitChanges();
        }

        public static object DanhSachNoHocPhi(int _hocvienId = 0, string TenHocVien = null, string gioiTinh = null, decimal? _from = null, decimal? _to = null)
        {
            return (from p in Database.BANGDIEMs
                    where p.PHIEUGHIDANH.ConNo > 0 &&
                          (_hocvienId == 0 ? true : p.HocVienId == _hocvienId) &&
                          (TenHocVien == null ? true : p.HOCVIEN.TenHocVien.Contains(TenHocVien)) &&
                          (gioiTinh == null ? true : p.HOCVIEN.GioiTinh == gioiTinh) &&
                          (_from == null || _to == null ? true : p.PHIEUGHIDANH.ConNo >= _from && p.PHIEUGHIDANH.ConNo <= _to)
                    select new
                    {
                        HocVienId = p.HocVienId,
                        TenHocVien = p.HOCVIEN.TenHocVien,
                        GioiTinhHocVien = p.HOCVIEN.GioiTinh,
                        LopHocId = p.LopHocId,
                        TenLopHoc = p.LOPHOC.TenLopHoc,
                        ConNo = p.PHIEUGHIDANH.ConNo,
                        PhieuGhiDanhId = p.PhieuGhiDanhId
                    }).ToList();
        }
        public static void UpdateFull(BangDiemFullDTO _bdct)
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
        }

        //public static void InsertFull(BangDiemFull _bangdiemfull)
        //{
        //    try
        //    {
        //        BANGDIEM _bangdiem = new BANGDIEM();
        //        _bangdiem.MaHocVien = _bangdiemfull.MaHocVien;
        //        _bangdiem.MaLop = _bangdiemfull.MaLop;
        //        _bangdiem.MaPhieu = _bangdiemfull.MaPhieu;
        //        _bangdiem.CreatedDate = DateTime.Now;
        //        _bangdiem.CreatedBy = GlobalSettings.UserCode;
        //        _bangdiem.MaKhoaHoc = _bangdiemfull.MaKhoaHoc;
        //        _bangdiem.TrangThai = 0; //=0: xep lop; =1: dang hoc; =99:ket thuc
        //        Database.BANGDIEMs.InsertOnSubmit(_bangdiem);
        //        Database.SubmitChanges();

        //        foreach (var item in _bangdiemfull.BangDiemChiTiets)
        //        {
        //            BANGDIEMCHITIET _chitiet = new BANGDIEMCHITIET();

        //        }

        //    }
        //    catch (Exception)
        //    {
        //    }       
        //}

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
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
