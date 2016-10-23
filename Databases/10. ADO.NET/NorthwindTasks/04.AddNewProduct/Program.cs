using System;
using System.Data.SqlClient;

namespace _04.AddNewProduct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = "Server =.; Database=Northwind; Integrated Security=true";

            var dbCon = new SqlConnection(connectionString);
            dbCon.Open();

            using (dbCon)
            {
                var commandText = @"INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice)
                        VALUES(@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice)";
                var command = new SqlCommand(commandText, dbCon);

                command.Parameters.AddWithValue("@productName", "Zagorka");
                command.Parameters.AddWithValue("@supplierID", 1);
                command.Parameters.AddWithValue("@categoryID", 2);
                command.Parameters.AddWithValue("@quantityPerUnit", "20x0.5l");
                command.Parameters.AddWithValue("@unitPrice", 3);

                command.ExecuteNonQuery();
            }
        }
    }
}
