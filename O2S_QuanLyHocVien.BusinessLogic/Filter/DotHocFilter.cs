using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Filter
{
    public class DotHocFilter
    {
        public int? DotHocId { get; set; }
        public int? LopHocId { get; set; }
        public int? CoSoId { get; set; }
        public bool? IsLock { get; set; }
    }
}
