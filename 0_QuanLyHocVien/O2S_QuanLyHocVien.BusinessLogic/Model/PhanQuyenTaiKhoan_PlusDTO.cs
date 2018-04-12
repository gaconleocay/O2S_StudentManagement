using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class PhanQuyenTaiKhoan_PlusDTO
    {
        public bool IsCheck { get; set; }
        public int? ChucNangId { get; set; }
        public string MaChucNang { get; set; }
        public string TenChucNang { get; set; }
        public int? LoaiChucNangId { get; set; }
        public int? TabMenuId { get; set; }
        public string GhiChu { get; set; }
        public int? PhanQuyenTaiKhoanId { get; set; }
        public int? TaiKhoanId { get; set; }
        public bool Them { get; set; }
        public bool Sua { get; set; }
        public bool Xoa { get; set; }
        public bool InAn { get; set; }
        public bool XuatFile { get; set; }
        //public int? IsRemove { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string CreatedLog { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public string ModifiedBy { get; set; }
        //public string ModifiedLog { get; set; }


    }
}
