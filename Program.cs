using dummy_api.Database;
using dummy_api.Repositories.Movie;
using dummy_api.Services.Movie;
using dummy_api.Shared.Contracts.Movie;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DatabaseMovie");

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Transient).AddTransient<DataContext>();

// Register Repositories
builder.Services.AddTransient<IMovieRepository, MovieRepository>();

// Register Service
builder.Services.AddTransient<IMovieService, MovieService>();

// Register Controller
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
