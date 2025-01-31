using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 8, 12, 3, 7 };
            string str = "Hello!";

            (int max, int min, int sum, char firstChar) ProcessArrayAndString(int[] arr, string s)
            {
                int max = arr.Max();
                int min = arr.Min();
                int sum = arr.Sum();
                char firstChar = s[0];
                return(max, min, sum, firstChar);
            }

            var result = ProcessArrayAndString(array, str);

            Console.WriteLine($"Максимум: {result.max}, Минимум: {result.min}, Сумма: {result.sum}, Первая буква строки: {result.firstChar}");
        }

    }
}
