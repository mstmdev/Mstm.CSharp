using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05工厂方法模式
{
    class WeChatOAuthService : IOAuthService
    {
        public string GetTokenByCode(string code, string appId)
        {
            return "WeChat Token";
        }

        public string GetOpenIdByToken(string token, string appId, string appKey)
        {
            return "WeChat OpenId";
        }

        public T GetUserInfoByOpenId<T>(string openId, string token, string appId, string appKey)
        {
            return default(T);
        }
    }
}
