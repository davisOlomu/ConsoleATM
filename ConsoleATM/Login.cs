using System;
using ConsoleBankDataAccess;
using System.Data.SqlClient;

namespace ConsoleATM
{
    partial class Login
    {
        public static DataAccess dbAccess = new DataAccess();
        public static AccountModel user = new AccountModel();

        public static void GetPin()
        {
            Designs.CenterNewLine("ENTER FOUR DIGIT PIN-code.");
            Designs.CenterNewLine("Press <CANCEL> for cancellation");

            Console.Write("\tPIN ****");

            if (!int.TryParse(Console.ReadLine(), out int pin))
            {
                throw new InvalidPinException("Invalid PIN. Please enter a valid four-digit PIN.");             
            }

            user.Pin = pin;

            try
            {
                if (dbAccess.ReadFromCustomerWithPin(user))
                {
                    UserInterface.TransactionInterface();
                }
                else
                {
                    throw new IncorrectPinException("Incorrect PIN.");
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("");
            }        
        }
    }
}
