using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class BangDiemFullDTO
    {
        public long BangDiemId { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaPhieu { get; set; }
        public string MaKhoaHoc { get; set; }
        public string TenKhoaHoc { get; set; }
        public DateTime? NgayBD { get; set; }
        public DateTime? NgayKT { get; set; }
        public int? SiSo { get; set; }
        public bool? DangMo { get; set; }
        public decimal DiemTrungBinh { get; set; }
        public int TrangThai { get; set; }
        public string TrangThai_Ten { get; set; }
        public List<BangDiemChiTietDTO> BangDiemChiTiets { get; set; }
    }
}
