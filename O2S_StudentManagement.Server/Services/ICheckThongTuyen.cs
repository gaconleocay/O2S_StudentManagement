using O2S_CarParking.Model.Models;
using O2S_CarParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_CarParking.Server.Services
{
    public interface ICheckThongTuyen
    {
        IEnumerable<KetQuaCheckThongTuyenDTO> GetCheckListHosobenhan(TieuChiCheckThongTuyenDTO tieuchicheck);

    }

}
