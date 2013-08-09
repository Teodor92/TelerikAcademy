namespace NumberOfRowsInCategories
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand rowCount = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories", dbCon);

                Console.WriteLine("Number of rows in Categories is {0}", rowCount.ExecuteScalar());
            }
        }
    }
}
