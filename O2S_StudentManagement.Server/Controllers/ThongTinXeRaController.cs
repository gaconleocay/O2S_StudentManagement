using O2S_StudentManagement.Model.Models;
using O2S_StudentManagement.Server.Process;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace O2S_StudentManagement.Server.Controllers
{
    [RoutePrefix("api/ThongTinXeRa")]
    public class ThongTinXeRaController : ApiController
    {
        [Route("KiemTraHuongMienPhi")]
        [HttpPost]
        public HttpResponseMessage KiemTraHuongMienPhi(HttpRequestMessage request, KTMienPhiFilterDTO _filterKiemTra)
        {
            try
            {
                KiemTraHuongMienPhi_QLGiuXe _process = new KiemTraHuongMienPhi_QLGiuXe();

                //Common.Logging.LogSystem.Warn("Input_GuiXe: maBN=" + _filterKiemTra.maBenhNhan + " ma the xe=" + _filterKiemTra.maTheGuiXe + " thoi gian=" + _filterKiemTra.thoiGianTagTheRa + " username=" + _filterKiemTra.username + " password=" + _filterKiemTra.password);
                //Validate User name
                if (_filterKiemTra.username == GlobalStore._UserName_QLGuiXe && _filterKiemTra.password == GlobalStore._Password_QLGuiXe)
                {
                    //truong hop khong co ma BN
                    if (_filterKiemTra.maBenhNhan == null || _filterKiemTra.maBenhNhan == "")
                    {
                        _filterKiemTra.maBenhNhan = _process.LayMaBenhNhan(_filterKiemTra.maTheGuiXe);
                    }
                    KTMienPhiKetQua_PlusDTO _loiHoSO = _process.QuyTacGiamDinhProcess_MienPhi(_filterKiemTra);
                    if (_loiHoSO.patientcode != null && _loiHoSO.patientcode != "")
                    {
                        //Luu lai CSDL
                        _process.LuuLaiVaoCoSoDuLieu(_filterKiemTra, _loiHoSO);
                    }
                    KTMienPhiKetQuaDTO _ketquaKiemTra = new KTMienPhiKetQuaDTO();
                    _ketquaKiemTra.maKetQua = _loiHoSO.maKetQua;
                    _ketquaKiemTra.thuHoiThe = _loiHoSO.thuHoiThe;
                    _ketquaKiemTra.ghiChu = _loiHoSO.ghiChu;
                    //Common.Logging.LogSystem.Warn("maKetQua " + _loiHoSO.maKetQua);
                    try
                    {
                        var response = request.CreateResponse(HttpStatusCode.OK, _ketquaKiemTra);
                        return response;
                    }
                    catch (Exception)
                    {
                        var response = request.CreateResponse(HttpStatusCode.Unauthorized);
                        return response;
                    }
                }
                else
                {
                    var response = request.CreateResponse(HttpStatusCode.Forbidden);
                    return response;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API ThongTinXeRa/KiemTraHuongMienPhi " + ex.ToString());
                return null;
            }
        }


        [Route("KiemTraHuongMienPhi_Token")]
        [HttpPost]
        public HttpResponseMessage KiemTraHuongMienPhi_Token(HttpRequestMessage request, KTMienPhiFilterDTO _filterKiemTra)
        {
            try
            {
                //TODO - kiem tra Token
                string _token = System.Web.HttpUtility.ParseQueryString(request.RequestUri.Query).Get("token");
                TokenProcess _tokenProcess = new TokenProcess();
                if (_tokenProcess.TokenCheck_Process(_token))
                {
                    KiemTraHuongMienPhi_QLGiuXe _process = new KiemTraHuongMienPhi_QLGiuXe();
                    KTMienPhiKetQua_PlusDTO _loiHoSO = _process.QuyTacGiamDinhProcess_MienPhi(_filterKiemTra);
                    if (_loiHoSO.patientcode != null && _loiHoSO.patientcode != "")
                    {
                        //Luu lai CSDL
                        _process.LuuLaiVaoCoSoDuLieu(_filterKiemTra, _loiHoSO);
                    }
                    KTMienPhiKetQuaDTO _ketquaKiemTra = new KTMienPhiKetQuaDTO();
                    _ketquaKiemTra.maKetQua = _loiHoSO.maKetQua;

                    var response = request.CreateResponse(HttpStatusCode.OK, _ketquaKiemTra);
                    return response;
                }
                else
                {
                    var response = request.CreateResponse(HttpStatusCode.Forbidden);
                    return response;
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API ThongTinXeRa/KiemTraHuongMienPhi " + ex.ToString());
                return null;
            }
        }

        [Route("KiemTraHuongMienPhiVaThongTinBN")]
        [HttpPost]
        public HttpResponseMessage KiemTraHuongMienPhiVaThongTinBN(HttpRequestMessage request, KTMienPhiFilterDTO _filterKiemTra)
        {
            try
            {
                KiemTraHuongMienPhi_QLGiuXe _process = new KiemTraHuongMienPhi_QLGiuXe();
                KTMienPhiKetQua_PlusDTO _loiHoSO = _process.QuyTacGiamDinhProcess_MienPhi(_filterKiemTra);
                if (_loiHoSO.patientcode != null && _loiHoSO.patientcode != "")
                {
                    //Luu lai CSDL
                    _process.LuuLaiVaoCoSoDuLieu(_filterKiemTra, _loiHoSO);
                }
                if (_loiHoSO.thuHoiThe == 1)
                {
                    _loiHoSO.thuHoiThe_Ten = " [Thu lại thẻ gửi xe]";
                }
                var response = request.CreateResponse(HttpStatusCode.OK, _loiHoSO);
                return response;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API ThongTinXeRa/KiemTraHuongMienPhiVaThongTinBN " + ex.ToString());
                return null;
            }
        }

    }
}
