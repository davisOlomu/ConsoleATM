using Spectre.Console;
using System;
using System.Threading;

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
            AnsiConsole.Write(new Markup("[blue]\n\nCHOOSE A TRANSACTION[/]\n").Centered());
            AnsiConsole.Write(new Markup("[blue]Press Cancel To Exit[/]\n\n").Centered());
            string withdraw = "Withdrawal".PadLeft(42);
            string cash = "Cash transaction".PadLeft(69);
            string transfer = "Transfer".PadLeft(40);
            string balance = "Balance".PadLeft(60);
            string others = "Other Services".PadLeft(46);
            string payment = "Payment".PadLeft(60);
            string online = "Online Banking".PadLeft(46);
            string cancel = "Cancel".PadLeft(59);
            var menuItem = AnsiConsole.Prompt(new SelectionPrompt<string>()
           .AddChoices(withdraw)
           .AddChoices(cash)
           .AddChoices(transfer)
           .AddChoices(balance)
           .AddChoices(others)
           .AddChoices(payment)
           .AddChoices(online)
           .AddChoices(cancel));

            if (menuItem.Contains("Withdrawal"))
            {
                Console.Clear();
                Withdraw.GetAccountType();
            }
            else if (menuItem.Contains("Cash"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[blue]Under Construction!\n[/]").Centered());
                Thread.Sleep(3000);
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
            }
            else if (menuItem.Contains("Balance"))
            {
                Console.Clear();
                Balance.ShowBalance();
            }
            else if (menuItem.Contains("Transfer"))
            {
                Console.Clear();
                Transfer.GetBeneficiaryBank();
            }
            else if (menuItem.Contains("Other"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Under Construction!\n[/]").Centered());
                Thread.Sleep(3000);
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                AnsiConsole.WriteLine("\n\n");
            }
            else if (menuItem.Contains("Payment"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Under Construction!\n[/]").Centered());
                Thread.Sleep(3000);
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
            }
            else if (menuItem.Contains("Online"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Under Construction!\n[/]").Centered());
                Thread.Sleep(3000);
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
            }
            else if (menuItem.Contains("Cancel"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
                Console.Clear();
            }
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

            while (true)
            {
                if (accountype.Contains("Savings"))
                {
                    Console.Clear();
                    break;
                }
                else if (accountype.Contains("Current"))
                {
                    Console.Clear();
                    break;
                }
                else if (accountype.Contains("Cancel"))
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                }
            }
        }

        public static void TransactionProgress()
        {
            AnsiConsole.Write(new Markup("[red]TRANSACTION IN PROGRESS[/]\n").Centered());
            AnsiConsole.Write(new Markup("[red]Please Wait[/]").Centered());
            Thread.Sleep(7000);
            Console.Clear();
        }

        public static decimal WithdrawalAmount()
        {
            AnsiConsole.Write(new Markup("[blue]\n\nSELECT AMOUNT[/]\n").Centered());
            AnsiConsole.Write(new Markup("[blue]Press Cancel To Terminate Transaction\n\n[/]").Centered());
            string fiveHundred = "N500".PadLeft(37);
            string tenThousand = "N10000".PadLeft(63);
            string oneThousand = "N1000".PadLeft(38);
            string fifteenThousand = "N15000".PadLeft(63);
            string twoThousand = "N2000".PadLeft(38);
            string twentyThousand = "N20000".PadLeft(63);
            string fiveThousand = "N5000".PadLeft(38);
            string other = "OTHER".PadLeft(62);
            string cancel = "Cancel".PadLeft(39);
            var menuItem = AnsiConsole.Prompt(new SelectionPrompt<string>()
           .AddChoices(fiveHundred)
           .AddChoices(tenThousand)
           .AddChoices(oneThousand)
           .AddChoices(fifteenThousand)
           .AddChoices(twoThousand)
           .AddChoices(twentyThousand)
           .AddChoices(fiveThousand)
           .AddChoices(other)
           .AddChoices(cancel));

            decimal amount = 0;
            if (menuItem.Contains("N500"))
            {
                Console.Clear();
                amount = 500;
            }
            else if (menuItem.Contains("N10000"))
            {
                Console.Clear();
                amount = 10000;
            }
            else if (menuItem.Contains("N1000"))
            {
                Console.Clear();
                amount = 1000;
            }
            else if (menuItem.Contains("N15000"))
            {
                Console.Clear();
                amount = 15000;
            }
            else if (menuItem.Contains("N2000"))
            {
                Console.Clear();
                amount = 2000;
            }
            else if (menuItem.Contains("N5000"))
            {
                Console.Clear();
                amount = 5000;
            }
            else if (menuItem.Contains("N20000"))
            {
                Console.Clear();
                amount = 20000;
            }
            else if (menuItem.Contains("OTHER"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[blue]\n\nEnter in multiples of 1000\n\n[/]").Centered());

                AnsiConsole.Write(new Markup("[red]N[/]").Centered());
                Console.SetCursorPosition(51, 5);
                decimal customAmount;

                if (decimal.TryParse(Console.ReadLine(), out customAmount))
                {
                    Console.Clear();
                    amount = customAmount;
                }
                else
                {
                    while (!decimal.TryParse(Console.ReadLine(), out customAmount))
                    {
                        Console.Clear();
                        AnsiConsole.Write(new Markup("[red]\n\nEnter in multiples of 1000\n\n\t\t\t  N:\n[/]").Centered());

                        if (double.TryParse(Console.ReadLine(), out _))
                        {
                            Console.Clear();
                            amount = customAmount;
                        }
                    }
                }
            }
            else if (menuItem.Contains("Cancel"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Wrong Input!\n[/]").Centered());
                Thread.Sleep(2000);
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
            }
            return amount;
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
            AnsiConsole.Write(new Markup("[red]Do you want to perform\n[/]").Centered());
            AnsiConsole.Write(new Markup("[red]another transaction?[/]").Centered());
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
           .AddChoices("YES")
           .AddChoices("NO"));

            if (option.Contains("YES"))
            {
                Console.Clear();
                Login.VerifyUser();
                Transactions();
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

        public static string BeneficiaryBank()
        {
            AnsiConsole.Write(new Markup("[blue]\n\nSELECT BENEFICIARY BANK\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]Press cancel to terminate transaction\n\n[/]").Centered());
            string access = "Access Bank".PadLeft(47);
            string diamond = "Diamond Bank".PadLeft(48);
            string fm = "(F-M)".PadLeft(60);
            string eco = "Eco Bank".PadLeft(44);
            string ns = "(N-S)".PadLeft(60);
            string heritage = "Heritage Bank".PadLeft(49);
            string tz = "(T-Z)".PadLeft(60);
            string cancel = "Cancel".PadLeft(42);
            var menuItem = AnsiConsole.Prompt(new SelectionPrompt<string>()
           .AddChoices(access + "\n")
           .AddChoices(diamond)
           .AddChoices(fm)
           .AddChoices(eco)
           .AddChoices(ns)
           .AddChoices(heritage)
           .AddChoices(tz)
           .AddChoices(cancel));
            Console.Clear();

            string beneficiaryBank = "";

            if (menuItem.Contains("Access"))
            {
                beneficiaryBank = "Access Bank";
            }
            else if (menuItem.Contains("Diamond"))
            {
                beneficiaryBank = "Diamond Bank";
            }
            else if (menuItem.Contains("Eco"))
            {
                beneficiaryBank = "Eco Bank";
            }
            else if (menuItem.Contains("Heritage"))
            {
                beneficiaryBank = "Heritage Bank";
            }
            else if (menuItem.Contains("(F-M)"))
            {
                Console.Clear();
                string cancl = "Cancel".PadLeft(33);
                string ext = "Exit".PadLeft(31);
                var bank = AnsiConsole.Prompt(new SelectionPrompt<string>()
                 .AddChoices("Fidelity Bank")
                 .AddChoices("First Bank")
                 .AddChoices("GT Bank")
                 .AddChoices(cancl)
                 .AddChoices(ext));
                Console.Clear();

                if (bank.Contains("Fidelity"))
                {
                    beneficiaryBank = "Fidelity Bank";
                }
                else if (bank.Contains("First"))
                {
                    beneficiaryBank = "First Bank";
                }
                else if (bank.Contains("GT"))
                {
                    beneficiaryBank = "GT Bank";
                }
                else if (bank.Contains(cancl))
                {
                    Console.Clear();
                    Transactions();
                }
                else if (bank.Contains(ext))
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup($"[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                }
            }

            else if (menuItem.Contains("(N-S)"))
            {
                Console.Clear();
                string cancl = "Cancel".PadLeft(33);
                string ext = "Exit".PadLeft(31);
                var bank = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Polaris Bank")
                .AddChoices("Stanbic IBTC")
                .AddChoices("Standard Chartered")
                .AddChoices("Sterling Bank")
                .AddChoices(cancl)
                .AddChoices(ext));
                Console.Clear();

                if (bank.Contains("Polaris"))
                {
                    beneficiaryBank = "Polaris Bank";
                }
                else if (bank.Contains("Stanbic"))
                {
                    beneficiaryBank = "Stanbic IBTC";
                }
                else if (bank.Contains("Standard"))
                {
                    beneficiaryBank = "Standard Chartered";
                }
                else if (bank.Contains("Sterling"))
                {
                    beneficiaryBank = "Sterling Bank";
                }
                else if (bank.Contains(cancl))
                {
                    Console.Clear();
                    Transactions();
                }
                else if (bank.Contains(ext))
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup($"[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                }
            }

            else if (menuItem.Contains("(T-Z)"))
            {
                Console.Clear();
                string cancl = "Cancel".PadLeft(33);
                string ext = "Exit".PadLeft(31);
                var bank = AnsiConsole.Prompt(new SelectionPrompt<string>()
                 .AddChoices("Taj Bank")
                 .AddChoices("Unity Bank")
                 .AddChoices("Union Bank")
                 .AddChoices("Wema Bank")
                 .AddChoices("GTB")
                 .AddChoices("Zenith Bank")
                 .AddChoices(cancl)
                 .AddChoices(ext));
                Console.Clear();

                if (bank.Contains("Taj"))
                {
                    beneficiaryBank = "Taj Bank";
                }
                else if (bank.Contains("Unity"))
                {
                    beneficiaryBank = "Unity Bank";
                }
                else if (bank.Contains("Union"))
                {
                    beneficiaryBank = "Union Bank";
                }
                else if (bank.Contains("Wema"))
                {
                    beneficiaryBank = "Wema Bank";
                }
                else if (bank.Contains("GTB"))
                {
                    beneficiaryBank = "GTB";
                }
                else if (bank.Contains("Zenith"))
                {
                    beneficiaryBank = "Zenith Bank";
                }
                else if (bank.Contains(cancl))
                {
                    Console.Clear();
                    Transactions();
                }
                else if (bank.Contains(ext))
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup($"[red]Please take your card\n[/]").Centered());
                    Environment.Exit(0);
                }
            }
            else
            {
                AnsiConsole.Write(new Markup("[red]Wrong Input!\n[/]").Centered());
                Thread.Sleep(3000);
                Console.Clear();
                BeneficiaryBank();
            }
            return beneficiaryBank;
        }
        public static double BeneficiaryAccountNumber()
        {
            AnsiConsole.Write(new Markup("[blue]ENTER BENEFICIARY ACCOUNT NUMBER\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]Please press cancel to terminate transaction.\n\n[/]").Centered());
            var option = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
           .AddChoices("Enter")
           .AddChoices("Cancel"));
            double beneficiaryAccountNumber = 0;

            if (option.Contains("Enter"))
            {
                string accountNumber = Console.ReadLine();
                Console.Clear();

                while (!(double.TryParse(accountNumber, out beneficiaryAccountNumber)))
                {
                    AnsiConsole.Write(new Markup("[red]Invalid account number entered\n[/]").Centered());
                    AnsiConsole.Write(new Markup("[red]Re-Enter Account Number\n[/]").Centered());
                    Thread.Sleep(2000);
                    Console.Clear();
                    AnsiConsole.Write(new Markup("[red]Account Number: [/]").Centered());
                    accountNumber = Console.ReadLine();
                }
                Console.Clear();
            }
            else if (option.Contains("Cancel"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup($"[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
            }
            return beneficiaryAccountNumber;
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

            if (option.Contains("Enter"))
            {
             
            }
            else if (option.Contains("Cancel"))
            {
                Console.Clear();
                AnsiConsole.Write(new Markup($"[red]Please take your card\n[/]").Centered());
                Environment.Exit(0);
            }
        }
    }
}
