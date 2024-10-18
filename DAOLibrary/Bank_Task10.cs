using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    public class Bank_Task10
    {
        private List<Account2> accountList = new List<Account2>();
        private static long nextAccountNumber = 1001;

        public Account2 CreateAccount(Customer_Task10 customer, string accType, float initialBalance)
        {
            var account = new Account2(nextAccountNumber++, accType, initialBalance, customer);
            accountList.Add(account);
            Console.WriteLine("Account created successfully.");
            return account;
        }

        public float GetAccountBalance(long accountNumber)
        {
            var account = FindAccount(accountNumber);
            return account != null ? account.AccountBalance : 0;
        }

        public void Deposit(long accountNumber, float amount)
        {
            var account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Withdraw(long accountNumber, float amount)
        {
            var account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            var fromAccount = FindAccount(fromAccountNumber);
            var toAccount = FindAccount(toAccountNumber);

            if (fromAccount != null && toAccount != null)
            {
                if (fromAccount.Withdraw(amount))
                {
                    toAccount.Deposit(amount);
                    Console.WriteLine($"Transferred {amount} from account {fromAccountNumber} to account {toAccountNumber}.");
                }
            }
            else
            {
                Console.WriteLine("One or both accounts not found.");
            }
        }

        public void GetAccountDetails(long accountNumber)
        {
            var account = FindAccount(accountNumber);
            if (account != null)
            {
                account.PrintAccountDetails();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private Account2 FindAccount(long accountNumber)
        {
            return accountList.Find(account => account.AccountNumber == accountNumber);
        }
    }
}
