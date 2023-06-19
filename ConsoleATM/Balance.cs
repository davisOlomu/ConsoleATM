using System;
using System.Globalization;
using System.Data.SqlClient;
using static ConsoleATM.Login;
using System.Threading;

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


                    Console.WriteLine($"{Designs.AlignText(70, "0> Exit")}");
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.NumPad0)
                    {
                        UserInterface.NewTransactionInterface();
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
