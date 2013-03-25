using System;
using MyAnimal;

public class Cat : Animal, ISound
{
    public Cat(string name, int age)
        : base(name, age)
    {
    }

    public Cat(string name, int age, Sex sex)
        : base(name, age, sex)
    {
    }

    public void MakeSound()
    {
        Console.WriteLine("Mau, Mau!");
    }
}