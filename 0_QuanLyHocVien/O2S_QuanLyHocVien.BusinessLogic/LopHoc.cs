// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "LopHoc.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2S_QuanLyHocVien.DataAccess;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class LopHoc
    {
        public static object SelectAll()
        {
            return (from p in Database.LOPHOCs
                    select p).ToList();
        }

        /// <summary>
        /// Lấy danh sách lớp theo Cơ sở
        /// </summary>
        /// <returns></returns>
        public static object SelectTheoCoCo()
        {
            return (from p in Database.LOPHOCs
                    where (p.MaCoSo==GlobalSettings.MaCoSo)
                    select p).ToList();
        }

        /// <summary>
        /// Lấy danh sách lớp thỏa điều kiện
        /// </summary>
        /// <param name="maLop">Mã lớp</param>
        /// <param name="tenLop">Tên lớp</param>
        /// <param name="MaKhoaHoc">Mã khóa học</param>
        /// <param name="tuNgay">Từ ngày</param>
        /// <param name="denNgay">Đến ngày</param>
        /// <param name="dangMo">Đang mở</param>
        /// <returns></returns>
        public static object SelectAll(string maLop, string tenLop, string MaKhoaHoc, DateTime? tuNgay, DateTime? denNgay, bool? dangMo)
        {
            return (from p in Database.LOPHOCs
                    where (maLop == null ? true : p.MaLop.Contains(maLop)) &&
                          (tenLop == null ? true : p.TenLop.Contains(tenLop)) &&
                          (MaKhoaHoc == null ? true : p.MaKhoaHoc == MaKhoaHoc) &&
                          (tuNgay == null ? true : p.NgayBD <= tuNgay) &&
                          (denNgay == null ? true : p.NgayKT >= denNgay) &&
                          (dangMo == null ? true : p.DangMo == dangMo)
                    select p).ToList();
        }


        /// <summary>
        /// Tự động sinh mã lớp
        /// </summary>
        /// <returns></returns>
        public static string AutoGenerateId(DateTime ngayBD)
        {
            string result = "LH" + ngayBD.ToString("yyMMdd");
            var temp = from p in GlobalSettings.Database.HOCVIENs
                       where p.MaHocVien.StartsWith(result)
                       select p.MaHocVien;
            int max = -1;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(8, 1));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D1}", result, max + 1);
        }

        /// <summary>
        /// Chọn một lớp
        /// </summary>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static LOPHOC Select(string maLop)
        {
            return (from p in Database.LOPHOCs
                    where p.MaLop.Contains(maLop)
                    select p).Single();
        }

        /// <summary>
        /// Tìm một lớp
        /// </summary>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static object SelectAll(string maLop)
        {
            return (from p in Database.LOPHOCs
                    where p.MaLop.Contains(maLop)
                    select p);
        }

        /// <summary>
        /// Lấy danh sách lớp trống
        /// </summary>
        /// <param name="MaKhoaHocoa">Mã khóa học</param>
        /// <returns></returns>
        public static object DanhSachLopTrong(string MaKhoaHocoa)
        {
            return (from p in Database.LOPHOCs
                    where p.MaKhoaHoc == MaKhoaHocoa &&
                            p.SiSo < (from q in Database.QUYDINHs
                                      where q.MaQD == "QD0000"
                                      select q.GiaTri).Single()
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.TenLop
                    }).ToList();
        }

        /// <summary>
        /// Chèn lớp trống
        /// </summary>
        /// <param name="lh">Lớp học</param>
        public static void Insert(LOPHOC lh)
        {
            Database.LOPHOCs.InsertOnSubmit(lh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin lớp học
        /// </summary>
        /// <param name="lh">Lớp học</param>
        public static void Update(LOPHOC lh)
        {
            var lopCu = Select(lh.MaLop);

            lopCu.TenLop = lh.TenLop;
            lopCu.NgayBD = lh.NgayBD;
            lopCu.NgayKT = lh.NgayKT;
            lopCu.SiSo = lh.SiSo;
            lopCu.MaKhoaHoc = lh.MaKhoaHoc;
            lopCu.DangMo = lh.DangMo;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xóa một lớp học
        /// </summary>
        /// <param name="maLop">Mã lớp</param>
        public static void Delete(string maLop)
        {
            LOPHOC lh = Select(maLop);

            //xóa bảng điểm
            var bangDiem = (from p in Database.BANGDIEMs
                            where p.MaLop == maLop
                            select p);
            Database.BANGDIEMs.DeleteAllOnSubmit(bangDiem);

            //xóa giảng dạy
            var giangDay = (from p in Database.GIANGDAYs
                            where p.MaLop == maLop
                            select p);

            Database.GIANGDAYs.DeleteAllOnSubmit(giangDay);

            //xóa lớp
            Database.LOPHOCs.DeleteOnSubmit(lh);

            Database.SubmitChanges();
        }
    }
}
