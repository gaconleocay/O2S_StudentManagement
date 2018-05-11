using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class BaoCaoThuTien_ChiTietDTO
    {
        public int? Stt { get; set; }
        public string MaPhieuThu { get; set; }
        public DateTime? ThoiGianThu { get; set; }
        public decimal? SoTien { get; set; }
        public string TenNguoiThu { get; set; }
        public string MaPhieuGhiDanh { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GhiChu { get; set; }
    }
}
