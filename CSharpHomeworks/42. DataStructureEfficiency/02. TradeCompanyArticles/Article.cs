namespace TradeCompanyArticles
{
    using System;

    public class Article : IComparable<Article>
    {
        private long barcode;
        private string vendor;
        private string title;
        private int price;

        public Article(long barcode, string vendor, string title, int price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public long Barcode
        {
            get
            {
                return this.barcode;
            }

            set
            {
                this.barcode = value;
            }
        }

        public string Vendor
        {
            get
            {
                return this.vendor;
            }

            set
            {
                this.vendor = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format(
                "Barcode: {0}, Vendor: {1}, Title: {2}, Price: {3}", 
                this.Barcode, 
                this.Vendor, 
                this.Title, 
                this.Price);
        }
    }
}
