using System.Collections.Generic;
using System.Data.SqlClient;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.DAL
{
    public class MedicineDAL
    {
        public List<Medicine> GetAll()
        {
            var list = new List<Medicine>();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM Medicine ORDER BY Name";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapReader(reader));
                }
            }
            return list;
        }

        public bool Add(Medicine m)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "INSERT INTO Medicine (Name, Category, Dosage, Price, StockQuantity, Supplier) " +
                                "VALUES (@Name, @Category, @Dosage, @Price, @StockQuantity, @Supplier)";
                SqlCommand cmd = new SqlCommand(query, conn);
                BindParams(cmd, m);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(Medicine m)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "UPDATE Medicine SET Name=@Name, Category=@Category, Dosage=@Dosage, " +
                                "Price=@Price, StockQuantity=@StockQuantity, Supplier=@Supplier " +
                                "WHERE MedicineId=@MedicineId";
                SqlCommand cmd = new SqlCommand(query, conn);
                BindParams(cmd, m);
                cmd.Parameters.AddWithValue("@MedicineId", m.MedicineId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int medicineId)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "DELETE FROM Medicine WHERE MedicineId = @MedicineId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MedicineId", medicineId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Search by name and/or category, optionally within a price range.
        /// Uses a parameterised LIKE query (SQL-side filtering) rather than
        /// pulling everything back and filtering in C#, which is the more
        /// efficient approach once the table grows.
        /// </summary>
        public List<Medicine> Search(string name, string category, decimal? minPrice, decimal? maxPrice)
        {
            var list = new List<Medicine>();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM Medicine WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(name)) query += " AND Name LIKE @Name";
                if (!string.IsNullOrWhiteSpace(category)) query += " AND Category = @Category";
                if (minPrice.HasValue) query += " AND Price >= @MinPrice";
                if (maxPrice.HasValue) query += " AND Price <= @MaxPrice";
                query += " ORDER BY Name";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(name)) cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
                if (!string.IsNullOrWhiteSpace(category)) cmd.Parameters.AddWithValue("@Category", category);
                if (minPrice.HasValue) cmd.Parameters.AddWithValue("@MinPrice", minPrice.Value);
                if (maxPrice.HasValue) cmd.Parameters.AddWithValue("@MaxPrice", maxPrice.Value);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapReader(reader));
                }
            }
            return list;
        }

        public bool DecreaseStock(int medicineId, int quantity)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "UPDATE Medicine SET StockQuantity = StockQuantity - @Qty " +
                                "WHERE MedicineId = @MedicineId AND StockQuantity >= @Qty";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Qty", quantity);
                cmd.Parameters.AddWithValue("@MedicineId", medicineId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void BindParams(SqlCommand cmd, Medicine m)
        {
            cmd.Parameters.AddWithValue("@Name", m.Name);
            cmd.Parameters.AddWithValue("@Category", m.Category);
            cmd.Parameters.AddWithValue("@Dosage", (object)m.Dosage ?? System.DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", m.Price);
            cmd.Parameters.AddWithValue("@StockQuantity", m.StockQuantity);
            cmd.Parameters.AddWithValue("@Supplier", (object)m.Supplier ?? System.DBNull.Value);
        }

        private Medicine MapReader(SqlDataReader reader)
        {
            return new Medicine
            {
                MedicineId = (int)reader["MedicineId"],
                Name = reader["Name"].ToString(),
                Category = reader["Category"].ToString(),
                Dosage = reader["Dosage"] == System.DBNull.Value ? null : reader["Dosage"].ToString(),
                Price = (decimal)reader["Price"],
                StockQuantity = (int)reader["StockQuantity"],
                Supplier = reader["Supplier"] == System.DBNull.Value ? null : reader["Supplier"].ToString(),
                CreatedAt = (System.DateTime)reader["CreatedAt"]
            };
        }
    }
}
