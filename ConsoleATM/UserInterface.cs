using System;
using System.Threading;
using Spectre.Console;

namespace ConsoleATM
{
    /// <summary>
    /// All user Interface.
    /// </summary>
    internal static class UserInterface
    {
        public static void Welcome()
        {
            AnsiConsole.Write(new Markup("[blue]Welcome...\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]Please insert your card.[/]").Centered());
            Thread.Sleep(6500);
            Console.Clear();
        }
        public static void Transactions()
        {
            Console.Clear();
            AnsiConsole.Write(new Markup("[blue]CHOOSE A TRANSACTION[/]\n").Centered());
            AnsiConsole.Write(new Markup("[blue]Press Cancel To Exit[/]").Centered());
            Console.WriteLine($"{Designs.AlignText(25, "1> Withdrawal\t\t\t\t5> Cash transaction")}");
            Console.WriteLine($"{Designs.AlignText(25, "2> Transfer\t\t\t\t6> Balance")}");
            Console.WriteLine($"{Designs.AlignText(25, "3> Other Services\t\t\t7> Payment")}");
            Console.WriteLine($"{Designs.AlignText(25, "4> Online Banking\t\t\t8> Cancel")}");
        }
        public static void AccountType()
        {
            AnsiConsole.Write(new Markup("[blue]SELECT YOUR ACCOUNT TYPE[/]\n").Centered());
            AnsiConsole.Write(new Markup("[blue]Press cancel to terminate transaction\n\n[/]").Centered());
            var accountype = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
           .AddChoices("Savings")
           .AddChoices("Current")
           .AddChoices("Cancel"));
        }
        public static void TransactionProgress()
        {
            ;
            AnsiConsole.Write(new Markup("[blue]TRANSACTION IN PROGRESS[/]\n").Centered());
            AnsiConsole.Write(new Markup("[blue]Please Wait[/]").Centered());
            Thread.Sleep(7000);
            Console.Clear();
        }
        public static void WithdrawalAmount()
        {
            AnsiConsole.Write(new Markup("[blue]SELECT AMOUNT\n").Centered());
            AnsiConsole.Write(new Markup("[blue]Press Cancel To Terminate Transaction\n\n[/]").Centered());
            Console.WriteLine($"{Designs.AlignText(28, "1> N500\t\t\t\t5> N10000")}");
            Console.WriteLine($"{Designs.AlignText(28, "2> N1000\t\t\t\t6> N15000")}");
            Console.WriteLine($"{Designs.AlignText(28, "3> N2000\t\t\t\t7> N20000")}");
            Console.WriteLine($"{Designs.AlignText(28, "4> N5000\t\t\t\t8> OTHER ")}");
            Console.WriteLine($"{Designs.AlignText(28, "9> Cancel")}");
        }
        public static void TransactionCompleted()
        {
            AnsiConsole.Write(new Markup("[blue]TRANSACTION COMPLETED\n\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]A notification will be sent[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]to you shortly[/]"));
        }
        public static void NewTransaction()
        {
            Console.Clear();
            AnsiConsole.Write(new Markup("[blue]Do you want to perform\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]another transaction?[/]").Centered());
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
           .AddChoices("YES")
           .AddChoices(" NO"));

            if (option.Contains("YES"))
            {
                Console.Clear();
                Login.VerifyUser();
                ConsoleATM.Transactions.SelectATransaction();
            }
            else if (option.Contains("NO"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card[/]").Centered());
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card[/]").Centered());
                Environment.Exit(0);
            }
        }
        public static void BeneficiaryBank()
        {
            AnsiConsole.Write(new Markup("[blue]SELECT BENEFICIARY BANK\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]Press cancel to terminate transaction\n[/]").Centered());
            Console.WriteLine("1> Access Bank\n");
            Console.WriteLine("3> Diamond Bank\t\t\t\t\t2> (F-M)\n");
            Console.WriteLine("5> Eco Bank\t\t\t\t\t4> (N-S)\n");
            Console.WriteLine("7> Heritage Bank\t\t\t\t6> (T-Z)");
        }
        public static void BeneficiaryAccountNumber()
        {
            AnsiConsole.Write(new Markup("[blue]ENTER BENEFICIARY ACCOUNT NUMBER\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]Please press cancel to terminate transaction.\n\n[/]").Centered());
            var option = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
          .AddChoices("Enter")
          .AddChoices("Cancel"));
        }
        public static void TransferAmount()
        {
            AnsiConsole.Write(new Markup("[blue]ENTER THE AMOUNT TO TRANSFER\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]Please press cancel to terminate transaction.\n\n[/]").Centered());
            Console.Write("Amount: ");
            Console.WriteLine("\n\n");
            var option = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
             .AddChoices("Enter")
             .AddChoices("Cancel"));
        }
    }
}
