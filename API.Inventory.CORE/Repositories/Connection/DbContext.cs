using System.Data;
using API.Inventory.CORE.Models;
using Microsoft.Data.SqlClient;

namespace API.Inventory.CORE.Repositories.Connection;

public class DbContext : IDbContext
{
    private readonly SqlConnection _dbConnection;
    private SqlTransaction _transaction;
    
    public DbContext(SqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<int> ExecuteAsync(string sql, SqlParameter[] parameters = null)
    {
        try
        {
            await using var cmd = new SqlCommand(sql, _dbConnection, _transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            if (_dbConnection.State == ConnectionState.Closed)
                await _dbConnection.OpenAsync();

            var rowAffected = await cmd.ExecuteNonQueryAsync();

            return rowAffected;
        }
        catch (SqlException ex)
        {
            var exception = ex.Message;
            return 0;
        }
        catch (Exception ex)
        {
            var exception = ex.Message;
            return 0;
        }
    }

    public async Task<DataTable?> QueryAsync(string sql, SqlParameter[] parameters = null)
    {
        try
        {
            await using var cmd = new SqlCommand(sql, _dbConnection, _transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            if (_dbConnection.State == ConnectionState.Closed)
                await _dbConnection.OpenAsync();

            await using var reader = await cmd.ExecuteReaderAsync();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable;
        } catch (SqlException ex)
        {
            var exception = ex.Message;
            return null;

        } catch (Exception ex)
        {
            var exception = ex.Message;
            return null;

        }
    }
    
    public async Task BeginTransactionAsync()
    {
        if (_dbConnection.State == ConnectionState.Closed)
            await _dbConnection.OpenAsync();
        _transaction = (SqlTransaction)await _dbConnection.BeginTransactionAsync();
    }
    
    public async Task CommitTransactionAsync()
    {
        await _transaction.CommitAsync();
        await _transaction.DisposeAsync();
        
    }
    
    public async Task RollbackTransactionAsync()
    {
        if (_transaction == null)
            return;
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
    }
        
    public void Dispose()
    {
            _transaction.Dispose();
        if (_dbConnection.State == ConnectionState.Open)
            _dbConnection.Close();
        _dbConnection.Dispose();
    }
}