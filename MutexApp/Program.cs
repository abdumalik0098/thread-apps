Mutex mutexObj = new();

// запускаем потоков
for (int i = 0; i < 1; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Касса {i+1}";
    myThread.Start();
}


void Print()
{
    for (int i = 0; i < 5; i++)
    {

        mutexObj.WaitOne();

        Console.WriteLine($"Покупатель {i} в {Thread.CurrentThread.Name}");
        Thread.Sleep(3000);

        mutexObj.ReleaseMutex();

    }
    
}
