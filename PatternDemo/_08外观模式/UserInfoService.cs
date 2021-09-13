using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08外观模式
{
    class UserInfoService
    {
        /// <summary>
        /// 根据第三方唯一表示获取用户名
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string GetUserNameByThirdUid(string uid)
        {
            return "Coco";
        }
    }
}
