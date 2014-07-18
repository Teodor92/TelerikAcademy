namespace StoreClasses
{
    using System;
    using System.Linq;

    // generates a uniqe ID
    public static class IDGenerator
    {
        private static int currentID = 100;

        public static int GetID()
        {
            return currentID++;
        }
    }
}
