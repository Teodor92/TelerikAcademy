namespace ExcelReader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.OleDb;
    using System.Data;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Set Access connection and select strings.
            // The path to BugTypes.MDB must be changed if you build 
            // the sample from the command line:

            string strAccessConn = string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    "../../sample.xlsx");

            string strAccessSelect = "SELECT * FROM [Лист1$]";

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

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Лист1");

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

            Console.WriteLine("{0} rows in the excel doc table", myDataSet.Tables["Лист1"].Rows.Count);
            Console.WriteLine("{0} columns in Categories table", myDataSet.Tables["Лист1"].Columns.Count);

            DataColumnCollection drc = myDataSet.Tables["Лист1"].Columns;
            foreach (DataColumn dc in drc)
            {
                Console.WriteLine("Column name is {0}, of type {1}", dc.ColumnName, dc.DataType);
            }

            DataRowCollection dra = myDataSet.Tables["Лист1"].Rows;

            foreach (DataRow dr in dra)
            {
                Console.WriteLine("{0}, {1}, {2}", dr[0], dr[1], dr[2]);
            }

        }
    }
}
