using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Default Constructor
        public Customer()
        {
            CustomerID = 0;
            FirstName = "Unknown";
            LastName = "Unknown";
            Email = "Unknown";
            PhoneNumber = "Unknown";
            Address = "Unknown";
        }

        // Overloaded Constructor
        public Customer(int customerID, string firstName, string lastName, string email, string phoneNumber, string address)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        // Method to print customer information
        public void PrintCustomerInfo()
        {
            Console.WriteLine("Customer Information:");
            Console.WriteLine($"Customer ID: {CustomerID}");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
        }
    }

    public class Account
    {
        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        protected double Balance { get; set; }

        // Overloaded Constructor
        public Account(long accountNumber, string accountType, double balance)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = balance;
        }

        // Deposit and Withdraw Overloads for different data types
        public void Deposit(float amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited: {amount}. New Balance: {Balance}");
        }

        public void Withdraw(float amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        // Virtual method for calculating interest
        public virtual void CalculateInterest()
        {
            // Does nothing for non-savings accounts
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }

    // SavingsAccount class for Savings accounts
    public class SavingsAccount : Account
    {
        private double InterestRate { get; set; }

        public SavingsAccount(long accountNumber, double balance)
            : base(accountNumber, "Savings", balance)
        {
            InterestRate = 0.045; // 4.5% interest rate
        }

        public override void CalculateInterest()
        {
            double interest = Balance * InterestRate;
            Balance += interest;
            Console.WriteLine($"Interest Added: {interest}. New Balance: {Balance}");
        }
    }

    // CurrentAccount class for Current accounts with overdraft limit
    public class CurrentAccount : Account
    {
        private const double OverdraftLimit = 500.0;

        public CurrentAccount(long accountNumber, double balance)
            : base(accountNumber, "Current", balance)
        {
        }

        public virtual void Withdraw(float amount)
        {
            if (Balance + OverdraftLimit >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew: {amount}. New Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds, including overdraft limit.");
            }
        }
    }

    public class Transaction
    {
        public string TransactionType { get; set; } // e.g., "Deposit" or "Withdrawal"
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        // Constructor for Transaction
        public Transaction(string transactionType, double amount)
        {
            TransactionType = transactionType;
            Amount = amount;
            TransactionDate = DateTime.Now;
        }

        // Display transaction details
        public void PrintTransaction()
        {
            Console.WriteLine($"{TransactionDate}: {TransactionType} of {Amount}");
        }
    }
}

