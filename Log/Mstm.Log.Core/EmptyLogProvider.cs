using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Log.Core
{
    /// <summary>
    /// 日志组件空实现，不做任何实际操作
    /// </summary>
    public class EmptyLogProvider : ILogProvider
    {
        private EmptyLogProvider() { }

        /// <summary>
        /// 获取一个EmptyLogProvider实例
        /// </summary>
        /// <returns></returns>
        public static ILogProvider New()
        {
            return new EmptyLogProvider();
        }

        public void Debug(object msg)
        {
        }

        public void Debug(object msg, Exception ex)
        {
        }

        public void DebugFormat(string msg, params object[] args)
        {
        }

        public void Error(object msg)
        {
        }

        public void Error(object msg, Exception ex)
        {
        }

        public void ErrorFormat(string msg, params object[] args)
        {
        }

        public void Fatal(object msg)
        {
        }

        public void Fatal(object msg, Exception ex)
        {
        }

        public void FatalFormat(string msg, params object[] args)
        {
        }

        public void Info(object msg)
        {
        }

        public void Info(object msg, Exception ex)
        {
        }

        public void InfoFormat(string msg, params object[] args)
        {
        }

        public void Warn(object msg)
        {
        }

        public void Warn(object msg, Exception ex)
        {
        }

        public void WarnFormat(string msg, params object[] args)
        {
        }
    }
}
