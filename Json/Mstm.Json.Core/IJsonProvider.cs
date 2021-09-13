using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Json.Core
{

    /// <summary>
    /// 序列化提供器接口
    /// </summary>
    public interface IJsonProvider
    {
        /// <summary>
        /// 对象序列化为字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="data">待序列化的对象</param>
        /// <returns>序列化后的字符串</returns>
        string SerializeObject<T>(T data);


        /// <summary>
        /// 将字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="jsonStr">待反序列化的字符串</param>
        /// <returns>序列化后的对象</returns>
        T DeserializeObject<T>(string jsonStr);
    }
}
