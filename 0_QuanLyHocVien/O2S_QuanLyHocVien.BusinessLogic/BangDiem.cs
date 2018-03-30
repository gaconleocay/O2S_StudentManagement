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
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public decimal? DiemTrungBinh { get; set; }
    }

    public static class BangDiem
    {
        /// <summary>
        /// Lấy chi tiết của một bảng điểm
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static BangDiemFullDTO SelectDetail(string maHV, string maLop)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaLop == maLop && p.MaHocVien == maHV
                    select new BangDiemFullDTO()
                    {
                        BangDiemId = p.BangDiemId,
                        MaHocVien = p.MaHocVien,
                        TenHocVien = p.HOCVIEN.TenHocVien,
                        MaLop = p.MaLop,
                        TenLop = p.LOPHOC.TenLop,
                        MaPhieu = p.MaPhieu,
                        TenKhoaHoc = p.LOPHOC.KHOAHOC.TenKhoaHoc,
                        NgayBD = p.LOPHOC.NgayBD,
                        NgayKT = p.LOPHOC.NgayKT,
                        SiSo = p.LOPHOC.SiSo,
                        DangMo = p.LOPHOC.DangMo,
                        DiemTrungBinh = p.DiemTrungBinh ?? 0,
                        BangDiemChiTiets =
                            (from ct in Database.BANGDIEMCHITIETs
                             where ct.BangDiemId == p.BangDiemId
                             select new BangDiemChiTietDTO()
                             {
                                 BangDiemChiTietId = ct.BangDiemChiTietId,
                                 BangDiemId = ct.BangDiemId ?? 0,
                                 MaMonHoc = ct.MaMonHoc,
                                 TenMonHoc = ct.TenMonHoc,
                                 Diem = ct.Diem
                             }).ToList()
                    }).Single();
        }

        /// <summary>
        /// Chọn một bảng điểm
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static BANGDIEM Select(string maHV, string maLop)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaLop == maLop && p.MaHocVien == maHV
                    select p).Single();
        }
        //public static BANGDIEM Select(string maHV, string maLop)
        //{
        //    return (from p in Database.BANGDIEMs
        //            where p.MaLop == maLop && p.MaHocVien == maHV
        //            select p).Single();
        //}

        /// <summary>
        /// Chọn danh sách học viên trong một lớp
        /// </summary>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static List<HOCVIEN> SelectDSHV(string maLop)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaLop == maLop
                    select p.HOCVIEN).ToList();
        }

        /// <summary>
        /// Lấy danh sách lớp của học viên
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <returns></returns>
        public static object SelectDSLop(string maHV, DateTime? tuNgay = null, DateTime? denNgay = null, string MaKhoaHoc = null)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaHocVien == maHV &&
                        (tuNgay == null ? true : p.LOPHOC.NgayBD >= tuNgay) &&
                        (denNgay == null ? true : p.LOPHOC.NgayKT <= denNgay) &&
                        (MaKhoaHoc == null ? true : p.LOPHOC.MaKhoaHoc == MaKhoaHoc)
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.LOPHOC.TenLop,
                    }).ToList();
        }

        /// <summary>
        /// Tổng nợ tất cả các lớp đã học
        /// </summary>
        /// <param name="maHV"></param>
        /// <returns></returns>
        public static decimal TongNoCacLop(string maHV)
        {
            var f = from p in Database.BANGDIEMs
                    where p.MaHocVien == maHV
                    select p;

            decimal result = 0;
            foreach (var i in f)
                result += (decimal)i.PHIEUGHIDANH.ConNo;

            return result;
        }

        /// <summary>
        /// Lấy bảng điểm trung bình của lớp
        /// </summary>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static IQueryable<BangDiemTrungBinh> SelectBangDiemLop(string maLop)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaLop == maLop
                    select new BangDiemTrungBinh()
                    {
                        MaHocVien = p.MaHocVien,
                        TenHocVien = p.HOCVIEN.TenHocVien,
                        DiemTrungBinh=p.DiemTrungBinh,
                        //DiemNghe = (int)p.DiemNghe,
                        //DiemNoi = (int)p.DiemNoi,
                        //DiemDoc = (int)p.DiemDoc,
                        //DiemViet = (int)p.DiemViet,
                        //DiemTrungBinh = (int)p.DiemNghe * (double)p.LOPHOC.KHOAHOC.HeSoNghe / 100 +
                        //                (int)p.DiemNoi * (double)p.LOPHOC.KHOAHOC.HeSoNoi / 100 +
                        //                (int)p.DiemDoc * (double)p.LOPHOC.KHOAHOC.HeSoDoc / 100 +
                        //                (int)p.DiemViet * (double)p.LOPHOC.KHOAHOC.HeSoViet / 100
                    });
        }

        /// <summary>
        /// Thêm một bảng điểm
        /// </summary>
        /// <param name="bd">Bảng điểm cần thêm</param>
        public static void Insert(BANGDIEM _bangdiem)
        {
            try
            {
                Database.BANGDIEMs.InsertOnSubmit(_bangdiem);
                Database.SubmitChanges();
                int _id = _bangdiem.BangDiemId;

                //Insert Bang diem chi tiet
                List<KHOAHOC_MONHOC> _khmh = KhoaHocMonHoc.SelectTheoKhoaHoc(_bangdiem.MaKhoaHoc);
                foreach (var item in _khmh)
                {
                    BANGDIEMCHITIET _chitiet = new BANGDIEMCHITIET();
                    _chitiet.BangDiemId = _id;
                    _chitiet.MaMonHoc = item.MaMonHoc;
                    _chitiet.TenMonHoc = item.TenMonHoc;
                    Database.BANGDIEMCHITIETs.InsertOnSubmit(_chitiet);
                    Database.SubmitChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Cập nhật bảng điểm
        /// </summary>
        /// <param name="b"></param>
        public static void Update(BANGDIEM b)
        {
            var temp = Select(b.MaHocVien, b.MaLop);

            temp.DiemTrungBinh = b.DiemTrungBinh;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Tìm danh sách học viên nợ học phí
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="TenHocVien">Tên học viên</param>
        /// <param name="gioiTinh">Giới tính</param>
        /// <param name="_from">Số tiền từ bao nhiêu</param>
        /// <param name="to">Số tiền đến bao nhiêu</param>
        /// <returns></returns>
        public static object DanhSachNoHocPhi(string maHV = null, string TenHocVien = null, string gioiTinh = null, decimal? _from = null, decimal? _to = null)
        {
            return (from p in Database.BANGDIEMs
                    where p.PHIEUGHIDANH.ConNo > 0 &&
                          (maHV == null ? true : p.MaHocVien.Contains(maHV)) &&
                          (TenHocVien == null ? true : p.HOCVIEN.TenHocVien.Contains(TenHocVien)) &&
                          (gioiTinh == null ? true : p.HOCVIEN.GioiTinhHocVien == gioiTinh) &&
                          (_from == null || _to == null ? true : p.PHIEUGHIDANH.ConNo >= _from && p.PHIEUGHIDANH.ConNo <= _to)
                    select new
                    {
                        MaHocVien = p.MaHocVien,
                        TenHocVien = p.HOCVIEN.TenHocVien,
                        GioiTinhHocVien = p.HOCVIEN.GioiTinhHocVien,
                        MaLop = p.MaLop,
                        ConNo = p.PHIEUGHIDANH.ConNo,
                        MaPhieu = p.MaPhieu
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
                _chitiet.MaMonHoc = item.MaMonHoc;
                _chitiet.TenMonHoc = item.TenMonHoc;
                _chitiet.Diem = item.Diem;
                BangDiemChiTiet.Update(_chitiet);

                _tongdiem += item.Diem ?? 0;
            }
            //Cap nhat BANGDIEM + diem trung binh
            var _bangdiemtmp = Select(_bdct.MaHocVien, _bdct.MaLop);
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


    }
}
