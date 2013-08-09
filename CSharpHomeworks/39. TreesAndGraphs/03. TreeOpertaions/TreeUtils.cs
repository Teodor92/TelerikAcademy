namespace TreeOpertaions
{
    using System;
    using System.Collections.Generic;

    public class TreeUtils
    {
        private static int maxPath = int.MinValue;
        private static string bestPath = string.Empty;

        public static string BestPath
        {
            get
            {
                return bestPath;
            }
        }

        public static int MaxPath
        {
            get
            {
                return maxPath;
            }
        }

        public static void FindSubtreeSum(Node root, int S)
        {
            foreach (var node in root.Children)
            {
                Queue<int> subtreeQueue = new Queue<int>();
                subtreeQueue.Enqueue(node.Value);
                FindSubtreeSum(node, S);

                foreach (var child in node.Children)
                {
                    subtreeQueue.Enqueue(child.Value);
                }

                int sum = 0;
                foreach (var item in subtreeQueue)
                {
                    sum += item;
                }

                if (sum == S)
                {
                    foreach (var item in subtreeQueue)
                    {
                        Console.Write("{0} ", item);
                    }

                    Console.WriteLine();
                }
            }
        }

        public static void PrintTree(Node node)
        {
            foreach (var item in node.Children)
            {
                Console.Write("{0} ", item.Value);
                PrintTree(item);
            }
        }

        public static void PathsWithSumS(Node root, List<List<Node>> listOfPaths, List<Node> pathSoFar, int currentSum, int targetSum)
        {
            if (currentSum == targetSum && CheckCurrentSum(pathSoFar, targetSum))
            {
                Node[] nodePath = new Node[pathSoFar.Count];
                pathSoFar.CopyTo(nodePath);
                listOfPaths.Add(new List<Node>(nodePath));
                pathSoFar.RemoveRange(1, pathSoFar.Count - 1);
            }

            foreach (var item in root.Children)
            {
                pathSoFar.Add(item);
                PathsWithSumS(item, listOfPaths, pathSoFar, currentSum + item.Value, targetSum);
                if (pathSoFar.Count > 1)
                {
                    pathSoFar.RemoveAt(pathSoFar.Count - 1);
                }
            }

        }

        private static bool CheckCurrentSum(List<Node> path, int targetSum)
        {
            int sum = 0;
            foreach (var item in path)
            {
                sum += item.Value;
            }

            return sum == targetSum ? true : false;
        }

        public static void BuildTree(IDictionary<int, Node> myTree)
        {
            int allPairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < allPairs - 1; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int firstValue = int.Parse(input[0]);
                int secondValue = int.Parse(input[1]);

                if (myTree.ContainsKey(firstValue))
                {
                    Node node = myTree[firstValue];
                    Node secondNode;

                    if (myTree.ContainsKey(secondValue))
                    {
                        secondNode = myTree[secondValue];
                        secondNode.HasParent = true;
                    }
                    else
                    {
                        secondNode = new Node(secondValue);
                        myTree.Add(secondValue, secondNode);
                    }

                    node.AddChild(secondNode);
                }
                else
                {
                    Node secondNode;
                    if (myTree.ContainsKey(secondValue))
                    {
                        secondNode = myTree[secondValue];
                        secondNode.HasParent = true;
                    }
                    else
                    {
                        secondNode = new Node(secondValue);
                        myTree.Add(secondValue, secondNode);
                    }

                    Node firstNode = new Node(firstValue, secondNode);
                    myTree.Add(firstValue, firstNode);
                }
            }
        }

        public static void FindLongestPath(Node root, int steps, string currentPath)
        {
            currentPath += string.Format(" {0}", root.Value);

            if (steps > maxPath)
            {
                maxPath = steps;
                bestPath = currentPath;
            }

            steps++;

            foreach (var node in root.Children)
            {
                FindLongestPath(node, steps, currentPath);
            }
        }

        public static List<Node> FindLeafs(Node root)
        {
            List<Node> leafs = new List<Node>();
            List<Node> children = root.Children;

            if (children.Count == 0)
            {
                leafs.Add(root);
            }

            foreach (var child in children)
            {
                leafs.AddRange(FindLeafs(child));
            }

            return leafs;
        }

        public static List<Node> FindMiddleNodes(Node root)
        {
            List<Node> middleNodes = new List<Node>();
            List<Node> children = root.Children;

            if (children.Count > 0 && root.HasParent == true)
            {
                middleNodes.Add(root);
            }

            foreach (var child in children)
            {
                middleNodes.AddRange(FindMiddleNodes(child));
            }

            return middleNodes;
        }

        public static Node FindRoot(IDictionary<int, Node> myTree)
        {
            foreach (var item in myTree)
            {
                if (!item.Value.HasParent)
                {
                    return item.Value;
                }
            }

            throw new InvalidOperationException("Tree has no root.");
        }
    }
}
