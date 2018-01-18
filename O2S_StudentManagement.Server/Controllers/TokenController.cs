using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using O2S_StudentManagement.Server.Process;
using O2S_StudentManagement.Model.Models;

namespace O2S_StudentManagement.Server.Controllers
{
    [RoutePrefix("api/Token")]
    public class TokenController : ApiController
    {
        [Route("Take")]
        [HttpPost]
        public HttpResponseMessage Take(HttpRequestMessage request, TakeTokenFilterDTO _filter)
        {
            try
            {
                TokenProcess _process = new TokenProcess();
                TakeTokenKetQuaDTO _loiHoSO = _process.TokenTake_Process(_filter);
                var response = request.CreateResponse(HttpStatusCode.OK, _loiHoSO);
                return response;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi khi goi API Token/Take " + ex.ToString());
                return null;
            }
        }
    }
}
