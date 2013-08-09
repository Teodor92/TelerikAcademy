using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PleaseNorhtwindWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = { "asd", "asddd", "ddeeee" };
            int[] tester = { 1, 2, 3, 4, 5, 6 };

            var zipped = test.Zip(tester, (a, b) => new { a, b });

            foreach (var item in zipped)
            {
                Console.WriteLine("First: {0}, Second: {1}", item.a, item.b);
            }
        }
    }
}
