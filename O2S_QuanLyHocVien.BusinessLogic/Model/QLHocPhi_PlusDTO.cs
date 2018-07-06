using O2S_QuanLyHocVien.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class QLHocPhi_PlusDTO : PHIEUGHIDANH
    {
        public int? Stt { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string TenKhoaHoc { get; set; }
        public string TenLopHoc { get; set; }
        public int? SoLuongDotHoc { get; set; }

    }
}
