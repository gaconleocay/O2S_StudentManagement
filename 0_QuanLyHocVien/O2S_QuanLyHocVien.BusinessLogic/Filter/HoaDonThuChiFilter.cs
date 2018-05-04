using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Filter
{
  public  class HoaDonThuChiFilter
    {
        public int? LoaiChungTuId { get; set; }
        public DateTime? ThoiGianLap_Tu { get; set; }
        public DateTime? ThoiGianLap_Den { get; set; }
    }
}
