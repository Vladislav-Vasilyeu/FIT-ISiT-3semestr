using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Customer
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
                if (creditCardNumber == null)
                    throw new ArgumentNullException(nameof(value), "CreditCardNumber cannot be null.");

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
        public Customer() : this(random.Next(1000, 9999))
        {
            LastName = "defalt";
            FirstName = "defalt";
            MiddleName = "defalt";
            Address = "defalt";
            CreditCardNumber = "0000000000000000";
            Balance = 0m;
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
}
