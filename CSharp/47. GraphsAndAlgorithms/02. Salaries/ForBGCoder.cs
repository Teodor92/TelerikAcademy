namespace BGCoderSalaries
{
    /* 
     * Sadly a.t.m the contest can not be practiced in BGCoder 
     */

    using System;
    using System.Collections.Generic;

    public class Node
    {
        private List<Node> childern;

        public Node(int nodeId)
        {
            this.NodeId = nodeId;
            this.Salary = 0m;
            this.childern = new List<Node>();
        }

        public int NodeId { get; set; }

        public decimal Salary { get; set; }

        public List<Node> ChildernList
        {
            get
            {
                return this.childern;
            }

            set
            {
                this.childern = value;
            }
        }

        public int Childern
        {
            get
            {
                return this.childern.Count;
            }
        }

        public void AddChild(Node child)
        {
            this.childern.Add(child);
        }

        public override int GetHashCode()
        {
            return this.NodeId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Node);
        }

        public bool Equals(Node node)
        {
            return this.NodeId.Equals(node.NodeId);
        }
    }

    public class Program
    {
        public static void Main()
        {
            int emploiesNumber = int.Parse(Console.ReadLine());

            Node[] allEmploies = new Node[emploiesNumber];

            for (int i = 0; i < allEmploies.Length; i++)
            {
                allEmploies[i] = new Node(i);
            }

            for (int i = 0; i < emploiesNumber; i++)
            {
                string employ = Console.ReadLine();

                for (int j = 0; j < employ.Length; j++)
                {
                    if (employ[j] == 'Y')
                    {
                        allEmploies[i].AddChild(allEmploies[j]);
                    }
                }
            }

            HashSet<Node> visited = new HashSet<Node>();

            decimal sum = 0;

            for (int i = 0; i < allEmploies.Length; i++)
            {
                if (!visited.Contains(allEmploies[i]))
                {
                    CalcSalaries(allEmploies[i], visited);
                }
            }

            for (int i = 0; i < allEmploies.Length; i++)
            {
                sum += allEmploies[i].Salary;
            }

            Console.WriteLine(sum);
        }

        public static decimal CalcSalaries(Node start, HashSet<Node> visited)
        {
            if (start.Childern == 0)
            {
                start.Salary = 1;
            }
            else
            {
                foreach (var item in start.ChildernList)
                {
                    if (visited.Contains(item))
                    {
                        start.Salary += item.Salary;
                    }
                    else
                    {
                        start.Salary += CalcSalaries(item, visited);
                    }
                }
            }

            visited.Add(start);

            return start.Salary;
        }
    }
}
