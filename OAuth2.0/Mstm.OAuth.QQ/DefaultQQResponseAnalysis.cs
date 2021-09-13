using Mstm.OAuth.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mstm.OAuth.QQ
{

    /// <summary>
    /// QQ响应数据解析器
    /// </summary>
    class DefaultQQResponseAnalysis : IQQResponseAnalysis
    {

        /// <summary>
        /// 解析腾讯响应的AccessToken信息
        /// access_token=2BC2F59**********BEF95591&expires_in=7776000&refresh_token=7FED6***********F88660FB7C7
        /// callback( {"error":100020,"error_description":"code is reused error"} );
        /// </summary>
        /// <param name="msg">token信息</param>
        /// <returns>解析的结果</returns>
        public OAuthResponse AnalysisAccessToken(string msg)
        {
            if (string.IsNullOrEmpty(msg)) { return null; }
            string pattern_error = "callback\\( {\"error\":(\\d+),\"error_description\":\"(.+)\"} \\)";
            string pattern_success = "access_token=([A-Za-z0-9]+)&expires_in=(\\d+)&refresh_token=([A-Za-z0-9]+)";
            var match_error = Regex.Match(msg, pattern_error);
            if (match_error != null && match_error.Groups.Count == 3)
            {
                return new OAuthResponse()
                {
                    ErrorCode = match_error.Groups[1].Value,
                    ErrorDescription = match_error.Groups[2].Value
                };
            }
            var match_success = Regex.Match(msg, pattern_success);
            if (match_success != null && match_success.Groups.Count == 4)
            {
                return new OAuthResponse()
                {
                    ErrorCode = "0",
                    ErrorDescription = "success",
                    AccessToken = match_success.Groups[1].Value,
                    ExpiresIn = match_success.Groups[2].Value,
                    RefreshToken = match_success.Groups[3].Value
                };
            }
            return null;
        }


        /// <summary>
        /// 从响应中解析出OpenId
        /// callback( {"client_id":"101111163","openid":"B60E8C*************3AF8F90971"} );
        /// callback( {"error":100016,"error_description":"access token check failed"} );
        /// </summary>
        /// <param name="msg">收到的响应消息</param>
        /// <returns>解析后的消息对象</returns>
        public OAuthResponse AnalysisOpenId(string msg)
        {
            if (string.IsNullOrEmpty(msg)) { return null; }
            string pattern_error = "callback\\( {\"error\":(\\d+),\"error_description\":\"(.+)\"} \\)";
            string pattern_success = "callback\\( {\"client_id\":\"(\\d+)\",\"openid\":\"([A-Za-z0-9]+)\"} \\)";
            var match_error = Regex.Match(msg, pattern_error);
            if (match_error != null && match_error.Groups.Count == 3)
            {
                return new OAuthResponse()
                {
                    ErrorCode = match_error.Groups[1].Value,
                    ErrorDescription = match_error.Groups[2].Value
                };
            }
            var match_success = Regex.Match(msg, pattern_success);
            if (match_success != null && match_success.Groups.Count == 3)
            {
                return new OAuthResponse()
                {
                    ErrorCode = "0",
                    ErrorDescription = "success",
                    ClientId = match_success.Groups[1].Value,
                    OpenId = match_success.Groups[2].Value
                };
            }
            return null;

        }
    }
}
