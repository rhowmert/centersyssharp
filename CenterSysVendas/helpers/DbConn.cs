using MySql.Data.MySqlClient;
using System;

namespace helpers
{
    public class DbConn : IDisposable
    {
        private MySqlConnection _connection;

        public DbConn()
        {
            _connection = new MySqlConnection("Server=localhost;Database=centersys;Uid=root;Pwd=master;");
            _connection.Open();
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
