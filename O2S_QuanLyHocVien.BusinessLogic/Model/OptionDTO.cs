using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public class OptionDTO
    {
        public long optionid { get; set; }
        public string optioncode { get; set; }
        public string optionname { get; set; }
        public string optionvalue { get; set; }
        public string optionnote { get; set; }
        public int optionlook { get; set; }
        public object optiondate { get; set; }
        public string optioncreateuser { get; set; }
    }
}
