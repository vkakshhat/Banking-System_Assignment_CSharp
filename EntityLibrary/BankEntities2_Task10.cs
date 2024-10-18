using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Customer_Task10
    {
        public long CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customer_Task10() { }

        public Customer_Task10(long customerId, string firstName, string lastName, string emailAddress, string phoneNumber, string address)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            SetEmail(emailAddress);
            SetPhoneNumber(phoneNumber);
            Address = address;
        }

        private void SetEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                EmailAddress = email;
            else
                throw new ArgumentException("Invalid Email Address");
        }

        private void SetPhoneNumber(string phone)
        {
            if (Regex.IsMatch(phone, @"^\d{10}$"))
                PhoneNumber = phone;
            else
                throw new ArgumentException("Phone number must be 10 digits");
        }

        public void PrintCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {CustomerID}, Name: {FirstName} {LastName}, Email: {EmailAddress}, Phone: {PhoneNumber}, Address: {Address}");
        }
    }

    public class Account2
    {
        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        public float AccountBalance { get; set; }
        public Customer_Task10 AccountHolder { get; set; }

        public Account2() { }

        public Account2(long accountNumber, string accountType, float balance, Customer_Task10 customer)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountBalance = balance;
            AccountHolder = customer;
        }

        public void PrintAccountDetails()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {AccountBalance}");
            AccountHolder.PrintCustomerInfo();
        }

        public void Deposit(float amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {AccountBalance}");
        }

        public bool Withdraw(float amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrew {amount}. New balance: {AccountBalance}");
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }
        }
    }
}
