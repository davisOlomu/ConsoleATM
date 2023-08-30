using ConsoleBankDataAccess;
using Spectre.Console;
using System;
using System.Data.SqlClient;
using System.Globalization;
using static ConsoleATM.Login;

namespace ConsoleATM
{
    public static class Balance
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly DataLayer databaseAccess = new DataLayer();

        /// <summary>
        /// Returns account balance of a verified user
        /// at a specific date and time.
        /// </summary>
        public static void ShowBalance()
        {
            try
            {
                string sqlStatement = $"Select * From Customer Where Pin = {UserLoggedIn.Pin}";
                if (databaseAccess.GetUser(UserLoggedIn, sqlStatement))
                {
                    AnsiConsole.Write(new Markup($"[blue]The balances on this account as at [/][red]{DateTime.Now}[/][blue] are as follows.\n\n[/]"));
                    AnsiConsole.Write(new Markup($"[blue]Current Balance:\t\t[/][red]{UserLoggedIn.Balance.ToString("C", CultureInfo.CurrentUICulture)}\n[/]"));
                    AnsiConsole.Write(new Markup($"[blue]Available Balance:\t[/][red]{UserLoggedIn.Balance.ToString("C", CultureInfo.CurrentUICulture)}\n\n\n[/]"));
                    var option = AnsiConsole.Prompt(
                     new SelectionPrompt<string>()
                   .AddChoices("Menu")
                   .AddChoices("Exit"));

                    if (option.Contains("Menu"))
                    {
                        UserInterface.Transactions();
                    }
                    else if (option.Contains("Exit"))
                    {
                        Console.Clear();
                        AnsiConsole.Write(new Markup($"[red]Please take your card\n[/]").Centered());
                        Environment.Exit(0);
                    }
                }
            }
            catch (SqlException)
            {
                AnsiConsole.Write(new Markup($"[red]There is an error while establishing a connection with the SqlServer\n[/]").Centered());
            }
        }
    }
}
