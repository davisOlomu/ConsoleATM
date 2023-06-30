using System;
using System.Threading;
using ConsoleBankDataAccess;
using static ConsoleATM.Login;

namespace ConsoleATM
{
    /// <summary>
    /// All logical steps involved in making a withdrawal.
    /// </summary>
    class Withdraw
    {
        private static decimal transactionAmount = 0;

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
            ConsoleKeyInfo amountOption = Console.ReadKey();
            Console.Clear();

            switch (amountOption.Key)
            {
                case ConsoleKey.NumPad1:
                    transactionAmount = 500;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad2:
                    transactionAmount = 1000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad3:
                    transactionAmount = 2000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad4:
                    transactionAmount = 5000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad5:
                    transactionAmount = 10000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad6:
                    transactionAmount = 15000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad7:
                    transactionAmount = 20000;
                    UserInterface.TransactionProgress();
                    break;
                case ConsoleKey.NumPad8:
                    Console.Clear();              
                    Console.Write("\n\nEnter in multiples of 1000\n\n\t\t\t  N: ");
                    decimal amount;

                    if (decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        Console.Clear();
                        transactionAmount = amount;
                        UserInterface.TransactionProgress();
                    }
                    else
                    {
                        while (!decimal.TryParse(Console.ReadLine(), out amount))
                        {
                            Console.Clear();
                            Console.Write("\n\n\t\tEnter in multiples of 1000\n\n\t\t\t  N: ");

                            if (double.TryParse(Console.ReadLine(), out _))
                            {
                                Console.Clear();
                                transactionAmount = amount;
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
            var withdraw = new TransactionModel { TransactionDescription = "ATM Withdrawal", TransactionAmount = transactionAmount };

            if (transactionAmount <= user.Balance)
            {
                user.Balance -= transactionAmount;
                dbAccess.UpdateBalance(user, user.Balance);
                withdraw.TransactionStatus = TransactionStatus.Sucessfull;
                withdraw.TransactionType = TransactionType.Debit;
                dbAccess.CreateTransaction(withdraw, user.UserName);
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
