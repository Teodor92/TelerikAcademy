using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Student[] myClass = new Student[3];

        Student firstStudent = new Student();
        firstStudent.firstName = "Ivan";
        firstStudent.secondName = "Zabunov";
        firstStudent.age = 19;
        myClass[0] = firstStudent;

        Student secondStudent = new Student();
        secondStudent.firstName = "Teodor";
        secondStudent.secondName = "Andonov";
        secondStudent.age = 25;
        myClass[1] = secondStudent;

        Student thirdStudent = new Student();
        thirdStudent.firstName = "Pesho";
        thirdStudent.secondName = "Olov";
        thirdStudent.age = 18;
        myClass[2] = thirdStudent;

        var sortedClass =
            from student in myClass
            where student.age >= 18 && student.age <= 24
            select student;

        foreach (var student in sortedClass)
        {
            Console.WriteLine("{0} {1} {2}", student.firstName, student.secondName, student.age);
        }
    }
}
