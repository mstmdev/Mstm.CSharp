using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Core
{

    /// <summary>
    /// 创建OAuth服务的工厂接口
    /// </summary>
    public interface IOAuthProviderFactory
    {

        /// <summary>
        /// 获取OAuth服务实例
        /// </summary>
        /// <returns></returns>
        IOAuthProvider GetThirdPartyProvider();

    }
}
