using dummy_api.Database;
using dummy_api.Shared.Contracts.Movie;
using dummy_api.Shared.DTO.Movie;
using dummy_api.Models.Entities;

namespace dummy_api.Repositories.Movie;

public class MovieRepository: IMovieRepository
{
    private readonly DataContext _db;

    public MovieRepository(DataContext db)
    {
        _db = db;
    }

    public (List<MovieResponse>?, Exception?) GetAllMovies()
    {
        try
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

            if (result.Count == 0)
            {
                return (null, new Exception("No movies found"));
            }

            return (result, null);
        }
        catch (Exception err)
        {
            return (null, new Exception(err.Message));
        }
    }

    public (MovieResponse?, Exception?) GetMovieById(Guid id)
    {
        try
        {
            var query = _db.Movies.Where(movie => movie.MovieId == id)
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

            var result = query.FirstOrDefault();

            if (result == null)
            {
                return (null, new Exception("No movies found")); 
            }

            return (result, null);
        }
        catch (Exception err)
        {
            return (null, new Exception(err.Message));
        }
    }

    public (MovieResponse?, Exception?) CreateMovie(MovieRequest? request)
    {
        try
        {
            if (request == null)
            {
                return (null, new Exception("request can not be null"));
            }
            
            var newMovie = new Models.Entities.Movie
            {
                Title = request.Title,
                ReleaseDate = request.ReleaseDate,
                Duration = request.Duration,
                Synopsis = request.Synopsis,
                DirectorId = request.DirectorId,
                GenreId = request.GenreId,
            };

            var newDirector = new Director
            {
                DirectorName = request.DirectorName,
            };

            var newGenre = new Genre
            {
                GenreName = request.GenreName,
            };
            
            _db.Movies.Add(newMovie);
            _db.Directors.Add(newDirector);
            _db.Genres.Add(newGenre);
            _db.SaveChanges();

            return (new MovieResponse()
            {
                Id = newMovie.MovieId,
            }, null);
        }
        catch (Exception err)
        {
            return (null, new Exception(err.Message));
        }
    }
}