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
            AnsiConsole.Write(new Markup("[blue]Press Cancel To Exit[/]\n\n").Centered());
            string withdraw = "Withdrawal".PadLeft(37);
            string cash = "Cash transaction".PadLeft(64);
            string transfer = "Transfer".PadLeft(35);
            string balance = "Balance".PadLeft(55);
            string others = "Other Services".PadLeft(41);
            string payment = "Payment".PadLeft(55);
            string online = "Online Banking".PadLeft(41);
            string cancel = "Cancel".PadLeft(54);
            var menuItem = AnsiConsole.Prompt(new SelectionPrompt<string>()
           .AddChoices(withdraw)
           .AddChoices(cash)
           .AddChoices(transfer)
           .AddChoices(balance)
           .AddChoices(others)
           .AddChoices(payment)
           .AddChoices(online)
           .AddChoices(cancel));
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
            AnsiConsole.Write(new Markup("[blue]TRANSACTION IN PROGRESS[/]\n").Centered());
            AnsiConsole.Write(new Markup("[blue]Please Wait[/]").Centered());
            Thread.Sleep(7000);
            Console.Clear();
        }
        public static void WithdrawalAmount()
        {
            AnsiConsole.Write(new Markup("[blue]SELECT AMOUNT[/]\n").Centered());
            AnsiConsole.Write(new Markup("[blue]Press Cancel To Terminate Transaction\n\n[/]").Centered());
            string fiveHundred = "N500".PadLeft(37);
            string ten = "N10000".PadLeft(63);
            string one = "N1000".PadLeft(38);
            string fifteen = "N15000".PadLeft(63);
            string two = "N2000".PadLeft(38);
            string twenty = "N20000".PadLeft(63);
            string fiveThousand = "N5000".PadLeft(38);
            string other = "OTHER".PadLeft(62);
            string cancel = "Cancel".PadLeft(39);
            var menuItem = AnsiConsole.Prompt(new SelectionPrompt<string>()
           .AddChoices(fiveHundred)
           .AddChoices(ten)
           .AddChoices(one)
           .AddChoices(fifteen)
           .AddChoices(two)
           .AddChoices(twenty)
           .AddChoices(fiveThousand)
           .AddChoices(other)
           .AddChoices(cancel));
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
            string access = "Access Bank".PadLeft(37);
            string diamond = "Diamond Bank".PadLeft(38);
            string fm = "(F-M)".PadLeft(50);
            string eco = "Eco Bank".PadLeft(34);
            string ns = "(N-S)".PadLeft(50);
            string heritage = "Heritage Bank".PadLeft(39);
            string tz = "(T-Z)".PadLeft(50);
            string cancel = "Cancel".PadLeft(32);
            var menuItem = AnsiConsole.Prompt(new SelectionPrompt<string>()
           .AddChoices(access + "\n")
           .AddChoices(diamond)
           .AddChoices(fm)
           .AddChoices(eco)
           .AddChoices(ns)
           .AddChoices(heritage)
           .AddChoices(tz)
           .AddChoices(cancel));
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
