// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "NhanVien.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using System.Transactions;
using O2S_QuanLyHocVien.BusinessLogic.Logic;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class NhanVienLogic
    {
        public static NHANVIEN SelectSingle(int _nhanvienId)
        {
            try
            {
                return (from p in GlobalSettings.Database.NHANVIENs
                        where p.NhanVienId == _nhanvienId
                        select p).Single();
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<NhanVien_PlusDTO> Select(NhanVienFilter _filter)
        {
            try
            {
                // List<NhanVien_PlusDTO> _result = null;
                var query = (from p in GlobalSettings.Database.NHANVIENs
                             select p).AsEnumerable().Select((obj, index) => new NhanVien_PlusDTO
                             {
                                 Stt = index + 1,
                                 NhanVienId = obj.NhanVienId,
                                 LoaiNhanVienId = obj.LoaiNhanVienId,
                                 TenLoaiNhanVien = obj.LOAINHANVIEN.TenLoaiNhanVien,
                                 TaiKhoanId = obj.TaiKhoanId,
                                 MaNhanVien = obj.MaNhanVien,
                                 TenNhanVien = obj.TenNhanVien,
                                 NgaySinh = obj.NgaySinh,
                                 GioiTinh = obj.GioiTinh,
                                 Sdt = obj.Sdt,
                                 Email = obj.Email,
                                 DiaChi = obj.DiaChi,
                                 NgayBatDauLamViec = obj.NgayBatDauLamViec,
                                 GhiChu = obj.GhiChu,
                                 TenDangNhap = obj.TAIKHOAN.TenDangNhap,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,
                             });
                if (_filter.NhanVienId != null && _filter.NhanVienId != 0)
                {
                    query = query.Where(o => o.NhanVienId == _filter.NhanVienId).ToList();
                }
                if (_filter.LoaiNhanVienId != null && _filter.LoaiNhanVienId != 0)
                {
                    query = query.Where(o => o.LoaiNhanVienId == _filter.LoaiNhanVienId).ToList();
                }
                if (_filter.TaiKhoanId != null && _filter.TaiKhoanId != 0)
                {
                    query = query.Where(o => o.TaiKhoanId == _filter.TaiKhoanId).ToList();
                }
                if (_filter.NgayBatDauLamViec_Tu != null && _filter.NgayBatDauLamViec_Den != null)
                {
                    query = query.Where(o => o.NgayBatDauLamViec >= _filter.NgayBatDauLamViec_Tu && o.NgayBatDauLamViec <= _filter.NgayBatDauLamViec_Den).ToList();
                }
                return query.ToList();
            }
            catch (Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(NHANVIEN _nhanvien, ref int _nhanVienId)
        {
            try
            {
                _nhanvien.CreatedDate = DateTime.Now;
                _nhanvien.CreatedBy = GlobalSettings.UserCode;
                _nhanvien.CreatedLog = GlobalSettings.SessionMyIP;
                _nhanvien.IsRemove = 0;
                Database.NHANVIENs.InsertOnSubmit(_nhanvien);
                Database.SubmitChanges();
                _nhanVienId = _nhanvien.NhanVienId;
                _nhanvien.MaNhanVien = string.Format("{0}{1:D5}", "NV", _nhanVienId); Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool InsertAndTaiKhoan(NHANVIEN nhanVien, TAIKHOAN taiKhoan)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    taiKhoan.LOAITAIKHOAN = LoaiTaiKhoanLogic.Select(taiKhoan.LoaiTaiKhoanId ?? 0);
                    taiKhoan.TenDangNhap = taiKhoan.TenDangNhap.ToLower();
                    taiKhoan.IsRemove = 0;
                    taiKhoan.MatKhau = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(taiKhoan.MatKhau, true);
                    Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
                    Database.SubmitChanges();

                    nhanVien.CreatedDate = DateTime.Now;
                    nhanVien.CreatedBy = GlobalSettings.UserCode;
                    nhanVien.CreatedLog = GlobalSettings.SessionMyIP;
                    nhanVien.IsRemove = 0;
                    nhanVien.TaiKhoanId = taiKhoan.TaiKhoanId;
                    Database.NHANVIENs.InsertOnSubmit(nhanVien);
                    Database.SubmitChanges();
                    nhanVien.MaNhanVien = string.Format("{0}{1:D5}", "NV", nhanVien.NhanVienId);
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
        public static bool Update(NHANVIEN _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var _nhanvienCu = SelectSingle(_hocVien.NhanVienId);

                _nhanvienCu.LOAINHANVIEN = LoaiNhanVienLogic.Select(_hocVien.LoaiNhanVienId ?? 0);
                _nhanvienCu.TenNhanVien = _hocVien.TenNhanVien;
                _nhanvienCu.Sdt = _hocVien.Sdt;
                _nhanvienCu.Email = _hocVien.Email;
                _nhanvienCu.NgaySinh = _hocVien.NgaySinh;
                _nhanvienCu.GioiTinh = _hocVien.GioiTinh;
                _nhanvienCu.DiaChi = _hocVien.DiaChi;
                _nhanvienCu.NgayBatDauLamViec = _hocVien.NgayBatDauLamViec;
                _nhanvienCu.GhiChu = _hocVien.GhiChu;
                _nhanvienCu.ModifiedDate = DateTime.Now;
                _nhanvienCu.ModifiedBy = GlobalSettings.UserCode;
                _nhanvienCu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                if (taiKhoan != null)
                {
                    TaiKhoanLogic.Update(taiKhoan);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _nhanvienId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {

                    //xoa nhan vien + xoa phan quyen tai khoan + Xoa tai khoan
                    var temp = SelectSingle(_nhanvienId);
                    int _TaiKhoanId = temp.TaiKhoanId ?? 0;
                    Database.NHANVIENs.DeleteOnSubmit(temp);
                    //Database.SubmitChanges();

                    List<PHANQUYENTAIKHOAN> _lstpqtk = PhanQuyenTaiKhoanLogic.SelectTheoTaiKhoan(_TaiKhoanId);
                    if (_lstpqtk != null && _lstpqtk.Count>0)
                    {
                        Database.PHANQUYENTAIKHOANs.DeleteAllOnSubmit(_lstpqtk);
                        //Database.SubmitChanges();
                    }
                    TAIKHOAN _taikhoan = TaiKhoanLogic.SelectSingle(_TaiKhoanId);
                    Database.TAIKHOANs.DeleteOnSubmit(_taikhoan);

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
    }
}
