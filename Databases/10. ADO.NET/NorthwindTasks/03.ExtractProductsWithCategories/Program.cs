using System;
using System.Data.SqlClient;

namespace _03.ExtractProductsWithCategories
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
                var commandText = "SELECT p.ProductName, c.CategoryName FROM Products p JOIN Categories c ON p.CategoryID=c.CategoryID";
                var command = new SqlCommand(commandText, dbCon);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (string)reader["CategoryName"];
                        var productName = (string)reader["ProductName"];

                        Console.WriteLine($"Product Name: {productName}, Category: {categoryName}");
                    }
                }
            }
        }
    }
}
