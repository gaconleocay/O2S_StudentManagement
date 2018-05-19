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
using log4net;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class PhieuGhiDanhLogic
    {
        //private static readonly ILog logFile = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static object SelectAll()
        {
            return (from p in Database.PHIEUGHIDANHs
                    join hv in Database.HOCVIENs on p.HocVienId equals hv.HocVienId
                    where p.IsRemove != 1
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

        //public static object SelectTheoCoSo()
        //{
        //    try
        //    {
        //        return (from p in Database.PHIEUGHIDANHs
        //                join hv in Database.HOCVIENs on p.HocVienId equals hv.HocVienId
        //                where (hv.CoSoId == GlobalSettings.CoSoId) && p.IsRemove != 1
        //                select new
        //                {
        //                    CoSoId = hv.CoSoId,
        //                    PhieuGhiDanhId = p.PhieuGhiDanhId,
        //                    HocVienId = p.HocVienId,
        //                    MaHocVien = hv.MaHocVien,
        //                    TenHocVien = hv.TenHocVien,
        //                    NgaySinh = hv.NgaySinh,
        //                    GioiTinh = hv.GioiTinh,
        //                    KhoaHocId = p.KhoaHocId,
        //                    TenKhoaHoc = p.KHOAHOC.TenKhoaHoc,
        //                    MaPhieuGhiDanh = p.MaPhieuGhiDanh,
        //                    NgayGhiDanh = p.NgayGhiDanh,
        //                    HocPhiKH = p.HocPhiKH,
        //                    SoTietKH = p.SoTietKH,
        //                    HocPhiHocVienKH = p.HocPhiHocVienKH,
        //                    SoTietHocVienKH = p.SoTietHocVienKH,
        //                    ThuKhoanKhac = p.ThuKhoanKhac,
        //                    TongTien = p.TongTien,
        //                    DaDong = p.DaDong,
        //                    MienGiam_PhanTram = p.MienGiam_PhanTram,
        //                    MienGiam_Tien = p.MienGiam_Tien,
        //                    LyDoMienGiam = p.LyDoMienGiam,
        //                    ConNo = p.ConNo,
        //                    IsRemove = p.IsRemove,
        //                    NhanVienId = p.NhanVienId,
        //                }).ToList();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return null;
        //        O2S_Common.Logging.LogSystem.Error(ex);
        //    }
        //}

        public static PHIEUGHIDANH SelectSingle(int _PhieuGhiDanhId)
        {
            try
            {
                return (from p in Database.PHIEUGHIDANHs
                        where p.PhieuGhiDanhId == _PhieuGhiDanhId && p.IsRemove != 1
                        select p).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<PhieuGhiDanh_PlusDTO> Select(PhieuGhiDanhFilter _filter)
        {
            try
            {
                var query = (from obj in GlobalSettings.Database.PHIEUGHIDANHs
                             where obj.IsRemove != 1
                             select new PhieuGhiDanh_PlusDTO
                             {
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
                                 HocPhiKH = obj.HocPhiKH,
                                 SoTietKH = obj.SoTietKH,
                                 HocPhiHocVienKH = obj.HocPhiHocVienKH,
                                 SoTietHocVienKH = obj.SoTietHocVienKH,
                                 ThuKhoanKhac = obj.ThuKhoanKhac,
                                 TongTien = obj.TongTien,
                                 DaDong = obj.DaDong,
                                 MienGiam_PhanTram = obj.MienGiam_PhanTram,
                                 MienGiam_Tien = obj.MienGiam_Tien,
                                 LyDoMienGiam = obj.LyDoMienGiam,
                                 ConNo = obj.ConNo,
                                 IsRemove = obj.IsRemove,
                                 NhanVienId = obj.NhanVienId,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,
                             }).ToList();
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
                for (int i = 0; i < query.Count; i++)
                {
                    query[i].Stt = i + 1;
                }

                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<QLHocPhi_PlusDTO> SelectQLHocPhi(PhieuGhiDanhFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.PHIEUGHIDANHs
                             where p.IsRemove != 1
                             select p).AsEnumerable().Select((obj, index) => new QLHocPhi_PlusDTO
                             {
                                 Stt = index + 1,
                                 PhieuGhiDanhId = obj.PhieuGhiDanhId,
                                 CoSoId = obj.CoSoId,
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
                                 MienGiam_PhanTram = obj.MienGiam_PhanTram,
                                 MienGiam_Tien = obj.MienGiam_Tien,
                                 LyDoMienGiam = obj.LyDoMienGiam,
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
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool InsertPGDFull(PHIEUGHIDANH _phieughidanh, PHIEUTHU _phieuthu, List<HOCPHIHOCVIEN> _lsthphv, ref int _PhieuGhiDanhId, ref int _PhieuThuId)
        {
            try
            {
             //   O2S_Common.Logging.LogSystem.Error("Luu log InsertPGDFull");
                using (TransactionScope ts = new TransactionScope())
                {
                    //Phieu ghi danh
                    _phieughidanh.CoSoId = GlobalSettings.CoSoId;
                    _phieughidanh.CreatedDate = DateTime.Now;
                    _phieughidanh.CreatedBy = GlobalSettings.UserCode;
                    _phieughidanh.CreatedLog = GlobalSettings.SessionMyIP;
                    _phieughidanh.IsRemove = 0;
                    Database.PHIEUGHIDANHs.InsertOnSubmit(_phieughidanh);
                    Database.SubmitChanges();
                    _PhieuGhiDanhId = _phieughidanh.PhieuGhiDanhId;
                    _phieughidanh.MaPhieuGhiDanh = string.Format("{0}{1:D7}", "PGD", _PhieuGhiDanhId);
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
                        _PhieuThuId = _phieuthu.PhieuThuId;
                        _phieuthu.MaPhieuThu = string.Format("{0}{1:D7}", "PT", _phieuthu.PhieuThuId);
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
                    //Update HOCVIEN = Hoc vien chinh thuc
                    HOCVIEN _hocvien = HocVienLogic.SelectSingle(_phieughidanh.HocVienId ?? 0);
                    _hocvien.LOAIHOCVIEN = LoaiHocVienLogic.Select(KeySetting.LOAIHOCVIEN_CHINHTHUC);
                    //Database.SubmitChanges();
                    //Update TAIKHOAN = được sử dụng
                    TAIKHOAN _taikhoan = TaiKhoanLogic.SelectTheoTenDangNhap(_hocvien.MaHocVien);
                    _taikhoan.IsRemove = 0;
                    Database.SubmitChanges();
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
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
                        _phieuthu.MaPhieuThu = string.Format("{0}{1:D7}", "PT", _phieuthu.PhieuThuId);
                        Database.SubmitChanges();
                    }
                    ts.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
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
                        //Database.SubmitChanges();
                    }
                    //Xoa bang PHIEUTHU;
                    List<PHIEUTHU> _lstPhieuThu = PhieuThuLogic.SelectTheoPhieuGhiDanh(_phieuGD.PhieuGhiDanhId);
                    if (_lstPhieuThu != null && _lstPhieuThu.Count > 0)
                    {
                        Database.PHIEUTHUs.DeleteAllOnSubmit(_lstPhieuThu);
                        // Database.SubmitChanges();
                    }
                    //update=Xoa bang PHIEUGHIDANH
                    //PHIEUGHIDANH _phieuGDUpdate = SelectSingle(_phieuGD.PhieuGhiDanhId);
                    _phieuGD.IsRemove = _phieuGD.IsRemove;
                    _phieuGD.LyDoXoa = _phieuGD.LyDoXoa;
                    _phieuGD.NguoiXoa = _phieuGD.NguoiXoa;
                    _phieuGD.ModifiedDate = DateTime.Now;
                    _phieuGD.ModifiedBy = GlobalSettings.UserCode;
                    _phieuGD.ModifiedLog = GlobalSettings.SessionMyIP;
                    //Database.SubmitChanges();
                    //cap nhat bang HOCVIEN va bang tai khoan: kiem tra HV hoc khoa nao ko? neu=1 thi update
                    PhieuGhiDanhFilter _filter = new PhieuGhiDanhFilter();
                    _filter.HocVienId = _phieuGD.HocVienId;
                    List<PhieuGhiDanh_PlusDTO> _PGD_Kiemtra = PhieuGhiDanhLogic.Select(_filter);
                    if (_PGD_Kiemtra == null || _PGD_Kiemtra.Count <= 1)
                    {
                        HOCVIEN _hocvien = HocVienLogic.SelectSingle(_phieuGD.HocVienId ?? 0);
                        _hocvien.LOAIHOCVIEN = LoaiHocVienLogic.Select(KeySetting.LOAIHOCVIEN_TIEMNANG);
                        Database.SubmitChanges();

                        TAIKHOAN _taikhoan = TaiKhoanLogic.SelectTheoTenDangNhap(_hocvien.TAIKHOAN.TenDangNhap);
                        _taikhoan.IsRemove = 1;
                        //Database.SubmitChanges();
                    }
                    //
                    Database.SubmitChanges();
                    ts.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<PHIEUGHIDANH> SelectTheoHocVien(int _hocVienId)
        {
            try
            {
                return (from p in Database.PHIEUGHIDANHs
                        where p.HocVienId == _hocVienId
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }


        public static bool UpdateMaPhieuGhiDanh7So()
        {
            try
            {
                List<PHIEUGHIDANH> _lstHocvien = (from p in GlobalSettings.Database.PHIEUGHIDANHs
                                                  select p).ToList();

                foreach (var item in _lstHocvien)
                {
                    PHIEUGHIDANH _hocvien = (from p in Database.PHIEUGHIDANHs
                                             where p.PhieuGhiDanhId == item.PhieuGhiDanhId
                                             select p).FirstOrDefault();
                    _hocvien.MaPhieuGhiDanh = string.Format("{0}{1:D7}", "PGD", item.PhieuGhiDanhId);
                    Database.SubmitChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
