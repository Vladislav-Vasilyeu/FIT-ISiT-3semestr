using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using static Set;


public interface ICollectionOperation<T>
{
    void Add(T item);
    void Remove(T item);
    void Display();
}

public class CollectionType<T> : ICollectionOperation<T> where T : class
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Элемент не может быть null.");
        items.Add(item);
    }

    public void Remove(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item), "Элемент не может быть null");
        if (!items.Remove(item))
            throw new InvalidOperationException("Элемент не найден в коллекции.");
    }

    public void Display()
    {
        Console.WriteLine("Содержимое коллекции: ");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public T Find(Predicate<T> predicate)
    {
        try
        {
            return items.Find(predicate) ?? throw new KeyNotFoundException("Элемент, соответствующий предикату, не найден.");
        }
        finally
        {
            Console.WriteLine("Поиск завершён");
        }
    }

    public void SaveToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in items)
                {
                    writer.WriteLine(item?.ToString());
                }
            }
            Console.WriteLine("Коллекция успешно сохранена в файл.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка сохранения: {ex.Message}");
        }
    }

    public void LoadFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл не найден.");

            items.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (typeof(T) == typeof(Production))
                    {
                        items.Add((T)(object)Production.FromString(line));
                    }
                    else if (typeof(T) == typeof(string))
                    {
                        items.Add((T)(object)line);
                    }
                    else if (typeof(T) == typeof(Растение))
                    {
                        
                        if (line.Contains("Роза"))
                        {
                            items.Add((T)(object)new Роза());
                        }
                        else if (line.Contains("Кактус"))
                        {
                            items.Add((T)(object)new Кактус());
                        }
                        else
                        {
                            throw new InvalidCastException($"Неизвестный тип растения в строке: {line}");
                        }
                    }
                    else
                    {
                        throw new InvalidCastException($"Тип {typeof(T)} не поддерживает загрузку из строки.");
                    }

                }
            }
            Console.WriteLine("Коллекция успешно загружена из файла.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка загрузки: {ex.Message}");
        }
    }
}



public class Set
{
    private List<int> elements;



    public class Production
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }

        public Production(int id, string organizationName)
        {
            Id = id;
            OrganizationName = organizationName;
        }
        public void Display()
        {
            Console.WriteLine($"Id организации : {Id}, название организации: {OrganizationName}");
        }
        public static Production FromString(string input)
        {
            var parts = input.Split(',');
            if (parts.Length != 2)
                throw new FormatException("Некорректный формат строки.");

            return new Production(int.Parse(parts[0]), parts[1]);
        }
        public override string ToString()
        {
            return $"{Id},{OrganizationName}";
        }

    }
    public class Developer
    {
        public string FIO { get; set; }
        public int Id { get; set; }
        public string Section { get; set; }

        public Developer(string fio, int id, string section)
        {
            FIO = fio;
            Id = id;
            Section = section;
        }

        public void Display()
        {
            Console.WriteLine($"ФИО разработчика: {FIO}, Его Id: {Id}, Отдел: {Section}");
        }
    }

    public Production ProductionInfo { get; set; }
    public Developer DeveloperInfo { get; set; }

    public Set()
    {
        elements = new List<int>();
        ProductionInfo = new Production(1, "БГТУ");
        DeveloperInfo = new Developer("Васильев Владислав Васильевич", 1, "ИСиТ");
    }


    public Set(IEnumerable<int> collection)
    {
        elements = new List<int>(collection);
        ProductionInfo = new Production(1, "БГТУ");
        DeveloperInfo = new Developer("Васильев Владислав Васильевич", 1, "ИСиТ");
    }


    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= elements.Count)
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            return elements[index];
        }
        set
        {
            if (index < 0 || index >= elements.Count)
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            elements[index] = value;
        }
    }


    public void Add(int item)
    {
        if (!elements.Contains(item))
        {
            elements.Add(item);
        }
    }


    public static Set operator -(Set set, int item)
    {
        Set newSet = new Set(set.elements);
        newSet.elements.Remove(item);
        return newSet;
    }


    public static Set operator *(Set set1, Set set2)
    {
        return new Set(set1.elements.Intersect(set2.elements));
    }


    public static bool operator <(Set set1, Set set2)
    {
        return set1.elements.Count < set2.elements.Count && !set1.elements.Except(set2.elements).Any();
    }

    public static bool operator >(Set set1, Set set2)
    {
        return !set2.elements.Except(set1.elements).Any();
    }


    public static Set operator &(Set set1, Set set2)
    {
        return new Set(set1.elements.Union(set2.elements));
    }


    public void Display()
    {
        Console.WriteLine("{" + string.Join(", ", elements) + "}");
    }



    public List<int> GetElements()
    {
        return elements;
    }











    public static Set operator ++(Set set1)
    {
        return set1 = new Set();
    }


}


public static class StatisticOperation
{


    public static int MaxMinSum(Set set)
    {
        var element = set.GetElements();
        return element.Max() + element.Min();
    }

    public static int MaxMinDifference(Set set)
    {
        var elements = set.GetElements();
        return elements.Max() - elements.Min();
    }

    public static int Count(Set set)
    {
        return set.GetElements().Count;
    }
    public static string AddPeriod(this string str)
    {
        return str.EndsWith(".") ? str : str + ".";
    }
    public static void RemoveZeroes(Set set)
    {
        var elements = set.GetElements();
        elements.RemoveAll(x => x == 0);
    }




}

public abstract class Растение
{
    public abstract string Describe();
    public override string ToString()
    {
        return $"Тип: {GetType().Name}, Описание: {Describe()}";
    }
    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != this.GetType())
            return false;

        var other = (Растение)obj;
        return this.Describe() == other.Describe(); 
    }

    
    public override int GetHashCode()
    {
        return Describe().GetHashCode();
    }
}

public class Роза : Растение
{
    public override string Describe()
    {
        return "Роза — это красивый цветок с красными лепестками.";
    }
}

public class Кактус : Растение
{
    public override string Describe()
    {
        return "Кактус — растение, приспособленное к жизни в пустыне.";
    }
}


class Program
{
    static void Main(string[] args)
    {
        var plantCollection = new CollectionType<Растение>();
        try
        {
            Console.WriteLine("Работа с коллекцией растений:");

            var rose = new Роза();
            var cactus = new Кактус();

            plantCollection.Add(rose);
            plantCollection.Add(cactus);
            plantCollection.Display();

            // Удаление существующего объекта
            plantCollection.Remove(cactus);
            plantCollection.Display();

            string filePath = "plants_collection.txt";
            plantCollection.SaveToFile(filePath);
            plantCollection.LoadFromFile(filePath);
            plantCollection.Display();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
