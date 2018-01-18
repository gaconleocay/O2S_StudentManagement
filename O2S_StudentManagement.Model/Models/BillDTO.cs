using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Model.Models
{
    public class BillDTO
    {
        public long stt { get; set; }
        public long billid { get; set; }
        public long billstt { get; set; }
        public string billgroupcode { get; set; }
        public long patientid { get; set; }
        public long vienphiid { get; set; }
        public long hosobenhanid { get; set; }
        public int loaiphieuthuid { get; set; }
        public string loaiphieuthu_name { get; set; }
        public string nguoithu { get; set; }
        public object billdate { get; set; }
        public long departmentgroupid { get; set; }
        public string departmentgroupname { get; set; }
        public long departmentid { get; set; }
        public string departmentname { get; set; }
        public decimal sotien { get; set; }
        public string billremark { get; set; }
        public int dahuyphieu { get; set; }
        public object thoigianhuyphieu { get; set; }
        public string lydohuyphieu { get; set; }
        public string nguoihuy { get; set; }
        public string patientname { get; set; }
        public object vienphidate { get; set; }
        public object vienphidate_ravien { get; set; }
        public long bhytid { get; set; }
        public string bhytcode { get; set; }
        public string gioitinhname { get; set; }
        public object namsinh { get; set; }
        public string diachi { get; set; }

    }
}
