using System;

class Flask
{
    public int amountOfDrink { get; set; }
    public int typeOfDrink { get; set; }
}

class AirplaneDrinks
{
    static void Main()
    {
        Flask newFlask = new Flask();
        int numberOfPassengers = int.Parse(Console.ReadLine());
        int[] passengers = new int[numberOfPassengers - 1];

        int numberOfCoffie = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCoffie; i++)
        {
            int coffie = int.Parse(Console.ReadLine());
            passengers[coffie - 1] = 1;
        }

        int totalTime = 0;
        if (passengers[0] == 1)
        {
            newFlask.typeOfDrink = 1;
            newFlask.amountOfDrink = 7;
            totalTime += 47;
        }
        else
        {
            newFlask.typeOfDrink = 0;
            newFlask.amountOfDrink = 7;
            totalTime += 47;
        }

        for (int tea = 0; tea < 2; tea++)
        {
            for (int i = 0; i < passengers.Length; i++)
            {
                if (newFlask.amountOfDrink == 0)
                {
                    totalTime += (i + 1) * 2;
                    totalTime += 47;
                }

                totalTime++;

                if (newFlask.typeOfDrink == passengers[i])
                {
                    totalTime += 4;
                    newFlask.amountOfDrink--;
                }
            }
        }
        //for (int i = 0; i < passengers.Length; i++)
        //{
        //    if (newFlask.amountOfDrink == 0)
        //    {
        //        totalTime += (i + 1) * 2;
        //        totalTime += 47;
        //    }
        //    totalTime++;
        //    if (passengers[i] == newFlask.typeOfDrink)
        //    {
        //        newFlask.amountOfDrink--;
        //        totalTime += 4;
        //    }
        //    else
        //    {
        //        totalTime += (i + 1) * 2;
        //        totalTime += 47;
        //        newFlask.typeOfDrink = passengers[i];
        //        newFlask.amountOfDrink = 7;
        //        totalTime += 4;
        //        newFlask.amountOfDrink--;
        //    }
        //}

        Console.WriteLine(totalTime);
    }
}
