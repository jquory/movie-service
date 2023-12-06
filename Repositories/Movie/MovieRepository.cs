using dummy_api.Database;
using dummy_api.Shared.Contracts.Movie;
using dummy_api.Shared.DTOs.Movie;

namespace dummy_api.Repositories.Movie;

public class MovieRepository: IMovieRepository
{
    private readonly DataContext _db;

    public MovieRepository(DataContext db)
    {
        _db = db;
    }

    public (List<MovieResponse>, Exception) GetAllMovies()
    {
        var query = _db.Movies
            .Join(_db.Directors, movie => movie.DirectorId, director => director.DirectorId,
                (movie, director) => new { movie, director })
            .Join(_db.Genres, @t => @t.movie.GenreId, genre => genre.GenreId,
                (result, genre) => new MovieResponse
                {
                    Id = result.movie.MovieId,
                    Title = result.movie.Title,
                    ReleaseDate = result.movie.ReleaseDate,
                    Duration = result.movie.Duration,
                    Synopsis = result.movie.Synopsis,
                    Director = result.director.DirectorName,
                    Genre = genre.GenreName,
                });

        var result = query.ToList();

        if (result == null)
        {
            return (null, new Exception("No movies found"));
        }

        return (result, null);
    }
}