using EntityLibrary;
using System;
using System.Text.RegularExpressions;

namespace EntityLibrary
{
    public class Customer_Task11
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customer_Task11(int customerId, string customerName, string email, string phoneNumber, string address)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}

    namespace EntityLibrary
    {
        public class Account_Task11
        {
            private static long lastAccNo = 0;
            public long AccountNumber { get; }
            public string AccountType { get; set; }
            public float Balance { get; set; }
            public Customer_Task11 Customer { get; set; }

            public Account_Task11(string accountType, float balance, Customer_Task11 customer)
            {
                AccountNumber = ++lastAccNo;
                AccountType = accountType;
                Balance = balance;
                Customer = customer;
            }

            public virtual void Deposit(float amount)
            {
                Balance += amount;
            }

            public virtual void Withdraw(float amount)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                }
                else
                {
                    throw new ArgumentException("Insufficient funds");
                }
            }
        }
    }

public class SavingsAccount_Task11 : Account_Task11
{
    public float InterestRate { get; set; }

    public SavingsAccount_Task11(float balance, Customer_Task11 customer, float interestRate)
        : base("Savings", balance, customer)
    {
        InterestRate = interestRate;
    }

    public override void Withdraw(float amount)
    {
        if (Balance - amount < 500)
        {
            throw new ArgumentException("Minimum balance requirement not met");
        }
        base.Withdraw(amount);
    }
}

public class CurrentAccount_Task11 : Account_Task11
{
    public float OverdraftLimit { get; set; }

    public CurrentAccount_Task11(float balance, Customer_Task11 customer, float overdraftLimit)
        : base("Current", balance, customer)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override void Withdraw(float amount)
    {
        if (Balance - amount < -OverdraftLimit)
        {
            throw new ArgumentException("Overdraft limit exceeded");
        }
        base.Withdraw(amount);
    }
}

public class Transaction_Task14
{

    public int TransactionId { get; set; }
    public long AccountNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionType { get; set; }
    public float Amount { get; set; }

    public Transaction_Task14(int transactionId, long accountNumber, DateTime transactionDate, string transactionType, float amount)
    {
        TransactionId = transactionId;
        AccountNumber = accountNumber;
        TransactionDate = transactionDate;
        TransactionType = transactionType;
        Amount = amount;
    }
}
