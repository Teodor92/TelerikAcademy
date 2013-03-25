using System;
using System.Linq;

public class ClassSorter
{
    private Student[] presortedCalss;

    public ClassSorter(Student[] myClass)
    {
        this.PrefilteredCalss = myClass;
    }

    public Student[] PrefilteredCalss
    {
        set
        {
            this.presortedCalss = value;
        }
    }

    public void ShowSortedClass()
    {
        var sortedClass = this.presortedCalss.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.SecondName);

        foreach (var student in sortedClass)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.SecondName);
        }
    }
}