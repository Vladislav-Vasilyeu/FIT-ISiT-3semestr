using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Project
{
    public class XmlSerialize : ISerializer
    {
        string xmlfile = "D:\\Универ\\ООП Мущук\\Осенний семестр\\лабы сдача\\laba13\\Project\\fiels\\file.xml";


        public void Serialize<T>(T obj)
        {
            XmlSerializer xmlSerializer = new(typeof(T));
            using (FileStream fs = new(xmlfile, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj);
            }
        }

        public T Deserialize<T>()
        {
            XmlSerializer formatter = new(typeof(T));
            using (FileStream fs = new(xmlfile, FileMode.Open))
            {
                return (T)formatter.Deserialize(fs);
            }

        }
    }



    public class XmlSerializerArray
    {
        string xmlfile = "D:\\Универ\\ООП Мущук\\Осенний семестр\\лабы сдача\\laba13\\Project\\fiels\\filearray.xml";

        public void Serialize<T>(T[] array)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]));
            using (FileStream fs = new FileStream(xmlfile, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, array);
            }
        }

        public T[] Deserialize<T>()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]));
            using (FileStream fs = new FileStream(xmlfile, FileMode.Open))
            {
                return (T[])xmlSerializer.Deserialize(fs);
            }
        }
    }
}
