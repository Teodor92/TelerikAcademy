using System;

class FighterAttack
{
    static void Main()
    {
        // input
        int plantX1, plantY1, plantX2, plantY2, fighterX, fighterY, distance;
        plantX1 = int.Parse(Console.ReadLine());
        plantY1 = int.Parse(Console.ReadLine());
        plantX2 = int.Parse(Console.ReadLine());
        plantY2 = int.Parse(Console.ReadLine());
        fighterX = int.Parse(Console.ReadLine());
        fighterY = int.Parse(Console.ReadLine());
        distance = int.Parse(Console.ReadLine());
        // helpers
        int dmgSum = 0;
        int bombTarget = fighterX + distance;
        //Finding coords
        int plantMinX = Math.Min(plantX1, plantX2);
        int plantMaxX = Math.Max(plantX1, plantX2);
        int plantMinY = Math.Min(plantY1, plantY2);
        int plantMaxY = Math.Max(plantY1, plantY2);
        // main logic
        if ((bombTarget >= plantMinX && bombTarget <= plantMaxX) && (fighterY >= plantMinY && fighterY <= plantMaxY))
        {
            dmgSum = dmgSum + 100;
        }
        if ((bombTarget >= plantMinX && bombTarget <= plantMaxX) && (fighterY - 1 >= plantMinY && fighterY - 1 <= plantMaxY))
        {
            dmgSum = dmgSum + 50;
        }
        if ((bombTarget >= plantMinX && bombTarget <= plantMaxX) && (fighterY + 1 >= plantMinY && fighterY + 1 <= plantMaxY))
        {
            dmgSum = dmgSum + 50;
        }
        if ((bombTarget + 1 >= plantMinX && bombTarget + 1 <= plantMaxX) && (fighterY >= plantMinY && fighterY <= plantMaxY))
        {
            dmgSum = dmgSum + 75;
        }
        // printing
        Console.WriteLine("{0}%",dmgSum);


    }
}
