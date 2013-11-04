using System;
using System.Collections.Generic;

public class Teacher : Human, ICommentable
{
    public readonly List<Discipline> SetOfDisciplines;

    public Teacher(string name) : base(name)
    {
        this.SetOfDisciplines = new List<Discipline>();
    }

    public void AddDiscipline(Discipline discipline)
    {
        this.SetOfDisciplines.Add(discipline);
    }
}