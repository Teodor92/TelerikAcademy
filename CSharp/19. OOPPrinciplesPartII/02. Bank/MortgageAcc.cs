using System;

public class MortgageAcc : Account, IDepositable
{
    public MortgageAcc(Customer customer, decimal balance, decimal interest)
        : base(customer, balance, interest)
    {
    }

    public override decimal ClacInterest(int numOfMounths)
    {
        if (this.Customer == Customer.Company && numOfMounths <= 12)
        {
            return this.Balance * (this.InterestRate / 100 / 2) * numOfMounths;
        }
        else if (this.Customer == Customer.Individual && numOfMounths <= 6)
        {
            return 0;
        }
        else if (this.Customer == Customer.Company)
        {
            return (this.Balance * (this.InterestRate / 100 / 2) * 12) + (numOfMounths * (this.InterestRate / 100) * (numOfMounths - 12));
        }
        else
        {
            return this.Balance * (this.InterestRate / 100) * (numOfMounths - 6);
        }
    }

    public void Deposit(int sum)
    {
        this.Balance = this.Balance + sum;
    }
}