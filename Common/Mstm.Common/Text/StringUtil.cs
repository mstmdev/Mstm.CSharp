using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Text
{
    /// <summary>
    /// 字符串相关处理工具
    /// </summary>
    public class StringUtil
    {
        #region 安全相关

        /// <summary>
        /// 获取SecureString实例
        /// </summary>
        /// <param name="text">加密文本</param>
        /// <returns>SecureString实例</returns>
        public SecureString GetSecureString(string text)
        {
            SecureString secure = new SecureString();
            var chars = text.ToCharArray();
            chars.ToList().ForEach(c => secure.AppendChar(c));
            return secure;
        }

        ///// <summary>
        ///// 解密SecureString
        ///// </summary>
        ///// <param name="secureStr">SecureString实例</param>
        ///// <returns>加密前的数据</returns>
        //public string FromSecureString(SecureString secureStr)
        //{
        //    string text = "";
        //    unsafe
        //    {
        //        IntPtr ptr = new IntPtr();
        //        try
        //        {
        //            ptr = Marshal.SecureStringToCoTaskMemUnicode(secureStr);
        //            Char* pc = (Char*)ptr;

        //            for (int i = 0; pc[i] != 0; i++)
        //            {
        //                text += pc[i];
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            Marshal.ZeroFreeCoTaskMemUnicode(ptr);
        //        }
        //    }
        //    return text;
        //}
        #endregion
    }
}
