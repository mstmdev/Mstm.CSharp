using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Core
{

    /// <summary>
    /// OAuth认证响应基类
    /// </summary>
    public class OAuthResponseBase
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty("error")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
