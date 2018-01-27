using O2S_StudentManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2S_StudentManagement.Base
{
    public class listChucNang
    {
        public static List<classPermission> getDanhSachChucNang()
        {
            List<classPermission> lstresult = new List<classPermission>();
            try
            {
                //permissiontype = 1 system
                //permissiontype = 2 Tools
                //permissiontype = 3 report
                //permissiontype = 4 phan quyen thao tac
                //permissiontype = 5 Dashboard
                //permissiontype = 10 Bao cao in ra

                //tabMenuId: // 1=Trang chu; 2=QL xe ra; 3=thong ke; 4=bao cao; 5=quan tri
                //System
                classPermission SYS_01 = new classPermission();
                SYS_01.permissioncheck = false;
                SYS_01.permissioncode = "SYS_01";
                SYS_01.permissionname = "Kết nối cơ sở dữ liệu";
                SYS_01.permissiontype = 1;
                SYS_01.tabMenuId = 1;
                SYS_01.permissionnote = "Kết nối cơ sở dữ liệu";
                lstresult.Add(SYS_01);

                classPermission SYS_02 = new classPermission();
                SYS_02.permissioncheck = false;
                SYS_02.permissioncode = "SYS_02";
                SYS_02.permissionname = "Quản lý người dùng";
                SYS_02.permissiontype = 1;
                SYS_02.tabMenuId = 1;
                SYS_02.permissionnote = "Quản lý người dùng";
                lstresult.Add(SYS_02);

                classPermission SYS_03 = new classPermission();
                SYS_03.permissioncheck = false;
                SYS_03.permissioncode = "SYS_03";
                SYS_03.permissionname = "Danh sách nhân viên";
                SYS_03.permissiontype = 1;
                SYS_03.tabMenuId = 1;
                SYS_03.permissionnote = "Danh sách nhân viên";
                lstresult.Add(SYS_03);

                classPermission SYS_04 = new classPermission();
                SYS_04.permissioncheck = false;
                SYS_04.permissioncode = "SYS_04";
                SYS_04.permissionname = "Danh sách tùy chọn";
                SYS_04.permissiontype = 1;
                SYS_04.tabMenuId = 1;
                SYS_04.permissionnote = "Danh sách tùy chọn";
                lstresult.Add(SYS_04);

                classPermission SYS_05 = new classPermission();
                SYS_05.permissioncheck = false;
                SYS_05.permissioncode = "SYS_05";
                SYS_05.permissionname = "Quản trị hệ thống";
                SYS_05.permissiontype = 1;
                SYS_05.tabMenuId = 1;
                SYS_05.permissionnote = "Quản trị hệ thống";
                lstresult.Add(SYS_05);

                classPermission SYS_06 = new classPermission();
                SYS_06.permissioncheck = false;
                SYS_06.permissioncode = "SYS_06";
                SYS_06.permissionname = "Danh mục cơ sở khám chữa bệnh";
                SYS_06.permissiontype = 1;
                SYS_06.tabMenuId = 1;
                SYS_06.permissionnote = "Danh mục cơ sở khám chữa bệnh";
                lstresult.Add(SYS_06);

                classPermission SYS_11 = new classPermission();
                SYS_11.permissioncheck = false;
                SYS_11.permissioncode = "SYS_11";
                SYS_11.permissionname = "Danh mục dùng chung";
                SYS_11.permissiontype = 1;
                SYS_11.tabMenuId = 1;
                SYS_11.permissionnote = "Danh mục dùng chung";
                lstresult.Add(SYS_11);


                //Tools - quan ly xe ra
                classPermission TOOL_01 = new classPermission();
                TOOL_01.permissioncheck = false;
                TOOL_01.permissioncode = "TOOL_01";
                TOOL_01.permissionname = "Quản lý xe ra - Kiểm tra xe ra";
                TOOL_01.permissiontype = 2;
                TOOL_01.tabMenuId = 2;
                TOOL_01.permissionnote = "Quản lý xe ra - Kiểm tra xe ra";
                lstresult.Add(TOOL_01);

                classPermission TOOL_02 = new classPermission();
                TOOL_02.permissioncheck = false;
                TOOL_02.permissioncode = "TOOL_02";
                TOOL_02.permissionname = "Quản lý xe ra - Tài chính - Giao dịch";
                TOOL_02.permissiontype = 2;
                TOOL_02.tabMenuId = 2;
                TOOL_02.permissionnote = "Quản lý xe ra - Tài chính - Giao dịch";
                lstresult.Add(TOOL_02);

                classPermission TOOL_03 = new classPermission();
                TOOL_03.permissioncheck = false;
                TOOL_03.permissioncode = "TOOL_03";
                TOOL_03.permissionname = "Quản lý xe ra - Cập nhật nội trú";
                TOOL_03.permissiontype = 2;
                TOOL_03.tabMenuId = 2;
                TOOL_03.permissionnote = "Quản lý xe ra - Cập nhật nội trú";
                lstresult.Add(TOOL_03);



                //Tools - Thống kê permissiontype = 2 tabMenuId = 3

                classPermission TOOL_05 = new classPermission();
                TOOL_05.permissioncheck = false;
                TOOL_05.permissioncode = "TOOL_05";
                TOOL_05.permissionname = "Thống kê - Lịch sử kiểm tra xe ra";
                TOOL_05.permissiontype = 2;
                TOOL_05.tabMenuId = 3;
                TOOL_05.permissionnote = "Thống kê - Lịch sử kiểm tra xe ra";
                lstresult.Add(TOOL_05);

                classPermission TOOL_06 = new classPermission();
                TOOL_06.permissioncheck = false;
                TOOL_06.permissioncode = "TOOL_06";
                TOOL_06.permissionname = "Thống kê - Lịch sử xe vào/ra";
                TOOL_06.permissiontype = 2;
                TOOL_06.tabMenuId = 3;
                TOOL_06.permissionnote = "Thống kê - Lịch sử xe vào/ra";
                lstresult.Add(TOOL_06);

                classPermission TOOL_07 = new classPermission();
                TOOL_07.permissioncheck = false;
                TOOL_07.permissioncode = "TOOL_07";
                TOOL_07.permissionname = "Thống kê - Lịch sử cập nhật nội trú";
                TOOL_07.permissiontype = 2;
                TOOL_07.tabMenuId = 3;
                TOOL_07.permissionnote = "Thống kê - Lịch sử cập nhật nội trú";
                lstresult.Add(TOOL_07);




                //report permissiontype = 3; 4=bao cao;
                classPermission REPORT_01 = new classPermission();
                REPORT_01.permissioncheck = false;
                REPORT_01.permissioncode = "REPORT_01";
                REPORT_01.permissionname = "Báo cáo tài chính - tạm ứng, hoàn ứng";
                REPORT_01.permissiontype = 3;
                REPORT_01.tabMenuId = 4;
                REPORT_01.permissionnote = "Báo cáo tài chính - tạm ứng, hoàn ứng";
                lstresult.Add(REPORT_01);

                classPermission REPORT_02 = new classPermission();
                REPORT_02.permissioncheck = false;
                REPORT_02.permissioncode = "REPORT_02";
                REPORT_02.permissionname = "Báo cáo tài chính - tổng hợp";
                REPORT_02.permissiontype = 3;
                REPORT_02.tabMenuId = 4;
                REPORT_02.permissionnote = "Báo cáo tài chính - tổng hợp";
                lstresult.Add(REPORT_02);

                classPermission REPORT_03 = new classPermission();
                REPORT_03.permissioncheck = false;
                REPORT_03.permissioncode = "REPORT_03";
                REPORT_03.permissionname = "Báo cáo quản lý tổng hợp";
                REPORT_03.permissiontype = 3;
                REPORT_03.tabMenuId = 4;
                REPORT_03.permissionnote = "Báo cáo quản lý tổng hợp";
                lstresult.Add(REPORT_03);

                classPermission REPORT_04 = new classPermission();
                REPORT_04.permissioncheck = false;
                REPORT_04.permissioncode = "REPORT_04";
                REPORT_04.permissionname = "Báo cáo danh sách thẻ xe nội trú";
                REPORT_04.permissiontype = 3;
                REPORT_04.tabMenuId = 4;
                REPORT_04.permissionnote = "Báo cáo danh sách thẻ xe nội trú";
                lstresult.Add(REPORT_04);

                classPermission REPORT_05 = new classPermission();
                REPORT_05.permissioncheck = false;
                REPORT_05.permissioncode = "REPORT_05";
                REPORT_05.permissionname = "Báo cáo thẻ xe hủy, mất mát";
                REPORT_05.permissiontype = 3;
                REPORT_05.tabMenuId = 4;
                REPORT_05.permissionnote = "Báo cáo thẻ xe hủy, mất mát";
                lstresult.Add(REPORT_05);

                classPermission REPORT_06 = new classPermission();
                REPORT_06.permissioncheck = false;
                REPORT_06.permissioncode = "REPORT_06";
                REPORT_06.permissionname = "Báo cáo xe nằm quá lâu trong bãi";
                REPORT_06.permissiontype = 3;
                REPORT_06.tabMenuId = 4;
                REPORT_06.permissionnote = "Báo cáo xe nằm quá lâu trong bãi";
                lstresult.Add(REPORT_06);



                //Thao tac
                classPermission THAOTAC_01 = new classPermission();
                THAOTAC_01.permissioncheck = false;
                THAOTAC_01.permissioncode = "THAOTAC_01";
                THAOTAC_01.permissionname = "Chỉnh sửa cập nhật nội trú";
                THAOTAC_01.permissiontype = 4;
                THAOTAC_01.tabMenuId = 2;
                THAOTAC_01.permissionnote = "Chỉnh sửa cập nhật nội trú";
                lstresult.Add(THAOTAC_01);

                classPermission THAOTAC_02 = new classPermission();
                THAOTAC_02.permissioncheck = false;
                THAOTAC_02.permissioncode = "THAOTAC_02";
                THAOTAC_02.permissionname = "Cập nhật mất thẻ gửi xe";
                THAOTAC_02.permissiontype = 4;
                THAOTAC_02.tabMenuId = 2;
                THAOTAC_02.permissionnote = "Cập nhật mất thẻ gửi xe";
                lstresult.Add(THAOTAC_02);

                classPermission THAOTAC_03 = new classPermission();
                THAOTAC_03.permissioncheck = false;
                THAOTAC_03.permissioncode = "THAOTAC_03";
                THAOTAC_03.permissionname = "Hủy cập nhật nội trú";
                THAOTAC_03.permissiontype = 4;
                THAOTAC_03.tabMenuId = 2;
                THAOTAC_03.permissionnote = "Hủy cập nhật nội trú";
                lstresult.Add(THAOTAC_03);

                //quan tri: permissiontype = 2 Tools; 5=quan tri
                classPermission TOOL_08 = new classPermission();
                TOOL_08.permissioncheck = false;
                TOOL_08.permissioncode = "TOOL_08";
                TOOL_08.permissionname = "Quản trị - Quản lý thẻ nội trú";
                TOOL_08.permissiontype = 2;
                TOOL_08.tabMenuId = 5;
                TOOL_08.permissionnote = "Quản trị - Quản lý thẻ nội trú";
                // lstresult.Add(TOOL_08);

                classPermission TOOL_09 = new classPermission();
                TOOL_09.permissioncheck = false;
                TOOL_09.permissioncode = "TOOL_09";
                TOOL_09.permissionname = "Cập nhật mất thẻ ngoại trú";
                TOOL_09.permissiontype = 2;
                TOOL_09.tabMenuId = 5;
                TOOL_09.permissionnote = "Cập nhật mất thẻ ngoại trú";
                lstresult.Add(TOOL_09);




            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            return lstresult;
        }

    }
}
