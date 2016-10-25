using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.Mime;

namespace _05.StoreImages
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
                var commandText = "SELECT Picture, CategoryName FROM Categories";

                var command = new SqlCommand(commandText, dbCon);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (string)reader["CategoryName"];
                        categoryName = categoryName.Replace('/', '-');

                        var fileContent = (byte[])reader["Picture"];
                        var fileName = categoryName;
                        var fileFormat = ".jpg";
                        var path = "../../Images/";

                        SaveImage(path, fileName, fileFormat, fileContent);
                    }
                }
            }
        }

        private static void SaveImage(string path, string fileName, string format, byte[] content)
        {
            var stream = File.OpenWrite($"{path}{fileName}{format}");

            using (stream)
            {
                stream.Write(content, 78, content.Length - 78);
            }
        }
    }
}
