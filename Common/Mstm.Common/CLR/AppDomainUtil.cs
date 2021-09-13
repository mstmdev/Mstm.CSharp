using Mstm.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.CLR
{
    /// <summary>
    /// 应用程序域工具类
    /// </summary>
    public class AppDomainUtil
    {
        /// <summary>
        /// 获取当前应用程序域的监视信息
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static AppDomainInfo GetMonitorInfo(AppDomain domain)
        {
            if (AppDomain.MonitoringIsEnabled == false)
            {
                AppDomain.MonitoringIsEnabled = true;
            }
            domain = domain ?? AppDomain.CurrentDomain;
            AppDomainInfo appDomainInfo = new AppDomainInfo();
            appDomainInfo.MonitoringSurvivedMemorySize = domain.MonitoringSurvivedMemorySize;
            appDomainInfo.MonitoringTotalAllocatedMemorySize = domain.MonitoringTotalAllocatedMemorySize;
            appDomainInfo.MonitoringSurvivedProcessMemorySize = AppDomain.MonitoringSurvivedProcessMemorySize;
            appDomainInfo.MonitoringTotalProcessorTime = domain.MonitoringTotalProcessorTime;
            return appDomainInfo;

        }
    }
}
