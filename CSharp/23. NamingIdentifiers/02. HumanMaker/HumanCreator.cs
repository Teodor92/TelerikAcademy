namespace SimpleHumanCreator
{
    using System;

    public class HumanCreator
    {
        public Human CreateHuman(int magicNumber)
        {
            Human newHuman = new Human();
            newHuman.Age = magicNumber;

            if (magicNumber % 2 == 0)
            {
                newHuman.Name = "Батката";
                newHuman.Gender = Gender.Male;
            }
            else
            {
                newHuman.Name = "Мацето";
                newHuman.Gender = Gender.Female;
            }

            return newHuman;
        }
    }
}