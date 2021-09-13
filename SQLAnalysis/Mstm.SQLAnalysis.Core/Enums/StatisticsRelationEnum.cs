using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 统计关系枚举
    /// </summary>
    public enum StatisticsRelationEnum
    {
        [Description("计数")]
        Count = 1,

        [Description("总计")]
        Sum = 2,

        [Description("最大值")]
        Max = 3,

        [Description("最小值")]
        Min = 4,

        [Description("平均数")]
        Avg = 5
    }
}
