using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
  public  class KhoaHocMonHocDTO
    {
        public bool IsCheck { get; set; }
        public int MonHocId { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public decimal DiemDat { get; set; }
    }
}
