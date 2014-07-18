namespace StoreClasses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Storage : IShowable, IAddable, IRemoveable
    {
        private Dictionary<Product, int> myStorage;

        // constructor
        public Storage()
        {
            this.myStorage = new Dictionary<Product, int>();
        }

        // properties

        // methods
        public Dictionary<Product, int> MyStorage
        {
            get
            {
                return this.myStorage;
            }

            set
            {
                this.myStorage = value;
            }
        }

        // DB Loader for testing 
        // TODO: Make a new class for DB Managment ?
        public void LoadDB()
        {
            using (StreamReader dbLoad = new StreamReader(@"../../../StoreClasses/StoreDB.txt"))
            {
                string line = dbLoad.ReadLine();

                while (line != null)
                {
                    string[] productComponets = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (productComponets[0] == "1")
                    {
                        this.AddObject(new Game(
                            productComponets[1],
                            int.Parse(productComponets[2]),
                            decimal.Parse(productComponets[3]),
                            productComponets[4],
                            int.Parse(productComponets[5]),
                            productComponets[6]));
                    }
                    else
                    {
                        this.AddObject(new Movie(
                            productComponets[1],
                            int.Parse(productComponets[2]),
                            decimal.Parse(productComponets[3]),
                            int.Parse(productComponets[4]),
                            productComponets[5],
                            int.Parse(productComponets[6])));
                    }

                    line = dbLoad.ReadLine();
                }
            }
        }

        // Show product info
        public string Show()
        {
            if (this.myStorage.Count == 0)
            {
                return "Nothing on store!";
            }

            StringBuilder endText = new StringBuilder();

            foreach (var proudct in this.myStorage)
            {
                endText.AppendFormat("Type: {0}, {1}, Quantity: {2} \n", proudct.Key.GetType().Name, proudct.Key.Show(), proudct.Value.ToString());
            }

            return endText.ToString();
        }

        // Added Product and check if in the storage
        public void AddObject(Product myProduct)
        {
            if (this.myStorage.ContainsKey(myProduct))
            {
                this.myStorage[myProduct]++;
            }
            else
            {
                this.myStorage.Add(myProduct, 1);
            }
        }

        // Remove single product
        public void RemoveObject(Product myProduct)
        {
            if (this.myStorage.ContainsKey(myProduct))
            {
                this.myStorage[myProduct]--;
            }
            else
            {
                throw new NoProductsException("No such product!");
            }
        }

        // Remove all quantity from product
        public void RemoveAll(Product myProduct)
        {
            if (this.myStorage.ContainsKey(myProduct))
            {
                this.myStorage[myProduct] = 0;
            }
            else
            {
                throw new NoProductsException("No such product!");
            }
        }

        // Remove product entry from storage
        public void RemoveProductFromStorage(Product myProduct)
        {
            if (this.myStorage.ContainsKey(myProduct))
            {
                this.myStorage.Remove(myProduct);
            }
            else
            {
                throw new NoProductsException("No such product!");
            }
        }

        // Search optinos
        // Search by ID
        public void SearchByID(int id)
        {
            int count = 0;
            foreach (var product in this.myStorage)
            {
                if (product.Key.Id == id)
                {
                    Console.WriteLine(product.Key.Show());
                    count++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Search ended! \nThere are {0} products answered to your search!", count);
        }

        // Searching by name
        public void SearchByName(string name)
        {
            var endText = new StringBuilder();
            int count = 0;
            foreach (var product in this.myStorage)
            {
                if (product.Key.Name.Contains(name))
                {
                    endText.AppendFormat("Type: {0} {1} \n", product.Key.GetType().Name, product.Key.Show());
                    count++;
                }
            }

            Console.WriteLine(endText.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Search ended! \n There are {0} results to your search!", count);
        }

        // TODO Add more search options
    }
}
