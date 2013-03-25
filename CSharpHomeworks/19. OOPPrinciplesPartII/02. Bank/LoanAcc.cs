using System;

public class LoanAcc : Account, IDepositable
{
    public LoanAcc(Customer customer, decimal balance, decimal interest)
        : base(customer, balance, interest)
    {
    }

    public override decimal ClacInterest(int numOfMounths)
    {
        if (numOfMounths <= 2 && this.Customer == Customer.Company)
        {
            return 0;
        }
        else if (numOfMounths <= 3 && this.Customer == Customer.Individual)
        {
            return 0;
        }
        else if (this.Customer == Customer.Company)
        {
            return this.Balance * (this.InterestRate / 100) * (numOfMounths - 2);
        }
        else
        {
            return this.Balance * (this.InterestRate / 100) * (numOfMounths - 3);
        }
    }

    public void Deposit(int sum)
    {
        this.Balance = this.Balance + sum;
    }
}