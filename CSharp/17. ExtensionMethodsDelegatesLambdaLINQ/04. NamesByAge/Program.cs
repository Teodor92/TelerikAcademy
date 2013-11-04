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

        AgeFilter myFilter = new AgeFilter(myClass);
        myFilter.ShowFilterdClass();
    }
}
