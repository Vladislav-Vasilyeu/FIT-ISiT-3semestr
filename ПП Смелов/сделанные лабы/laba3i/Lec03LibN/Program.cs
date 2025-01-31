using System;
namespace Lec03LibN
{
    public interface IBonus
    {
        double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0);
    }

    public interface IFactory
    {
        IBonus CreateBonus();
    }
    public class TypeA1 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return wH * cH;
        }
    }

    public class TypeA2 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return (wH + a) * cH;
        }
    }

    public class TypeA3 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return (wH + a) * (cH + b);
        }
    }
    public class TypeB1 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return wH * cH * x;
        }
    }

    public class TypeB2 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return (wH + a) * cH * x;
        }
    }

    public class TypeB3 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return (wH + a) * (cH + b) * x;
        }
    }
    public class TypeC1 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return wH * cH * x + y;
        }
    }

    public class TypeC2 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return (wH + a) * cH * x + y;
        }
    }

    public class TypeC3 : IBonus
    {
        public double CalculateBonus(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return (wH + a) * (cH + b) * x + y;
        }
    }
    public class FactoryA : IFactory
    {
        private readonly int _level;

        public FactoryA(int level)
        {
            _level = level;
        }

        public IBonus CreateBonus()
        {
            return _level switch
            {
                1 => new TypeA1(),
                2 => new TypeA2(),
                3 => new TypeA3(),
                _ => throw new ArgumentException("Invalid level for Type A")
            };
        }
    }

    public class FactoryB : IFactory
    {
        private readonly int _level;

        public FactoryB(int level)
        {
            _level = level;
        }

        public IBonus CreateBonus()
        {
            return _level switch
            {
                1 => new TypeB1(),
                2 => new TypeB2(),
                3 => new TypeB3(),
                _ => throw new ArgumentException("Invalid level for Type B")
            };
        }
    }

    public class FactoryC : IFactory
    {
        private readonly int _level;

        public FactoryC(int level)
        {
            _level = level;
        }

        public IBonus CreateBonus()
        {
            return _level switch
            {
                1 => new TypeC1(),
                2 => new TypeC2(),
                3 => new TypeC3(),
                _ => throw new ArgumentException("Invalid level for Type C")
            };
        }
    }
}
