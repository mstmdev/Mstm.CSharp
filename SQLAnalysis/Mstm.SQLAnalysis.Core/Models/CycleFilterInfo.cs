using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 周期筛选条件
    /// </summary>
    public class CycleFilterInfo
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }



        /// <summary>
        /// 查询关系
        /// </summary>
        public CycleWhereRelationEnum CycleRelation { get; set; }


        /// <summary>
        /// 最小值
        /// 注意：周日为每星期的第一天即值为1
        /// </summary>
        public int MinValue { get; set; }


        /// <summary>
        /// 最大值
        /// 注意：周日为每星期的第一天即值为1
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// 连接关系
        /// </summary>
        public ConnectRelationEnum ConnectRelation { get; set; }
    }
}
