using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08外观模式
{
    class SignInLogService
    {
        public void WriteSignInLog(string userName)
        {
            Console.WriteLine(string.Format("{0} 于 {1} 登陆本系统！", userName, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
        }
    }
}
