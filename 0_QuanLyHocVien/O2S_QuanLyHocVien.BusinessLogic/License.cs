// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "License.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using System.Collections.Generic;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class License
    {
        public static LICENSE Select(string _DataKey)
        {
            return (from p in Database.LICENSEs
                    where p.DataKey == _DataKey
                    select p).Single();
        }

        public static void Delete(string _DataKey)
        {
            var temp = (from p in Database.LICENSEs
                        where p.DataKey == _DataKey
                        select p).Single();

            Database.LICENSEs.DeleteOnSubmit(temp);
            Database.SubmitChanges();
        }

        public static void Insert(LICENSE lh)
        {
            Database.LICENSEs.InsertOnSubmit(lh);
            Database.SubmitChanges();
        }

        public static void Update(LICENSE _version)
        {
            var temp = (from p in Database.LICENSEs
                        where p.DataKey == _version.DataKey
                        select p).Single();

            temp.LicenseKey = _version.LicenseKey;
            Database.SubmitChanges();
        }

    }
}
