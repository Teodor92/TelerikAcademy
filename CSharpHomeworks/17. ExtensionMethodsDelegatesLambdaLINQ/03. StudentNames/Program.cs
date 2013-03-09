using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Student[] myClass = 
        {
               new Student("Ivan", "Mihailov"),  
               new Student("Ivan", "Ivanov"),
               new Student("Ivan", "Dimitrov"),
               new Student("Ivan", "Stoianov")
        };

        var sortedClass =
            from student in myClass
            where student.FirstName.CompareTo(student.SecondName) == -1
            select student;

        foreach (var student in sortedClass)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.SecondName);
        }
    }
}
