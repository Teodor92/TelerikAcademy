namespace Library
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static MySqlConnection dbCon = null;
        private static StringBuilder output = new StringBuilder();

        public static void StartConection()
        {
            dbCon = new MySqlConnection("server=localhost;user=root;database=library;port=3306;");
        }

        public static void ListAllBooks()
        {
            MySqlCommand listBooks = new MySqlCommand("SELECT * FROM Books", dbCon);

            MySqlDataReader dbInfo = listBooks.ExecuteReader();

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
            MySqlCommand listBooks = new MySqlCommand("INSERT INTO Books(Title, Author, ISBN) VALUES(@title, @author, @catID)", dbCon);
            listBooks.Parameters.AddWithValue("@title", title);
            listBooks.Parameters.AddWithValue("@author", author);
            listBooks.Parameters.AddWithValue("@catID", isbn);

            listBooks.ExecuteNonQuery();
        }

        public static void SearchForBooks(string bookName)
        {
            output.AppendLine("SearchResult");

            MySqlCommand searchBooks = new MySqlCommand("SELECT * FROM Books WHERE Title=@title", dbCon);
            searchBooks.Parameters.AddWithValue("@title", bookName);
            MySqlDataReader dbInfo = searchBooks.ExecuteReader();

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
                MySqlCommand rowCount = new MySqlCommand("SELECT COUNT(id) FROM Books", dbCon);

                Console.WriteLine("Number of rows in Categories is {0}", rowCount.ExecuteScalar());

                ListAllBooks();

                AddBook("TESTE", "IVAN", "A65asd555sda");

                SearchForBooks("asd");
            }



            Console.WriteLine(output.ToString());

            dbCon.Close();
        }
    }
}
