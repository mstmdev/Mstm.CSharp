using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// SQL语句构建接口
    /// </summary>
    public interface ISQLSyntaxAnalysisProvider
    {

        /// <summary>
        /// 构建完整的where语句
        /// </summary>
        /// <param name="filterInfo">筛选条件</param>
        /// <returns>带where的完整的筛选语句</returns>
        string BuildWhere(FilterInfo filterInfo);


        /// <summary>
        /// 构建普通的where语句
        /// </summary>
        /// <param name="filters">所有筛选条件集合</param>
        /// <returns>不带where的筛选语句</returns>
        string BuildNormalWhere(List<NormalFilterInfo> filters);


        /// <summary>
        /// 构建周期类型的where语句
        /// </summary>
        /// <param name="filters">所有筛选条件集合</param>
        /// <returns>不带where的筛选语句</returns>
        string BuildCycleWhere(List<CycleFilterInfo> filters);



        /// <summary>
        /// 构建时间点类型的where语句
        /// </summary>
        /// <param name="filters">所有筛选条件集合</param>
        /// <returns>不带where的筛选语句</returns>
        string BuildPointInTimeWhere(List<PointInTimeFilterInfo> filters);


        /// <summary>
        /// 构建统计语句
        /// </summary>
        /// <param name="filter">统计的条件</param>
        /// <returns>带select的统计语句，如 select count(*) from userinfo </returns>
        string BuildStatistics(StatisticsInfo info);


        /// <summary>
        /// 构建排序语句
        /// </summary>
        /// <param name="info">排序信息集合，按集合的顺序排序</param>
        /// <returns>排序sql语句</returns>
        string BuildOrder(List<OrderInfo> orderList);


        /// <summary>
        /// 构建select语句
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="fieldList">需要查询的字段集合，如果为空或者长度等于0则查询所有字段</param>
        /// <returns>select语句</returns>
        string BuildSelect(string source, List<string> fieldList = null);

    }
}
