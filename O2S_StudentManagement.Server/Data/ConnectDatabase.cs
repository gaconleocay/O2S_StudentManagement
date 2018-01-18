using System;
using System.Data;
using Npgsql;
using System.Configuration;
using System.Data.SqlClient;

namespace O2S_StudentManagement.Server.Base
{
    public class ConnectDatabase
    {
        #region Khai bao
        private string serverhost = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
        private string serveruser = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
        private string serverpass = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
        private string serverdb = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);

        private string serverhost_HSBA = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost_HSBA"].ToString().Trim() ?? "", true);
        private string serveruser_HSBA = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username_HSBA"].ToString().Trim(), true);
        private string serverpass_HSBA = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password_HSBA"].ToString().Trim(), true);
        private string serverdb_HSBA = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database_HSBA"].ToString().Trim(), true);

        private string serverhost_BGX = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost_BGX"].ToString().Trim() ?? "", true);
        private string serveruser_BGX = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username_BGX"].ToString().Trim(), true);
        private string serverpass_BGX = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password_BGX"].ToString().Trim(), true);
        private string serverdb_BGX = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database_BGX"].ToString().Trim(), true);
        private string serverdb_BGXEvents = Common.EncryptAndDecrypt.EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database_BGXEvents"].ToString().Trim(), true);

        private NpgsqlConnection conn;
        private NpgsqlConnection conn_HSBA;
        private SqlConnection conn_BGX;
        private bool kiemtraketnoi = false;

        #endregion

