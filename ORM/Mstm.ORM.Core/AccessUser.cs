using Mstm.ORM.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core
{
    /// <summary>
    /// 当前访问的用户信息
    /// </summary>
    public class AccessUser
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户唯一标识,暂未启用
        /// </summary>
        public string UserIdentity { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 当前操作用户解析器
        /// 如果为空则系统使用默认的信息填充，代表用户未登录
        /// </summary>
        public static Func<AccessUser> ResolveAssessUser { get; set; }

        /// <summary>
        /// 通过解析器解析出来的用户信息，如果解析为空则会使用默认的信息填充
        /// </summary>
        public static AccessUser DefaultUser
        {
            get
            {
                AccessUser user = null;
                AccessUser defaultUser = new AccessUser()
                {
                    UserId = -999,
                    UserIdentity = "DE986881-D8E0-48FA-97B6-19DD4AE0DF2D",
                    UserName = "DefaultSystemUser"
                };
                if (ResolveAssessUser != null)
                {
                    try
                    {
                        user = ResolveAssessUser();
                    }
                    catch (Exception ex)
                    {
                        //出现异常则设置为null
                        user = null;
                        DefaultLog<AccessUser>.Logger.Error("解析当前访问用户信息异常", ex);
                    }
                }
                return user ?? defaultUser;
            }
        }
    }
}
