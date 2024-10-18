using DAOLibrary;
using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMBank
{
    class BankApp_Task10
    {
        static void Main(string[] args)
        {
            Bank_Task10 bank = new Bank_Task10();

            while (true)
            {
                Console.WriteLine("\n---Bank System Menu---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Get Account Details");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccountSubMenu(bank);
                        break;

                    case 2:
                        Console.Write("Enter Account Number: ");
                        long accNo = Convert.ToInt64(Console.ReadLine());

                        Console.Write("Enter Amount to Deposit: ");
                        float depositAmount = float.Parse(Console.ReadLine());

                        bank.Deposit(accNo, depositAmount);
                        break;

                    case 3:
                        Console.Write("Enter Account Number: ");
                        long withdrawAccNo = Convert.ToInt64(Console.ReadLine());

                        Console.Write("Enter Amount to Withdraw: ");
                        float withdrawAmount = float.Parse(Console.ReadLine());

                        bank.Withdraw(withdrawAccNo, withdrawAmount);
                        break;

                    case 4:
                        Console.Write("Enter From Account Number: ");
                        long fromAccNo = Convert.ToInt64(Console.ReadLine());

                        Console.Write("Enter To Account Number: ");
                        long toAccNo = Convert.ToInt64(Console.ReadLine());

                        Console.Write("Enter Amount to Transfer: ");
                        float transferAmount = float.Parse(Console.ReadLine());

                        bank.Transfer(fromAccNo, toAccNo, transferAmount);
                        break;

                    case 5:
                        Console.Write("Enter Account Number: ");
                        long detailsAccNo = Convert.ToInt64(Console.ReadLine());

                        bank.GetAccountDetails(detailsAccNo);
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void CreateAccountSubMenu(Bank_Task10 bank)
        {
            while (true)
            {
                Console.WriteLine("\n---Create Account Sub-menu---");
                Console.WriteLine("1. Create Savings Account");
                Console.WriteLine("2. Create Current Account");
                Console.WriteLine("3. Exit to Main Menu");
                Console.Write("Enter your choice: ");
                int subChoice = Convert.ToInt32(Console.ReadLine());

                if (subChoice == 3)
                {
                    Console.WriteLine("Returning to main menu...");
                    break;
                }

                Console.Write("Enter Customer ID: ");
                long customerId = Convert.ToInt64(Console.ReadLine());

                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                string phone = Console.ReadLine();

                Console.Write("Enter Address: ");
                string address = Console.ReadLine();

                Customer_Task10 customer = new Customer_Task10(customerId, firstName, lastName, email, phone, address);

                Console.Write("Enter Initial Balance: ");
                float balance = float.Parse(Console.ReadLine());

                if (subChoice == 1)
                {
                    Console.WriteLine("Creating Savings Account...");
                    bank.CreateAccount(customer, "Savings", balance);
                }
                else if (subChoice == 2)
                {
                    Console.WriteLine("Creating Current Account...");
                    bank.CreateAccount(customer, "Current", balance);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }

                Console.WriteLine("Account creation completed.");
            }
        }
    }
}
