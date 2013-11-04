/* Define several constructors for the 
 * defined classes that take different 
 * sets of arguments (the full information for the class or part of it). 
 * Assume that model and manufacturer are mandatory (the others are optional). 
 * All unknown data fill with null.
 */

using System;
using System.Linq;


public class GSMTest
{
    static void Main()
    {
        // GSMTest
        GSM[] test = new GSM[3];

        Display testDisplay = new Display(12, 13);
        Battery testBattery = new Battery(BatteryType.LiIon, 10, 10);

        GSM firstPhone = new GSM("test", "test", 12, "Bai Ivan", testBattery, testDisplay);
        test[0] = firstPhone;

        GSM secondPhone = new GSM("SecondTest", "SecondTest", 14, "Moore Name", testBattery, testDisplay);
        test[1] = secondPhone;

        GSM thirdPhone = new GSM("Some test", "Texttt", 1, "Name", testBattery, testDisplay);
        test[2] = thirdPhone;

        for (int i = 0; i < test.Length; i++)
        {
            Console.WriteLine(test[i]);
        }

        Console.WriteLine(GSM.Iphone.Model);
        Console.WriteLine(GSM.Iphone.Manufacturer);
        Console.WriteLine(firstPhone.Battery.BatteryModel);

        Console.WriteLine("---------------------------------");
        Console.WriteLine("GSMCallHistoryTest");
        Console.WriteLine("---------------------------------");

        //GSMCallHistoryTest
        GSM myPhone = new GSM("Nokia", "Nokia Corp", 1, "Ivan", testBattery, testDisplay);


        myPhone.AddCall(DateTime.Now, "088888888", 236);
        myPhone.AddCall(DateTime.Now, "077777777", 333);
        myPhone.AddCall(DateTime.Now, "066666666", 123);
        myPhone.AddCall(DateTime.Now, "055555555", 11);
        myPhone.AddCall(DateTime.Now, "044444444", 23);

        myPhone.DisplayCallHistory();

        Console.WriteLine(myPhone.CalcPrice(0.37));

        myPhone.RemoveCallByDuration(333);

        myPhone.DisplayCallHistory();
        Console.WriteLine(myPhone.CalcPrice(0.37));

        myPhone.ClearHistory();
        myPhone.DisplayCallHistory();


    }
}