        #region Database HIS
        public void Connect()
        {
            try
            {
                if (conn == null)
                    conn = new NpgsqlConnection("Server=" + serverhost + ";Port=5432;User Id=" + serveruser + "; " + "Password=" + serverpass + ";Database=" + serverdb + ";CommandTimeout=1800000;");
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                kiemtraketnoi = true;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                // MessageBox.Show("Không kết nối được cơ sở dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.Logging.LogSystem.Error("Loi ket noi den CSDL: " + ex.ToString());
            }
        }
        public void Disconnect()
        {
            try
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                    conn.Close();
                conn.Dispose();
                conn = null;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                //MessageBox.Show("Có lỗi khi đóng kết nối đến CSDL", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.Logging.LogSystem.Error("Loi dong ket noi den CSDL: " + ex.ToString());
            }
        }
        public DataTable GetDataTable(string sql)
        {
            Connect();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
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
                Common.Logging.LogSystem.Error("Loi getDataTable: " + ex.ToString());
            }
            return dt;
        }
        public bool ExecuteNonQuery_HIS(string sql)
        {
            bool result = false;
            try
            {
                Connect();
                if (kiemtraketnoi == true)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Có lỗi khi thực thi đến CSDL", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.Logging.LogSystem.Error("Loi ExecuteNonQuery: " + ex.ToString());
            }
            return result;
        }
        public bool ExecuteNonQuery_Error_HIS(string sql)
        {
            bool result = false;
            try
            {
                Connect();
                if (kiemtraketnoi == true)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Disconnect();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi ExecuteNonQuery_Error: " + ex.ToString());
            }
            return result;
        }
        public NpgsqlDataReader getDataReader(string sql)
        {
            try
            {
                Connect();
                NpgsqlCommand com = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = com.ExecuteReader();
                //dr.Read();
                Disconnect();
                return dr;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi get dataReader ve: " + ex.ToString());
                return null;
            }

        }

        #endregion

        #region Database Ho So Benh An
        public void Connect_HSBA()
        {
            try
            {
                if (conn_HSBA == null)
                    conn_HSBA = new NpgsqlConnection("Server=" + serverhost_HSBA + ";Port=5432;User Id=" + serveruser_HSBA + "; " + "Password=" + serverpass_HSBA + ";Database=" + serverdb_HSBA + ";CommandTimeout=1800000;");
                if (conn_HSBA.State == ConnectionState.Closed)
                    conn_HSBA.Open();
                kiemtraketnoi = true;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                Common.Logging.LogSystem.Error("Loi ket noi den CSDL: " + ex.ToString());
            }
        }
        public void Disconnect_HSBA()
        {
            try
            {
                if ((conn_HSBA != null) && (conn_HSBA.State == ConnectionState.Open))
                    conn_HSBA.Close();
                conn_HSBA.Dispose();
                conn_HSBA = null;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                Common.Logging.LogSystem.Error("Loi dong ket noi den CSDL: " + ex.ToString());
            }
        }
        public DataTable GetDataTable(string sql)
        {
            Connect_HSBA();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn_HSBA);
            DataTable dt = new DataTable();
            try
            {
                if (kiemtraketnoi == true)
                {
                    da.Fill(dt);
                    Disconnect_HSBA();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Có lỗi dữ liệu đầu vào" + ex.ToString(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.Logging.LogSystem.Error("Loi getDataTable: " + ex.ToString());
            }
            return dt;
        }
        public bool ExecuteNonQuery_HSBA(string sql)
        {
            bool result = false;
            try
            {
                Connect_HSBA();
                if (kiemtraketnoi == true)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn_HSBA);
                    cmd.ExecuteNonQuery();
                    Disconnect_HSBA();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Có lỗi khi thực thi đến CSDL", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.Logging.LogSystem.Error("Loi ExecuteNonQuery: " + ex.ToString());
            }
            return result;
        }

        #endregion

        #region Sử dụng DB_LINK để kết nối đến một CSDL khác
        public DataTable GetDataTable_Dblink(string sql)
        {
            DataTable result = new DataTable();
            try
            {
                //dblink_connect
                Execute_Dblink_Connect_HIS();
                //Chay SQL thuc thi
                result = GetDataTable(sql);
                //Disconnect
                Execute_Dblink_Disconnect_HIS();
            }
            catch (Exception ex)
            {
                Execute_Dblink_Disconnect_HIS();
                Execute_Dblink_Connect_HIS();
                result = GetDataTable(sql);
                Execute_Dblink_Disconnect_HIS();
            }
            return result;
        }
        public bool ExecuteNonQuery_Dblink(string sql)
        {
            bool result = false;
            try
            {
                //dblink_connect
                Execute_Dblink_Connect_HIS();
                //Chay SQL thuc thi
                result = ExecuteNonQuery_HSBA(sql);
                //Disconnect
                Execute_Dblink_Disconnect_HIS();
            }
            catch (Exception ex)
            {
                //Logging.Error("Loi getDataTable Dblink: " + ex.ToString());
                Execute_Dblink_Disconnect_HIS();
                Execute_Dblink_Connect_HIS();
                result = ExecuteNonQuery_HSBA(sql);
                Execute_Dblink_Disconnect_HIS();
            }
            return result;
        }

        public void Execute_Dblink_Connect_HIS()
        {
            try
            {
                string dblink_connect = "SELECT dblink_connect('myconn', 'dbname=" + serverdb + " port=5432 host=" + serverhost + " user=" + serveruser + " password=" + serverpass + "');";
                GetDataTable(dblink_connect);
            }
            catch (Exception)
            {
            }
        }
        public void Execute_Dblink_Disconnect_HIS()
        {
            try
            {
                string dblink_dis = "SELECT dblink_disconnect('myconn');";
                GetDataTable(dblink_dis);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Kết nối từ DB HIS sang DB Giám định
        public DataTable GetDataTable_Dblink_IE(string sql)
        {
            DataTable result = new DataTable();
            try
            {
                //dblink_connect
                Execute_Dblink_Connect_IE();
                //Chay SQL thuc thi
                result = GetDataTable(sql);
                //Disconnect
                Execute_Dblink_Disconnect_IE();
            }
            catch (Exception ex)
            {
                Execute_Dblink_Disconnect_IE();
                Execute_Dblink_Connect_IE();
                result = GetDataTable(sql);
                Execute_Dblink_Disconnect_IE();
                Common.Logging.LogSystem.Error("Loi GetDataTable_Dblink_IE: " + ex.ToString());
            }
            return result;
        }
        //public bool ExecuteNonQuery_Dblink_IE(string sql)
        //{
        //    bool result = false;
        //    try
        //    {
        //        //dblink_connect
        //        Execute_Dblink_Connect_HIS();
        //        //Chay SQL thuc thi
        //        result = ExecuteNonQuery_HSBA(sql);
        //        //Disconnect
        //        Execute_Dblink_Disconnect_HIS();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Common.Logging.LogSystem.Error("Loi getDataTable Dblink: " + ex.ToString());
        //        Execute_Dblink_Disconnect_HIS();
        //        Execute_Dblink_Connect_HIS();
        //        result = ExecuteNonQuery_HSBA(sql);
        //        Execute_Dblink_Disconnect_HIS();
        //    }
        //    return result;
        //}
        public void Execute_Dblink_Connect_IE()
        {
            try
            {
                string dblink_connect = "SELECT dblink_connect('myconn_ie', 'dbname=" + serverdb_HSBA + " port=5432 host=" + serverhost_HSBA + " user=" + serveruser_HSBA + " password=" + serverpass_HSBA + "');";
                GetDataTable(dblink_connect);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi Execute_Dblink_Connect_IE: " + ex.ToString());
            }
        }
        public void Execute_Dblink_Disconnect_IE()
        {
            try
            {
                string dblink_dis = "SELECT dblink_disconnect('myconn_ie');";
                GetDataTable(dblink_dis);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi Execute_Dblink_Disconnect_IE: " + ex.ToString());
            }
        }
        #endregion

        #region Database SQL Server QL Bai gui xe
        public void Connect_BGX(int _dbId)
        {
            try
            {
                string _databasename = this.serverdb_BGX;
                if (_dbId == 1)
                {
                    _databasename = this.serverdb_BGXEvents;
                }

                if (conn_BGX == null)
                    conn_BGX = new SqlConnection("Data Source = " + serverhost_BGX + "; Initial Catalog = " + _databasename + ";Persist Security Info=True;User ID=" + serveruser_BGX + ";Password=" + serverpass_BGX);
                if (conn_BGX.State == ConnectionState.Closed)
                    conn_BGX.Open();
                kiemtraketnoi = true;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                Common.Logging.LogSystem.Error("Loi ket noi den CSDL: " + ex.ToString());
            }
        }
        public void Disconnect_BGX()
        {
            try
            {
                if ((conn_BGX != null) && (conn_BGX.State == ConnectionState.Open))
                    conn_BGX.Close();
                conn_BGX.Dispose();
                conn_BGX = null;
            }
            catch (Exception ex)
            {
                kiemtraketnoi = false;
                Common.Logging.LogSystem.Error("Loi dong ket noi den CSDL: " + ex.ToString());
            }
        }
        /// <summary>
        /// Lay du lieu
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="_dbId">_dbId=0:MPARKING; =1:MPARKINGEVENT</param>
        /// <returns></returns>
        public DataTable GetDataTable_BGX(string sql, int _dbId)
        {
            Connect_BGX(_dbId);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn_BGX);
            DataTable dt = new DataTable();
            try
            {
                if (kiemtraketnoi == true)
                {
                    da.Fill(dt);
                    Disconnect_BGX();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Có lỗi dữ liệu đầu vào" + ex.ToString(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.Logging.LogSystem.Error("Loi getDataTable: " + ex.ToString());
            }
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="_dbId">_dbId=0:MPARKING; =1:MPARKINGEVENT</param>
        /// <returns></returns>
        public bool ExecuteNonQuery_BGX(string sql, int _dbId)
        {
            bool result = false;
            try
            {
                Connect_BGX(_dbId);
                if (kiemtraketnoi == true)
                {
                    SqlCommand cmd = new SqlCommand(sql, conn_BGX);
                    cmd.ExecuteNonQuery();
                    Disconnect_BGX();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi ExecuteNonQuery: " + ex.ToString());
            }
            return result;
        }


        #endregion
    }
}

// daolekwan.wordpress.com/2013/06/10/cclass-ket-noi-trong-c/