using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class BangDiemChiTietDTO
    {
        public long BangDiemChiTietId { get; set; }
        public long BangDiemId { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public decimal? Diem { get; set; }
    }
}
