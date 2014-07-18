namespace _05.AirplaneDrinks
{
    using System;

    public class AirplaneDrinks
    {
        internal static void Main()
        {
            var newFlask = new Flask();
            var numberOfPassengers = int.Parse(Console.ReadLine());
            var passengers = new int[numberOfPassengers - 1];
            var numberOfCoffie = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCoffie; i++)
            {
                int coffie = int.Parse(Console.ReadLine());
                passengers[coffie - 1] = 1;
            }

            int totalTime = 0;
            if (passengers[0] == 1)
            {
                newFlask.TypeOfDrink = 1;
                newFlask.AmountOfDrink = 7;
                totalTime += 47;
            }
            else
            {
                newFlask.TypeOfDrink = 0;
                newFlask.AmountOfDrink = 7;
                totalTime += 47;
            }

            for (int tea = 0; tea < 2; tea++)
            {
                for (int i = 0; i < passengers.Length; i++)
                {
                    if (newFlask.AmountOfDrink == 0)
                    {
                        totalTime += (i + 1) * 2;
                        totalTime += 47;
                    }

                    totalTime++;

                    if (newFlask.TypeOfDrink == passengers[i])
                    {
                        totalTime += 4;
                        newFlask.AmountOfDrink--;
                    }
                }
            }

            Console.WriteLine(totalTime);
        }
    }
}