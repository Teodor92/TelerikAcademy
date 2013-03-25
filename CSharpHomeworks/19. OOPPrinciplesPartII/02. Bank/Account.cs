using System;

public abstract class Account
{
    private Customer customer;
    private decimal balance;
    private decimal interestRate;

    // Constructors
    public Account(Customer customer, decimal balance, decimal interestRate)
    {
        this.customer = customer;
        this.balance = balance;
        this.interestRate = interestRate;
    }

    // Props
    public Customer Customer
    {
        get
        {
            return this.customer;
        }

        set
        {
            this.customer = value;
        }
    }

    public decimal Balance
    {
        get
        {
            return this.balance;
        }

        set
        {
            if (value >= 0)
            {
                this.balance = value;
            }
            else
            {
                throw new ArgumentException("No money!");
            }
        }
    }

    public decimal InterestRate
    {
        get
        {
            return this.interestRate;
        }

        set
        {
            this.interestRate = value;
        }
    }

    // Methods
    public virtual decimal ClacInterest(int numOfMounths)
    {
        return 0;
    }
}