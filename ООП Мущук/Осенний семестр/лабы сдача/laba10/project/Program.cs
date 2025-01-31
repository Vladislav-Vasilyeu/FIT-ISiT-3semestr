using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public partial class Customer
    {
        private readonly int id;
        private string lastName;
        private string firstName;
        private string middleName;
        private string address;
        private string creditCardNumber;
        private decimal balance;
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

        public decimal Balance
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

        

        private Customer(int id)
        {
            this.id = id;
            customerCount++;
        }

        

        public Customer(string lastName, string firstName, string middleName, string address, string creditCardNumber, decimal balance)
            : this(random.Next(1000, 9999))
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Address = address;
            CreditCardNumber = creditCardNumber;
            Balance = balance;
        }

        

        public void Deposit(decimal amount)
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

        public void Withdraw(decimal amount, ref decimal remainingBalance, out bool success)
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
    public class Transaction
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }

        public Transaction(int customerId, decimal amount)
        {
            CustomerId = customerId;
            Amount = amount;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
             
            string[] months = { "June", "July", "May", "December", "January", "February", "March", "April", "August", "September", "October", "November" };

            int n = 4;
            var lengthQuery = months.Where(m => m.Length == n);
            Console.WriteLine($"Месяцы с длиной строки {n}:");
            foreach (var month in lengthQuery)
            {
                Console.WriteLine(month);
            }



            string[] summerMonths = { "June", "July", "August" };
            string[] winterMonths = { "December", "January", "February" };
            var summerAndWinterQuery = months.Where(m => summerMonths.Contains(m) || winterMonths.Contains(m));
            Console.WriteLine("\nЛетние и зимние месяцы:");
            foreach (var month in summerAndWinterQuery)
            {
                Console.WriteLine(month);
            }



            var alphabeticalQuery = months.OrderBy(m => m);
            Console.WriteLine("\nМесяцы в алфавитном порядке:");
            foreach (var month in alphabeticalQuery)
            {
                Console.WriteLine(month);
            }



            var containsUQuery = months.Where(m => m.Contains('u') && m.Length >= 4);
            Console.WriteLine("\nМесяцы, содержащие букву «u» и длиной имени не менее 4-х:");
            foreach (var month in containsUQuery)
            {
                Console.WriteLine(month);
            }








            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Ivanov", "Ivan", "Ivanovich", "123 Main Street, Apt 4B", "1234567890123456", 1500.75m));
            customers.Add(new Customer("Petrov", "Petr", "Petrovich", "456 Elm Street, Suite 12", "9876543210987654", 3200.00m));
            customers.Add(new Customer("Sidorov", "Sidr", "Sidorovich", "789 Oak Avenue, Flat 3A", "1111222233334444", 450.20m));
            customers.Add(new Customer("Smirnova", "Anna", "Aleksandrovna", "321 Pine Road, House 5", "5678123487654321", 980.00m));
            customers.Add(new Customer("Kuznetsov", "Dmitry", "Nikolaevich", "654 Maple Lane, Apt 1", "4444555566667777", 2500.50m));
            customers.Add(new Customer("Volkova", "Elena", "Sergeevna", "987 Birch Blvd, Suite 202", "2222888899990000", 765.35m));
            customers.Add(new Customer("Fedorov", "Alexey", "Andreevich", "543 Spruce Court, Flat 2B", "1122334455667788", 1340.00m));
            customers.Add(new Customer("Mikhailova", "Maria", "Petrovna", "210 Oakwood Drive, Apt 10", "3344556677889900", 550.75m));
            customers.Add(new Customer("Popov", "Sergey", "Mikhailovich", "101 Cedar Circle, Suite 8", "1212343456567878", 2900.40m));
            customers.Add(new Customer("Zaitseva", "Olga", "Ivanovna", "789 Aspen Street, Flat 9", "9090808070706060", 1200.00m));



            var sortCustomers = customers.OrderBy(m => m.LastName);
            foreach (var customer in sortCustomers)
            {
                Console.WriteLine(customer);
            }



            string lowerBound = "2000000000000000";
            string upperBound = "8000000000000000";
            Console.WriteLine("\nПокупатели с номерами кредитных карт в заданном интервале:");
            var filteredCustomers = customers.Where(c => String.Compare(c.CreditCardNumber, lowerBound) >= 0 && String.Compare(c.CreditCardNumber, upperBound) <= 0);
            foreach (var customer in filteredCustomers)
            {
                Console.WriteLine(customer.ToString());
            }



            var maxCustomer = customers.OrderByDescending(m => m.CreditCardNumber).FirstOrDefault();
            Console.WriteLine($"\nМаксимальный покупатель: {maxCustomer.LastName} {maxCustomer.FirstName}, Номер карты: {maxCustomer.CreditCardNumber}, Баланс: {maxCustomer.Balance}\n");



            var topFiveCustomers = customers.OrderByDescending(m => m.Balance).Take(5);
            Console.WriteLine("Первые пять покупателей с максимальной суммой на карте:");
            foreach (var customer in topFiveCustomers)
            {
                Console.WriteLine($"{customer.LastName} {customer.FirstName}, Баланс: {customer.Balance}");
            }




            var customQuery = customers
                .Where(c => c.Balance > 1000) 
                .GroupBy(c => c.LastName[0]) 
                .Select(g => new
                    {
                    Initial = g.Key,
                    AverageBalance = g.Average(c => c.Balance), 
                    CustomersCount = g.Count(),
                    Customers = g.ToList()
                    }) 
                .OrderByDescending(g => g.AverageBalance) 
                .ToList();

            Console.WriteLine("\nРезультаты сложного запроса:");
            foreach (var group in customQuery)
            {
                Console.WriteLine($"Группа: {group.Initial}, Средний баланс: {group.AverageBalance}, Кол-во клиентов: {group.CustomersCount}");
                foreach (var customer in group.Customers)
                {
                    Console.WriteLine($"  {customer.LastName} {customer.FirstName}, Баланс: {customer.Balance}");
                }
            }
            var hasLargeGroup = customQuery.Any(g => g.CustomersCount > 2); 
            Console.WriteLine($"\nЕсть ли группы с более чем двумя клиентами? {hasLargeGroup}");





            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction(customers[0].Id, 500.00m),
                new Transaction(customers[1].Id, 1200.50m),
                new Transaction(customers[2].Id, 300.75m),
                new Transaction(customers[3].Id, 100.25m),
                new Transaction(customers[4].Id, 800.00m)
            };
            var customerTransactionQuery = customers
                .Join(transactions,     
                        c => c.Id,        
                        t => t.CustomerId,  
                        (c, t) => new   
                            {
                            CustomerName = $"{c.LastName} {c.FirstName}",
                            TransactionAmount = t.Amount
                            })
                .ToList();

            
            Console.WriteLine("\nКлиенты и их транзакции:");
            foreach (var entry in customerTransactionQuery)
            {
                Console.WriteLine($"Клиент: {entry.CustomerName}, Сумма транзакции: {entry.TransactionAmount}");
            }


        }
    }
}
