namespace FindSales
{
    using System;
    using System.Data.Objects;
    using System.Linq;
    using _01.DataModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            NorthwindEntities dbContent = new NorthwindEntities();

            /* 
             * Steps to reproduse the DB:
             * 1. Open SorceModel.edmx
             * 2. Right button click on the empty space between the tables
             * 3. Click Generate Database from model - it will generate a SQL script
             * 4. Edit the USE [Northwind]; to the name of the database you want to clone the current DB to.
             * 5. Run the script;
             */
        }
    }
}
