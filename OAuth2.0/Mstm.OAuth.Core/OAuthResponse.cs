using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Core
{
    /// <summary>
    /// OAuth响应数据Model
    /// </summary>
    public class OAuthResponse : OAuthResponseBase
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 客户端网站标识
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }


        /// <summary>
        /// 登录用户在第三方平台的唯一标识
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }
    }
}
