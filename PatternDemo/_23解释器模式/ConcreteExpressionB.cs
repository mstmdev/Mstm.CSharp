using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _23解释器模式
{

    /// <summary>
    /// 解释小写字母的解释器
    /// </summary>
    class ConcreteExpressionB : AbstractExpression
    {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        public ConcreteExpressionB()
        {
            for (int i = 97; i <= 122; i++)
            {
                string single = ((char)i).ToString();
                string target = ((i - 10) % 80).ToString();
                _dict.Add(single, target);
            }
        }

        public override void Interprent(InterpreterContext context)
        {
            string regx = "[a-z]";
            if (context != null && string.IsNullOrEmpty(context.Output) == false)
            {
                context.Output = Regex.Replace(context.Output, regx, new MatchEvaluator((match) =>
                 {
                     var value = match.Value;
                     return _dict[value];
                 }));
            }

        }
    }
}
