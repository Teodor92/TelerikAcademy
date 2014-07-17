namespace _01.Ship_Damage
{
    using System;

    public class ShipDamage
    {
        internal static void Main()
        {
            // input
            var shipX1 = int.Parse(Console.ReadLine());
            var shipY1 = int.Parse(Console.ReadLine());
            var shipX2 = int.Parse(Console.ReadLine());
            var shipY2 = int.Parse(Console.ReadLine());
            var horizont = int.Parse(Console.ReadLine());
            var cannonX1 = int.Parse(Console.ReadLine());
            var cannonY1 = int.Parse(Console.ReadLine());
            var cannonX2 = int.Parse(Console.ReadLine());
            var cannonY2 = int.Parse(Console.ReadLine());
            var cannonX3 = int.Parse(Console.ReadLine());
            var cannonY3 = int.Parse(Console.ReadLine());
            var points = 0;

            // finding the hit points
            cannonY1 = (horizont * 2) - cannonY1;
            cannonY2 = (horizont * 2) - cannonY2;
            cannonY3 = (horizont * 2) - cannonY3;

            // finding coords
            var minX = Math.Min(shipX1, shipX2);
            var maxX = Math.Max(shipX1, shipX2);
            var minY = Math.Min(shipY1, shipY2);
            var maxY = Math.Max(shipY1, shipY2);

            // main logic
            // -- corner check
            // ---- first cannon
            if ((minX == cannonX1 || maxX == cannonX1) && (minY == cannonY1 || maxY == cannonY1))
            {
                points = points + 25;
            }

            // ---- second cannon
            if ((minX == cannonX2 || maxX == cannonX2) && (minY == cannonY2 || maxY == cannonY2))
            {
                points = points + 25;
            }

            // ---- third cannon
            if ((minX == cannonX3 || maxX == cannonX3) && (minY == cannonY3 || maxY == cannonY3))
            {
                points = points + 25;
            }

            // -- side check
            // ---- first cannon
            if (((minX == cannonX1 || maxX == cannonX1) && (minY < cannonY1 && maxY > cannonY1)) ||
                ((minY == cannonY1 || maxY == cannonY1) && (minX < cannonX1 && maxX > cannonX1)))
            {
                points = points + 50;
            }

            // ---- second cannon
            if (((minX == cannonX2 || maxX == cannonX2) && (minY < cannonY2 && maxY > cannonY2)) ||
                ((minY == cannonY2 || maxY == cannonY2) && (minX < cannonX2 && maxX > cannonX2)))
            {
                points = points + 50;
            }

            // ---- third cannon
            if (((minX == cannonX3 || maxX == cannonX3) && (minY < cannonY3 && maxY > cannonY3)) ||
                ((minY == cannonY3 || maxY == cannonY3) && (minX < cannonX3 && maxX > cannonX3)))
            {
                points = points + 50;
            }

            // -- internal check
            // ---- first cannon
            if ((minX < cannonX1) && (maxX > cannonX1) && (minY < cannonY1) && (maxY > cannonY1))
            {
                points = points + 100;
            }

            // ---- second cannon
            if ((minX < cannonX2) && (maxX > cannonX2) && (minY < cannonY2) && (maxY > cannonY2))
            {
                points = points + 100;
            }

            // ---- third cannon
            if ((minX < cannonX3) && (maxX > cannonX3) && (minY < cannonY3) && (maxY > cannonY3))
            {
                points = points + 100;
            }

            // output
            Console.WriteLine("{0}%", points);
        }
    }
}
