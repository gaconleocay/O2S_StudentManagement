using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class BangDiemChiTietDTO
    {
        public int BangDiemChiTietId { get; set; }
        public int BangDiemId { get; set; }
        public int MonHocId { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public decimal? Diem { get; set; }
    }
}
