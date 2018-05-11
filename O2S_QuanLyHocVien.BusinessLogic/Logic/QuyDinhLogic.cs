// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "QuyDinh.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class QuyDinhLogic
    {
        /// <summary>
        /// Chọn tất cả các quy định
        /// </summary>
        /// <returns></returns>
        public static List<QUYDINH> SelectAll()
        {
            try
            {
                return (from p in Database.QUYDINHs
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        /// <summary>
        /// Chọn một quy định
        /// </summary>
        /// <param name="maQD">Mã quy định</param>
        /// <returns></returns>
        public static QUYDINH Select(string _MaQuyDinh)
        {
            try
            {
                return (from p in Database.QUYDINHs
                        where p.MaQuyDinh == _MaQuyDinh
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        /// <summary>
        /// Cập nhật một quy định
        /// </summary>
        /// <param name="qd">Quy định cần cập nhật</param>
        public static void Update(QUYDINH qd)
        {
            try
            {
                var qdCu = Select(qd.MaQuyDinh);
                qdCu.GiaTri = qd.GiaTri;

                Database.SubmitChanges();
            }
            catch (System.Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
