using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 排序信息
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }


        /// <summary>
        /// 排序方式
        /// </summary>
        public OrderModeEnum OrderMode { get; set; }
    }
}
