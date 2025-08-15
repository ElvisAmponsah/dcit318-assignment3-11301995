using System;

namespace Question_1
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[CryptoWallet] Processing transaction of {transaction.Amount:C} for {transaction.Category}");
        }
    }
}
