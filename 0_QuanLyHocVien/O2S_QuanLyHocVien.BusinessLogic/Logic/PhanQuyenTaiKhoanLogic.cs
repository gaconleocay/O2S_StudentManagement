using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;

namespace O2S_QuanLyHocVien.BusinessLogic.Logic
{
    public static class PhanQuyenTaiKhoanLogic
    {
        public static PHANQUYENTAIKHOAN Select(int _phanQuyenTaiKhoanId)
        {
            return (from p in Database.PHANQUYENTAIKHOANs
                    where p.PhanQuyenTaiKhoanId == _phanQuyenTaiKhoanId
                    select p).Single();
        }
        public static List<PHANQUYENTAIKHOAN> SelectTheoTaiKhoan(int _TaiKhoanId)
        {
            return (from p in Database.PHANQUYENTAIKHOANs
                    where p.TaiKhoanId == _TaiKhoanId
                    select p).ToList();
        }

        public static List<PhanQuyenTaiKhoan_PlusDTO> SelectKieuPhanQuyen(int _TaiKhoanId)
        {
            var result = (from p in Database.CHUCNANGs
                          join pq in (from tmp in Database.PHANQUYENTAIKHOANs where tmp.TaiKhoanId == _TaiKhoanId select tmp) on p.ChucNangId equals pq.ChucNangId into phanquyen
                          from pq1 in phanquyen.DefaultIfEmpty()
                              //where pq1.TAIKHOAN.TaiKhoanId == _TaiKhoanId
                          select new PhanQuyenTaiKhoan_PlusDTO
                          {
                              IsCheck = pq1 == null ? false : true,
                              ChucNangId = p.ChucNangId,
                              MaChucNang = p.MaChucNang,
                              TenChucNang = p.TenChucNang,
                              LoaiChucNangId = p.LoaiChucNangId,
                              TabMenuId = p.TabMenuId,
                              GhiChu = p.GhiChu,
                              PhanQuyenTaiKhoanId = pq1 == null ? 0 : pq1.PhanQuyenTaiKhoanId,
                              TaiKhoanId = pq1 == null ? 0 : pq1.TaiKhoanId,
                              Them = pq1 == null ? false : (pq1.Them == 1 ? true : false),
                              Sua = pq1 == null ? false : (pq1.Sua == 1 ? true : false),
                              Xoa = pq1 == null ? false : (pq1.Xoa == 1 ? true : false),
                              InAn = pq1 == null ? false : (pq1.InAn == 1 ? true : false),
                              XuatFile = pq1 == null ? false : (pq1.XuatFile == 1 ? true : false),

                          }).OrderBy(or => or.MaChucNang).ToList();

            return result;
        }
       // public static PHANQUYENTAIKHOAN SelectTheoTenForm(string _TenForm)
        //{
        //    try
        //    {
        //        return (from p in Database.PHANQUYENTAIKHOANs
        //                join cn in Database.CHUCNANGs on p.ChucNangId equals cn.ChucNangId
        //                where cn.TenForm == _TenForm && p.TaiKhoanId == GlobalSettings.UserID
        //                select p).FirstOrDefault();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return null;
        //        Common.Logging.LogSystem.Error(ex);
        //    }
        //}
        public static PHANQUYENTAIKHOAN SelectTheoMaChucNang(string _machucnang)
        {
            try
            {
                return (from p in Database.PHANQUYENTAIKHOANs
                        join cn in Database.CHUCNANGs on p.ChucNangId equals cn.ChucNangId
                        where cn.MaChucNang == _machucnang && p.TaiKhoanId == GlobalSettings.UserID
                        select p).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return null;
                Common.Logging.LogSystem.Error(ex);
            }
        }
        public static void Insert(PHANQUYENTAIKHOAN bd)
        {
            bd.IsRemove = 0;
            Database.PHANQUYENTAIKHOANs.InsertOnSubmit(bd);
            Database.SubmitChanges();
        }
        public static bool DeleteAndInsert(List<PHANQUYENTAIKHOAN> _lstPQTK, int _TaiKhoanId)
        {
            try
            {
                if (DeleteTheoTaiKhoanId(_TaiKhoanId))
                {
                    Database.PHANQUYENTAIKHOANs.InsertAllOnSubmit(_lstPQTK);
                    Database.SubmitChanges();
                    return true;
                }
                else
                { return false; }
            }
            catch (System.Exception ex)
            {
                return false;
                Common.Logging.LogSystem.Error(ex);
            }

        }
        public static void Update(PHANQUYENTAIKHOAN kh)
        {
            var khoaHocCu = Select(kh.PhanQuyenTaiKhoanId);

            //khoaHocCu.Diem = kh.Diem;
            Database.SubmitChanges();
        }

        public static void Delete(int _phanQuyenTaiKhoanId)
        {
            var kh = (from p in Database.PHANQUYENTAIKHOANs
                      where p.PhanQuyenTaiKhoanId == _phanQuyenTaiKhoanId
                      select p).Single();
            Database.PHANQUYENTAIKHOANs.DeleteOnSubmit(kh);
            Database.SubmitChanges();
        }
        public static bool DeleteTheoTaiKhoanId(int _taiKhoanId)
        {
            try
            {
                List<PHANQUYENTAIKHOAN> _lstPQTK = (from p in Database.PHANQUYENTAIKHOANs
                                                    where p.TaiKhoanId == _taiKhoanId
                                                    select p).ToList();
                Database.PHANQUYENTAIKHOANs.DeleteAllOnSubmit(_lstPQTK);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
