namespace StoreClasses
{
    using System;
    using System.Linq;
    using System.Text;

    public struct Currency : IShowable
    {
        private decimal euro;
        private decimal usd;
        private decimal leva;

        // constructors
        public Currency(decimal euro, decimal usd, decimal leva)
            : this()
        {
            this.Euro = euro;
            this.Usd = usd;
            this.Leva = leva;
        }

        // properites
        public decimal Leva
        {
            get
            {
                return this.leva;
            }

            set
            {
                this.leva = value;
            }
        }

        public decimal Euro
        {
            get
            {
                return this.euro;
            }

            set
            {
                this.euro = value;
            }
        }

        public decimal Usd
        {
            get
            {
                return this.usd;
            }

            set
            {
                this.usd = value;
            }
        }

        public string Show()
        {
            // TODO: Optimize
            StringBuilder endText = new StringBuilder();
            endText.AppendFormat(" BGN account : {0} \n", this.Leva);
            endText.AppendFormat(" EURO account : {0} \n", this.Euro);
            endText.AppendFormat(" USD account : {0} \n", this.Usd);

            return endText.ToString();
        }
    }
}
