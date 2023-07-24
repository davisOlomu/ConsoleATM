using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleBankDataAccess;
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
                Designs.CenterNewLine("Wrong Input!");
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
                Designs.CenterNewLine("Invalid account number entered\n");
                Designs.CenterNewLine("Re-Enter Account Number");
                Thread.Sleep(2000);
                Console.Clear();
                Console.Write("Account Number: ");
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
                Designs.CenterNewLine("Please take your card");
                Environment.Exit(0);
            }
            GetAmount();
        }

        /// <summary>
        /// Verify if user input is a valid amount.
        /// </summary>
        public static void GetAmount()
        {
            Console.Write("NGN:");
            var transfer = new TransactionModel { TransactionDescription = "ATM Transfer", TransactionAmount = _amount };

            while (!(decimal.TryParse(Console.ReadLine(), out _amount)))
            {
                Console.Clear();
                Designs.CenterNewLine("Invalid amount format!\n");
                Thread.Sleep(2000);
                Console.Clear();
                Console.Write("NGN:");
            }
            while (!(_amount <= user.Balance))
            {
                Console.Clear();
                Designs.CenterNewLine("Insufficient funds!\n");
                Thread.Sleep(2000);
                Console.Clear();
                Console.Write("NGN:");
                decimal.TryParse(Console.ReadLine(), out _amount);
            }
            user.Balance -= _amount;
            databaseAccess.UpdateBalance(user, user.Balance);
            transfer.TransactionStatus = TransactionStatus.Sucessfull;
            transfer.TransactionType = TransactionType.Debit;
            databaseAccess.CreateTransaction(transfer, user.UserName);
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
            Designs.CenterNewLine("Please confirm details of Transfer\n");
            Console.WriteLine("Account Number: " + _beneficiaryAccountNumber);
            Console.WriteLine("Amount:NGN " + _amount);
            Console.WriteLine("Bank: " + _beneficiaryBank);
            Console.WriteLine($"{Designs.AlignText(70, "1. Proceed")}");
            Console.WriteLine($"{Designs.AlignText(70, "2. Cancel")}");
            ConsoleKeyInfo userOption = Console.ReadKey();
            Console.Clear();

            if (userOption.Key == ConsoleKey.NumPad1)
            {
                UserInterface.TransactionProgress();
                Console.Clear();
                UserInterface.TransactionCompleted();
                UserInterface.NewTransaction();
            }
            else if (userOption.Key == ConsoleKey.NumPad2)
            {
                Designs.CenterNewLine("Please take your card");
                Environment.Exit(0);
            }
            else
            {
                Designs.CenterNewLine("Please take your card");
                Environment.Exit(0);
            }
        }
    }
}
