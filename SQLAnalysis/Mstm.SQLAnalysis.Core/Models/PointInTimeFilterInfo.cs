using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 时间点筛选条件
    /// </summary>
    public class PointInTimeFilterInfo
    {

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }


        /// <summary>
        /// 查询关系
        /// </summary>
        public PointInTimeWhereRelationEnum PointInTimeWhereRelation { get; set; }


        /// <summary>
        /// 查询关系值
        /// </summary>
        public int WhereValue { get; set; }


        /// <summary>
        /// 连接关系
        /// </summary>
        public ConnectRelationEnum ConnectRelation { get; set; }
    }
}
