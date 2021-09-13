using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14备忘录模式
{
    /// <summary>
    /// Word文档类
    /// </summary>
    class WordDocument
    {
        public string Titile { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }


        /// <summary>
        /// 保存当前状态
        /// </summary>
        /// <returns></returns>
        public WordMemento SaveMemento()
        {
            return new WordMemento()
            {
                Content = this.Content,
                Description = this.Description,
                Titile = this.Titile
            };
        }

        /// <summary>
        /// 恢复指定的状态
        /// </summary>
        /// <param name="memento"></param>
        public void RecoverMemento(WordMemento memento)
        {
            if (memento != null)
            {
                this.Content = memento.Content;
                this.Titile = memento.Titile;
                this.Description = memento.Description;
            }
        }

        /// <summary>
        /// 输出文档的内容
        /// </summary>
        public void Show()
        {
            Console.WriteLine("作者： " + this.Author);
            Console.WriteLine("标题： " + this.Titile);
            Console.WriteLine("描述： " + this.Description);
            Console.WriteLine("内容： " + this.Content);
        }
    }
}
