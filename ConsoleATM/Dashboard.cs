using System;
using System.Threading;
using static ConsoleATM.Login;

namespace ConsoleATM
{
    internal class Dashboard
    {
        static void Main()
        {
            Console.Title = "Console ATM";
            Console.SetWindowSize(100, 20);

            UserInterface.WelcomeInterface();

            // Check for a correct Pin
            bool inCorrectPin = true;

            while (inCorrectPin)
            {
                try
                {
                    GetPin();
                    inCorrectPin = false;
                }
                catch (InvalidPinException e)
                {
                    Console.Clear();
                    Designs.CenterNewLine(e.Message);

                    Thread.Sleep(3000);
                    Console.Clear();
                }
                catch (IncorrectPinException e)
                {
                    Console.Clear();
                    Designs.CenterNewLine(e.Message);

                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }
            var userTransaction = new Transactions();
            userTransaction.SelectTransaction();
        }
    }
}
