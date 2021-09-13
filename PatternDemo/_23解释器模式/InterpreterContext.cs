using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23解释器模式
{

    /// <summary>
    /// 传递给解释器的上下文数据
    /// </summary>
    class InterpreterContext
    {
        private string _input;
        private string _output;


        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                _output = value;
            }
        }

        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }

        public string Rule { get; set; }
    }
}
