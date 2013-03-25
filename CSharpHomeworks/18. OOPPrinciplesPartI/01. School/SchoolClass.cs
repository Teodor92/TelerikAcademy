using System;
using System.Collections.Generic;

public class SchoolClass : ICommentable
{
    public readonly List<Teacher> SetOfTeachers;

    private string uniqeTextIndet;

    public SchoolClass()
    {
        this.SetOfTeachers = new List<Teacher>();
        this.Comments = new List<string>();
    }

    public List<string> Comments { get; set; }

    public string UniqeTextIndet
    {
        get
        {
            return this.uniqeTextIndet;
        }

        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Ivalid format!");
            }

            this.uniqeTextIndet = value;
        }
    }

    public void AddTeacher(Teacher teacher)
    {
        this.SetOfTeachers.Add(teacher);
    }

    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }
}
