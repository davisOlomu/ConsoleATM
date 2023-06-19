using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleBankDataAccess;
using static ConsoleATM.Login;


namespace ConsoleATM
{
    class Transfer
    {
        private static decimal _transferAmount;

        private static ConsoleKeyInfo _selectBank;

        private static double _beneficiaryAccountNumber;

        private static string _beneficiaryBank;

        private static string[] _listOfBanks;


        // Transfer funds
        public static void BeneficiaryBank()
        {
            Console.Clear();
            UserInterface.BeneficiaryBankInterface();

            _selectBank = Console.ReadKey();
            Console.Clear();

            if (_selectBank.Key == ConsoleKey.NumPad1 || _selectBank.Key == ConsoleKey.NumPad3 || _selectBank.Key == ConsoleKey.NumPad5 || _selectBank.Key == ConsoleKey.NumPad7)
            {
                _listOfBanks = new[] { "Access Bank", "Diamond Bank", "Eco Bank", "Heritage Bank" };

                if (_selectBank.Key == ConsoleKey.NumPad1)
                    _beneficiaryBank = _listOfBanks[0];

                else if (_selectBank.Key == ConsoleKey.NumPad2)
                    _beneficiaryBank = _listOfBanks[1];

                else if (_selectBank.Key == ConsoleKey.NumPad3)
                    _beneficiaryBank = _listOfBanks[2];

                else if (_selectBank.Key == ConsoleKey.NumPad4)
                    _beneficiaryBank = _listOfBanks[3];

                BeneficiaryAccounNumber();

            }   
            if (_selectBank.Key == ConsoleKey.NumPad2)
            {
                List<string> displayBanks = new List<string> { "1> Fidelity Bank", "2> First Bank", "3> GT Bank\n\n" };

                foreach (string bankName in displayBanks)
                {
                    Console.WriteLine(bankName);
                }
                 
                _selectBank = Console.ReadKey();
                Console.Clear();

                if (_selectBank.Key == ConsoleKey.NumPad1 || _selectBank.Key == ConsoleKey.NumPad2 || _selectBank.Key == ConsoleKey.NumPad3)
                {
                    _listOfBanks = new[] { "Fidelity Bank", "First Bank", "GT Bank" };

                    if (_selectBank.Key == ConsoleKey.NumPad1)
                        _beneficiaryBank = _listOfBanks[0];

                    else if (_selectBank.Key == ConsoleKey.NumPad2)
                        _beneficiaryBank = _listOfBanks[1];

                    else if (_selectBank.Key == ConsoleKey.NumPad3)
                        _beneficiaryBank = _listOfBanks[2];

                    BeneficiaryAccounNumber();
                }
            }

            if (_selectBank.Key == ConsoleKey.NumPad4)
            {
                List<string> displayBanks = new List<string> { "1. Polaris Bank", "2. Stanbic IBTC", "3. Standard Chartered", "4. Sterling Bank\n\n" };

                foreach (string bankName in displayBanks)
                {
                    Console.WriteLine(bankName);

                }
                _selectBank = Console.ReadKey();
                Console.Clear();

                if (_selectBank.Key == ConsoleKey.NumPad1 || _selectBank.Key == ConsoleKey.NumPad2 || _selectBank.Key == ConsoleKey.NumPad3 || _selectBank.Key == ConsoleKey.NumPad4)
                {
                    _listOfBanks = new[] { "Polaris Bank", "Stanbic IBTC", "Standard Chartered", "Sterling Bank" };

                    if (_selectBank.Key == ConsoleKey.NumPad1)
                        _beneficiaryBank = _listOfBanks[0];

                    else if (_selectBank.Key == ConsoleKey.NumPad2)
                        _beneficiaryBank = _listOfBanks[1];

                    else if (_selectBank.Key == ConsoleKey.NumPad3)
                        _beneficiaryBank = _listOfBanks[2];
                    else if (_selectBank.Key == ConsoleKey.NumPad4)
                        _beneficiaryBank = _listOfBanks[3];

                    BeneficiaryAccounNumber();
                }
            }
        

            if (_selectBank.Key == ConsoleKey.NumPad6)
            {
                List<string> displayBanks = new List<string> { "1. Taj Bank", "2. Unity Bank", "3. Union Bank", "4. Wema Bank", "5. GTB", "6. Zenith Bank\n\n" };

                foreach (string bankName in displayBanks)
                {
                    Console.WriteLine(bankName);
                }             
                _selectBank = Console.ReadKey();
                Console.Clear();

                if (_selectBank.Key == ConsoleKey.NumPad1 || _selectBank.Key == ConsoleKey.NumPad2 || _selectBank.Key == ConsoleKey.NumPad3 || _selectBank.Key == ConsoleKey.NumPad4 || _selectBank.Key == ConsoleKey.NumPad5 || _selectBank.Key == ConsoleKey.NumPad6)
                {
                    _listOfBanks = new[] { "Taj Bank", " Unity Bank", "Union Bank", "Wema Bank", "GTB", "Zenith Bank" };

                    if (_selectBank.Key == ConsoleKey.NumPad1)
                        _beneficiaryBank = _listOfBanks[0];

                    else if (_selectBank.Key == ConsoleKey.NumPad2)
                        _beneficiaryBank = _listOfBanks[1];

                    else if (_selectBank.Key == ConsoleKey.NumPad3)
                        _beneficiaryBank = _listOfBanks[2];

                    else if (_selectBank.Key == ConsoleKey.NumPad4)
                        _beneficiaryBank = _listOfBanks[3];

                    else if (_selectBank.Key == ConsoleKey.NumPad5)
                        _beneficiaryBank = _listOfBanks[4];

                    else if (_selectBank.Key == ConsoleKey.NumPad6)
                        _beneficiaryBank = _listOfBanks[5];

                    BeneficiaryAccounNumber();
                }
            }
            else
            {
                Designs.CenterNewLine("Wrong Input!");
                Thread.Sleep(3000);

                Console.Clear();
                UserInterface.BeneficiaryBankInterface();
            }
        }


