using System;

public class Program
{
    public static void Main()
    {
        Student testStudentOne = new Student("Ivan", "Ivan", "Ivan", "854894");

        Console.WriteLine(testStudentOne);

        Student testStudentTwo = new Student("Ivan", "Ivan", "Ivan", "854894");

        Student testStudentThree = new Student("Ivan", "Ivan", "Dragan", "123123");

        Console.WriteLine(testStudentOne == testStudentTwo);
        Console.WriteLine(testStudentOne.Equals(testStudentTwo));

        Console.WriteLine(testStudentOne != testStudentThree);
        Console.WriteLine(testStudentOne.Equals(testStudentThree));

        var clone = testStudentOne.Clone();
        Console.WriteLine(clone);

        Console.WriteLine(testStudentOne.CompareTo(testStudentThree));
    }
}