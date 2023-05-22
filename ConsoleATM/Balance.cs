using System;
using System.Globalization;
using System.Data.SqlClient;
using static ConsoleATM.Login;

namespace ConsoleATM
{
    class Balance
    {
        public static void GetBalance()
        {
            try
            {
                if (dbAccess.ReadFromCustomerWithPin(user))
                {
                    Console.WriteLine($"The balances on this account as at {DateTime.Now} are as follows.\n");

                    Console.WriteLine($"Current Balance\t\t:{user.Balance.ToString("C", CultureInfo.CurrentUICulture)}");
                    Console.WriteLine($"Available Balance\t:{user.Balance.ToString("C", CultureInfo.CurrentUICulture)}\n\n");

                    UserInterface.TransactionCompletedInterface();
                }
            }
            catch (SqlException)
            {
                throw;
            }           
        }
    }
}
