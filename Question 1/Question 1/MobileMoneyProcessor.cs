using System;

namespace Question_1
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[MobileMoney] Processing transaction of {transaction.Amount:C} for {transaction.Category}");
        }
    }
}
