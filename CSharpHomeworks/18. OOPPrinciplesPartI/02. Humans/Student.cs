using System;

public class Student : Human
{
    private int grade;

    public Student(string firstName, string secondName, int grade) : base(firstName, secondName)
    {
        this.Grade = grade;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        set
        {
            this.grade = value;
        }
    }
}