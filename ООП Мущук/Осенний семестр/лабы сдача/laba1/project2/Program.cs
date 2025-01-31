using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intVal = 100;
            long longVal = intVal; 
            float floatVal = intVal;
            double doubleVal = floatVal;
            ushort ushortVal = 32000; 
            uint uintVal = ushortVal; 

            
            double largeDouble = 12345.67;
            int intFromDouble = (int)largeDouble; 
            float floatFromDouble = (float)largeDouble; 
            long longFromDouble = (long)largeDouble; 
            byte byteVal = (byte)intVal; 
            sbyte sbyteVal = (sbyte)ushortVal; 

            
            Console.WriteLine("Неявное приведение:");
            Console.WriteLine("int -> long: " + longVal);
            Console.WriteLine("int -> float: " + floatVal);
            Console.WriteLine("float -> double: " + doubleVal);
            Console.WriteLine("int -> ushort: " + ushortVal);
            Console.WriteLine("ushort -> uint: " + uintVal);

            Console.WriteLine("\nЯвное приведение:");
            Console.WriteLine("double -> int: " + intFromDouble);
            Console.WriteLine("double -> float: " + floatFromDouble);
            Console.WriteLine("double -> long: " + longFromDouble);
            Console.WriteLine("int -> byte: " + byteVal);
            Console.WriteLine("ushort -> sbyte: " + sbyteVal);


            int value = 500;
            object Val = value;
            int k = (int)Val;

            Console.WriteLine("\n");

            var massiv = new[] {1, 2, 3, 4, 5 };
            Console.WriteLine(massiv.GetType());
            var massiv2 = new[] { 1, 2, 3.5, 3.456, 5.02, 100 };
            Console.WriteLine(massiv2.GetType());

            Nullable();

            //var number = 500;
            //number = "Hello, world";

            Console.ReadKey();
        }

        static void Nullable()
        {
            int? value = null;
            
            
             if(value.HasValue)
            {
                Console.WriteLine($"Значение  value = {value}");
            }
             else
            {
                Console.WriteLine("value не содержит значени.");
            }


            Console.WriteLine("Введите значение value: ");
            value = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Значение value = {value}");

        }
    }
}
