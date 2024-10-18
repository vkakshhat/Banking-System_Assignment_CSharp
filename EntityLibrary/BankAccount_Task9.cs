using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public abstract class BankAccount_Task9
    {
        public long AccountNumber { get; set; }
        public string CustomerName { get; set; }
        protected double Balance { get; set; }

        // Default constructor
        public BankAccount_Task9() { }

        // Overloaded constructor
        public BankAccount_Task9(long accountNumber, string customerName, double balance)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = balance;
        }

        // Print account details
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Balance: {Balance}");
        }

        // Abstract methods
        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract void CalculateInterest();
    }

}

public class SavingsAccountAbstract : BankAccount_Task9
{
    private double InterestRate { get; set; }

    // Overloaded constructor for savings account
    public SavingsAccountAbstract(long accountNumber, string customerName, double balance)
        : base(accountNumber, customerName, balance)
    {
        InterestRate = 0.045; // 4.5% interest rate
    }

    // Implement Deposit method
    public override void Deposit(float amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited: {amount}. New Balance: {Balance}");
    }

    // Implement Withdraw method with insufficient funds check
    public override void Withdraw(float amount)
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

    // Implement CalculateInterest for savings account
    public override void CalculateInterest()
    {
        double interest = Balance * InterestRate;
        Balance += interest;
        Console.WriteLine($"Interest Added: {interest}. New Balance: {Balance}");
    }
}

public class CurrentAccountAbstract : BankAccount_Task9
{
    private const double OverdraftLimit = 500.0;

    // Overloaded constructor for current account
    public CurrentAccountAbstract(long accountNumber, string customerName, double balance)
        : base(accountNumber, customerName, balance)
    {
    }

    // Implement Deposit method
    public override void Deposit(float amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited: {amount}. New Balance: {Balance}");
    }

    // Implement Withdraw method with overdraft handling
    public override void Withdraw(float amount)
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

    // No interest for current accounts
    public override void CalculateInterest()
    {
        Console.WriteLine("No interest for current accounts.");
    }
}

