namespace Singleton.Example
{
    using System;

    /// <summary>
    /// MainApp startup class
    /// Singleton Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            LoadBalancer balancer1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer balancer2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer balancer3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer balancer4 = LoadBalancer.GetLoadBalancer();

            // Same instance?
            if (balancer1 == balancer2 && balancer2 == balancer3 && balancer3 == balancer4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }
        }
    }
}
