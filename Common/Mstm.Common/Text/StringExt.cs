using Mstm.Common.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 字符串相关扩展
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// 将当前字符转换为指定编码的byte数组，默认编码为utf8
        /// </summary>
        /// <param name="source"></param>
        /// <param name="encoding">字符编码，默认为utf8</param>
        /// <returns></returns>
        public static byte[] Bytes(this string source, Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding.Enconding;
            return encoding.GetBytes(source);
        }

        /// <summary>
        /// 将byte数组以utf8的编码转化为字符串，默认编码为utf8
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding">字符编码，默认为utf8</param>
        /// <returns></returns>
        public static string Str(this byte[] bytes, Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding.Enconding;
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 将byte集合以utf8的编码转化为字符串，默认编码为utf8
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding">字符编码，默认为utf8</param>
        /// <returns></returns>
        public static string Str(this IEnumerable<byte> bytes, Encoding encoding = null)
        {
            encoding = encoding ?? DefaultEncoding.Enconding;
            return encoding.GetString(bytes.ToArray());
        }
    }
}
