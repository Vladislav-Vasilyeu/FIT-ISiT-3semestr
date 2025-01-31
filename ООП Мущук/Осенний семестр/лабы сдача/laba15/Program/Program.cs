using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


namespace Program
{
    class Program
    {
        static int CalculateResult(int x, int y, int z)
        {
            return x * y + z;
        }
        static bool ArraysAreEqual(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }

        static async Task Main()
        {
                        

                        int vectorSize = 1000000;
                        int multiplier = 24352;

                        int[] vector = new int[vectorSize];
                        for (int i = 0; i < vectorSize; i++)
                        {
                            vector[i] = i;
                        }

                        Stopwatch sequentialStopwatch = Stopwatch.StartNew();
                        SequentialVectorMultiplier sequentialMultiplier = new();
                        sequentialMultiplier.Multiply(vector, multiplier);
                        sequentialStopwatch.Stop();
                        Console.WriteLine($"Последовательный алгоритм: {sequentialStopwatch.ElapsedMilliseconds} мс\n");

                        Stopwatch parallelStopwatch = Stopwatch.StartNew();
                        ParallelVectorMultiplier parallelMultiplier = new();
                        parallelMultiplier.Multiply(vector, multiplier);
                        parallelStopwatch.Stop();
                        Console.WriteLine($"Параллельный алгоритм: {parallelStopwatch.ElapsedMilliseconds} мс");

                        Console.ReadLine();

                        

                        CancellationTokenSource cancellationTokenSource = new();
                        CancellationToken cancellationToken = cancellationTokenSource.Token;

                        ParallelVectorMultiplier parallelMultiplier1 = new();
                        parallelMultiplier1.Multiply(vector, multiplier, cancellationToken);
                        Thread.Sleep(500);
                        cancellationTokenSource.Cancel();

                        Console.ReadLine();

                        

                        int x = 2, y = 3, z = 4;

                        Task<int> task1 = Task.Run(() => CalculateResult(x, y, z));
                        Task<int> task2 = Task.Run(() => CalculateResult(x, y, z));
                        Task<int> task3 = Task.Run(() => CalculateResult(x, y, z));

                        Task<int> finalTask = Task.WhenAll(task1, task2, task3)
                            .ContinueWith(tasks => // плюс задание 4 п.1
                            {
                                int result = tasks.Result[0] + tasks.Result[1] + tasks.Result[2];
                                return result;
                            });

                        Console.WriteLine($"Результат: {finalTask.Result}");

                        Console.ReadLine();

                        

                        Task<int> what = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
                        var awaiter = what.GetAwaiter();
                        awaiter.OnCompleted(() => {
                            int res = awaiter.GetResult();
                            Console.WriteLine(res);
                        });

                        Console.ReadLine();

                        

                        int arraySize = 1000000;
                        int[] resultArray1 = new int[arraySize];
                        int[] resultArray2 = new int[arraySize];

                        Stopwatch generateArraySequential = Stopwatch.StartNew();
                        ArrayGenerator.GenerateArraySequential(arraySize, resultArray1);
                        generateArraySequential.Stop();
                        Console.WriteLine($"Обычный цикл: {generateArraySequential.ElapsedMilliseconds} мс\n");

                        Stopwatch generateArrayParallel = Stopwatch.StartNew();
                        ArrayGenerator.GenerateArrayParallel(arraySize, resultArray2);
                        generateArrayParallel.Stop();
                        Console.WriteLine($"Параллельные циклы: {generateArrayParallel.ElapsedMilliseconds} мс\n");

                        bool arraysAreEqual = ArraysAreEqual(resultArray1, resultArray2);
                        Console.WriteLine($"Проверка равенства результатов. Массивы одинаковы: {arraysAreEqual}");

                        Console.ReadLine();

                        

                        ParallelTaskExecutor taskExecutor = new();
                        taskExecutor.ExecuteTasks();

                        Console.ReadLine();

            

            Warehouse.AAAAsync();

            Console.ReadLine();

            

            Console.WriteLine("Начало Main");
            Task<int> resultTask = PerformAsyncOperation();
            Console.WriteLine("Работа в Main");

            int result = await resultTask;
            Console.WriteLine($"Конец Main. Результат: {result}");

        }
        static async Task<int> PerformAsyncOperation()
        {
            Console.WriteLine("Начало PerformAsyncOperation");
            await Task.Delay(3000);
            Console.WriteLine("Конец PerformAsyncOperation");

            return 42;
        }
    }
}
