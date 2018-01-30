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
    public static class Version
    {
        /// <summary>
        /// Lấy 1 phiên bản
        /// </summary>
        /// <param name="_AppType"> 0: Phần mềm chạy; 1: Launcher</param>
        /// <returns></returns>
        public static VERSION Select(int _AppType)
        {
            return (from p in Database.VERSIONs
                    where p.AppType == _AppType
                    select p).Single();
        }

        /// <summary>
        /// Xóa version
        /// </summary>
        /// <param name="_AppType">0: Phần mềm chạy; 1: Launcher</param>
        public static void Delete(int _AppType)
        {
            var temp = (from p in Database.VERSIONs
                        where p.AppType == _AppType
                        select p).Single();

            Database.VERSIONs.DeleteOnSubmit(temp);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="_version"></param>
        public static void Update(VERSION _version)
        {
            var temp = (from p in Database.VERSIONs
                        where p.AppType == _version.AppType
                        select p).Single();

            temp.AppVersion = _version.AppVersion;
            temp.AppLink = _version.AppLink;
            //temp.AppResults = _version.AppResults;
            temp.AppMD5Hash = _version.AppMD5Hash;
            temp.SqlVersion = _version.SqlVersion;
            //temp.SqlResults = _version.SqlResults;

            Database.SubmitChanges();
        }

    }
}
