using O2S_QuanLyHocVien.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
   public class HoaDonThuChi_PlusDTO:HOADONTHUCHI
    {
        public int? Stt { get; set; }
        public string TenLoaiChungTu { get; set; }
    }
}
