using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{

    /// <summary>
    /// 提供String类型相关操作接口
    /// </summary>
    public interface IRedisString
    {
        /// <summary>
        /// 根据键获取字符数据
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>Redis中存储的字符数据</returns>
        string GetString(string key);

        /// <summary>
        /// 写入字符串到Redis缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要存储的字符数据</param>
        /// <param name="cacheMinutes">缓存的时间，单位分钟，如果不传递或小于等于0，则默认不过期</param>
        void SetString(string key, string value, double cacheMinutes = -1);


        /// <summary>
        /// 将对象序列化后存储到Redis中
        /// </summary>
        /// <typeparam name="T">存储对象的类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">存储的对象</param>
        /// <param name="cacheMinutes">缓存的时间，单位分钟，如果不传递或小于等于0，则默认不过期</param>
        void SetData<T>(string key, T value, double cacheMinutes = -1);


        /// <summary>
        /// 根据键获取Redis中对象数据
        /// </summary>
        /// <typeparam name="T">获取的对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>反序列化后的对象实例</returns>
        T GetData<T>(string key);


        /// <summary>
        /// 判断指定键的字符数据是否已经存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>键是否存在</returns>
        bool IsExistString(string key);


        /// <summary>
        /// 根据键删除一个字符数据
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>删除操作是否成功</returns>
        bool DeleteString(string key);


        /// <summary>
        /// 在指定键的数据后添加字符
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="appendStr">附加的字符</param>
        /// <returns>最终存储的字符结果</returns>
        string AppendString(string key, string appendStr);

        /// <summary>
        /// 获取byte数组
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>存储的byte数组</returns>
        byte[] GetBytes(string key);


        /// <summary>
        /// 设置byte数组
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要存储的byte数组</param>
        /// <param name="cacheMinutes">缓存的时间，单位分钟，如果不传递或小于等于0，则默认不过期</param>
        void SetBytes(string key, byte[] value, double cacheMinutes = -1);


    }
}
