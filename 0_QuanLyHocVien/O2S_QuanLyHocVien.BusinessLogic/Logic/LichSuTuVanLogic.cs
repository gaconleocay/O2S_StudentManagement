// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "LichSuTuVan.cs"
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
    public static class LichSuTuVanLogic
    {
        public static LICHSUTUVAN SelectSingle(int _lichsutuvanId)
        {
            try
            {
                return (from p in GlobalSettings.Database.LICHSUTUVANs
                        where p.LichSuTuVanId == _lichsutuvanId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<LichSuTuVan_PlusDTO> Select(int _hocvienId)
        {
            try
            {
                var query = (from obj in Database.LICHSUTUVANs
                             join hv in Database.HOCVIENs on obj.HocVienId equals hv.HocVienId
                             where obj.HocVienId == _hocvienId
                             select new LichSuTuVan_PlusDTO
                             {
                                 LichSuTuVanId = obj.LichSuTuVanId,
                                 HocVienId = obj.HocVienId,
                                 MaHocVien = hv.MaHocVien,
                                 NguoiTuVan= obj.NguoiTuVan,
                                 NoiDungTuVan = obj.NoiDungTuVan,
                                 KetQuaTuVan = obj.KetQuaTuVan,
                                 GhiChu = obj.GhiChu,
                                 NgayTuVan = obj.NgayTuVan,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,

                             });
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(LICHSUTUVAN _lichsutuvan)
        {
            try
            {
                _lichsutuvan.CreatedDate = DateTime.Now;
                _lichsutuvan.CreatedBy = GlobalSettings.UserCode;
                _lichsutuvan.CreatedLog = GlobalSettings.SessionMyIP;
                _lichsutuvan.IsRemove = 0;
                Database.LICHSUTUVANs.InsertOnSubmit(_lichsutuvan);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(LICHSUTUVAN _lichsutuvan)
        {
            try
            {
                var lichsutuvanCu = SelectSingle(_lichsutuvan.LichSuTuVanId);

                lichsutuvanCu.NoiDungTuVan = _lichsutuvan.NoiDungTuVan;
                lichsutuvanCu.KetQuaTuVan = _lichsutuvan.KetQuaTuVan;
                lichsutuvanCu.GhiChu = _lichsutuvan.GhiChu;
                lichsutuvanCu.IsRemove = _lichsutuvan.IsRemove;
                lichsutuvanCu.ModifiedDate = DateTime.Now;
                lichsutuvanCu.ModifiedBy = GlobalSettings.UserCode;
                lichsutuvanCu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _lichsutuvanId)
        {
            try
            {
                var temp = SelectSingle(_lichsutuvanId);
                Database.LICHSUTUVANs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

    }
}
