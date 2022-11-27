using System.Threading;
using System;

public class Program
{
    static void Main(string[] args)
    {
        Thread thread = new Thread(Print);
        thread.Start();
        string s;
        do
        {
            s = Console.ReadLine();
            Console.WriteLine(s);
        } while (s != "q");
    }

    static void Print()
    {
        for (int i = 0; i<10; i++)
        {
            Console.WriteLine("Potok Print");
            Thread.Sleep(2000);
        }
    }
}
