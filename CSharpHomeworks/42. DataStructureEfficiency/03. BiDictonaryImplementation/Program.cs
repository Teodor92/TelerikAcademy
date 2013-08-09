namespace BiDictonaryImplementation
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            BiDictionary<string, string, string> myDictonary = new BiDictionary<string, string, string>(true);

            myDictonary.AddByBothKeys("Ivan", "Ivanov", "Stude2222nt");
            myDictonary.AddByBothKeys("Ivan", "Ivanov", "Studasdent");
            myDictonary.AddByFirstKey("Ivan", "Student");
            myDictonary.AddByFirstKey("Ivan", "Student");
            myDictonary.AddByFirstKey("Ivan", "Student");
            myDictonary.AddByFirstKey("Ivan", "Student");

            var test = myDictonary.FindByFirstKey("Ivan");
            var test2 = myDictonary.FindByFirstAndSecondKey("Ivan", "Ivanov");
            foreach (var item in test2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(myDictonary.Count);
        }
    }
}
