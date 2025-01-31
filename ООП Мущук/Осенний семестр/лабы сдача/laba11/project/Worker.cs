using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Работник
    {
        public int Id { get; set; }
        public string Имя { get; set; }
        public string Должность { get; set; }
        public decimal Зарплата { get; set; }

        public Работник(int id, string имя, string должность, decimal зарплата)
        {
            Id = id;
            Имя = имя;
            Должность = должность;
            Зарплата = зарплата;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Имя: {Имя}, Должность: {Должность}, Зарплата: {Зарплата}";
        }
    }

}
