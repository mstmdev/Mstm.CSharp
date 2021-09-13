using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Core
{

    /// <summary>
    /// Http客户端工厂接口
    /// </summary>
    public interface IHttpClientFactory
    {

        /// <summary>
        /// 获取Http客户端实例
        /// </summary>
        /// <returns></returns>
        IHttpClient GetHttpClient();
    }
}
