using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace O2S_CarParking.Server.Controllers
{
    [RoutePrefix("api/DuLieuDungChung")]
    public class DuLieuDungChungController : ApiController
    {
        //ngay 11/9/2017
        [Route("LayDuLieuTuCSDL")]
        [HttpGet]
        public HttpResponseMessage LayDuLieuTuCSDL(HttpRequestMessage request, string _loaidulieu)
        {
            try
            {
                //
                switch (_loaidulieu)
                {
                    case "ie_danhmuc_dvkt":
                        {
                            Base.LayDuLieuTuCSDLProcess.Get_DanhSachDVKTPheDuyet();
                            Base.LayDuLieuTuCSDLProcess.GopDanhMucDVKTVaGiuong();
                            break;
                        }
                    case "ie_danhmuc_giuong":
                        {
                            Base.LayDuLieuTuCSDLProcess.Get_DanhSachGiuongPheDuyet();
                            Base.LayDuLieuTuCSDLProcess.GopDanhMucDVKTVaGiuong();
                            break;
                        }
                    case "ie_danhmuc_thuoc":
                        {
                            Base.LayDuLieuTuCSDLProcess.Get_DanhSachThuocPheDuyet();
                            break;
                        }
                    case "ie_danhmuc_vattu":
                        {
                            Base.LayDuLieuTuCSDLProcess.Get_DanhSachVatTuPheDuyet();
                            break;
                        }
                    case "ie_qtgd_hoso":
                        {
                            Base.LayDuLieuTuCSDLProcess.Get_QuyTacGiamDinh_HoSo();
                            break;
                        }
                    case "ie_hsba_xml1":
                        {
                            Base.LayDuLieuTuCSDLProcess.Get_TheFileXML1();
                            break;
                        }
                    case "cp_config":
                        {
                            Base.LayDuLieuTuCSDLProcess.Get_ThongTinVeTaiKhoan_CongBHYT();
                            break;
                        }
                    default:
                        break;
                }

                var response = request.CreateResponse(HttpStatusCode.OK,"Thành công!");
                return response;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API LayDuLieuTuCSDL/LayDuLieuTuCSDL " + ex.ToString());
                return null;
            }
        }
    }
}
