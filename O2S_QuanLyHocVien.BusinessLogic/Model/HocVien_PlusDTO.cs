﻿using O2S_QuanLyHocVien.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class HocVien_PlusDTO : HOCVIEN
    {
        public int Stt { get; set; }
        public string TenCoSoTrungTam { get; set; }
        public string MaLoaiHocVien { get; set; }
        public string TenLoaiHocVien { get; set; }
        public string TenDangNhap { get; set; }
    }
}
