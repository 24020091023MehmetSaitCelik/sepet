using Microsoft.Data.SqlClient;

namespace SepetApp
{
    public class DBConnection
    {
        private static readonly string connectionString =
            "Server=localhost;Database=sepet_db;User Id=sa;Password=1234;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
