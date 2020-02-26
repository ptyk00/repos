using System;
using System.Data.SqlClient;

namespace PIV_Lab1
{
    public class DB
    {
        public void Select(SqlConnection connection)
        {
            var query = "SELECT * FROM Customers";

            var command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetString(1)}");
                }
            }
        }

        public void Insert(SqlConnection connection, int id, string regionName)
        {
            var query = "INSERT INTO Region(RegionID, RegionDescription) VALUES(@id, @regionName)";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@regionName", regionName);

            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows inserted");
        }

        public void Delete(SqlConnection connection, int id)
        {
            var query = "DELETE FROM Region WHERE RegionID = @id";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows deleted");
        }

        public void Update(SqlConnection connection, int id, string regionName)
        {
            var query = "UPDATE Region SET RegionDescription = @regionName WHERE RegionID = @id";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@regionName", regionName);

            int affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows updated");
        }
    }
}
