namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Wintellect.PowerCollections;

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
            output.AppendFormat("{0};{1};", this.Name, this.Producer);
            output.Append(this.Price.ToString("0.00"));
            output.Append('}');
            return output.ToString();
        }
    }

    public class Program
    {
        private static MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);

        private static OrderedMultiDictionary<decimal, Product> productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);

        private static MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);

        private static MultiDictionary<string, Product> productsByNameAndProducer = new MultiDictionary<string, Product>(true);

        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            int numberOfCommands = int.Parse(Console.ReadLine());

            string[] commands = new string[numberOfCommands];

            for (int i = 0; i < numberOfCommands; i++)
            {
                commands[i] = Console.ReadLine();
            }

            ProcessCommands(commands);

            Console.WriteLine(output.ToString());
        }

        public static void ProcessCommands(string[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                int indexOfFirstSpace = commands[i].IndexOf(' ');
                string method = commands[i].Substring(0, indexOfFirstSpace);
                string parameterValues = commands[i].Substring(indexOfFirstSpace + 1);
                string[] parameters = parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                switch (method)
                {
                    case "AddProduct": AddProduct(parameters); 
                        break;
                    case "DeleteProducts":
                        if (parameters.Length == 2)
                        {
                            DeleteProduct(parameters);
                        }
                        else
                        {
                            DeleteProductByProducer(parameters);
                        }

                        break;
                    case "FindProductsByName": FindProductsByName(parameters); 
                        break;
                    case "FindProductsByPriceRange": FindProductsByPriceRange(parameters); 
                        break;
                    case "FindProductsByProducer": FindProductsByProducer(parameters); 
                        break;
                    default: throw new ArgumentException("Command was invalid.");
                }
            }
        }

        private static void DeleteProductByProducer(string[] commandParams)
        {
            string producerKey = commandParams[0];

            if (!productsByProducer.ContainsKey(producerKey))
            {
                output.AppendLine("No products found");
                return;
            }

            var productsToRemove = productsByProducer[producerKey];

            foreach (var item in productsToRemove)
            {
                productsByPrice.Remove(item.Price, item);
                productsByName.Remove(item.Name, item);
                productsByNameAndProducer.Remove(item.GetNameAndProducerKey(), item);
            }

            int removeCount = productsToRemove.Count;
            productsByProducer.Remove(producerKey);
            output.AppendFormat("{0} products deleted", removeCount);
            output.AppendLine();
        }

        private static void FindProductsByProducer(string[] commandParams)
        {
            if (!productsByProducer.ContainsKey(commandParams[0]))
            {
                output.AppendLine("No products found");
                return;
            }

            var productsFound = productsByProducer[commandParams[0]];

            List<Product> toPrint = new List<Product>(productsFound);
            toPrint.Sort();

            foreach (var item in toPrint)
            {
                output.AppendLine(item.ToString());
            }
        }

        private static void FindProductsByPriceRange(string[] commandParams)
        {
            var itemsFound = productsByPrice.Range(decimal.Parse(commandParams[0]), true, decimal.Parse(commandParams[1]), true).Values;

            if (itemsFound.Count == 0)
            {
                output.AppendLine("No products found");
                return;
            }
            else
            {
                List<Product> toPrint = new List<Product>(itemsFound);
                toPrint.Sort();

                foreach (var item in toPrint)
                {
                    output.AppendLine(item.ToString());
                }
            }
        }

        private static void FindProductsByName(string[] commandParams)
        {
            if (!productsByName.ContainsKey(commandParams[0]))
            {
                output.AppendLine("No products found");
                return;
            }

            var productsFound = productsByName[commandParams[0]];

            List<Product> toPrint = new List<Product>(productsFound);
            toPrint.Sort();

            foreach (var item in toPrint)
            {
                output.AppendLine(item.ToString());
            }
        }

        private static void DeleteProduct(string[] commandParams)
        {
            string key = commandParams[0] + ";" + commandParams[1];

            if (!productsByNameAndProducer.ContainsKey(key))
            {
                output.AppendLine("No products found");
                return;
            }

            var productsToRemove = productsByNameAndProducer[key];

            foreach (var prodcut in productsToRemove)
            {
                productsByName.Remove(prodcut.Name, prodcut);
                productsByPrice.Remove(prodcut.Price, prodcut);
                productsByProducer.Remove(prodcut.Producer, prodcut);
            }

            int removeCount = productsToRemove.Count;
            productsByNameAndProducer.Remove(key);
            output.AppendFormat("{0} products deleted", removeCount);
            output.AppendLine();
        }

        private static void AddProduct(string[] commandParams)
        {
            Product currentProduct = new Product(commandParams[0], decimal.Parse(commandParams[1]), commandParams[2]);
            productsByName.Add(currentProduct.Name, currentProduct);
            productsByPrice.Add(currentProduct.Price, currentProduct);
            productsByProducer.Add(currentProduct.Producer, currentProduct);
            productsByNameAndProducer.Add(currentProduct.GetNameAndProducerKey(), currentProduct);
            output.AppendLine("Product added");
        }
    }
}
