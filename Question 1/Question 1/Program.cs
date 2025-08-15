using System;

namespace Question_1
{
    class Program
    {
        static void Main(string[] args)
        {
            FinanceApp app = new FinanceApp();
            app.Run();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}