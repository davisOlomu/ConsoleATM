using System;
using System.Threading;
using Spectre.Console;

namespace ConsoleATM
{
    /// <summary>
    /// 
    /// </summary>
    internal class Validation
    {
        /// <summary>
        ///  Make sure user logged in is a valid user.
        /// </summary>
        public static void ValidatePin()
        {
            bool isNotPin = true;
            while (isNotPin)
            {
                try
                {
                    Login.VerifyUser();
                    isNotPin = false;
                }
                catch (InvalidPinException e)
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup($"[red]{e.Message}\n[/]").Centered());
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (IncorrectPinException e)
                {
                    Console.Clear();
                    AnsiConsole.Write(new Markup($"[red]{e.Message}\n[/]").Centered());
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
    }
}
