namespace StoreClasses
{
    using System;
    using System.Linq;
    using System.Text;

    public abstract class Product : IShowable, IComparable<Product> ////, IEquatable<Product>
    {
        // fileds
        private readonly int id;
        private string name;  
        private decimal price;

        // constructors
        protected Product(string name)
        {
            this.Name = name;
            this.id = IDGenerator.GetID();
        }

        protected Product(string name, int id)
            : this(name)
        {
            this.id = id;
        }

        protected Product(string name, int id, decimal price) : this(name, id)
        {
            this.Price = price;
        }

        // properties
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length <= 1 || value == null)
                {
                    throw new ArgumentException("Name is too short!");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cant be negative!");
                }

                this.price = value;
            }
        }

        // methods
        public static bool operator ==(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Id == secondProduct.Id;
        }

        public static bool operator !=(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Id != secondProduct.Id;
        }

        public virtual string Show()
        {
            StringBuilder endText = new StringBuilder();

            endText.AppendFormat("Name: {0}, Id: {1}", this.name, this.id);
            if (this.Price != 0)
            {
                endText.AppendFormat(", Price: {0}", this.price);
            }
            else
            {
                endText.Append(", Price: N/A");
            }

            return endText.ToString();
        }

        // virtual method override for dictonary - Teodor
        public int CompareTo(Product prod)
        {
            if (this.Id.CompareTo(prod.Id) != 0)
            {
                return this.Id.CompareTo(prod.Id);
            }
            else
            {
                return 0;
            }
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override bool Equals(object obj)
        {
            Product student = obj as Product;

            if (this.Id != student.Id)
            {
                return false;
            }

            return true;
        }
    }
}
