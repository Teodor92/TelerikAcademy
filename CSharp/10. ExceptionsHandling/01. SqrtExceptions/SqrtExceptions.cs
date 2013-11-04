/* Write a program that reads an integer number and 
 * calculates and prints its square root. If the number 
 * is invalid or negative, print "Invalid number". In all 
 * cases finally print "Good bye". Use try-catch-finally.
 */

using System;

public class SqrtExceptions
{
    public static void Main()
    {
        try
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 0)
            {
                throw new FormatException();
            }
            Console.WriteLine(Math.Sqrt(n));
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Argument was null!");
        }
        catch (FormatException fe)
        {
            Console.WriteLine("Invalid number: {0}", fe.Message);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Number was too large or too small!");
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }
    }
}
