using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary;

namespace DAOLibrary
{
    public interface IBankRepository_Task14
    {
        long CreateAccount(Customer_Task11 customer, string accType, float balance);
        List<Account_Task11> ListAccounts();

        void CalculateInterest();

        float GetAccountBalance(long accountNumber);

        float Deposit(long accountNumber, float amount);

        float Withdraw(long accountNumber, float amount);

        float Transfer(long fromAccountNumber, long toAccountNumber, float amount);

        Account_Task11 GetAccountDetails(long accountNumber);

        List<Transaction_Task14> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }
}
