using System;
using System.Text;

public class Person
{
    private string name;
    private int? age;

    public Person(string name) : this(name, null)
    {
    }

    public Person(string name, int? age)
    {
        this.name = name;
        this.age = age;
    }

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

    public int? Age
    {
        get
        {
            return this.age;
        }

        set
        {
            this.age = value;
        }
    }

    public override string ToString()
    {
        StringBuilder endText = new StringBuilder();

        endText.AppendFormat("Name: {0} \n", this.Name);
        endText.AppendFormat("Age: {0} \n", this.Age == null ? "Not specified!" : this.Age.ToString());

        return endText.ToString();
    }
}