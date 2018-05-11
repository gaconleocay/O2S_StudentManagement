using O2S_QuanLyHocVien.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic.Model
{
    public class TaiKhoan_PlusDTO : TAIKHOAN
    {
        public string TenNguoiDung { get; set; }
        public string TenLoaiTaiKhoan { get; set; }
    }
}
