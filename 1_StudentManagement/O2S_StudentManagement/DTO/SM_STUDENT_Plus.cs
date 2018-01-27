using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.DTO
{
    public class SM_STUDENT_Plus : DAL.SM_STUDENT
    {
        public string gioitinh_name { get; set; }
        public string dantoc_name { get; set; }
        public string nghenghiep_name { get; set; }
        public string tinh_name { get; set; }
        public string huyen_name { get; set; }
        public string xa_name { get; set; }
        public string dicchi { get; set; }
        public string trangthai_name { get; set; }
        public string chuyennganh_name { get; set; }
        public string bangcap_name { get; set; }
    }
}
