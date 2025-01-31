using System;
using System.Linq;

namespace Program
{
    public partial class Customer
    {
        private readonly int id;
        private string lastName;
        private string firstName;
        private string middleName;
        private string address; 
        private string creditCardNumber;
        private double balance;
        private const string BankName = "БанкРешение";
        private static int customerCount;
        private static readonly Random random = new Random(); 

        public int Id
        {
            get 
            {
                return id;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }

        public string Address 
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string CreditCardNumber
        {
            get
            {
                return creditCardNumber;
            }
            private set
            {
                if (value.Length == 16)
                {
                    creditCardNumber = value;
                }
                else
                {
                    throw new ArgumentException("Номер кредитной карты должен содержать 16 цифр."); 
                }
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value >= 0)
                {
                    balance = value;
                }
                else
                {
                    throw new ArgumentException("Баланс не может быть отрицательным."); 
                }
            }
        }

        static Customer()
        {
            customerCount = 0;
        }

        private Customer(int id)
        {
            this.id = id;
            customerCount++;
        }

        public Customer() : this(random.Next(1000, 9999)) 
        {
        }

        public Customer(string lastName, string firstName, string middleName, string address, string creditCardNumber)
            : this(random.Next(1000, 9999)) 
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Address = address; 
            CreditCardNumber = creditCardNumber;
            Balance = 0;
        }

        public Customer(string lastName, string firstName) : this(lastName, firstName, "Unknown", "Unknown", "0000000000000000") { }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                throw new ArgumentException("Сумма зачисления должна быть положительной."); 
            }
        }

        public void Withdraw(double amount, ref double remainingBalance, out bool success)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                remainingBalance = Balance;
                success = true;
            }
            else
            {
                remainingBalance = Balance;
                success = false;
            }
        }

        public static void DisplayClassInfo()
        {
            Console.WriteLine($"Class Customer From {BankName}, Total Customers: {customerCount}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Customer))
            {
                return false;
            }

            Customer other = (Customer)obj;
            return this.id == other.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return $"ID: {id}, Name: {LastName} {FirstName} {MiddleName}, Balance: {Balance:C}";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer("Ivanov", "Ivan", "Ivanovich", "123 Main St", "1234567812345678");
            Customer customer3 = new Customer("Petrov", "Petr");

            Console.WriteLine(customer1.ToString());
            Console.WriteLine(customer2.ToString());
            Console.WriteLine(customer3.ToString());

            customer2.Deposit(1500);
            Console.WriteLine($"Баланс клиента 2 после зачисления: {customer2.Balance:C}");

            double remainingBalance = 0;
            bool success;
            customer2.Withdraw(500, ref remainingBalance, out success);
            if (success)
            {
                Console.WriteLine($"Списание прошло успешно. Остаток на счёте клиента 2: {remainingBalance:C}");
            }
            else
            {
                Console.WriteLine("Не удалось списать средства.");
            }

            Console.WriteLine("Сравнение клиентов 1 и 2: " + customer1.Equals(customer2));
            Console.WriteLine("Сравнение клиентов 2 и 3: " + customer2.Equals(customer3));

            Console.WriteLine("Тип объекта customer1: " + customer1.GetType());
            Console.WriteLine("Тип объекта customer2: " + customer2.GetType());

            Customer.DisplayClassInfo();

            Customer customer4 = new Customer("Sidorov", "Sidor", "Sidorovich", "456 Park Ave", "8765432187654321");
            Customer.DisplayClassInfo();

            Console.WriteLine(customer4.ToString());

            Customer[] customers = new Customer[]
            {
                new Customer("Ivanov", "Ivan", "Ivanovich", "123 Main St", "1234567812345678"),
                new Customer("Petrov", "Petr", "Petrovich", "456 Park Ave", "9876543298765432"),
                new Customer("Sidorov", "Sidor", "Sidorovich", "789 Oak St", "1111222233334444"),
                new Customer("Zhukov", "Andrey", "Andreevich", "321 Elm St", "4444333322221111"),
                new Customer("Abramov", "Sergey", "Sergeevich", "654 Birch St", "5555666677778888")
            };

            Console.WriteLine("Список покупателей в алфавитном порядке:");
            var sortedCustomers = customers.OrderBy(c => c.LastName).ToArray();
            foreach (var customer in sortedCustomers)
            {
                Console.WriteLine(customer.ToString());
            }

            string lowerBound = "2000000000000000";
            string upperBound = "8000000000000000";

            Console.WriteLine("\nПокупатели с номерами кредитных карт в заданном интервале:");
            var filteredCustomers = customers.Where(c => String.Compare(c.CreditCardNumber, lowerBound) >= 0 &&
                                                         String.Compare(c.CreditCardNumber, upperBound) <= 0)
                                             .ToArray();
            foreach (var customer in filteredCustomers)
            {
                Console.WriteLine(customer.ToString());
            }

            var anonymousCustomer = new
            {
                ID = 1234,
                LastName = "Ivanov",
                FirstName = "Ivan",
                MiddleName = "Ivanovich",
                Address = "123 Main St",
                CreditCardNumber = "1234567812345678",
                Balance = 1500.75
            };

            Console.WriteLine($"ID: {anonymousCustomer.ID}");
            Console.WriteLine($"Фамилия: {anonymousCustomer.LastName}");
            Console.WriteLine($"Имя: {anonymousCustomer.FirstName}");
            Console.WriteLine($"Отчество: {anonymousCustomer.MiddleName}");
            Console.WriteLine($"Адрес: {anonymousCustomer.Address}");
            Console.WriteLine($"Номер кредитной карты: {anonymousCustomer.CreditCardNumber}");
            Console.WriteLine($"Баланс: {anonymousCustomer.Balance:C}");
        }
    }

    public class Examplle
    {
        private double h;
        public double H
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
            }
        }
        public int Float()
        {
            
            return (int)Math.Round(h);
        } 
            
    }







}
