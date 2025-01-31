using System;

namespace Lec03LibN
{
    public interface IBonus
    {
        float cost1hour { get; set; } 
        float calc(float number_hours); 
    }

    public interface IFactory
    {
        IBonus getA(float cost1hour); 
        IBonus getB(float cost1hour, float x); 
        IBonus getC(float cost1hour, float x, float y); 
    }

    public class BonusA : IBonus
    {
        public float cost1hour { get; set; }
        private float a;
        private float b;

        public BonusA(float cost1hour, float a = 0, float b = 0)
        {
            this.cost1hour = cost1hour;
            this.a = a;
            this.b = b;
        }

        public float calc(float number_hours)
        {
            return (number_hours + a) * (cost1hour + b);
        }
    }

    public class BonusB : IBonus
    {
        public float cost1hour { get; set; }
        private float a;
        private float b;
        private float x;

        public BonusB(float cost1hour, float x, float a = 0, float b = 0)
        {
            this.cost1hour = cost1hour;
            this.x = x;
            this.a = a;
            this.b = b;
        }

        public float calc(float number_hours)
        {
            return (number_hours + a) * (cost1hour + b) * x;
        }
    }

    public class BonusC : IBonus
    {
        public float cost1hour { get; set; }
        private float a;
        private float b;
        private float x;
        private float y;

        public BonusC(float cost1hour, float x, float y, float a = 0, float b = 0)
        {
            this.cost1hour = cost1hour;
            this.x = x;
            this.y = y;
            this.a = a;
            this.b = b;
        }

        public float calc(float number_hours)
        {
            return ((number_hours + a) * (cost1hour + b) * x) + y;
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
            return new BonusA(cost1hour, a);
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB(cost1hour, x, a);
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC(cost1hour, x, y, a);
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
            return new BonusA(cost1hour, a, b);
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB(cost1hour, x, a, b);
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC(cost1hour, x, y, a, b);
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
}
