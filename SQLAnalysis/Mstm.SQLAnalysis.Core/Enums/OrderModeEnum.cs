using Mstm.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 排序方式
    /// </summary>
    public enum OrderModeEnum
    {

        /// <summary>
        /// 降序排序
        /// </summary>
        [Description("降序排序")]
        [Operator("DESC")]
        Desc = 1,


        /// <summary>
        /// 升序排序
        /// </summary>
        [Description("升序排序")]
        [Operator("ASC")]
        Asc = 2
    }
}
