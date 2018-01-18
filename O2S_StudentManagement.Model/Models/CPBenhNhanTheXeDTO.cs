using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Model.Models
{
   public class CPBenhNhanTheXeDTO
    {
        public long benhnhanthexeid { get; set; }
        public long patientid { get; set; }
        public string patientcode { get; set; }
        public long vienphiid { get; set; }
        public long hosobenhanid { get; set; }
        public string patientname { get; set; }
        public object vienphidate { get; set; }
        public long vienphidate_long { get; set; }
        public object vienphidate_noitru { get; set; }
        public long vienphidate_noitru_long { get; set; }
        public object vienphidate_ravien { get; set; }
        public long vienphidate_ravien_long { get; set; }
        public long bhytid { get; set; }
        public string bhytcode { get; set; }
        public string gioitinhname { get; set; }
        public object namsinh { get; set; }
        public string diachi { get; set; }
        public int vienphistatus { get; set; }
        public string vienphistatus_name { get; set; }
        public int loaivienphiid { get; set; }
        public string loaivienphi_name { get; set; }
        public long departmentgroupid { get; set; }
        public string departmentgroupname { get; set; }
        public long departmentid { get; set; }
        public string departmentname { get; set; }
        public string khoaphong { get; set; }
        public object createdate { get; set; }
        public string createusercode { get; set; }
        public string createusername { get; set; }
        public int ketthuc_status { get; set; }
        public object ketthuc_date { get; set; }
        public string ketthuc_usercode { get; set; }
        public string ketthuc_username { get; set; }
        public object updatedate { get; set; }
        public string updateusercode { get; set; }
        public string updateusername { get; set; }
    }
}
