using System;
using System.Linq;

class Program
{
    static void Main()
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
            orderby student.FirstName descending, student.SecondName descending
            select student;

        foreach (var student in sortedClass)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.SecondName);
        }
    }
}
