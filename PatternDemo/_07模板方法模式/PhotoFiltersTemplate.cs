using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07模板方法模式
{
    public abstract class PhotoFiltersTemplate
    {
        public void Render()
        {
            string style = GetStyle();
            Console.WriteLine("Start Render.....");
            Console.WriteLine(style);
            Console.WriteLine("Render Finshed !");
        }

        public abstract string GetStyle();
    }
}
