using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23解释器模式
{

    /// <summary>
    /// 抽象解释器
    /// </summary>
    abstract class AbstractExpression
    {
        public abstract void Interprent(InterpreterContext context);
    }
}
