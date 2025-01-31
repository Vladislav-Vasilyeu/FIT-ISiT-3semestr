using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace program
{
    class BouquetException : Exception
    {
        public BouquetException() { }
        public BouquetException(string message) : base(message) { }
        public BouquetException(string message, Exception innerException) : base(message, innerException) { }
    }

    class FlowerException : BouquetException
    {
        public FlowerException() { }
        public FlowerException(string message) : base(message) { }
        public FlowerException(string message, Exception innerException) : base(message, innerException) { }
    }


    class SpecificFlowerException : FlowerException
    {
        public SpecificFlowerException() { }
        public SpecificFlowerException(string message) : base(message) { }
        public SpecificFlowerException(string message, Exception innerExeption) : base(message, innerExeption) { }  
    }

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



    public enum Типы_Растений
    {
        Куст,
        Роза,
        Гладиолус,
        Кактус
    }



    public struct Размеры
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Размеры(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override string ToString()
        {
            return $"Высота: {Height}, Ширина: {Width}";
        }

    }



    abstract class Цветок : Растение, IComparable<Цветок>
    {
        public abstract string Цвет { get; }
        public abstract decimal Цена { get; }
        public int CompareTo(Цветок other)
        {
            if (other == null) return 1;
            return Цена.CompareTo(other.Цена);
        }
    }



    sealed class Роза : Цветок
    {
        public override string Цвет => "Красный";
        public override decimal Цена => 25.0m;
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
        public override decimal Цена => 15.5m;
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
        private List<Цветок> цветы;
        public Бумага Упаковка { get; set; }

        public Букет(Бумага упаковка)
        {
            Упаковка = упаковка;
            цветы = new List<Цветок>();
        }

        public void AddFlower(Цветок цветок)
        {
            Debug.Assert(цветок != null, "Попытка добавьть null");
            if (цветок == null)
                throw new FlowerException("Нельзя добавить пустой объект цветка в букет.");
            цветы.Add(цветок);
        }
        public void RemoveFlower(Цветок цветок)
        {
            if (!цветы.Contains(цветок))
                throw new FlowerException(" Цветок для удаления не найден в букете");
            цветы.Remove(цветок);
        }
        public decimal GetTotalCost()
        {
            return цветы.Sum(цветок => цветок.Цена);
        }

        public List<Цветок> GetЦветы()
        {
            return цветы;
        }

        public void ShowBouquet()
        {
            Console.WriteLine("Состав букета: ");
            foreach (var цветок in цветы)
            {
                Console.WriteLine(" ");
                Console.WriteLine(цветок.ToString());
                Console.WriteLine(" ");

            }
            Console.WriteLine($"Общая стоимость букета: {GetTotalCost()} руб.");
            Console.WriteLine(" ");

        }

    }



    class Control
    {
        private Букет букет;
        public Control(Букет букет)
        {
            this.букет = букет ?? throw new BouquetException("Букет не может быть null.");
        }

        public void SortFlowers()
        {
            var цветы = букет.GetЦветы().OfType<Цветок>().OrderBy(цветок => цветок).ToList();
            букет = new Букет(букет.Упаковка);
            foreach (var цветок in цветы)
            {
                букет.AddFlower(цветок);
            }
        }


        public Цветок FindFlower(string FlowerColor)
        {
            return букет.GetЦветы().FirstOrDefault(цветок => цветок.Цвет == FlowerColor);
        }

        public void TriggerExeption()
        {
            try
            {
                throw new FlowerException("Искуственная ошибка");
            }
            catch(FlowerException ex)
            {
                Console.WriteLine($"{ex.Message}. Выполняем проброс выше.");
                throw;
            }
        }

    }



    class Printer
    {
        public void IAmPrinting(Растение растение)
        {
            Console.WriteLine(растение.ToString());
        }
    }


    

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                



                Роза роза = new Роза();
                Гладиолус гладиолус = new Гладиолус();
                Кактус кактус = new Кактус();
                Куст куст = new Куст();
                Бумага бумага = new Бумага();


                Растение[] растения = { роза, гладиолус, кактус, куст };

                Printer printer = new Printer();
                foreach (var растение in растения)
                {
                    if (растение is Роза)
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
                Console.WriteLine($"ICloneable DoClone: {cloneable.DoClone()}");
                Console.WriteLine($"Растение DoClone: {куст.DoClone()} ");





                Букет НовыйБукет = new Букет(бумага);
                НовыйБукет.AddFlower(роза);
                НовыйБукет.AddFlower(null);

                НовыйБукет.ShowBouquet();
                // НовыйБукет = null;
                Control control = new Control(НовыйБукет);

                Console.WriteLine("Cортировка цветов по цене: ");
                control.SortFlowers();
                НовыйБукет.ShowBouquet();

                string ColorFlower = "Розовый";
                Цветок найденныйЦветок = control.FindFlower(ColorFlower);
                if (найденныйЦветок != null)
                {
                    Console.WriteLine($"Найден цветок с цветом {ColorFlower}: ");
                    Console.WriteLine(найденныйЦветок.ToString());
                }
                else
                {
                    Console.WriteLine($"Цветок с цветом {ColorFlower} не найден.");
                }



                //Console.WriteLine("Проверка проброса исключения.");
               // control.TriggerExeption();


            }
            
            catch (FlowerException ex)
            {
                Console.WriteLine($"[FlowerException] Место: {ex.TargetSite}, Причина: {ex.Message}");
            }
        
            catch (BouquetException ex) 
            {
                Console.WriteLine($"[BouquetException] Место: {ex.TargetSite}, Причина: {ex.Message}");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[Общее исключение] Место: {ex.TargetSite}, Причина: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Работа программы завершена.");
            }
            


            


        }
    }
}
