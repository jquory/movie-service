using dummy_api.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseMovie");

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Transient).AddTransient<DataContext>();

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
