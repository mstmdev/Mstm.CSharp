using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 统计筛选信息
    /// </summary>
    public class StatisticsInfo
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }


        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }


        /// <summary>
        /// 查询关系
        /// </summary>
        public StatisticsRelationEnum StatisticsRelation { get; set; }

    }
}
