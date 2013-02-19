/* Define several constructors for the 
 * defined classes that take different 
 * sets of arguments (the full information for the class or part of it). 
 * Assume that model and manufacturer are mandatory (the others are optional). 
 * All unknown data fill with null.
 */

using System;
using System.Linq;


public class Program
{
    static void Main()
    {
        Display testDisplay = new Display(12, 13);
        Battery testBattery = new Battery(BatteryType.Type1);
        GSM myPhone = new GSM("test", "test", 12, "Bai Ivan", testBattery, testDisplay);
        Console.WriteLine(myPhone.Display.Size);
    }
}
