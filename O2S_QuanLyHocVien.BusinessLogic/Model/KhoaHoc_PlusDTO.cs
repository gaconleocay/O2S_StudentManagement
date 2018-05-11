using O2S_QuanLyHocVien.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class KhoaHoc_PlusDTO : KHOAHOC
    {
        public int Stt { get; set; }
        public string TenCoSoTrungTam { get; set; }
        public string TrangThai_Ten { get; set; }
    }
}
