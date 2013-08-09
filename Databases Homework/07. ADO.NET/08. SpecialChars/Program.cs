namespace SpecialChars
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static SqlConnection dbCon;

        private static void ConnectToDB()
        {
            dbCon = new SqlConnection("Server=.; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
        }

        private static void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }

        private static int InsertProduct(
            string productName,
            int supplierID,
            int categoryID,
            string quantityPerUnit,
            decimal unitPrice,
            short unitsInStock,
            short unitsOnOrder,
            short reorderLevel,
            byte discontinued)
        {
            SqlCommand cmdInsertProduct = new SqlCommand(
            @"INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, 
            UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
            "VALUES (@name, @supID, @catID, @qpu, @unitPrice, @unitsInStick, @unitsInOrder, @reorderLvl, @discont)", dbCon);
            cmdInsertProduct.Parameters.AddWithValue("@name", productName);
            cmdInsertProduct.Parameters.AddWithValue("@supID", supplierID);
            cmdInsertProduct.Parameters.AddWithValue("@catID", categoryID);
            cmdInsertProduct.Parameters.AddWithValue("@qpu", quantityPerUnit);
            cmdInsertProduct.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmdInsertProduct.Parameters.AddWithValue("@unitsInStick", unitsInStock);
            cmdInsertProduct.Parameters.AddWithValue("@unitsInOrder", unitsOnOrder);
            cmdInsertProduct.Parameters.AddWithValue("@reorderLvl", reorderLevel);
            cmdInsertProduct.Parameters.AddWithValue("@discont", discontinued);

            cmdInsertProduct.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity =
                new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId =
                (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

        public static void Main()
        {
            try
            {
                ConnectToDB();
                Console.WriteLine("Product Name:");
                string productName = Console.ReadLine();

                Console.WriteLine("Sup ID:");
                int supId = int.Parse(Console.ReadLine());

                Console.WriteLine("Cat ID:");
                int catId = int.Parse(Console.ReadLine());

                Console.WriteLine("Units in stock:");
                string unitsInstock = Console.ReadLine();

                Console.WriteLine("Unit Price");
                decimal unitPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Units in stock:");
                short unitsInStock = short.Parse(Console.ReadLine());

                Console.WriteLine("Units on order:");
                short unitsOnOrder = short.Parse(Console.ReadLine());

                Console.WriteLine("Reorder Level:");
                short reorderLevel = short.Parse(Console.ReadLine());

                Console.WriteLine("Discontinued:");
                byte discontinued = byte.Parse(Console.ReadLine());

                int newProjectId = InsertProduct(
                    productName, 
                    supId, 
                    catId, 
                    unitsInstock, 
                    unitPrice, 
                    unitsInStock, 
                    unitsOnOrder, 
                    reorderLevel, 
                    discontinued);
                Console.WriteLine("Inserted new product. ProjectID = {0}", newProjectId);
            }
            finally
            {
                DisconnectFromDB();
            }
        }
    }
}
