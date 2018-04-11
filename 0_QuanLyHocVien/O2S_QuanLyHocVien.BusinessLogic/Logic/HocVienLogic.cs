// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "HocVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using O2S_QuanLyHocVien.BusinessLogic.Model;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class HocVienLogic
    {
        public static HOCVIEN SelectSingle(int _hocvienid)
        {
            try
            {
               // GlobalSettings.NewDatacontexDatabase();
                return (from p in GlobalSettings.Database.HOCVIENs
                        where p.HocVienId == _hocvienid
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<HocVien_PlusDTO> Select(HocVienFilter _filter)
        {
            try
            {
                //GlobalSettings.NewDatacontexDatabase();
                // List<HocVien_PlusDTO> _result = null;
                var query = (from p in GlobalSettings.Database.HOCVIENs
                             select p).AsEnumerable().Select((obj, index) => new HocVien_PlusDTO
                             {
                                 Stt = index + 1,
                                 HocVienId = obj.HocVienId,
                                 CoSoId = obj.CoSoId,
                                 TenCoSoTrungTam = obj.COSOTRUNGTAM.TenCoSo,
                                 LoaiHocVienId = obj.LoaiHocVienId,
                                 MaLoaiHocVien = obj.LOAIHOCVIEN.MaLoaiHocVien,
                                 TenLoaiHocVien = obj.LOAIHOCVIEN.TenLoaiHocVien,
                                 MaHocVien = obj.MaHocVien,
                                 TenHocVien = obj.TenHocVien,
                                 GioiTinh = obj.GioiTinh,
                                 NgaySinh = obj.NgaySinh,
                                 DiaChi = obj.DiaChi,
                                 Sdt = obj.Sdt,
                                 Email = obj.Email,
                                 NgayTiepNhan = obj.NgayTiepNhan,
                                 SdtBo = obj.SdtBo,
                                 EmailBo = obj.EmailBo,
                                 SdtMe = obj.SdtMe,
                                 EmailMe = obj.EmailMe,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,
                                 /*TaiKhoanId = obj.TaiKhoanId,
                                 TenDangNhap=obj.TAIKHOAN.TenDangNhap,*/
                             });
                if (_filter.MaHocVien != null)
                {
                    query = query.Where(o => o.MaHocVien.Contains(_filter.MaHocVien)).ToList();
                }
                if (_filter.HocVienId != null && _filter.HocVienId != 0)
                {
                    query = query.Where(o => o.HocVienId == _filter.HocVienId).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.NgayTiepNhan_Tu != null && _filter.NgayTiepNhan_Den != null)
                {
                    query = query.Where(o => o.NgayTiepNhan >= _filter.NgayTiepNhan_Tu && o.NgayTiepNhan <= _filter.NgayTiepNhan_Den).ToList();
                }
                if (_filter.LoaiHocVienId != null && _filter.LoaiHocVienId != 0)
                {
                    query = query.Where(o => o.LoaiHocVienId == _filter.LoaiHocVienId).ToList();
                }
                if (_filter.GioiTinh != null && _filter.GioiTinh != "")
                {
                    query = query.Where(o => o.GioiTinh == _filter.GioiTinh).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<QuanLyHocVienDTO> SelectQuanLyHocVien(HocVienFilter _filter)
        {
            try
            {
                // List<HocVien_PlusDTO> _result = null;
                var query = (from hv in GlobalSettings.Database.HOCVIENs
                             join pgd in Database.PHIEUGHIDANHs on hv.HocVienId equals pgd.HocVienId into phieu
                             from pgd1 in phieu.DefaultIfEmpty()
                             join bd in Database.BANGDIEMs on pgd1.PhieuGhiDanhId equals bd.BangDiemId into bangdiem
                             from bd1 in bangdiem.DefaultIfEmpty()
                             select new QuanLyHocVienDTO
                             {
                                 HocVienId = hv.HocVienId,
                                 CoSoId = hv.CoSoId,
                                 TenCoSoTrungTam = hv.COSOTRUNGTAM.TenCoSo,
                                 LoaiHocVienId = hv.LoaiHocVienId,
                                 MaLoaiHocVien = hv.LOAIHOCVIEN.MaLoaiHocVien,
                                 TenLoaiHocVien = hv.LOAIHOCVIEN.TenLoaiHocVien,
                                 MaHocVien = hv.MaHocVien,
                                 TenHocVien = hv.TenHocVien,
                                 GioiTinh = hv.GioiTinh,
                                 NgaySinh = hv.NgaySinh,
                                 DiaChi = hv.DiaChi,
                                 Sdt = hv.Sdt,
                                 Email = hv.Email,
                                 NgayTiepNhan = hv.NgayTiepNhan,
                                 SdtBo = hv.SdtBo,
                                 EmailBo = hv.EmailBo,
                                 SdtMe = hv.SdtMe,
                                 EmailMe = hv.EmailMe,
                                 IsRemove = hv.IsRemove,
                                 CreatedDate = hv.CreatedDate,
                                 CreatedBy = hv.CreatedBy,
                                 CreatedLog = hv.CreatedLog,
                                 ModifiedDate = hv.ModifiedDate,
                                 ModifiedBy = hv.ModifiedBy,
                                 ModifiedLog = hv.ModifiedLog,
                                 TenDangNhap = hv.TAIKHOAN.TenDangNhap,
                                 PhieuGhiDanhId = pgd1 == null ? 0 : pgd1.PhieuGhiDanhId,
                                 MaPhieuGhiDanh = pgd1 == null ? "" : pgd1.MaPhieuGhiDanh,
                                 NgayGhiDanh = pgd1 == null ? null : pgd1.NgayGhiDanh,
                                 TongTien = pgd1 == null ? 0 : pgd1.TongTien,
                                 DaDong = pgd1 == null ? 0 : pgd1.DaDong,
                                 ConNo = pgd1 == null ? 0 : pgd1.ConNo,
                                 KhoaHocId = pgd1 == null ? 0 : pgd1.KhoaHocId,
                                 TenKhoaHoc = pgd1 == null ? "" : pgd1.KHOAHOC.TenKhoaHoc,
                                 LopHocId = bd1 == null ? 0 : bd1.LopHocId,
                                 TenLopHoc = bd1 == null ? "" : bd1.LOPHOC.TenLopHoc,
                                 BangDiemId = bd1 == null ? 0 : bd1.BangDiemId,
                                 DiemTrungBinh = bd1 == null ? 0 : bd1.DiemTrungBinh,
                                 TenTrangThai = bd1 == null ? "" : (bd1.TrangThai == 0 ? "Xếp lớp" : bd1.TrangThai == 1 ? "Đang học" : bd1.TrangThai == 3 ? "Có điểm" : bd1.TrangThai == 99 ? "Kết thúc" : ""),
                             }).ToList();
                //if (_filter.MaHocVien != null)
                //{
                //    query = query.Where(o => o.MaHocVien == _filter.MaHocVien).ToList();
                //}
                //if (_filter.HocVienId != null && _filter.HocVienId != 0)
                //{
                //    query = query.Where(o => o.HocVienId == _filter.HocVienId).ToList();
                //}
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.NgayTiepNhan_Tu != null && _filter.NgayTiepNhan_Den != null)
                {
                    query = query.Where(o => o.NgayTiepNhan >= _filter.NgayTiepNhan_Tu && o.NgayTiepNhan <= _filter.NgayTiepNhan_Den).ToList();
                }
                if (_filter.LoaiHocVienId != null && _filter.LoaiHocVienId != 0)
                {
                    query = query.Where(o => o.LoaiHocVienId == _filter.LoaiHocVienId).ToList();
                }
                //if (_filter.GioiTinh != null && _filter.GioiTinh != "")
                //{
                //    query = query.Where(o => o.GioiTinh == _filter.GioiTinh).ToList();
                //}
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<XepLopDTO> DanhSachHocVienChuaXepLop(int _cosoId)
        {
            try
            {
                var querry = (from p in Database.PHIEUGHIDANHs
                              where p.HOCVIEN.CoSoId == _cosoId
                              && !(from q in Database.BANGDIEMs select q.PhieuGhiDanhId).Contains(p.PhieuGhiDanhId)
                              select new XepLopDTO()
                              {
                                  HocVienId = p.HocVienId,
                                  MaHocVien = p.HOCVIEN.MaHocVien,
                                  TenHocVien = p.HOCVIEN.TenHocVien,
                                  PhieuGhiDanhId = p.PhieuGhiDanhId,
                                  MaPhieuGhiDanh = p.MaPhieuGhiDanh,
                                  NgayGhiDanh = p.NgayGhiDanh,
                                  NgaySinh = p.HOCVIEN.NgaySinh,
                                  GioiTinh = p.HOCVIEN.GioiTinh,
                                  DiaChi = p.HOCVIEN.DiaChi,
                                  KhoaHocId = p.KhoaHocId,
                                  MaKhoaHoc = p.KHOAHOC.MaKhoaHoc,
                                  TenKhoaHoc = p.KHOAHOC.TenKhoaHoc,
                              });
                return querry.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(HOCVIEN _hocVien, TAIKHOAN taiKhoan, ref int _hocVienId)
        {
            try
            {
                _hocVien.CreatedDate = DateTime.Now;
                _hocVien.CreatedBy = GlobalSettings.UserCode;
                _hocVien.CreatedLog = GlobalSettings.SessionMyIP;

                if (_hocVien.LoaiHocVienId == KeySetting.LOAIHOCVIEN_TIEMNANG)
                {
                    taiKhoan.IsRemove = 1;
                }
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
                Database.HOCVIENs.InsertOnSubmit(_hocVien);
                Database.SubmitChanges();

                _hocVien.TAIKHOAN = TaiKhoanLogic.SelectSingle(taiKhoan.TaiKhoanId);
                _hocVienId = _hocVien.HocVienId;
                _hocVien.MaHocVien = string.Format("{0}{1:D5}", "HV", _hocVienId); //add ma hoc vien
                Database.SubmitChanges();

                TAIKHOAN _tkUpdate = TaiKhoanLogic.SelectSingle(taiKhoan.TaiKhoanId);
                _tkUpdate.TenDangNhap = _hocVien.MaHocVien;
                _tkUpdate.MatKhau = _hocVien.MaHocVien;
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(HOCVIEN _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                //update hoc vien
                var hocVienCu = SelectSingle(_hocVien.HocVienId);
                hocVienCu.LOAIHOCVIEN = LoaiHocVienLogic.Select(_hocVien.LoaiHocVienId ?? 0);
                hocVienCu.TenHocVien = _hocVien.TenHocVien;
                hocVienCu.GioiTinh = _hocVien.GioiTinh;
                hocVienCu.NgaySinh = _hocVien.NgaySinh;
                hocVienCu.DiaChi = _hocVien.DiaChi;
                hocVienCu.Sdt = _hocVien.Sdt;
                hocVienCu.Email = _hocVien.Email;
                hocVienCu.NgayTiepNhan = _hocVien.NgayTiepNhan;
                hocVienCu.SdtBo = _hocVien.SdtBo;
                hocVienCu.EmailBo = _hocVien.EmailBo;
                hocVienCu.SdtMe = _hocVien.SdtMe;
                hocVienCu.EmailMe = _hocVien.EmailMe;
                hocVienCu.ModifiedDate = DateTime.Now;
                hocVienCu.ModifiedBy = GlobalSettings.UserCode;
                hocVienCu.ModifiedLog = GlobalSettings.SessionMyIP;

                //update tai khoan
                TAIKHOAN _tk = TaiKhoanLogic.SelectSingle(hocVienCu.TaiKhoanId ?? 0);
                //_tk.TenDangNhap = taiKhoan.TenDangNhap;
                //_tk.MatKhau = taiKhoan.MatKhau;
                if (_hocVien.LoaiHocVienId == KeySetting.LOAIHOCVIEN_CHINHTHUC)//chinh thuc
                {
                    _tk.IsRemove = 0;
                }
                else
                {
                    _tk.IsRemove = 1;
                }
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _hocvienId)
        {
            try
            {
                var temp = SelectSingle(_hocvienId);
                int _loaihocvien = temp.LoaiHocVienId ?? 0;
                int TaiKhoanId = temp.TaiKhoanId ?? 0;

                Database.HOCVIENs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                //if (_loaihocvien == 1)
                TaiKhoanLogic.Delete(TaiKhoanId);
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
