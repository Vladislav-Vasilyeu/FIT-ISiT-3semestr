
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;


class Task1
{
    public static void Run()
    {
        string filePath = "processes_info.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    writer.WriteLine($"ID: {process.Id}");
                    writer.WriteLine($"Имя: {process.ProcessName}");
                    writer.WriteLine($"Приоритет: {process.BasePriority}");
                    writer.WriteLine($"Время запуска: {process.StartTime}");
                    writer.WriteLine($"Состояние: {(process.Responding ? "Работает" : "Не отвечает")}");
                    writer.WriteLine($"Общее время CPU: {process.TotalProcessorTime}");
                    writer.WriteLine(new string('-', 40));
                }
                catch (Exception ex)
                {
                    writer.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}




class Task2
{
    public static void Run()
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        Console.WriteLine($"Имя домена: {currentDomain.FriendlyName}");
        Console.WriteLine("Загруженные сборки:");
        foreach (Assembly assembly in currentDomain.GetAssemblies())
        {
            Console.WriteLine(assembly.FullName);
        }

        AppDomain newDomain = AppDomain.CreateDomain("НовыйДомен");
        try
        {
            newDomain.Load("System.Text.Json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        AppDomain.Unload(newDomain);
    }
}




class Task3
{
    static Thread primeThread;
    static bool pauseThread = false;

    public static void Run(int n)
    {
        primeThread = new Thread(() => CalculatePrimes(n));
        primeThread.Start();
    }

    static void CalculatePrimes(int n)
    {
        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }

    static bool IsPrime(int number)
    {
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}


class Task4
{
    static readonly object locker = new object();
    static bool printOdd = false;

    public static void Run(int n)
    {
        Thread evenThread = new Thread(() => PrintEvenNumbers(n));
        Thread oddThread = new Thread(() => PrintOddNumbers(n));

        evenThread.Start();
        oddThread.Start();

        evenThread.Join();
        oddThread.Join();
    }

    static void PrintEvenNumbers(int n)
    {
        for (int i = 0; i <= n; i += 2)
        {
            lock (locker)
            {
                while (printOdd) Monitor.Wait(locker);
                Console.WriteLine(i);
                printOdd = true;
                Monitor.Pulse(locker);
            }
        }
    }

    static void PrintOddNumbers(int n)
    {
        for (int i = 1; i <= n; i += 2)
        {
            lock (locker)
            {
                while (!printOdd) Monitor.Wait(locker);
                Console.WriteLine(i);
                printOdd = false;
                Monitor.Pulse(locker);
            }
        }
    }
}


class Task5
{
    static Timer timer;
    static int counter = 0;

    public static void Run()
    {
        timer = new Timer(PrintTime, null, 0, 2000);
        Console.ReadLine();
        timer.Dispose();
    }

    static void PrintTime(object state)
    {
        counter++;
        Console.WriteLine($"Время: {DateTime.Now:HH:mm:ss}, Запуск №{counter}");
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("Выполнение всех заданий:");

    
        Task1.Run();
        Task2.Run();

        Console.Write("Введите n для поиска простых чисел: ");
        int n = int.Parse(Console.ReadLine());
        Task3.Run(n);

        Task4.Run(n);
        Task5.Run();

        Console.WriteLine("Все задания выполнены.");
    }
}
