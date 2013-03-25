using System;

public class Program
{
    public static void Main()
    {
        DepositAcc myAccount = new DepositAcc(Customer.Individual, 0, 1);

        myAccount.Deposit(2000);

        Console.WriteLine(myAccount.Balance);
        Console.WriteLine(myAccount.ClacInterest(10));

        myAccount.Withdraw(2000);

        Console.WriteLine(myAccount.Balance);

        Console.WriteLine(myAccount.ClacInterest(10));
    }
}