using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using O2S_QuanLyHocVien.Properties;

namespace O2S_QuanLyHocVien.DAL
{
    public class ConnectDatabase
    {
        #region Khai bao
        private string serverhost_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
        private string serveruser_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
        private string serverpass_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
        private string serverdb_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);

        private SqlConnection conn_SM;
        private bool kiemtraketnoi = false;

        #endregion

        #region Database SQL Server
        public void Connect()
        {
            try
            {
                //string ConnectionString = "Data Source =GEZIGRSJ0G5SFP8\\SQLEXPRESS; Initial Catalog =O2S_QLHV;Persist Security Info=True;User ID=sa;Password=123456";
                string ConnectionString = "Data Source = " + serverhost_SM + "; Initial Catalog = " + this.serverdb_SM + ";Persist Security Info=True;User ID=" + serveruser_SM + ";Password=" + serverpass_SM;
                if (conn_SM == null)
                {
                    conn_SM = new SqlConnection(ConnectionString);
                }
                if (conn_SM.State == ConnectionState.Closed)
                    conn_SM.Open();
                kiemtraketnoi = true;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                O2S_Common.Logging.LogSystem.Error("Loi ket noi den CSDL: " + ex.ToString());
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
                O2S_Common.Logging.LogSystem.Error("Loi dong ket noi den CSDL: " + ex.ToString());
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
                MessageBox.Show("Có lỗi dữ liệu đầu vào" + ex.ToString(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                O2S_Common.Logging.LogSystem.Error("Loi getDataTable: " + ex.ToString());
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
                O2S_Common.Logging.LogSystem.Error("Loi ExecuteNonQuery: " + ex.ToString());
            }
            return result;
        }


        #endregion
    }
}
