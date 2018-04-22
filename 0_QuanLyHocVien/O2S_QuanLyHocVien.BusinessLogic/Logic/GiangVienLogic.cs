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
        public static GIANGVIEN SelectSingle(int _khoahocId)
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
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<GiangVien_PlusDTO> Select(GiangVienFilter _filter)
        {
            try
            {
                //List<GiangVien_PlusDTO> _result = null;
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
                if (_filter.GiangVienId != null && _filter.GiangVienId != 0)
                {
                    query = query.Where(o => o.GiangVienId == _filter.GiangVienId).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(GIANGVIEN _khoahoc, ref int _khoaHocId)
        {
            try
            {
                _khoahoc.CreatedDate = DateTime.Now;
                _khoahoc.CreatedBy = GlobalSettings.UserCode;
                _khoahoc.CreatedLog = GlobalSettings.SessionMyIP;
                _khoahoc.IsRemove = 0;
                Database.GIANGVIENs.InsertOnSubmit(_khoahoc);
                Database.SubmitChanges();
                _khoaHocId = _khoahoc.GiangVienId;
                _khoahoc.MaGiangVien = string.Format("{0}{1:D5}", "GV", _khoaHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }
        public static bool Insert(GIANGVIEN _giangvien, TAIKHOAN taiKhoan)
        {
            try
            {
                taiKhoan.IsRemove = 0;
                taiKhoan.MatKhau = Common.EncryptAndDecrypt.EncryptAndDecrypt.Encrypt(taiKhoan.MatKhau,true);
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
                Database.SubmitChanges();

                _giangvien.TaiKhoanId = taiKhoan.TaiKhoanId;
                _giangvien.IsRemove = 0;
                Database.GIANGVIENs.InsertOnSubmit(_giangvien);
                Database.SubmitChanges();
                _giangvien.MaGiangVien = string.Format("{0}{1:D5}", "GV", _giangvien.GiangVienId);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }
        public static bool Update(GIANGVIEN _hocVien, TAIKHOAN taiKhoan = null)
        {
            try
            {
                var hocVienCu = SelectSingle(_hocVien.GiangVienId);

                hocVienCu.TenGiangVien = _hocVien.TenGiangVien;
                hocVienCu.GioiTinh = _hocVien.GioiTinh;
                hocVienCu.Sdt = _hocVien.Sdt;
                hocVienCu.Email = _hocVien.Email;
                hocVienCu.NgaySinh = _hocVien.NgaySinh;
                hocVienCu.DiaChi = _hocVien.DiaChi;
                hocVienCu.ModifiedDate = DateTime.Now;
                hocVienCu.ModifiedBy = GlobalSettings.UserCode;
                hocVienCu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
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
                    var temp = SelectSingle(_GiangVienId);
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
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
