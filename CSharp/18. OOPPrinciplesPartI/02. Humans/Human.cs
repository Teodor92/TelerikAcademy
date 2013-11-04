using System;

public abstract class Human
{
    private string firstName;
    private string secondName;

    public Human(string firstName, string secondName)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Ivalid Name");
            }

            this.firstName = value;
        }
    }

    public string SecondName
    {
        get
        {
            return this.secondName;
        }

        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Ivalid Name");
            }

            this.secondName = value;
        }
    }
}
