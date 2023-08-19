using System;
using System.Threading;
using Spectre.Console;

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
            ConsoleKeyInfo userOption = Console.ReadKey();

            switch (userOption.Key)
            {
                case ConsoleKey.NumPad1:
                    Withdraw.GetAccountType();
                    break;
                case ConsoleKey.NumPad2:
                    Transfer.GetBeneficiaryBank();
                    break;
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[blue]Under Construction!\n[/]").Centered());
                    Thread.Sleep(3000);
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                    break;
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Under Construction!\n[/]").Centered());
                    Thread.Sleep(3000);
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                    AnsiConsole.WriteLine("\n\n");
                    break;
                case ConsoleKey.NumPad5:
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Under Construction!\n[/]").Centered());
                    Thread.Sleep(3000);
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                    break;
                case ConsoleKey.NumPad6:
                    Console.Clear();
                    Balance.ShowBalance();
                    break;
                case ConsoleKey.NumPad7:
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Under Construction!\n[/]").Centered());
                    Thread.Sleep(3000);
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                    break;
                case ConsoleKey.NumPad8:
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

