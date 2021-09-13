using Mstm.ORM.Core.Attributes;
using Mstm.ORM.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core.Tests.Common
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Table("UserInfo")]
    public class UserInfoEntity : BaseEntity
    {
        /// <summary>
        /// 用户Id 主键
        /// </summary>
        [PK]
        public long UserId { get; set; }

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string UserIdentity { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码原文
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 加密后的密码
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// 用户激活码
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 推荐人用户Id
        /// </summary>
        public long ReferralUserId { get; set; }

        /// <summary>
        /// 用户的状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 状态描述
        /// </summary>
        public string StateDesc { get; set; }

    }
}
