using System;
using System.Linq;

public class AgeFilter
{
    private Student[] prefilteredCalss;

    public AgeFilter(Student[] myClass)
    {
        this.PrefilteredCalss = myClass;
    }

    public Student[] PrefilteredCalss
    {
        set
        {
            this.prefilteredCalss = value;
        }
    }

    public void ShowFilterdClass()
    {
        var wantedStudents =
            from student in this.prefilteredCalss
            where student.Age >= 18 && student.Age <= 24
            select student;

        foreach (var student in wantedStudents)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.SecondName, student.Age);
        }
    }
}