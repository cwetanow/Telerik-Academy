using System;
using System.Data.SqlClient;

namespace _01.ExtractCategoriesCount
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
                var commandText = "SELECT COUNT(*) FROM Categories";
                var command = new SqlCommand(commandText, dbCon);

                var categoriesCount = (int)command.ExecuteScalar();

                Console.WriteLine(categoriesCount);
            }
        }
    }
}
