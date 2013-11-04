namespace PriceRangeSearch
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public int CompareTo(Product obj)
        {
            if (obj == null)
            {
                return 1;    
            }

            return this.Price.CompareTo(obj.Price);
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Price: {1:C}", this.Name, this.Price);
        }
    }
}
