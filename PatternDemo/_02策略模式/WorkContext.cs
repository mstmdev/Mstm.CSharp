using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02策略模式
{
    class WorkContext
    {
        private AlgorithmBase algorithm;

        public WorkContext(string type)
        {
            switch (type)
            {
                case "A":
                    algorithm = new AlgorithmA(); break;
                case "B":
                    algorithm = new AlgorithmB(); break;
                case "C":
                    algorithm = new AlgorithmC(); break;
                default:
                    break;
            }
        }

        public void DoWork()
        {
            algorithm.Execute();
        }
    }
}
