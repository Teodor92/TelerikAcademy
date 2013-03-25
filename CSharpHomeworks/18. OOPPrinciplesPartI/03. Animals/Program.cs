using System;
using MyAnimal;

public class Program
{
    public static void Main()
    {
        Dog lol = new Dog("Ivan", 12, Sex.Male);
        lol.MakeSound();

        Kitten test = new Kitten("Ivanka", 12, Sex.Female);

        Animal[] myZoo = 
        {
            new Cat("Ivanka", 12, Sex.Female),
            new Kitten("Ivanka", 12, Sex.Female),
            new Frog("Ivanka", 20, Sex.Female),
            new Frog("Ivanka", 10, Sex.Female),
            new Dog("Ivanka", 12, Sex.Female),
            new Cat("Ivanka", 12, Sex.Female),
            new Kitten("Ivanka", 12, Sex.Female),
            new Frog("Ivanka", 20, Sex.Female),
            new Frog("Ivanka", 10, Sex.Female),
            new Dog("Ivanka", 12, Sex.Female),
            new Cat("Ivanka", 12, Sex.Female),
            new Kitten("Ivanka", 12, Sex.Female),
            new Frog("Ivanka", 20, Sex.Female),
            new Frog("Ivanka", 10, Sex.Female),
            new Dog("Ivanka", 12, Sex.Female),
            new Cat("Ivanka", 12, Sex.Female),
            new Kitten("Ivanka", 12, Sex.Female),
            new Frog("Ivanka", 20, Sex.Female),
            new Frog("Ivanka", 10, Sex.Female),
            new Dog("Ivanka", 12, Sex.Female),
        };

        Animal.AgeAverage(myZoo);
    }
}
