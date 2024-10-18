using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityLibrary;

namespace DAOLibrary
{
    public interface IBankServiceProvider_Task11 : ICustomerServiceProvider_Task11
    {
        void CreateAccount(Customer_Task11 customer, long accNo, string accType, float balance);
        Account_Task11[] ListAccounts();
        string GetAccountDetails(long accountNumber);
        void CalculateInterest();
    }
}
