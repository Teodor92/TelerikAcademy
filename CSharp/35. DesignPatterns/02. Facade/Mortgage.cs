namespace Facade.Example
{
    using System;

    /// <summary>
    /// Our Facade class
    /// </summary>
    public class Mortgage
    {
        private Bank bank = new Bank();

        private Loan loan = new Loan();

        private Credit credit = new Credit();

        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine(
                "{0} applies for {1:C} loan\n",
                cust.Name, 
                amount);

            bool eligible = true;

            // Check creditworthyness of applicant
            if (!this.bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!this.loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!this.credit.HasGoodCredit(cust))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}