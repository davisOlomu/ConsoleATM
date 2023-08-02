using System;
using System.Threading;

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
                    Designs.CenterNewLine(e.Message);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (IncorrectPinException e)
                {
                    Console.Clear();
                    Designs.CenterNewLine(e.Message);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
    }
}
