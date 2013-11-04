/* Write an expression that calculates trapezoid's 
 * area by given sides a and b and height h.
 */

using System;

class TrapezoidArea
{
    static void Main()
    {
        int sideA = 5;
        int sideB = 3;
        int height = 10;
        int area = ((sideA + sideB) * height) / 2;
        Console.WriteLine("The area of the trapezoid is: {0}", area);
    }
}
