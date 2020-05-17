using System;
using System.Data.SqlClient;

namespace PersonnelDepartment.Helpers
{
    internal static class ConnectionFactory
    {
        private static string _connString = string.Empty;

        public static SqlConnection GetSqlConnection()
        {
            if(string.IsNullOrEmpty(_connString))
                throw new InvalidOperationException(RuStrings.ConnStringNotSet);

            var conn = new SqlConnection(_connString);
            conn.Open();
            return conn;
        }

        public static void SetConnectionString(string connectionString)
        {
            connectionString = connectionString.Trim();
            if(string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(RuStrings.EmptyConnString);
            _connString = connectionString;
        }
    }
}
