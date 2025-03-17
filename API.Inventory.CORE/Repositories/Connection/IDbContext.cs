using System.Data;
using API.Inventory.CORE.Models;
using Microsoft.Data.SqlClient;

namespace API.Inventory.CORE.Repositories.Connection;

public interface IDbContext : IDisposable
{
    public Task<int> ExecuteAsync(string sql, SqlParameter[] parameters = null);
    public Task<DataTable?> QueryAsync(string sql, SqlParameter[] parameters = null);
    public Task BeginTransactionAsync();
    public Task CommitTransactionAsync();
    public Task RollbackTransactionAsync();
}