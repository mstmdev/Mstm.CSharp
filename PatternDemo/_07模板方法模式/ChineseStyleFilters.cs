using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07模板方法模式
{
    public class ChineseStyleFilters : PhotoFiltersTemplate
    {
        public override string GetStyle()
        {
            return "Chinese Style Photo";
        }
    }
}
