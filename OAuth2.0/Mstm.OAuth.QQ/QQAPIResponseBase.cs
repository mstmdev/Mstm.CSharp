using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.QQ
{

    /// <summary>
    /// QQ响应模型基类
    /// </summary>
    public class QQAPIResponseBase
    {
        /// <summary>
        /// 返回码
        /// http://wiki.connect.qq.com/公共返回码说明
        /// </summary>
        [JsonProperty("ret")]
        public string Ret { get; set; }

        /// <summary>
        /// 如果ret小于0，会有相应的错误信息提示，返回数据全部用UTF-8编码。
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
