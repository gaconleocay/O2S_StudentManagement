using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Model.Models
{
    public class TakeTokenKetQuaDTO
    {
        public int trangThai { get; set; }
        public TokenTakeDTO APIKey { get; set; }
    }

    public class TokenTakeDTO
    {
        public string access_token { get; set; }
        public string id_token { get; set; }
        public DateTime expires_in { get; set; }
        public string token_type = "Bearer";

    }
}
