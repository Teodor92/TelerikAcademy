namespace Facade.Example
{
    /// <summary>
    /// Out customer class
    /// </summary>
    public class Customer
    {
        private string name;

        // Constructor
        public Customer(string name)
        {
            this.name = name;
        }

        // Gets the name
        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}