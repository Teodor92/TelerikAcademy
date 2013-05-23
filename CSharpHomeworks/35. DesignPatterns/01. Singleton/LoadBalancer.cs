namespace Singleton.Example
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    public class LoadBalancer
    {
        private static LoadBalancer instance;
        private readonly List<string> servers = new List<string>();
        private readonly Random random = new Random();

        // Lock synchronization object
        private static readonly object SyncLock = new object();

        // Constructor (protected)
        protected LoadBalancer()
        {
            // List of available servers
            this.servers.Add("ServerI");
            this.servers.Add("ServerII");
            this.servers.Add("ServerIII");
            this.servers.Add("ServerIV");
            this.servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (instance == null)
            {
                lock (SyncLock)
                {
                    if (instance == null)
                    {
                        instance = new LoadBalancer();
                    }
                }
            }

            return instance;
        }

        // Simple, but effective random load balancer
        public string Server
        {
            get
            {
                int randomInt = this.random.Next(this.servers.Count);
                return this.servers[randomInt].ToString();
            }
        }
    }
}