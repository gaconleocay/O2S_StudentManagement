//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace O2S_StudentManagement.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SM_TBLLOG
    {
        public int id { get; set; }
        public string logusercode { get; set; }
        public string logvalue { get; set; }
        public string ipaddress { get; set; }
        public string computername { get; set; }
        public string softversion { get; set; }
        public Nullable<System.DateTime> logtime { get; set; }
        public string logtypecode { get; set; }
    }
}