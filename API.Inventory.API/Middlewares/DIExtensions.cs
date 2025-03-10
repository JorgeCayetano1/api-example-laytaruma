using API.Inventory.CORE;
using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Implementation;
using API.Inventory.CORE.Repositories.Interface;
using API.Inventory.CORE.Services.Implementation;
using API.Inventory.CORE.Services.Interface;
using AutoMapper;
using Microsoft.Data.SqlClient;

namespace API.Inventory.API.Middlewares
{
    public static class DIExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserInventoryService, UserInventoryInventoryService>();
            services.AddScoped<IUserInventoryRepository, UserInventoryInventoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContext, DbContext>();
        }
    }
}
