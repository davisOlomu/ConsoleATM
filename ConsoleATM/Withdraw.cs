using System;
using System.Threading;
using ConsoleBankDataAccess;
using static ConsoleATM.Login;

namespace ConsoleATM
{
    /// <summary>
    /// All logical steps involved in making a withdrawal.
    /// </summary>
    internal static class Withdraw
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly DataLayer databaseAccess = new DataLayer();
        private static decimal _amount;

        /// <summary>
        /// Pick your account type. 
        /// </summary>
        public static void GetAccountType()
        {
            Console.Clear();
            UserInterface.AccountType();
            ConsoleKeyInfo accountType = Console.ReadKey();
            Console.Clear();

            if (accountType.Key == ConsoleKey.NumPad1 || accountType.Key == ConsoleKey.NumPad2)
            {
                UserInterface.WithdrawalAmount();
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
        /// Select an amount from the list.
        /// Or opt to enter a custom amount.
        /// </summary>
        public static void GetAmount()
        {
            ConsoleKeyInfo amount = Console.ReadKey();
            Console.Clear();

            switch (amount.Key)
            {
                case ConsoleKey.NumPad1:
                    _amount = 500;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad2:
                    _amount = 1000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad3:
                    _amount = 2000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad4:
                    _amount = 5000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad5:
                    _amount = 10000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad6:
                    _amount = 15000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad7:
                    _amount = 20000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad8:
                    Console.Clear();              
                    Console.Write("\n\nEnter in multiples of 1000\n\n\t\t\t  #:");
                    decimal customAmount;

                    if (decimal.TryParse(Console.ReadLine(), out customAmount))
                    {
                        Console.Clear();
                        _amount = customAmount;
                        UserInterface.TransactionProgress();
                    }
                    else
                    {
                        while (!decimal.TryParse(Console.ReadLine(), out customAmount))
                        {
                            Console.Clear();
                            Console.Write("\n\n\t\tEnter in multiples of 1000\n\n\t\t\t  N: ");

                            if (double.TryParse(Console.ReadLine(), out _))
                            {
                                Console.Clear();
                                _amount = customAmount;
                                UserInterface.TransactionProgress();
                            }
                        }
                    }
                    break;
                case ConsoleKey.NumPad9:
                    Console.Clear();
                    Designs.CenterNewLine("Please take your card ");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Designs.CenterNewLine("Wrong Input!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Designs.CenterNewLine("Please take your card ");
                    Environment.Exit(0);
                    break;
            }
            GetStatus();
        }

        /// <summary>
        ///  Get notifications about the current transaction.
        /// </summary>
        public static void GetStatus()
        {
            var withdraw = new TransactionModel { TransactionDescription = "ATM Withdrawal", TransactionAmount = _amount };

            if (_amount <= UserLoggedIn.Balance)
            {
                UserLoggedIn.Balance -= _amount;
                databaseAccess.UpdateBalance(UserLoggedIn, UserLoggedIn.Balance);
                withdraw.TransactionStatus = TransactionStatus.Sucessfull;
                withdraw.TransactionType = TransactionType.Debit;
                databaseAccess.CreateTransaction(withdraw, UserLoggedIn.UserName);
                UserInterface.TransactionProgress();
                Designs.CenterNewLine("Please take your cash");
                Thread.Sleep(6000);
                Console.Clear();
                UserInterface.TransactionCompleted();
                UserInterface.NewTransaction();
            }
            else
            {
                Console.Clear();
                Designs.CenterNewLine("Insufficient funds!\n");
                withdraw.TransactionStatus = TransactionStatus.Unsucessfull;
                withdraw.TransactionType = TransactionType.Debit;
                Thread.Sleep(3000);
                Console.Clear();
                UserInterface.WithdrawalAmount();
                GetAmount();
            }
        }
    }
}
