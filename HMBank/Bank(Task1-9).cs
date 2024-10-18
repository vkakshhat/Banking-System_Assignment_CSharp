using EntityLibrary;
using System;
using System.Collections.Generic;

public class Bank
{
    private Account account = null;            // For Account class
    private BankAccount_Task9 abstractAccount = null; // For BankAccount_Task9 abstract class
    private List<Transaction> transactionHistory = new List<Transaction>(); // For Transaction history

    // Task 8 Methods (For existing Account class)
    public void CreateAccount()
    {
        Console.WriteLine("Choose Account Type: 1 for Savings, 2 for Current");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter Account Number: ");
        long accountNumber = long.Parse(Console.ReadLine());
        Console.Write("Enter Initial Deposit: ");
        double initialDeposit = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                account = new SavingsAccount(accountNumber, initialDeposit);
                Console.WriteLine("Savings Account Created Successfully!");
                break;
            case 2:
                account = new CurrentAccount(accountNumber, initialDeposit);
                Console.WriteLine("Current Account Created Successfully!");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void DepositToAccount(float amount)
    {
        if (account != null)
        {
            account.Deposit(amount);
            transactionHistory.Add(new Transaction("Deposit", amount));
        }
        else
        {
            Console.WriteLine("No account found. Please create an account first.");
        }
    }

    public void WithdrawFromAccount(float amount)
    {
        if (account != null)
        {
            account.Withdraw(amount);
            transactionHistory.Add(new Transaction("Withdrawal", amount));
        }
        else
        {
            Console.WriteLine("No account found. Please create an account first.");
        }
    }

    public void CalculateAccountInterest()
    {
        if (account is SavingsAccount savingsAccount)
        {
            savingsAccount.CalculateInterest();
        }
        else
        {
            Console.WriteLine("Interest calculation is only available for Savings Accounts.");
        }
    }

    public void DisplayAccountInfo()
    {
        if (account != null)
        {
            account.DisplayAccountInfo();
        }
        else
        {
            Console.WriteLine("No account found. Please create an account first.");
        }
    }

    // Methods for Task 9 (For BankAccount_Task9 abstract class)
    public void CreateAbstractAccount()
    {
        Console.WriteLine("Choose Abstract Account Type: 1 for Savings, 2 for Current");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter Account Number: ");
        long accountNumber = long.Parse(Console.ReadLine());
        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();
        Console.Write("Enter Initial Deposit: ");
        double initialDeposit = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                abstractAccount = new SavingsAccountAbstract(accountNumber, customerName, initialDeposit);
                Console.WriteLine("Abstract Savings Account Created Successfully!");
                break;
            case 2:
                abstractAccount = new CurrentAccountAbstract(accountNumber, customerName, initialDeposit);
                Console.WriteLine("Abstract Current Account Created Successfully!");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void DepositAbstractAccount(float amount)
    {
        if (abstractAccount != null)
        {
            abstractAccount.Deposit(amount);
        }
        else
        {
            Console.WriteLine("No abstract account found. Please create an account first.");
        }
    }

    public void WithdrawAbstractAccount(float amount)
    {
        if (abstractAccount != null)
        {
            abstractAccount.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("No abstract account found. Please create an account first.");
        }
    }

    public void CalculateAbstractInterest()
    {
        if (abstractAccount != null)
        {
            abstractAccount.CalculateInterest();
        }
        else
        {
            Console.WriteLine("No abstract account found. Please create an account first.");
        }
    }

    // Display transaction history (same for both systems)
    public void DisplayTransactionHistory()
    {
        Console.WriteLine("Transaction History:");
        foreach (Transaction transaction in transactionHistory)
        {
            transaction.PrintTransaction();
        }
    }

    // Menu system to handle both existing Account class and abstract BankAccount_Task9 system
    public static void Main(string[] args)
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Loan Eligibility Check (Task 1)");
            Console.WriteLine("2. ATM Simulation (Task 2)");
            Console.WriteLine("3. Compound Interest Calculation (Task 3)");
            Console.WriteLine("4. Check Account Balance (Task 4)");
            Console.WriteLine("5. Validate Password (Task 5)");
            Console.WriteLine("6. Transaction History (Task 6)");
            Console.WriteLine("7. Bank Operations (Task 8)");
            Console.WriteLine("8. Abstract Bank Operations (Task 9)");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Loan Eligibility (simplified)
                    Console.WriteLine("Enter credit score:");
                    int creditScore = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter annual income:");
                    double annualIncome = double.Parse(Console.ReadLine());

                    if (creditScore > 700 && annualIncome >= 50000)
                    {
                        Console.WriteLine("You are eligible for a loan.");
                    }
                    else
                    {
                        Console.WriteLine("You are not eligible for a loan.");
                    }
                    break;

                case 2:
                    // ATM Simulation (simplified)
                    double balance = 5000; // Example starting balance
                    while (true)
                    {
                        Console.WriteLine("\nATM Options:");
                        Console.WriteLine("1. Check Balance");
                        Console.WriteLine("2. Withdraw");
                        Console.WriteLine("3. Deposit");
                        Console.WriteLine("4. Exit");
                        Console.Write("Choose an option: ");
                        int ATMchoice = Convert.ToInt32(Console.ReadLine());

                        switch (ATMchoice)
                        {
                            case 1: // Check Balance
                                Console.WriteLine($"Your balance is: {balance}");
                                break;
                            case 2: // Withdraw
                                Console.WriteLine("Enter the amount to withdraw:");
                                double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                if (withdrawAmount > balance)
                                {
                                    Console.WriteLine("Insufficient balance.");
                                }
                                else if (withdrawAmount % 100 != 0 && withdrawAmount % 500 != 0)
                                {
                                    Console.WriteLine("Withdrawal amount must be in multiples of 100 or 500.");
                                }
                                else
                                {
                                    balance -= withdrawAmount;
                                    Console.WriteLine($"Withdrawal successful. Your new balance is {balance}");
                                }
                                break;
                            case 3: // Deposit
                                Console.WriteLine("Enter the amount to deposit:");
                                double depositAmount = Convert.ToDouble(Console.ReadLine());
                                balance += depositAmount;
                                Console.WriteLine($"Deposit successful. Your new balance is {balance}");
                                break;
                            case 4: // Exit
                                return;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                    }
                    break;

                case 3:
                    // Compound Interest Calculation (simplified)
                    Console.WriteLine("Enter the number of customers:");
                    int numCustomers = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < numCustomers; i++)
                    {
                        Console.WriteLine($"\nCustomer {i + 1}:");
                        Console.WriteLine("Enter initial balance:");
                        double initialBalance = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter annual interest rate (as a percentage):");
                        double interestRate = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter number of years:");
                        int years = Convert.ToInt32(Console.ReadLine());

                        double futureBalance = initialBalance * Math.Pow((1 + interestRate / 100), years);
                        Console.WriteLine($"Future balance after {years} years: {futureBalance}");
                    }
                    break;

                case 4:
                    // Check Account Balance (simplified)
                    Dictionary<int, double> accounts = new Dictionary<int, double>()
                    {
                        { 1001, 5000 },
                        { 1002, 3000 },
                        { 1003, 15000 }
                    };

                    while (true)
                    {
                        Console.WriteLine("Enter your account number:");
                        int accNumber = Convert.ToInt32(Console.ReadLine());

                        if (accounts.ContainsKey(accNumber))
                        {
                            Console.WriteLine($"Your balance is: {accounts[accNumber]}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid account number. Please try again.");
                        }
                    }
                    break;

                case 5:
                    // Validate Password (simplified)
                    Console.WriteLine("Create a password:");
                    string password = Console.ReadLine();

                    if (password.Length >= 8 &&
                        password.Any(char.IsUpper) &&
                        password.Any(char.IsDigit))
                    {
                        Console.WriteLine("Password is valid.");
                    }
                    else
                    {
                        Console.WriteLine("Password is invalid. It must be at least 8 characters long, contain at least one uppercase letter, and one digit.");
                    }
                    break;

                case 6:
                    // Display Transaction History
                    double TransactionBalance = 0;
                    List<string> transactions = new List<string>();

                    while (true)
                    {
                        Console.WriteLine("\nTransaction Options:");
                        Console.WriteLine("1. Deposit");
                        Console.WriteLine("2. Withdraw");
                        Console.WriteLine("3. Exit and Display Transaction History");
                        Console.Write("Choose an option: ");
                        int TransactionChoice = Convert.ToInt32(Console.ReadLine());

                        switch (TransactionChoice)
                        {
                            case 1: // Deposit
                                Console.WriteLine("Enter the amount to deposit:");
                                double depositAmount = Convert.ToDouble(Console.ReadLine());
                                TransactionBalance += depositAmount;
                                transactions.Add($"Deposited: {depositAmount}, New Balance: {TransactionBalance}");
                                Console.WriteLine($"Deposit successful. Your new balance is {TransactionBalance}");
                                break;

                            case 2: // Withdraw
                                Console.WriteLine("Enter the amount to withdraw:");
                                double withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                if (withdrawAmount > TransactionBalance)
                                {
                                    Console.WriteLine("Insufficient balance.");
                                }
                                else
                                {
                                    TransactionBalance -= withdrawAmount;
                                    transactions.Add($"Withdrew: {withdrawAmount}, New Balance: {TransactionBalance}");
                                    Console.WriteLine($"Withdrawal successful. Your new balance is {TransactionBalance}");
                                }
                                break;

                            case 3: // Exit and Display Transaction History
                                Console.WriteLine("\nTransaction History:");
                                foreach (string transaction in transactions)
                                {
                                    Console.WriteLine(transaction);
                                }
                                return;

                            default:
                                Console.WriteLine("Invalid choice. Try again.");
                                break;
                        }
                    }
                    break;

                case 7:
                    // Bank Operations (for Account class)
                    Console.WriteLine("\nBank Operations (Existing Account Class):");
                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Deposit Amount");
                    Console.WriteLine("3. Withdraw Amount");
                    Console.WriteLine("4. Calculate Interest (Savings Account)");
                    Console.WriteLine("5. Display Account Info");
                    Console.WriteLine("6. Back to Main Menu");
                    Console.Write("Choose an option: ");
                    int accountChoice = int.Parse(Console.ReadLine());

                    switch (accountChoice)
                    {
                        case 1:
                            bank.CreateAccount();
                            break;
                        case 2:
                            Console.Write("Enter amount to deposit: ");
                            float depositAmount = float.Parse(Console.ReadLine());
                            bank.DepositToAccount(depositAmount);
                            break;
                        case 3:
                            Console.Write("Enter amount to withdraw: ");
                            float withdrawAmount = float.Parse(Console.ReadLine());
                            bank.WithdrawFromAccount(withdrawAmount);
                            break;
                        case 4:
                            bank.CalculateAccountInterest();
                            break;
                        case 5:
                            bank.DisplayAccountInfo();
                            break;
                        case 6:
                            break;  // Back to main menu
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                    break;

                case 8:
                    // Abstract Bank Operations (Task 9)
                    Console.WriteLine("\nAbstract Bank Operations:");
                    Console.WriteLine("1. Create Abstract Account");
                    Console.WriteLine("2. Deposit Amount to Abstract Account");
                    Console.WriteLine("3. Withdraw Amount from Abstract Account");
                    Console.WriteLine("4. Calculate Interest (Savings Account only)");
                    Console.WriteLine("5. Back to Main Menu");
                    Console.Write("Choose an option: ");
                    int abstractChoice = int.Parse(Console.ReadLine());

                    switch (abstractChoice)
                    {
                        case 1:
                            bank.CreateAbstractAccount();
                            break;
                        case 2:
                            Console.Write("Enter amount to deposit: ");
                            float depositAbstractAmount = float.Parse(Console.ReadLine());
                            bank.DepositAbstractAccount(depositAbstractAmount);
                            break;
                        case 3:
                            Console.Write("Enter amount to withdraw: ");
                            float withdrawAbstractAmount = float.Parse(Console.ReadLine());
                            bank.WithdrawAbstractAccount(withdrawAbstractAmount);
                            break;
                        case 4:
                            bank.CalculateAbstractInterest();
                            break;
                        case 5:
                            break;  // Back to main menu
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                    break;

                case 9:
                    Console.WriteLine("Exiting... Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}




