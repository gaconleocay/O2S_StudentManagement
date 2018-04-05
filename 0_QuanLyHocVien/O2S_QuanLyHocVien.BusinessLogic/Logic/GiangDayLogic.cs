// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "frmGiangDay.cs"
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
    public static class GiangDayLogic
    {
        public static List<GiangDay_PlusDTO> Select(GiangDayFilter _filter)
        {
            try
            {
                //List<GiangDay_PlusDTO> _result = null;
                var query = (from p in GlobalSettings.Database.GIANGDAYs
                             select p).AsEnumerable().Select((obj, index) => new GiangDay_PlusDTO
                             {
                                 Stt = index + 1,
                                 GiangDayId = obj.GiangDayId,
                                 LopHocId = obj.LopHocId,
                                 GiangVienId = obj.GiangVienId,
                                 IsRemove = obj.IsRemove,
                                 CreatedDate = obj.CreatedDate,
                                 CreatedBy = obj.CreatedBy,
                                 CreatedLog = obj.CreatedLog,
                                 ModifiedDate = obj.ModifiedDate,
                                 ModifiedBy = obj.ModifiedBy,
                                 ModifiedLog = obj.ModifiedLog,

                             });
                if (_filter.GiangDayId != null && _filter.GiangDayId != 0)
                {
                   query = query.Where(o => o.GiangDayId == _filter.GiangDayId).ToList();
                }
                if (_filter.LopHocId != null && _filter.LopHocId != 0)
                {
                   query = query.Where(o => o.LopHocId == _filter.LopHocId).ToList();
                }
                if (_filter.GiangVienId != null && _filter.GiangVienId != 0)
                {
                   query = query.Where(o => o.GiangVienId == _filter.GiangVienId).ToList();
                }
                if (_filter.KhoaHocId != null && _filter.KhoaHocId != 0)
                {
                   query = query.Where(o => o.LOPHOC.KhoaHocId == _filter.KhoaHocId).ToList();
                }
                if (_filter.NgayBatDau != null && _filter.NgayKetThuc != null)
                {
                   query = query.Where(o => o.LOPHOC.NgayBatDau >= _filter.NgayBatDau && o.LOPHOC.NgayKetThuc <= _filter.NgayKetThuc).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_QuanLyHocVien.Common.Logging.LogSystem.Error(ex);
            }
        }

        /// <summary>
        /// Xóa một quá trình giảng dạy của giảng viên
        /// </summary>
        /// <param name="maGV"></param>
        public static void Delete_GiangVien(int _GiangVienId)
        {
            var temp = (from p in Database.GIANGDAYs
                        where p.GiangVienId == _GiangVienId
                        select p);

            Database.GIANGDAYs.DeleteAllOnSubmit(temp);
            Database.SubmitChanges();
        }

    }
}
