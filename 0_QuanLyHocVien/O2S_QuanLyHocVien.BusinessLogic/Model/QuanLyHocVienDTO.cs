using O2S_QuanLyHocVien.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class QuanLyHocVienDTO : HOCVIEN
    {
        public int Stt { get; set; }
        public string TenCoSoTrungTam { get; set; }
        public string MaLoaiHocVien { get; set; }
        public string TenLoaiHocVien { get; set; }
        public string TenDangNhap { get; set; }
        public int? PhieuGhiDanhId { get; set; }
        public string MaPhieuGhiDanh { get; set; }
        public DateTime? NgayGhiDanh { get; set; }
        public decimal? TongTien { get; set; }
        public decimal? DaDong { get; set; }
        public decimal? ConNo { get; set; }
        public int? KhoaHocId { get; set; }
        public string TenKhoaHoc { get; set; }
        public int? LopHocId { get; set; }
        public string TenLopHoc { get; set; }
        public int? BangDiemId { get; set; }
        public decimal? DiemTrungBinh { get; set; }
        public string TenTrangThai { get; set; }
    }
}
