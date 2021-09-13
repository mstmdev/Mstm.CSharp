using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Model
{

    /// <summary>
    /// 应用程序域相关信息
    /// </summary>
    public class AppDomainInfo
    {
        /// <summary>
        /// 获取上次回收后保留下来的，已知由当前应用程序域引用的字节数
        /// </summary>
        public long MonitoringSurvivedMemorySize { get; set; }

        /// <summary>
        /// 获取自从创建应用程序域后由应用程序域进行的所有内存分配的总大小（以字节为单位，不扣除已回收的内存）
        /// </summary>
        public long MonitoringTotalAllocatedMemorySize { get; set; }

        /// <summary>
        ///  获取进程中所有应用程序域的上次回收后保留下来的总字节数
        /// </summary>
        public long MonitoringSurvivedProcessMemorySize { get; set; }

        /// <summary>
        /// 获取自从进程启动后所有线程在当前应用程序域中执行时所使用的总处理器时间
        /// </summary>
        public TimeSpan MonitoringTotalProcessorTime { get; set; }
    }
}
