using Dapper;
using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "";
            using var connection = new SqlConnection(connectionString);

            //var sql = "SELECT * FROM Region";
            //var regions = connection.Query<Region>(sql);

            var region = new Region()
            {
                ReigionDescription = "dapper",
                ReigionId = 101
            };

            //var insertSql = "INSERT INTO Region(regionID, regionDescription) VALUES(@id, @description)";
            // var result = connection.Execute(insertSql, new { id = 100, desciption = "dapper" });

            var db = new DB();
            db.Insert(connection, region);


        }
    }
}
