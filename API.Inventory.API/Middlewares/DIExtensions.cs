using API.Inventory.CORE;
using API.Inventory.CORE.Repositories.Implementation;
using API.Inventory.CORE.Repositories.Interface;
using API.Inventory.CORE.Services.Implementation;
using API.Inventory.CORE.Services.Interface;

namespace API.Inventory.API.Middlewares
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
