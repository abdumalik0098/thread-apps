object block = new object(); // объект синхронизация доступа (объект блокировки) - заглушка
                             //int k = 0;

Mutex mutexObj = new();

for (int i = 0; i < 3; i++)
{
    new Thread(Method).Start(); // поток
}
Thread.Sleep(1000);


void Method()
{
    int hash = Thread.CurrentThread.GetHashCode();

    // критическая секция
    
    for (int i = 0; i < 3; i++)
    {
        mutexObj.WaitOne();
        Console.WriteLine($"Kassa {hash} - итерация {i}"); // ресурс
        //Thread.Sleep(3000);

        //Console.WriteLine($"Kassa {hash} - итерация {i}"); // ресурс
        //Thread.Sleep(3000);

        //Console.WriteLine($"Kassa {hash} - итерация {i}"); // ресурс
        //Thread.Sleep(3000);

        mutexObj.ReleaseMutex();
    }
    
    //Console.WriteLine(new string('-',20));
}
