using System;
using MyAnimal;

public class Kitten : Cat, ISound
{
    public Kitten(string name, int age, Sex sex)
        : base(name, age)
    {
        if (sex == MyAnimal.Sex.Male)
        {
            throw new ArgumentException("Wrong sex !");
        }

        this.Sex = sex;
    }
}