using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Student[] myStudents = 
        {
            new Student("Ivan", "Ivanov", 2),
            new Student("Teodor", "Teodorov", 4),
            new Student("Ivan", "Petev", 3),
            new Student("Test", "Testov", 4),
            new Student("Stoian", "Stoian", 5),
            new Student("Kolio", "Kolev", 3),
            new Student("Dragan", "Draganov", 6),
            new Student("Hasan", "Haskov", 4),
            new Student("Hanko", "Brat", 5),
            new Student("Asen", "Ivanov", 6),
        };

        Worker[] myWorkers = 
        {
            new Worker("Ivan", "Ivanov", 500, 8),
            new Worker("Teodor", "Teodorov", 500, 4),
            new Worker("Ivan", "Petev", 600, 6),
            new Worker("Test", "Testov", 700, 8),
            new Worker("Stoian", "Stoian", 400, 8),
            new Worker("Kolio", "Kolev", 900, 8),
            new Worker("Dragan", "Draganov", 100, 2),
            new Worker("Hasan", "Haskov", 350, 6),
            new Worker("Hanko", "Brat", 600, 6),
            new Worker("Asen", "Ivanov", 700, 8),
        };

        var sortedStudents = myStudents.OrderBy(x => x.Grade);

        foreach (var student in sortedStudents)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.SecondName, student.Grade);
        }

        Console.WriteLine("--------------------------------------------");

        var sortedWorkers = myWorkers.OrderByDescending(x => x.MoneyPerHour());

        foreach (var worker in sortedWorkers)
        {
            Console.WriteLine("{0} {1} {2}", worker.FirstName, worker.SecondName, worker.MoneyPerHour());
        }

        List<Human> merged = new List<Human>();

        merged.AddRange(sortedStudents.ToList());
        merged.AddRange(sortedWorkers.ToList());

        foreach (var human in merged)
        {
            Console.WriteLine("{0} {1}", human.FirstName, human.SecondName);
        }

        var sortedFinal = merged.OrderBy(x => x.FirstName).ThenBy(x => x.SecondName);

        foreach (var human in sortedFinal)
        {
            Console.WriteLine("{0} {1}", human.FirstName, human.SecondName);
        }
    }  
}
