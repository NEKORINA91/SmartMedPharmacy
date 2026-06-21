using System.Configuration;
using System.Data.SqlClient;

namespace SmartMedPharmacy.DAL
{
    /// <summary>
    /// Central place that hands out SQL connections.
    /// Keeping this in one spot means the connection string
    /// only has to be changed in one place if the DB moves.
    /// </summary>
    public static class DbConnection
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["SmartMedPharmacyDB"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
