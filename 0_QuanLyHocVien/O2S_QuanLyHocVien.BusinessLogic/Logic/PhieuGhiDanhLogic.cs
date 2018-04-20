// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "PhieuGhiDanh.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System.Transactions;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public struct BaoCaoHocVienNo
    {
        public int? HocVienId { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public string GioiTinh { get; set; }
        public string TenKhoaHoc { get; set; }
        public decimal? ConNo { get; set; }
    }
    public struct BaoCaoHocVienGhiDanh
    {
        public int HocVienId { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgayGhiDanh { get; set; }
        public string TenKhoaHoc { get; set; }
    }
    public static class PhieuGhiDanhLogic
    {
        public static object SelectAll()
        {
            return (from p in Database.PHIEUGHIDANHs
                    join hv in Database.HOCVIENs on p.HocVienId equals hv.HocVienId
                    where p.IsRemove!=1
                    select new
                    {
                        PhieuGhiDanhId = p.PhieuGhiDanhId,
                        HocVienId = p.HocVienId,
                        TenHocVien = hv.TenHocVien,
                        NgayGhiDanh = p.NgayGhiDanh,
                        DaDong = p.DaDong,
                        ConNo = p.ConNo
                    }).ToList();
        }

        public static object SelectTheoCoSo()
        {
            return (from p in Database.PHIEUGHIDANHs
                    join hv in Database.HOCVIENs on p.HocVienId equals hv.HocVienId
                    where (hv.CoSoId == GlobalSettings.CoSoId) && p.IsRemove!=1
                    select new
                    {
                        CoSoId = hv.CoSoId,
                        PhieuGhiDanhId = p.PhieuGhiDanhId,
                        HocVienId = p.HocVienId,
                        MaHocVien = hv.MaHocVien,
                        TenHocVien = hv.TenHocVien,
                        NgaySinh = hv.NgaySinh,
                        GioiTinh = hv.GioiTinh,
                        KhoaHocId = p.KhoaHocId,
                        TenKhoaHoc = p.KHOAHOC.TenKhoaHoc,
                        MaPhieuGhiDanh = p.MaPhieuGhiDanh,
                        NgayGhiDanh = p.NgayGhiDanh,
                        TongTien = p.TongTien,
                        DaDong = p.DaDong,
                        MienGiam_PhanTram = p.MienGiam_PhanTram,
                        MienGiam_Tien = p.MienGiam_Tien,
                        ConNo = p.ConNo,
                        IsRemove = p.IsRemove,
                        NhanVienId = p.NhanVienId,
                    }).ToList();
        }

        public static IQueryable<BaoCaoHocVienGhiDanh> BaoCaoHocVienGhiDanhTheoThang(int month, int year)
        {
            return from p in Database.PHIEUGHIDANHs
                   join hv in Database.HOCVIENs on p.HocVienId equals hv.HocVienId
                   join kh in Database.KHOAHOCs on p.KhoaHocId equals kh.KhoaHocId
                   where (p.NgayGhiDanh.Value.Month == month) &&
                         (p.NgayGhiDanh.Value.Year == year) && p.IsRemove!=1
                   select new BaoCaoHocVienGhiDanh()
                   {
                       HocVienId = p.HocVienId ?? 0,
                       TenHocVien = hv.TenHocVien,
                       GioiTinh = hv.GioiTinh,
                       NgayGhiDanh = p.NgayGhiDanh,
                       TenKhoaHoc = kh.TenKhoaHoc
                   };
        }
        public static IQueryable<BaoCaoHocVienNo> ThongKeDanhSachNoHocPhi()
        {
            return (from p in Database.PHIEUGHIDANHs
                    join hv in Database.HOCVIENs on p.HocVienId equals hv.HocVienId
                    join kh in Database.KHOAHOCs on p.KhoaHocId equals kh.KhoaHocId
                    where p.ConNo > 0 && p.IsRemove!=1
                    select new BaoCaoHocVienNo()
                    {
                        HocVienId = p.HocVienId,
                        TenHocVien = hv.TenHocVien,
                        GioiTinh = hv.GioiTinh,
                        TenKhoaHoc = kh.TenKhoaHoc,
                        ConNo = p.ConNo
                    });
        }

        public static PHIEUGHIDANH SelectSingle(int _PhieuGhiDanhId)
        {
            return (from p in Database.PHIEUGHIDANHs
                    where p.PhieuGhiDanhId == _PhieuGhiDanhId && p.IsRemove!=1
                    select p).Single();
        }
        public static List<PhieuGhiDanh_PlusDTO> Select(PhieuGhiDanhFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.PHIEUGHIDANHs
                             where p.IsRemove != 1
                             select p).AsEnumerable().Select((obj, index) => new PhieuGhiDanh_PlusDTO
                             {
                                 Stt = index + 1,
                                 CoSoId = obj.HOCVIEN.CoSoId,
                                 PhieuGhiDanhId = obj.PhieuGhiDanhId,
                                 HocVienId = obj.HocVienId,
                                 MaHocVien = obj.HOCVIEN.MaHocVien,
                                 TenHocVien = obj.HOCVIEN.TenHocVien,
                                 NgaySinh = obj.HOCVIEN.NgaySinh,
                                 GioiTinh = obj.HOCVIEN.GioiTinh,
                                 KhoaHocId = obj.KhoaHocId,
                                 TenKhoaHoc = obj.KHOAHOC.TenKhoaHoc,
                                 MaPhieuGhiDanh = obj.MaPhieuGhiDanh,
                                 NgayGhiDanh = obj.NgayGhiDanh,
                                 TongTien = obj.TongTien,
                                 DaDong = obj.DaDong,
                                 MienGiam_PhanTram = obj.MienGiam_PhanTram,
                                 MienGiam_Tien = obj.MienGiam_Tien,
                                 ConNo = obj.ConNo,
                                 IsRemove = obj.IsRemove,
                                 NhanVienId = obj.NhanVienId,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,
                             });
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.KhoaHocId != null && _filter.KhoaHocId != 0)
                {
                    query = query.Where(o => o.KhoaHocId == _filter.KhoaHocId).ToList();
                }
                if (_filter.PhieuGhiDanhId != null && _filter.PhieuGhiDanhId != 0)
                {
                    query = query.Where(o => o.PhieuGhiDanhId == _filter.PhieuGhiDanhId).ToList();
                }
                if (_filter.HocVienId != null && _filter.HocVienId != 0)
                {
                    query = query.Where(o => o.HocVienId == _filter.HocVienId).ToList();
                }
                if (_filter.NgayGhiDanh_Tu != null && _filter.NgayGhiDanh_Den != null)
                {
                    query = query.Where(o => o.NgayGhiDanh >= _filter.NgayGhiDanh_Tu && o.NgayGhiDanh <= _filter.NgayGhiDanh_Den).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<QLHocPhi_PlusDTO> SelectQLHocPhi(PhieuGhiDanhFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.PHIEUGHIDANHs
                             where p.IsRemove!=1
                             select p).AsEnumerable().Select((obj, index) => new QLHocPhi_PlusDTO
                             {
                                 Stt = index + 1,
                                 PhieuGhiDanhId = obj.PhieuGhiDanhId,
                                 HocVienId = obj.HocVienId,
                                 TenHocVien = obj.HOCVIEN.TenHocVien,
                                 MaHocVien = obj.HOCVIEN.MaHocVien,
                                 GioiTinh = obj.HOCVIEN.GioiTinh,
                                 NgaySinh = obj.HOCVIEN.NgaySinh,
                                 DiaChi = obj.HOCVIEN.DiaChi,
                                 KhoaHocId = obj.KhoaHocId,
                                 TenKhoaHoc = obj.KHOAHOC.TenKhoaHoc,
                                 TenLopHoc = (from diem in GlobalSettings.Database.BANGDIEMs where diem.PhieuGhiDanhId == obj.PhieuGhiDanhId select diem.LOPHOC.TenLopHoc).SingleOrDefault() ?? "",
                                 //obj.BANGDIEMs.Where(o=>o.PhieuGhiDanhId==obj.PhieuGhiDanhId).SingleOrDefault().LOPHOC.TenLopHoc,
                                 MaPhieuGhiDanh = obj.MaPhieuGhiDanh,
                                 NgayGhiDanh = obj.NgayGhiDanh,
                                 TongTien = obj.TongTien,
                                 DaDong = obj.DaDong,
                                 ConNo = obj.ConNo,
                                 IsRemove = obj.IsRemove,
                                 NhanVienId = obj.NhanVienId,
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
                if (_filter.PhieuGhiDanhId != null && _filter.PhieuGhiDanhId != 0)
                {
                    query = query.Where(o => o.PhieuGhiDanhId == _filter.PhieuGhiDanhId).ToList();
                }
                if (_filter.HocVienId != null && _filter.HocVienId != 0)
                {
                    query = query.Where(o => o.HocVienId == _filter.HocVienId).ToList();
                }
                if (_filter.NgayGhiDanh_Tu != null && _filter.NgayGhiDanh_Den != null)
                {
                    query = query.Where(o => o.NgayGhiDanh >= _filter.NgayGhiDanh_Tu && o.NgayGhiDanh <= _filter.NgayGhiDanh_Den).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(PHIEUGHIDANH _phieughidanh, ref int _PhieuGhiDanhId)
        {
            try
            {
                if (GlobalSettings.UserID != -1)
                {
                    _phieughidanh.NhanVienId = GlobalSettings.UserID;
                }

                _phieughidanh.CreatedDate = DateTime.Now;
                _phieughidanh.CreatedBy = GlobalSettings.UserCode;
                _phieughidanh.CreatedLog = GlobalSettings.SessionMyIP;
                _phieughidanh.IsRemove = 0;
                Database.PHIEUGHIDANHs.InsertOnSubmit(_phieughidanh);
                Database.SubmitChanges();
                _PhieuGhiDanhId = _phieughidanh.PhieuGhiDanhId;
                _phieughidanh.MaPhieuGhiDanh = string.Format("{0}{1:D5}", "PGD", _PhieuGhiDanhId);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool InsertPGDFull(PHIEUGHIDANH _phieughidanh, PHIEUTHU _phieuthu, List<HOCPHIHOCVIEN> _lsthphv, ref int _PhieuGhiDanhId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Phieu ghi danh
                    _phieughidanh.CreatedDate = DateTime.Now;
                    _phieughidanh.CreatedBy = GlobalSettings.UserCode;
                    _phieughidanh.CreatedLog = GlobalSettings.SessionMyIP;
                    _phieughidanh.IsRemove = 0;
                    Database.PHIEUGHIDANHs.InsertOnSubmit(_phieughidanh);
                    Database.SubmitChanges();
                    _PhieuGhiDanhId = _phieughidanh.PhieuGhiDanhId;
                    _phieughidanh.MaPhieuGhiDanh = string.Format("{0}{1:D5}", "PGD", _PhieuGhiDanhId);
                    Database.SubmitChanges();

                    //insert bang PHIEUTHU
                    if (_phieuthu != null && _phieuthu.HocVienId > 0)
                    {
                        _phieuthu.PhieuGhiDanhId = _PhieuGhiDanhId;
                        _phieuthu.CreatedDate = DateTime.Now;
                        _phieuthu.CreatedBy = GlobalSettings.UserCode;
                        _phieuthu.CreatedLog = GlobalSettings.SessionMyIP;
                        _phieuthu.IsRemove = 0;
                        Database.PHIEUTHUs.InsertOnSubmit(_phieuthu);
                        Database.SubmitChanges();
                        _phieuthu.MaPhieuThu = string.Format("{0}{1:D5}", "PT", _phieuthu.PhieuThuId);
                        Database.SubmitChanges();
                    }
                    //Hocphihocvien
                    if (_lsthphv != null && _lsthphv.Count > 0)
                    {
                        foreach (var item in _lsthphv)
                        {
                            item.PhieuGhiDanhId = _PhieuGhiDanhId;
                            item.PhieuThuId = _phieuthu.PhieuThuId;
                            item.CreatedDate = DateTime.Now;
                            item.CreatedBy = GlobalSettings.UserCode;
                            item.CreatedLog = GlobalSettings.SessionMyIP;
                            item.IsRemove = 0;
                            Database.HOCPHIHOCVIENs.InsertOnSubmit(item);
                            Database.SubmitChanges();
                        }
                    }
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool InsertQLHocPhi(PHIEUGHIDANH _phieughidanh, PHIEUTHU _phieuthu, ref int _PhieuThuId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //update Phieu ghi danh
                    PHIEUGHIDANH _PGD_select = PhieuGhiDanhLogic.SelectSingle(_phieughidanh.PhieuGhiDanhId);
                    _PGD_select.DaDong = _phieughidanh.DaDong;
                    _PGD_select.ConNo = _phieughidanh.ConNo;
                    _PGD_select.ModifiedDate = DateTime.Now;
                    _PGD_select.ModifiedBy = GlobalSettings.UserCode;
                    _PGD_select.ModifiedLog = GlobalSettings.SessionMyIP;
                    Database.SubmitChanges();

                    //insert bang PHIEUTHU
                    if (_phieuthu != null && _phieuthu.HocVienId > 0)
                    {
                        _phieuthu.PhieuGhiDanhId = _phieughidanh.PhieuGhiDanhId;
                        _phieuthu.CreatedDate = DateTime.Now;
                        _phieuthu.CreatedBy = GlobalSettings.UserCode;
                        _phieuthu.CreatedLog = GlobalSettings.SessionMyIP;
                        _phieuthu.IsRemove = 0;
                        Database.PHIEUTHUs.InsertOnSubmit(_phieuthu);
                        Database.SubmitChanges();
                        _PhieuThuId = _phieuthu.PhieuThuId;
                        _phieuthu.MaPhieuThu = string.Format("{0}{1:D5}", "PT", _phieuthu.PhieuThuId);
                        Database.SubmitChanges();
                    }
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool Update(PHIEUGHIDANH ph)
        {
            try
            {
                PHIEUGHIDANH pCu = SelectSingle(ph.PhieuGhiDanhId);

                pCu.NgayGhiDanh = ph.NgayGhiDanh;
                pCu.DaDong = ph.DaDong;
                pCu.ConNo = ph.ConNo;
                pCu.NhanVienId = ph.NhanVienId;

                Database.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool XoaPhieuGhiDanh(PHIEUGHIDANH _phieuGD)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //xoa HOCPHIHOCVIEN  
                    List<HOCPHIHOCVIEN> _lstHPHV = HocPhiHocVienLogic.SelectTheoPhieuGhiDanh(_phieuGD.PhieuGhiDanhId);
                    if (_lstHPHV != null && _lstHPHV.Count > 0)
                    {
                        Database.HOCPHIHOCVIENs.DeleteAllOnSubmit(_lstHPHV);
                        Database.SubmitChanges();
                    }
                    //Xoa bang PHIEUTHU;
                    List<PHIEUTHU> _lstPhieuThu = PhieuThuLogic.SelectTheoPhieuGhiDanh(_phieuGD.PhieuGhiDanhId);
                    if (_lstPhieuThu != null && _lstPhieuThu.Count > 0)
                    {
                        Database.PHIEUTHUs.DeleteAllOnSubmit(_lstPhieuThu);
                        Database.SubmitChanges();
                    }
                    //update=Xoa bang PHIEUGHIDANH
                    PHIEUGHIDANH _phieuGDUpdate = SelectSingle(_phieuGD.PhieuGhiDanhId);
                    _phieuGDUpdate.IsRemove = _phieuGD.IsRemove;
                    _phieuGDUpdate.LyDoXoa = _phieuGD.LyDoXoa;
                    _phieuGDUpdate.NguoiXoa = _phieuGD.NguoiXoa;
                    Database.SubmitChanges();
                    //cap nhat bang HOCVIEN va bang tai khoan: kiem tra HV hoc khoa nao ko? neu khong thi update
                    PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter();
                    _filter.HocVienId = _phieuGD.HocVienId;
                    List<PhieuGhiDanh_PlusDTO> _PGD_Kiemtra = PhieuGhiDanhLogic.Select(_filter);
                    if (_PGD_Kiemtra == null || _PGD_Kiemtra.Count == 0)
                    {
                        HOCVIEN _hocvien = HocVienLogic.SelectSingle(_phieuGD.HocVienId ?? 0);
                        _hocvien.LOAIHOCVIEN = LoaiHocVienLogic.Select(KeySetting.LOAIHOCVIEN_TIEMNANG);
                        Database.SubmitChanges();

                        TAIKHOAN _taikhoan = TaiKhoanLogic.Select(_hocvien.TAIKHOAN.TenDangNhap);
                        _taikhoan.IsRemove = 1;
                        Database.SubmitChanges();
                    }
                    //
                    ts.Complete();
                    return true; 
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
