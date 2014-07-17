namespace _01.FighterAttack
{
    using System;

    public class FighterAttack
    {
        internal static void Main()
        {
            // input
            var plantX1 = int.Parse(Console.ReadLine());
            var plantY1 = int.Parse(Console.ReadLine());
            var plantX2 = int.Parse(Console.ReadLine());
            var plantY2 = int.Parse(Console.ReadLine());
            var fighterX = int.Parse(Console.ReadLine());
            var fighterY = int.Parse(Console.ReadLine());
            var distance = int.Parse(Console.ReadLine());

            // helpers
            var dmgSum = 0;
            var bombTarget = fighterX + distance;

            // Finding coords
            var plantMinX = Math.Min(plantX1, plantX2);
            var plantMaxX = Math.Max(plantX1, plantX2);
            var plantMinY = Math.Min(plantY1, plantY2);
            var plantMaxY = Math.Max(plantY1, plantY2);

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
}
