using System;
using MyAnimal;

public class Dog : Animal, ISound
{
    public Dog(string name, int age, Sex sex)
        : base(name, age, sex)
    {
    }

    public void MakeSound()
    {
        Console.WriteLine("Bau, Bau");
    }
}
