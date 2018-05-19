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
using System.Transactions;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class QuyDinhLogic
    {
        public static List<QUYDINH> SelectAll()
        {
            try
            {
                return (from p in Database.QUYDINHs
                        where p.IsRemove == 0
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        public static List<QUYDINH> SelectTheoCoSo()
        {
            try
            {
                return (from p in Database.QUYDINHs
                        where p.IsRemove == 0 && (p.CoSoId == 0 || p.CoSoId == GlobalSettings.CoSoId)
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

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

        public static bool UpdateAll(List<QUYDINH> lstQuyDinh)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in lstQuyDinh)
                    {
                        QUYDINH _quydinh = Select(item.MaQuyDinh);
                        if (_quydinh.GiaTri != item.GiaTri)
                        {
                            _quydinh.GiaTri = item.GiaTri;
                            Database.SubmitChanges();
                        }
                    }
                    Database.SubmitChanges();
                    ts.Complete();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }


    }
}
