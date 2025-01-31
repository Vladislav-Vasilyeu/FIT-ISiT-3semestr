using System;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Project
{
    

    [Serializable]
    class Букет
    {
        public Цветок Цветок { get; set; }
        public Бумага Упаковка { get; set; }

        [NonSerialized]
        public string ИгнорируемыйЧлен = "Этот элемент не будет сериализован"; // Это поле не будет сериализовано

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

    [Serializable]
    class Бумага
    {
        public string Материал => "Целюлоза";
    }

    [Serializable]
    abstract public class Растение
    {
        public abstract string Describe();
        public abstract bool DoClone();
        public override string ToString()
        {
            return $"Тип: {GetType().Name}, Описание: {Describe()}";
        }

    }

    [Serializable]
    abstract public class Цветок : Растение
    {
        public abstract string Цвет { get; }
    }
    [Serializable]
    sealed public class Роза : Цветок
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
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Роза роза1 = new();
            BinarySerializer binarySerializer = new();
            binarySerializer.Serialize(роза1);
            Роза роза1des = binarySerializer.Deserialize<Роза>();
            Console.WriteLine(роза1des.ToString());


            Роза роза2 = new();
            XmlSerialize xmlSerialize = new();
            xmlSerialize.Serialize(роза2);
            Роза роза2des = xmlSerialize.Deserialize<Роза>();
            Console.WriteLine(роза2des.ToString());


            Роза роза3 = new();
            SoapSerializer soapSerializer = new();
            soapSerializer.Serialize(роза3);
            Роза роза3des = soapSerializer.Deserialize<Роза>();
            Console.WriteLine(роза3des.ToString());


            Роза роза4 = new();
            JsonSerialize jsonSerializer = new();
            jsonSerializer.Serialize(роза4);
            Роза роза4des = jsonSerializer.Deserialize<Роза>();
            Console.WriteLine(роза4des.ToString());


            Роза роза5 = new();
            ISerializer serializer = new BinarySerializer();
            CustomSerializer serializationManager = new(serializer);
            serializationManager.Serialize(роза5);
            Роза роза5des = serializer.Deserialize<Роза>();
            Console.WriteLine(роза5des.ToString());


            Console.WriteLine("\n\n");
            Роза[] array = new Роза[] { роза1, роза2, роза3, роза4, роза5 };
            XmlSerializerArray binarySerializerArray = new();
            binarySerializerArray.Serialize(array);
            Роза[] arraynew = binarySerializerArray.Deserialize<Роза>();
            foreach (var item in arraynew)
            {
                Console.WriteLine(item.ToString());
            }


            string xmlContent = @"
    <Букеты>
      <Букет>
        <Цветок Тип='Роза'>Красный</Цветок>
        <Упаковка>Целюлоза</Упаковка>
      </Букет>
      <Букет>
        <Цветок Тип='Лилия'>Белый</Цветок>
        <Упаковка>Пластик</Упаковка>
      </Букет>
    </Букеты>";

            XmlDocument doc = new();
            doc.LoadXml(xmlContent);

            XmlNode цветок = doc.SelectSingleNode("//Букет[Цветок/@Тип='Роза']/Цветок");
            Console.WriteLine("XPath запрос 1: " + цветок?.InnerText);

            XmlNode упаковка = doc.SelectSingleNode("//Букет[Цветок='Белый']/Упаковка");
            Console.WriteLine("XPath запрос 2: " + упаковка?.InnerText);


            XDocument newDoc = new(
        new XElement("Букеты",
            new XElement("Букет",
                new XElement("Цветок", "Красный", new XAttribute("Тип", "Роза")),
                new XElement("Упаковка", "Целюлоза")
            ),
            new XElement("Букет",
                new XElement("Цветок", "Белый", new XAttribute("Тип", "Лилия")),
                new XElement("Упаковка", "Пластик")
            )
        )
    );

            string newPath = "new_bouquets.xml";
            newDoc.Save(newPath);

            var красныеЦветы = newDoc.Descendants("Цветок")
                .Where(x => (string)x == "Красный")
                .Select(x => x.Attribute("Тип")?.Value);

            Console.WriteLine("\nКрасные цветы:");
            foreach (var цвет in красныеЦветы)
            {
                Console.WriteLine(цвет);
            }

            var упаковки = newDoc.Descendants("Упаковка")
                .Select(x => x.Value);

            Console.WriteLine("\nВсе упаковки:");
            foreach (var упак in упаковки)
            {
                Console.WriteLine(упак);
            }

        }
    }
}
