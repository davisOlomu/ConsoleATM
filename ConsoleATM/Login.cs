using System;
using ConsoleBankDataAccess;
using System.Data.SqlClient;

namespace ConsoleATM
{
    partial class Login
    {
        // wrong code approach
        // exposing static data
        // looking for a solution
        public static AccountModel user = new AccountModel();
        public static DataLayer dbAccess = new DataLayer();
        public static void VerifyPin()
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
                if (dbAccess.GetUser(user, sqlStatment))
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
