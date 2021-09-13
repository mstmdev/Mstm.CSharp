using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Text
{
    /// <summary>
    /// 常用加解密工具类
    /// </summary>
    public class EncryptUtil
    {
        /// <summary>
        /// 计算MD5值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string input)
        {
            if (input == null) { input = ""; }
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] md5Bytes = md5.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach (var item in md5Bytes)
            {
                builder.Append(item.ToString("x2"));
            }
            string md5Str = builder.ToString();
            return md5Str;
        }
    }
}
