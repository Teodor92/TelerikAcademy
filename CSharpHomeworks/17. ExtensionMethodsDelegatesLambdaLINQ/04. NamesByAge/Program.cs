using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Student[] myClass = 
        {
               new Student("Ivan", "Mihailov", 19),  
               new Student("Ivan", "Ivanov", 25),
               new Student("Ivan", "Dimitrov", 18),
               new Student("Ivan", "Stoianov", 36)
        };

        var sortedClass =
            from student in myClass
            where student.Age >= 18 && student.Age <= 24
            select student;

        foreach (var student in sortedClass)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.SecondName, student.Age);
        }
    }
}
