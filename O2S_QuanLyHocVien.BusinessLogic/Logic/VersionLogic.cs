// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "Version.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using System.Collections.Generic;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class VersionLogic
    {
        public static VERSION Select()
        {
            return (from p in Database.VERSIONs
                    select p).FirstOrDefault();
        }

        public static void Delete()
        {
            var temp = (from p in Database.VERSIONs
                        select p).Single();

            Database.VERSIONs.DeleteOnSubmit(temp);
            Database.SubmitChanges();
        }

        public static bool Insert(VERSION _version)
        {
            try
            {
                Database.VERSIONs.InsertOnSubmit(_version);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }


        public static bool Update(VERSION _version)
        {
            try
            {
                var temp = (from p in Database.VERSIONs
                            select p).Single();

                temp.AppVersion = _version.AppVersion;
                temp.AppLink = _version.AppLink;
                //temp.AppResults = _version.AppResults;
                temp.AppMD5Hash = _version.AppMD5Hash;
                temp.SqlVersion = _version.SqlVersion;
                temp.SqlResults = _version.SqlResults;

                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }

        }

    }
}
