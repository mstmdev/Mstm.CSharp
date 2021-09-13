using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Core
{

    /// <summary>
    /// 默认Http客户端工厂
    /// </summary>
    public class DefaultHttpClientFactory : IHttpClientFactory
    {
        /// <summary>
        /// 获取IHttpClient实例
        /// </summary>
        /// <returns></returns>
        public IHttpClient GetHttpClient()
        {
#if NET47
            return new DefaultHttpClient();
#else
            throw new Exception("当前框架暂未实现对应的HttpClient");
#endif
        }
    }
}
