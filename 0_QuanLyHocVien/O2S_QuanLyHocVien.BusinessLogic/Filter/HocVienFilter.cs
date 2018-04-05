using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Filter
{
    public class HocVienFilter
    {
        public int? HocVienId { get;set;}
        public int? CoSoId { get; set; }
        public string MaHocVien { get; set; }
        public int? LoaiHocVienId { get; set; }
        public DateTime? NgayTiepNhan_Tu { get; set; }
        public DateTime? NgayTiepNhan_Den { get; set; }
        public string GioiTinh { get; set; }
    }
}
