using System;
using System.Security.Cryptography.X509Certificates;

enum Mounths
{
    Январь, 
    Февраль, 
    Март, 
    Апрель,
    Май, 
    Июнь, 
    Июль,
    Август, 
    Сентябрь, 
    Октябрь, 
    Ноябрь,
    Декабрь
}


class Computer : IComparable<Computer>
{
    static readonly int pole1;
    static int pole2;
    public int pole3;
    
    public int Value {  get; set; } 
   

    public Computer(int value)
    {
        Value = value;
    }

    public int CompareTo(Computer other)
    {
        if (other == null) throw new ArgumentNullException("other");
        return Value.CompareTo(other.Value);
    }

    
}



interface IGood
{
    void Fine();
}

abstract public class Something
{
    abstract public void ItsOk();
    
}

public class Case : Something, IGood
{
    public void Fine()
    {
        Console.WriteLine("Oh, It's so very funny!!!");
    }
    public override void ItsOk()
    {
        Console.WriteLine("This is a just text.");
    }
}



class Program
{
    static void Main(string[] args)
    {
        foreach(Mounths mount in Enum.GetValues(typeof(Mounths)))
        {
            Console.WriteLine(mount);
        }

        string number = "123.456.789";
        string[] newNumbs = number.Split('.');
        foreach (string numb in  newNumbs)
        {
            Console.WriteLine(numb);
        }

        Computer comp1 = new Computer(10);
        Computer comp2 = new Computer(20);
        var varr= Console.ReadLine();
        Console.WriteLine(typeof(varr));
        //comp1.Value = Console.ReadLine();
       // int curr = comp1.CompareTo(comp2);
        if (comp1.CompareTo(comp2) == 0) Console.WriteLine($"Объекты {nameof(comp1)} и {nameof(comp2)} равны");
        if (comp1.CompareTo(comp2) == 1) Console.WriteLine($"Объект {nameof(comp1)} больше объекта {nameof(comp2)}");
        if (comp1.CompareTo(comp2) < 0) Console.WriteLine($"Объект {nameof(comp1)} меньше объекта {nameof(comp2)}");

        
        Case newCase = new Case();
        newCase.ItsOk();
        newCase.Fine();


    }
}