        // Beneficiary account number
        public static void BeneficiaryAccounNumber()
        {
            UserInterface.BeneficiaryAccountNumberInterface();
            string accoutNumberEntered = Console.ReadLine();

            Console.Clear();

            if (!double.TryParse(accoutNumberEntered, out _beneficiaryAccountNumber) || accoutNumberEntered.Length > 10 || accoutNumberEntered.Length > 10)
            {
                Designs.CenterNewLine("Invalid account number entered\n");
                Designs.CenterNewLine("Re-Enter Account Number");
                Thread.Sleep(2500);

                Console.Clear();
                BeneficiaryAccounNumber();
            }
            else
            {
                Console.Clear();
                UserInterface.AccountTypeInterface();
            }
            BeneficiaryAccountType();
        }


        // Beneficiary Account type
        public static void BeneficiaryAccountType()
        {
            ConsoleKeyInfo accountType = Console.ReadKey();
            Console.Clear();

            if (accountType.Key == ConsoleKey.NumPad1)
            {
                UserInterface.TransferAmountInterface();
            }
            else if (accountType.Key == ConsoleKey.NumPad2)
            {
                UserInterface.TransferAmountInterface();
            }
            else
            {
                Console.Clear();
                Designs.CenterNewLine("Please take your card");

                Environment.Exit(0);
            }
            TransferAmount();
        }


        // Enter transfer Amount 
        public static void TransferAmount()
        {
            Console.Write("NGN:");
            //  _transferAmount = decimal.Parse(Console.ReadLine());

            var transfer = new TransactionModel { TransactionDescription = "ATM Transfer", TransactionAmount = _transferAmount };

            if (decimal.TryParse(Console.ReadLine(), out _transferAmount))
            {
                if (_transferAmount <= user.Balance)
                {
                    user.Balance -= _transferAmount;
                    dbAccess.UpdateBalance(user, user.Balance);

                    transfer.TransactionStatus = TransactionStatus.Sucessfull;
                    transfer.TransactionType = TransactionType.Debit;

                    dbAccess.CreateTransaction(transfer, user.UserName);

                    ConfirmTransferDetails();
                }
                else
                {
                    Console.Clear();
                    Designs.CenterNewLine("Insufficient funds!\n");

                    //transfer.TransactionStatus = TransactionStatus.Unsucessfull;
                   // transfer.TransactionType = TransactionType.Debit;

                    TransferAmount();
                }
            }
            else
            {
                Console.Clear();
                Designs.CenterNewLine("Invalid amount format!\n");

             //   transfer.TransactionStatus = TransactionStatus.Unsucessfull;
             //   transfer.TransactionType = TransactionType.Debit;

                TransferAmount();
            }
        }


        // Confirm recepient details
        public static void ConfirmTransferDetails()
        {
            Console.Clear();
            Designs.CenterNewLine("Please confirm details of Transfer\n");

            Console.WriteLine("Account Number: " + _beneficiaryAccountNumber);
            Console.WriteLine("Amount:NGN " + _transferAmount);
            Console.WriteLine("Bank: " + _beneficiaryBank);

            Console.WriteLine($"{Designs.AlignText(70, "1. Proceed")}");
            Console.WriteLine($"{Designs.AlignText(70, "2. Cancel")}");

            ConsoleKeyInfo confirmInput = Console.ReadKey();
            Console.Clear();

            if (confirmInput.Key == ConsoleKey.NumPad1)
            {
                UserInterface.TransactionInProgressInterface();
                Console.Clear();

                UserInterface.TransactionCompletedInterface();
                UserInterface.NewTransactionInterface();
            }
            else if (confirmInput.Key == ConsoleKey.NumPad2)
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
