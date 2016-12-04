using System;

namespace BranchingDemo
{
    class Program
    {   
        static void Main(string[] args)
        {
            var account = new Account(() => { });

            Console.Write("1#Situation NotVerified\n");
            Console.Write("Desposit 1000$\n");
            account.Deposit(1000);

            Console.Write("Balance actual: " + account.Balance + "\n");

            Console.Write("Withdraw 200\n");
            account.Withdraw(200);
            Console.Write("Balance actual: " + account.Balance + "\n");


            Console.Write("2#Situation Verified\n");
            Console.Write("HolderVerfied\n");
            account.HolderVerfied();

            Console.Write("Withdraw 200\n");
            account.Withdraw(200);

            Console.Write("Balance actual: " + account.Balance + "\n");
            
            Console.ReadLine();


            //implement control digits
            var controlDigit = ControlDigitAlgorithms.ForAccountingDepartament.GetControlDigit(12345);
        }

    }
}
