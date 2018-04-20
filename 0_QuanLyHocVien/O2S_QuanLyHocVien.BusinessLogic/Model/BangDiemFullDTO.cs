using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class BangDiemFullDTO
    {
        public int? Stt { get; set; }
        public int? BangDiemId { get; set; }
        public int? HocVienId { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public int? PhieuGhiDanhId { get; set; }
        public string MaPhieuGhiDanh { get; set; }
        public DateTime? NgayGhiDanh { get; set; }
        public int? LopHocId { get; set; }
        public string TenLopHoc { get; set; }
        public int? KhoaHocId { get; set; }
        public string TenKhoaHoc { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? SiSo { get; set; }
        public bool? DangMo { get; set; }
        public decimal? DiemTrungBinh { get; set; }
        public int? TrangThai { get; set; }
        public string TrangThai_Ten { get; set; }
        [Display(Name = "Bảng điểm chi tiết")]
        public List<BangDiemChiTietDTO> BangDiemChiTiets { get; set; }
    }
}
