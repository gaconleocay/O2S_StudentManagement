using O2S_QuanLyHocVien.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class GiangDay_PlusDTO : GIANGDAY
    {
        public int Stt { get; set; }
        public string TenGiangVien { get; set; }
        public string TenLopHoc { get; set; }
    }
}
