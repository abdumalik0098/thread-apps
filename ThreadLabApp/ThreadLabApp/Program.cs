using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLabApp
{
    internal class Program
    {
        static Mutex mutex = new Mutex();
        static string word;
        static string textfile;
        static int amountPotok;
        static string[] listfiles;
        
        
        static void Main(string[] args)
        {
            word = Console.ReadLine();
            string path = Directory.GetCurrentDirectory() + "\\src\\";
            listfiles = Directory.GetFiles(path);
            amountPotok = int.Parse(Console.ReadLine());
            for (int i = 0; i < amountPotok; i++)
            {
                Thread thread = new Thread(Search);
                thread.Name = $"Potok {i}";
                thread.Start(i);
                
            }
            Console.ReadKey();
        }

        static void Search(object obj)
        {

            List<string> words = new List<string>();

            if (obj is int j)
            {
                mutex.WaitOne();
               
                Console.WriteLine(Thread.CurrentThread.Name);

                for (int i = j; i < listfiles.Length; i=i+amountPotok)
                {
                    using (FileStream fstream = File.OpenRead(listfiles[i]))
                    {
                        byte[] buffer = new byte[fstream.Length];
                        fstream.Read(buffer, 0, buffer.Length);
                        textfile = Encoding.Default.GetString(buffer);
                        Console.WriteLine($"Текст из файла: {textfile}");
                        textfile = textfile.ToLower();
                        word = word.ToLower();
                        if (textfile.Contains(word))
                        {
                            int index = textfile.IndexOf(word);
                            string text = textfile.Substring(index, word.Length);
                            words.Add(text);
                        }

                    }
                    //Console.WriteLine($"Текст из файла: {textfile}");
                   // i = j;
                }
                foreach (var i in words)
                {
                    Console.WriteLine(i);
                }
                mutex.ReleaseMutex();
            }



            
        }
    }
}
