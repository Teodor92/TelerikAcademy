namespace SimpleDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class Program
    {
        public static void Main()
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var dictonaryDB = mongoServer.GetDatabase("dictonaryDB");
            MongoCollection<BsonDocument> dicronary = dictonaryDB.GetCollection("dictonary");

            //dicronary.Drop();

            //for (int i = 0; i < 10; i++)
            //{
            //    InsertEntry(dicronary, "Book" + i, "TestDescription");
            //}

            //ListDictonary(dicronary);

            FindDescriptionByBookName(dicronary, "Book6");

            Console.WriteLine("End");

        }

        public static void InsertEntry(MongoCollection dictonary, string bookName, string description)
        {
            dictonary.Insert(new Entry(bookName, description));
        }

        public static void ListDictonary(MongoCollection<BsonDocument> dictonary)
        {
            Console.WriteLine("List");

            foreach (var item in dictonary.FindAll())
            {
                Console.WriteLine(new string('-', Console.WindowWidth - 5));

                foreach (var book in item.Values)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public static void FindDescriptionByBookName(MongoCollection dictonary, string bookName)
        {
            var searchQuery = Query.EQ("Name", bookName);

            var queryResult = dictonary.FindAs<Entry>(searchQuery);

            Console.WriteLine("Search");
            Console.WriteLine(new string('-', Console.WindowWidth - 5));

            foreach (var item in queryResult)
            {
                Console.WriteLine("Book Name: {0}, Transalation: {1}", item.Name, item.Translation);
            }
        }
    }
}
