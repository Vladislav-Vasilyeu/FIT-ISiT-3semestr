using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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


class Program
{
    static void Main(string[] args)
    {
        Set set1 = new Set();
        set1.Add(1);
        set1.Add(2);    
        set1.Add(3);    
        set1.Add(4);    
        set1.Display();
        set1++;
        set1.Display();

        
       
    }
}