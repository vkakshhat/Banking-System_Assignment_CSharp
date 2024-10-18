using DAOLibrary;
using EntityLibrary;

namespace HMBank
{
    public class BankApp_Task11and12
    {
        static void Main(string[] args)
        {
            BankServiceProviderImpl_Task11 bank = new BankServiceProviderImpl_Task11();

            while (true)
            {
                Console.WriteLine("Banking System");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Balance");
                Console.WriteLine("5. Transfer");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List Accounts");
                Console.WriteLine("8. Exit");

                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CreateAccount(bank);
                        break;
                    case 2:
                        Deposit(bank);
                        break;
                    case 3:
                        Withdraw(bank);
                        break;
                    case 4:
                        GetBalance(bank);
                        break;
                    case 5:
                        Transfer(bank);
                        break;
                    case 6:
                        GetAccountDetails(bank);
                        break;
                    case 7:
                        ListAccounts(bank);
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
        static void CreateAccount(BankServiceProviderImpl_Task11 bank)
        {
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

            Console.WriteLine("Choose account type:");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.WriteLine("3. Zero Balance Account");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter initial balance: ");
                    float balance = Convert.ToSingle(Console.ReadLine());
                    Console.Write("Enter interest rate: ");
                    float interestRate = Convert.ToSingle(Console.ReadLine());

                    bank.CreateAccount(customer, 0, "Savings", balance);
                    break;
                case 2:
                    Console.Write("Enter initial balance: ");
                    balance = Convert.ToSingle(Console.ReadLine());
                    Console.Write("Enter overdraft limit: ");
                    float overdraftLimit = Convert.ToSingle(Console.ReadLine());

                    bank.CreateAccount(customer, 0, "Current", balance);
                    break;
                case 3:
                    bank.CreateAccount(customer, 0, "Zero Balance", 0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        static void Deposit(BankServiceProviderImpl_Task11 bank)
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter deposit amount: ");
            float amount = Convert.ToSingle(Console.ReadLine());

            try
            {
                float balance = bank.Deposit(accountNumber, amount);
                Console.WriteLine($"Deposit successful. New balance: {balance}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Withdraw(BankServiceProviderImpl_Task11 bank)
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter withdrawal amount: ");
            float amount = Convert.ToSingle(Console.ReadLine());

            try
            {
                float balance = bank.Withdraw(accountNumber, amount);
                Console.WriteLine($"Withdrawal successful. New balance: {balance}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void GetBalance(BankServiceProviderImpl_Task11 bank)
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());

            try
            {
                float balance = bank.GetAccountBalance(accountNumber);
                Console.WriteLine($"Account balance: {balance}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Transfer(BankServiceProviderImpl_Task11 bank)
        {
            Console.Write("Enter source account number: ");
            long sourceAccountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter destination account number: ");
            long destinationAccountNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter transfer amount: ");
            float amount = Convert.ToSingle(Console.ReadLine());

            try
            {
                float balance = bank.Transfer(sourceAccountNumber, destinationAccountNumber, amount);
                Console.WriteLine($"Transfer successful. New balance: {balance}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void GetAccountDetails(BankServiceProviderImpl_Task11 bank)
        {
            Console.Write("Enter account number: ");
            long accountNumber = Convert.ToInt64(Console.ReadLine());
            try
            {
                string details = bank.GetAccountDetails(accountNumber);
                Console.WriteLine(details);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListAccounts(BankServiceProviderImpl_Task11 bank)
        {
            Account_Task11[] accounts = bank.ListAccounts();

            foreach (Account_Task11 account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Account Type: {account.AccountType}, Balance: {account.Balance}");
            }
        }
    }
}