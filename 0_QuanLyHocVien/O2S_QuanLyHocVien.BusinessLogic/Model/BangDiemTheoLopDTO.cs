using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class BangDiemTheoLopDTO
    {
        public int HocVienId { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string MaPhieuGhiDanh { get; set; }
        public DateTime? NgayGhiDanh { get; set; }
        public int? KhoaHocId { get; set; }
        public string TenKhoaHoc { get; set; }
        public int? LopHocId { get; set; }
        public string TenLopHoc { get; set; }
        public decimal? DiemTrungBinh { get; set; }

        public List<BangDiemChiTietDTO> lstBangDiemChiTiet { get; set; }
    }
}
