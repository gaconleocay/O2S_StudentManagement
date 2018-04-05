using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class BangDiemFullDTO
    {
        public int? BangDiemId { get; set; }
        public int? HocVienId { get; set; }
        public string TenHocVien { get; set; }
        public int? LopHocId { get; set; }
        public string TenLop { get; set; }
        public int? PhieuGhiDanhId { get; set; }
        public int? KhoaHocId { get; set; }
        public string TenKhoaHoc { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? SiSo { get; set; }
        public bool? DangMo { get; set; }
        public decimal DiemTrungBinh { get; set; }
        public int TrangThai { get; set; }
        public string TrangThai_Ten { get; set; }
        public List<BangDiemChiTietDTO> BangDiemChiTiets { get; set; }
    }
}
