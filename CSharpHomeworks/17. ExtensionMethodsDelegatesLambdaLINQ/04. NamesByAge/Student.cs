using System;

public class Student
{
    public Student(string firstName, string secondName, int age)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.Age = age;
    }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public int Age { get; set; }
}
