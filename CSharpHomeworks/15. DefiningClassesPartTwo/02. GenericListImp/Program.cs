using System;

class Program
{
    static void Main()
    {
        GenericList<int> listTesting = new GenericList<int>(1);
        listTesting.AddElement(2);
        listTesting.AddElement(3);
        listTesting.AddElement(4);
        listTesting.AddElement(5);
        listTesting.AddElement(6);

        Console.WriteLine(listTesting);

        listTesting.RemoveElemAtIndex(4);

        Console.WriteLine(listTesting);

        listTesting.InsertElemAtIndex(0, 123);

        Console.WriteLine(listTesting);

        Console.WriteLine(listTesting.FindElemByValue(123));

        listTesting.ClearList();

        Console.WriteLine(listTesting);
    }


}
