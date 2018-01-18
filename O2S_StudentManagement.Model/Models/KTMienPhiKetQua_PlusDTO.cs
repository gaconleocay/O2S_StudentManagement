using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Model.Models
{
    public class KTMienPhiKetQua_PlusDTO:ThongTinBenhNhanDTO
    {
        public int maKetQua { get; set; }
        public string tenKetQua { get; set; }
        public int thuHoiThe { get; set; }
        public string thuHoiThe_Ten { get; set; }
        public string ghiChu { get; set; }
    }
}
