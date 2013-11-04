using System;
using System.Linq;

public class ClassNameFilter
{
    private Student[] prefilteredCalss;

    public ClassNameFilter(Student[] myClass)
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
        var filteredClass =
            from student in this.prefilteredCalss
            where student.FirstName.CompareTo(student.SecondName) == -1
            select student;

        foreach (var student in filteredClass)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.SecondName);
        }
    }
}