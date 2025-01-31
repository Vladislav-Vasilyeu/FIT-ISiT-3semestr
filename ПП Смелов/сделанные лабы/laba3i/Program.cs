using Lec03LibN;
using System;
namespace Lec03LibN
{
    public interface IBonus // вознаграждение
    {
        float cost1hour { get; set; } // стоимость одного часа
        float calc( // вычисление возраграждения
            float number_hours // - количество отработанных часов
            );
    }

    public interface IFactory // типы вознаграждения
    {
        IBonus getA(    // тип вознаграждения А
            float cost1hour         //стоимость одного часа
            );
        IBonus getB(        // тип вознаграждения В
            float cost1hour,        //стоимость одного часа
            float x         //повышающий/понижающий коэфициент
            );
        IBonus getC(        // тип вознаграждения С
            float cost1hour,        //стоимость одного часа
            float x,            //повышающий/понижающий коэфициент
            float y             // величина снижения/повыщения
            );
    }
    static public partial class Lec03BLib       //уровни вознаграждения
    {
        static public partial IFactory getL1();     //уровень 1
        static public partial IFactory getL2(       //уровень 1
                                                float a     //величина снижения/повышения отработанных часов
                                            );
        static public partial IFactory getL3(       //уровень 1
                                                float a,        //величина снижения/повышения отработанных часов
                                                float b         //величина снижения/повышения стоимости одного часа
                                            );
    }
}


public class Employee
{
    public IBonus bonus { get; private set; }
    public Employee(IBonus bonus)
    {
        this.bonus = bonus;
    }
    public float calcBonus(float number_hours)
    {
        return bonus.calc(number_hours);
    }
}