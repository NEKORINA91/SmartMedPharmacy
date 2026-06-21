using System.Data.SqlClient;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.DAL
{
    public class AdminDAL
    {
        /// <summary>
        /// Validates admin login credentials. Returns the Admin object
        /// if successful, or null if username/password don't match.
        /// </summary>
        public Admin Login(string username, string password)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                string query = "SELECT AdminId, Username, PasswordHash, FullName, Email, CreatedAt " +
                                "FROM Admin WHERE Username = @Username";
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
                            return new Admin
                            {
                                Id = (int)reader["AdminId"],
                                Username = reader["Username"].ToString(),
                                PasswordHash = storedHash,
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"].ToString(),
                                CreatedAt = (System.DateTime)reader["CreatedAt"]
                            };
                        }
                    }
                }
            }
            return null; // login failed
        }
    }
}
