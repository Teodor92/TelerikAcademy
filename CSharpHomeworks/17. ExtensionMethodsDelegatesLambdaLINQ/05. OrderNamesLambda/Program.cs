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

        var sortedClass = myClass.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.SecondName);

        foreach (var student in sortedClass)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.SecondName);
        }
    }
}
