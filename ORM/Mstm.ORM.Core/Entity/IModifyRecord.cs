using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core.Entity
{
    /// <summary>
    /// 记录用户数据修改信息
    /// </summary>
    public interface IModifyRecord
    {
        /// <summary>
        /// 记录修改时间
        /// </summary>
        DateTime ModifyTime { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        long ModifyUserId { get; set; }

        /// <summary>
        /// 修改人的用户名
        /// </summary>
        string ModifyUserName { get; set; }

        /// <summary>
        /// 当前行记录的哈希值
        /// </summary>
        string RecordHash { get; set; }
    }
}
