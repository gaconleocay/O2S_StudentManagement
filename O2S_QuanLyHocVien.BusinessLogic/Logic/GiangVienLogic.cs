// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "GiangVien.cs"
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
using O2S_QuanLyHocVien.BusinessLogic.Logic;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class GiangVienLogic
    {
        public static GIANGVIEN SelectSigleTheoKhoaKhoa(int _khoahocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.GIANGVIENs
                        where p.GiangVienId == _khoahocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<GiangVien_PlusDTO> Select(GiangVienFilter _filter)
        {
            //GlobalSettings.NewDatacontexDatabase();
            try
            {
                var query = (from p in GlobalSettings.Database.GIANGVIENs
                             select p).AsEnumerable().Select((obj, index) => new GiangVien_PlusDTO
                             {
                                 Stt = index + 1,
                                 GiangVienId = obj.GiangVienId,
                                 MaGiangVien = obj.MaGiangVien,
                                 TenGiangVien = obj.TenGiangVien,
                                 CoSoId = obj.CoSoId,
                                 TenCoSoTrungTam = obj.COSOTRUNGTAM.TenCoSo,
                                 GioiTinh = obj.GioiTinh,
                                 Sdt = obj.Sdt,
                                 Email = obj.Email,
                                 NgayBatDauLamViec=obj.NgayBatDauLamViec,
                                 TaiKhoanId = obj.TaiKhoanId,
                                 TenDangNhap = obj.TAIKHOAN.TenDangNhap,
                                 NgaySinh = obj.NgaySinh,
                                 DiaChi = obj.DiaChi,
                                 GhiChu=obj.GhiChu,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,

                             });
                if (_filter.GiangVienId != null && _filter.GiangVienId != 0)
                {
                    query = query.Where(o => o.GiangVienId == _filter.GiangVienId).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.NgayBatDauLamViec_Tu != null && _filter.NgayBatDauLamViec_Den != null)
                {
                    query = query.Where(o => o.NgayBatDauLamViec >= _filter.NgayBatDauLamViec_Tu && o.NgayBatDauLamViec <= _filter.NgayBatDauLamViec_Den).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static bool InsertAndTaiKhoan(GIANGVIEN _giangvien, TAIKHOAN taiKhoan)
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

                    _giangvien.CreatedDate = DateTime.Now;
                    _giangvien.CreatedBy = GlobalSettings.UserCode;
                    _giangvien.CreatedLog = GlobalSettings.SessionMyIP;
                    _giangvien.IsRemove = 0;
                    _giangvien.TaiKhoanId = taiKhoan.TaiKhoanId;
                    Database.GIANGVIENs.InsertOnSubmit(_giangvien);
                    Database.SubmitChanges();
                    _giangvien.MaGiangVien = string.Format("{0}{1:D5}", "GV", _giangvien.GiangVienId);
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

        public static bool Update(GIANGVIEN _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var hocVienCu = SelectSigleTheoKhoaKhoa(_hocVien.GiangVienId);

                hocVienCu.TenGiangVien = _hocVien.TenGiangVien;
                hocVienCu.GioiTinh = _hocVien.GioiTinh;
                hocVienCu.Sdt = _hocVien.Sdt;
                hocVienCu.Email = _hocVien.Email;
                hocVienCu.NgaySinh = _hocVien.NgaySinh;
                hocVienCu.DiaChi = _hocVien.DiaChi;
                hocVienCu.NgayBatDauLamViec = _hocVien.NgayBatDauLamViec;
                hocVienCu.GhiChu = _hocVien.GhiChu;
                hocVienCu.ModifiedDate = DateTime.Now;
                hocVienCu.ModifiedBy = GlobalSettings.UserCode;
                hocVienCu.ModifiedLog = GlobalSettings.SessionMyIP;
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

        public static bool Delete(int _GiangVienId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //kiem tra neu giang vien: co GIANGDAY + XEPLICHHOC thi khong cho xoa
                    List<GIANGDAY> _lstGiangDay = GiangDayLogic.SelectTheoGiangVien(_GiangVienId);
                    if (_lstGiangDay != null && _lstGiangDay.Count > 0)
                    {
                        Database.GIANGDAYs.DeleteAllOnSubmit(_lstGiangDay);
                        Database.SubmitChanges();
                    }

                    XepLichHocFilter _filter_xlh = new XepLichHocFilter();
                    _filter_xlh.GiaoVien_ChinhId = _GiangVienId;
                    _filter_xlh.GiaoVien_TroGiangId = _GiangVienId;
                    List<XEPLICHHOC> _lstXepLichHoc = XepLichHocLogic.SelectTheoGiangVien(_filter_xlh);
                    if (_lstXepLichHoc != null && _lstXepLichHoc.Count > 0)
                    {
                        Database.XEPLICHHOCs.DeleteAllOnSubmit(_lstXepLichHoc);
                        Database.SubmitChanges();
                    }
                    //xoa GIANGVIEN
                    var temp = SelectSigleTheoKhoaKhoa(_GiangVienId);
                    Database.GIANGVIENs.DeleteOnSubmit(temp);
                    Database.SubmitChanges();

                    //Xoa PHANQUYENTAIKHOAN
                    List<PHANQUYENTAIKHOAN> _lstpqtk = PhanQuyenTaiKhoanLogic.SelectTheoTaiKhoan(temp.TaiKhoanId ?? 0);
                    if (_lstpqtk != null)
                    {
                        Database.PHANQUYENTAIKHOANs.DeleteAllOnSubmit(_lstpqtk);
                        Database.SubmitChanges();
                    }
                    TAIKHOAN _taikhoan = TaiKhoanLogic.SelectSingle(temp.TaiKhoanId ?? 0);
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
