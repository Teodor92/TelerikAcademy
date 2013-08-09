namespace _01.DayOfTheWeek.Client
{
    using System;
    using System.Linq;
    using _01.DayOfTheWeek.Client.DayOfTheWeekService;
    using System.Globalization;

    public class Program
    {
        private static Random randGen = new Random();

        internal static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("bg-BG");
            ServiceDayGetterClient dayService = new ServiceDayGetterClient();

            DateTime date = DateTime.Now;

            for (int i = 0; i < 50; i++)
            {
                var day = dayService.GetDay(date);

                Console.WriteLine(day);

                date = date.AddDays(randGen.Next(1, 5));
            }
        }
    }
}
