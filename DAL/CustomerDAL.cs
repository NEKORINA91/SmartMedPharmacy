using System.Data.SqlClient;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.DAL
{
    public class CustomerDAL
    {
        public Customer Login(string username, string password)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "SELECT CustomerId, Username, PasswordHash, FullName, Email, Phone, Address, CreatedAt " +
                                "FROM Customer WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader["PasswordHash"].ToString();
                        if (PasswordHelper.Verify(password, storedHash))
                        {
                            return MapReaderToCustomer(reader);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// User name check for new users
        /// </summary>
        public bool Register(Customer customer)
        {
            if (UsernameExists(customer.Username))
                return false;

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "INSERT INTO Customer (Username, PasswordHash, FullName, Email, Phone, Address) " +
                                "VALUES (@Username, @PasswordHash, @FullName, @Email, @Phone, @Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", customer.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", customer.PasswordHash);
                cmd.Parameters.AddWithValue("@FullName", customer.FullName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", (object)customer.Phone ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)customer.Address ?? System.DBNull.Value);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public bool UsernameExists(string username)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Customer WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool UpdateProfile(Customer customer)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "UPDATE Customer SET FullName = @FullName, Email = @Email, " +
                                "Phone = @Phone, Address = @Address WHERE CustomerId = @CustomerId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", customer.FullName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", (object)customer.Phone ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)customer.Address ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@CustomerId", customer.Id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public System.Collections.Generic.List<Customer> GetAll()
        {
            var list = new System.Collections.Generic.List<Customer>();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "SELECT CustomerId, Username, PasswordHash, FullName, Email, Phone, Address, CreatedAt FROM Customer";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapReaderToCustomer(reader));
                    }
                }
            }
            return list;
        }

        private Customer MapReaderToCustomer(SqlDataReader reader)
        {
            return new Customer
            {
                Id = (int)reader["CustomerId"],
                Username = reader["Username"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                FullName = reader["FullName"].ToString(),
                Email = reader["Email"].ToString(),
                Phone = reader["Phone"] == System.DBNull.Value ? null : reader["Phone"].ToString(),
                Address = reader["Address"] == System.DBNull.Value ? null : reader["Address"].ToString(),
                CreatedAt = (System.DateTime)reader["CreatedAt"]
            };
        }
    }
}
