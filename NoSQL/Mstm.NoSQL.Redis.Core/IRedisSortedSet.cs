using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{

    /// <summary>
    /// 提供SortedSet类型相关操作接口
    /// </summary>
    public interface IRedisSortedSet
    {

        /// <summary>
        /// 添加一个SortedSet
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">数据成员</param>
        /// <returns>是否操作成功</returns>
        bool AddSortedSet(string key, Dictionary<string, string> value);


        /// <summary>
        /// 获取指定SortedSet的成员数量
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>成员数量</returns>
        int GetSortedSetCount(string key);


        /// <summary>
        /// 根据分数区间获取指定SortedSet的成员数量
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="minScore">最低分数</param>
        /// <param name="maxScore">最高分数</param>
        /// <param name="containMinScore">区间是否包含最小值</param>
        /// <param name="containMaxScore">区间是否包含最大值</param>
        /// <returns>成员数量</returns>
        int GetSortedSetCount(string key, int minScore, int maxScore, bool containMinScore = true, bool containMaxScore = true);



        /// <summary>
        /// 获取大于指定分数的SortedSet数量
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="minScore">最低分数</param>
        /// <param name="containMinScore">区间是否包含最小值</param>
        /// <returns>成员数量</returns>
        int GetSortedSetCountMoreThan(string key, int minScore, bool containMinScore = true);


        /// <summary>
        /// 获取小于指定分数的SortedSet数量
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="maxScore">最高分数</param>
        /// <param name="containMaxScore">区间是否包含最大值</param>
        /// <returns>成员数量</returns>
        int GetSortedSetCountLessThan(string key, int maxScore, bool containMaxScore = true);



        /// <summary>
        /// 根据索引获取指定SortedSet之中成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="startIndex">开始索引，从0开始计数</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="isReverse">是否进行倒序</param>
        /// <returns>成员集合，不包含分数</returns>
        List<string> GetSortedSetByIndex(string key, int startIndex, int endIndex, bool isReverse = false);


        /// <summary>
        /// 根据索引获取指定SortedSet之中成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="startIndex">开始索引，从0开始计数</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="isReverse">是否进行倒序</param>
        /// <returns>成员集合，包含分数</returns>
        Dictionary<string, string> GetSortedSetByIndexWithScores(string key, int startIndex, int endIndex, bool isReverse = false);



        /// <summary>
        /// 根据分数获取指定SortedSet之中成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="minScore">最低分数</param>
        /// <param name="maxScore">最高分数</param>
        /// <param name="isReverse">是否进行倒序</param>
        /// <returns>成员集合，不包含分数</returns>
        List<string> GetSortedSetByScore(string key, int minScore, int maxScore, bool isReverse = false);


        /// <summary>
        /// 根据分数获取指定SortedSet之中成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="minScore">最低分数</param>
        /// <param name="maxScore">最高分数</param>
        /// <param name="offset">查询起始的偏移量</param>
        /// <param name="count">要返回的数量</param>
        /// <param name="isReverse">是否进行倒序</param>
        /// <returns>成员集合，不包含分数</returns>
        List<string> GetSortedSetByScore(string key, int minScore, int maxScore, int offset, int count, bool isReverse = false);

        /// <summary>
        /// 根据分数获取指定SortedSet之中成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="minScore">最低分数</param>
        /// <param name="maxScore">最高分数</param>
        /// <param name="isReverse">是否进行倒序</param>
        /// <returns>成员集合，包含分数</returns>
        Dictionary<string, string> GetSortedSetByScoreWithScores(string key, int minScore, int maxScore, bool isReverse = false);


        /// <summary>
        /// 根据分数获取指定SortedSet之中成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="minScore">最低分数</param>
        /// <param name="maxScore">最高分数</param>
        /// <param name="offset">查询起始的偏移量</param>
        /// <param name="count">要返回的数量</param>
        /// <param name="isReverse">是否进行倒序</param>
        /// <returns>成员集合，包含分数</returns>
        Dictionary<string, string> GetSortedSetByScoreWithScores(string key, int minScore, int maxScore, int offset, int count, bool isReverse = false);


        /// <summary>
        /// 获取指定SortedSet中指定成员的索引
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="member">成员</param>
        /// <param name="isReverse">是否进行倒序计算</param>
        /// <returns>成员索引</returns>
        int GetIndexForSortedSetMember(string key, string member, bool isReverse = false);


        /// <summary>
        /// 获取指定SortedSet中指定成员的分数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="member">成员</param>
        /// <returns>成员分数</returns>
        int GetScoreForSortedSetMember(string key, string member);



        /// <summary>
        /// 删除指定SortedSet中的成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="members">成员集合</param>
        /// <returns>被删除的成员数量</returns>
        long DeleteSortedSetMembers(string key, params string[] members);


        /// <summary>
        /// 根据索引区间删除指定SortedSet的成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <returns>被删除的成员数量</returns>
        long DeleteSortedSetByIndex(string key, int startIndex, int endIndex);


        /// <summary>
        /// 根据分数区间删除指定SortedSet的成员
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="minScore">最低分数</param>
        /// <param name="maxScore">最高分数</param>
        /// <returns>被删除的成员数量</returns>
        long DeleteSortedSetByScore(string key, int minScore, int maxScore);
    }
}
