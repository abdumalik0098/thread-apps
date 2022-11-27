using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadExamples
{
    public class MyClass
    {
        object block = new object(); // объект синхронизация доступа (объект блокировки) - заглушка
        int k = 0;
        public void Method()
        {
            int hash = Thread.CurrentThread.GetHashCode();
            
            // критическая секция
            lock (block) 
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Поток {hash} - итерация {i}"); // ресурс
                    //Thread.Sleep(1000);
                }
            }
            //Console.WriteLine(new string('-',20));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            for (int i = 0; i < 3; i++)
            {
                new Thread(myClass.Method).Start(); // поток
            }
            Thread.Sleep(1000);
        }
    }
}
