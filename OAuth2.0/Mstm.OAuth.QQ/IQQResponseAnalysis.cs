using Mstm.OAuth.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.QQ
{

    /// <summary>
    /// QQ响应数据解析器接口
    /// </summary>
    interface IQQResponseAnalysis
    {

        /// <summary>
        /// 解析AccessToken
        /// </summary>
        /// <param name="msg">QQ互联响应的消息</param>
        /// <returns>响应Model</returns>
        OAuthResponse AnalysisAccessToken(string msg);

        /// <summary>
        /// 解析OpenId
        /// </summary>
        /// <param name="msg">QQ互联响应的消息</param>
        /// <returns>响应Model</returns>
        OAuthResponse AnalysisOpenId(string msg);

    }
}
