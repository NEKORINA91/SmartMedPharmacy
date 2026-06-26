using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartMedPharmacy.DAL
{
    public class SalesReportRow
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class StockReportRow
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Dosage { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Supplier { get; set; }
    }

    public class OrderHistoryRow
    {
        public string CustomerName { get; set; }
        public string Username { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
    }

    public class ReportsDAL
    {
        public List<SalesReportRow> GetSalesReport()
        {
            var list = new List<SalesReportRow>();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query =
                    "SELECT o.OrderId, c.FullName AS CustomerName, " +
                    "CONVERT(NVARCHAR, o.OrderDate, 105) AS OrderDate, " +
                    "o.Status, o.TotalAmount " +
                    "FROM Orders o " +
                    "JOIN Customer c ON o.CustomerId = c.CustomerId " +
                    "ORDER BY o.OrderDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SalesReportRow
                        {
                            OrderId = (int)reader["OrderId"],
                            CustomerName = reader["CustomerName"].ToString(),
                            OrderDate = reader["OrderDate"].ToString(),
                            Status = reader["Status"].ToString(),
                            TotalAmount = (decimal)reader["TotalAmount"]
                        });
                    }
                }
            }
            return list;
        }

        public List<StockReportRow> GetStockReport()
        {
            var list = new List<StockReportRow>();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query =
                    "SELECT Name, Category, Dosage, Price, StockQuantity, Supplier " +
                    "FROM Medicine ORDER BY Category, Name";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StockReportRow
                        {
                            Name = reader["Name"].ToString(),
                            Category = reader["Category"].ToString(),
                            Dosage = reader["Dosage"] == System.DBNull.Value ? "-" : reader["Dosage"].ToString(),
                            Price = (decimal)reader["Price"],
                            StockQuantity = (int)reader["StockQuantity"],
                            Supplier = reader["Supplier"] == System.DBNull.Value ? "-" : reader["Supplier"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<OrderHistoryRow> GetOrderHistoryReport()
        {
            var list = new List<OrderHistoryRow>();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query =
                    "SELECT c.FullName AS CustomerName, c.Username, " +
                    "COUNT(o.OrderId) AS TotalOrders, " +
                    "ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent " +
                    "FROM Customer c " +
                    "LEFT JOIN Orders o ON c.CustomerId = o.CustomerId " +
                    "GROUP BY c.FullName, c.Username " +
                    "ORDER BY TotalSpent DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new OrderHistoryRow
                        {
                            CustomerName = reader["CustomerName"].ToString(),
                            Username = reader["Username"].ToString(),
                            TotalOrders = (int)reader["TotalOrders"],
                            TotalSpent = (decimal)reader["TotalSpent"]
                        });
                    }
                }
            }
            return list;
        }
    }
}
