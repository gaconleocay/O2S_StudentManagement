using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Model.Models
{
    public class LichSuXeBenhNhanDTO
    {
        public long stt { get; set; }
        //tblCardEvent
        public string CardEventID { get; set; }
        public string CardNumber { get; set; }
        public object DatetimeIn { get; set; }
        public long DatetimeIn_long { get; set; }
        public object DateTimeOut { get; set; }
        public long DateTimeOut_long { get; set; }
        public string PicDirIn { get; set; }
        public string PicDirOut { get; set; }
        public string LaneIn { get; set; }
        public string LaneOut { get; set; }
        public string UserIn { get; set; }
        public string UserOut { get; set; }
        public string PlateIn { get; set; }
        public string PlateOut { get; set; }
        public decimal Moneys { get; set; }
        public string CardGroupName { get; set; }//loaixe
        public string CustomerName { get; set; }
        public string IsFree { get; set; }
        public string CardNo { get; set; }

        //cp_benhnhanthexe
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
