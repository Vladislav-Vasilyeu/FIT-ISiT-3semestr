using System;
interface ICloneable
{
    bool DoClone();
}
abstract class Растение
{
    public abstract string Describe();
    public abstract bool DoClone();
    public override string ToString()
    {
        return $"Тип: {GetType().Name}, Описание: {Describe()}";
    }

}
class Куст : Растение, ICloneable
{
    public override string Describe()
    {
        return "Кустарник(Куст) — жизненная форма растений; многолетние деревянистые растения высотой 0,8—6 метров, в отличие от деревьев не имеющие во взрослом состоянии главного ствола, а имеющие несколько или много стеблей, часто существующих бок о бок и сменяющих друг друга. Продолжительность жизни 10—20 лет.";
    }
    public override bool DoClone()
    {
        return false;
    }
    bool ICloneable.DoClone() 
    {
        return true;    
    }
}

abstract class Цветок : Растение
{
    public abstract string Цвет { get; }
}
sealed class Роза : Цветок
{
    public override string Цвет => "Красный";
    public override string Describe()
    {
        return "Роза — собирательное название видов и сортов представителей рода Шиповник (лат. Rósa), выращиваемых человеком и растущих в дикой природе. Большая часть сортов роз получена в результате длительной селекции путём многократных повторных скрещиваний и отбора. Некоторые сорта являются формами дикорастущих видов.";
    }
    public override bool DoClone()
    {
        return true;
    }
}

class Гладиолус : Цветок
{
    public override string Describe()
    {
        return "Род многолетних клубнелуковичных растений семейства Ирисовые. Латинское название произошло от gladius - «меч» и связано с тем, что листья гладиолуса по форме напоминают шпаги. Природный ареал - тропические и субтропические районы Африки, Средиземноморья, Средние Европа и Азия, Западная Сибирь. Род включает около 280 видов, из которых 163 происходят из южной части Африки, 10 - из Евразии, 9 произрастают на Мадагаскаре.";
    }
    public override string Цвет => "Розовый";
    public override bool DoClone()
    {
        return true;
    }
}

class Кактус : Растение
{
    public override bool DoClone()
    {
        return false;
    }
    public override string Describe()
    {
        return "Кактус — это растение из семейства кактусовых (лат. Cactaceae), которое включает около 127 родов и около 1750 видов. Эти растения приспособлены к жизни в засушливых условиях, таких как пустыни и полупустыни. Они обладают способностью накапливать влагу в своих тканях, что помогает им выживать в условиях дефицита воды¹.";
    }
}
class Бумага
{
    public string Материал => "Целюлоза";
}
class Букет
{
    public Цветок Цветок { get; set; }
    public Бумага Упаковка { get; set; }

    public Букет(Бумага упаковка, Цветок цветок)
    {
        Цветок = цветок;
        Упаковка = упаковка;
    }
    public override string ToString()
    {
        return $"Букет: Цветок - {Цветок.GetType().Name}, Упаковка - {Упаковка.Материал}";
    }
}
class Printer
{
    public void IAmPrinting(Растение растение)
    {
        Console.WriteLine(растение.ToString());
    }
}
class Program
{
    static void Main(string[] args)
    {
        Роза роза = new Роза();
        Гладиолус гладиолус = new Гладиолус();
        Кактус кактус = new Кактус();
        Куст куст = new Куст();
        Бумага бумага = new Бумага();
        Букет букет = new Букет(бумага, роза);

        Растение[] растения = { роза, гладиолус, кактус, куст };

        Printer printer = new Printer();
        foreach (var растение in растения)
        {
            if(растение is Роза)
            {
                Console.WriteLine("Информация о растении 'Роза' ");
            }
            else if (растение is Гладиолус)
            {
                Console.WriteLine("Информация о растении 'Гладиолус' ");
            }
            else if (растение is Кактус)
            {
                Console.WriteLine("Информация о растении 'Кактус' ");
            }
            else if (растение is Куст)
            {
                Console.WriteLine("Информация о растении 'Куст' ");
            }
            printer.IAmPrinting(растение);
            Console.WriteLine(" ");
        }

        ICloneable cloneable = куст;
        Console.WriteLine($"ICloneable DoClone: {cloneable.DoClone()}" );
        Console.WriteLine($"Растение DoClone: {куст.DoClone()} ");
        Console.WriteLine(кактус.DoClone());
        
    }
}
