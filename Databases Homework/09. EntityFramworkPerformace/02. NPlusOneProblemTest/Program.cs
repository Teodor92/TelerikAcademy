namespace _02.NPlusOneProblemTest
{
    using System;
    using _01.DataModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            //PrintEmployeInfo();

            PrintEmployeInfoFast();
        }

        public static void PrintEmployeInfo()
        {
            using (TelerikAcademyEntities dbContext = new TelerikAcademyEntities())
            {
                foreach (var employe in dbContext.Employees)
                {
                    Console.WriteLine("Employe name: {0}", employe.FirstName);
                    Console.WriteLine("Employe department name: {0}", employe.Department.Name);
                    Console.WriteLine("Employe town name: {0}", employe.Address.Town.Name);
                }
            }
        }

        public static void PrintEmployeInfoFast()
        {
            using (TelerikAcademyEntities dbContext = new TelerikAcademyEntities())
            {
                foreach (var employe in dbContext.Employees.Include("Department").Include("Address").Include("Address.Town"))
                {
                    Console.WriteLine("Employe name: {0}", employe.FirstName);
                    Console.WriteLine("Employe department name: {0}", employe.Department.Name);
                    Console.WriteLine("Employe town name: {0}", employe.Address.Town.Name);
                }
            }
        }
    }
}
