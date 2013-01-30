using System;
	 
class WeAllLoveBits
{
	static void Main()
	{
	    int n = int.Parse(Console.ReadLine());
	    for (int i = 1; i <= n; i++)
	    {
	        int oldNumber = int.Parse(Console.ReadLine());
	        int newNumber = 0;
	        while (oldNumber > 0)
	        {
	            newNumber <<= 1;
	            if ((oldNumber & 1) == 1)
	            {
	                newNumber |= 1;
	            }
	            oldNumber >>= 1;
	        }
	        Console.WriteLine(newNumber);
	    }
	}
}