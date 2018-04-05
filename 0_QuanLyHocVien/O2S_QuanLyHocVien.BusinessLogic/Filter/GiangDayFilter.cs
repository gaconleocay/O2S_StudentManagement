using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Filter
{
    public class GiangDayFilter
    {
        public int? GiangDayId { get;set;}
        public int? LopHocId { get; set; }
        public int? GiangVienId { get; set; }
        public int? KhoaHocId { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
    }
}
