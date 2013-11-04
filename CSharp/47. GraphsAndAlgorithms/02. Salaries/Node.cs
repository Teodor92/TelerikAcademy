namespace Salaries
{
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
}