namespace StoreClasses
{
    using System;
    using System.Linq;
    using System.Text;

    public class CashRegister : IShowable
    {
        // fileds
        private Currency currencySumm = new Currency(0, 0, 0);
        private decimal dayRateOfUSD;
        private decimal dayRateOfEuro;
        
        // constructors
        public CashRegister(decimal dayRateOfEuro, decimal dayRateOfUsd)
        {
            this.DayRateOfEuro = dayRateOfEuro;
            this.DayRateOfUsd = dayRateOfUsd;
        }

        public decimal DayRateOfEuro
        {
            get
            {
                return this.dayRateOfEuro;
            }

            set
            {
                this.dayRateOfEuro = value;
            }
        }

        public decimal DayRateOfUsd
        {
            get
            {
                return this.dayRateOfUSD;
            }

            set
            {
                this.dayRateOfUSD = value;
            }
        }

        // Public methods
        public void AddMoney(decimal sum, CurruncyType type)
        {
            if (type == CurruncyType.Leva)
            {
                this.currencySumm.Leva += sum;
            }
            else if (type == CurruncyType.Euro)
            {
                this.currencySumm.Euro += sum;
            }
            else if (type == CurruncyType.USD)
            {
                this.currencySumm.Usd += sum;
            }
        }

        public void RemoveMoney(decimal sum, CurruncyType type)
        {
            if (type == CurruncyType.Leva)
            {
                this.currencySumm.Leva -= sum;
            }
            else if (type == CurruncyType.Euro)
            {
                this.currencySumm.Euro -= sum;
            }
            else if (type == CurruncyType.USD)
            {
                this.currencySumm.Usd -= sum;
            }
        }

        public string Show()
        {
            StringBuilder showText = new StringBuilder();
            showText.AppendFormat(this.currencySumm.Show());
            showText.AppendFormat("Total sum in Leva is: {0}", this.ConvertMoneyToLeva());

            return showText.ToString();
        }

        // internal methods
        internal string ConvertMoneyToLeva()
        {
            decimal sumAccountsInLeva = 0;
            sumAccountsInLeva = this.currencySumm.Leva + (this.currencySumm.Euro * this.DayRateOfEuro) + (this.currencySumm.Usd * this.DayRateOfUsd);

            return sumAccountsInLeva.ToString();
        }
    }
}