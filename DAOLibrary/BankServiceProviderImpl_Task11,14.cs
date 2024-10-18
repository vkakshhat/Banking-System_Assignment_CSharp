using EntityLibrary;

namespace DAOLibrary
{
    public class BankServiceProviderImpl_Task11 : CustomerServiceProviderImpl_Task11, IBankServiceProvider_Task11
    {

        // FOR TASK 14 THE LIST OF ACCOUNTS AND TRANSACTIONS ARE MADE ALONG WITH BRANCHNAME AND ADDRESS

        public List<Account_Task11> accountList { get; set; }
        public List<Transaction_Task14> transactionList { get; set; }
        public string branchName { get; set; }
        public string branchAddress { get; set; }

        public BankServiceProviderImpl_Task11()
        {
            accountList = new List<Account_Task11>();
            transactionList = new List<Transaction_Task14>();
        }

        public void CreateAccount(Customer_Task11 customer, long accNo, string accType, float balance)
        {
            var account = new Account_Task11(accType, balance, customer);
            accountList.Add(account);

        }

        public Account_Task11[] ListAccounts()
        {
            return accountList.ToArray();
        }

        public string GetAccountDetails(long accountNumber)
        {
            return base.GetAccountDetails(accountNumber);
        }

        public void CalculateInterest()
        {
            foreach (var account in accountList)
            {
                // Calculate interest based on balance and interest rate
                account.Balance += account.Balance * 0.05f; // 5% interest rate
            }
        }
    }
}