using System;
using System.Collections.Generic;

namespace Question_1
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void Run()
        {
            SavingsAccount account = new SavingsAccount("SA-12345", 1000m);

            Transaction t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            Transaction t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
            Transaction t3 = new Transaction(3, DateTime.Now, 500m, "Entertainment");

            ITransactionProcessor processor1 = new MobileMoneyProcessor();
            processor1.Process(t1);

            ITransactionProcessor processor2 = new BankTransferProcessor();
            processor2.Process(t2);

            ITransactionProcessor processor3 = new CryptoWalletProcessor();
            processor3.Process(t3);

            account.ApplyTransaction(t1);
            account.ApplyTransaction(t2);
            account.ApplyTransaction(t3);

            _transactions.Add(t1);
            _transactions.Add(t2);
            _transactions.Add(t3);
        }
    }
}
