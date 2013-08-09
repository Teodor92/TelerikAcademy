namespace _03.ToListProblemTest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using _01.DataModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            SlowSelect();
            timer.Stop();

            Console.WriteLine("Slow select: {0}", timer.Elapsed);
            timer.Reset();

            Console.WriteLine(new string('-', Console.WindowWidth - 5));

            timer.Start();
            FastSelect();
            timer.Stop();

            Console.WriteLine("Fast select: {0}", timer.Elapsed);
            timer.Reset();
        }

        public static void SlowSelect()
        {
            using (TelerikAcademyEntities dbContext = new TelerikAcademyEntities())
            {
                List<Employee> allEmplpyes = (from emp in dbContext.Employees select emp).ToList();
                List<Address> allAddreses = (from address in allEmplpyes select address.Address).ToList();
                List<Town> sofiaTowns = (from town in allAddreses select town.Town).ToList().Where(x => x.Name == "Sofia").ToList();

                foreach (var town in sofiaTowns)
                {
                    Console.WriteLine(town.Name);
                }
            }
        }

        public static void FastSelect()
        {
            using (TelerikAcademyEntities dbContext = new TelerikAcademyEntities())
            {
                List<Employee> sofiaEmployes = (from town in dbContext.Employees
                                                where town.Address.Town.Name == "Sofia"
                                                select town).ToList();

                foreach (var item in sofiaEmployes)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
        }
    }
}
