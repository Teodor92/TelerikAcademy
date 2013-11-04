using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Data;
using Students.Models;

namespace Students.Client
{
    public class Program
    {
        public static void Main()
        {
            StudentsContext testContext = new StudentsContext();

            foreach (var item in testContext.Students.ToList())
            {
                foreach (var lol in item.Marks)
                {
                    Console.WriteLine(lol.Value);
                }
            }


        }
    }
}
