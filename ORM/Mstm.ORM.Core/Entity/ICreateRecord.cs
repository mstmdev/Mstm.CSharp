using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core.Entity
{
    /// <summary>
    /// 记录用户数据创建信息
    /// </summary>
    public interface ICreateRecord
    {
        /// <summary>
        /// 记录创建时间
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        long CreateUserId { get; set; }
        
        /// <summary>
        /// 创建人的用户名
        /// </summary>
        string CreateUserName { get; set; }
    }
}
