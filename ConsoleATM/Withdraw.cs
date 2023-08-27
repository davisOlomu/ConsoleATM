using System;
using System.Threading;
using ConsoleBankDataAccess;
using static ConsoleATM.Login;
using Spectre.Console;

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
        private static  decimal _amount;

        /// <summary>
        /// Pick your account type. 
        /// </summary>
        public static void GetAccountType()
        {
            Console.Clear();
            UserInterface.AccountType();         
            GetAmount();
        }

        /// <summary>
        /// Select an amount from the list.
        /// Or opt to enter a custom amount.
        /// </summary>
        public static void GetAmount()
        {
            _amount = UserInterface.WithdrawalAmount();             
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
                AnsiConsole.Write(new Markup("[red]Please take your cash\n[/]").Centered());
                Thread.Sleep(6000);
                Console.Clear();
                UserInterface.TransactionCompleted();
                UserInterface.NewTransaction();
            }
            else
            {
                Console.Clear();
                AnsiConsole.Write(new Markup("[red]Insufficient funds!\n[/]").Centered());
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
