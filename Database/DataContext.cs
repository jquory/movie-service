using dummy_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dummy_api.Database;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Movie>().HasKey(x => x.MovieId);
        builder.Entity<Director>().HasKey(x => x.DirectorId);
        builder.Entity<Genre>().HasKey(x => x.GenreId);
    }

    public virtual DbSet<Movie> Movies { get; set; }
    public virtual DbSet<Director> Directors { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
}