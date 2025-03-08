using System.Data;
using Microsoft.Data.SqlClient;

namespace API.Inventory.CORE.Repositories.Connection;

public class DbContext : IDbContext
{
    private readonly SqlConnection _dbConnection;
    
    public DbContext(SqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<int> ExecuteAsync(string sql, SqlParameter[] parameters = null)
    {
        using (var cmd = new SqlCommand(sql, _dbConnection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            if (_dbConnection.State == ConnectionState.Closed)
                await _dbConnection.OpenAsync();

            return await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task<DataTable> QueryAsync(string sql, SqlParameter[] parameters = null)
    {
        using (var cmd = new SqlCommand(sql, _dbConnection))
        {
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            if (_dbConnection.State == ConnectionState.Closed)
                await _dbConnection.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
    }
        
    public void Dispose()
    {
        _dbConnection.Dispose();
    }
}