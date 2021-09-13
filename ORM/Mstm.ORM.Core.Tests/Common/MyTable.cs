using Mstm.ORM.Core.Attributes;
using Mstm.ORM.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core.Tests.Common
{
    [Table("CustomerInfo")]
    public class MyTable : BaseEntity
    {
        /// <summary>
        /// 用户Id 主键
        /// </summary>
        [PK]
        public long UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户的状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 用户状态描述
        /// </summary>
        [Ignore]
        public string StateDesc { get; set; }

    }
}
