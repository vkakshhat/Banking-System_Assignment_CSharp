using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary;


namespace DAOLibrary
{
    public interface ICustomerServiceProvider_Task11
    {
        float GetAccountBalance(long accountNumber);
        float Deposit(long accountNumber, float amount);
        float Withdraw(long accountNumber, float amount);
        float Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        string GetAccountDetails(long accountNumber);

        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }
}
