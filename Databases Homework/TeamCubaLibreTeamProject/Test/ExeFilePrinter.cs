namespace Test
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Text;

    public class ExcelReader
    {
        public void GetSubDirs(string path)
        {
            try
            {
                this.ShowExes(path);

                string[] dirs = Directory.GetDirectories(path);

                if (dirs.Length > 0)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        this.GetSubDirs(dirs[i]);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Directory: {0}, CAN NOT be accessed!", path);
                return;
            }
        }

        private void ShowExes(string path)
        {
            StringBuilder output = new StringBuilder();

            string[] exes = Directory.GetFiles(path, @"*.xls");

            foreach (var item in exes)
            {
                string strAccessConn = string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    item);

                //Console.WriteLine(strAccessConn);

                OleDbConnection myAccessConn = new OleDbConnection(strAccessConn);
                myAccessConn.Open();
                Console.WriteLine();
                DataSet myDataSet = new DataSet();
                string strAccessSelect = "SELECT * FROM [Sales$]";

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
                    myDataAdapter.Fill(myDataSet, "Sales");

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

                Console.WriteLine("{0} rows in the excel doc table", myDataSet.Tables["Sales"].Rows.Count);
                Console.WriteLine("{0} columns in Categories table", myDataSet.Tables["Sales"].Columns.Count);

                DataColumnCollection drc = myDataSet.Tables["Sales"].Columns;
                foreach (DataColumn dc in drc)
                {
                    Console.WriteLine("Column name is {0}, of type {1}", dc.ColumnName, dc.DataType);
                }

                DataRowCollection dra = myDataSet.Tables["Sales"].Rows;

                foreach (DataRow dr in dra)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", dr[0], dr[1], dr[2], dr[3]);
                }
            }

            Console.Write(output.ToString());
        }
    }
}
