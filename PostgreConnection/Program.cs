using Npgsql;
using System;

namespace PostgreConnection
{
    internal class Program
    {
        static string baglaticumlesi = "Server=127.0.0.1;" +
                                "Port=5432;" +
                                "Database=Northwind;" +
                                "User Id=postgres;" +
                                "Password=123; ";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PostgreBaglan();
        }
        public static void PostgreBaglan()
        {
            string sql = "Select * from Customers";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(baglaticumlesi);
            npgsqlConnection.Open();

            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sql, npgsqlConnection);
            NpgsqlDataReader rdr = npgsqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr["Customer_Id"] + " " + rdr["Company_Name"] + " " + rdr["Contact_Name"]);
            }
            npgsqlConnection.Close();
        }
    }
}
