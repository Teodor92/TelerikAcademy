namespace SimpleDictonaryRedis
{
    using ServiceStack.Redis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var redisClient = new RedisClient("127.0.0.1:6379"))
            {
                for (int i = 0; i < 12; i++)
                {
                    Entry newEntry = new Entry("BookName" + i, "Some description" + (12 - i));

                    AddEntry(redisClient, newEntry);
                }

                ListAllEntries(redisClient);

                FindEntryByBookName(redisClient, "BookName3");
            }
        }

        public static void AddEntry(RedisClient redisIO, Entry entry)
        {
            redisIO.HSet("Dictonary", entry.Name.ToAsciiCharArray(), entry.Translation.ToAsciiCharArray());
        }

        public static void ListAllEntries(RedisClient redisIO)
        {
            Console.WriteLine("List");

            Console.WriteLine(new string('-', Console.WindowWidth - 5));

            foreach (var item in redisIO.HGetAll("Dictonary"))
            {
                Console.WriteLine(StringExtensions.StringFromByteArray(item));
                Console.WriteLine(new string('-', Console.WindowWidth - 5));
            }
        }

        public static void FindEntryByBookName(RedisClient redisIO, string bookName)
        {
            Console.WriteLine("Search");
            Console.WriteLine(new string('-', Console.WindowWidth - 5));

            string translation = StringExtensions.StringFromByteArray(redisIO.HGet("Dictonary", bookName.ToAsciiCharArray()));

            Console.WriteLine("Book Name: {0}, Translation: {1}", bookName, translation);
        }
    }
}
