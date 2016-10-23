using System;
using System.Data.SqlClient;

namespace _02.GetCategoriesNameDescription
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
                var commandText = "SELECT CategoryName, Description FROM Categories";
                var command = new SqlCommand(commandText, dbCon);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (string)reader["CategoryName"];
                        var categoryDescription = (string)reader["Description"];

                        Console.WriteLine($"Name: {categoryName}, Description: {categoryDescription}");
                    }
                }
            }
        }
    }
}
