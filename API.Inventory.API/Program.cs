using API.Inventory.API.Middlewares;
using API.Inventory.CORE.Helpers;
using API.Inventory.CORE.Repositories.Connection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DIExtensions.AddDependencyInjection(builder.Services);
SqlConnectionCoreExtensions.AddSqlConnectionCore(builder.Services, builder.Configuration.GetConnectionString("InventoryConnection"));
builder.Services.AddAutoMapper(typeof(MapeoGenerico));

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
