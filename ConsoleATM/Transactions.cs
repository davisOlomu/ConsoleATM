using System;
using System.Threading;

namespace ConsoleATM
{
    /// <summary>
    /// List of all functionality available to the user.
    /// </summary>
    internal static class Transactions
    {
        public  static void SelectATransaction()
        {
            Console.WriteLine(Environment.NewLine);
            ConsoleKeyInfo option = Console.ReadKey();

            switch (option.Key)
            {
                case ConsoleKey.NumPad1:
                    Withdraw.GetAccountType();
                    break;
                case ConsoleKey.NumPad2:
                    Transfer.GetBeneficiaryBank();
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
                    Balance.ShowBalance();
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

