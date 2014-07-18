namespace StoreClasses
{
    using System;
    using System.Linq;

    public class NoProductsException : System.Exception
    {
        // TODO: make the exception
        public NoProductsException()
            : this("No products!", null, null)
        {
        }

        public NoProductsException(string msg)
            : this(msg, null, null)
        {
        }

        public NoProductsException(string msg, string productName)
            : this(msg, productName, null)
        {
        }

        public NoProductsException(string msg, string productName, Exception innerExcept = null)
            : base(msg, innerExcept)
        {
            this.ProductName = productName;
        }

        public string ProductName { get; set; }
    }
}
