using O2S_QuanLyHocVien.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.Base
{
    public class listChucNang
    {
        public static List<classPermission> getDanhSachChucNang()
        {
            List<classPermission> lstresult = new List<classPermission>();
            try
            {
                //permissiontype = 1 system
                //permissiontype = 2 function
                //permissiontype = 3 report
                //permissiontype = 4 phan quyen thao tac
                //permissiontype = 5 Dashboard
                //permissiontype = 10 Bao cao in ra

                //tabMenuId: // 1=Trang chu; 2=tiep nhan; 3=quan ly lop hoc; 4=quan ly hoc vien; 5=danh muc; 6=He thong

                //permissiontype = 2; tabMenuId=1:trang chu


                //permissiontype = 2 function; tabMenuId=2: tiep nhan
                classPermission FUNC_01 = new classPermission();
                FUNC_01.permissioncheck = false;
                FUNC_01.permissioncode = "FUNC_01";
                FUNC_01.permissionname = "Tiếp nhận học viên";
                FUNC_01.permissiontype = 2;
                FUNC_01.tabMenuId = 2;
                FUNC_01.permissionnote = "Tiếp nhận học viên";
                lstresult.Add(FUNC_01);

                classPermission FUNC_02 = new classPermission();
                FUNC_02.permissioncheck = false;
                FUNC_02.permissioncode = "FUNC_02";
                FUNC_02.permissionname = "Lập phiếu ghi danh";
                FUNC_02.permissiontype = 2;
                FUNC_02.tabMenuId = 2;
                FUNC_02.permissionnote = "Lập phiếu ghi danh";
                lstresult.Add(FUNC_02);



                //permissiontype = 2 function; tabMenuId=3: quan ly lop hoc
                classPermission FUNC_03 = new classPermission();
                FUNC_03.permissioncheck = false;
                FUNC_03.permissioncode = "FUNC_03";
                FUNC_03.permissionname = "Xếp lớp";
                FUNC_03.permissiontype = 2;
                FUNC_03.tabMenuId = 3;
                FUNC_03.permissionnote = "Xếp lớp";
                lstresult.Add(FUNC_03);

                classPermission FUNC_04 = new classPermission();
                FUNC_04.permissioncheck = false;
                FUNC_04.permissioncode = "FUNC_04";
                FUNC_04.permissionname = "Quản lý điểm học viên";
                FUNC_04.permissiontype = 2;
                FUNC_04.tabMenuId = 3;
                FUNC_04.permissionnote = "Quản lý điểm học viên";
                lstresult.Add(FUNC_04);


                //permissiontype = 2 function; tabMenuId=4: quan ly hoc vien
                classPermission FUNC_05 = new classPermission();
                FUNC_05.permissioncheck = false;
                FUNC_05.permissioncode = "FUNC_05";
                FUNC_05.permissionname = "Quản lý học viên";
                FUNC_05.permissiontype = 2;
                FUNC_05.tabMenuId = 4;
                FUNC_05.permissionnote = "Quản lý học viên";
                lstresult.Add(FUNC_05);

                classPermission FUNC_06 = new classPermission();
                FUNC_06.permissioncheck = false;
                FUNC_06.permissioncode = "FUNC_06";
                FUNC_06.permissionname = "Quản lý nhân viên";
                FUNC_06.permissiontype = 2;
                FUNC_06.tabMenuId = 4;
                FUNC_06.permissionnote = "Quản lý nhân viên";
                lstresult.Add(FUNC_06);


                classPermission FUNC_07 = new classPermission();
                FUNC_07.permissioncheck = false;
                FUNC_07.permissioncode = "FUNC_07";
                FUNC_07.permissionname = "Quản lý giảng viên";
                FUNC_07.permissiontype = 2;
                FUNC_07.tabMenuId = 4;
                FUNC_07.permissionnote = "Quản lý giảng viên";
                lstresult.Add(FUNC_07);

                classPermission FUNC_08 = new classPermission();
                FUNC_08.permissioncheck = false;
                FUNC_08.permissioncode = "FUNC_08";
                FUNC_08.permissionname = "Quản lý học phí học viên";
                FUNC_08.permissiontype = 2;
                FUNC_08.tabMenuId = 4;
                FUNC_08.permissionnote = "Quản lý học phí học viên";
                lstresult.Add(FUNC_08);





                //permissiontype = 1 system ; tabMenuId=6: He thong 
                classPermission SYS_01 = new classPermission();
                SYS_01.permissioncheck = false;
                SYS_01.permissioncode = "SYS_01";
                SYS_01.permissionname = "Kết nối cơ sở dữ liệu";
                SYS_01.permissiontype = 1;
                SYS_01.tabMenuId = 6;
                SYS_01.permissionnote = "Kết nối cơ sở dữ liệu";
                lstresult.Add(SYS_01);

                classPermission SYS_02 = new classPermission();
                SYS_02.permissioncheck = false;
                SYS_02.permissioncode = "SYS_02";
                SYS_02.permissionname = "Quản lý tài khoản";
                SYS_02.permissiontype = 1;
                SYS_02.tabMenuId = 6;
                SYS_02.permissionnote = "Quản lý tài khoản";
                lstresult.Add(SYS_02);

                classPermission SYS_03 = new classPermission();
                SYS_03.permissioncheck = false;
                SYS_03.permissioncode = "SYS_03";
                SYS_03.permissionname = "Quản lý quy định";
                SYS_03.permissiontype = 1;
                SYS_03.tabMenuId = 6;
                SYS_03.permissionnote = "Quản lý quy định";
                lstresult.Add(SYS_03);

                classPermission SYS_04 = new classPermission();
                SYS_04.permissioncheck = false;
                SYS_04.permissioncode = "SYS_04";
                SYS_04.permissionname = "Quản lý cơ sở trung tâm";
                SYS_04.permissiontype = 1;
                SYS_04.tabMenuId = 6;
                SYS_04.permissionnote = "Quản lý cơ sở trung tâm";
                lstresult.Add(SYS_04);

                classPermission SYS_05 = new classPermission();
                SYS_05.permissioncheck = false;
                SYS_05.permissioncode = "SYS_05";
                SYS_05.permissionname = "Đăng ký bản quyền";
                SYS_05.permissiontype = 1;
                SYS_05.tabMenuId = 6;
                SYS_05.permissionnote = "Đăng ký bản quyền";
                lstresult.Add(SYS_05);

                //classPermission SYS_06 = new classPermission();
                //SYS_06.permissioncheck = false;
                //SYS_06.permissioncode = "SYS_06";
                //SYS_06.permissionname = "Danh mục cơ sở khám chữa bệnh";
                //SYS_06.permissiontype = 1;
                //SYS_06.tabMenuId = 6;
                //SYS_06.permissionnote = "Danh mục cơ sở khám chữa bệnh";
                //lstresult.Add(SYS_06);



                //report permissiontype = 3; tabMenuId=2: tiep nhan
                classPermission REPORT_01 = new classPermission();
                REPORT_01.permissioncheck = false;
                REPORT_01.permissioncode = "REPORT_01";
                REPORT_01.permissionname = "Báo cáo tiếp nhận học viên";
                REPORT_01.permissiontype = 3;
                REPORT_01.tabMenuId = 2;
                REPORT_01.permissionnote = "Báo cáo tiếp nhận học viên";
                lstresult.Add(REPORT_01);

                classPermission REPORT_02 = new classPermission();
                REPORT_02.permissioncheck = false;
                REPORT_02.permissioncode = "REPORT_02";
                REPORT_02.permissionname = "Báo cáo học viên ghi danh";
                REPORT_02.permissiontype = 3;
                REPORT_02.tabMenuId = 2;
                REPORT_02.permissionnote = "Báo cáo học viên ghi danh";
                lstresult.Add(REPORT_02);

                //report permissiontype = 3; tabMenuId=3: quan ly lop hoc
                classPermission REPORT_03 = new classPermission();
                REPORT_03.permissioncheck = false;
                REPORT_03.permissioncode = "REPORT_03";
                REPORT_03.permissionname = "Thống kê theo dõi điểm";
                REPORT_03.permissiontype = 3;
                REPORT_03.tabMenuId = 3;
                REPORT_03.permissionnote = "Thống kê theo dõi điểm";
                lstresult.Add(REPORT_03);

                classPermission REPORT_04 = new classPermission();
                REPORT_04.permissioncheck = false;
                REPORT_04.permissioncode = "REPORT_04";
                REPORT_04.permissionname = "Thống kê nợ học phí";
                REPORT_04.permissiontype = 3;
                REPORT_04.tabMenuId = 3;
                REPORT_04.permissionnote = "Thống kê nợ học phí";
                lstresult.Add(REPORT_04);

                classPermission REPORT_05 = new classPermission();
                REPORT_05.permissioncheck = false;
                REPORT_05.permissioncode = "REPORT_05";
                REPORT_05.permissionname = "Báo cáo thẻ xe hủy, mất mát";
                REPORT_05.permissiontype = 3;
                REPORT_05.tabMenuId = 4;
                REPORT_05.permissionnote = "Báo cáo thẻ xe hủy, mất mát";
                lstresult.Add(REPORT_05);


                ////Thao tac
                //classPermission THAOTAC_01 = new classPermission();
                //THAOTAC_01.permissioncheck = false;
                //THAOTAC_01.permissioncode = "THAOTAC_01";
                //THAOTAC_01.permissionname = "Chỉnh sửa cập nhật nội trú";
                //THAOTAC_01.permissiontype = 4;
                //THAOTAC_01.tabMenuId = 2;
                //THAOTAC_01.permissionnote = "Chỉnh sửa cập nhật nội trú";
                //lstresult.Add(THAOTAC_01);



            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return lstresult;
        }

    }
}
