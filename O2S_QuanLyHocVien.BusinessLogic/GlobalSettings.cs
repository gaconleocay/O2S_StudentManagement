﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "GlobalSettings.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;
using System.Data.SqlClient;
using System.Data;
//using O2S_QuanLyHocVien.BusinessLogic.Properties;
using O2S_QuanLyHocVien.BusinessLogic.Models;
using System.Configuration;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public enum UserType { NhanVien, HocVien, GiangVien, QuanTri }
    public static class GlobalSettings
    {
        #region Bien Session
        public static QuanLyHocVienDataContext Database { get; set; } //Đại diện cho cơ sở dữ liệu của chương trình
        //public static string ConnectionString { get; set; }// Đại diện cho chuỗi kết nối

        public static int UserID { get; set; }
        public static string UserCode { get; set; }
        public static string UserName { get; set; }  // Tên user
        public static UserType UserType { get; set; }//Đại diện cho kiểu người dùng đăng nhập
        public static string SessionMachineName { get; set; }   // Tên máy
        public static string SessionMyIP { get; set; }  // Địa chỉ IP máy
        public static string SessionVersion { get; set; } // Version phần mềm
        public static bool KiemTraLicenseSuDung { get; set; } //kiem tra license: neu false thi out phan mem, neu true thi cho su dung tiep
        public static string License_KeyDB { get; set; } //License lay tu DB
        public static string MaDatabase { get; set; }//Lay thong tin database
        public static string ServerName { get; set; }//Đại diện cho tên server
        public static string ServerCatalog { get; set; }//Đại diện cho tên database
        public static string TrungTam_Name { get; set; }//Đại diện cho tên trung tâm
        public static string TrungTam_DiaChi { get; set; }//Đại diện cho địa chỉ trung tâm
        public static string TrungTam_Website { get; set; }// Đại diện cho website trung tâm
        public static string TrungTam_Email { get; set; }// Đại diện cho email trung tâm
        public static string TrungTam_Phone { get; set; }// Đại diện cho số điện thoại trung tâm

        //Co so trung tam
        public static int CoSoId { get; set; }
        public static string CoSo_Ten { get; set; }
        public static string CoSo_DiaChi { get; set; }
        public static string CoSo_Sdt { get; set; }
        public static string CoSo_Email { get; set; }
        public static System.Drawing.Image CoSo_LogoCoSo { get; set; }
        public static Dictionary<string, string> lstQuyDinh { get; set; }// Đại diện cho danh sách quy định

        //



        #endregion


        #region Function

        /// <summary>
        /// Kết nối đến cơ sở dữ liệu
        /// </summary>
        public static bool ConnectToDatabase()
        {
            bool result = false;
            try
            {
                string serverhost_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
                string serveruser_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
                string serverpass_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
                string serverdb_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);
                ServerName = serverhost_SM;
                ServerCatalog = serverdb_SM;
                string ConnectionString = "Data Source = " + serverhost_SM + "; Initial Catalog = " + serverdb_SM + ";Persist Security Info=True;User ID=" + serveruser_SM + ";Password=" + serverpass_SM;


                ////nạp thông tin kết nối
                //ConnectionString = Settings.Default.ConnectionString;
                //ServerName = Settings.Default.Database_ServerName;
                //ServerCatalog = Settings.Default.Database_ServerCatalog;

                Database = new QuanLyHocVienDataContext(ConnectionString);

                //kiểm tra kết nối
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("select 1", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                result = true;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error("Loi khi Ket noi CSDL" + ex.ToString());
            }
            return result;
        }

        public static bool NewDatacontexDatabase()
        {
            bool result = false;
            try
            {
                string serverhost_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["ServerHost"].ToString().Trim() ?? "", true);
                string serveruser_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Username"].ToString().Trim(), true);
                string serverpass_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Password"].ToString().Trim(), true);
                string serverdb_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);
                ServerName = serverhost_SM;
                ServerCatalog = serverdb_SM;
                string ConnectionString = "Data Source = " + serverhost_SM + "; Initial Catalog = " + serverdb_SM + ";Persist Security Info=True;User ID=" + serveruser_SM + ";Password=" + serverpass_SM;
                Database = new QuanLyHocVienDataContext(ConnectionString);

                //kiểm tra kết nối
                //SqlConnection connection = new SqlConnection(ConnectionString);
                //connection.Open();
                //SqlCommand cmd = new SqlCommand("select 1", connection);
                //cmd.ExecuteNonQuery();
                //connection.Close();
                result = true;
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error("Loi new Datacontext" + ex.ToString());
            }
            return result;
        }
        /// <summary>
        /// Nạp thông tin trung tâm
        /// </summary>
        public static void LoadCenterInformation()
        {
            THONGTINTRUNGTAM detail = ChiTietTrungTamLogic.Select();
            if (detail != null)
            {
                TrungTam_Name = detail.TenTrungTam;
                TrungTam_DiaChi = detail.DiaChi;
                TrungTam_Website = detail.Website;
                TrungTam_Email = detail.Email;
                TrungTam_Phone = detail.Sdt;
            }
        }

        /// <summary>
        /// Lấy danh sách database
        /// </summary>
        /// <param name="connectionString">Chuỗi kết nối đến master</param>
        /// <returns></returns>
        public static List<string> GetDatabaseList(string connectionString)
        {
            List<string> list = new List<string>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_databases", con))
                using (IDataReader dr = cmd.ExecuteReader())
                    while (dr.Read())
                        list.Add(dr[0].ToString());
            }

            return list;
        }

        /// <summary>
        /// Lưu lại kết nối cơ sở dữ liệu
        /// </summary>
        public static void SaveDatabaseConnection()
        {
            //Settings.Default.ConnectionString = ConnectionString;
            //Settings.Default.Database_ServerName = ServerName;
            //Settings.Default.Database_ServerCatalog = ServerCatalog;

            //Settings.Default.Save();
        }

        /// <summary>
        /// Nạp danh sách quy định
        /// </summary>
        public static void LoadQuyDinh()
        {
            try
            {
                lstQuyDinh = new Dictionary<string, string>();

                var QuyDinh = BusinessLogic.QuyDinhLogic.SelectTheoCoSo();

                foreach (var i in QuyDinh)
                {
                    lstQuyDinh.Add(i.MaQuyDinh, i.GiaTri);
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }


        #endregion
    }
}
