using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 标准的筛选条件枚举
    /// </summary>
    public enum NormalWhereRelationEnum
    {
        /// <summary>
        /// 等于
        /// </summary>
        Equal = 1,

        /// <summary>
        /// In
        /// </summary>
        In = 2,

        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual = 3,

        /// <summary>
        /// 小于
        /// </summary>
        LessThan = 4,

        /// <summary>
        /// 小于等于
        /// </summary>
        LessThanOrEqual = 5,

        /// <summary>
        /// 大于
        /// </summary>
        MoreThan = 6,

        /// <summary>
        /// 大于等于
        /// </summary>
        MoreThanOrEqual = 7,

        /// <summary>
        /// Like模糊查询
        /// </summary>
        Like = 8,

        /// <summary>
        /// Like前缀 %kw
        /// </summary>
        LikePrefix = 9,

        /// <summary>
        /// Like后缀  kw%
        /// </summary>
        LikeSuffix = 10,

        /// <summary>
        /// 模糊查询后取反
        /// </summary>
        NotLike = 11,

        /// <summary>
        /// Like前缀 %kw  并取反
        /// </summary>
        NotLikePrefix = 12,

        /// <summary>
        /// Like后缀  kw%  并取反
        /// </summary>
        NotLikeSuffix = 13,

        /// <summary>
        /// 为空值
        /// </summary>
        IsNull = 14,

        /// <summary>
        /// 不为空
        /// </summary>
        IsNotNull = 15
    }
}
