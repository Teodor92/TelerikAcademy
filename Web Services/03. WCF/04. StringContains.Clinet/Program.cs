using _04.StringContains.Clinet.StringContainsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.StringContains.Clinet
{
    class Program
    {
        public static void Main()
        {
            ServiceStringContainsClient stringClinet = new ServiceStringContainsClient();

            var output = stringClinet.ContainsString("IvanIHamIadiAw", "I");

            Console.WriteLine(output);

        }
    }
}
