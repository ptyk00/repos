using System.Data.SqlClient;

namespace PIV_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using var connection = new SqlConnection(connectionString);

            var db = new DB();
            connection.Open();

            //db.Select(connection);
            //db.Insert(connection, 10, "Bielsko");
            //db.Delete(connection, 10);
            db.Update(connection, 4, "Bielsko");

            connection.Close();
        }
    }
}
