using API.Inventory.API.Middlewares;
using API.Inventory.CORE.Repositories.Connection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add sql connection
//builder.Services.AddSingleton<SqlConnectionCore>(sp =>
//{
//    var configuration = sp.GetRequiredService<IConfiguration>();
//    var connectionString = configuration.GetConnectionString("DefaultConnection");
//    if (string.IsNullOrWhiteSpace(connectionString))
//    {
//        throw new InvalidOperationException("Connection string is missing");
//    }
//    return new SqlConnectionCore(connectionString);
//});
DIExtensions.AddDependencyInjection(builder.Services);
SqlConnectionCoreExtensions.AddSqlConnectionCore(builder.Services, builder.Configuration.GetConnectionString("InventoryConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
