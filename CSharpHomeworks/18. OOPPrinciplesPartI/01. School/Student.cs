using System;
using System.Collections.Generic;

public class Student : Human, ICommentable
{
    private string uniqeClassNumber;

    public Student(string name, string uniqeClassNumber) : base(name)
    {
        this.uniqeClassNumber = uniqeClassNumber;
    }

    public string UniqeClassNumber
    {
        get
        {
            return this.uniqeClassNumber;
        }

        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Invalid text number!");
            }

            this.uniqeClassNumber = value;
        }
    }
}