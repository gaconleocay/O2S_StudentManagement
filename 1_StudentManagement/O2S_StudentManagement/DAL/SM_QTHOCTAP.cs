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
    
    public partial class SM_QTHOCTAP
    {
        public int id { get; set; }
        public Nullable<int> student_id { get; set; }
        public Nullable<int> truonghoc_id { get; set; }
        public string truonghocten { get; set; }
        public Nullable<int> chuyennganh_id { get; set; }
        public string noidung { get; set; }
        public string diachi { get; set; }
        public Nullable<System.DateTime> thoigianhoctu { get; set; }
        public Nullable<System.DateTime> thoigianhocden { get; set; }
        public Nullable<decimal> hocphi { get; set; }
        public Nullable<int> ketqua_id { get; set; }
        public Nullable<int> bangcap_id { get; set; }
        public string ghichu { get; set; }
        public Nullable<int> isremove { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string created_by { get; set; }
        public string created_log { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string modified_by { get; set; }
        public string modified_log { get; set; }
    }
}
