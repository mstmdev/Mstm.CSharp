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
    /// 连接关系枚举
    /// </summary>
    public enum ConnectRelationEnum
    {
        [Description("AND")]
        [Operator("AND")]
        And = 1,


        [Description("OR")]
        [Operator("OR")]
        Or = 2
    }
}
