using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PleaseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CarRental test = new CarRental())
            {
                foreach (var item in test.Cars)
                {
                    Console.WriteLine(item.CarYear);
                }
            }
        }
    }
}
