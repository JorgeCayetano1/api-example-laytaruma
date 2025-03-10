using System.Data;
using API.Inventory.CORE.Models;
using Microsoft.Data.SqlClient;

namespace API.Inventory.CORE.Repositories.Connection;

public interface IDbContext : IDisposable
{
    public Task<ResponseModel<int>> ExecuteAsync(string sql, SqlParameter[] parameters = null);
    public Task<ResponseModel<DataTable>> QueryAsync(string sql, SqlParameter[] parameters = null);
}