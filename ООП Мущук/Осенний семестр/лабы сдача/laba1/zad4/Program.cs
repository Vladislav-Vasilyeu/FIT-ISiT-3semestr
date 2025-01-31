using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tuple = (42, "Hello", '!', "World", 100000UL);
            korteg1(tuple);
            korteg2(tuple); 

        }

        static void korteg1((int, string, char, string, ulong)tuple)
        {
            
            Console.WriteLine("Кортеж целиком: ");
            Console.WriteLine(tuple);

            Console.WriteLine("Отдельные элементы кортежа (1, 3, 4): ");
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);

            Console.ReadKey();
        }
        static void korteg2((int, string,   char, string, ulong) tuple)
        {
            (int number, string str1, char letter, string str2, ulong value) = tuple;

            Console.WriteLine("Распакованный кортеж:");
            Console.WriteLine($"Number: {number}, String: {str1}, Char: {letter}, String: {str2}, Value: {value}");

            (int number1, _, char letter1, _, ulong value1) = tuple;

            Console.WriteLine("Частично распакованный кортеж:");
            Console.WriteLine($"Number: {number1}, Char: {letter1}, Value: {value1}");
            Console.ReadKey();

        }
        static void korteg3()
        {
            var tuple1 = (42, "SkillForge", 'A', "Learning", 100000UL);
            var tuple2 = (42, "SkillForge", 'A', "Education", 100000UL);

            
            bool areEqual = tuple1 == tuple2;

            Console.WriteLine($"Кортежи равны: {areEqual}");

            
            if (tuple1.Item2 == tuple2.Item2 && tuple1.Item3 == tuple2.Item3)
            {
                Console.WriteLine("Второй и третий элементы у кортежей равны.");
            }
            else
            {
                Console.WriteLine("Второй и третий элементы у кортежей различны.");
            }
            Console.ReadKey();
        }
    }
}
