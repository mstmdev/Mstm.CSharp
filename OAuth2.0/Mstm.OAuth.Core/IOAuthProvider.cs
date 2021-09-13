using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Core
{

    /// <summary>
    /// OAuth服务接口
    /// </summary>
    public interface IOAuthProvider
    {

        /// <summary>
        /// 生成登录地址
        /// </summary>
        /// <param name="state">用于校验的state参数 由用户随机生成</param>
        /// <returns>登录地址</returns>
        string GenerateLoginUrl(string state);

        /// <summary>
        /// 根据code获取必要的授权信息
        /// </summary>
        /// <param name="code">授权code</param>
        /// <returns>授权信息</returns>
        OAuthResponse GetOAuthResponse(string code);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <typeparam name="T">用户信息Model</typeparam>
        /// <param name="token">认证成功后获取的Token</param>
        /// <param name="openId">该用户在第三方用户系统的唯一标识</param>
        /// <returns>用户信息</returns>
        T GetUserInfo<T>(string token, string openId);
    }
}
