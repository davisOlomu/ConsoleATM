using System;
using System.Threading;


namespace ConsoleATM
{
    class Transactions
    {
        public void SelectTransaction()
        {
            Console.WriteLine(Environment.NewLine);
            ConsoleKeyInfo myTransaction = Console.ReadKey();

            switch (myTransaction.Key)
            {
                case ConsoleKey.NumPad1:
                    Withdraw.WithdrawalAccountType();
                    break;

                case ConsoleKey.NumPad2:
                    Transfer.BeneficiaryBank();
                    break;

                case ConsoleKey.NumPad3:
                    Console.Clear();
                    Designs.CenterNewLine("Under Construction!");

                    Thread.Sleep(3000);
                    Console.Clear();

                    Designs.CenterNewLine("Please take your card");
                    Environment.Exit(0);
                    break;

                case ConsoleKey.NumPad4:
                    Console.Clear();
                    Designs.CenterNewLine("Under Construction!");

                    Thread.Sleep(3000);
                    Console.Clear();

                    Designs.CenterNewLine("Please take your card");
                    Environment.Exit(0);
                    break;

                case ConsoleKey.NumPad5:
                    Console.Clear();
                    Designs.CenterNewLine("Under Construction!");

                    Thread.Sleep(3000);
                    Console.Clear();

                    Designs.CenterNewLine("Please take your card");
                    Environment.Exit(0);
                    break;

                case ConsoleKey.NumPad6:
                    Console.Clear();
                    Balance.GetBalance();
                    break;

                case ConsoleKey.NumPad7:
                    Console.Clear();
                    Designs.CenterNewLine("Under Construction!");

                    Thread.Sleep(3000);
                    Console.Clear();

                    Designs.CenterNewLine("Please take your card");
                    Environment.Exit(0);
                    break;

                case ConsoleKey.NumPad8:
                    Console.Clear();

                    Designs.CenterNewLine("Please take your card");
                    Environment.Exit(0);

                    Console.Clear();
                    break;

                default:
                    Console.Clear();
                    Designs.CenterNewLine("Please take your card");

                    Environment.Exit(0);
                    break;
            }
        }
    }
}

