using MySql.Data.MySqlClient;

namespace CampManagement
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Server=localhost;Port=3309;Database=camp;Uid=root;Pwd=venny;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
