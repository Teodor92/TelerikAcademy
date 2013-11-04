using System;
using System.Collections.Generic;

public class School
{
    public readonly List<SchoolClass> Classes;

    public School()
    {
        this.Classes = new List<SchoolClass>();
    }

    public void AddClass(SchoolClass myClass)
    {
        this.Classes.Add(myClass);
    }
}
