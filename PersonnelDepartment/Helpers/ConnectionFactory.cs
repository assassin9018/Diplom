using System;
using System.Data.SqlClient;
using System.IO;

namespace PersonnelDepartment.Helpers
{
    internal static class ConnectionFactory
    {
        private const string ConnFileName = "SqlConn.txt";
        private static string _connString = string.Empty;
        private const string DefaultConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MSSQL\Data\PersonnelDepartment.mdf;Integrated Security=True;";

        static ConnectionFactory()
        {
            try
            {
                _connString = File.ReadAllText(ConnFileName);
            }
            catch
            {
                File.WriteAllText(ConnFileName, DefaultConnectionString);
                _connString = DefaultConnectionString;
            }
        }

        public static string GetConnectionString() => _connString;

        public static SqlConnection GetSqlConnection()
        {
            if(string.IsNullOrEmpty(_connString))
                throw new InvalidOperationException(RuStrings.ConnStringNotSet);

            var conn = new SqlConnection(_connString);
            conn.Open();
            return conn;
        }

        public static void ChangeConnectionString(string connectionString)
        {
            connectionString = connectionString.Trim();
            if(string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(RuStrings.EmptyConnString);
            _connString = connectionString;
            File.WriteAllText(ConnFileName, connectionString);
        }
    }
}
