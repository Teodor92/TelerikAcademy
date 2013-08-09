namespace LibrarySQLite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SQLite;

    public class Program
    {
        private static SQLiteConnection dbCon = null;
        private static StringBuilder output = new StringBuilder();

        public static void StartConection()
        {
            dbCon = new SQLiteConnection("Data Source=../../app_data/library.db");
        }

        public static void ListAllBooks()
        {
            SQLiteCommand listBooks = new SQLiteCommand("SELECT * FROM Books", dbCon);

            SQLiteDataReader dbInfo = listBooks.ExecuteReader();

            using (dbInfo)
            {
                while (dbInfo.Read())
                {
                    output.AppendFormat("Title: {0}, Author: {1}, ISBN: {2}", dbInfo["Title"], dbInfo["Author"], dbInfo["ISBN"]);
                    output.AppendLine();
                }
            }
        }

        public static void AddBook(string title, string author, string isbn)
        {
            SQLiteCommand listBooks = new SQLiteCommand("INSERT INTO Books(Title, Author, ISBN) VALUES(@title, @author, @catID)", dbCon);
            listBooks.Parameters.AddWithValue("@title", title);
            listBooks.Parameters.AddWithValue("@author", author);
            listBooks.Parameters.AddWithValue("@catID", isbn);

            listBooks.ExecuteNonQuery();
        }

        public static void SearchForBooks(string bookName)
        {
            output.AppendLine("SearchResult");

            SQLiteCommand searchBooks = new SQLiteCommand("SELECT * FROM Books WHERE Title=@title", dbCon);
            searchBooks.Parameters.AddWithValue("@title", bookName);
            SQLiteDataReader dbInfo = searchBooks.ExecuteReader();

            using (dbInfo)
            {
                while (dbInfo.Read())
                {
                    output.AppendFormat("Title: {0}, Author: {1}, ISBN: {2}", dbInfo["Title"], dbInfo["Author"], dbInfo["ISBN"]);
                    output.AppendLine();
                }
            }
        }

        public static void Main(string[] args)
        {
            StartConection();
            dbCon.Open();
            using (dbCon)
            {
                SQLiteCommand rowCount = new SQLiteCommand("SELECT COUNT(id) FROM Books", dbCon);

                Console.WriteLine("Number of rows in Categories is {0}", rowCount.ExecuteScalar());

                ListAllBooks();

                AddBook("TESTE", "IVAN", "A65asd555sda");

                SearchForBooks("TESTE");
            }



            Console.WriteLine(output.ToString());
        }
    }
}
