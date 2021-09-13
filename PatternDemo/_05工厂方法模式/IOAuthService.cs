using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05工厂方法模式
{
    interface IOAuthService
    {
        /// <summary>
        /// 根据code换取token
        /// </summary>
        /// <param name="code"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        string GetTokenByCode(string code, string appId);

        /// <summary>
        /// 根据Token换取OpenId
        /// </summary>
        /// <param name="token"></param>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        string GetOpenIdByToken(string token, string appId, string appKey);

        /// <summary>
        /// 根据OpenID获得用户信息
        /// </summary>
        /// <typeparam name="T">用户信息类型</typeparam>
        /// <param name="openId"></param>
        /// <param name="token"></param>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        T GetUserInfoByOpenId<T>(string openId, string token, string appId, string appKey);
    }
}
