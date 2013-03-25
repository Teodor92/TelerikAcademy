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

        ClassSorter mySorter = new ClassSorter(myClass);
        mySorter.ShowSortedClass();
    }
}