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
        myClass[0] = firstStudent;

        Student secondStudent = new Student();
        secondStudent.firstName = "Teodor";
        secondStudent.secondName = "Andonov";
        myClass[1] = secondStudent;

        Student thirdStudent = new Student();
        thirdStudent.firstName = "Pesho";
        thirdStudent.secondName = "Olov";
        myClass[2] = thirdStudent;

        var sortedClass =
            from student in myClass
            orderby student.firstName orderby student.secondName
            select student;

        foreach (var student in sortedClass)
        {
            Console.WriteLine("{0} {1}", student.firstName, student.secondName);
        }
    }
}
