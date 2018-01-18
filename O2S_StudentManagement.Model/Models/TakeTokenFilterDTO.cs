using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace O2S_StudentManagement.Model.Models
{
    public class TakeTokenFilterDTO
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
