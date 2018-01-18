﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_CarParking.DTO
{
   public class CarParkingDTO
    {
       public long stt { get; set; }
       public long patientid { get; set; }
       public string patientcode { get; set; }
       public string patientname { get; set; }
       public long vienphiid { get; set; }
       public long CarParkingid { get; set; }
       public string CarParkingcode { get; set; }
       public string bhytcode { get; set; }
       public DateTime thoigianvaovien { get; set; }
       public long CarParkingstatus { get; set; }
       public long hosobenhanid { get; set; }
       public long departmentid { get; set; }
       public string departmentname { get; set; }
       public long departmentgroupid { get; set; }
       public string departmentgroupname { get; set; }
       public string giuong { get; set; }
       public long servicepriceid { get; set; }
       public string servicepricecode { get; set; }
       public long ie_pttt_serviceid { get; set; }
       public long hosobenhanstatus { get; set; }
       public string chandoanbandau { get; set; }

    }
}