namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Item
    {
        public int Value { get; set; }

        public int Weight { get; set; }

        public string Name { get; set; }

        public Item(string name, int value, int weight)
        {
            this.Value = value;
            this.Weight = weight;
            this.Name = name;
        }
    }
}
