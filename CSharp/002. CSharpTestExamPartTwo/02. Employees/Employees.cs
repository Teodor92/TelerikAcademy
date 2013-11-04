using System;
using System.Collections.Generic;
using System.Linq;

struct Worker
{
    public string NameFirst;
    public string NameLast;
    public string Positon;
    public int Rang;
}

class Employees
{

    static void Main()
    {
        int numberOfPositions = int.Parse(Console.ReadLine());
        Dictionary<string, int> PosAndRanks = new Dictionary<string, int>();
        for (int i = 0; i < numberOfPositions; i++)
        {
            string[] input = Console.ReadLine().Split('-');
            string trimed = input[0].Trim();
            if (!PosAndRanks.ContainsKey(trimed))
            {
                PosAndRanks.Add(trimed, int.Parse(input[1]));
            }
        }

        List<Worker> People = new List<Worker>();
        int numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] input = Console.ReadLine().Split('-');
            Worker emp = new Worker();
            string[] splited = input[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string trimed = input[1].Trim();
            emp.NameFirst = splited[0];
            emp.NameLast = splited[splited.Length - 1];
            emp.Positon = trimed;
            if (PosAndRanks.ContainsKey(trimed))
            {
                emp.Rang = PosAndRanks[trimed];
            }

            People.Add(emp);
        }

        var orederedPpl = People.OrderByDescending(x => x.Rang).ThenBy(x => x.NameLast).ThenBy(x => x.NameFirst);
        foreach (var person in orederedPpl)
        {
            Console.WriteLine("{0} {1}", person.NameFirst, person.NameLast);
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class ExamTest
//{
//    static void Main()
//    {
//        //number of positions
//        int positions = int.Parse(Console.ReadLine());
//        //positions and ranks
//        Dictionary<string, int> PosAndRanks = new Dictionary<string, int>();
//        for (int i = 0; i < positions; i++)
//        {
//            string[] input = Console.ReadLine().Split('-');
//            PosAndRanks.Add(input[0].Trim(), int.Parse(input[1]));
//        }
//        //number of people
//        int numOfPeople = int.Parse(Console.ReadLine());
//        // people and profs
//        Dictionary<string[], int> people = new Dictionary<string[], int>();
//        for (int i = 0; i < numOfPeople; i++)
//        {
//            string[] input = Console.ReadLine().Split('-');
//            input[0] = input[0].Trim();
//            string[] name = input[0].Split(' ');
//            input[1] = input[1].Trim();
//            if (PosAndRanks.ContainsKey(input[1]))
//            {
//                people.Add(name, PosAndRanks[input[1]]);
//            }
//        }
//        var orederedPpl = people.OrderByDescending(ordered => ordered.Value).ThenBy(oredered => oredered.Key[1]).ThenBy(oredered => oredered.Key[0]);
//        foreach (var item in orederedPpl)
//        {
//            Console.WriteLine("{0} {1}",item.Key[0],item.Key[1]);
//        }

//    }
//}