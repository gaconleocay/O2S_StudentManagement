using System.Collections.Generic;
using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;

namespace O2S_QuanLyHocVien.BusinessLogic.Logic
{
    public static class LoaiTaiKhoanLogic
    {
        public static List<LOAITAIKHOAN> SelectAll()
        {
            GlobalSettings.NewDatacontexDatabase();
            return (from p in Database.LOAITAIKHOANs
                    select p).ToList();
        }
    }
}
