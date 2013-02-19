/* Define a class that holds information about 
 * a mobile phone device: model, manufacturer, 
 * price, owner, battery characteristics 
 * (model, hours idle and hours talk) and display 
 * characteristics (size and number of colors). 
 * Define 3 separate classes 
 * (class GSM holding instances of the classes Battery and Display).
 */

using System;
using System.Linq;


public class Program
{
    static void Main()
    {
        GSM myPhone = new GSM();

        myPhone.Manufacturer = "Bai Ivan";
        Console.WriteLine(myPhone.Manufacturer);
        myPhone.Model = "Kaspichan";
        Console.WriteLine(myPhone.Model);
        myPhone.Owner = "Bai Stoqn";
        Console.WriteLine(myPhone.Owner);
        myPhone.Price = 1234;
        Console.WriteLine(myPhone.Price);
        myPhone.Battery.BatteryModel = "Test Model";
        Console.WriteLine(myPhone.Battery.BatteryModel);
        myPhone.Battery.HoursIdle = 123;
        Console.WriteLine(myPhone.Battery.HoursIdle);
        myPhone.Display.Size = 123;
        Console.WriteLine(myPhone.Display.Size);
    }
}
