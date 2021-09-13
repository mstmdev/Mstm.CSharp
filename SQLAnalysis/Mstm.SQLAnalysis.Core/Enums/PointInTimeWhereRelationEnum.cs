using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 时间点过滤枚举
    /// </summary>
    public enum PointInTimeWhereRelationEnum
    {
        BeforeYear = 1,
        BeforeMonth = 2,
        BeforeDay = 3,
        BeforeHour = 4,
        InYear = 5,
        InMonth = 6,
        InDay = 7,
        InHour = 8
    }
}
