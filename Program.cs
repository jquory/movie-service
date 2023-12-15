using System.Text;
using dummy_api.Database;
using dummy_api.Repositories.Movie;
using dummy_api.Services.Movie;
using dummy_api.Shared.Contracts.Movie;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DatabaseMovie");

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Transient).AddTransient<DataContext>();

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Register Repositories
builder.Services.AddTransient<IMovieRepository, MovieRepository>();

// Register Service
builder.Services.AddTransient<IMovieService, MovieService>();

// Register Controller
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
