using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.DataAccess
{
    public static class ConnectDB
    {
        private static string serverhost_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
        private static string serveruser_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
        private static string serverpass_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
        private static string serverdb_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);

        public static string ConnectionString = "Data Source = " + serverhost_SM + "; Initial Catalog = " + serverdb_SM + ";Persist Security Info=True;User ID=" + serveruser_SM + ";Password=" + serverpass_SM;
    }
}
