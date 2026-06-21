using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.DAL
{
    public class OrderDAL
    {
        /// <summary>
        /// Places a new order with its line items inside a transaction,
        /// and decrements medicine stock accordingly. If anything fails,
        /// the whole order is rolled back so stock numbers never drift.
        /// </summary>
        public bool PlaceOrder(Order order)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string orderQuery = "INSERT INTO Orders (CustomerId, OrderDate, Status, TotalAmount) " +
                                         "OUTPUT INSERTED.OrderId " +
                                         "VALUES (@CustomerId, @OrderDate, @Status, @TotalAmount)";
                    SqlCommand orderCmd = new SqlCommand(orderQuery, conn, transaction);
                    orderCmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    orderCmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    orderCmd.Parameters.AddWithValue("@Status", order.Status);
                    orderCmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

                    int newOrderId = (int)orderCmd.ExecuteScalar();

                    foreach (var item in order.Items)
                    {
                        string itemQuery = "INSERT INTO OrderItems (OrderId, MedicineId, Quantity, UnitPrice) " +
                                            "VALUES (@OrderId, @MedicineId, @Quantity, @UnitPrice)";
                        SqlCommand itemCmd = new SqlCommand(itemQuery, conn, transaction);
                        itemCmd.Parameters.AddWithValue("@OrderId", newOrderId);
                        itemCmd.Parameters.AddWithValue("@MedicineId", item.MedicineId);
                        itemCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                        itemCmd.ExecuteNonQuery();

                        string stockQuery = "UPDATE Medicine SET StockQuantity = StockQuantity - @Qty " +
                                             "WHERE MedicineId = @MedicineId";
                        SqlCommand stockCmd = new SqlCommand(stockQuery, conn, transaction);
                        stockCmd.Parameters.AddWithValue("@Qty", item.Quantity);
                        stockCmd.Parameters.AddWithValue("@MedicineId", item.MedicineId);
                        stockCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return GetOrders("WHERE o.CustomerId = @CustomerId", cmd =>
                cmd.Parameters.AddWithValue("@CustomerId", customerId));
        }

        public List<Order> GetAllOrders()
        {
            return GetOrders("", cmd => { });
        }

        public bool UpdateStatus(int orderId, string newStatus)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "UPDATE Orders SET Status = @Status WHERE OrderId = @OrderId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private List<Order> GetOrders(string whereClause, Action<SqlCommand> bindParams)
        {
            var orders = new Dictionary<int, Order>();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query =
                    "SELECT o.OrderId, o.CustomerId, o.OrderDate, o.Status, o.TotalAmount, " +
                    "c.FullName AS CustomerName, " +
                    "oi.OrderItemId, oi.MedicineId, oi.Quantity, oi.UnitPrice, m.Name AS MedicineName " +
                    "FROM Orders o " +
                    "JOIN Customer c ON o.CustomerId = c.CustomerId " +
                    "LEFT JOIN OrderItems oi ON o.OrderId = oi.OrderId " +
                    "LEFT JOIN Medicine m ON oi.MedicineId = m.MedicineId " +
                    whereClause + " " +
                    "ORDER BY o.OrderDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                bindParams(cmd);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderId = (int)reader["OrderId"];
                        if (!orders.ContainsKey(orderId))
                        {
                            orders[orderId] = new Order
                            {
                                OrderId = orderId,
                                CustomerId = (int)reader["CustomerId"],
                                CustomerName = reader["CustomerName"].ToString(),
                                OrderDate = (DateTime)reader["OrderDate"],
                                Status = reader["Status"].ToString(),
                                TotalAmount = (decimal)reader["TotalAmount"]
                            };
                        }

                        if (reader["OrderItemId"] != DBNull.Value)
                        {
                            orders[orderId].Items.Add(new OrderItem
                            {
                                OrderItemId = (int)reader["OrderItemId"],
                                OrderId = orderId,
                                MedicineId = (int)reader["MedicineId"],
                                MedicineName = reader["MedicineName"].ToString(),
                                Quantity = (int)reader["Quantity"],
                                UnitPrice = (decimal)reader["UnitPrice"]
                            });
                        }
                    }
                }
            }

            return new List<Order>(orders.Values);
        }
    }
}
