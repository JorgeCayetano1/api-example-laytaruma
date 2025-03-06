using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Repositories.Connection
{
    public class SqlConnectionCore : IDisposable
    {
        private readonly string _connectionString;
        //private SqlConnection _connection;

        public SqlConnectionCore(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<SqlConnection> GetOpenConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public void CloseConnection()
        {
            this.GetOpenConnectionAsync().Result.Close();
        }

        public void Dispose()
        {

            this.GetOpenConnectionAsync().Result.Dispose();
        }


        // SUGGESTED SOLUTION
        //private readonly string _connectionString;
        //private SqlConnection _connection;

        //public SqlConnectionCore(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //public async Task<SqlConnection> GetOpenConnectionAsync()
        //{
        //    if (_connection == null)
        //    {
        //        _connection = new SqlConnection(_connectionString);
        //        await _connection.OpenAsync();
        //    }
        //    return _connection;
        //}

        //public void CloseConnection()
        //{
        //    _connection?.Close();
        //    _connection?.Dispose();
        //    _connection = null;
        //}

        //public void Dispose()
        //{
        //    CloseConnection();
        //}


    }

}

