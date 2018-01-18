using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Model.Models
{
  public  class tblCardEventDTO
    {
        public long stt { get; set; }
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

    }
}
