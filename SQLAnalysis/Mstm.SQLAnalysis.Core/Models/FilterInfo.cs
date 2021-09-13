using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 筛选条件信息
    /// </summary>
    public class FilterInfo
    {
        /// <summary>
        /// 周期筛选条件集合
        /// </summary>
        public List<CycleFilterInfo> CycleFilterInfoList { get; set; }


        /// <summary>
        /// 正常筛选条件集合
        /// </summary>
        public List<NormalFilterInfo> NormalFilterInfoList { get; set; }


        /// <summary>
        /// 时间点筛选条件集合
        /// </summary>
        public List<PointInTimeFilterInfo> PointInTimeFilterInfoList { get; set; }


        /// <summary>
        /// 排序信息集合
        /// 按照集合的顺序进行排序
        /// </summary>
        public List<OrderInfo> OrderInfoList { get; set; }
    }
}
