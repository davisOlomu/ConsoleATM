using ConsoleBankDataAccess;
using Spectre.Console;
using System.Data.SqlClient;

namespace ConsoleATM
{
    internal class Login
    {     
        private static AccountModel userLoggedIn = new AccountModel();
        private static readonly DataLayer databaseAccess = new DataLayer();

        /// <summary>
        /// Expose user currently logged in.
        /// </summary>
        public static AccountModel UserLoggedIn
        {
            get { return userLoggedIn; }
            set { userLoggedIn = value; }
        }
        /// <summary>
        /// Authenticate a valid user using user's four digit pin
        /// </summary>
        /// <param name="user">sucessfully logged in user</param>
        /// <exception cref="InvalidPinException"></exception>
        /// <exception cref="IncorrectPinException"></exception>
        public static void VerifyUser()
        {
            AnsiConsole.Write(new Markup("[blue]ENTER FOUR DIGIT PIN-code.\n[/]").Centered());
            AnsiConsole.Write(new Markup("[blue]Press <CANCEL> for cancellation[/]").Centered());
            var pinEntered = AnsiConsole.Prompt(
            new TextPrompt<string>("[blue]\tEnter PIN: [/]")
           .PromptStyle("red")
           .Secret());

            if (!int.TryParse(pinEntered, out int pin))
            {
                throw new InvalidPinException("Invalid PIN. Please enter a valid four-digit PIN.");
            }
            UserLoggedIn.Pin = pin;
            string sqlStatment = $"Select * From Customer Where Pin = {UserLoggedIn.Pin}";
            try
            {
                if (databaseAccess.GetUser(UserLoggedIn, sqlStatment))
                {
                    UserInterface.Transactions();
                }
                else
                {
                    throw new IncorrectPinException("Incorrect PIN.");
                }
            }
            catch (SqlException)
            {
                AnsiConsole.Write(new Markup("[red]There is an error while establishing a connection with the SqlServer[/]").Centered());
            }
        }
    }
}
