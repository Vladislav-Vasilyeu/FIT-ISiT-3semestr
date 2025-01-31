using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            C1 obj1 = new C1();
            Console.WriteLine("Конструктор по умолчанию:");
            Console.WriteLine($"PublicField: {obj1.PublicField}");
            Console.WriteLine($"PublicProperty: {obj1.PublicProperty}");
            obj1.PublicMethod();
            Console.WriteLine();

            
            C1 obj2 = new C1(10, 20, 30);
            Console.WriteLine("Конструктор с параметрами:");
            Console.WriteLine($"PublicField: {obj2.PublicField}");
            Console.WriteLine($"PublicProperty (до изменения): {obj2.PublicProperty}");
            obj2.PublicProperty = 50; 
            Console.WriteLine($"PublicProperty (после изменения): {obj2.PublicProperty}");
            obj2.PublicMethod();
            Console.WriteLine();

            
            C1 obj3 = new C1(obj2);
            Console.WriteLine("Копирующий конструктор:");
            Console.WriteLine($"PublicField: {obj3.PublicField}");
            Console.WriteLine($"PublicProperty: {obj3.PublicProperty}");
            obj3.PublicMethod();
            Console.WriteLine();

            
            obj1.PublicField = 100;
            obj1.PublicProperty = 200;
            Console.WriteLine("Работа с публичными полями и свойствами:");
            Console.WriteLine($"PublicField: {obj1.PublicField}");
            Console.WriteLine($"PublicProperty: {obj1.PublicProperty}");
        }
    }

    public class C1
    {
        
        private const string PrivateConstant = "PrivateConstantValue";

        
        public const string PublicConstant = "PublicConstantValue";

       
        protected const string ProtectedConstant = "ProtectedConstantValue";

        
        private int _privateField;

        
        public int PublicField;

       
        protected int ProtectedField;

        private int PrivateProperty { get; set; }

        public int PublicProperty { get; set; }

        protected int ProtectedProperty { get; set; }

        public C1()
        {
            _privateField = 0;
            PublicField = 0;
            ProtectedField = 0;
            PrivateProperty = 0;
            PublicProperty = 0;
            ProtectedProperty = 0;
        }

        public C1(C1 other)
        {
            _privateField = other._privateField;
            PublicField = other.PublicField;
            ProtectedField = other.ProtectedField;
            PrivateProperty = other.PrivateProperty;
            PublicProperty = other.PublicProperty;
            ProtectedProperty = other.ProtectedProperty;
        }

        public C1(int privateField, int publicField, int protectedField)
        {
            _privateField = privateField;
            PublicField = publicField;
            ProtectedField = protectedField;
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Это приватный метод.");
        }

        public void PublicMethod()
        {
            Console.WriteLine("Это публичный метод.");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("Это защищенный метод.");
        }
    }
}
