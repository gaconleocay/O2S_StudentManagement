using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Filter
{
    public class HocPhiHocVienFilter
    {
        public int? HocPhiHocVienId { get; set; }
        public int? HocVienId { get;set;}
        public int? DmDichVuId { get; set; }
        public int? PhieuThuId { get; set; }
        public DateTime? CreatedDate_Tu { get; set; }
        public DateTime? CreatedDate_Den { get; set; }
    }
}
