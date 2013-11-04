namespace TreeOpertaions
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        private int value;
        private List<Node> children;
        private bool hasParent;

        public Node(int value)
        {
            this.Value = value;
            this.hasParent = true;
            this.children = new List<Node>();
        }

        public Node(int value, Node child)
            : this(value)
        {
            this.AddChild(child);
            this.hasParent = false;
        }

        public List<Node> Children
        {
            get
            {
                return this.children;
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }

            set
            {
                this.hasParent = value;
            }
        }

        public void AddChild(Node child)
        {
            this.children.Add(child);
        }
    }
}
