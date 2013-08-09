namespace NameAndDescOfCats
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();

            SqlConnection dbCon = new SqlConnection("Server=.; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand catNamesAndDesc = new SqlCommand(@"SELECT ProductName, CategoryName
                                                            FROM Categories cat
                                                            JOIN Products pro
	                                                            ON pro.CategoryID = cat.CategoryID
                                                            ORDER BY CategoryName", dbCon);

                SqlDataReader dbInfo = catNamesAndDesc.ExecuteReader();

                using (dbInfo)
                {
                    while (dbInfo.Read())
                    {
                        output.AppendFormat("Product Name: {0}, Category Name: {1}", dbInfo["ProductName"], dbInfo["CategoryName"]);
                        output.AppendLine();
                    }
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
