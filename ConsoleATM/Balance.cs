using System;
using System.Globalization;
using System.Data.SqlClient;
using static ConsoleATM.Login;
using System.Threading;

namespace ConsoleATM
{
    class Balance
    {
        /// <summary>
        /// Returns account balance of a verified user
        /// at a specific date and time.
        /// </summary>
        public static void ShowBalance()
        {     
            try
            {
                string sqlStatement = $"Select * From Customer Where Pin = {user.Pin}";
                if (dbAccess.GetUser(user, sqlStatement))
                {
                    Console.WriteLine($"The balances on this account as at {DateTime.Now} are as follows.\n");
                    Console.WriteLine($"Current Balance\t\t:{user.Balance.ToString("C", CultureInfo.CurrentUICulture)}");
                    Console.WriteLine($"Available Balance\t:{user.Balance.ToString("C", CultureInfo.CurrentUICulture)}\n\n");
                    Console.WriteLine($"{Designs.AlignText(70, "0> Exit")}");
                    ConsoleKeyInfo option = Console.ReadKey();

                    if (option.Key == ConsoleKey.NumPad0)
                    {
                        UserInterface.NewTransaction();
                    }
                    else
                    {
                        Console.Clear();
                        Designs.CenterNewLine("Wrong Input!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Designs.CenterNewLine("Please take your card");
                        Environment.Exit(0);
                    }                    
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("There is an error while establishing a connection with the SqlServer");
            }           
        }
    }
}
