using System;
using System.Collections.Generic;

public class Discipline : ICommentable
{
    private string name;
    private int numberOfLectures; 
    private int numberOfExercises;

    public Discipline()
        : this(null, 0, 0)
    {
    }

    public Discipline(string name) : this(name, 0, 0)
    {       
    }

    public Discipline(string name, int numberOfLectures, int numberOfExercises)
    {
        this.name = name;
        this.numberOfLectures = numberOfLectures;
        this.numberOfExercises = numberOfExercises;
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
                throw new ArgumentException("Ivalid input");
            }

            this.name = value;
        }
    }

    public int NumberOfLectures
    {
        get
        {
            return this.numberOfLectures;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Ivalid input");
            }

            this.numberOfLectures = value;
        }
    }

    public int NumberOfExercises
    {
        get
        {
            return this.numberOfExercises;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Ivalid input");
            }

            this.numberOfExercises = value;
        }
    }

    public void AddComment(string comment)
    {
        this.Comments.Add(comment);
    }
}