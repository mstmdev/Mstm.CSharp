using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01简单工厂模式
{
    class OperationFactory
    {
        public static OperationBase GetCalc(string operaStr)
        {
            switch (operaStr)
            {
                case "+":
                    return new OperationAdd();
                case "-":
                    return new OperationSub();
                case "*":
                    return new OperationMulti();
                case "/":
                    return new OperationDiv();
                default:
                    return null;
            }
        }
    }
}
