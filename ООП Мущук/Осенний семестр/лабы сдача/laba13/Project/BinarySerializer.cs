using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Project
{
    public class BinarySerializer : ISerializer
    {
        BinaryFormatter formatter = new();
        readonly string binpath = "D:\\Универ\\ООП Мущук\\Осенний семестр\\лабы сдача\\laba13\\Project\\fiels\\file.bin";

        public void Serialize<T>(T obj)
        {
            using (FileStream fs = new(binpath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public T Deserialize<T>()
        {
            using (FileStream fs = new(binpath, FileMode.OpenOrCreate))
            {
                return (T)formatter.Deserialize(fs);
            }
        }

    }




    public class BinarySerializerArray
    {
        BinaryFormatter formatter = new();
        readonly string binpath = "D:\\Универ\\ООП Мущук\\Осенний семестр\\лабы сдача\\laba13\\Project\\fiels\\filearray.bin";

        public void Serialize<T>(T[] array)
        {
            using (FileStream fs = new FileStream(binpath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, array);
            }
        }

        public T[] Deserialize<T>()
        {
            using (FileStream fs = new FileStream(binpath, FileMode.OpenOrCreate))
            {
                object obj = formatter.Deserialize(fs);
                return (T[])obj;
            }
        }
    }
}
