using System.Collections.Generic;
using System.Linq;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;

namespace O2S_QuanLyHocVien.BusinessLogic.Logic
{
    public static class LoaiTaiKhoanLogic
    {
        public static LOAITAIKHOAN Select(int _loaitaikhoanId)
        {
            try
            {
                return (from p in Database.LOAITAIKHOANs
                        where p.LoaiTaiKhoanId == _loaitaikhoanId
                        select p).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<LOAITAIKHOAN> SelectAll()
        {
            try
            {
                GlobalSettings.NewDatacontexDatabase();
                return (from p in Database.LOAITAIKHOANs
                        select p).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
