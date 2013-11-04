using System;

class ShipDamage
{
    static void Main()
    {
        // input
        int shipX1, shipX2, shipY1, shipY2, Horizont;
        int cannonX1, cannonY1, cannonX2, cannonY2, cannonX3, cannonY3, points;
        shipX1 = int.Parse(Console.ReadLine());
        shipY1 = int.Parse(Console.ReadLine());
        shipX2 = int.Parse(Console.ReadLine());
        shipY2 = int.Parse(Console.ReadLine());
        Horizont = int.Parse(Console.ReadLine());
        cannonX1 = int.Parse(Console.ReadLine());
        cannonY1 = int.Parse(Console.ReadLine());
        cannonX2 = int.Parse(Console.ReadLine());
        cannonY2 = int.Parse(Console.ReadLine());
        cannonX3 = int.Parse(Console.ReadLine());
        cannonY3 = int.Parse(Console.ReadLine());
        points = 0;
        //finding the hit points
        cannonY1 = Horizont * 2 - cannonY1;
        cannonY2 = Horizont * 2 - cannonY2;
        cannonY3 = Horizont * 2 - cannonY3;
        //finding coords
        int minX = Math.Min(shipX1, shipX2);
        int maxX = Math.Max(shipX1, shipX2);
        int minY = Math.Min(shipY1, shipY2);
        int maxY = Math.Max(shipY1, shipY2);
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
        Console.WriteLine("{0}%",points);
    }
}
