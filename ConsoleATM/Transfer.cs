using ConsoleBankDataAccess;
using Spectre.Console;
using System;
using System.Threading;
using static ConsoleATM.Login;

namespace ConsoleATM
{
    /// <summary>
    /// All the logical steps involved in making a transfer.
    /// </summary>
    internal static class Transfer
    {
        /// <summary>
        /// 
        /// </summary>
        private static decimal _amount;
        private static double _beneficiaryAccountNumber;
        private static string _beneficiaryBank;
        private static readonly DataLayer databaseAccess = new DataLayer();

        /// <summary>
        /// Choose beneficiary bank from a list of 
        /// pre-defined banks.
        /// The nesting of if statements is too deep,
        /// i'm trying to get a fix for it soon.
        /// </summary>
        public static void GetBeneficiaryBank()
        {
            Console.Clear();
            _beneficiaryBank = UserInterface.BeneficiaryBank();
            GetBeneficiaryAccountNumber();
        }

        /// <summary>
        /// Fill in beneficiary account number.
        /// </summary>
        public static void GetBeneficiaryAccountNumber()
        {
            _beneficiaryAccountNumber = UserInterface.BeneficiaryAccountNumber();
            GetBeneficiaryAccountType();
        }

        /// <summary>
        /// Choose an account type
        /// </summary>
        public static void GetBeneficiaryAccountType()
        {
            UserInterface.AccountType();
            GetAmount();
        }

        /// <summary>
        /// Verify if user input is a valid amount.
        /// </summary>
        public static void GetAmount()
        {
            AnsiConsole.Write(new Markup("[blue]Enter amount[/]\n"));
            AnsiConsole.Write(new Markup("[blue]NGN:[/]"));
            var transfer = new TransactionModel { TransactionDescription = "ATM Transfer", TransactionAmount = _amount };

            while (true)
            {
                if (!(decimal.TryParse(Console.ReadLine(), out _amount)))
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Invalid amount format!\n[/]").Centered());
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.Write("NGN:");
                }
                else if (!(_amount <= UserLoggedIn.Balance))
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Insufficient funds!\n[/]").Centered());
                    Thread.Sleep(2000);
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]NGN:[/]"));
                }
                else
                {
                    break;
                }
            }
            UserLoggedIn.Balance -= _amount;
            databaseAccess.UpdateBalance(UserLoggedIn, UserLoggedIn.Balance);
            transfer.TransactionStatus = TransactionStatus.Sucessfull;
            transfer.TransactionType = TransactionType.Debit;
            databaseAccess.CreateTransaction(transfer, UserLoggedIn.UserName);
            ConfirmTransferDetails();
        }

        /// <summary>
        /// Check all transaction details
        /// before transfer is made.
        /// Transaction cannot be cancelled beyond this point.
        /// </summary>
        public static void ConfirmTransferDetails()
        {
            Console.Clear();
            AnsiConsole.Write(new Markup("[blue]Please confirm details of Transfer\n[/]").Centered());
            AnsiConsole.Write(new Markup($"[blue]Account Number:[/]  [red]{_beneficiaryAccountNumber}\n[/]"));
            AnsiConsole.Write(new Markup($"[blue]Amount: NGN[/][red] {_amount }\n[/]"));
            AnsiConsole.Write(new Markup($"[blue]Bank:[/][red] {_beneficiaryBank}\n\n\n[/]"));
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
           .AddChoices("Proceed")
           .AddChoices("Cancel"));
            Console.Clear();

            if (option.Contains("Proceed"))
            {
                UserInterface.TransactionProgress();
                Console.Clear();
                UserInterface.TransactionCompleted();
                UserInterface.NewTransaction();
            }
            else if (option.Contains("Cancel"))
            {
                AnsiConsole.Write(new Markup("[red]Please take your card.\n[/]").Centered());
                Environment.Exit(0);
            }
            else
            {
                AnsiConsole.Write(new Markup("[red]Please take your card.\n[/]").Centered());
                Environment.Exit(0);
            }
        }
    }
}
