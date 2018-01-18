using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Model.Models
{
    public class classPermission
    {
        //public ie_tbluser_permission();
        public bool permissioncheck { get; set; }
        public Int32 permissionid { get; set; }
        public string permissioncode { get; set; }
		public string en_permissioncode { get; set; }
        public string permissionname { get; set; }
		public string en_permissionname { get; set; }
        public Int32 permissiontype { get; set; } // 1: he thong; 2: chuc nang; 3: bao cao; 4: thao tac
        public Int32 tabMenuId { get; set; } // 1=Trang chu; 2=QL hoc vien; 3=QL hoc vu; 4=Tai chinh; 5=QL giao vien; 6=
        public string permissionnote { get; set; }
    }
}
