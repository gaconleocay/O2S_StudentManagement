using O2S_StudentManagement.Model;
using O2S_StudentManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement
{
    public class GlobalStore
    {
        //public static List<MrdServicerefDTO> GlobalLst_MrdServiceref { get; set; }
        //public static List<MrdHsbaTemplateDTO> GlobalLst_MrdHsbaTemplate { get; set; }
        public static TokenDTO tokenSession { get; set; }
        public static string SoYTe_String { get; set; }
        public static string TenBenhVien_String { get; set; }
        public static List<OptionDTO> lstOption { get; set; }
        //public static List<Model.Models.TheFileXMLDTO> lstTheFileXML1Global { get; set; }
        //public static List<Model.Models.GDThongKeViPhamDTO> lstGD_ThongKeViPham { get; set; }

    }
}
