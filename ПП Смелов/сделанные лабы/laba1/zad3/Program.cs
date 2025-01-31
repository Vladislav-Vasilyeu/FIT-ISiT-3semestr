using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    internal class Program
    {
        public static void Main()
        {
            C2 obj1 = new C2();
            Console.WriteLine("Создание объекта с конструктором по умолчанию:");
            Console.WriteLine($"PublicField: {obj1.PublicField}");
            Console.WriteLine($"PublicProperty: {obj1.PublicProperty}");
            obj1.PublicMethod();
            Console.WriteLine();

            C2 obj2 = new C2(10, 20, 30);
            Console.WriteLine("Создание объекта с конструктором с параметрами:");
            Console.WriteLine($"PublicField: {obj2.PublicField}");
            Console.WriteLine($"PublicProperty (до изменения): {obj2.PublicProperty}");
            obj2.PublicProperty = 50; 
            Console.WriteLine($"PublicProperty (после изменения): {obj2.PublicProperty}");
            obj2.PublicMethod();
            Console.WriteLine();

            
            obj1.MyMethod();
            obj1.MyProperty = 15;
            Console.WriteLine($"MyProperty (из интерфейса I1): {obj1.MyProperty}");
            Console.WriteLine();

            
            obj1[0] = 100;
            Console.WriteLine("Использование индексатора:");
            Console.WriteLine($"Индекс 0: {obj1[0]}");
            Console.WriteLine();

            
            obj1.MyEvent += (sender, e) => Console.WriteLine("Событие MyEvent было вызвано.");
            obj1.TriggerEvent();
        }
    }

    
    public interface I1
    {
        int MyProperty { get; set; }
        void MyMethod();
        event EventHandler MyEvent;
        int this[int index] { get; set; }
    }

    
    public class C2 : I1
    {
        
        private int _privateField;
        public int PublicField;
        protected int ProtectedField;

        
        public int MyProperty { get; set; }

        
        private int PrivateProperty { get; set; }
        public int PublicProperty { get; set; }
        protected int ProtectedProperty { get; set; }

        
        public event EventHandler MyEvent;

        
        public C2()
        {
            _privateField = 0;
            PublicField = 0;
            ProtectedField = 0;
            PrivateProperty = 0;
            PublicProperty = 0;
            ProtectedProperty = 0;
        }

        
        public C2(int privateField, int publicField, int protectedField)
        {
            _privateField = privateField;
            PublicField = publicField;
            ProtectedField = protectedField;
        }

        
        public void MyMethod()
        {
            Console.WriteLine("Метод из интерфейса I1 реализован в классе C2.");
        }

        
        public void PublicMethod()
        {
            Console.WriteLine("Это публичный метод из C2.");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Это приватный метод из C2.");
        }

        
        protected void ProtectedMethod()
        {
            Console.WriteLine("Это защищенный метод из C2.");
        }

        
        private int[] array = new int[10];
        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        
        public void TriggerEvent()
        {
            if (MyEvent != null)
            {
                MyEvent(this, EventArgs.Empty);
            }
        }

    }
}
