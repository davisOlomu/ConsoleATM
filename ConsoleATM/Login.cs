using System;
using ConsoleBankDataAccess;
using System.Data.SqlClient;

namespace ConsoleATM
{
    internal class Login
    {
        /// <summary> 
        /// Wrong code approach
        /// Exposing static data
        /// Looking for a solution
        /// </summary>
        public static AccountModel user = new AccountModel();
        private static readonly DataLayer databaseAccess = new DataLayer();

        /// <summary>
        /// Authenticate a valid user using user's four digit pin
        /// </summary>
        /// <param name="user">sucessfully logged in user</param>
        /// <exception cref="InvalidPinException"></exception>
        /// <exception cref="IncorrectPinException"></exception>
        public static void VerifyUser()
        {
            Designs.CenterNewLine("ENTER FOUR DIGIT PIN-code.");
            Designs.CenterNewLine("Press <CANCEL> for cancellation");
            Console.Write("\tPIN **** ");

            if (!int.TryParse(Console.ReadLine(), out int pin))
            {
                throw new InvalidPinException("Invalid PIN. Please enter a valid four-digit PIN.");
            }
            user.Pin = pin;
            string sqlStatment = $"Select * From Customer Where Pin = {user.Pin}";
            try
            {
                if (databaseAccess.GetUser(user, sqlStatment))
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
                Console.WriteLine("There is an error while establishing a connection with the SqlServer");
            }
        }
    }
}
