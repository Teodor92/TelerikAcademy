using System;
using System.Collections.Generic;

public class Human : ICommentable
{
    private string name;
    
    public Human(string name)
    {
        this.name = name;
        this.Comments = new List<string>();
    }

    public List<string> Comments { get; set; }

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Name is too short!");
            }

            this.name = value;
        }
    }

    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }
}