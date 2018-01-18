using JWT;
using JWT.Serializers;
using O2S_StudentManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace O2S_StudentManagement.Server.Process
{
    public class TokenProcess
    {
        private Base.ConnectDatabase condb = new Base.ConnectDatabase();

        internal TakeTokenKetQuaDTO TokenTake_Process(TakeTokenFilterDTO _filter)
        {
            TakeTokenKetQuaDTO result = new TakeTokenKetQuaDTO();
            try
            {
                DateTime _expires_in = DateTime.Now.AddHours(5);
                long _expires_in_long = Common.TypeConvert.TypeConvertParse.ToInt64(_expires_in.ToString("yyyyMMddHHmmss"));
                var payload = new Dictionary<string, object>
                {
                    { "iss", "OneOne solution co., ltd" },
                    { "sub", "Ket noi PM QL Bai gui xe" },
                    { "user", _filter.username },
                    { "pass", _filter.password },
                    { "exp", _expires_in_long }
                };

                IJwtAlgorithm algorithm = new JWT.Algorithms.HMACSHA256Algorithm();
                IJsonSerializer serializer = new JWT.Serializers.JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                var token = encoder.Encode(payload, GlobalStore.SecretToken);

                result.trangThai = 1;
                result.APIKey = new TokenTakeDTO();
                result.APIKey.access_token = token;
                result.APIKey.id_token = token;
                result.APIKey.expires_in = _expires_in;
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi Xu ly API TokenTake_Process Process" + ex.ToString());
            }
            return result;
        }

        internal bool TokenCheck_Process(string access_token)
        {
            bool result = false;
            try
            {
                if (GlobalStore.UserName_QLGuiXe == null)
                {
                    Base.LayDuLieuTuCSDLProcess.Get_ThongTinVeTaiKhoan_QLGuiXe();
                }
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var payload = decoder.DecodeToObject<IDictionary<string, object>>(access_token, GlobalStore.SecretToken, true);

                //Validate User name va thoi gian het han cua token.
                if (payload["user"].ToString()==GlobalStore.UserName_QLGuiXe && payload["pass"].ToString() == GlobalStore.Password_QLGuiXe_MD5)
                {
                    long _expires_in_long = Common.TypeConvert.TypeConvertParse.ToInt64(payload["exp"].ToString());
                    long _timenow = Common.TypeConvert.TypeConvertParse.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    if (_expires_in_long>=_timenow)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error("Loi Check token Process" + ex.ToString());
            }
            return result;
        }
    }
}