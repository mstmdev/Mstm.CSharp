using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Weibo
{

    /// <summary>
    /// 微博Token响应Model
    /// </summary>
    class WeiboTokenResponse
    {

        /// <summary>
        /// 用于调用access_token，接口获取授权后的access token。
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// access_token的生命周期（该参数即将废弃，开发者请使用expires_in）。
        /// </summary>
        [JsonProperty("remind_in")]
        public string RemindIn { get; set; }

        /// <summary>
        /// access_token的生命周期，单位是秒数。
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// 当前授权用户的UID。
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; set; }
    }
}
