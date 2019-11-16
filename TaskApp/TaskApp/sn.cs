using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp
{
    public class sn
    {
        //定义个方法，定义个委托，多线程离不开委托
       // public delegate GetData;
        public void Collection()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"苏宁的第{i}个线程开始了");
            }
        }
    }
}
