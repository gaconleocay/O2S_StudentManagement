using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Filter
{
    public class LopHocFilter
    {
        public int? LopHocId { get; set; }
        public int? CoSoId { get; set; }
        public int? KhoaHocId { get; set; }
        public bool? IsLock { get; set; }
        public int? GiangVienId { get;set;}
    }
}
