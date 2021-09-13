using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core.Entity
{
    /// <summary>
    /// 逻辑删除
    /// </summary>
    public interface IDeleted
    {
        /// <summary>
        /// 记录是否逻辑删除
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
