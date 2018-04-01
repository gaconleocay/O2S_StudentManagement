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
using O2S_QuanLyHocVien.BusinessLogic.Properties;
using O2S_QuanLyHocVien.Model.Models;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public enum UserType { NhanVien, HocVien, GiangVien,QuanTri }
    public static class GlobalSettings
    {
        #region Bien Session
        public static QuanLyHocVienDataContext Database { get; set; } //Đại diện cho cơ sở dữ liệu của chương trình
        public static string ConnectionString { get; set; }// Đại diện cho chuỗi kết nối

        public static string UserID { get; set; }
        public static string UserCode { get; set; }
        public static string UserName { get; set; }  // Tên user
        public static UserType UserType { get; set; }//Đại diện cho kiểu người dùng đăng nhập
        public static string SessionMachineName { get; set; }   // Tên máy
        public static string SessionMyIP { get; set; }  // Địa chỉ IP máy
        public static string SessionVersion { get; set; } // Version phần mềm
        public static bool KiemTraLicenseSuDung { get; set; } //kiem tra license: neu false thi out phan mem, neu true thi cho su dung tiep
        public static string License_KeyDB { get; set; } //License lay tu DB
        public static string MaDatabase { get; set; }//Lay thong tin database
        public static List<classPermission> SessionLstPhanQuyenNguoiDung { get; set; }

        public static string ServerName { get; set; }//Đại diện cho tên server
        public static string ServerCatalog { get; set; }//Đại diện cho tên database
        public static string CenterName { get; set; }//Đại diện cho tên trung tâm
        public static string MaCoSo { get; set; }//Co so trung tam
        public static string TenCoSo { get; set; }
        public static string CenterAddress { get; set; }//Đại diện cho địa chỉ trung tâm
        public static string CenterWebsite { get; set; }// Đại diện cho website trung tâm
        public static string CenterEmail { get; set; }// Đại diện cho email trung tâm
        public static string CenterTelephone { get; set; }// Đại diện cho số điện thoại trung tâm
        public static Dictionary<string,int> QuyDinh { get; set; }// Đại diện cho danh sách quy định

        //



        #endregion


        #region Function

        /// <summary>
        /// Kết nối đến cơ sở dữ liệu
        /// </summary>
        public static void ConnectToDatabase()
        {
            //nạp thông tin kết nối
            ConnectionString = Settings.Default.ConnectionString;
            ServerName = Settings.Default.Database_ServerName;
            ServerCatalog = Settings.Default.Database_ServerCatalog;

            Database = new QuanLyHocVienDataContext(ConnectionString);

            //kiểm tra kết nối
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select 1", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Nạp thông tin trung tâm
        /// </summary>
        public static void LoadCenterInformation()
        {
            CHITIETTRUNGTAM detail = ChiTietTrungTam.Select();

            CenterName = detail.TenTT;
            CenterAddress = detail.DiaChiTT;
            CenterWebsite = detail.Website;
            CenterEmail = detail.EmailTT;
            CenterTelephone = detail.SdtTT;
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
            Settings.Default.ConnectionString = ConnectionString;
            Settings.Default.Database_ServerName = ServerName;
            Settings.Default.Database_ServerCatalog = ServerCatalog;

            Settings.Default.Save();
        }

        /// <summary>
        /// Nạp danh sách quy định
        /// </summary>
        public static void LoadQuyDinh()
        {
            QuyDinh = new Dictionary<string, int>();

            var f = BusinessLogic.QuyDinh.SelectAll();

            foreach (var i in f)
                QuyDinh.Add(i.MaQD, (int)i.GiaTri);
        }


        #endregion
    }
}
