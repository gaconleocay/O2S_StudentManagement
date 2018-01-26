﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "QuyDinh.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;

namespace BusinessLogic
{
    public static class QuyDinh
    {
        /// <summary>
        /// Chọn tất cả các quy định
        /// </summary>
        /// <returns></returns>
        public static List<QUYDINH> SelectAll()
        {
            return (from p in Database.QUYDINHs
                    select p).ToList();
        }

        /// <summary>
        /// Chọn một quy định
        /// </summary>
        /// <param name="maQD">Mã quy định</param>
        /// <returns></returns>
        public static QUYDINH Select(string maQD)
        {
            return (from p in Database.QUYDINHs
                    where p.MaQD == maQD
                    select p).Single();
        }

        /// <summary>
        /// Cập nhật một quy định
        /// </summary>
        /// <param name="qd">Quy định cần cập nhật</param>
        public static void Update(QUYDINH qd)
        {
            var qdCu = Select(qd.MaQD);
            qdCu.GiaTri = qd.GiaTri;

            Database.SubmitChanges();
        }
    }
}
