using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Enums
{
    /// <summary>
    /// 定义操作符
    /// </summary>
    public class OperatorAttribute : Attribute
    {
        private string _operatorStr;

        public OperatorAttribute(string operatorStr)
        {
            if (string.IsNullOrWhiteSpace(operatorStr))
            {
                throw new ArgumentException("操作符不能为空！", "operatorStr");
            }
            this._operatorStr = operatorStr;
        }


        /// <summary>
        /// 操作符
        /// </summary>
        public string Operation
        {
            get
            {
                return _operatorStr;
            }
        }
    }
}
