using System;

namespace Question_1
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[BankTransfer] Processing transaction of {transaction.Amount:C} for {transaction.Category}");
        }
    }
}
