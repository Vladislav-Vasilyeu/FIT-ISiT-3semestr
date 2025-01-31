using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FunctionWithChecked();
            Console.ReadKey();
            FunctionWithUnchecked();
            Console.ReadKey();
        }
        static void FunctionWithChecked()
        {
            checked
            {
                int maxInt = int.MaxValue;
                int result = maxInt + 1;
                Console.WriteLine("Результат в checked: " + result);
            }
        }
        static void FunctionWithUnchecked()
        {
            unchecked
            {
                int maxInt = int.MaxValue;
                int result = maxInt + 1;
                Console.WriteLine("Результат в unchecked: " + result);
            }
        }
    }
}
