using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08外观模式
{
    /// <summary>
    /// 通过Facade组件对数据库服务、OAuth服务、日志服务进行封装
    /// 提供给客户端统一的操作接口
    /// </summary>
    public class Facade
    {
        UserInfoService userService;
        OAuthService oauthService;
        SignInLogService logService;
        public Facade()
        {
            userService = new UserInfoService();
            oauthService = new OAuthService();
            logService = new SignInLogService();
        }

        public void Login(string code)
        {
            string uid = oauthService.SignIn(code);
            string userName = userService.GetUserNameByThirdUid(uid);
            logService.WriteSignInLog(userName);
        }
    }
}
