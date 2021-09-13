using Mstm.OAuth.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Weibo
{

    /// <summary>
    /// 微博OAuth服务工厂
    /// </summary>
    public class WeiboOAuthProviderFactory : IOAuthProviderFactory
    {
        /// <summary>
        /// 获取微博OAuth服务接口IOAuthProvider的实例
        /// </summary>
        /// <returns></returns>
        public IOAuthProvider GetThirdPartyProvider()
        {
            return new WeiboOAuthProvider();
        }
    }
}
