using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18桥接模式
{
    class Insurance : Product
    {
        public Insurance(string name, decimal price, DateTime startTime, DateTime endTime)
            : base(name, price)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }


        public override void Show()
        {
            Console.WriteLine(string.Format("{0} ： 价格 {1} 起保时间 {2} 到期时间 {3}", this.ProductName, this.Price, StartTime, EndTime));
        }
    }
}
