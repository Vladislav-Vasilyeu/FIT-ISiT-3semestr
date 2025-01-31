using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;

namespace CombinedExample
{
    
    public class Работник
    {
        public int Id { get; set; }
        public string Имя { get; set; }
        public string Должность { get; set; }
        public decimal Зарплата { get; set; }

        public Работник(int id, string имя, string должность, decimal зарплата)
        {
            Id = id;
            Имя = имя;
            Должность = должность;
            Зарплата = зарплата;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Имя: {Имя}, Должность: {Должность}, Зарплата: {Зарплата}";
        }
    }

    public class Company : IEnumerable<Работник>
    {
        private List<Работник> работники = new List<Работник>();
        public void AddWorker(Работник работник)
        {
            работники.Add(работник);
        }
        public bool DeleteWorker(int id)
        {
            var работник = работники.FirstOrDefault(r => r.Id == id);
            if (работник != null)
            {
                работники.Remove(работник);
                return true;
            }    
            return false;
        }
        public Работник FindWorker(string имя)
        {
            return работники.FirstOrDefault(r => r.Имя.Equals(имя, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerator<Работник> GetEnumerator()
        {
            return работники.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void DisplayAllWorkers()
        {
            foreach (var работник in работники)
            {
                Console.WriteLine(работник);
            }
        }
    }
    
  

    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.AddWorker(new Работник(1, "Иван Иванов", "Менеджер", 60000));
            company.AddWorker(new Работник(2, "Петр Петрович", "Разработчик", 80000));
            company.AddWorker(new Работник(3, "Алексей Алексевич", "Аналитик", 70000));

            Console.WriteLine("Все работники: ");
            company.DisplayAllWorkers();

            Console.WriteLine("Поиск работника по имени *Иван Иванов*: ");
            var finderWorker = company.FindWorker("Иван Иванов");
            Console.WriteLine(finderWorker != null ? finderWorker.ToString() : "Работник не найден");

            Console.WriteLine("Удаление работника с ID=2: ");
            if (company.DeleteWorker(2))
            {
                Console.WriteLine("Работник удалён.");

            }
            else
            {
                Console.WriteLine("Работник с таким ID не найден");
            }

            Console.WriteLine("Обновлённый список работников: ");
            company.DisplayAllWorkers();



            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "A");
            hashtable.Add(2, "B");
            hashtable.Add(3, "C");
            hashtable.Add(4, "D");
            hashtable.Add(5, "E");
            hashtable.Add(6, "F");
            hashtable.Add(7, "G");

            Console.WriteLine("Исходная коллекция Hashtable: ");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }


            Console.WriteLine("Удаляем 2 элемента коллекции: ");
            hashtable.Remove(2);
            hashtable.Remove(3);

            Console.WriteLine("Обновлённая коллекция Hashtable: ");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }


            Console.WriteLine("Добавление новых элементов");
            hashtable.Add(8, "H");
            hashtable[9] = "I";

            Console.WriteLine("Обновлённая коллекция Hashtable: ");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            Dictionary<int, char> dictionaly = new Dictionary<int, char>();
            foreach (DictionaryEntry entry in hashtable)
            {
                dictionaly.Add((int)entry.Key, Convert.ToChar(entry.Value));
            }

            Console.WriteLine("Коллекция Dictionary, заполненная из HashTable: ");
            foreach(var pair in dictionaly)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }

            Console.WriteLine("Поиск значения F в другой коллекции: ");
            char searchChar = 'F';
            var found = dictionaly.ContainsValue(searchChar);
            if (found)
            {
                Console.WriteLine($"Значение '{searchChar}' найдено в коллекции.");
            }
            else
            {
                Console.WriteLine($"Значение '{searchChar}' не найдено в коллекции.");
            }


















            ObservableCollection<Работник> работникs = new ObservableCollection<Работник>();
            работникs.CollectionChanged += Работники_CollectionChanged;

            Console.WriteLine("Добавляем работников:");
            работникs.Add(new Работник(1, "Илья", "Менеджер", 50000));
            работникs.Add(new Работник(2, "Игорь", "Разработчик", 40000));


            Console.WriteLine("\nУдаляем работника:");
            работникs.RemoveAt(0);

            Console.WriteLine("\nДобавляем ещё одного работника:");
            работникs.Add(new Работник(3, "Сергей", "Аналитик", 70000));

        }
        private static void Работники_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Добавлен элемент:");
                    foreach (Работник newItem in e.NewItems)
                    {
                        Console.WriteLine(newItem);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Удалён элемент:");
                    foreach (Работник oldItem in e.OldItems)
                    {
                        Console.WriteLine(oldItem);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Элемент заменён:");
                    foreach (Работник oldItem in e.OldItems)
                    {
                        Console.WriteLine("Старый: " + oldItem);
                    }
                    foreach (Работник newItem in e.NewItems)
                    {
                        Console.WriteLine("Новый: " + newItem);
                    }
                    break;
            }
        }

    }
}
