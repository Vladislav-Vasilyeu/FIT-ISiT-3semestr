using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Project
{
    public class SoapSerializer : ISerializer
    {
        readonly string soappath = "D:\\Универ\\ООП Мущук\\Осенний семестр\\лабы сдача\\laba13\\Project\\fiels\\file.soap";
        SoapFormatter serializer = new();

        public void Serialize<T>(T obj)
        {
            using (FileStream fs = new(soappath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, obj);
            }
        }

        public T Deserialize<T>()
        {
            using (FileStream fs = new(soappath, FileMode.OpenOrCreate))
            {
                return (T)serializer.Deserialize(fs);
            }
        }
    }


    public class SoapSerializerArray
    {
        readonly string soappath = "D:\\Универ\\ООП Мущук\\Осенний семестр\\лабы сдача\\laba13\\Project\\fiels\\filearray.soap";
        SoapFormatter serializer = new();

        public void Serialize<T>(T[] array)
        {
            using (FileStream fs = new FileStream(soappath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, array);
            }
        }

        public T[] Deserialize<T>()
        {
            using (FileStream fs = new FileStream(soappath, FileMode.OpenOrCreate))
            {
                object obj = serializer.Deserialize(fs);
                return (T[])obj;
            }
        }
    }
}
