namespace SimpleHumanCreator
{
    using System;

    public static class HumanCreatorTest
    {
        public static void Main()
        {
            HumanCreator myTestCreator = new HumanCreator();

            Human myTestHuman = myTestCreator.CreateHuman(2);

            Console.WriteLine(myTestHuman);
        }
    }
}
