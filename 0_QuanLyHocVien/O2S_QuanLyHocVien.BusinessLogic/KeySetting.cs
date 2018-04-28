using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class KeySetting
    {
        public static int LOAIHOCVIEN_CHINHTHUC = 1;
        public static int LOAIHOCVIEN_TIEMNANG = 2;

        public static int LOAINHANVIEN_QuanTri = 1;
        public static int LOAINHANVIEN_NVGhiDanh = 2;
        public static int LOAINHANVIEN_NVHocVu = 3;
        public static int LOAINHANVIEN_NVKeToan = 4;

        public static int LOAITAIKHOAN_NhanVien = 1;
        public static int LOAITAIKHOAN_HocVien = 2;
        public static int LOAITAIKHOAN_GiangVien = 3;
        public static int LOAITAIKHOAN_QuanTri = 4;

        public static int LOAICHUNGTU_PhieuThu = 1;
        public static int LOAICHUNGTU_PhieuChi = 2;
        public enum ButtonEnum { Them, Sua, Xoa, In, XuatFile }




    }
}
