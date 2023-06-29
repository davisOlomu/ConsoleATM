using System;
using System.Threading;

namespace ConsoleATM
{
    class UserInterface
    {
        public static void Welcome()
        {
            Designs.CenterNewLine("Welcome...");
            Designs.CenterNewLine("Please insert your card.");
            Thread.Sleep(6500);
            Console.Clear();
        }
        public static void Transactions()
        {
            Console.Clear();
            Designs.CenterNewLine("CHOOSE A TRANSACTION");
            Designs.CenterNewLine("Press Cancel To Exit\n");
            Console.WriteLine($"{Designs.AlignText(25, "1> Withdrawal\t\t\t\t5> Cash transaction")}");
            Console.WriteLine($"{Designs.AlignText(25, "2> Transfer\t\t\t\t6> Balance")}");
            Console.WriteLine($"{Designs.AlignText(25, "3> Other Services\t\t\t7> Payment")}");
            Console.WriteLine($"{Designs.AlignText(25, "4> Online Banking\t\t\t8> Cancel")}");
        }
        public static void AccountType()
        {
            Designs.CenterNewLine("SELECT YOUR ACCOUNT TYPE");
            Designs.CenterNewLine("Press cancel to terminate transaction\n\n");
            Console.WriteLine($"{Designs.AlignText(70, "1> Savings")}");
            Console.WriteLine($"{Designs.AlignText(70, "2> Currents")}");
            Console.WriteLine($"{Designs.AlignText(70, "3> Cancel")}");
        }
        public static void TransactionProgress()
        {
            Designs.CenterNewLine("TRANSACTION IN PROGRESS\n");
            Designs.CenterNewLine("Please Wait");
            Thread.Sleep(7000);
            Console.Clear();
        }
        public static void WithdrawalAmount()
        {
            Designs.CenterNewLine("SELECT AMOUNT");
            Designs.CenterNewLine("Press Cancel To Terminate Transaction\n\n");
            Console.WriteLine($"{Designs.AlignText(28, "1> N500\t\t\t\t5> N10000")}");
            Console.WriteLine($"{Designs.AlignText(28, "2> N1000\t\t\t\t6> N15000")}");
            Console.WriteLine($"{Designs.AlignText(28, "3> N2000\t\t\t\t7> N20000")}");
            Console.WriteLine($"{Designs.AlignText(28, "4> N5000\t\t\t\t8> OTHER ")}");
            Console.WriteLine($"{Designs.AlignText(28, "9> Cancel")}");
        }
        public static void TransactionCompleted()
        {
            Designs.CenterNewLine("TRANSACTION COMPLETED\n\n");
            Designs.CenterNewLine("A notification will be sent");
            Designs.CenterNewLine("to you shortly");
        }
        public static void NewTransaction()
        {
            Console.Clear();
            Designs.CenterNewLine("Do you want to perform");
            Designs.CenterNewLine("another transaction?");
            Console.WriteLine($"{Designs.AlignText(70, "1> YES\n")}");
            Console.WriteLine($"{Designs.AlignText(70, "2> NO")}");
            ConsoleKeyInfo option = Console.ReadKey();

            if (option.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                Login.VerifyPin();
                Transactions transactions = new Transactions();
                transactions.SelectTransaction();
            }
            else if (option.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                Designs.CenterNewLine("Please take your card");
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Designs.CenterNewLine("Please take your card");
                Environment.Exit(0);
            }
        }
        public static void BeneficiaryBank()
        {
            Designs.CenterNewLine("SELECT BENEFICIARY BANK");
            Designs.CenterNewLine("Press cancel to terminate transaction\n");
            Console.WriteLine("1> Access Bank\n");
            Console.WriteLine("3> Diamond Bank\t\t\t\t\t2> (F-M)\n");
            Console.WriteLine("5> Eco Bank\t\t\t\t\t4> (N-S)\n");
            Console.WriteLine("7> Heritage Bank\t\t\t\t6> (T-Z)");
        }
        public static void BeneficiaryAccountNumber()
        {
            Designs.CenterNewLine("ENTER BENEFICIARY ACCOUNT NUMBER");
            Designs.CenterNewLine("Please press cancel to terminate transaction.\n\n");
            Console.WriteLine($"{Designs.AlignText(70, "> Enter")}");
        }
        public static void TransferAmount()
        {
            Designs.CenterNewLine("ENTER THE AMOUNT TO TRANSFER");
            Designs.CenterNewLine("Please press cancel to terminate transaction.\n\n");
            Console.WriteLine($"{Designs.AlignText(70, "> Enter")}");
        }
    }
}
