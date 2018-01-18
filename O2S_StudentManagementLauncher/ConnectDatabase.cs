using System;
using System.Data;
using Npgsql;
using System.Configuration;
using System.Data.SqlClient;

namespace O2S_StudentManagementLauncher
{
    public class ConnectDatabase
    {
        #region Khai bao
        private string serverhost_SM = EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
        private string serveruser_SM = EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
        private string serverpass_SM = EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
        private string serverdb_SM = EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);

        private SqlConnection conn_SM;
        private bool kiemtraketnoi = false;

        #endregion

        #region Database SQL Server
        public void Connect()
        {
            try
            {
                if (conn_SM == null)
                    conn_SM = new SqlConnection("Data Source = " + serverhost_SM + "; Initial Catalog = " + this.serverdb_SM + ";Persist Security Info=True;User ID=" + serveruser_SM + ";Password=" + serverpass_SM);
                if (conn_SM.State == ConnectionState.Closed)
                    conn_SM.Open();
                kiemtraketnoi = true;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                //Common.Logging.LogSystem.Error("Loi ket noi den CSDL: " + ex.ToString());
            }
        }
        public void Disconnect()
        {
            try
            {
                if ((conn_SM != null) && (conn_SM.State == ConnectionState.Open))
                    conn_SM.Close();
                conn_SM.Dispose();
                conn_SM = null;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                //Common.Logging.LogSystem.Error("Loi dong ket noi den CSDL: " + ex.ToString());
            }
        }
        public DataTable GetDataTable(string sql)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn_SM);
            DataTable dt = new DataTable();
            try
            {
                if (kiemtraketnoi == true)
                {
                    da.Fill(dt);
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Có lỗi dữ liệu đầu vào" + ex.ToString(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Common.Logging.LogSystem.Error("Loi getDataTable: " + ex.ToString());
            }
            return dt;
        }
        public bool ExecuteNonQuery(string sql)
        {
            bool result = false;
            try
            {
                Connect();
                if (kiemtraketnoi == true)
                {
                    SqlCommand cmd = new SqlCommand(sql, conn_SM);
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Common.Logging.LogSystem.Error("Loi ExecuteNonQuery: " + ex.ToString());
            }
            return result;
        }


        #endregion
    }
}

