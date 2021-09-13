using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Web.AspNetCore.Session
{
    /// <summary>
    /// Session操作接口
    /// </summary>
    public interface ISessionStorage
    {
        /// <summary>
        /// 获取Session中指定键的值
        /// </summary>
        /// <typeparam name="T">返回的类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>Session中存储的值</returns>
        T Get<T>(string key);

        /// <summary>
        /// 设置一个Session键值
        /// </summary>
        /// <typeparam name="T">要保存的数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">保存的值</param>
        /// <param name="cacheMinutes">缓存时间</param>
        void Set<T>(string key, T value, int cacheMinutes = 60 * 24);

        /// <summary>
        /// 获取Session中指定键的String值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        string GetString(string key);

        /// <summary>
        /// 设置一个String类型的Session
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要保存的字符串</param>
        /// <param name="cacheMinutes">缓存的时间</param>
        void SetString(string key, string value, int cacheMinutes = 60 * 24);

    }
}
