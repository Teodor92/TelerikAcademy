using System;

public class DepositAcc : Account, IDepositable, IWithdrawable
{
    public DepositAcc(Customer customer, decimal balance, decimal interest)
        : base(customer, balance, interest)
    {
    }

    public override decimal ClacInterest(int numOfMounths)
    {
        if (this.Balance <= 1000)
        {
            return 0;
        }
        else
        {
            return this.Balance * (this.InterestRate / 100) * numOfMounths;
        }
    }

    public void Deposit(int sum)
    {
        this.Balance = this.Balance + sum;
    }

    public void Withdraw(int sum)
    {
        try
        {
            this.Balance = this.Balance - sum;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}