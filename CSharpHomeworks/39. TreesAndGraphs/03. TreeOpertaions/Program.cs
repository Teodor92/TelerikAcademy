namespace TreeOpertaions
{
    /*
     * You are given a tree of N nodes 
     * represented as a set of N-1 pairs of nodes 
     * (parent node, child node), each in the range (0..N-1).
     * Write a program to read the tree and find:
     * 1. the root node
     * 2. all leaf nodes
     * 3. all middle nodes
     * 4. the longest path in the tree
     * 5. all paths in the tree with given sum S of their nodes
     * 6. all subtrees with given sum S of their nodes
     */

    /* Sample input: */
    /*
        10
        2 4
        3 2
        5 0
        3 5
        5 6
        5 1
        0 8
        8 9
        6 16
        1 7
        7 10
    */
    /* Sample input tree look:
                
                 3
                 |
           --------------
           |            |
           5            2
           |            |
        --------        4
        |  |   |
        0  1   6
        |  |   |
        8  7   16
        |  |
        9  10
     */

    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            IDictionary<int, Node> myTree = new Dictionary<int, Node>();

            TreeUtils.BuildTree(myTree);

            // 1. Finding the root.
            Node root = TreeUtils.FindRoot(myTree);
            Console.WriteLine("Whole tree");
            TreeUtils.PrintTree(root);
            Console.WriteLine();

            // 2. Finding the leaves.
            Console.WriteLine("Tree leaves:");
            List<Node> leafs = TreeUtils.FindLeafs(root);

            foreach (var item in leafs)
            {
                Console.WriteLine(item.Value);
            }

            // 3. Finding the middle nodes.
            Console.WriteLine("Middle nodes:");
            List<Node> middleNodes = TreeUtils.FindMiddleNodes(root);

            foreach (var item in middleNodes)
            {
                Console.WriteLine(item.Value);
            }

            // 4. Finding the longest path.
            Console.WriteLine("Longest path length:");
            TreeUtils.FindLongestPath(root, 1, string.Empty);
            Console.WriteLine(TreeUtils.MaxPath);

            Console.WriteLine("The path:");
            Console.WriteLine(TreeUtils.BestPath);

            // 5. Finding all paths with sum S
            int s = 9;
            List<List<Node>> listOfPaths = new List<List<Node>>();
            TreeUtils.PathsWithSumS(root, listOfPaths, new List<Node>(new Node[] { root }), root.Value, s);
            Console.WriteLine("Paths with sum of {0}:", s);
            foreach (var foundPath in listOfPaths)
            {
                foreach (var node in foundPath)
                {
                    Console.Write("{0} ", node.Value);
                }
                Console.WriteLine();
            }

            // 6. Finding all the subtrees by given sum.
            int sum = 6;
            Console.WriteLine("List of subtrees with sum {0}:", sum);
            TreeUtils.FindSubtreeSum(root, sum);
        }
    }
}
