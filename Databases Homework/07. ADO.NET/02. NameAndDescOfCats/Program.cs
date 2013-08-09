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
                SqlCommand catNamesAndDesc = new SqlCommand("SELECT CategoryName, [Description] FROM Categories", dbCon);

                SqlDataReader dbInfo = catNamesAndDesc.ExecuteReader();

                using (dbInfo)
                {
                    while (dbInfo.Read())
                    {
                        output.AppendFormat("Name: {0}, Description: {1}", dbInfo["CategoryName"], dbInfo["Description"]);
                        output.AppendLine();
                    }
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
