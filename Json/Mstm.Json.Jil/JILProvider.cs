using Jil;
using Mstm.Json.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Json.Jil
{
    /// <summary>
    /// jil序列化器实现
    /// </summary>
    public class JILProvider : IJsonProvider
    {
        /// <summary>
        /// 将Json字符串反序列化为指定的类型实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="jsonStr">待反序列化的Json字符串</param>
        /// <returns>反序列化后的对象实例</returns>
        public T DeserializeObject<T>(string jsonStr)
        {
            T obj = JSON.Deserialize<T>(jsonStr);
            return obj;
        }

        /// <summary>
        /// 将指定的对象序列化为Json字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="data">对象实例</param>
        /// <returns>序列化后的Json串</returns>
        public string SerializeObject<T>(T data)
        {
            string json = JSON.Serialize(data);
            return json;
        }
    }
}
