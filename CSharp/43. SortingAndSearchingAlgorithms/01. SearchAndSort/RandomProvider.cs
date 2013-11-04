namespace SortingHomework
{
    using System;

    public class RandomProvider
    {
        private static readonly Random instance = new Random();

        public static Random Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
