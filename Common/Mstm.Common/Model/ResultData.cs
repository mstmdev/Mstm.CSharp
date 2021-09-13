using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Model
{
    /// <summary>
    /// 统一操作结果
    /// </summary>
    public class ResultData
    {
        /// <summary>
        /// 服务是否出错
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// 响应代码，0表示正常，小于0为服务出错代码，大于0为业务代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应代码对应的提示消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 服务返回的数据
        /// </summary>
        public object Data { get; set; }
    }
}
