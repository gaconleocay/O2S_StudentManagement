using O2S_StudentManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O2S_StudentManagement.Server
{
    public class GlobalStore
    {
        public static TokenDTO tokenSession { get; set; }
        public static string UserName_QLGuiXe {get;set;}
        public static string Password_QLGuiXe { get; set; }
        public static string Password_QLGuiXe_MD5 { get; set; }
        public static string MaTinh { get; set; }
        public static string MaCSKCB { get; set; }
        public static string SecretToken = "123445!#%^#@#%^&DACFA";
        public static string _UserName_QLGuiXe = "qlguixe";
        public static string _Password_QLGuiXe = "guixe123$";
    }
}