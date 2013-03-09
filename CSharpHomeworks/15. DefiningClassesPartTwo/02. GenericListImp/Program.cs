using System;

public class Program
{
    public static void Main()
    {
        GenericList<int> listTesting = new GenericList<int>(1);
        listTesting.AddElement(2);
        listTesting.AddElement(3);
        listTesting.AddElement(4);
        listTesting.AddElement(5);
        listTesting.AddElement(6);
        listTesting.AddElement(-1000);

        Console.WriteLine(listTesting);

        listTesting.RemoveElemAtIndex(4);

        Console.WriteLine(listTesting);

        listTesting.InsertElemAtIndex(0, 123);

        Console.WriteLine(listTesting);

        Console.WriteLine(listTesting.FindElemByValue(123));

        Console.WriteLine(listTesting.Max());
        Console.WriteLine(listTesting.Min());

        listTesting.ClearList();

        Console.WriteLine(listTesting);
    }
}
