using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14备忘录模式
{

    /// <summary>
    /// 备忘录模式（Memento）：
    ///     在不破坏封装的前提下，将捕获一个对象的内部状态，并在该对象之外保存这个状态。
    ///     这样以后就可将该对象恢复到保存的状态。    
    /// 
    ///     通过备忘录模式可以将程序运行中每一时刻的状态保存下来，在必要的时刻将其恢复到指定的状态
    ///     如常用的Word文档就可以使用撤销键将Word文档恢复到上一个状态
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            WordCaretaker caretaker = new WordCaretaker();
            WordDocument doc = new WordDocument()
            {
                Author = "彰明",
                Content = "备忘录模式是一种...",
                Titile = "备忘录模式",
                Description = "关于备忘录模式"
            };

            caretaker.Memento = doc.SaveMemento();
            Console.WriteLine("..........初始文档............");
            doc.Show();


            doc.Author = "小明";
            doc.Content = "测试内容";
            doc.Description = "测试描述";
            doc.Titile = "测试标题";
            Console.WriteLine("..........修改后的文档............");
            doc.Show();


            doc.RecoverMemento(caretaker.Memento);
            Console.WriteLine("..........恢复后的文档............");
            doc.Show();

            Console.ReadLine();

        }
    }
}
