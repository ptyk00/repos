using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleApp1
{
    public class DB
    {
        public void Select(IDbConnection connection)
        {
            var sql = "SELECT * FROM Region";
            var regions = connection.Query<Region>(sql);

            foreach (var item in regions)
            {
                Console.WriteLine($"{item.ReigionId}: {item.ReigionDescription}");
            }
        }

        public int Insert(IDbConnection connection, Region region)
        {
            var insertSql = "INSERT INTO Region(regionID, regionDescription) VALUES(@id, @description)";

            return connection.Execute(insertSql, region);
        }

        public int Insert(IDbConnection connection, int id, string desc)
        {
            var insertSql = "INSERT INTO Region(regionID, regionDescription) VALUES(@id, @description)";

            return connection.Execute(insertSql, new { id = id, desciption = desc });
        }

        public int Delete(IDbConnection connection, int id)
        {
            var sql = "DELETE FROM Rgion WHERE regionId = @id";

            return connection.Execute(sql, new { id = id });
        }

        public void SelectOrder(IDbConnection connection, int id)
        {
            var sql = "SELECT * FROM Orders o " +
                "INNER JOIN [Order Details] od ON o.OrderID = od.OrderID" +
                " WHERE o.OrderID = od.OrderID";

            var resultOrder = default(Order);

            var result = connection.Query<Order, OrderDetails, Order>(
                sql,
                (order, orderDetails) =>
                {
                    resultOrder ??= order;

                    resultOrder.Details.Add(orderDetails);
                    return resultOrder;
                },
                new { id },
                splitOn: "OrderID"
                );
        }
    }
}
