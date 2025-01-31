using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        public interface I1
        {
            int MyProperty { get; set; }

            
            void MyMethod();

            
            event EventHandler MyEvent;

            
            int this[int index] { get; set; }
        }

    }
}
