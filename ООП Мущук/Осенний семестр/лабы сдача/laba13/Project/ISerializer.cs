using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project
{
    public interface ISerializer
    {
        public void Serialize<T>(T obj);
        public T Deserialize<T>();
    }
}
