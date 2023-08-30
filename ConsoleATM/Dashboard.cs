﻿using System;

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
            Validation.ValidatePin();
            UserInterface.Transactions();
        }
    }
}
