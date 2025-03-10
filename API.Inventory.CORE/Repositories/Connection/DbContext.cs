using System.Data;
using API.Inventory.CORE.Models;
using Microsoft.Data.SqlClient;

namespace API.Inventory.CORE.Repositories.Connection;

public class DbContext : IDbContext
{
    private readonly SqlConnection _dbConnection;
    
    public DbContext(SqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<ResponseModel<int>> ExecuteAsync(string sql, SqlParameter[] parameters = null)
    {
        try
        {
            using (var cmd = new SqlCommand(sql, _dbConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                if (_dbConnection.State == ConnectionState.Closed)
                    await _dbConnection.OpenAsync();

                var rowAffected = await cmd.ExecuteNonQueryAsync();
                var response = new ResponseModel<int>();

                if (rowAffected == 0)
                {
                    response.success = false;
                    response.errorMessage = "No rows affected";
                    return response;
                }
            
                response.success = true;
                return response;
            }
        }
        catch (SqlException ex)
        {
            var response = new ResponseModel<int>();
            response.success = false;
            response.errorMessage = ex.Message;
            return response;
        }
        catch (Exception ex)
        {
            var response = new ResponseModel<int>();
            response.success = false;
            response.errorMessage = ex.Message;
            return response;
        }
    }

    public async Task<ResponseModel<DataTable>> QueryAsync(string sql, SqlParameter[] parameters = null)
    {
        using (var cmd = new SqlCommand(sql, _dbConnection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            if (_dbConnection.State == ConnectionState.Closed)
                await _dbConnection.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                var dataTable = new DataTable();
                dataTable.Load(reader);
                
                var response = new ResponseModel<DataTable>();
                response.success = true;
                response.result = dataTable;
                return response;
            }
        }
    }
        
    public void Dispose()
    {
        if (_dbConnection.State == ConnectionState.Open)
            _dbConnection.Close();
        _dbConnection.Dispose();
    }
}