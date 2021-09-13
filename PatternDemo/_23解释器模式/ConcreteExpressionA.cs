using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _23解释器模式
{
    /// <summary>
    /// 解释大写字母的解释器
    /// </summary>
    class ConcreteExpressionA : AbstractExpression
    {

        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        public ConcreteExpressionA()
        {
            for (int i = 65; i <= 90; i++)
            {
                string single = ((char)i).ToString();
                string target = ((i + 10) % 30).ToString();
                _dict.Add(single, target);
            }
        }

        public override void Interprent(InterpreterContext context)
        {
            string regx = "[A-Z]";
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
