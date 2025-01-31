using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Massive1(args);
            Massive2(args);
            Massive3(args);
            Massive4(args);
        }

        static void Massive1(string[] args) 
        {
            int[,] myArr = new int[4, 5];

            Random rar = new Random();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myArr[i, j] = rar.Next(1, 20);
                    Console.Write("{0}\t", myArr[i, j]);

                }
                Console.WriteLine();
            }
            Console.ReadKey();  
        }


        static void Massive2(string[] args)
        {
            string[] stringArray = { "яблоко", "банан", "вишня", "машина", "самолёт" };
            Console.WriteLine("Массив строк: ");
            foreach (string str in stringArray) 
            {
                Console.WriteLine(str);
            }
            Console.WriteLine($"Длина массива: {stringArray.Length}");

            Console.WriteLine("Введите позицию для замены (0-4): ");
            int position = int.Parse( Console.ReadLine() );

            Console.WriteLine("Введите новое значение: ");
            string newValue = Console.ReadLine();

            if (position >= 0 && position < stringArray.Length)
            {
                stringArray[position] = newValue;
            }
            else
            {
                Console.WriteLine("Неверная позиция.");

            }

            Console.WriteLine("Обновлённый массив: ") ;
            foreach (string str in stringArray)
            {
                Console.WriteLine(str) ;
            }


            Console.ReadKey();

        }

        static void Massive3(string[] args) 
        {
            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[2]; 
            jaggedArray[1] = new double[3]; 
            jaggedArray[2] = new double[4]; 

            
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"Введите значение для jaggedArray[{i}][{j}]: ");
                    jaggedArray[i][j] = double.Parse(Console.ReadLine());
                }
            }

            
            Console.WriteLine("Содержимое ступенчатого массива:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Massive4(string[] args) 
        {
            var stringArray = new[] { "hello", "world", "C#" };

            
            var greeting = "Hello from SkillForge!";

            
            Console.WriteLine("Неявно типизированный массив:");
            foreach (var str in stringArray)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Неявно типизированная строка:");
            Console.WriteLine(greeting);
        } 
    }
}
