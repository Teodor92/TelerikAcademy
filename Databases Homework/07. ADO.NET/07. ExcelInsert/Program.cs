namespace ExcelInsert
{
    using System;
    using System.Linq;
    using System.Data.OleDb;
    using System.Data;

    public class Program
    {
        public static void InsertIntoExcelDoc(OleDbConnection dbConnect, string name, int score, short won)
        {
            string strAccessSelect = string.Format(
                "INSERT INTO [Лист1$](Name, Score, Won) VALUES ({0}, {1}, {2})", 
                string.Format("'{0}'", name), 
                score, 
                won);

            OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, dbConnect);
            dbConnect.Open();

            myAccessCommand.ExecuteScalar();

            dbConnect.Close();
        }

        public static void Main(string[] args)
        {
            // Set Access connection and select strings.
            // The path to BugTypes.MDB must be changed if you build 
            // the sample from the command line:

            string strAccessConn = string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    "../../sample.xlsx");

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }

            try
            {

                InsertIntoExcelDoc(myAccessConn, "Ivan", 23, 1);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }
        }
    }
}
