using System;
using System.Threading;
using static ConsoleATM.Login;

namespace ConsoleATM
{
    internal class Dashboard
    {
        /// <summary>
        /// Enter pin to login
        /// </summary>
        static void Main()
        {
            Console.Title = "Console ATM";
            Console.SetWindowSize(100, 20);
            UserInterface.Welcome();

            bool isNotPin = true;
            while (isNotPin)
            {
                try
                {
                    VerifyPin();
                    isNotPin = false;
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
            var transactionType = new Transactions();
            transactionType.SelectTransaction();
        }
    }
}
