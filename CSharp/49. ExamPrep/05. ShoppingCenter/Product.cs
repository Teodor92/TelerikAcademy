namespace XXShoppingCenter
{
    using System;
    using System.Text;

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public string GetNameAndProducerKey()
        {
            string key = this.Name + ";" + this.Producer;
            return key;
        }

        public int CompareTo(Product other)
        {
            if (other == null)
            {
                return 0;
            }

            int resultOfCompare = this.Name.CompareTo(other.Name);

            if (resultOfCompare == 0)
            {
                resultOfCompare = this.Producer.CompareTo(other.Producer);
            }

            if (resultOfCompare == 0)
            {
                resultOfCompare = this.Price.CompareTo(other.Price);
            }

            return resultOfCompare;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append('{');
            output.AppendFormat("{0};{1};{2}", this.Name, this.Producer, this.Price);
            output.Append('}');
            return output.ToString();
        }
    }
}
