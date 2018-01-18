using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Model.Models
{
    public class KTMienPhiFilterDTO
    {
        public string maBenhNhan { get; set; }
        public string maTheGuiXe { get; set; }
        public long thoiGianTagTheRa { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public long? thoiGianTagTheRa_Day { get; set; }
        public long? maBenhNhanId { get; set; }
        public string checkusercode { get;set;}
        public string checkusername { get; set; }

    }
}
