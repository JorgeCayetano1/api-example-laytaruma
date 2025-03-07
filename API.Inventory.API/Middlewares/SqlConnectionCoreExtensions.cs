﻿using API.Inventory.CORE.Repositories.Connection;
using Microsoft.Data.SqlClient;
using System.Data.Common;

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
            services.AddScoped<DbTransaction>( sp =>
            {
                var connection = sp.GetRequiredService<SqlConnectionCore>();
                return connection.BeginTransaction();
            });
            return services;
        }
    }
}
