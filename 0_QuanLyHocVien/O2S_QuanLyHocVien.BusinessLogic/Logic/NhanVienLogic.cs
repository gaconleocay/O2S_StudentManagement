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
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
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
                                 MaNhanVien = obj.MaNhanVien,
                                 TenNhanVien = obj.TenNhanVien,
                                 Sdt = obj.Sdt,
                                 Email = obj.Email,
                                 TaiKhoanId = obj.TaiKhoanId,
                                 TenDangNhap = obj.TAIKHOAN.TenDangNhap,
                                 NgaySinh = obj.NgaySinh,
                                 DiaChi = obj.DiaChi,
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
                return query.ToList();
            }
            catch (Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
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
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(NHANVIEN nhanVien, TAIKHOAN taiKhoan)
        {
            try
            {
                taiKhoan.IsRemove = 0;
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
                Database.SubmitChanges();

                nhanVien.TaiKhoanId = taiKhoan.TaiKhoanId;
                nhanVien.IsRemove = 0;
                Database.NHANVIENs.InsertOnSubmit(nhanVien);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }
        public static bool Update(NHANVIEN _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var hocVienCu = SelectSingle(_hocVien.NhanVienId);

                hocVienCu.TenNhanVien = _hocVien.TenNhanVien;
                hocVienCu.Sdt = _hocVien.Sdt;
                hocVienCu.Email = _hocVien.Email;
                hocVienCu.NgaySinh = _hocVien.NgaySinh;
                hocVienCu.DiaChi = _hocVien.DiaChi;
                hocVienCu.ModifiedDate = DateTime.Now;
                hocVienCu.ModifiedBy = GlobalSettings.UserCode;
                hocVienCu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                if (taiKhoan != null)
                    TaiKhoanLogic.Update(taiKhoan);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _nhanvienId)
        {
            try
            {
                var temp = SelectSingle(_nhanvienId);
                Database.NHANVIENs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
