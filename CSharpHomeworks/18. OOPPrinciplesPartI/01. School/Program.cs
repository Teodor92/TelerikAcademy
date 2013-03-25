using System;

public class Program
{
    public static void Main()
    {
        SchoolClass firstClass = new SchoolClass();

        Teacher firstTeacher = new Teacher("Ivan");
        firstClass.AddTeacher(firstTeacher);

        Teacher secondTeacher = new Teacher("Stoian");
        firstClass.AddTeacher(secondTeacher);

        Teacher thirdTeacher = new Teacher("Dragan");
        firstClass.AddTeacher(thirdTeacher);
        thirdTeacher.AddComment("Test wtf!");

        Console.WriteLine(thirdTeacher.Comments[0]);

        foreach (var teacher in firstClass.SetOfTeachers)
        {
            teacher.Name = "test";
        }
    }
}
