using System;

namespace Lec03LibN
{
    public interface IBonus
    {
        float cost1hour { get; set; } // стоимость одного часа
        float calc(float number_hours); // вычисление вознаграждения
    }

    public interface IFactory
    {
        IBonus getA(float cost1hour); // тип вознаграждения A
        IBonus getB(float cost1hour, float x); // тип вознаграждения B
        IBonus getC(float cost1hour, float x, float y); // тип вознаграждения C
    }

    public class BonusA : IBonus
    {
        public float cost1hour { get; set; }

        public BonusA(float cost1hour)
        {
            this.cost1hour = cost1hour;
        }

        public float calc(float number_hours)
        {
            return number_hours * cost1hour; // Формула для A
        }
    }

    public class BonusB : IBonus
    {
        public float cost1hour { get; set; }
        private float x;

        public BonusB(float cost1hour, float x)
        {
            this.cost1hour = cost1hour;
            this.x = x;
        }

        public float calc(float number_hours)
        {
            return number_hours * cost1hour * x; // Формула для B
        }
    }

    public class BonusC : IBonus
    {
        public float cost1hour { get; set; }
        private float x;
        private float y;

        public BonusC(float cost1hour, float x, float y)
        {
            this.cost1hour = cost1hour;
            this.x = x;
            this.y = y;
        }

        public float calc(float number_hours)
        {
            return number_hours * cost1hour * x + y; // Формула для C
        }
    }

    public class Level1Factory : IFactory
    {
        public IBonus getA(float cost1hour)
        {
            return new BonusA(cost1hour);
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB(cost1hour, x);
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC(cost1hour, x, y);
        }
    }

    public class Level2Factory : IFactory
    {
        private float a;

        public Level2Factory(float a)
        {
            this.a = a;
        }

        public IBonus getA(float cost1hour)
        {
            return new BonusA(cost1hour + a);
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB(cost1hour + a, x);
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC(cost1hour + a, x, y);
        }
    }

    public class Level3Factory : IFactory
    {
        private float a;
        private float b;

        public Level3Factory(float a, float b)
        {
            this.a = a;
            this.b = b;
        }

        public IBonus getA(float cost1hour)
        {
            return new BonusA((cost1hour + a) * b);
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB((cost1hour + a) * b, x);
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC((cost1hour + a) * b, x, y);
        }
    }

    public static partial class Lec03BLib
    {
        public static IFactory getL1()
        {
            return new Level1Factory();
        }

        public static IFactory getL2(float a)
        {
            return new Level2Factory(a);
        }

        public static IFactory getL3(float a, float b)
        {
            return new Level3Factory(a, b);
        }
    }
}
