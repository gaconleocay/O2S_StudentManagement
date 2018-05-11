using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Filter
{
    public class PhieuThuFilter
    {
        public int? PhieuThuId { get; set; }
        public int? CoSoId { get;set;}
        public int? HocVienId { get; set; }
        public int? PhieuGhiDanhId { get; set; }
        public DateTime? ThoiGianThu_Tu { get; set; }
        public DateTime? ThoiGianThu_Den { get; set; }
    }
}
