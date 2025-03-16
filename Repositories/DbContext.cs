using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FootballAdministration.Repositories
{
    public sealed class DbContext : IDisposable
    {
        private const string ConnectionString =
            "Data Source=.;Initial Catalog=FootballAdministration;Integrated Security=True;TrustServerCertificate=True;";
        
        private SqlConnection _connection;
        
        public SqlConnection GetConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
            }
            return _connection;
        }
        
        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}

