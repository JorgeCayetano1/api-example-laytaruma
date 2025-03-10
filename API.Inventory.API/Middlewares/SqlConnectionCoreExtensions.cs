using Microsoft.Data.SqlClient;

namespace API.Inventory.API.Middlewares
{
    public static class SqlConnectionCoreExtensions
    {
        public static void AddSqlConnectionCore(this IServiceCollection services, string? connectionString)
        {
            // services.AddTransient<IDbConnection>(sp => new SqlConnection(connectionString));
            services.AddTransient<SqlConnection>(sp => new SqlConnection(connectionString));
        }
    }
}
