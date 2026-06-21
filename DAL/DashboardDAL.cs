using System.Data.SqlClient;

namespace SmartMedPharmacy.DAL
{
    /// <summary>
    /// Holds the summary numbers shown on the Admin Dashboard overview.
    /// </summary>
    public class DashboardStats
    {
        public decimal TotalSales { get; set; }
        public int TotalMedicinesInStock { get; set; }
        public int ActiveOrders { get; set; }
    }

    public class DashboardDAL
    {
        /// <summary>
        /// Pulls together the three headline numbers for the admin dashboard:
        /// total revenue from delivered orders, total units of medicine
        /// currently in stock, and how many orders are still in progress
        /// (Pending or Ready for Pickup).
        /// </summary>
        public DashboardStats GetStats()
        {
            var stats = new DashboardStats();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // Total sales = sum of TotalAmount for orders that have been delivered
                string salesQuery = "SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders WHERE Status = 'Delivered'";
                SqlCommand salesCmd = new SqlCommand(salesQuery, conn);
                stats.TotalSales = (decimal)salesCmd.ExecuteScalar();

                // Total medicines in stock = sum of all StockQuantity across the table
                string stockQuery = "SELECT ISNULL(SUM(StockQuantity), 0) FROM Medicine";
                SqlCommand stockCmd = new SqlCommand(stockQuery, conn);
                stats.TotalMedicinesInStock = (int)stockCmd.ExecuteScalar();

                // Active orders = anything not yet delivered
                string activeQuery = "SELECT COUNT(*) FROM Orders WHERE Status IN ('Pending', 'Ready for Pickup')";
                SqlCommand activeCmd = new SqlCommand(activeQuery, conn);
                stats.ActiveOrders = (int)activeCmd.ExecuteScalar();
            }

            return stats;
        }
    }
}
