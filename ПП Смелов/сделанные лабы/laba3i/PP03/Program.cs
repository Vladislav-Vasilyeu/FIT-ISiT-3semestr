using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lec03LibN;

namespace PP03
{
    public class Employee
    {
        private readonly IBonus _bonusCalculator;

        public Employee(IBonus bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

        public double CalculateReward(double wH, double cH, double x = 0, double y = 0, double a = 0, double b = 0)
        {
            return _bonusCalculator.CalculateBonus(wH, cH, x, y, a, b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип вознаграждения: A, B, или C");
            string type = Console.ReadLine()?.ToUpper();

            Console.WriteLine("Выберите уровень вознаграждения: 1, 2, или 3");
            if (!int.TryParse(Console.ReadLine(), out int level) || level < 1 || level > 3)
            {
                Console.WriteLine("Неверный уровень. Программа завершена.");
                return;
            }

            IFactory factory = type switch
            {
                "A" => new FactoryA(level),
                "B" => new FactoryB(level),
                "C" => new FactoryC(level),
                _ => throw new ArgumentException("Неверный тип вознаграждения")
            };

            IBonus bonusCalculator = factory.CreateBonus();

            Console.WriteLine("Введите отработанные часы (wH):");
            double wH = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Введите стоимость одного часа (cH):");
            double cH = double.Parse(Console.ReadLine() ?? "0");

            double x = 0, y = 0, a = 0, b = 0;

            if (type == "B" || type == "C")
            {
                Console.WriteLine("Введите коэффициент x:");
                x = double.Parse(Console.ReadLine() ?? "0");
            }

            if (type == "C")
            {
                Console.WriteLine("Введите величину y:");
                y = double.Parse(Console.ReadLine() ?? "0");
            }

            if (level > 1)
            {
                Console.WriteLine("Введите величину повышения/понижения a:");
                a = double.Parse(Console.ReadLine() ?? "0");
            }

            if (level == 3)
            {
                Console.WriteLine("Введите величину повышения/понижения b:");
                b = double.Parse(Console.ReadLine() ?? "0");
            }

            Employee employee = new Employee(bonusCalculator);
            double reward = employee.CalculateReward(wH, cH, x, y, a, b);

            Console.WriteLine($"Вознаграждение сотрудника: {reward:F2}");
        }
    }
}
