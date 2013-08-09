namespace FriendsInNeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void DijkstraAlgorithm(Node source, Dictionary<Node, List<Connection>> graph)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                if (source.PointID != node.Key.PointID)
                {
                    node.Key.DijktraDistance = int.MaxValue;
                    queue.Enqueue(node.Key); 
                }
            }

            source.DijktraDistance = 0;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Peek();

                if (currentNode.DijktraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    int potDistance = currentNode.DijktraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijktraDistance)
                    {
                        neighbour.Node.DijktraDistance = potDistance;
                        Node next = new Node(neighbour.Node.PointID, potDistance);
                        queue.Enqueue(next);
                    }
                }

                queue.Dequeue();
            }
        }

        public static void Main()
        {
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();

            string[] initialParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfNodes = int.Parse(initialParams[0]);
            int numberOfStreets = int.Parse(initialParams[1]);
            int numberOfHospitals = int.Parse(initialParams[2]);

            string[] hostitalParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] hospitalNumbers = new int[hostitalParams.Length];

            for (int i = 0; i < hostitalParams.Length; i++)
            {
                hospitalNumbers[i] = int.Parse(hostitalParams[i]);
            }

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();
            List<int[]> allParams = new List<int[]>();

            for (int i = 0; i < numberOfStreets; i++)
            {
                string[] currentParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] currentNumbers = new int[currentParams.Length];

                for (int j = 0; j < currentParams.Length; j++)
                {
                    currentNumbers[j] = int.Parse(currentParams[j]);
                }

                allParams.Add(currentNumbers);

                if (!nodes.ContainsKey(currentNumbers[0]))
                {
                    nodes.Add(currentNumbers[0], new Node(currentNumbers[0], int.MaxValue));
                }

                if (!nodes.ContainsKey(currentNumbers[1]))
                {
                    nodes.Add(currentNumbers[1], new Node(currentNumbers[1], int.MaxValue));
                }
            }

            for (int i = 0; i < allParams.Count; i++)
            {
                int[] currentParams = allParams[i];

                if (graph.ContainsKey(nodes[currentParams[0]]))
                {
                    graph[nodes[currentParams[0]]].Add(new Connection(nodes[currentParams[1]], currentParams[2]));
                }
                else
                {
                    graph.Add(nodes[currentParams[0]], new List<Connection>() 
                    { 
                        new Connection(nodes[currentParams[1]], currentParams[2]) 
                    });
                }

                if (graph.ContainsKey(nodes[currentParams[1]]))
                {
                    graph[nodes[currentParams[1]]].Add(new Connection(nodes[currentParams[0]], currentParams[2]));
                }
                else
                {
                    graph.Add(nodes[currentParams[1]], new List<Connection>() 
                    { 
                        new Connection(nodes[currentParams[0]], currentParams[2]) 
                    });
                }
            }

            double bestSum = double.MaxValue;

            for (int i = 0; i < hospitalNumbers.Length; i++)
            {
                DijkstraAlgorithm(nodes[hospitalNumbers[i]], graph);

                double sum = 0;

                foreach (var item in graph)
                {
                    if (!hospitalNumbers.Contains(item.Key.PointID))
                    {
                        sum += item.Key.DijktraDistance;
                    }
                }

                if (sum < bestSum)
                {
                    bestSum = sum;
                }
            }

            Console.WriteLine(bestSum);
        }
    }
}
