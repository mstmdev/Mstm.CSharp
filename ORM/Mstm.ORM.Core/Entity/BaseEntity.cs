using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core.Entity
{
    /// <summary>
    /// 实体公共基类
    /// </summary>
    public class BaseEntity : IEntity, ICreateRecord, IModifyRecord, IDeleted
    {
        #region ICreateRecord
        /// <summary>
        /// 记录创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        public long CreateUserId { get; set; }

        /// <summary>
        /// 创建人的用户名
        /// </summary>
        public string CreateUserName { get; set; }
        #endregion

        #region IModifyRecord
        /// <summary>
        /// 记录修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        public long ModifyUserId { get; set; }

        /// <summary>
        /// 修改人的用户名
        /// </summary>
        public string ModifyUserName { get; set; }

        /// <summary>
        /// 当前行记录的哈希值
        /// </summary>
        public string RecordHash { get; set; }
        #endregion

        #region IDeleted
        /// <summary>
        /// 记录是否逻辑删除
        /// </summary>
        public bool IsDeleted { get; set; }
        #endregion
    }
}
