using API.Inventory.CORE.Repositories.Connection;
using Microsoft.Data.SqlClient;

namespace API.Inventory.API.Middlewares
{
    public static class SqlConnectionCoreExtensions
    {
        //public static IServiceCollection AddSqlConnectionCore(this IServiceCollection services, string? connectionString)
        //{
        //    if (string.IsNullOrWhiteSpace(connectionString))
        //    {
        //        throw new InvalidOperationException("Connection string is missing");
        //    }
        //    services.AddScoped(x => new SqlConnectionCore(connectionString));
        //    return services;
        //}

        public static IServiceCollection AddSqlConnectionCore(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string is missing");
            }
            services.AddSingleton(new SqlConnectionCore(connectionString));
            services.AddScoped<SqlConnection>(sp =>
            {
                var sqlConnectionCore = sp.GetRequiredService<SqlConnectionCore>();
                return sqlConnectionCore.GetOpenConnectionAsync().GetAwaiter().GetResult();
            });
            services.AddScoped<SqlTransaction>(sp =>
            {
                var connection = sp.GetRequiredService<SqlConnection>();
                return connection.BeginTransaction();
            });
            return services;
        }
    }
}
