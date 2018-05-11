using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class BangDiemChiTietDTO
    {
        [DataMember(Order = 1)]
        [Display(Name = "Id")]
        public int BangDiemChiTietId { get; set; }
        [DataMember(Order = 2)]
        [Display(Name = "BangDiemId")]
        public int BangDiemId { get; set; }
        [DataMember(Order = 3)]
        [Display(Name = "MonHocId")]
        public int MonHocId { get; set; }
        [DataMember(Order = 4)]
        [Display(Name = "Mã môn học")]
        public string MaMonHoc { get; set; }
        [DataMember(Order = 5)]
        [Display(Name = "Tên môn học")]
        public string TenMonHoc { get; set; }
        [DataMember(Order = 6)]
        [Display(Name = "Điểm")]
        public decimal? Diem { get; set; }
    }
}
