// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "LopHoc.cs"
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

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class LopHocLogic
    {
        public static LOPHOC SelectSingle(int _LopHocId)
        {
            try
            {
                return (from p in GlobalSettings.Database.LOPHOCs
                        where p.LopHocId == _LopHocId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<LopHoc_PlusDTO> Select(LopHocFilter _filter)
        {
            try
            {
                //List<LopHoc_PlusDTO> _result = null;
                var query = (from p in GlobalSettings.Database.LOPHOCs
                             select p).AsEnumerable().Select((obj, index) => new LopHoc_PlusDTO
                             {
                                 Stt = index + 1,
                                 LopHocId = obj.LopHocId,
                                 MaLopHoc = obj.MaLopHoc,
                                 TenLopHoc = obj.TenLopHoc,
                                 NgayBatDau = obj.NgayBatDau,
                                 NgayKetThuc = obj.NgayKetThuc,
                                 SiSo = obj.SiSo,
                                 KhoaHocId = obj.KhoaHocId,
                                 TenKhoaHoc = obj.KHOAHOC.TenKhoaHoc,
                                 CoSoId = obj.CoSoId,
                                 TenCoSoTrungTam = obj.COSOTRUNGTAM.TenCoSo,
                                 DangMo = obj.DangMo,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,

                             });
                if (_filter.LopHocId != null && _filter.LopHocId != 0)
                {
                    query = query.Where(o => o.LopHocId == _filter.LopHocId).ToList();
                }
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                if (_filter.KhoaHocId != null && _filter.KhoaHocId != 0)
                {
                    query = query.Where(o => o.KhoaHocId == _filter.KhoaHocId).ToList();
                }
                if (_filter.DangMo != null)
                {
                    query = query.Where(o => o.DangMo == _filter.DangMo).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(LOPHOC _khoahoc, ref int _khoaHocId)
        {
            try
            {
                _khoahoc.CreatedDate = DateTime.Now;
                _khoahoc.CreatedBy = GlobalSettings.UserCode;
                _khoahoc.CreatedLog = GlobalSettings.SessionMyIP;
                Database.LOPHOCs.InsertOnSubmit(_khoahoc);
                Database.SubmitChanges();
                _khoaHocId = _khoahoc.LopHocId;
                _khoahoc.MaLopHoc = string.Format("{0}{1:D5}", "LH", _khoaHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(LOPHOC _lopHoc)
        {
            try
            {
                var hocVienCu = SelectSingle(_lopHoc.LopHocId);

                hocVienCu.TenLopHoc = _lopHoc.TenLopHoc;
                hocVienCu.NgayBatDau = _lopHoc.NgayBatDau;
                hocVienCu.NgayKetThuc = _lopHoc.NgayKetThuc;
                hocVienCu.SiSo = _lopHoc.SiSo;
                hocVienCu.KhoaHocId = _lopHoc.KhoaHocId;
                hocVienCu.DangMo = _lopHoc.DangMo;
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

        public static bool Delete(int _khoahocId)
        {
            try
            {
                var temp = SelectSingle(_khoahocId);
                Database.LOPHOCs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        public static object DanhSachLopTrong(int _khoahocId)
        {
            return (from p in Database.LOPHOCs
                    where p.KhoaHocId == _khoahocId &&
                            p.SiSo < (from q in Database.QUYDINHs
                                      where q.MaQuyDinh == "QD0000"
                                      select q.GiaTri).Single()
                    select new
                    {
                        LopHocId = p.LopHocId,
                        MaLopHoc = p.MaLopHoc,
                        TenLopHoc = p.TenLopHoc
                    }).ToList();
        }

    }
}
