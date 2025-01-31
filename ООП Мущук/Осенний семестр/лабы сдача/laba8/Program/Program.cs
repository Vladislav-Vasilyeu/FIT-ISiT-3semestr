using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Сотрудник
    {
        public string Имя { get; set; }
        public double Зарплата {  get; set; }

        public Сотрудник(string имя, double зарплата)
        {
            Имя = имя;
            Зарплата = зарплата;
        }
    }
    public class Токарь : Сотрудник
    {
        public Токарь(string имя, double зарплата) : base(имя, зарплата) { }
        public void ПовыситьЗарплату(object sender, EventArgs e)
        {
            Зарплата += 1000;
            Console.WriteLine($"{Имя} получил повышение. Новая зарплата: {Зарплата}");

        }
        public void НаложитьШтраф(object sender, EventArgs e)
        {
            Зарплата -= 500;
            Console.WriteLine($"{Имя} получил штраф. Новая зарплата: {Зарплата}");
        }
    }



    public class СтудентЗаочник : Сотрудник
    {
        public СтудентЗаочник(string имя, double зарплата) : base(имя, зарплата) { }

        public void ПовыситьЗарплату(object sender, EventArgs e)
        {
            Зарплата += 700; 
            Console.WriteLine($"{Имя} получил повышение. Новая зарплата: {Зарплата}");
        }

        public void НаложитьШтраф(object sender, EventArgs e)
        {
            Зарплата -= 200; 
            Console.WriteLine($"{Имя} получил штраф. Новая зарплата: {Зарплата}");
        }
    }



    public class Директор
    {
        public event EventHandler Повысить;
        public event EventHandler Штраф;
        public void ПовыситьЗарплату()
        {
            Повысить?.Invoke(this, EventArgs.Empty);
        }
        public void НаложитьШтраф()
        {
            Штраф?.Invoke(this, EventArgs.Empty);
        }
    }

    internal class Program
    {

        public static string УдалитьЗнакиПрепинания(string str) => new string(str.Where(c => !char.IsPunctuation(c)).ToArray());

        public static string ДобавитьСимволы(string str) => str + "!!!";

        public static string ЗаменитьНаЗаглавные(string str) => str.ToUpper();

        public static string УдалитьЛишниеПробелы(string str) => string.Join(" ", str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        public static string ДобавитьСимволВНачало(string str) => "#" + str;

        static void Main(string[] args)
        {
            Директор директор = new Директор();

            Токарь токарь1 = new Токарь("Иван", 3000);
            Токарь токарь2 = new Токарь("Пётр", 3500);
            СтудентЗаочник студент1 = new СтудентЗаочник("Анна", 2000);
            СтудентЗаочник студент2 = new СтудентЗаочник("Елена", 2500);

            директор.Повысить += токарь1.ПовыситьЗарплату;
            директор.Повысить += студент1.ПовыситьЗарплату;
            директор.Штраф += токарь2.НаложитьШтраф;
            директор.Штраф += студент2.НаложитьШтраф;

            директор.ПовыситьЗарплату();

            директор.НаложитьШтраф();




            string исходнаяСтрока = "   Привет,  мир!    Это   тест-сообщение  .";
            Action<string> обработкаСтроки = str =>
            {
                str = УдалитьЗнакиПрепинания(str);
                str = ДобавитьСимволы(str);
                str = ЗаменитьНаЗаглавные(str);
                str = УдалитьЛишниеПробелы(str);
                str = ДобавитьСимволВНачало(str);
                Console.WriteLine(str);
            };

            обработкаСтроки(исходнаяСтрока);

        }
    }
}
