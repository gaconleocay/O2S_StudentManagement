// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "LoaiNV.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Collections.Generic;
using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.BusinessLogic.Model;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class ChucNangLogic
    {
        public static List<CHUCNANG> SelectAll()
        {
            return (from p in Database.CHUCNANGs
                    select p).ToList();
        }

        public static List<CHUCNANG> SelecTheoTaiKhoan()
        {
            try
            {
                return (from p in Database.CHUCNANGs
                        join pq in Database.PHANQUYENTAIKHOANs on p.ChucNangId equals pq.ChucNangId
                        where pq.TaiKhoanId == GlobalSettings.UserID
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<PhanQuyenTaiKhoan_PlusDTO> SelectKieuPhanQuyen()
        {
            try
            {
                return (from p in Database.CHUCNANGs
                        select new PhanQuyenTaiKhoan_PlusDTO
                        {
                            IsCheck = false,
                            ChucNangId = p.ChucNangId,
                            MaChucNang = p.MaChucNang,
                            TenChucNang = p.TenChucNang,
                            LoaiChucNangId = p.LoaiChucNangId,
                            TabMenuId = p.TabMenuId,
                            GhiChu = p.GhiChu,
                            PhanQuyenTaiKhoanId = 0,
                            TaiKhoanId = 0,
                            Them = false,
                            Sua = false,
                            Xoa = false,
                            InAn = false,
                            XuatFile = false,

                        }).OrderBy(or=>or.MaChucNang).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                Common.Logging.LogSystem.Error(ex);
            }

        }



    }
}
