using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOLibrary;
using EntityLibrary;

namespace HMBank
{
    class BankApp_Task14
    {
        private IBankRepository_Task14 bankRepository;
        private Customer_Task11 customer;

        public BankApp_Task14()
        {
            bankRepository = new BankRepositoryImpl_Task14();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Banking System Menu:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. Get Transactions");
                Console.WriteLine("9. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        GetBalance();
                        break;
                    case 5:
                        Transfer();
                        break;
                    case 6:
                        GetAccountDetails();
                        break;
                    case 7:
                        ListAccounts();
                        break;
                    case 8:
                        GetTransactions();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("Account Types:");
            Console.WriteLine("1. Savings");
            Console.WriteLine("2. Checking");
            Console.WriteLine("3. Current");

            Console.Write("Enter your account type choice: ");
            int accountTypeChoice = Convert.ToInt32(Console.ReadLine());

            string accountType = "";
            switch (accountTypeChoice)
            {
                case 1:
                    accountType = "Savings";
                    break;
                case 2:
                    accountType = "Checking";
                    break;
                case 3:
                    accountType = "Current";
                    break;
                default:
                    Console.WriteLine("Invalid account type choice.");
                    return;
            }

            Console.Write("Enter customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Customer_Task11 customer = new Customer_Task11(customerId, customerName, email, phoneNumber, address);

            Console.Write("Enter initial deposit amount: ");
            float balance = Convert.ToSingle(Console.ReadLine());

            long accountNumber = bankRepository.CreateAccount(customer, accountType, balance);

            Console.WriteLine($"Account created successfully. Account number: {accountNumber}");
        }

        private void Deposit()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter amount to deposit: ");
            float amount = Convert.ToSingle(Console.ReadLine());

            bankRepository.Deposit(accountNumber, amount);
            Console.WriteLine("Deposit successful.");
        }

        private void Withdraw()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter amount to withdraw: ");
            float amount = Convert.ToSingle(Console.ReadLine());

            bankRepository.Withdraw(accountNumber, amount);
            Console.WriteLine("Withdrawal successful.");
        }

        private void GetBalance()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());

            float balance = bankRepository.GetAccountBalance(accountNumber);
            Console.WriteLine($"Account balance: {balance}");
        }

        private void Transfer()
        {
            Console.Write("Enter source account number: ");
            long sourceAccountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter destination account number: ");
            long destinationAccountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter amount to transfer: ");
            float amount = Convert.ToSingle(Console.ReadLine());

            bankRepository.Transfer(sourceAccountNumber, destinationAccountNumber, amount);
            Console.WriteLine("Transfer successful.");
        }

        private void GetAccountDetails()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());

            Account_Task11 account = bankRepository.GetAccountDetails(accountNumber);
            Console.WriteLine($"Account number: {account.AccountNumber}");
            Console.WriteLine($"Account type: {account.AccountType}");
            Console.WriteLine($"Balance: {account.Balance}");
            Console.WriteLine($"Customer name: {account.Customer.CustomerName}");
            Console.WriteLine($"Customer address: {account.Customer.Address}");
            Console.WriteLine($"Customer phone: {account.Customer.PhoneNumber}");
        }

        private void ListAccounts()
        {
            List<Account_Task11> accounts = bankRepository.ListAccounts();

            foreach (var account in accounts)
            {
                Console.WriteLine($"Account number: {account.AccountNumber}");
                Console.WriteLine($"Account type: {account.AccountType}");
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine($"Customer name: {account.Customer.CustomerName}");
                Console.WriteLine($"Customer address: {account.Customer.Address}");
                Console.WriteLine($"Customer phone: {account.Customer.PhoneNumber}");
                Console.WriteLine("------------------------");
            }
        }

        private void GetTransactions()
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter from date (yyyy-MM-dd): ");
            DateTime fromDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter to date (yyyy-MM-dd): ");
            DateTime toDate = Convert.ToDateTime(Console.ReadLine());

            List<Transaction_Task14> transactions = bankRepository.GetTransactions(accountNumber, fromDate, toDate);

            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId}");
                Console.WriteLine($"Account number: {transaction.AccountNumber}");
                Console.WriteLine($"Transaction date: {transaction.TransactionDate}");
                Console.WriteLine($"Transaction type: {transaction.TransactionType}");
                Console.WriteLine($"Amount: {transaction.Amount}");
                Console.WriteLine("------------------------");
            }
        }

        // Main method to run the application
        static void Main(string[] args)
        {
            BankApp_Task14 app = new BankApp_Task14();
            app.Run();
        }
    }
}
