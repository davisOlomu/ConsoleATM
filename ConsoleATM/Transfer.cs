using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleBankDataAccess;
using static ConsoleATM.Login;
using Spectre.Console;

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
        private static ConsoleKeyInfo _bankOption;
        private static double _beneficiaryAccountNumber;
        private static string _beneficiaryBank;
        private static string[] _allBanks;
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
            UserInterface.BeneficiaryBank();
            _bankOption = Console.ReadKey();
            Console.Clear();

            if (_bankOption.Key == ConsoleKey.NumPad1 || _bankOption.Key == ConsoleKey.NumPad3 || _bankOption.Key == ConsoleKey.NumPad5 || _bankOption.Key == ConsoleKey.NumPad7)
            {
                _allBanks = new[] { "Access Bank", "Diamond Bank", "Eco Bank", "Heritage Bank" };

                if (_bankOption.Key == ConsoleKey.NumPad1)
                    _beneficiaryBank = _allBanks[0];

                else if (_bankOption.Key == ConsoleKey.NumPad2)
                    _beneficiaryBank = _allBanks[1];

                else if (_bankOption.Key == ConsoleKey.NumPad3)
                    _beneficiaryBank = _allBanks[2];

                else if (_bankOption.Key == ConsoleKey.NumPad4)
                    _beneficiaryBank = _allBanks[3];

                GetBeneficiaryAccounNumber();
            }

            if (_bankOption.Key == ConsoleKey.NumPad2)
            {
                List<string> allBanks = new List<string> { "1> Fidelity Bank", "2> First Bank", "3> GT Bank\n\n" };

                foreach (string bankName in allBanks)
                {
                    Console.WriteLine(bankName);
                }
                _bankOption = Console.ReadKey();
                Console.Clear();

                if (_bankOption.Key == ConsoleKey.NumPad1 || _bankOption.Key == ConsoleKey.NumPad2 || _bankOption.Key == ConsoleKey.NumPad3)
                {
                    _allBanks = new[] { "Fidelity Bank", "First Bank", "GT Bank" };

                    if (_bankOption.Key == ConsoleKey.NumPad1)
                        _beneficiaryBank = _allBanks[0];

                    else if (_bankOption.Key == ConsoleKey.NumPad2)
                        _beneficiaryBank = _allBanks[1];

                    else if (_bankOption.Key == ConsoleKey.NumPad3)
                        _beneficiaryBank = _allBanks[2];

                    GetBeneficiaryAccounNumber();
                }
            }

            if (_bankOption.Key == ConsoleKey.NumPad4)
            {
                List<string> allBanks = new List<string> { "1. Polaris Bank", "2. Stanbic IBTC", "3. Standard Chartered", "4. Sterling Bank\n\n" };

                foreach (string bank in allBanks)
                {
                    Console.WriteLine(bank);
                }
                _bankOption = Console.ReadKey();
                Console.Clear();

                if (_bankOption.Key == ConsoleKey.NumPad1 || _bankOption.Key == ConsoleKey.NumPad2 || _bankOption.Key == ConsoleKey.NumPad3 || _bankOption.Key == ConsoleKey.NumPad4)
                {
                    _allBanks = new[] { "Polaris Bank", "Stanbic IBTC", "Standard Chartered", "Sterling Bank" };

                    if (_bankOption.Key == ConsoleKey.NumPad1)
                        _beneficiaryBank = _allBanks[0];

                    else if (_bankOption.Key == ConsoleKey.NumPad2)
                        _beneficiaryBank = _allBanks[1];

                    else if (_bankOption.Key == ConsoleKey.NumPad3)
                        _beneficiaryBank = _allBanks[2];
                    else if (_bankOption.Key == ConsoleKey.NumPad4)
                        _beneficiaryBank = _allBanks[3];

                    GetBeneficiaryAccounNumber();
                }
            }

            if (_bankOption.Key == ConsoleKey.NumPad6)
            {
                List<string> allBanks = new List<string> { "1. Taj Bank", "2. Unity Bank", "3. Union Bank", "4. Wema Bank", "5. GTB", "6. Zenith Bank\n\n" };

                foreach (string bank in allBanks)
                {
                    Console.WriteLine(bank);
                }
                _bankOption = Console.ReadKey();
                Console.Clear();

                if (_bankOption.Key == ConsoleKey.NumPad1 || _bankOption.Key == ConsoleKey.NumPad2 || _bankOption.Key == ConsoleKey.NumPad3 || _bankOption.Key == ConsoleKey.NumPad4 || _bankOption.Key == ConsoleKey.NumPad5 || _bankOption.Key == ConsoleKey.NumPad6)
                {
                    _allBanks = new[] { "Taj Bank", " Unity Bank", "Union Bank", "Wema Bank", "GTB", "Zenith Bank" };

                    if (_bankOption.Key == ConsoleKey.NumPad1)
                        _beneficiaryBank = _allBanks[0];

                    else if (_bankOption.Key == ConsoleKey.NumPad2)
                        _beneficiaryBank = _allBanks[1];

                    else if (_bankOption.Key == ConsoleKey.NumPad3)
                        _beneficiaryBank = _allBanks[2];

                    else if (_bankOption.Key == ConsoleKey.NumPad4)
                        _beneficiaryBank = _allBanks[3];

                    else if (_bankOption.Key == ConsoleKey.NumPad5)
                        _beneficiaryBank = _allBanks[4];

                    else if (_bankOption.Key == ConsoleKey.NumPad6)
                        _beneficiaryBank = _allBanks[5];

                    GetBeneficiaryAccounNumber();
                }
            }
            else
            {
                AnsiConsole.Write(new Markup("[red]Wrong Input!\n[/]").Centered());
                Thread.Sleep(3000);
                Console.Clear();
                UserInterface.BeneficiaryBank();
            }
        }
        /// <summary>
        /// Fill in beneficiary account number.
        /// </summary>
        public static void GetBeneficiaryAccounNumber()
        {
            UserInterface.BeneficiaryAccountNumber();
            string accountNumber = Console.ReadLine();
            Console.Clear();

            while (!(double.TryParse(accountNumber, out _beneficiaryAccountNumber)))
            {
                AnsiConsole.Write(new Markup("[red]Invalid account number entered\n[/]").Centered());
                AnsiConsole.Write(new Markup("[red]Re-Enter Account Number\n[/]").Centered());
                Thread.Sleep(2000);
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Account Number: [/]").Centered());
                accountNumber = Console.ReadLine();
            }
            Console.Clear();
            UserInterface.AccountType();
            GetBeneficiaryAccountType();
        }
        /// <summary>
        /// Choose an account type
        /// </summary>
        public static void GetBeneficiaryAccountType()
        {
            ConsoleKeyInfo userOption = Console.ReadKey();
            Console.Clear();

            if (userOption.Key == ConsoleKey.NumPad1)
            {
                UserInterface.TransferAmount();
            }
            else if (userOption.Key == ConsoleKey.NumPad2)
            {
                UserInterface.TransferAmount();
            }
            else
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
            }
            GetAmount();
        }
        /// <summary>
        /// Verify if user input is a valid amount.
        /// </summary>
        public static void GetAmount()
        {
            AnsiConsole.Write(new Markup("[blued]NGN:[/]"));
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
            AnsiConsole.Write(new Markup($"[blue]Bank:[/][red] {_beneficiaryBank}\n[/]"));
             var option = AnsiConsole.Prompt(
              new SelectionPrompt<string>()
             .AddChoices("Proceed")
             .AddChoices("Cancel"));

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
