using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[][] massive = new double[3][];
            massive[0] = new double[3] { 1, 2, 3};
            massive[1] = new double[5] {4, 5, 6, 7, 8};
            massive[2] = new double[4] {9, 10, 11, 12};

            for (int i = 0; i < massive.Length; i++)
            {
                for (int j = 0; j < massive[i].Length; j++)
                {
                    Console.WriteLine(massive[i][j]);
                }
                Console.WriteLine("\n");
            }

            System.Int64 a;
            Console.Write("введите число а: ");
            a = Convert.ToInt64(Console.ReadLine());
            System.SByte b;
            Console.Write("введите число b: ");
            b = Convert.ToSByte(Console.ReadLine());
            System.Int16 c;
            Console.Write("Ведите число с: ");
            c = Convert.ToInt16(Console.ReadLine());
            System.Int32 d;
            Console.Write("Введите число d: ");
            d = Convert.ToInt32(Console.ReadLine());
            System.Byte e;
            Console.Write("Введите число e: ");
            e = Convert.ToByte(Console.ReadLine());
            System.UInt16 f;
            Console.Write("Введите число f: ");
            f = Convert.ToUInt16(Console.ReadLine());
            System.UInt32 g;
            Console.Write("Введите число g: ");
            g = Convert.ToUInt32(Console.ReadLine());
            System.UInt64 h;
            Console.Write("Введите число h: ");
            h = Convert.ToUInt64(Console.ReadLine());
            System.Char i;
            Console.Write("Введите символ: ");
            i = Convert.ToChar(Console.ReadLine());
            System.Boolean j;
            Console.Write("Введите true or false: ");
            j = Convert.ToBoolean(Console.ReadLine());
            System.Single k;
            Console.Write("Введите число k: ");
            k = Convert.ToSingle(Console.ReadLine());
            System.Double l;
            Console.Write("Введите число l: ");
            l = Convert.ToDouble(Console.ReadLine());
            System.Decimal m;
            Console.Write("Введите число m: ");
            m = Convert.ToDecimal(Console.ReadLine());
            System.String str;
            Console.Write("Введите строку: ");
            str = Console.ReadLine();
            System.Object[] o = { a, b, c, d, e, f, g, h, i, j, k, l, m, str };


            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);
            Console.WriteLine(g);
            Console.WriteLine(h);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.WriteLine(k);
            Console.WriteLine(l);
            Console.WriteLine(m);
            Console.WriteLine(str);
            for(int y = 0; y < o.Length; y++)
            {
                Console.WriteLine(o[y]);
            }
            Console.WriteLine(o);
            Console.ReadKey();
        }
    }
}
