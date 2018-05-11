﻿using System.Collections.Generic;
using O2S_QuanLyHocVien.Model.Models;

namespace O2S_QuanLyHocVien.Base
{
    /// <summary>
    /// Clast lưu biến tên user đăng nhập hệ thống để sử dụng cho mọi nơi trong chương trình
    /// </summary>
    public static class SessionLogin
    {
        public static string SessionUsercode { get; set; }  // code user
        public static string SessionUsername { get; set; }  // Tên user
        public static string SessionMachineName { get; set; }   // Tên máy
        public static string SessionMyIP { get; set; }  // Địa chỉ IP máy
        public static string SessionVersion { get; set; } // Version phần mềm
        public static bool KiemTraLicenseSuDung { get; set; } //kiem tra license: neu false thi out phan mem, neu true thi cho su dung tiep
        public static string License_KeyDB { get; set; } //License lay tu DB
        public static string MaDatabase { get; set; }//Lay thong tin database


        public static List<classPermission> SessionLstPhanQuyenNguoiDung { get; set; }
    }


}

