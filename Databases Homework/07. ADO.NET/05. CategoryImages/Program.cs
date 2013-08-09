namespace NameAndDescOfCats
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
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
                SqlCommand catNamesAndDesc = new SqlCommand(@"SELECT Picture
                                                            FROM Categories 
                                                            ", dbCon);

                SqlDataReader dbInfo = catNamesAndDesc.ExecuteReader();
                int coutner = 1;
                using (dbInfo)
                {
                    while (dbInfo.Read())
                    {
                        byte[] imageData = (byte[])dbInfo["Picture"];

                        FileStream stream = File.OpenWrite(string.Format("../../pic{0}.jpg", coutner));
                        
                        using (stream)
                        {
                            stream.Write(imageData, 0, imageData.Length);
                        }

                        coutner++;
                    }
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
