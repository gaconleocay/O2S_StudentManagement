using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Filter
{
    public class NhanVienFilter
    {
        public int? NhanVienId { get; set; }
        public int? LoaiNhanVienId { get; set; }
        public int? TaiKhoanId { get; set; }
        public DateTime? NgayBatDauLamViec_Tu { get;set;}
        public DateTime? NgayBatDauLamViec_Den { get; set; }

    }
}
